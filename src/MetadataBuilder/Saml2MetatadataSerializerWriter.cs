//using Microsoft.IdentityModel.Xml;
//using System;
//using System.Globalization;
//using System.IO;
//using System.Text;
//using System.Xml;
//using System.Xml.Schema;

//namespace MetadataBuilder
//{
//    internal partial class Saml2MetatadataSerializer
//    {

//        #region Write Metadata
        
//            protected virtual void WriteApplicationServiceDescriptor(XmlWriter writer, ApplicationServiceDescriptor appService)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (appService == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("appService");
//                }

//                if (appService.Endpoints == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("appService.Endpoints");
//                }

//                if (appService.PassiveRequestorEndpoints == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("appService.PassiveRequestorEndpoints");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.RoleDescriptor, Saml2MetadataConstants.Namespace);
//                writer.WriteAttributeString("xsi", "type", XmlSchema.InstanceNamespace, FederationMetadataConstants.Prefix + ":" + FederationMetadataConstants.Elements.ApplicationServiceType);

//                writer.WriteAttributeString("xmlns", FederationMetadataConstants.Prefix, null, FederationMetadataConstants.Namespace);

//                WriteWebServiceDescriptorAttributes(writer, appService);
//                WriteCustomAttributes<ApplicationServiceDescriptor>(writer, appService);

//                WriteWebServiceDescriptorElements(writer, appService);

//                // Optional ApplicationServiceEndpoints
//                foreach (EndpointReference epr in appService.Endpoints)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.ApplicationServiceEndpoint, FederationMetadataConstants.Namespace);
//                    epr.WriteTo(writer);
//                    writer.WriteEndElement();
//                }

//                // Optional PassiveRequestorEndpoints
//                foreach (EndpointReference epr in appService.PassiveRequestorEndpoints)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.PassiveRequestorEndpoint, FederationMetadataConstants.Namespace);
//                    epr.WriteTo(writer);
//                    writer.WriteEndElement();
//                }

//                WriteCustomElements<ApplicationServiceDescriptor>(writer, appService);

//                writer.WriteEndElement();
//            }
//            protected virtual void WriteContactPerson(XmlWriter writer, ContactType contactPerson)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (contactPerson == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contactPerson");
//                }

//                if (contactPerson.EmailAddresses == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contactPerson.EmailAddresses");
//                }

//                if (contactPerson.TelephoneNumbers == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("contactPerson.TelephoneNumbers");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.ContactPerson, Saml2MetadataConstants.Namespace);
//                if (contactPerson.Type == ContactType.Unspecified)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.ContactType)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ContactType, null, contactPerson.Type.ToString().ToLowerInvariant());

//                WriteCustomAttributes<ContactPerson>(writer, contactPerson);

//                if (!String.IsNullOrEmpty(contactPerson.Company))
//                {
//                    writer.WriteElementString(Saml2MetadataConstants.Elements.Company, Saml2MetadataConstants.Namespace, contactPerson.Company);
//                }

//                if (!String.IsNullOrEmpty(contactPerson.GivenName))
//                {
//                    writer.WriteElementString(Saml2MetadataConstants.Elements.GivenName, Saml2MetadataConstants.Namespace, contactPerson.GivenName);
//                }

//                if (!String.IsNullOrEmpty(contactPerson.Surname))
//                {
//                    writer.WriteElementString(Saml2MetadataConstants.Elements.Surname, Saml2MetadataConstants.Namespace, contactPerson.Surname);
//                }

//                foreach (string email in contactPerson.EmailAddresses)
//                {
//                    writer.WriteElementString(Saml2MetadataConstants.Elements.EmailAddress, Saml2MetadataConstants.Namespace, email);
//                }

//                foreach (string phone in contactPerson.TelephoneNumbers)
//                {
//                    writer.WriteElementString(Saml2MetadataConstants.Elements.TelephoneNumber, Saml2MetadataConstants.Namespace, phone);
//                }

//                WriteCustomElements<ContactPerson>(writer, contactPerson);

//                writer.WriteEndElement();
//            }
//            protected virtual void WriteCustomAttributes<T>(XmlWriter writer, T source)
//            {
//                // Extensibility point only. Do Nothing.
//            }
//            protected virtual void WriteCustomElements<T>(XmlWriter writer, T source)
//            {
//                // Extensibility point only. Do Nothing.
//            }
//            protected virtual void WriteProtocolEndpoint(XmlWriter writer, EndpointType endpoint, XmlQualifiedName element)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (endpoint == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("endpoint");
//                }

//                if (element == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
//                }

//                writer.WriteStartElement(element.Name, element.Namespace);
//                if (endpoint.Binding == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.Binding)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Binding, null, (endpoint.Binding.IsAbsoluteUri ? endpoint.Binding.AbsoluteUri : endpoint.Binding.ToString()));

