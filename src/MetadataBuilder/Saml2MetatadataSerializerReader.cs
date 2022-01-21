
//using System.Xml;

//namespace MetadataBuilder
//{
//    internal partial class Saml2MetatadataSerializer
//    {
//        #region Read Metadata

//        /// <summary>
//        /// Reads application service descriptor.
//        /// </summary>
//        /// <param name="reader">Xml reader.</param>
//        /// <returns>An application service descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual ApplicationServiceDescriptor ReadApplicationServiceDescriptor(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            ApplicationServiceDescriptor appService = CreateApplicationServiceInstance();
//            ReadWebServiceDescriptorAttributes(reader, appService);
//            ReadCustomAttributes<ApplicationServiceDescriptor>(reader, appService);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(FederationMetadataConstants.Elements.ApplicationServiceEndpoint, FederationMetadataConstants.Namespace))
//                    {
//                        isEmpty = reader.IsEmptyElement;
//                        reader.ReadStartElement();
//                        if (!isEmpty && reader.IsStartElement())
//                        {
//                            EndpointReference address = EndpointReference.ReadFrom(reader);
//                            appService.Endpoints.Add(address);
//                            reader.ReadEndElement();
//                        }
//                    }
//                    else if (reader.IsStartElement(FederationMetadataConstants.Elements.PassiveRequestorEndpoint, FederationMetadataConstants.Namespace))
//                    {
//                        isEmpty = reader.IsEmptyElement;
//                        reader.ReadStartElement();
//                        if (!isEmpty && reader.IsStartElement())
//                        {
//                            EndpointReference address = EndpointReference.ReadFrom(reader);
//                            appService.PassiveRequestorEndpoints.Add(address);
//                            reader.ReadEndElement();
//                        }
//                    }
//                    else if (ReadWebServiceDescriptorElement(reader, appService))
//                    {
//                        // Do nothing
//                    }
//                    else if (ReadCustomElement<ApplicationServiceDescriptor>(reader, appService))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }

//                // SecurityTokenService
//                reader.ReadEndElement();
//            }

//            return appService;
//        }

//        /// <summary>
//        /// Reads a contact person.
//        /// </summary>
//        /// <param name="reader">Xml reader.</param>
//        /// <returns>A contact person.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual ContactPerson ReadContactPerson(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            ContactPerson person = CreateContactPersonInstance();

//            string contactType = reader.GetAttribute(Saml2MetadataConstants.Attributes.ContactType, null);
//            bool foundKey = false;

//            person.Type = GetContactPersonType(contactType, out foundKey);
//            if (!foundKey)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3201, typeof(ContactType), contactType)));
//            }

//            ReadCustomAttributes<ContactPerson>(reader, person);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement(); // <ContactPerson>
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(Saml2MetadataConstants.Elements.Company, Saml2MetadataConstants.Namespace))
//                    {
//                        person.Company = reader.ReadElementContentAsString(Saml2MetadataConstants.Elements.Company, Saml2MetadataConstants.Namespace);
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.GivenName, Saml2MetadataConstants.Namespace))
//                    {
//                        person.GivenName = reader.ReadElementContentAsString(Saml2MetadataConstants.Elements.GivenName, Saml2MetadataConstants.Namespace);
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.Surname, Saml2MetadataConstants.Namespace))
//                    {
//                        person.Surname = reader.ReadElementContentAsString(Saml2MetadataConstants.Elements.Surname, Saml2MetadataConstants.Namespace);
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.EmailAddress, Saml2MetadataConstants.Namespace))
//                    {
//                        string emailId = reader.ReadElementContentAsString(Saml2MetadataConstants.Elements.EmailAddress, Saml2MetadataConstants.Namespace);
//                        if (!String.IsNullOrEmpty(emailId))
//                        {
//                            person.EmailAddresses.Add(emailId);
//                        }
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.TelephoneNumber, Saml2MetadataConstants.Namespace))
//                    {
//                        string phone = reader.ReadElementContentAsString(Saml2MetadataConstants.Elements.TelephoneNumber, Saml2MetadataConstants.Namespace);
//                        if (!String.IsNullOrEmpty(phone))
//                        {
//                            person.TelephoneNumbers.Add(phone);
//                        }
//                    }
//                    else if (ReadCustomElement<ContactPerson>(reader, person))
//                    {
//                        // Do nothing
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }

//                }
//                reader.ReadEndElement(); // </ContactPerson>
//            }

//            // No mandatory elements to be validated.
//            return person;
//        }

//        /// <summary>
//        /// Extensibility point for reading custom attributes.
//        /// </summary>
//        /// <typeparam name="T">The type of element.</typeparam>
//        /// <param name="reader">Xml reader.</param>
//        /// <param name="target">An object of type T.</param>
//        protected virtual void ReadCustomAttributes<T>(XmlReader reader, T target)
//        {
//            // Extensibility point only. Do Nothing.
//        }

//        /// <summary>
//        /// Extensibility point for reading custom elements. By default this returns false.
//        /// </summary>
//        /// <typeparam name="T">The type of element.</typeparam>
//        /// <param name="reader">Xml reader.</param>
//        /// <param name="target">An object of type T.</param>
//        /// <returns>True if an element of type T is read, else false.</returns>
//        protected virtual bool ReadCustomElement<T>(XmlReader reader, T target)
//        {
//            // Extensibility point only. Do Nothing.
//            return false;
//        }

//        /// <summary>
//        /// Extensibility point for reading custom RoleDescriptors.
//        /// </summary>
//        /// <param name="xsiType">The xsi type</param>
//        /// <param name="reader">Xml reader</param>
//        /// <param name="entityDescriptor">The entity descriptor for adding the Role Descriptors</param>
//        protected virtual void ReadCustomRoleDescriptor(string xsiType, XmlReader reader, EntityDescriptor entityDescriptor)
//        {
//            //
//            // Extensibility point: Based on the xsiType, overriden implementations have the ability to read the RoleDescriptor 
//            // attributes from a (##other) namespace and add the Role Descriptors to the entityDescriptor
//            //
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            TraceUtility.TraceString(System.Diagnostics.TraceEventType.Warning, SR.GetString(SR.ID3274, xsiType));
//            reader.Skip();
//        }

