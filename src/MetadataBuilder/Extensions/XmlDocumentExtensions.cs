// MIT License
// Copyright (c) 2019 Dina Heidar
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY
//
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM
//
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//

using System;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using Microsoft.IdentityModel.Tokens;
using Saml.MetadataBuilder.Constants;

namespace Saml.MetadataBuilder
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlDocumentExtensions
    {
        /// <summary>
        /// Adds the Rsa signature.
        /// </summary>
        /// <param name="xml">The XML.</param>
        /// <param name="x509Certificate2">The X509 certificate2.</param>
        /// <returns></returns>
        public static XmlDocument AddSignature(this XmlDocument xml, X509Certificate2 x509Certificate2)
        {
            //set key, signtureMethod based on certificate type

            var (key, signatureMethod, keyName) = SetSignatureAlgorithm(x509Certificate2);

            var signedXml = new SignedXml(xml) { SigningKey = key };
            signedXml.SignedInfo.SignatureMethod = signatureMethod;

            // Canonicalization tells the verifier of the XML how to turn the Signature element
            // from XML into bytes so that it can validate the signature. For example,
            // here you are using “http://www.w3.org/2001/10/xml-exc-c14n#”,
            // a very common canonicalization method, seen in heavy use in the SAML world.
            signedXml.SignedInfo.CanonicalizationMethod = SecurityAlgorithms.ExclusiveC14n;

            // sign whole document using "SAML style" transforms
            // Also of note is that you are signing all of the XML,
            // which is why you are using an empty string as the reference URI.
            // If you were to have multiple signatures or sign particular parts of the XML,
            // you would need to set this URI to point to the ID of that element
            var reference = new Reference { Uri = string.Empty };

            // Transforms, on the other hand, describe how to turn the XML that you signed into bytes.
            // If the verifier doesn’t know how you did this, they will likely not reproduce the same bytes,
            // and it will appear as an invalid signature. For example, here you are
            // using “http://www.w3.org/2000/09/xmldsig#enveloped-signature”,
            // which tells the validator that it should remove the signature element from the document
            // before it validates the signature.
            reference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            reference.AddTransform(new XmlDsigExcC14NTransform());
            signedXml.AddReference(reference);

            // OPTIONAL: embed the public key in the XML.
            // This MUST NOT be trusted during validation (used for debugging only)
            var keyInfo = new KeyInfo();
            keyInfo.AddClause(new KeyInfoX509Data(x509Certificate2));
            keyInfo.AddClause(new KeyInfoName(keyName));
            signedXml.KeyInfo = keyInfo;

            // create signature
            signedXml.ComputeSignature();

            // get signature XML element and add it as a child of the root element
            // it must be prepended not appended
            signedXml.GetXml();
            xml.DocumentElement?.PrependChild(signedXml.GetXml());
            return xml;
        }

        private static (AsymmetricAlgorithm key, string signatureMethod, string keyName) SetSignatureAlgorithm(X509Certificate2 x509Certificate2)
        {
            var keyName = x509Certificate2.GetPublicKeyString();
            var key = (AsymmetricAlgorithm)x509Certificate2.GetRSAPrivateKey() ?? x509Certificate2.GetECDsaPrivateKey();

            var signatureMethod = (AsymmetricAlgorithm)x509Certificate2.GetRSAPrivateKey() == null ?
                SecurityAlgorithms.EcdsaSha256Signature : SecurityAlgorithms.RsaSha256Signature;

            if (signatureMethod == SecurityAlgorithms.EcdsaSha256Signature)
            {
                // register custom signing algorithm
                CryptoConfig.AddAlgorithm(typeof(Ecdsa256SignatureDescription),
                    SecurityAlgorithms.EcdsaSha256Signature);
            }
            return (key, signatureMethod, keyName);
        }

        /// <summary>
        /// Validates the signature.
        /// </summary>
        /// <param name="xmlDoc">The XML document.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">
        /// Too many signatures!
        /// or
        /// Check your references!
        /// </exception>
        public static bool ValidateSignature(this XmlDocument xmlDoc)
        {
            var signedXml = new SignedXml(xmlDoc);
            var signatureElement = xmlDoc.GetElementsByTagName("Signature", NamespaceTypes.DsNamespace);

            // Checking If the Response or the Assertion has been signed once and only once.
            if (signatureElement.Count != 1)
                throw new InvalidOperationException("Too many signatures!");

            signedXml.LoadXml((XmlElement)signatureElement[0]);

            // a metadata might be multiple signing certificates (Idp have this).
            // get the correct one and check it
            var x509data = signedXml.Signature.KeyInfo.OfType<KeyInfoX509Data>().First();
            var signedCertificate = (X509Certificate2)x509data.Certificates[0];

            // validate references here!
            if ((signedXml.SignedInfo.References[0] as Reference)?.Uri != "")
                throw new InvalidOperationException("Check your references!");

            return signedXml.CheckSignature((AsymmetricAlgorithm)signedCertificate.GetRSAPublicKey() ??
                signedCertificate.GetECDsaPublicKey());
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Security.Cryptography.SignatureDescription" />
    public class Ecdsa256SignatureDescription : SignatureDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ecdsa256SignatureDescription"/> class.
        /// </summary>
        public Ecdsa256SignatureDescription()
        {
            KeyAlgorithm = typeof(ECDsa).AssemblyQualifiedName;
        }

        /// <summary>
        /// Creates a <see cref="T:System.Security.Cryptography.HashAlgorithm" /> instance using the <see cref="P:System.Security.Cryptography.SignatureDescription.DigestAlgorithm" /> property.
        /// </summary>
        /// <returns>
        /// The newly created <see cref="T:System.Security.Cryptography.HashAlgorithm" /> instance.
        /// </returns>
        public override HashAlgorithm CreateDigest() => SHA256.Create();

        /// <summary>
        /// Creates an <see cref="T:System.Security.Cryptography.AsymmetricSignatureFormatter" /> instance with the specified key using the <see cref="P:System.Security.Cryptography.SignatureDescription.FormatterAlgorithm" /> property.
        /// </summary>
        /// <param name="key">The key to use in the <see cref="T:System.Security.Cryptography.AsymmetricSignatureFormatter" />.</param>
        /// <returns>
        /// The newly created <see cref="T:System.Security.Cryptography.AsymmetricSignatureFormatter" /> instance.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Requires EC key using P-256</exception>
        public override AsymmetricSignatureFormatter CreateFormatter(AsymmetricAlgorithm key)
        {
            if (!(key is ECDsa ecdsa) || ecdsa.KeySize != 256)
                throw new InvalidOperationException("Requires EC key using P-256");
            return new EcdsaSignatureFormatter(ecdsa);
        }

        /// <summary>
        /// Creates an <see cref="T:System.Security.Cryptography.AsymmetricSignatureDeformatter" /> instance with the specified key using the <see cref="P:System.Security.Cryptography.SignatureDescription.DeformatterAlgorithm" /> property.
        /// </summary>
        /// <param name="key">The key to use in the <see cref="T:System.Security.Cryptography.AsymmetricSignatureDeformatter" />.</param>
        /// <returns>
        /// The newly created <see cref="T:System.Security.Cryptography.AsymmetricSignatureDeformatter" /> instance.
        /// </returns>
        /// <exception cref="System.InvalidOperationException">Requires EC key using P-256</exception>
        public override AsymmetricSignatureDeformatter CreateDeformatter(AsymmetricAlgorithm key)
        {
            if (!(key is ECDsa ecdsa) || ecdsa.KeySize != 256)
                throw new InvalidOperationException("Requires EC key using P-256");
            return new EcdsaSignatureDeformatter(ecdsa);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Security.Cryptography.AsymmetricSignatureFormatter" />
    public class EcdsaSignatureFormatter : AsymmetricSignatureFormatter
    {
        /// <summary>
        /// The key
        /// </summary>
        private ECDsa key;

        /// <summary>
        /// Initializes a new instance of the <see cref="EcdsaSignatureFormatter"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public EcdsaSignatureFormatter(ECDsa key) => this.key = key;

        /// <summary>
        /// When overridden in a derived class, sets the asymmetric algorithm to use to create the signature.
        /// </summary>
        /// <param name="key">The instance of the implementation of <see cref="T:System.Security.Cryptography.AsymmetricAlgorithm" /> to use to create the signature.</param>
        public override void SetKey(AsymmetricAlgorithm key) => this.key = key as ECDsa;

        /// <summary>
        /// When overridden in a derived class, sets the hash algorithm to use for creating the signature.
        /// </summary>
        /// <param name="strName">The name of the hash algorithm to use for creating the signature.</param>
        public override void SetHashAlgorithm(string strName) { }

        /// <summary>
        /// When overridden in a derived class, creates the signature for the specified data.
        /// </summary>
        /// <param name="rgbHash">The data to be signed.</param>
        /// <returns>
        /// The digital signature for the <paramref name="rgbHash" /> parameter.
        /// </returns>
        public override byte[] CreateSignature(byte[] rgbHash) => key.SignHash(rgbHash);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Security.Cryptography.AsymmetricSignatureDeformatter" />
    public class EcdsaSignatureDeformatter : AsymmetricSignatureDeformatter
    {
        /// <summary>
        /// The key
        /// </summary>
        private ECDsa key;

        /// <summary>
        /// Initializes a new instance of the <see cref="EcdsaSignatureDeformatter"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        public EcdsaSignatureDeformatter(ECDsa key) => this.key = key;

        /// <summary>
        /// When overridden in a derived class, sets the public key to use for verifying the signature.
        /// </summary>
        /// <param name="key">The instance of an implementation of <see cref="T:System.Security.Cryptography.AsymmetricAlgorithm" /> that holds the public key.</param>
        public override void SetKey(AsymmetricAlgorithm key) =>
            this.key = key as ECDsa;

        /// <summary>
        /// When overridden in a derived class, sets the hash algorithm to use for verifying the signature.
        /// </summary>
        /// <param name="strName">The name of the hash algorithm to use for verifying the signature.</param>
        public override void SetHashAlgorithm(string strName) { }

        /// <summary>
        /// When overridden in a derived class, verifies the signature for the specified data.
        /// </summary>
        /// <param name="rgbHash">The data signed with <paramref name="rgbSignature" />.</param>
        /// <param name="rgbSignature">The signature to be verified for <paramref name="rgbHash" />.</param>
        /// <returns>
        ///   <see langword="true" /> if <paramref name="rgbSignature" /> matches the signature computed using the specified hash algorithm and key on <paramref name="rgbHash" />; otherwise, <see langword="false" />.
        /// </returns>
        public override bool VerifySignature(byte[] rgbHash, byte[] rgbSignature) =>
            key.VerifyHash(rgbHash, rgbSignature);
    }
}