//                if (endpoint.Location == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.Location)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Location, null, (endpoint.Location.IsAbsoluteUri ? endpoint.Location.AbsoluteUri : endpoint.Location.ToString()));

//                if (endpoint.ResponseLocation != null)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ResponseLocation, null, (endpoint.ResponseLocation.IsAbsoluteUri ? endpoint.ResponseLocation.AbsoluteUri : endpoint.ResponseLocation.ToString()));
//                }

//                WriteCustomAttributes<EndpointType>(writer, endpoint);

//                WriteCustomElements<EndpointType>(writer, endpoint);
//                writer.WriteEndElement();
//            }
//            protected virtual void WriteDisplayClaim(XmlWriter writer, DisplayClaim claim)
//            {
//                // This is not extensible since it is defined in a different spec.
//                writer.WriteStartElement(WSAuthorizationConstants.Prefix, WSAuthorizationConstants.Elements.ClaimType, WSAuthorizationConstants.Namespace);

//                // ClaimType is mandatory
//                if (String.IsNullOrEmpty(claim.ClaimType))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, WSAuthorizationConstants.Elements.ClaimType)));
//                }

//                if (!UriUtil.CanCreateValidUri(claim.ClaimType, UriKind.Absolute))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID0014, claim.ClaimType)));
//                }

//                writer.WriteAttributeString(WSFederationMetadataConstants.Attributes.Uri, claim.ClaimType);

//                if (claim.WriteOptionalAttribute)
//                {
//                    writer.WriteAttributeString(WSFederationMetadataConstants.Attributes.Optional, XmlConvert.ToString(claim.Optional));
//                }

//                if (!String.IsNullOrEmpty(claim.DisplayTag))
//                {
//                    writer.WriteElementString(WSAuthorizationConstants.Prefix, WSAuthorizationConstants.Elements.DisplayName, WSAuthorizationConstants.Namespace, claim.DisplayTag);
//                }

//                if (!String.IsNullOrEmpty(claim.Description))
//                {
//                    writer.WriteElementString(WSAuthorizationConstants.Prefix, WSAuthorizationConstants.Elements.Description, WSAuthorizationConstants.Namespace, claim.Description);
//                }

//                writer.WriteEndElement(); // ClaimType
//            }
//            protected virtual void WriteEntitiesDescriptor(XmlWriter inputWriter, EntitiesDescriptorType entitiesDescriptor)
//            {
//                if (inputWriter == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("inputWriter");
//                }

//                if (entitiesDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("entitiesDescriptor");
//                }

//                if (entitiesDescriptor.ChildEntities == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("entitiesDescriptor.ChildEntities");
//                }

//                if (entitiesDescriptor.ChildEntityGroups == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("entitiesDescriptor.ChildEntityGroups");
//                }

//                string entityReference = "_" + Guid.NewGuid().ToString();
//                XmlWriter writer = inputWriter;
//                EnvelopedSignatureWriter signedWriter = null;
//                if (entitiesDescriptor.SigningCredentials != null)
//                {
//                    signedWriter = new EnvelopedSignatureWriter(inputWriter, entitiesDescriptor.SigningCredentials, entityReference, SecurityTokenSerializer);
//                    writer = signedWriter;
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.EntitiesDescriptor, Saml2MetadataConstants.Namespace);
//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Id, null, entityReference);

//                if (entitiesDescriptor.ChildEntities.Count == 0 && entitiesDescriptor.ChildEntityGroups.Count == 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.EntitiesDescriptor)));
//                }

//                // Ensure FederationID in all children are valid.
//                foreach (EntityDescriptor entity in entitiesDescriptor.ChildEntities)
//                {
//                    if (!String.IsNullOrEmpty(entity.FederationId))
//                    {
//                        if (!StringComparer.Ordinal.Equals(entity.FederationId, entitiesDescriptor.Name))
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, WSFederationMetadataConstants.Attributes.FederationId)));
//                        }
//                    }
//                }

//                if (!String.IsNullOrEmpty(entitiesDescriptor.Name))
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.EntityGroupName, null, entitiesDescriptor.Name);
//                }

//                WriteCustomAttributes<EntitiesDescriptor>(writer, entitiesDescriptor);

//                // WriteSamlMetadataBaseElements?

//                if (null != signedWriter)
//                {
//                    // Write the signature at the top of the sequence
//                    signedWriter.WriteSignature();
//                }

//                foreach (EntityDescriptor entity in entitiesDescriptor.ChildEntities)
//                {
//                    WriteEntityDescriptor(writer, entity);
//                }