//        /// <summary>
//        /// Returns the <see cref="DisplayClaim"/> from the <paramref name="reader"/>.
//        /// </summary>
//        /// <param name="reader">XML reader.</param>
//        /// <returns>The display claim.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        /// <exception cref="MetadataSerializationException">Thrown if the XML is not well-formed.</exception>
//        protected virtual DisplayClaim ReadDisplayClaim(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            //
//            // This is out of scope for extensibility.
//            //
//            string claimType = reader.GetAttribute(WSFederationMetadataConstants.Attributes.Uri, null);
//            if (!UriUtil.CanCreateValidUri(claimType, UriKind.Absolute))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, WSAuthorizationConstants.Elements.ClaimType, claimType)));
//            }
//            DisplayClaim claim = new DisplayClaim(claimType);

//            bool isOptional = true;
//            string optionalString = reader.GetAttribute(WSFederationMetadataConstants.Attributes.Optional);
//            if (!String.IsNullOrEmpty(optionalString))
//            {
//                try
//                {
//                    isOptional = XmlConvert.ToBoolean(optionalString.ToLowerInvariant());
//                }
//                catch (FormatException)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, WSFederationMetadataConstants.Attributes.Optional, optionalString)));
//                }
//            }
//            claim.Optional = isOptional;

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(WSAuthorizationConstants.Elements.DisplayName, WSAuthorizationConstants.Namespace))
//                    {
//                        claim.DisplayTag = reader.ReadElementContentAsString(WSAuthorizationConstants.Elements.DisplayName, WSAuthorizationConstants.Namespace);
//                    }
//                    else if (reader.IsStartElement(WSAuthorizationConstants.Elements.Description, WSAuthorizationConstants.Namespace))
//                    {
//                        claim.Description = reader.ReadElementContentAsString(WSAuthorizationConstants.Elements.Description, WSAuthorizationConstants.Namespace);
//                    }
//                    else
//                    {
//                        // Move on
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }
//            return claim;
//        }

//        /// <summary>
//        /// Reads entities descriptor.
//        /// </summary>
//        /// <param name="reader">Xml reader.</param>
//        /// <param name="tokenResolver">The security token resolver.</param>
//        /// <returns>The entities descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        /// <exception cref="MetadataSerializationException">Thrown if the XML is not well-formed.</exception>
//        protected virtual EntitiesDescriptor ReadEntitiesDescriptor(XmlReader reader, SecurityTokenResolver tokenResolver)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            EntitiesDescriptor resultEntityGroup = CreateEntitiesDescriptorInstance();

//            //
//            // There may be embedded signed XML elements. So we need to plumb the SecurityTokenSerializer and tokenResolver
//            //
//            EnvelopedSignatureReader envelopeReader = new EnvelopedSignatureReader(reader, SecurityTokenSerializer, tokenResolver, false, false, true);

//            string name = envelopeReader.GetAttribute(Saml2MetadataConstants.Attributes.EntityGroupName, null);
//            if (!String.IsNullOrEmpty(name))
//            {
//                resultEntityGroup.Name = name;
//            }

//            ReadCustomAttributes<EntitiesDescriptor>(envelopeReader, resultEntityGroup);

//            bool isEmpty = envelopeReader.IsEmptyElement;
//            envelopeReader.ReadStartElement(); // <EntitiesDescriptor>
//            if (!isEmpty)
//            {
//                while (envelopeReader.IsStartElement())
//                {
//                    if (envelopeReader.IsStartElement(Saml2MetadataConstants.Elements.EntityDescriptor, Saml2MetadataConstants.Namespace))
//                    {
//                        resultEntityGroup.ChildEntities.Add(ReadEntityDescriptor(envelopeReader, tokenResolver));
//                    }
//                    else if (envelopeReader.IsStartElement(Saml2MetadataConstants.Elements.EntitiesDescriptor, Saml2MetadataConstants.Namespace))
//                    {
//                        resultEntityGroup.ChildEntityGroups.Add(ReadEntitiesDescriptor(envelopeReader, tokenResolver));
//                    }
//                    else if (envelopeReader.TryReadSignature())
//                    {
//                        // Do nothng
//                    }
//                    else if (ReadCustomElement<EntitiesDescriptor>(envelopeReader, resultEntityGroup))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        envelopeReader.Skip();
//                    }

//                }
//                envelopeReader.ReadEndElement(); // </EntitiesDescriptor>
//            }

//            resultEntityGroup.SigningCredentials = envelopeReader.SigningCredentials;

//            if (resultEntityGroup.SigningCredentials != null)
//            {
//                ValidateSigningCredential(resultEntityGroup.SigningCredentials);
//            }

//            if (resultEntityGroup.ChildEntityGroups.Count == 0 && resultEntityGroup.ChildEntities.Count == 0)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3200, Saml2MetadataConstants.Elements.EntityDescriptor)));
//            }
//            foreach (EntityDescriptor entity in resultEntityGroup.ChildEntities)
//            {
//                if (!String.IsNullOrEmpty(entity.FederationId))
//                {
//                    if (!StringComparer.Ordinal.Equals(entity.FederationId, resultEntityGroup.Name))
//                    {
//                        throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, WSFederationMetadataConstants.Attributes.FederationId, entity.FederationId)));
//                    }
//                }
//            }
//            return resultEntityGroup;
//        }

//        /// <summary>
//        /// Gets or sets the validation mode of the X509 certificate that is used to sign the metadata document.
//        /// </summary>
//        public X509CertificateValidationMode CertificateValidationMode
//        {
//            get;
//            set;
//        }

//        /// <summary>
//        /// Gets or sets the revocation mode of the X509 certificate that is used to sign the metadata document.
//        /// </summary>
//        public X509RevocationMode RevocationMode
//        {
//            get;
//            set;
//        }

//        /// <summary>
//        /// Gets or sets the trusted store location of the X509 certificate that is used to sign the metadata document.
//        /// </summary>
//        public StoreLocation TrustedStoreLocation
//        {
//            get;
//            set;
//        }

//        /// <summary>
//        /// Gets or sets the certificate validator of the X509 certificate that is used to sign the metadata document.
//        /// </summary>
//        public X509CertificateValidator CertificateValidator
//        {
//            get;
//            set;
//        }

//        /// <summary>
//        /// Gets the list of trusted issuer that this serializer instance trusts to sign the metadata docuemnt.
//        /// </summary>
//        public List<string> TrustedIssuers
//        {
//            get { return _trustedIssuers; }
//        }

//        /// <summary>
//        /// Validates the signing credential of the metadata document.
//        /// </summary>
//        /// <param name="signingCredentials">The signing credential used to sign the metadata document.</param>
//        /// <exception cref="ArgumentNullException">If <paramref name="signingCredentials"/> is null.</exception>
//        protected virtual void ValidateSigningCredential(SigningCredentials signingCredentials)
//        {
//            if (signingCredentials == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("signingCredentials");
//            }