//                foreach (EntitiesDescriptor entityGroup in entitiesDescriptor.ChildEntityGroups)
//                {
//                    WriteEntitiesDescriptor(writer, entityGroup);
//                }

//                WriteCustomElements<EntitiesDescriptor>(writer, entitiesDescriptor);

//                writer.WriteEndElement(); // EntitiesDescriptor
//            }
//            protected virtual void WriteEntityDescriptor(XmlWriter inputWriter, EntityDescriptorType entityDescriptor)
//            {
//                if (inputWriter == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("inputWriter");
//                }

//                if (entityDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("entityDescriptor");
//                }

//                if (entityDescriptor.Contacts == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("entityDescriptor.Contacts");
//                }

//                if (entityDescriptor.RoleDescriptors == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("entityDescriptor.RoleDescriptors");
//                }

//                string entityReference = "_" + Guid.NewGuid().ToString();
//                XmlWriter writer = inputWriter;
//                EnvelopedSignatureWriter signedWriter = null;
//                if (entityDescriptor.SigningCredentials != null)
//                {
//                    signedWriter = new EnvelopedSignatureWriter(inputWriter, entityDescriptor.SigningCredentials, entityReference, SecurityTokenSerializer);
//                    writer = signedWriter;
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.EntityDescriptor, Saml2MetadataConstants.Namespace);
//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Id, null, entityReference);

//                if (entityDescriptor.EntityId == null || entityDescriptor.EntityId.Id == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.EntityId)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.EntityId, null, entityDescriptor.EntityId.Id);

//                if (!String.IsNullOrEmpty(entityDescriptor.FederationId))
//                {
//                    writer.WriteAttributeString(WSFederationMetadataConstants.Attributes.FederationId, WSFederationMetadataConstants.Namespace, entityDescriptor.FederationId);
//                }

//                WriteCustomAttributes<EntityDescriptorType>(writer, entityDescriptor);

//                if (null != signedWriter)
//                {
//                    // Write the signature at the top of the sequence
//                    signedWriter.WriteSignature();
//                }

//                if (entityDescriptor.RoleDescriptors.Count == 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.RoleDescriptor)));
//                }

//                foreach (RoleDescriptor roleDescriptor in entityDescriptor.RoleDescriptors)
//                {
//                    SPSSODescriptorType spDesc = roleDescriptor as SPSSODescriptorType;
//                    if (spDesc != null)
//                    {
//                        WriteServiceProviderSingleSignOnDescriptor(writer, spDesc);
//                    }

//                    IDPSSODescriptorType idpDesc = roleDescriptor as IDPSSODescriptorType;
//                    if (idpDesc != null)
//                    {
//                        WriteIdentityProviderSingleSignOnDescriptor(writer, idpDesc);
//                    }

//                    ApplicationServiceDescriptor appService = roleDescriptor as ApplicationServiceDescriptor;
//                    if (appService != null)
//                    {
//                        WriteApplicationServiceDescriptor(writer, appService);
//                    }

//                    SecurityTokenServiceDescriptor stsService = roleDescriptor as SecurityTokenServiceDescriptor;
//                    if (stsService != null)
//                    {
//                        WriteSecurityTokenServiceDescriptor(writer, stsService);
//                    }
//                }

//                if (entityDescriptor.Organization != null)
//                {
//                    WriteOrganization(writer, entityDescriptor.Organization);
//                }

//                foreach (ContactType person in entityDescriptor.ContactPerson)
//                {
//                    WriteContactPerson(writer, person);
//                }

//                WriteCustomElements<EntityDescriptorType>(writer, entityDescriptor);

//                writer.WriteEndElement(); // EntityDescriptor
//            }
//            protected virtual void WriteIdentityProviderSingleSignOnDescriptor(XmlWriter writer, IDPSSODescriptorType identityProviderSingleSignOnDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (identityProviderSingleSignOnDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("idpssoDescriptor");
//                }

//                if (identityProviderSingleSignOnDescriptor.SupportedAttributes == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("idpssoDescriptor.SupportedAttributes");
//                }

//                if (identityProviderSingleSignOnDescriptor.SingleSignOnServices == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("idpssoDescriptor.SingleSignOnServices");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.IdpssoDescriptor, Saml2MetadataConstants.Namespace);
//                if (identityProviderSingleSignOnDescriptor.WantAuthenticationRequestsSigned)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.WantAuthenticationRequestsSigned, null,
//                        XmlConvert.ToString(identityProviderSingleSignOnDescriptor.WantAuthenticationRequestsSigned));
//                }

//                WriteSingleSignOnDescriptorAttributes(writer, identityProviderSingleSignOnDescriptor);
//                WriteCustomAttributes<IdentityProviderSingleSignOnDescriptor>(writer, identityProviderSingleSignOnDescriptor);

//                WriteSingleSignOnDescriptorElements(writer, identityProviderSingleSignOnDescriptor);

//                // Mandatory SingleSignonServiceEndpoint
//                if (identityProviderSingleSignOnDescriptor.SingleSignOnServices.Count == 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.SingleSignOnService)));
//                }

//                foreach (ProtocolEndpoint endpoint in identityProviderSingleSignOnDescriptor.SingleSignOnServices)
//                {
//                    if (endpoint.ResponseLocation != null)
//                    {
//                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3249, Saml2MetadataConstants.Attributes.ResponseLocation)));
//                    }

//                    XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.SingleSignOnService, Saml2MetadataConstants.Namespace);
//                    WriteProtocolEndpoint(writer, endpoint, element);
//                }

//                // Optional SupportedAttributes
//                foreach (Saml2Attribute attribute in identityProviderSingleSignOnDescriptor.SupportedAttributes)
//                {
//                    WriteAttribute(writer, attribute);
//                }

//                WriteCustomElements<IdentityProviderSingleSignOnDescriptor>(writer, identityProviderSingleSignOnDescriptor);

//                writer.WriteEndElement();
//            }
//            protected virtual void WriteIndexedProtocolEndpoint(XmlWriter writer, IndexedEndpointType indexedEP, XmlQualifiedName element)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (indexedEP == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("indexedEP");
//                }

//                if (element == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
//                }

//                writer.WriteStartElement(element.Name, element.Namespace);
//                if (indexedEP.Binding == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.Binding)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Binding, null, (indexedEP.Binding.IsAbsoluteUri ? indexedEP.Binding.AbsoluteUri : indexedEP.Binding.ToString()));

//                if (indexedEP.Location == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.Location)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Location, null, (indexedEP.Location.IsAbsoluteUri ? indexedEP.Location.AbsoluteUri : indexedEP.Location.ToString()));

//                if (indexedEP.Index < 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.EndpointIndex)));
//                }

//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.EndpointIndex, null, indexedEP.Index.ToString(CultureInfo.InvariantCulture));

//                if (indexedEP.ResponseLocation != null)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ResponseLocation, null, (indexedEP.ResponseLocation.IsAbsoluteUri ? indexedEP.ResponseLocation.AbsoluteUri : indexedEP.ResponseLocation.ToString()));
//                }

//                if (indexedEP.IsDefault.HasValue)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.EndpointIsDefault, null, XmlConvert.ToString(indexedEP.IsDefault.Value));
//                }

//                WriteCustomAttributes<IndexedProtocolEndpoint>(writer, indexedEP);
//                WriteCustomElements<IndexedProtocolEndpoint>(writer, indexedEP);
//                writer.WriteEndElement();
//            }
//            protected virtual void WriteKeyDescriptor(XmlWriter writer, KeyDescriptorType keyDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (keyDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("keyDescriptor");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.KeyDescriptor, Saml2MetadataConstants.Namespace);
//                if (keyDescriptor.Use == KeyType.Encryption || keyDescriptor.Use == KeyType.Signing)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Use, null, keyDescriptor.Use.ToString().ToLowerInvariant());
//                }

//                WriteCustomAttributes<KeyDescriptor>(writer, keyDescriptor);

//                if (keyDescriptor.KeyInfo == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, XmlSignatureConstants.Elements.KeyInfo)));
//                }

//                SecurityTokenSerializer.WriteKeyIdentifier(writer, keyDescriptor.KeyInfo);

//                // Write the encryption method element.
//                if (keyDescriptor.EncryptionMethods != null && keyDescriptor.EncryptionMethods.Count > 0)
//                {
//                    foreach (EncryptionMethod encryptionMethod in keyDescriptor.EncryptionMethods)
//                    {
//                        if (encryptionMethod.Algorithm == null)
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.Algorithm)));
//                        }

//                        if (!encryptionMethod.Algorithm.IsAbsoluteUri)
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID0014, Saml2MetadataConstants.Attributes.Algorithm)));
//                        }

//                        writer.WriteStartElement(Saml2MetadataConstants.Elements.EncryptionMethod, Saml2MetadataConstants.Namespace);
//                        writer.WriteAttributeString(Saml2MetadataConstants.Attributes.Algorithm, null, encryptionMethod.Algorithm.AbsoluteUri);
//                        writer.WriteEndElement();
//                    }
//                }

//                WriteCustomElements<KeyDescriptor>(writer, keyDescriptor);
//                writer.WriteEndElement();
//            }
//            protected virtual void WriteLocalizedName(XmlWriter writer, localizedNameType name, XmlQualifiedName element)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (name == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name");
//                }

//                if (element == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
//                }

//                if (name.Name == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("name.Name");
//                }