//            if (CertificateValidationMode != X509CertificateValidationMode.Custom)
//            {
//                CertificateValidator = X509Util.CreateCertificateValidator(CertificateValidationMode, RevocationMode, TrustedStoreLocation);
//            }
//            else if (CertificateValidationMode == X509CertificateValidationMode.Custom && CertificateValidator == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString(SR.ID4280)));
//            }

//            X509Certificate2 certificate = GetMetadataSigningCertificate(signingCredentials.SigningKeyIdentifier);

//            ValidateIssuer(certificate);
//            CertificateValidator.Validate(certificate);
//        }

//        /// <summary>
//        /// Validates the certificate that signed the metadata document against the TrustedIssuers. This method is invoked by the ValidateSigningCredential method.
//        /// By default, this method does not perform any validation. Provide your own implementation to perform trusted issuer validation.
//        /// </summary>
//        /// <param name="signingCertificate">The signing certificate.</param>
//        protected virtual void ValidateIssuer(X509Certificate2 signingCertificate)
//        {
//            // No-op by default.
//        }

//        /// <summary>
//        /// Gets the <see cref="X509Certificate2"/> instance created from the <paramref name="ski"/>.
//        /// By default, this method only supports <see cref="X509RawDataKeyIdentifierClause"/>. Override this method
//        /// to support other key identifier clauses. This method is invoked by the ValidateSigningCredential method.
//        /// </summary>
//        /// <param name="ski">The security key identifier instance.</param>
//        /// <returns>An <see cref="X509Certificate2"/> instance.</returns>
//        protected virtual X509Certificate2 GetMetadataSigningCertificate(SecurityKeyIdentifier ski)
//        {
//            if (ski == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ski");
//            }

//            X509RawDataKeyIdentifierClause clause = null;
//            if (ski.TryFind<X509RawDataKeyIdentifierClause>(out clause))
//            {
//                return new X509Certificate2(clause.GetX509RawData());
//            }
//            else
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new InvalidOperationException(SR.GetString(SR.ID8029)));
//            }
//        }

//        /// <summary>
//        /// Reads an entity descriptor.
//        /// </summary>
//        /// <param name="inputReader">The xml reader.</param>
//        /// <param name="tokenResolver">The security token resolver.</param>
//        /// <returns>An entity descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter inputReader is null.</exception>
//        protected virtual EntityDescriptor ReadEntityDescriptor(XmlReader inputReader, SecurityTokenResolver tokenResolver)
//        {
//            if (inputReader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("inputReader");
//            }

//            EntityDescriptor resultEntity = CreateEntityDescriptorInstance();

//            //
//            // There may be embedded signed XML elements. So we need to plumb the SecurityTokenSerializer and tokenResolver
//            // IDFX 

//            EnvelopedSignatureReader reader = new EnvelopedSignatureReader(inputReader, SecurityTokenSerializer, tokenResolver, false, false, true);

//            // EntityID is mandatory - relaxed as per FIP 9935
//            string entityId = reader.GetAttribute(Saml2MetadataConstants.Attributes.EntityId, null);
//            if (!String.IsNullOrEmpty(entityId))
//            {
//                resultEntity.EntityId = new EntityId(entityId);
//            }

//            // FederationID is optional
//            string fedId = reader.GetAttribute(WSFederationMetadataConstants.Attributes.FederationId, WSFederationMetadataConstants.Namespace);
//            if (!String.IsNullOrEmpty(fedId))
//            {
//                resultEntity.FederationId = fedId;
//            }

//            ReadCustomAttributes<EntityDescriptor>(reader, resultEntity);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(Saml2MetadataConstants.Elements.SpssoDescriptor, Saml2MetadataConstants.Namespace))
//                    {
//                        resultEntity.RoleDescriptors.Add(ReadServiceProviderSingleSignOnDescriptor(reader));
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.IdpssoDescriptor, Saml2MetadataConstants.Namespace))
//                    {
//                        resultEntity.RoleDescriptors.Add(ReadIdentityProviderSingleSignOnDescriptor(reader));
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.RoleDescriptor, Saml2MetadataConstants.Namespace))
//                    {
//                        string xsiType = reader.GetAttribute("type", XmlSchema.InstanceNamespace);

//                        if (!String.IsNullOrEmpty(xsiType))
//                        {
//                            int index = xsiType.IndexOf(":", 0, StringComparison.Ordinal);
//                            if (index < 0)
//                            {
//                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3207, "xsi:type", Saml2MetadataConstants.Elements.RoleDescriptor, xsiType)));
//                            }
//                            string prefix = xsiType.Substring(0, index);
//                            string ns = reader.LookupNamespace(prefix);

//                            if (String.IsNullOrEmpty(ns))
//                            {
//                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, prefix, ns)));
//                            }
//                            else if (!StringComparer.Ordinal.Equals(ns, FederationMetadataConstants.Namespace))
//                            {
//                                ReadCustomRoleDescriptor(xsiType, reader, resultEntity);
//                            }
//                            else if (StringComparer.Ordinal.Equals(xsiType, prefix + ":" + FederationMetadataConstants.Elements.ApplicationServiceType))
//                            {
//                                resultEntity.RoleDescriptors.Add(ReadApplicationServiceDescriptor(reader));
//                            }
//                            else if (StringComparer.Ordinal.Equals(xsiType, prefix + ":" + FederationMetadataConstants.Elements.SecurityTokenServiceType))
//                            {
//                                resultEntity.RoleDescriptors.Add(ReadSecurityTokenServiceDescriptor(reader));
//                            }
//                            else
//                            {
//                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3207, "xsi:type", Saml2MetadataConstants.Elements.RoleDescriptor, xsiType)));
//                            }
//                        }
//                        else
//                        {
//                            throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID0001, "xsi:type", Saml2MetadataConstants.Elements.RoleDescriptor)));
//                        }
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.Organization, Saml2MetadataConstants.Namespace))
//                    {
//                        resultEntity.Organization = ReadOrganization(reader);
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.ContactPerson, Saml2MetadataConstants.Namespace))
//                    {
//                        resultEntity.Contacts.Add(ReadContactPerson(reader));
//                    }
//                    else if (reader.TryReadSignature())
//                    {
//                        // Do nothing
//                    }
//                    else if (ReadCustomElement<EntityDescriptor>(reader, resultEntity))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            resultEntity.SigningCredentials = reader.SigningCredentials;
//            if (resultEntity.SigningCredentials != null)
//            {
//                ValidateSigningCredential(resultEntity.SigningCredentials);
//            }