//                writer.WriteStartElement(element.Name, element.Namespace);
//                if (name.Language == null || String.IsNullOrEmpty(name.Name))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, LanguageLocalName)));
//                }

//                writer.WriteAttributeString(LanguagePrefix, LanguageLocalName, LanguageNamespaceUri, name.Language.Name);
//                WriteCustomAttributes<LocalizedName>(writer, name);
//                writer.WriteString(name.Name);
//                WriteCustomElements<LocalizedName>(writer, name);
//                writer.WriteEndElement();
//            }
//            protected virtual void WriteLocalizedUri(XmlWriter writer, localizedURIType uri, XmlQualifiedName element)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (uri == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("uri");
//                }

//                if (element == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("element");
//                }

//                writer.WriteStartElement(element.Name, element.Namespace);
//                if (uri.Language == null || uri.Uri == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, LanguageLocalName)));
//                }

//                writer.WriteAttributeString(LanguagePrefix, LanguageLocalName, LanguageNamespaceUri, uri.Language.Name);
//                WriteCustomAttributes<LocalizedUri>(writer, uri);
//                writer.WriteString(uri.Uri.IsAbsoluteUri ? uri.Uri.AbsoluteUri : uri.Uri.ToString());
//                WriteCustomElements<LocalizedUri>(writer, uri);
//                writer.WriteEndElement();
//            }
//            public void WriteMetadata(Stream stream, MetadataBase metadata)
//            {
//                if (stream == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
//                }

//                if (metadata == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("metadata");
//                }

//                using (XmlDictionaryWriter writer = XmlDictionaryWriter.CreateTextWriter(stream, Encoding.UTF8, false))
//                {
//                    WriteMetadata(writer, metadata);
//                }
//            }
//            public void WriteMetadata(XmlWriter writer, MetadataBase metadata)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (metadata == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("metadata");
//                }

//                WriteMetadataCore(writer, metadata);
//            }
//            protected virtual void WriteMetadataCore(XmlWriter writer, MetadataBase metadataBase)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (metadataBase == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("metadataBase");
//                }

//                EntitiesDescriptorType entitiesDescriptor = metadataBase as EntitiesDescriptorType;
//                if (entitiesDescriptor != null)
//                {
//                    WriteEntitiesDescriptor(writer, entitiesDescriptor);
//                }
//                else
//                {
//                    EntityDescriptorType entityDescriptor = metadataBase as EntityDescriptorType;
//                    if (entityDescriptor == null)
//                    {
//                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.EntitiesDescriptor)));
//                    }

//                    WriteEntityDescriptor(writer, entityDescriptor);
//                }
//            }
//            protected virtual void WriteOrganization(XmlWriter writer, OrganizationType organization)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (organization == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("organization");
//                }

//                if (organization.OrganizationDisplayName == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("organization.DisplayNames");
//                }

//                if (organization.OrganizationName == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("organization.Names");
//                }

//                if (organization.OrganizationURL == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("organization.Urls");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.Organization, Saml2MetadataConstants.Namespace);

//                if (organization.OrganizationName.Length < 1)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.OrganizationName)));
//                }

//                foreach (localizedNameType name in organization.OrganizationName)
//                {
//                    XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.OrganizationName, Saml2MetadataConstants.Namespace);
//                    WriteLocalizedName(writer, name, element);
//                }

//                if (organization.OrganizationDisplayName.Length < 1)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.OrganizationDisplayName)));
//                }

//                foreach (localizedNameType displayName in organization.OrganizationDisplayName)
//                {
//                    XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.OrganizationDisplayName, Saml2MetadataConstants.Namespace);
//                    WriteLocalizedName(writer, displayName, element);
//                }

//                if (organization.OrganizationURL.Length < 1)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.OrganizationUrl)));
//                }

//                foreach (localizedURIType uri in organization.OrganizationURL)
//                {
//                    XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.OrganizationUrl, Saml2MetadataConstants.Namespace);
//                    WriteLocalizedUri(writer, uri, element);
//                }

//                WriteCustomAttributes<OrganizationType>(writer, organization);
//                WriteCustomElements<OrganizationType>(writer, organization);
//                writer.WriteEndElement(); // Organization
//            }
//            protected virtual void WriteRoleDescriptorAttributes(XmlWriter writer, RoleDescriptorType roleDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (roleDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor");
//                }

//                if (roleDescriptor.protocolSupportEnumeration == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.ProtocolsSupported");
//                }

//                // Optional
//                if (roleDescriptor.validUntil != null && roleDescriptor.validUntil != DateTime.MaxValue)
//                {
//                    // Write the date in a sortable form.
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ValidUntil, null, roleDescriptor.validUntil.ToString("s", CultureInfo.InvariantCulture));
//                }