//            // Elements are optional. Mandatory attributes already validated.

//            return resultEntity;
//        }

//        /// <summary>
//        /// Reads an idpsso descriptor.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>An idpsso descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual IdentityProviderSingleSignOnDescriptor ReadIdentityProviderSingleSignOnDescriptor(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            IdentityProviderSingleSignOnDescriptor idpssoDescriptor = CreateIdentityProviderSingleSignOnDescriptorInstance();
//            ReadSingleSignOnDescriptorAttributes(reader, idpssoDescriptor);
//            ReadCustomAttributes<IdentityProviderSingleSignOnDescriptor>(reader, idpssoDescriptor);

//            string wantAuthnRequestSignedAttribute = reader.GetAttribute(Saml2MetadataConstants.Attributes.WantAuthenticationRequestsSigned);
//            if (!String.IsNullOrEmpty(wantAuthnRequestSignedAttribute))
//            {
//                try
//                {
//                    idpssoDescriptor.WantAuthenticationRequestsSigned = XmlConvert.ToBoolean(wantAuthnRequestSignedAttribute.ToLowerInvariant());
//                }
//                catch (FormatException)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(
//                        SR.ID3202, Saml2MetadataConstants.Attributes.WantAuthenticationRequestsSigned, wantAuthnRequestSignedAttribute)));
//                }
//            }

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(Saml2MetadataConstants.Elements.SingleSignOnService, Saml2MetadataConstants.Namespace))
//                    {
//                        ProtocolEndpoint endpoint = ReadProtocolEndpoint(reader);

//                        // Relaxed check for endpoint.ResponseLocation as per FIP 9935
//                        idpssoDescriptor.SingleSignOnServices.Add(endpoint);
//                    }
//                    else if (reader.IsStartElement(Saml2Constants.Elements.Attribute, Saml2Constants.Namespace))
//                    {
//                        idpssoDescriptor.SupportedAttributes.Add(ReadAttribute(reader));
//                    }
//                    else if (ReadSingleSignOnDescriptorElement(reader, idpssoDescriptor))
//                    {
//                        // Do nothing
//                    }
//                    else if (ReadCustomElement<IdentityProviderSingleSignOnDescriptor>(reader, idpssoDescriptor))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            // Relaxed check for( idpssoDescriptor.SingleSignOnServices.Count == 0 ) as per FIP 9935
//            return idpssoDescriptor;
//        }

//        /// <summary>
//        /// Reads an indexed endpoint.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>An indexed endpoint.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual IndexedProtocolEndpoint ReadIndexedProtocolEndpoint(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            IndexedProtocolEndpoint endpoint = CreateIndexedProtocolEndpointInstance();

//            string binding = reader.GetAttribute(Saml2MetadataConstants.Attributes.Binding, null);
//            Uri bindingUri;
//            if (!UriUtil.TryCreateValidUri(binding, UriKind.RelativeOrAbsolute, out bindingUri))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.Binding, binding)));
//            }
//            endpoint.Binding = bindingUri;

//            string location = reader.GetAttribute(Saml2MetadataConstants.Attributes.Location, null);
//            Uri locationUri;
//            if (!UriUtil.TryCreateValidUri(location, UriKind.RelativeOrAbsolute, out locationUri))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.Location, location)));
//            }
//            endpoint.Location = locationUri;

//            string indexStr = reader.GetAttribute(Saml2MetadataConstants.Attributes.EndpointIndex, null);
//            int index;
//            if (!Int32.TryParse(indexStr, out index))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.EndpointIndex, indexStr)));
//            }
//            endpoint.Index = index;

//            // responseLocation is optional
//            string responseLocation = reader.GetAttribute(Saml2MetadataConstants.Attributes.ResponseLocation, null);
//            if (!String.IsNullOrEmpty(responseLocation))
//            {
//                Uri responseUri;
//                if (!UriUtil.TryCreateValidUri(responseLocation, UriKind.RelativeOrAbsolute, out responseUri))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.ResponseLocation, responseLocation)));
//                }
//                endpoint.ResponseLocation = responseUri;
//            }

//            // isDefault is optional
//            string isDefaultString = reader.GetAttribute(Saml2MetadataConstants.Attributes.EndpointIsDefault, null);
//            if (!String.IsNullOrEmpty(isDefaultString))
//            {
//                try
//                {
//                    endpoint.IsDefault = XmlConvert.ToBoolean(isDefaultString.ToLowerInvariant());
//                }
//                catch (FormatException)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.EndpointIsDefault, isDefaultString)));
//                }
//            }

//            ReadCustomAttributes<IndexedProtocolEndpoint>(reader, endpoint);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (ReadCustomElement<IndexedProtocolEndpoint>(reader, endpoint))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        // Move on
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            // No elements to validate. Attributes are already validated
//            return endpoint;
//        }

//        /// <summary>
//        /// Reads a key descriptor.
//        /// </summary>
//        /// <param name="reader">Xml reader.</param>
//        /// <returns>The key descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual KeyDescriptor ReadKeyDescriptor(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            KeyDescriptor resultKey = CreateKeyDescriptorInstance();

//            // Use is optional
//            string use = reader.GetAttribute(Saml2MetadataConstants.Attributes.Use, null);
//            if (!String.IsNullOrEmpty(use))
//            {
//                resultKey.Use = GetKeyDescriptorType(use);
//            }

//            ReadCustomAttributes<KeyDescriptor>(reader, resultKey);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(XmlSignatureConstants.Elements.KeyInfo, XmlSignatureConstants.Namespace))
//                    {
//                        resultKey.KeyInfo = SecurityTokenSerializer.ReadKeyIdentifier(reader);
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.EncryptionMethod, Saml2MetadataConstants.Namespace))
//                    {
//                        // Read the required algorithm attribute - relaxed as per FIP 9935
//                        string algorithm = reader.GetAttribute(Saml2MetadataConstants.Attributes.Algorithm);
//                        if (!String.IsNullOrEmpty(algorithm) && UriUtil.CanCreateValidUri(algorithm, UriKind.Absolute))
//                        {
//                            resultKey.EncryptionMethods.Add(new EncryptionMethod(new Uri(algorithm)));
//                        }