//                // Optional
//                if (roleDescriptor.errorURL != null)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ErrorUrl, null, (new Uri(roleDescriptor.errorURL).IsAbsoluteUri ? new Uri(roleDescriptor.errorURL).AbsoluteUri : roleDescriptor.errorURL.ToString()));
//                }

//                // Mandatory
//                if (roleDescriptor.protocolSupportEnumeration.Length == 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Attributes.ProtocolsSupported)));
//                }

//                StringBuilder sb = new StringBuilder();
//                foreach (string protocol in roleDescriptor.protocolSupportEnumeration)
//                {
//                    sb.AppendFormat("{0} ", (new Uri(protocol).IsAbsoluteUri ? new Uri(protocol).AbsoluteUri : protocol.ToString()));
//                }

//                string protocolsString = sb.ToString();
//                writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ProtocolsSupported, null, protocolsString.Trim());

//                WriteCustomAttributes<RoleDescriptorType>(writer, roleDescriptor);
//            }
//            protected virtual void WriteRoleDescriptorElements(XmlWriter writer, RoleDescriptorType roleDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (roleDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor");
//                }

//                if (roleDescriptor.ContactPerson == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.Contacts");
//                }

//                if (roleDescriptor.Keys == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.Keys");
//                }

//                // Optional
//                if (roleDescriptor.Organization != null)
//                {
//                    WriteOrganization(writer, roleDescriptor.Organization);
//                }

//                // Optional
//                foreach (KeyDescriptorType key in roleDescriptor.KeyDescriptor)
//                {
//                    WriteKeyDescriptor(writer, key);
//                }

//                // Optional
//                foreach (ContactType contact in roleDescriptor.ContactPerson)
//                {
//                    WriteContactPerson(writer, contact);
//                }

//                WriteCustomElements<RoleDescriptorType>(writer, roleDescriptor);
//            }
//            protected virtual void WriteSecurityTokenServiceDescriptor(XmlWriter writer, SecurityTokenServiceDescriptor securityTokenServiceDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (securityTokenServiceDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("securityTokenServiceDescriptor");
//                }

//                if (securityTokenServiceDescriptor.SecurityTokenServiceEndpoints == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("securityTokenServiceDescriptor.Endpoints");
//                }

//                if (securityTokenServiceDescriptor.PassiveRequestorEndpoints == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("securityTokenServiceDescriptor.PassiveRequestorEndpoints");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.RoleDescriptor, Saml2MetadataConstants.Namespace);
//                writer.WriteAttributeString("xsi", "type", XmlSchema.InstanceNamespace, FederationMetadataConstants.Prefix + ":" + FederationMetadataConstants.Elements.SecurityTokenServiceType);

//                writer.WriteAttributeString("xmlns", FederationMetadataConstants.Prefix, null, FederationMetadataConstants.Namespace);

//                WriteWebServiceDescriptorAttributes(writer, securityTokenServiceDescriptor);
//                WriteCustomAttributes<SecurityTokenServiceDescriptor>(writer, securityTokenServiceDescriptor);

//                WriteWebServiceDescriptorElements(writer, securityTokenServiceDescriptor);

//                if (securityTokenServiceDescriptor.SecurityTokenServiceEndpoints.Count == 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, FederationMetadataConstants.Elements.SecurityTokenServiceEndpoint)));
//                }

//                foreach (EndpointReference epr in securityTokenServiceDescriptor.SecurityTokenServiceEndpoints)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.SecurityTokenServiceEndpoint, FederationMetadataConstants.Namespace);
//                    epr.WriteTo(writer);
//                    writer.WriteEndElement();
//                }

//                foreach (EndpointReference epr in securityTokenServiceDescriptor.PassiveRequestorEndpoints)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.PassiveRequestorEndpoint, FederationMetadataConstants.Namespace);
//                    epr.WriteTo(writer);
//                    writer.WriteEndElement();
//                }

//                WriteCustomElements<SecurityTokenServiceDescriptor>(writer, securityTokenServiceDescriptor);

//                writer.WriteEndElement();
//            }
//            protected virtual void WriteServiceProviderSingleSignOnDescriptor(XmlWriter writer, SPSSODescriptorType serviceProviderSingleSignOnDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (serviceProviderSingleSignOnDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("spssoDescriptor");
//                }

//                if (serviceProviderSingleSignOnDescriptor.AssertionConsumerService == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("spssoDescriptor.AssertionConsumerService");
//                }

//                writer.WriteStartElement(Saml2MetadataConstants.Elements.SpssoDescriptor, Saml2MetadataConstants.Namespace);
//                if (serviceProviderSingleSignOnDescriptor.AuthnRequestsSigned)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.AuthenticationRequestsSigned, null,
//                        XmlConvert.ToString(serviceProviderSingleSignOnDescriptor.AuthnRequestsSigned));
//                }