//                        isEmpty = reader.IsEmptyElement;
//                        reader.ReadStartElement(Saml2MetadataConstants.Elements.EncryptionMethod, Saml2MetadataConstants.Namespace);
//                        if (!isEmpty)
//                        {
//                            while (reader.IsStartElement())
//                            {
//                                if (ReadCustomElement<KeyDescriptor>(reader, resultKey))
//                                {
//                                    // Do nothing for now
//                                }
//                                else
//                                {
//                                    reader.Skip();
//                                }
//                            }
//                            reader.ReadEndElement();
//                        }
//                    }
//                    else if (ReadCustomElement<KeyDescriptor>(reader, resultKey))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            if (resultKey.KeyInfo == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3200, XmlSignatureConstants.Elements.KeyInfo)));
//            }
//            return resultKey;
//        }

//        /// <summary>
//        /// Reads a localized name.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>A localized name.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual LocalizedName ReadLocalizedName(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            LocalizedName resultName = CreateLocalizedNameInstance();

//            string lang = reader.GetAttribute(LanguageLocalName, LanguageNamespaceUri);
//            try
//            {
//                resultName.Language = CultureInfo.GetCultureInfo(lang);
//            }
//            catch (ArgumentNullException)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, LanguageLocalName, "null")));
//            }
//            catch (ArgumentException)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, LanguageLocalName, lang)));
//            }

//            ReadCustomAttributes<LocalizedName>(reader, resultName);

//            bool isEmpty = reader.IsEmptyElement;
//            string elementName = reader.Name;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                resultName.Name = reader.ReadContentAsString();
//                while (reader.IsStartElement())
//                {
//                    if (ReadCustomElement<LocalizedName>(reader, resultName))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        // Move on
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            if (String.IsNullOrEmpty(resultName.Name))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3200, elementName)));
//            }
//            return resultName;
//        }

//        /// <summary>
//        /// Reads a localized uri.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>A localized uri.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual LocalizedUri ReadLocalizedUri(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            LocalizedUri resultUri = CreateLocalizedUriInstance();

//            string lang = reader.GetAttribute(LanguageLocalName, LanguageNamespaceUri);
//            try
//            {
//                resultUri.Language = CultureInfo.GetCultureInfo(lang);
//            }
//            catch (ArgumentNullException)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, LanguageLocalName, "null")));
//            }
//            catch (ArgumentException)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, LanguageLocalName, lang)));
//            }

//            ReadCustomAttributes<LocalizedUri>(reader, resultUri);

//            bool isEmpty = reader.IsEmptyElement;
//            string elementName = reader.Name;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                string uriContent = reader.ReadContentAsString();
//                Uri uri;
//                if (!UriUtil.TryCreateValidUri(uriContent, UriKind.RelativeOrAbsolute, out uri))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, elementName, uriContent)));
//                }
//                resultUri.Uri = uri;
//                while (reader.IsStartElement())
//                {
//                    if (ReadCustomElement<LocalizedUri>(reader, resultUri))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            if (resultUri.Uri == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3200, elementName)));
//            }
//            return resultUri;
//        }

//        /// <summary>
//        /// Reads the given stream to deserialize a FederationMetadata instance.
//        /// </summary>
//        /// <param name="stream">Stream to be read.</param>
//        /// <returns>An FederationMetadata instance.</returns>
//        /// <exception cref="ArgumentNullException">The parameter stream is null.</exception>
//        public MetadataBase ReadMetadata(Stream stream)
//        {
//            if (stream == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("stream");
//            }
//            XmlDictionaryReader reader = XmlDictionaryReader.CreateTextReader(stream, XmlDictionaryReaderQuotas.Max);
//            return ReadMetadata(reader);
//        }

//        /// <summary>
//        /// Read the given XmlReader to deserialize the FederationMetadata instance.
//        /// </summary>
//        /// <param name="reader">XmlReader to be read.</param>
//        /// <returns>An FederationMetadata instance</returns>
//        public MetadataBase ReadMetadata(XmlReader reader)
//        {
//            return ReadMetadata(reader, EmptySecurityTokenResolver.Instance);
//        }

//        /// <summary>
//        /// Read the given XmlReader to deserialize the FederationMetadata instance.
//        /// </summary>
//        /// <param name="reader">XmlReader to be read.</param>
//        /// <param name="tokenResolver">Token resolver to resolve the signature token.</param>
//        /// <returns>An FederationMetadata instance.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        public MetadataBase ReadMetadata(XmlReader reader, SecurityTokenResolver tokenResolver)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (tokenResolver == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenResolver");
//            }
//            if (false == (reader is XmlDictionaryReader))
//            {
//                reader = XmlDictionaryReader.CreateDictionaryReader(reader);
//            }

//            MetadataBase metadata = ReadMetadataCore(reader, tokenResolver);
//            return metadata;
//        }

//        /// <summary>
//        /// Reads metadata.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <param name="tokenResolver">The security token resolver.</param>
//        /// <returns>MetadataBase</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader or tokenReolver is null.</exception>
//        protected virtual MetadataBase ReadMetadataCore(XmlReader reader, SecurityTokenResolver tokenResolver)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (tokenResolver == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("tokenResolver");
//            }

//            MetadataBase metadataBase;

//            if (reader.IsStartElement(Saml2MetadataConstants.Elements.EntitiesDescriptor, Saml2MetadataConstants.Namespace))
//            {
//                metadataBase = ReadEntitiesDescriptor(reader, tokenResolver);
//            }
//            else if (reader.IsStartElement(Saml2MetadataConstants.Elements.EntityDescriptor, Saml2MetadataConstants.Namespace))
//            {
//                metadataBase = ReadEntityDescriptor(reader, tokenResolver);
//            }
//            else
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3260)));
//            }

//            return metadataBase;
//        }

//        /// <summary>
//        /// Reads an organization.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>An organization.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual Organization ReadOrganization(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            Organization resultOrg = CreateOrganizationInstance();

//            ReadCustomAttributes<Organization>(reader, resultOrg);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(Saml2MetadataConstants.Elements.OrganizationName, Saml2MetadataConstants.Namespace))
//                    {
//                        resultOrg.Names.Add(ReadLocalizedName(reader));
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.OrganizationDisplayName, Saml2MetadataConstants.Namespace))
//                    {
//                        resultOrg.DisplayNames.Add(ReadLocalizedName(reader));
//                    }
//                    else if (reader.IsStartElement(Saml2MetadataConstants.Elements.OrganizationUrl, Saml2MetadataConstants.Namespace))
//                    {
//                        resultOrg.Urls.Add(ReadLocalizedUri(reader));
//                    }
//                    else if (ReadCustomElement<Organization>(reader, resultOrg))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement();
//            }