//                if (serviceProviderSingleSignOnDescriptor.WantAssertionsSigned)
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.WantAssertionsSigned, null,
//                        XmlConvert.ToString(serviceProviderSingleSignOnDescriptor.WantAssertionsSigned));
//                }

//                WriteSingleSignOnDescriptorAttributes(writer, serviceProviderSingleSignOnDescriptor);
//                WriteCustomAttributes<SPSSODescriptorType>(writer, serviceProviderSingleSignOnDescriptor);

//                WriteSingleSignOnDescriptorElements(writer, serviceProviderSingleSignOnDescriptor);
//                if (serviceProviderSingleSignOnDescriptor.AssertionConsumerService.Length == 0)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3203, Saml2MetadataConstants.Elements.AssertionConsumerService)));
//                }

//                foreach (IndexedEndpointType ep in serviceProviderSingleSignOnDescriptor.AttributeConsumingService)
//                {
//                    XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.AssertionConsumerService, Saml2MetadataConstants.Namespace);
//                    WriteIndexedProtocolEndpoint(writer, ep, element);
//                }

//                WriteCustomElements<SPSSODescriptorType>(writer, serviceProviderSingleSignOnDescriptor);
//                writer.WriteEndElement(); // SPSSODescriptor
//            }
//            protected virtual void WriteSingleSignOnDescriptorAttributes(XmlWriter writer, SSODescriptorType singleSignOnDescriptor)
//            {
//                WriteRoleDescriptorAttributes(writer, singleSignOnDescriptor);
//                WriteCustomAttributes<SSODescriptorType>(writer, singleSignOnDescriptor);
//            }
//            protected virtual void WriteSingleSignOnDescriptorElements(XmlWriter writer, SSODescriptorType singleSignOnDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (singleSignOnDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ssoDescriptor");
//                }

//                WriteRoleDescriptorElements(writer, singleSignOnDescriptor);

//                if (singleSignOnDescriptor.ArtifactResolutionService != null && singleSignOnDescriptor.ArtifactResolutionService.Length > 0)
//                {
//                    // Write the artifact resolution services
//                    foreach (IndexedEndpointType ep in singleSignOnDescriptor.ArtifactResolutionService)
//                    {
//                        if (ep.ResponseLocation != null)
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID3249, Saml2MetadataConstants.Attributes.ResponseLocation)));
//                        }

//                        XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.ArtifactResolutionService, Saml2MetadataConstants.Namespace);
//                        WriteIndexedProtocolEndpoint(writer, ep, element);
//                    }
//                }

//                if (singleSignOnDescriptor.SingleLogoutService != null && singleSignOnDescriptor.SingleLogoutService.Length > 0)
//                {
//                    // Write the single logout service endpoints.
//                    foreach (EndpointType endpoint in singleSignOnDescriptor.SingleLogoutService)
//                    {
//                        XmlQualifiedName element = new XmlQualifiedName(Saml2MetadataConstants.Elements.SingleLogoutService, Saml2MetadataConstants.Namespace);
//                        WriteProtocolEndpoint(writer, endpoint, element);
//                    }
//                }

//                if (singleSignOnDescriptor.NameIDFormat != null && singleSignOnDescriptor.NameIDFormat.Length > 0)
//                {
//                    // Write the name id formats
//                    foreach (string nameId in singleSignOnDescriptor.NameIDFormat)
//                    {
//                        if (!new Uri(nameId).IsAbsoluteUri)
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new Saml2MetadataSerializationException(SR.GetString(SR.ID0014, Saml2MetadataConstants.Elements.NameIDFormat)));
//                        }

//                        writer.WriteStartElement(Saml2MetadataConstants.Elements.NameIDFormat, Saml2MetadataConstants.Namespace);
//                        writer.WriteString(new Uri(nameId).AbsoluteUri);
//                        writer.WriteEndElement();
//                    }
//                }

//                WriteCustomElements<SSODescriptorType>(writer, singleSignOnDescriptor);
//            }
//            protected virtual void WriteWebServiceDescriptorAttributes(XmlWriter writer, WebServiceDescriptor wsDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (wsDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("wsDescriptor");
//                }

//                WriteRoleDescriptorAttributes(writer, wsDescriptor);

//                if (!String.IsNullOrEmpty(wsDescriptor.ServiceDisplayName))
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ServiceDisplayName, null, wsDescriptor.ServiceDisplayName);
//                }

//                if (!String.IsNullOrEmpty(wsDescriptor.ServiceDescription))
//                {
//                    writer.WriteAttributeString(Saml2MetadataConstants.Attributes.ServiceDescription, null, wsDescriptor.ServiceDescription);
//                }

//                WriteCustomAttributes<WebServiceDescriptor>(writer, wsDescriptor);
//            }
//            protected virtual void WriteWebServiceDescriptorElements(XmlWriter writer, WebServiceDescriptor wsDescriptor)
//            {
//                if (writer == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (wsDescriptor == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("wsDescriptor");
//                }

//                if (wsDescriptor.TargetScopes == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("wsDescriptor.TargetScopes");
//                }

//                if (wsDescriptor.ClaimTypesOffered == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("wsDescriptor.ClaimTypesOffered");
//                }

//                if (wsDescriptor.TokenTypesOffered == null)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("wsDescriptor.TokenTypesOffered");
//                }

//                WriteRoleDescriptorElements(writer, wsDescriptor);

//                if (wsDescriptor.TokenTypesOffered.Count > 0)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.TokenTypesOffered, FederationMetadataConstants.Namespace);
//                    foreach (Uri tokenType in wsDescriptor.TokenTypesOffered)
//                    {
//                        writer.WriteStartElement(WSFederationMetadataConstants.Elements.TokenType, WSFederationMetadataConstants.Namespace);
//                        if (!tokenType.IsAbsoluteUri)
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3203, WSAuthorizationConstants.Elements.ClaimType)));
//                        }

//                        writer.WriteAttributeString(WSFederationMetadataConstants.Attributes.Uri, tokenType.AbsoluteUri);
//                        writer.WriteEndElement();
//                    }

//                    writer.WriteEndElement();
//                }

//                if (wsDescriptor.ClaimTypesOffered.Count > 0)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.ClaimTypesOffered, FederationMetadataConstants.Namespace);
//                    foreach (DisplayClaim claim in wsDescriptor.ClaimTypesOffered)
//                    {
//                        WriteDisplayClaim(writer, claim);
//                    }

//                    writer.WriteEndElement();
//                }

//                if (wsDescriptor.ClaimTypesRequested.Count > 0)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.ClaimTypesRequested, FederationMetadataConstants.Namespace);
//                    foreach (DisplayClaim claim in wsDescriptor.ClaimTypesRequested)
//                    {
//                        WriteDisplayClaim(writer, claim);
//                    }

//                    writer.WriteEndElement();
//                }

//                if (wsDescriptor.TargetScopes.Count > 0)
//                {
//                    writer.WriteStartElement(FederationMetadataConstants.Elements.TargetScopes, FederationMetadataConstants.Namespace);
//                    foreach (EndpointReference address in wsDescriptor.TargetScopes)
//                    {
//                        address.WriteTo(writer);
//                    }

//                    writer.WriteEndElement();
//                }

//                WriteCustomElements<WebServiceDescriptor>(writer, wsDescriptor);
//            }
//            protected virtual void WriteAttribute(XmlWriter writer, Saml2Attribute data)
//            {
//                if (null == writer)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("writer");
//                }

//                if (null == data)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("data");
//                }

//                // <Attribute>
//                writer.WriteStartElement(Saml2Constants.Elements.Attribute, Saml2Constants.Namespace);

//                // @Name - required
//                writer.WriteAttributeString(Saml2Constants.Attributes.Name, data.Name);

//                // @NameFormat - optional
//                if (null != data.NameFormat)
//                {
//                    writer.WriteAttributeString(Saml2Constants.Attributes.NameFormat, data.NameFormat.AbsoluteUri);
//                }

//                // @FriendlyName - optional
//                if (null != data.FriendlyName)
//                {
//                    writer.WriteAttributeString(Saml2Constants.Attributes.FriendlyName, data.FriendlyName);
//                }

//                // <AttributeValue> 0-OO (nillable)
//                foreach (string value in data.Values)
//                {
//                    writer.WriteStartElement(Saml2Constants.Elements.AttributeValue, Saml2Constants.Namespace);

//                    if (null == value)
//                    {
//                        writer.WriteAttributeString("nil", XmlSchema.InstanceNamespace, XmlConvert.ToString(true));
//                    }
//                    else if (value.Length > 0)
//                    {
//                        writer.WriteString(value);
//                    }

//                    writer.WriteEndElement();
//                }

//                // </Attribute>
//                writer.WriteEndElement();
//            }
//            // Wraps common data validation exceptions with an XmlException 
//            // associated with the failing reader
//            private static Exception TryWrapReadException(XmlReader reader, Exception inner)
//            {
//                if (inner is FormatException
//                    || inner is ArgumentException
//                    || inner is InvalidOperationException
//                    || inner is OverflowException)
//                {
//                    return DiagnosticUtility.ThrowHelperXml(reader, SR.GetString(SR.ID4125), inner);
//                }

//                return null;
//            }

//        #endregion
//    }
//}