//            // Relaxed as per FIP 9935
//            // if ( resultOrg.DisplayNames.Count < 1 )
//            // if ( resultOrg.Names.Count < 1 )
//            // if ( resultOrg.Urls.Count < 1 )

//            return resultOrg;
//        }

//        /// <summary>
//        /// Reads an endpoint.
//        /// </summary>
//        /// <param name="reader">Xml reader.</param>
//        /// <returns>An endpoint.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual ProtocolEndpoint ReadProtocolEndpoint(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            ProtocolEndpoint endpoint = CreateProtocolEndpointInstance();

//            string binding = reader.GetAttribute(Saml2MetadataConstants.Attributes.Binding, null);
//            Uri bindingUri;
//            if (!UriUtil.TryCreateValidUri(binding, UriKind.RelativeOrAbsolute, out bindingUri))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.Binding, binding)));
//            }
//            endpoint.Binding = bindingUri;

//            string location = reader.GetAttribute(Saml2MetadataConstants.Attributes.Location, null);
//            Uri locationUri;
//            if (!UriUtil.TryCreateValidUri(location, UriKind.RelativeOrAbsolute, out locationUri))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.Location, location)));
//            }
//            endpoint.Location = locationUri;

//            string responseLocation = reader.GetAttribute(Saml2MetadataConstants.Attributes.ResponseLocation, null);
//            if (!String.IsNullOrEmpty(responseLocation))
//            {
//                Uri responseUri;
//                if (!UriUtil.TryCreateValidUri(responseLocation, UriKind.RelativeOrAbsolute, out responseUri))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.ResponseLocation, responseLocation)));
//                }
//                endpoint.ResponseLocation = responseUri;
//            }

//            ReadCustomAttributes<ProtocolEndpoint>(reader, endpoint);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement(); // <Endpoint>
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (!ReadCustomElement<ProtocolEndpoint>(reader, endpoint))
//                    {
//                        // Move on
//                        reader.Skip();
//                    }
//                }
//                reader.ReadEndElement(); // </Endpoint>
//            }

//            return endpoint;
//        }

//        /// <summary>
//        /// Reads role descriptor attributes.
//        /// </summary>
//        /// <param name="reader">The xml reader</param>
//        /// <param name="roleDescriptor">The role descriptor.</param>
//        /// <exception cref="ArgumentNullException">The parameter reader/roleDescriptor/roleDescriptor.ProtocolsSupported is null.</exception>
//        protected virtual void ReadRoleDescriptorAttributes(XmlReader reader, RoleDescriptor roleDescriptor)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (roleDescriptor == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor");
//            }
//            if (roleDescriptor.ProtocolsSupported == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.ProtocolsSupported");
//            }

//            // Optional
//            string validUntilString = reader.GetAttribute(Saml2MetadataConstants.Attributes.ValidUntil, null);
//            if (!String.IsNullOrEmpty(validUntilString))
//            {
//                DateTime validUntil;
//                if (!DateTime.TryParse(validUntilString, out validUntil))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.ValidUntil, validUntilString)));
//                }
//                roleDescriptor.ValidUntil = validUntil;
//            }

//            // Optional
//            string errorUrlString = reader.GetAttribute(Saml2MetadataConstants.Attributes.ErrorUrl, null);
//            if (!string.IsNullOrEmpty(errorUrlString))
//            {
//                Uri errorUrl;
//                if (!UriUtil.TryCreateValidUri(errorUrlString, UriKind.RelativeOrAbsolute, out errorUrl))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.ErrorUrl, errorUrlString)));
//                }
//                roleDescriptor.ErrorUrl = errorUrl;
//            }

//            // Mandatory
//            string protocols = reader.GetAttribute(Saml2MetadataConstants.Attributes.ProtocolsSupported, null);
//            if (String.IsNullOrEmpty(protocols))
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, Saml2MetadataConstants.Attributes.ProtocolsSupported, protocols)));
//            }
//            foreach (string protocol in protocols.Split(' '))
//            {
//                string toAdd = protocol.Trim();
//                if (!String.IsNullOrEmpty(toAdd))
//                {
//                    roleDescriptor.ProtocolsSupported.Add(new Uri(toAdd));
//                }
//            }
//            ReadCustomAttributes<RoleDescriptor>(reader, roleDescriptor);
//        }

//        /// <summary>
//        /// Reads role descriptor element.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <param name="roleDescriptor">The role descriptor.</param>
//        /// <returns>True if read.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader/roleDescriptor/roleDescriptor.Contacts/rolDescriptor.Keys is null.</exception>
//        protected virtual bool ReadRoleDescriptorElement(XmlReader reader, RoleDescriptor roleDescriptor)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (roleDescriptor == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor");
//            }
//            if (roleDescriptor.Contacts == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.Contacts");
//            }
//            if (roleDescriptor.Keys == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.Keys");
//            }

//            if (reader.IsStartElement(Saml2MetadataConstants.Elements.Organization, Saml2MetadataConstants.Namespace))
//            {
//                roleDescriptor.Organization = ReadOrganization(reader);
//                return true;
//            }
//            else if (reader.IsStartElement(Saml2MetadataConstants.Elements.KeyDescriptor, Saml2MetadataConstants.Namespace))
//            {
//                roleDescriptor.Keys.Add(ReadKeyDescriptor(reader));
//                return true;
//            }
//            else if (reader.IsStartElement(Saml2MetadataConstants.Elements.ContactPerson, Saml2MetadataConstants.Namespace))
//            {
//                roleDescriptor.Contacts.Add(ReadContactPerson(reader));
//                return true;
//            }
//            else
//            {
//                return ReadCustomElement<RoleDescriptor>(reader, roleDescriptor);
//            }

//            // No mandatory elements. No validations
//        }

//        /// <summary>
//        /// Reads security token service descriptor.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>A security token service descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        protected virtual SecurityTokenServiceDescriptor ReadSecurityTokenServiceDescriptor(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            SecurityTokenServiceDescriptor securityTokenServiceDescriptor = CreateSecurityTokenServiceDescriptorInstance();
//            ReadWebServiceDescriptorAttributes(reader, securityTokenServiceDescriptor);
//            ReadCustomAttributes<SecurityTokenServiceDescriptor>(reader, securityTokenServiceDescriptor);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(FederationMetadataConstants.Elements.SecurityTokenServiceEndpoint, FederationMetadataConstants.Namespace))
//                    {
//                        isEmpty = reader.IsEmptyElement;
//                        reader.ReadStartElement();
//                        if (!isEmpty && reader.IsStartElement())
//                        {
//                            EndpointReference address = EndpointReference.ReadFrom(reader);
//                            securityTokenServiceDescriptor.SecurityTokenServiceEndpoints.Add(address);
//                            reader.ReadEndElement();
//                        }
//                    }
//                    else if (reader.IsStartElement(FederationMetadataConstants.Elements.PassiveRequestorEndpoint, FederationMetadataConstants.Namespace))
//                    {
//                        isEmpty = reader.IsEmptyElement;
//                        reader.ReadStartElement();
//                        if (!isEmpty && reader.IsStartElement())
//                        {
//                            EndpointReference address = EndpointReference.ReadFrom(reader);
//                            securityTokenServiceDescriptor.PassiveRequestorEndpoints.Add(address);
//                            reader.ReadEndElement();
//                        }
//                    }
//                    else if (ReadWebServiceDescriptorElement(reader, securityTokenServiceDescriptor))
//                    {
//                        // Do nothing
//                    }
//                    else if (ReadCustomElement<SecurityTokenServiceDescriptor>(reader, securityTokenServiceDescriptor))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }

//                reader.ReadEndElement(); // SecurityTokenService
//            }

//            // Relaxed as per FIP 9935
//            // if ( securityTokenServiceDescriptor.SecurityTokenServiceEndpoints.Count == 0 )

//            return securityTokenServiceDescriptor;
//        }

//        /// <summary>
//        /// Reads spsso descriptor.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <returns>An spsso descriptor.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader is null.</exception>
//        /// <exception cref="MetadataSerializationException">The XML was invalid.</exception>
//        protected virtual ServiceProviderSingleSignOnDescriptor ReadServiceProviderSingleSignOnDescriptor(XmlReader reader)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }

//            ServiceProviderSingleSignOnDescriptor spssoDescriptor = CreateServiceProviderSingleSignOnDescriptorInstance();

//            string authnRequestsSignedAttribute = reader.GetAttribute(Saml2MetadataConstants.Attributes.AuthenticationRequestsSigned);
//            if (!String.IsNullOrEmpty(authnRequestsSignedAttribute))
//            {
//                try
//                {
//                    spssoDescriptor.AuthenticationRequestsSigned = XmlConvert.ToBoolean(authnRequestsSignedAttribute.ToLowerInvariant());
//                }
//                catch (FormatException)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(
//                        SR.ID3202, Saml2MetadataConstants.Attributes.AuthenticationRequestsSigned, authnRequestsSignedAttribute)));
//                }
//            }

//            string wantAssertionsSignedAttribute = reader.GetAttribute(Saml2MetadataConstants.Attributes.WantAssertionsSigned);
//            if (!String.IsNullOrEmpty(wantAssertionsSignedAttribute))
//            {
//                try
//                {
//                    spssoDescriptor.WantAssertionsSigned = XmlConvert.ToBoolean(wantAssertionsSignedAttribute.ToLowerInvariant());
//                }
//                catch (FormatException)
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(
//                        SR.ID3202, Saml2MetadataConstants.Attributes.WantAssertionsSigned, wantAssertionsSignedAttribute)));
//                }
//            }

//            ReadSingleSignOnDescriptorAttributes(reader, spssoDescriptor);
//            ReadCustomAttributes<ServiceProviderSingleSignOnDescriptor>(reader, spssoDescriptor);

//            bool isEmpty = reader.IsEmptyElement;
//            reader.ReadStartElement();
//            if (!isEmpty)
//            {
//                while (reader.IsStartElement())
//                {
//                    if (reader.IsStartElement(Saml2MetadataConstants.Elements.AssertionConsumerService, Saml2MetadataConstants.Namespace))
//                    {
//                        IndexedProtocolEndpoint endpoint = ReadIndexedProtocolEndpoint(reader);
//                        spssoDescriptor.AssertionConsumerServices.Add(endpoint.Index, endpoint);
//                    }
//                    else if (ReadSingleSignOnDescriptorElement(reader, spssoDescriptor))
//                    {
//                        // Do nothing
//                    }
//                    else if (ReadCustomElement<ServiceProviderSingleSignOnDescriptor>(reader, spssoDescriptor))
//                    {
//                        // Do nothing.
//                    }
//                    else
//                    {
//                        reader.Skip();
//                    }
//                }

//                reader.ReadEndElement(); // SPSSODescriptor
//            }

//            // Relaxed as per FIP 9935
//            // if ( spssoDescriptor.AssertionConsumerService.Count == 0 )

//            return spssoDescriptor;
//        }

//        /// <summary>
//        /// Reads sso descriptor attributes.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <param name="roleDescriptor">The sso role descriptor.</param>
//        protected virtual void ReadSingleSignOnDescriptorAttributes(XmlReader reader, SingleSignOnDescriptor roleDescriptor)
//        {
//            ReadRoleDescriptorAttributes(reader, roleDescriptor);
//            ReadCustomAttributes<SingleSignOnDescriptor>(reader, roleDescriptor);
//        }

//        /// <summary>
//        /// Reads sso descriptor element.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <param name="singleSignOnDescriptor">The sso descriptor.</param>
//        /// <returns>True if read.</returns>
//        protected virtual bool ReadSingleSignOnDescriptorElement(XmlReader reader, SingleSignOnDescriptor singleSignOnDescriptor)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (singleSignOnDescriptor == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("ssoDescriptor");
//            }

//            if (ReadRoleDescriptorElement(reader, singleSignOnDescriptor))
//            {
//                return true;
//            }
//            else if (reader.IsStartElement(Saml2MetadataConstants.Elements.ArtifactResolutionService, Saml2MetadataConstants.Namespace))
//            {
//                IndexedProtocolEndpoint endpoint = ReadIndexedProtocolEndpoint(reader);

//                // Relaxed check for endpoint.ResponseLocation != null as per FIP 9935
//                singleSignOnDescriptor.ArtifactResolutionServices.Add(endpoint.Index, endpoint);
//                return true;
//            }
//            else if (reader.IsStartElement(Saml2MetadataConstants.Elements.SingleLogoutService, Saml2MetadataConstants.Namespace))
//            {
//                singleSignOnDescriptor.SingleLogoutServices.Add(ReadProtocolEndpoint(reader));
//                return true;
//            }
//            else if (reader.IsStartElement(Saml2MetadataConstants.Elements.NameIDFormat, Saml2MetadataConstants.Namespace))
//            {
//                string nameId = reader.ReadElementContentAsString(Saml2MetadataConstants.Elements.NameIDFormat, Saml2MetadataConstants.Namespace);
//                if (!UriUtil.CanCreateValidUri(nameId, UriKind.Absolute))
//                {
//                    throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID0014, Saml2MetadataConstants.Elements.NameIDFormat)));
//                }
//                singleSignOnDescriptor.NameIdentifierFormats.Add(new Uri(nameId));
//                return true;
//            }
//            else
//            {
//                return ReadCustomElement<SingleSignOnDescriptor>(reader, singleSignOnDescriptor);
//            }
//        }

//        /// <summary>
//        /// Reads web service descriptor attributes.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <param name="roleDescriptor">The web service descriptor.</param>
//        /// <exception cref="ArgumentNullException">The parameter reader/roleDescriptor is null.</exception>
//        protected virtual void ReadWebServiceDescriptorAttributes(XmlReader reader, WebServiceDescriptor roleDescriptor)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (roleDescriptor == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor");
//            }

//            ReadRoleDescriptorAttributes(reader, roleDescriptor);
//            string displayName = reader.GetAttribute(Saml2MetadataConstants.Attributes.ServiceDisplayName, null);
//            if (!String.IsNullOrEmpty(displayName))
//            {
//                roleDescriptor.ServiceDisplayName = displayName;
//            }
//            string description = reader.GetAttribute(Saml2MetadataConstants.Attributes.ServiceDescription, null);
//            if (!String.IsNullOrEmpty(description))
//            {
//                roleDescriptor.ServiceDescription = description;
//            }
//            ReadCustomAttributes<WebServiceDescriptor>(reader, roleDescriptor);

//            // All optional no validations
//        }

//        /// <summary>
//        /// Reads web service descriptor element.
//        /// </summary>
//        /// <param name="reader">The xml reader.</param>
//        /// <param name="roleDescriptor">The web service descriptor.</param>
//        /// <returns>True if read.</returns>
//        /// <exception cref="ArgumentNullException">The parameter reader/roleDescriptor/roleDescriptor.TargetScopes/roleDescriptor.TargetScopes/roleDescriptor.TokenTypesOffered
//        /// is null.</exception>
//        public virtual bool ReadWebServiceDescriptorElement(XmlReader reader, WebServiceDescriptor roleDescriptor)
//        {
//            if (reader == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("reader");
//            }
//            if (roleDescriptor == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor");
//            }
//            if (roleDescriptor.TargetScopes == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.TargetScopes");
//            }
//            if (roleDescriptor.ClaimTypesOffered == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.TargetScopes");
//            }
//            if (roleDescriptor.TokenTypesOffered == null)
//            {
//                throw DiagnosticUtility.ExceptionUtility.ThrowHelperArgumentNull("roleDescriptor.TokenTypesOffered");
//            }

//            if (ReadRoleDescriptorElement(reader, roleDescriptor))
//            {
//                return true;
//            }
//            else if (reader.IsStartElement(FederationMetadataConstants.Elements.TargetScopes, FederationMetadataConstants.Namespace))
//            {
//                bool isEmpty = reader.IsEmptyElement;
//                reader.ReadStartElement();
//                if (!isEmpty)
//                {
//                    while (reader.IsStartElement())
//                    {
//                        roleDescriptor.TargetScopes.Add(EndpointReference.ReadFrom(reader));
//                    }

//                    reader.ReadEndElement();
//                }

//                return true;
//            }
//            else if (reader.IsStartElement(FederationMetadataConstants.Elements.ClaimTypesOffered, FederationMetadataConstants.Namespace))
//            {
//                bool isEmpty = reader.IsEmptyElement;
//                reader.ReadStartElement();
//                if (!isEmpty)
//                {
//                    while (reader.IsStartElement())
//                    {
//                        if (reader.IsStartElement(WSAuthorizationConstants.Elements.ClaimType, WSAuthorizationConstants.Namespace))
//                        {
//                            roleDescriptor.ClaimTypesOffered.Add(ReadDisplayClaim(reader));
//                        }
//                        else
//                        {
//                            // Move on
//                            reader.Skip();
//                        }
//                    }

//                    reader.ReadEndElement();
//                }

//                return true;
//            }
//            else if (reader.IsStartElement(FederationMetadataConstants.Elements.ClaimTypesRequested, FederationMetadataConstants.Namespace))
//            {
//                bool isEmpty = reader.IsEmptyElement;
//                reader.ReadStartElement();
//                if (!isEmpty)
//                {
//                    while (reader.IsStartElement())
//                    {
//                        if (reader.IsStartElement(WSAuthorizationConstants.Elements.ClaimType, WSAuthorizationConstants.Namespace))
//                        {
//                            roleDescriptor.ClaimTypesRequested.Add(ReadDisplayClaim(reader));
//                        }
//                        else
//                        {
//                            // Move on
//                            reader.Skip();
//                        }
//                    }

//                    reader.ReadEndElement();
//                }

//                return true;
//            }
//            else if (reader.IsStartElement(FederationMetadataConstants.Elements.TokenTypesOffered, FederationMetadataConstants.Namespace))
//            {
//                bool isEmpty = reader.IsEmptyElement;
//                reader.ReadStartElement(FederationMetadataConstants.Elements.TokenTypesOffered, FederationMetadataConstants.Namespace);

//                if (!isEmpty)
//                {
//                    while (reader.IsStartElement())
//                    {
//                        if (reader.IsStartElement(WSFederationMetadataConstants.Elements.TokenType, WSFederationMetadataConstants.Namespace))
//                        {
//                            string tokenType = reader.GetAttribute(WSFederationMetadataConstants.Attributes.Uri, null);
//                            Uri tokenTypeUri;
//                            if (!UriUtil.TryCreateValidUri(tokenType, UriKind.Absolute, out tokenTypeUri))
//                            {
//                                throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new MetadataSerializationException(SR.GetString(SR.ID3202, WSFederationMetadataConstants.Elements.TokenType, tokenType)));
//                            }

//                            roleDescriptor.TokenTypesOffered.Add(tokenTypeUri);

//                            isEmpty = reader.IsEmptyElement;
//                            reader.ReadStartElement(); // TokenType
//                            if (!isEmpty)
//                            {
//                                reader.ReadEndElement(); // TokenType
//                            }
//                        }
//                        else
//                        {
//                            reader.Skip();
//                        }
//                    }

//                    reader.ReadEndElement(); // TokenTypeOffered
//                }
//                return true;
//            }
//            else
//            {
//                return ReadCustomElement<WebServiceDescriptor>(reader, roleDescriptor);
//            }

//            // All optional. No Validations needed
//        }

//        #endregion
//    }
//}
