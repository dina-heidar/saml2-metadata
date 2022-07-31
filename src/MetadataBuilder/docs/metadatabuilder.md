<a name='assembly'></a>
# MetadataBuilder

## Contents

- [AdditionalMetadataLocation](#T-MetadataBuilder-Dto-AdditionalMetadataLocation 'MetadataBuilder.Dto.AdditionalMetadataLocation')
  - [Namespace](#P-MetadataBuilder-Dto-AdditionalMetadataLocation-Namespace 'MetadataBuilder.Dto.AdditionalMetadataLocation.Namespace')
  - [Value](#P-MetadataBuilder-Dto-AdditionalMetadataLocation-Value 'MetadataBuilder.Dto.AdditionalMetadataLocation.Value')
- [AssertionConsumerServiceTypes](#T-Saml-MetadataBuilder-AssertionConsumerServiceTypes 'Saml.MetadataBuilder.AssertionConsumerServiceTypes')
  - [Artifact](#P-Saml-MetadataBuilder-AssertionConsumerServiceTypes-Artifact 'Saml.MetadataBuilder.AssertionConsumerServiceTypes.Artifact')
  - [Post](#P-Saml-MetadataBuilder-AssertionConsumerServiceTypes-Post 'Saml.MetadataBuilder.AssertionConsumerServiceTypes.Post')
  - [Redirect](#P-Saml-MetadataBuilder-AssertionConsumerServiceTypes-Redirect 'Saml.MetadataBuilder.AssertionConsumerServiceTypes.Redirect')
- [Attribute](#T-Saml-MetadataBuilder-Attribute 'Saml.MetadataBuilder.Attribute')
  - [AttributeValue](#P-Saml-MetadataBuilder-Attribute-AttributeValue 'Saml.MetadataBuilder.Attribute.AttributeValue')
  - [FriendlyName](#P-Saml-MetadataBuilder-Attribute-FriendlyName 'Saml.MetadataBuilder.Attribute.FriendlyName')
  - [Name](#P-Saml-MetadataBuilder-Attribute-Name 'Saml.MetadataBuilder.Attribute.Name')
  - [NameFormat](#P-Saml-MetadataBuilder-Attribute-NameFormat 'Saml.MetadataBuilder.Attribute.NameFormat')
- [AttributeConsumingService](#T-Saml-MetadataBuilder-AttributeConsumingService 'Saml.MetadataBuilder.AttributeConsumingService')
  - [Index](#P-Saml-MetadataBuilder-AttributeConsumingService-Index 'Saml.MetadataBuilder.AttributeConsumingService.Index')
  - [IsDefault](#P-Saml-MetadataBuilder-AttributeConsumingService-IsDefault 'Saml.MetadataBuilder.AttributeConsumingService.IsDefault')
  - [IsDefaultFieldSpecified](#P-Saml-MetadataBuilder-AttributeConsumingService-IsDefaultFieldSpecified 'Saml.MetadataBuilder.AttributeConsumingService.IsDefaultFieldSpecified')
  - [RequestedAttributes](#P-Saml-MetadataBuilder-AttributeConsumingService-RequestedAttributes 'Saml.MetadataBuilder.AttributeConsumingService.RequestedAttributes')
  - [ServiceDescriptions](#P-Saml-MetadataBuilder-AttributeConsumingService-ServiceDescriptions 'Saml.MetadataBuilder.AttributeConsumingService.ServiceDescriptions')
  - [ServiceNames](#P-Saml-MetadataBuilder-AttributeConsumingService-ServiceNames 'Saml.MetadataBuilder.AttributeConsumingService.ServiceNames')
- [AuthenticationContext](#T-Saml-MetadataBuilder-AuthenticationContext 'Saml.MetadataBuilder.AuthenticationContext')
  - [AuthnContextClassRef](#P-Saml-MetadataBuilder-AuthenticationContext-AuthnContextClassRef 'Saml.MetadataBuilder.AuthenticationContext.AuthnContextClassRef')
  - [AuthnContextRefTypes](#P-Saml-MetadataBuilder-AuthenticationContext-AuthnContextRefTypes 'Saml.MetadataBuilder.AuthenticationContext.AuthnContextRefTypes')
  - [ComparisonSpecified](#P-Saml-MetadataBuilder-AuthenticationContext-ComparisonSpecified 'Saml.MetadataBuilder.AuthenticationContext.ComparisonSpecified')
  - [ComparisonType](#P-Saml-MetadataBuilder-AuthenticationContext-ComparisonType 'Saml.MetadataBuilder.AuthenticationContext.ComparisonType')
- [AuthnContextRefTypes](#T-Saml-MetadataBuilder-Constants-AuthnContextRefTypes 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes')
  - [IntegratedWindowsAuthentication](#F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-IntegratedWindowsAuthentication 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes.IntegratedWindowsAuthentication')
  - [Kerberose](#F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-Kerberose 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes.Kerberose')
  - [PasswordProtectedTransport](#F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-PasswordProtectedTransport 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes.PasswordProtectedTransport')
  - [TransportLayerSecurityClient](#F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-TransportLayerSecurityClient 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes.TransportLayerSecurityClient')
  - [UserNameAndPassword](#F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-UserNameAndPassword 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes.UserNameAndPassword')
  - [X509Certificate](#F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-X509Certificate 'Saml.MetadataBuilder.Constants.AuthnContextRefTypes.X509Certificate')
- [Binding](#T-Saml-MetadataBuilder-Binding 'Saml.MetadataBuilder.Binding')
  - [#ctor(binding)](#M-Saml-MetadataBuilder-Binding-#ctor-System-String- 'Saml.MetadataBuilder.Binding.#ctor(System.String)')
  - [binding](#F-Saml-MetadataBuilder-Binding-binding 'Saml.MetadataBuilder.Binding.binding')
  - [Url(location,responseLocation)](#M-Saml-MetadataBuilder-Binding-Url-System-String,System-String- 'Saml.MetadataBuilder.Binding.Url(System.String,System.String)')
  - [Url(location,index,isDefault)](#M-Saml-MetadataBuilder-Binding-Url-System-String,System-Int32,System-Boolean- 'Saml.MetadataBuilder.Binding.Url(System.String,System.Int32,System.Boolean)')
- [BindingTypes](#T-Saml-MetadataBuilder-Constants-BindingTypes 'Saml.MetadataBuilder.Constants.BindingTypes')
  - [Artifact](#F-Saml-MetadataBuilder-Constants-BindingTypes-Artifact 'Saml.MetadataBuilder.Constants.BindingTypes.Artifact')
  - [Post](#F-Saml-MetadataBuilder-Constants-BindingTypes-Post 'Saml.MetadataBuilder.Constants.BindingTypes.Post')
  - [Redirect](#F-Saml-MetadataBuilder-Constants-BindingTypes-Redirect 'Saml.MetadataBuilder.Constants.BindingTypes.Redirect')
- [ComparisonTypes](#T-Saml-MetadataBuilder-Constants-ComparisonTypes 'Saml.MetadataBuilder.Constants.ComparisonTypes')
  - [Better](#F-Saml-MetadataBuilder-Constants-ComparisonTypes-Better 'Saml.MetadataBuilder.Constants.ComparisonTypes.Better')
  - [Exact](#F-Saml-MetadataBuilder-Constants-ComparisonTypes-Exact 'Saml.MetadataBuilder.Constants.ComparisonTypes.Exact')
  - [Maximum](#F-Saml-MetadataBuilder-Constants-ComparisonTypes-Maximum 'Saml.MetadataBuilder.Constants.ComparisonTypes.Maximum')
  - [Minimum](#F-Saml-MetadataBuilder-Constants-ComparisonTypes-Minimum 'Saml.MetadataBuilder.Constants.ComparisonTypes.Minimum')
- [ContactPerson](#T-Saml-MetadataBuilder-ContactPerson 'Saml.MetadataBuilder.ContactPerson')
  - [#ctor()](#M-Saml-MetadataBuilder-ContactPerson-#ctor 'Saml.MetadataBuilder.ContactPerson.#ctor')
  - [#ctor(contactType)](#M-Saml-MetadataBuilder-ContactPerson-#ctor-Saml-MetadataBuilder-Constants-ContactType- 'Saml.MetadataBuilder.ContactPerson.#ctor(Saml.MetadataBuilder.Constants.ContactType)')
  - [Company](#P-Saml-MetadataBuilder-ContactPerson-Company 'Saml.MetadataBuilder.ContactPerson.Company')
  - [ContactType](#P-Saml-MetadataBuilder-ContactPerson-ContactType 'Saml.MetadataBuilder.ContactPerson.ContactType')
  - [EmailAddresses](#P-Saml-MetadataBuilder-ContactPerson-EmailAddresses 'Saml.MetadataBuilder.ContactPerson.EmailAddresses')
  - [GivenName](#P-Saml-MetadataBuilder-ContactPerson-GivenName 'Saml.MetadataBuilder.ContactPerson.GivenName')
  - [Surname](#P-Saml-MetadataBuilder-ContactPerson-Surname 'Saml.MetadataBuilder.ContactPerson.Surname')
  - [TelephoneNumbers](#P-Saml-MetadataBuilder-ContactPerson-TelephoneNumbers 'Saml.MetadataBuilder.ContactPerson.TelephoneNumbers')
- [ContactType](#T-Saml-MetadataBuilder-Constants-ContactType 'Saml.MetadataBuilder.Constants.ContactType')
  - [Administrative](#F-Saml-MetadataBuilder-Constants-ContactType-Administrative 'Saml.MetadataBuilder.Constants.ContactType.Administrative')
  - [Billing](#F-Saml-MetadataBuilder-Constants-ContactType-Billing 'Saml.MetadataBuilder.Constants.ContactType.Billing')
  - [Other](#F-Saml-MetadataBuilder-Constants-ContactType-Other 'Saml.MetadataBuilder.Constants.ContactType.Other')
  - [Support](#F-Saml-MetadataBuilder-Constants-ContactType-Support 'Saml.MetadataBuilder.Constants.ContactType.Support')
  - [Technical](#F-Saml-MetadataBuilder-Constants-ContactType-Technical 'Saml.MetadataBuilder.Constants.ContactType.Technical')
- [Endpoint](#T-Saml-MetadataBuilder-Endpoint 'Saml.MetadataBuilder.Endpoint')
  - [Binding](#P-Saml-MetadataBuilder-Endpoint-Binding 'Saml.MetadataBuilder.Endpoint.Binding')
  - [Location](#P-Saml-MetadataBuilder-Endpoint-Location 'Saml.MetadataBuilder.Endpoint.Location')
  - [ResponseLocation](#P-Saml-MetadataBuilder-Endpoint-ResponseLocation 'Saml.MetadataBuilder.Endpoint.ResponseLocation')
- [EntityDescriptor](#T-Saml-MetadataBuilder-EntityDescriptor 'Saml.MetadataBuilder.EntityDescriptor')
  - [AdditionalMetadataLocations](#P-Saml-MetadataBuilder-EntityDescriptor-AdditionalMetadataLocations 'Saml.MetadataBuilder.EntityDescriptor.AdditionalMetadataLocations')
  - [CacheDuration](#P-Saml-MetadataBuilder-EntityDescriptor-CacheDuration 'Saml.MetadataBuilder.EntityDescriptor.CacheDuration')
  - [ContactPersons](#P-Saml-MetadataBuilder-EntityDescriptor-ContactPersons 'Saml.MetadataBuilder.EntityDescriptor.ContactPersons')
  - [EntityID](#P-Saml-MetadataBuilder-EntityDescriptor-EntityID 'Saml.MetadataBuilder.EntityDescriptor.EntityID')
  - [Extensions](#P-Saml-MetadataBuilder-EntityDescriptor-Extensions 'Saml.MetadataBuilder.EntityDescriptor.Extensions')
  - [Id](#P-Saml-MetadataBuilder-EntityDescriptor-Id 'Saml.MetadataBuilder.EntityDescriptor.Id')
  - [Organization](#P-Saml-MetadataBuilder-EntityDescriptor-Organization 'Saml.MetadataBuilder.EntityDescriptor.Organization')
  - [RoleDescriptor](#P-Saml-MetadataBuilder-EntityDescriptor-RoleDescriptor 'Saml.MetadataBuilder.EntityDescriptor.RoleDescriptor')
  - [Signature](#P-Saml-MetadataBuilder-EntityDescriptor-Signature 'Saml.MetadataBuilder.EntityDescriptor.Signature')
  - [ValidUntil](#P-Saml-MetadataBuilder-EntityDescriptor-ValidUntil 'Saml.MetadataBuilder.EntityDescriptor.ValidUntil')
- [Extension](#T-Saml-MetadataBuilder-Extension 'Saml.MetadataBuilder.Extension')
  - [UiInfo](#P-Saml-MetadataBuilder-Extension-UiInfo 'Saml.MetadataBuilder.Extension.UiInfo')
- [IMetadataMapper\`2](#T-Saml-MetadataBuilder-IMetadataMapper`2 'Saml.MetadataBuilder.IMetadataMapper`2')
  - [Map(input)](#M-Saml-MetadataBuilder-IMetadataMapper`2-Map-`0- 'Saml.MetadataBuilder.IMetadataMapper`2.Map(`0)')
- [IWriter](#T-Saml-MetadataBuilder-IWriter 'Saml.MetadataBuilder.IWriter')
- [IndexedEndpoint](#T-Saml-MetadataBuilder-IndexedEndpoint 'Saml.MetadataBuilder.IndexedEndpoint')
  - [Index](#P-Saml-MetadataBuilder-IndexedEndpoint-Index 'Saml.MetadataBuilder.IndexedEndpoint.Index')
  - [IsDefault](#P-Saml-MetadataBuilder-IndexedEndpoint-IsDefault 'Saml.MetadataBuilder.IndexedEndpoint.IsDefault')
  - [IsDefaultSpecified](#P-Saml-MetadataBuilder-IndexedEndpoint-IsDefaultSpecified 'Saml.MetadataBuilder.IndexedEndpoint.IsDefaultSpecified')
- [KeyDescriptor](#T-Saml-MetadataBuilder-KeyDescriptor 'Saml.MetadataBuilder.KeyDescriptor')
  - [KeyInfo](#P-Saml-MetadataBuilder-KeyDescriptor-KeyInfo 'Saml.MetadataBuilder.KeyDescriptor.KeyInfo')
  - [KeyInfoNameType](#P-Saml-MetadataBuilder-KeyDescriptor-KeyInfoNameType 'Saml.MetadataBuilder.KeyDescriptor.KeyInfoNameType')
  - [KeyType](#P-Saml-MetadataBuilder-KeyDescriptor-KeyType 'Saml.MetadataBuilder.KeyDescriptor.KeyType')
  - [UseSpecified](#P-Saml-MetadataBuilder-KeyDescriptor-UseSpecified 'Saml.MetadataBuilder.KeyDescriptor.UseSpecified')
- [KeyInfoNameType](#T-Saml-MetadataBuilder-KeyInfoNameType 'Saml.MetadataBuilder.KeyInfoNameType')
  - [Item](#F-Saml-MetadataBuilder-KeyInfoNameType-Item 'Saml.MetadataBuilder.KeyInfoNameType.Item')
  - [KeyName](#F-Saml-MetadataBuilder-KeyInfoNameType-KeyName 'Saml.MetadataBuilder.KeyInfoNameType.KeyName')
  - [KeyValue](#F-Saml-MetadataBuilder-KeyInfoNameType-KeyValue 'Saml.MetadataBuilder.KeyInfoNameType.KeyValue')
  - [MgmtData](#F-Saml-MetadataBuilder-KeyInfoNameType-MgmtData 'Saml.MetadataBuilder.KeyInfoNameType.MgmtData')
  - [PGPData](#F-Saml-MetadataBuilder-KeyInfoNameType-PGPData 'Saml.MetadataBuilder.KeyInfoNameType.PGPData')
  - [RetrievalMethod](#F-Saml-MetadataBuilder-KeyInfoNameType-RetrievalMethod 'Saml.MetadataBuilder.KeyInfoNameType.RetrievalMethod')
  - [SPKIData](#F-Saml-MetadataBuilder-KeyInfoNameType-SPKIData 'Saml.MetadataBuilder.KeyInfoNameType.SPKIData')
  - [X509Data](#F-Saml-MetadataBuilder-KeyInfoNameType-X509Data 'Saml.MetadataBuilder.KeyInfoNameType.X509Data')
- [KeyTypes](#T-Saml-MetadataBuilder-Constants-KeyTypes 'Saml.MetadataBuilder.Constants.KeyTypes')
  - [encryption](#F-Saml-MetadataBuilder-Constants-KeyTypes-encryption 'Saml.MetadataBuilder.Constants.KeyTypes.encryption')
  - [signing](#F-Saml-MetadataBuilder-Constants-KeyTypes-signing 'Saml.MetadataBuilder.Constants.KeyTypes.signing')
- [Keyword](#T-Saml-MetadataBuilder-Keyword 'Saml.MetadataBuilder.Keyword')
  - [Language](#P-Saml-MetadataBuilder-Keyword-Language 'Saml.MetadataBuilder.Keyword.Language')
  - [Values](#P-Saml-MetadataBuilder-Keyword-Values 'Saml.MetadataBuilder.Keyword.Values')
- [LocalizedName](#T-Saml-MetadataBuilder-LocalizedName 'Saml.MetadataBuilder.LocalizedName')
  - [Language](#P-Saml-MetadataBuilder-LocalizedName-Language 'Saml.MetadataBuilder.LocalizedName.Language')
  - [Value](#P-Saml-MetadataBuilder-LocalizedName-Value 'Saml.MetadataBuilder.LocalizedName.Value')
- [LocalizedUri](#T-Saml-MetadataBuilder-LocalizedUri 'Saml.MetadataBuilder.LocalizedUri')
  - [Language](#P-Saml-MetadataBuilder-LocalizedUri-Language 'Saml.MetadataBuilder.LocalizedUri.Language')
  - [Uri](#P-Saml-MetadataBuilder-LocalizedUri-Uri 'Saml.MetadataBuilder.LocalizedUri.Uri')
- [Logo](#T-Saml-MetadataBuilder-Logo 'Saml.MetadataBuilder.Logo')
  - [Height](#P-Saml-MetadataBuilder-Logo-Height 'Saml.MetadataBuilder.Logo.Height')
  - [Language](#P-Saml-MetadataBuilder-Logo-Language 'Saml.MetadataBuilder.Logo.Language')
  - [Value](#P-Saml-MetadataBuilder-Logo-Value 'Saml.MetadataBuilder.Logo.Value')
  - [Width](#P-Saml-MetadataBuilder-Logo-Width 'Saml.MetadataBuilder.Logo.Width')
- [NameIdFormatTypes](#T-Saml-MetadataBuilder-Constants-NameIdFormatTypes 'Saml.MetadataBuilder.Constants.NameIdFormatTypes')
  - [Email](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Email 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.Email')
  - [Encrypted](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Encrypted 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.Encrypted')
  - [EntityIdentifier](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-EntityIdentifier 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.EntityIdentifier')
  - [KerberosPrincipalName](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-KerberosPrincipalName 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.KerberosPrincipalName')
  - [Persistent](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Persistent 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.Persistent')
  - [SubjectName](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-SubjectName 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.SubjectName')
  - [Transient](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Transient 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.Transient')
  - [Unspecified](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Unspecified 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.Unspecified')
  - [WindowsDomainQualifiedName](#F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-WindowsDomainQualifiedName 'Saml.MetadataBuilder.Constants.NameIdFormatTypes.WindowsDomainQualifiedName')
- [Organization](#T-Saml-MetadataBuilder-Organization 'Saml.MetadataBuilder.Organization')
  - [OrganizationDisplayName](#P-Saml-MetadataBuilder-Organization-OrganizationDisplayName 'Saml.MetadataBuilder.Organization.OrganizationDisplayName')
  - [OrganizationName](#P-Saml-MetadataBuilder-Organization-OrganizationName 'Saml.MetadataBuilder.Organization.OrganizationName')
  - [OrganizationURL](#P-Saml-MetadataBuilder-Organization-OrganizationURL 'Saml.MetadataBuilder.Organization.OrganizationURL')
- [RequestedAttribute](#T-Saml-MetadataBuilder-RequestedAttribute 'Saml.MetadataBuilder.RequestedAttribute')
  - [IsRequiredField](#P-Saml-MetadataBuilder-RequestedAttribute-IsRequiredField 'Saml.MetadataBuilder.RequestedAttribute.IsRequiredField')
  - [IsRequiredFieldSpecified](#P-Saml-MetadataBuilder-RequestedAttribute-IsRequiredFieldSpecified 'Saml.MetadataBuilder.RequestedAttribute.IsRequiredFieldSpecified')
- [RequestingAuthenticationContext](#T-Saml-MetadataBuilder-RequestingAuthenticationContext 'Saml.MetadataBuilder.RequestingAuthenticationContext')
  - [#ctor(authnContextRefTypes)](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-#ctor-System-String[]- 'Saml.MetadataBuilder.RequestingAuthenticationContext.#ctor(System.String[])')
  - [#ctor(authnContextRefTypes)](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-#ctor-System-String- 'Saml.MetadataBuilder.RequestingAuthenticationContext.#ctor(System.String)')
  - [authnContextRefTypes](#F-Saml-MetadataBuilder-RequestingAuthenticationContext-authnContextRefTypes 'Saml.MetadataBuilder.RequestingAuthenticationContext.authnContextRefTypes')
  - [comparisonType](#F-Saml-MetadataBuilder-RequestingAuthenticationContext-comparisonType 'Saml.MetadataBuilder.RequestingAuthenticationContext.comparisonType')
  - [AuthenticationContext(comparisonType)](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-AuthenticationContext-System-String- 'Saml.MetadataBuilder.RequestingAuthenticationContext.AuthenticationContext(System.String)')
  - [Better()](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-Better 'Saml.MetadataBuilder.RequestingAuthenticationContext.Better')
  - [Custom(comparisonType)](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-Custom-System-String- 'Saml.MetadataBuilder.RequestingAuthenticationContext.Custom(System.String)')
  - [Default()](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-Default 'Saml.MetadataBuilder.RequestingAuthenticationContext.Default')
  - [Exact()](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-Exact 'Saml.MetadataBuilder.RequestingAuthenticationContext.Exact')
  - [Maximum()](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-Maximum 'Saml.MetadataBuilder.RequestingAuthenticationContext.Maximum')
  - [Minimum()](#M-Saml-MetadataBuilder-RequestingAuthenticationContext-Minimum 'Saml.MetadataBuilder.RequestingAuthenticationContext.Minimum')
- [RequestingAuthenticationContextTypes](#T-Saml-MetadataBuilder-RequestingAuthenticationContextTypes 'Saml.MetadataBuilder.RequestingAuthenticationContextTypes')
  - [FormsAuthentication](#P-Saml-MetadataBuilder-RequestingAuthenticationContextTypes-FormsAuthentication 'Saml.MetadataBuilder.RequestingAuthenticationContextTypes.FormsAuthentication')
  - [WindowsAuthentication](#P-Saml-MetadataBuilder-RequestingAuthenticationContextTypes-WindowsAuthentication 'Saml.MetadataBuilder.RequestingAuthenticationContextTypes.WindowsAuthentication')
  - [Custom(authnContextRefTypes,comparisonTypes)](#M-Saml-MetadataBuilder-RequestingAuthenticationContextTypes-Custom-System-String[],System-String- 'Saml.MetadataBuilder.RequestingAuthenticationContextTypes.Custom(System.String[],System.String)')
- [RoleDescriptor](#T-Saml-MetadataBuilder-RoleDescriptor 'Saml.MetadataBuilder.RoleDescriptor')
  - [CacheDuration](#P-Saml-MetadataBuilder-RoleDescriptor-CacheDuration 'Saml.MetadataBuilder.RoleDescriptor.CacheDuration')
  - [ContactPersons](#P-Saml-MetadataBuilder-RoleDescriptor-ContactPersons 'Saml.MetadataBuilder.RoleDescriptor.ContactPersons')
  - [Extensions](#P-Saml-MetadataBuilder-RoleDescriptor-Extensions 'Saml.MetadataBuilder.RoleDescriptor.Extensions')
  - [Id](#P-Saml-MetadataBuilder-RoleDescriptor-Id 'Saml.MetadataBuilder.RoleDescriptor.Id')
  - [KeyDescriptor](#P-Saml-MetadataBuilder-RoleDescriptor-KeyDescriptor 'Saml.MetadataBuilder.RoleDescriptor.KeyDescriptor')
  - [Organization](#P-Saml-MetadataBuilder-RoleDescriptor-Organization 'Saml.MetadataBuilder.RoleDescriptor.Organization')
  - [ProtocolSupportEnumeration](#P-Saml-MetadataBuilder-RoleDescriptor-ProtocolSupportEnumeration 'Saml.MetadataBuilder.RoleDescriptor.ProtocolSupportEnumeration')
  - [Signature](#P-Saml-MetadataBuilder-RoleDescriptor-Signature 'Saml.MetadataBuilder.RoleDescriptor.Signature')
  - [ValidUntil](#P-Saml-MetadataBuilder-RoleDescriptor-ValidUntil 'Saml.MetadataBuilder.RoleDescriptor.ValidUntil')
  - [ValidUntilFieldSpecified](#P-Saml-MetadataBuilder-RoleDescriptor-ValidUntilFieldSpecified 'Saml.MetadataBuilder.RoleDescriptor.ValidUntilFieldSpecified')
- [SPSSODescriptor](#T-Saml-MetadataBuilder-SPSSODescriptor 'Saml.MetadataBuilder.SPSSODescriptor')
  - [AssertionConsumerServices](#P-Saml-MetadataBuilder-SPSSODescriptor-AssertionConsumerServices 'Saml.MetadataBuilder.SPSSODescriptor.AssertionConsumerServices')
  - [AttributeConsumingService](#P-Saml-MetadataBuilder-SPSSODescriptor-AttributeConsumingService 'Saml.MetadataBuilder.SPSSODescriptor.AttributeConsumingService')
  - [AuthnRequestsSigned](#P-Saml-MetadataBuilder-SPSSODescriptor-AuthnRequestsSigned 'Saml.MetadataBuilder.SPSSODescriptor.AuthnRequestsSigned')
  - [AuthnRequestsSignedFieldSpecified](#P-Saml-MetadataBuilder-SPSSODescriptor-AuthnRequestsSignedFieldSpecified 'Saml.MetadataBuilder.SPSSODescriptor.AuthnRequestsSignedFieldSpecified')
  - [WantAssertionsSigned](#P-Saml-MetadataBuilder-SPSSODescriptor-WantAssertionsSigned 'Saml.MetadataBuilder.SPSSODescriptor.WantAssertionsSigned')
  - [WantAssertionsSignedFieldSpecified](#P-Saml-MetadataBuilder-SPSSODescriptor-WantAssertionsSignedFieldSpecified 'Saml.MetadataBuilder.SPSSODescriptor.WantAssertionsSignedFieldSpecified')
- [SSODescriptor](#T-Saml-MetadataBuilder-SSODescriptor 'Saml.MetadataBuilder.SSODescriptor')
  - [ArtifactResolutionServices](#P-Saml-MetadataBuilder-SSODescriptor-ArtifactResolutionServices 'Saml.MetadataBuilder.SSODescriptor.ArtifactResolutionServices')
  - [ManageNameIdServices](#P-Saml-MetadataBuilder-SSODescriptor-ManageNameIdServices 'Saml.MetadataBuilder.SSODescriptor.ManageNameIdServices')
  - [NameIdFormats](#P-Saml-MetadataBuilder-SSODescriptor-NameIdFormats 'Saml.MetadataBuilder.SSODescriptor.NameIdFormats')
  - [SingleLogoutServices](#P-Saml-MetadataBuilder-SSODescriptor-SingleLogoutServices 'Saml.MetadataBuilder.SSODescriptor.SingleLogoutServices')
- [ServiceCollectionExtensions](#T-Saml-MetadataBuilder-ServiceCollectionExtensions 'Saml.MetadataBuilder.ServiceCollectionExtensions')
  - [AddSamlMetadatBuilder(services)](#M-Saml-MetadataBuilder-ServiceCollectionExtensions-AddSamlMetadatBuilder-Microsoft-Extensions-DependencyInjection-IServiceCollection- 'Saml.MetadataBuilder.ServiceCollectionExtensions.AddSamlMetadatBuilder(Microsoft.Extensions.DependencyInjection.IServiceCollection)')
- [ServiceProviderConfiguration](#T-Saml-MetadataBuilder-ServiceProviderConfiguration 'Saml.MetadataBuilder.ServiceProviderConfiguration')
  - [#ctor()](#M-Saml-MetadataBuilder-ServiceProviderConfiguration-#ctor 'Saml.MetadataBuilder.ServiceProviderConfiguration.#ctor')
  - [AssertionConsumerServices](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-AssertionConsumerServices 'Saml.MetadataBuilder.ServiceProviderConfiguration.AssertionConsumerServices')
  - [KeyInfos](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-KeyInfos 'Saml.MetadataBuilder.ServiceProviderConfiguration.KeyInfos')
  - [NameIdFormat](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-NameIdFormat 'Saml.MetadataBuilder.ServiceProviderConfiguration.NameIdFormat')
  - [Signature](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-Signature 'Saml.MetadataBuilder.ServiceProviderConfiguration.Signature')
  - [SigningCredentials](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-SigningCredentials 'Saml.MetadataBuilder.ServiceProviderConfiguration.SigningCredentials')
  - [SingleLogoutServices](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-SingleLogoutServices 'Saml.MetadataBuilder.ServiceProviderConfiguration.SingleLogoutServices')
  - [TokenEndpoint](#P-Saml-MetadataBuilder-ServiceProviderConfiguration-TokenEndpoint 'Saml.MetadataBuilder.ServiceProviderConfiguration.TokenEndpoint')
- [SignaturePropertyType](#T-MetadataBuilder-Schema-Metadata-SignaturePropertyType 'MetadataBuilder.Schema.Metadata.SignaturePropertyType')
- [SingleLogoutServiceTypes](#T-Saml-MetadataBuilder-SingleLogoutServiceTypes 'Saml.MetadataBuilder.SingleLogoutServiceTypes')
  - [Post](#P-Saml-MetadataBuilder-SingleLogoutServiceTypes-Post 'Saml.MetadataBuilder.SingleLogoutServiceTypes.Post')
  - [Redirect](#P-Saml-MetadataBuilder-SingleLogoutServiceTypes-Redirect 'Saml.MetadataBuilder.SingleLogoutServiceTypes.Redirect')
- [UiInfo](#T-Saml-MetadataBuilder-UiInfo 'Saml.MetadataBuilder.UiInfo')
  - [Description](#P-Saml-MetadataBuilder-UiInfo-Description 'Saml.MetadataBuilder.UiInfo.Description')
  - [DisplayName](#P-Saml-MetadataBuilder-UiInfo-DisplayName 'Saml.MetadataBuilder.UiInfo.DisplayName')
  - [InformationURL](#P-Saml-MetadataBuilder-UiInfo-InformationURL 'Saml.MetadataBuilder.UiInfo.InformationURL')
  - [Keywords](#P-Saml-MetadataBuilder-UiInfo-Keywords 'Saml.MetadataBuilder.UiInfo.Keywords')
  - [Logo](#P-Saml-MetadataBuilder-UiInfo-Logo 'Saml.MetadataBuilder.UiInfo.Logo')
  - [PrivacyStatementURL](#P-Saml-MetadataBuilder-UiInfo-PrivacyStatementURL 'Saml.MetadataBuilder.UiInfo.PrivacyStatementURL')
- [Writer](#T-Saml-MetadataBuilder-Writer 'Saml.MetadataBuilder.Writer')
  - [#ctor(spMetadataMapper)](#M-Saml-MetadataBuilder-Writer-#ctor-Saml-MetadataBuilder-IMetadataMapper{Saml-MetadataBuilder-SpMetadata,MetadataBuilder-Schema-Metadata-SPSSODescriptorType}- 'Saml.MetadataBuilder.Writer.#ctor(Saml.MetadataBuilder.IMetadataMapper{Saml.MetadataBuilder.SpMetadata,MetadataBuilder.Schema.Metadata.SPSSODescriptorType})')
- [X509DataTypes](#T-MetadataBuilder-Constants-X509DataTypes 'MetadataBuilder.Constants.X509DataTypes')
  - [Item](#F-MetadataBuilder-Constants-X509DataTypes-Item 'MetadataBuilder.Constants.X509DataTypes.Item')
  - [X509CRL](#F-MetadataBuilder-Constants-X509DataTypes-X509CRL 'MetadataBuilder.Constants.X509DataTypes.X509CRL')
  - [X509Certificate](#F-MetadataBuilder-Constants-X509DataTypes-X509Certificate 'MetadataBuilder.Constants.X509DataTypes.X509Certificate')
  - [X509IssuerSerial](#F-MetadataBuilder-Constants-X509DataTypes-X509IssuerSerial 'MetadataBuilder.Constants.X509DataTypes.X509IssuerSerial')
  - [X509SKI](#F-MetadataBuilder-Constants-X509DataTypes-X509SKI 'MetadataBuilder.Constants.X509DataTypes.X509SKI')
  - [X509SubjectName](#F-MetadataBuilder-Constants-X509DataTypes-X509SubjectName 'MetadataBuilder.Constants.X509DataTypes.X509SubjectName')

<a name='T-MetadataBuilder-Dto-AdditionalMetadataLocation'></a>
## AdditionalMetadataLocation `type`

##### Namespace

MetadataBuilder.Dto

##### Summary



<a name='P-MetadataBuilder-Dto-AdditionalMetadataLocation-Namespace'></a>
### Namespace `property`

##### Summary

Gets or sets the namespace.

<a name='P-MetadataBuilder-Dto-AdditionalMetadataLocation-Value'></a>
### Value `property`

##### Summary

Gets or sets the value.

<a name='T-Saml-MetadataBuilder-AssertionConsumerServiceTypes'></a>
## AssertionConsumerServiceTypes `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

AssertionConsumerService indexed endpoint with different binding value types.

<a name='P-Saml-MetadataBuilder-AssertionConsumerServiceTypes-Artifact'></a>
### Artifact `property`

##### Summary

Gets the binding of type ARTIFACT.

<a name='P-Saml-MetadataBuilder-AssertionConsumerServiceTypes-Post'></a>
### Post `property`

##### Summary

Gets the binding of type POST.

<a name='P-Saml-MetadataBuilder-AssertionConsumerServiceTypes-Redirect'></a>
### Redirect `property`

##### Summary

Gets the binding of type REDIRECT.

<a name='T-Saml-MetadataBuilder-Attribute'></a>
## Attribute `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-Attribute-AttributeValue'></a>
### AttributeValue `property`

##### Summary

Gets or sets the attribute value.

<a name='P-Saml-MetadataBuilder-Attribute-FriendlyName'></a>
### FriendlyName `property`

##### Summary

Gets or sets the name of the friendly.

<a name='P-Saml-MetadataBuilder-Attribute-Name'></a>
### Name `property`

##### Summary

Gets or sets the name.

<a name='P-Saml-MetadataBuilder-Attribute-NameFormat'></a>
### NameFormat `property`

##### Summary

Gets or sets the name format.

<a name='T-Saml-MetadataBuilder-AttributeConsumingService'></a>
## AttributeConsumingService `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-AttributeConsumingService-Index'></a>
### Index `property`

##### Summary

Gets or sets the index.

<a name='P-Saml-MetadataBuilder-AttributeConsumingService-IsDefault'></a>
### IsDefault `property`

##### Summary

Gets or sets a value indicating whether this instance is default.

<a name='P-Saml-MetadataBuilder-AttributeConsumingService-IsDefaultFieldSpecified'></a>
### IsDefaultFieldSpecified `property`

##### Summary

Gets or sets a value indicating whether this instance is default field specified.

<a name='P-Saml-MetadataBuilder-AttributeConsumingService-RequestedAttributes'></a>
### RequestedAttributes `property`

##### Summary

Gets or sets the requested attributes.

<a name='P-Saml-MetadataBuilder-AttributeConsumingService-ServiceDescriptions'></a>
### ServiceDescriptions `property`

##### Summary

Gets or sets the service descriptions.

<a name='P-Saml-MetadataBuilder-AttributeConsumingService-ServiceNames'></a>
### ServiceNames `property`

##### Summary

Gets or sets the service names.

<a name='T-Saml-MetadataBuilder-AuthenticationContext'></a>
## AuthenticationContext `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

The information added to an assertion regarding details of the technology 
used for the actual authentication action. For example, a service 
provider can request that an identity provider comply with a specific 
authentication method by identifying that method in an authentication request.

<a name='P-Saml-MetadataBuilder-AuthenticationContext-AuthnContextClassRef'></a>
### AuthnContextClassRef `property`

##### Summary

Gets the authn context class reference.

<a name='P-Saml-MetadataBuilder-AuthenticationContext-AuthnContextRefTypes'></a>
### AuthnContextRefTypes `property`

##### Summary

Gets or sets the authn context reference types.

<a name='P-Saml-MetadataBuilder-AuthenticationContext-ComparisonSpecified'></a>
### ComparisonSpecified `property`

##### Summary

Gets or sets a value indicating whether [comparison specified].

<a name='P-Saml-MetadataBuilder-AuthenticationContext-ComparisonType'></a>
### ComparisonType `property`

##### Summary

Gets or sets the type of the comparison.

<a name='T-Saml-MetadataBuilder-Constants-AuthnContextRefTypes'></a>
## AuthnContextRefTypes `type`

##### Namespace

Saml.MetadataBuilder.Constants

##### Summary



<a name='F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-IntegratedWindowsAuthentication'></a>
### IntegratedWindowsAuthentication `constants`

##### Summary

The integrated windows authentication

<a name='F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-Kerberose'></a>
### Kerberose `constants`

##### Summary

The kerberose

<a name='F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-PasswordProtectedTransport'></a>
### PasswordProtectedTransport `constants`

##### Summary

The password protected transport

<a name='F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-TransportLayerSecurityClient'></a>
### TransportLayerSecurityClient `constants`

##### Summary

The transport layer security client

<a name='F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-UserNameAndPassword'></a>
### UserNameAndPassword `constants`

##### Summary

The user name and password

<a name='F-Saml-MetadataBuilder-Constants-AuthnContextRefTypes-X509Certificate'></a>
### X509Certificate `constants`

##### Summary

The X509 certificate

<a name='T-Saml-MetadataBuilder-Binding'></a>
## Binding `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='M-Saml-MetadataBuilder-Binding-#ctor-System-String-'></a>
### #ctor(binding) `constructor`

##### Summary

Initializes a new instance of the [Binding](#T-Saml-MetadataBuilder-Binding 'Saml.MetadataBuilder.Binding') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| binding | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding. |

<a name='F-Saml-MetadataBuilder-Binding-binding'></a>
### binding `constants`

##### Summary

The binding

<a name='M-Saml-MetadataBuilder-Binding-Url-System-String,System-String-'></a>
### Url(location,responseLocation) `method`

##### Summary

URLs the specified location.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The location. |
| responseLocation | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The response location. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [MetadataBuilder.Saml2MetadataSerializationException](#!-MetadataBuilder-Saml2MetadataSerializationException 'MetadataBuilder.Saml2MetadataSerializationException') | Endpoint location is not a valid Url
or
Endpoint response location is not a valid Url |

<a name='M-Saml-MetadataBuilder-Binding-Url-System-String,System-Int32,System-Boolean-'></a>
### Url(location,index,isDefault) `method`

##### Summary

URLs the specified location.

##### Returns

IndexedEndpoint

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The location. |
| index | [System.Int32](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int32 'System.Int32') | The index (will default to 0 if not provided). |
| isDefault | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | if set to `true` [is default]. |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [MetadataBuilder.Saml2MetadataSerializationException](#!-MetadataBuilder-Saml2MetadataSerializationException 'MetadataBuilder.Saml2MetadataSerializationException') | Endpoint location is not a valid Url |

<a name='T-Saml-MetadataBuilder-Constants-BindingTypes'></a>
## BindingTypes `type`

##### Namespace

Saml.MetadataBuilder.Constants

##### Summary

Binding contstant values

<a name='F-Saml-MetadataBuilder-Constants-BindingTypes-Artifact'></a>
### Artifact `constants`

##### Summary

The HTTP artifact saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-BindingTypes-Post'></a>
### Post `constants`

##### Summary

The HTTP post saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-BindingTypes-Redirect'></a>
### Redirect `constants`

##### Summary

The HTTP redirect saml xml constant value

<a name='T-Saml-MetadataBuilder-Constants-ComparisonTypes'></a>
## ComparisonTypes `type`

##### Namespace

Saml.MetadataBuilder.Constants

##### Summary



<a name='F-Saml-MetadataBuilder-Constants-ComparisonTypes-Better'></a>
### Better `constants`

##### Summary

The better

<a name='F-Saml-MetadataBuilder-Constants-ComparisonTypes-Exact'></a>
### Exact `constants`

##### Summary

The exact

<a name='F-Saml-MetadataBuilder-Constants-ComparisonTypes-Maximum'></a>
### Maximum `constants`

##### Summary

The maximum

<a name='F-Saml-MetadataBuilder-Constants-ComparisonTypes-Minimum'></a>
### Minimum `constants`

##### Summary

The minimum

<a name='T-Saml-MetadataBuilder-ContactPerson'></a>
## ContactPerson `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Contact person information

<a name='M-Saml-MetadataBuilder-ContactPerson-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ContactPerson](#T-Saml-MetadataBuilder-ContactPerson 'Saml.MetadataBuilder.ContactPerson') class.

##### Parameters

This constructor has no parameters.

<a name='M-Saml-MetadataBuilder-ContactPerson-#ctor-Saml-MetadataBuilder-Constants-ContactType-'></a>
### #ctor(contactType) `constructor`

##### Summary

Initializes a new instance of the [ContactPerson](#T-Saml-MetadataBuilder-ContactPerson 'Saml.MetadataBuilder.ContactPerson') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| contactType | [Saml.MetadataBuilder.Constants.ContactType](#T-Saml-MetadataBuilder-Constants-ContactType 'Saml.MetadataBuilder.Constants.ContactType') | Type of the contact. |

<a name='P-Saml-MetadataBuilder-ContactPerson-Company'></a>
### Company `property`

##### Summary

Gets or sets the company.

<a name='P-Saml-MetadataBuilder-ContactPerson-ContactType'></a>
### ContactType `property`

##### Summary

Gets or sets the type of the contact.

<a name='P-Saml-MetadataBuilder-ContactPerson-EmailAddresses'></a>
### EmailAddresses `property`

##### Summary

Gets or sets the email addresses.

<a name='P-Saml-MetadataBuilder-ContactPerson-GivenName'></a>
### GivenName `property`

##### Summary

Gets or sets the name of the given.

<a name='P-Saml-MetadataBuilder-ContactPerson-Surname'></a>
### Surname `property`

##### Summary

Gets or sets the surname.

<a name='P-Saml-MetadataBuilder-ContactPerson-TelephoneNumbers'></a>
### TelephoneNumbers `property`

##### Summary

Gets or sets the telephone numbers.

<a name='T-Saml-MetadataBuilder-Constants-ContactType'></a>
## ContactType `type`

##### Namespace

Saml.MetadataBuilder.Constants

##### Summary

Type of contact

<a name='F-Saml-MetadataBuilder-Constants-ContactType-Administrative'></a>
### Administrative `constants`

##### Summary

Administrative staff

<a name='F-Saml-MetadataBuilder-Constants-ContactType-Billing'></a>
### Billing `constants`

##### Summary

Billing staff

<a name='F-Saml-MetadataBuilder-Constants-ContactType-Other'></a>
### Other `constants`

##### Summary

Other

<a name='F-Saml-MetadataBuilder-Constants-ContactType-Support'></a>
### Support `constants`

##### Summary

Support staff

<a name='F-Saml-MetadataBuilder-Constants-ContactType-Technical'></a>
### Technical `constants`

##### Summary

Technical staff

<a name='T-Saml-MetadataBuilder-Endpoint'></a>
## Endpoint `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Endpoint class

<a name='P-Saml-MetadataBuilder-Endpoint-Binding'></a>
### Binding `property`

##### Summary

Gets or sets the binding.

<a name='P-Saml-MetadataBuilder-Endpoint-Location'></a>
### Location `property`

##### Summary

Gets or sets the location.

<a name='P-Saml-MetadataBuilder-Endpoint-ResponseLocation'></a>
### ResponseLocation `property`

##### Summary

Gets or sets the response location.

<a name='T-Saml-MetadataBuilder-EntityDescriptor'></a>
## EntityDescriptor `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

This base class that creates the metadata.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-AdditionalMetadataLocations'></a>
### AdditionalMetadataLocations `property`

##### Summary

Used to provide a set of locations where additional 
metadata exists for the current SAML entity.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-CacheDuration'></a>
### CacheDuration `property`

##### Summary

The maximum length of time a consumer should cache the metadata.
Example: PT604800S

##### Example

PT604800S

<a name='P-Saml-MetadataBuilder-EntityDescriptor-ContactPersons'></a>
### ContactPersons `property`

##### Summary

used to provide various kind of information about 
a contact person such as individuals’ name,
email address and phone numbers.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-EntityID'></a>
### EntityID `property`

##### Summary

The unique identifier of the SAML entity 
which is described by this definition.
Example: dev.contoso.com

##### Example

dev.constoso.com

<a name='P-Saml-MetadataBuilder-EntityDescriptor-Extensions'></a>
### Extensions `property`

##### Summary

Used to include metadata extensions that are agreed upon 
between a metadata publisher and the consumer.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-Id'></a>
### Id `property`

##### Summary

A document-unique identifier 
for the element, typically used as a reference point when signing. 
Example: 35D0C44A-52CE-4D2F-BE06-AE5F00C30AA7

##### Example

35D0C44A-52CE-4D2F-BE06-AE5F00C30AA7

<a name='P-Saml-MetadataBuilder-EntityDescriptor-Organization'></a>
### Organization `property`

##### Summary

Used to identifying the organization 
responsible for the SAML entity, it possible 
to include details such as organization’s name, 
display name, URL.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-RoleDescriptor'></a>
### RoleDescriptor `property`

##### Summary

Used to describe the role or capabilities of the SAML entity.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-Signature'></a>
### Signature `property`

##### Summary

Used to include a digital signature that can be used to 
sign various elements in a metadata definition.

<a name='P-Saml-MetadataBuilder-EntityDescriptor-ValidUntil'></a>
### ValidUntil `property`

##### Summary

The expiration time of the metadata.
Example: 2028-01-21T18:12:29.287Z

##### Example

2028-01-21T18:12:29.287Z

<a name='T-Saml-MetadataBuilder-Extension'></a>
## Extension `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-Extension-UiInfo'></a>
### UiInfo `property`

##### Summary

Gets or sets the UI information.

<a name='T-Saml-MetadataBuilder-IMetadataMapper`2'></a>
## IMetadataMapper\`2 `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



##### Generic Types

| Name | Description |
| ---- | ----------- |
| TIn | The type of the in. |
| TOut | The type of the out. |

<a name='M-Saml-MetadataBuilder-IMetadataMapper`2-Map-`0-'></a>
### Map(input) `method`

##### Summary

Maps the specified input.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| input | [\`0](#T-`0 '`0') | The input. |

<a name='T-Saml-MetadataBuilder-IWriter'></a>
## IWriter `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='T-Saml-MetadataBuilder-IndexedEndpoint'></a>
## IndexedEndpoint `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Indexed endpoint which inherits from Endpoint.

<a name='P-Saml-MetadataBuilder-IndexedEndpoint-Index'></a>
### Index `property`

##### Summary

Gets or sets the index.

<a name='P-Saml-MetadataBuilder-IndexedEndpoint-IsDefault'></a>
### IsDefault `property`

##### Summary

Gets or sets a value indicating whether this index value is the default value.

<a name='P-Saml-MetadataBuilder-IndexedEndpoint-IsDefaultSpecified'></a>
### IsDefaultSpecified `property`

##### Summary

Gets or sets a value indicating whether if default value is specified.

<a name='T-Saml-MetadataBuilder-KeyDescriptor'></a>
## KeyDescriptor `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-KeyDescriptor-KeyInfo'></a>
### KeyInfo `property`

##### Summary

Gets or sets the key information.

<a name='P-Saml-MetadataBuilder-KeyDescriptor-KeyInfoNameType'></a>
### KeyInfoNameType `property`

##### Summary

Gets or sets the type of the key information name.

<a name='P-Saml-MetadataBuilder-KeyDescriptor-KeyType'></a>
### KeyType `property`

##### Summary

Gets or sets the type of the key.

<a name='P-Saml-MetadataBuilder-KeyDescriptor-UseSpecified'></a>
### UseSpecified `property`

##### Summary

Gets or sets a value indicating whether [use field specified].

<a name='T-Saml-MetadataBuilder-KeyInfoNameType'></a>
## KeyInfoNameType `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='F-Saml-MetadataBuilder-KeyInfoNameType-Item'></a>
### Item `constants`

##### Summary

The item

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-KeyName'></a>
### KeyName `constants`

##### Summary

The key name

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-KeyValue'></a>
### KeyValue `constants`

##### Summary

The key value

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-MgmtData'></a>
### MgmtData `constants`

##### Summary

The MGMT data

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-PGPData'></a>
### PGPData `constants`

##### Summary

The PGP data

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-RetrievalMethod'></a>
### RetrievalMethod `constants`

##### Summary

The retrieval method

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-SPKIData'></a>
### SPKIData `constants`

##### Summary

The spki data

<a name='F-Saml-MetadataBuilder-KeyInfoNameType-X509Data'></a>
### X509Data `constants`

##### Summary

The X509 data

<a name='T-Saml-MetadataBuilder-Constants-KeyTypes'></a>
## KeyTypes `type`

##### Namespace

Saml.MetadataBuilder.Constants

##### Summary



<a name='F-Saml-MetadataBuilder-Constants-KeyTypes-encryption'></a>
### encryption `constants`

##### Summary

The encryption

<a name='F-Saml-MetadataBuilder-Constants-KeyTypes-signing'></a>
### signing `constants`

##### Summary

The signing

<a name='T-Saml-MetadataBuilder-Keyword'></a>
## Keyword `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-Keyword-Language'></a>
### Language `property`

##### Summary

Gets or sets the language.

<a name='P-Saml-MetadataBuilder-Keyword-Values'></a>
### Values `property`

##### Summary

Gets or sets the values.

<a name='T-Saml-MetadataBuilder-LocalizedName'></a>
## LocalizedName `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Localization based values

<a name='P-Saml-MetadataBuilder-LocalizedName-Language'></a>
### Language `property`

##### Summary

Gets or sets the language.

<a name='P-Saml-MetadataBuilder-LocalizedName-Value'></a>
### Value `property`

##### Summary

Gets or sets the value.

<a name='T-Saml-MetadataBuilder-LocalizedUri'></a>
## LocalizedUri `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-LocalizedUri-Language'></a>
### Language `property`

##### Summary

Gets or sets the language.

<a name='P-Saml-MetadataBuilder-LocalizedUri-Uri'></a>
### Uri `property`

##### Summary

Gets or sets the URI.

<a name='T-Saml-MetadataBuilder-Logo'></a>
## Logo `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

The logo
 logos SHOULD:  use a transparent background where appropriate
 use PNG, or GIF(less preferred), images use HTTPS URLs in order 
 to avoid mixed-content warnings within browsers

<a name='P-Saml-MetadataBuilder-Logo-Height'></a>
### Height `property`

##### Summary

Gets or sets the height.

<a name='P-Saml-MetadataBuilder-Logo-Language'></a>
### Language `property`

##### Summary

Gets or sets the language.

<a name='P-Saml-MetadataBuilder-Logo-Value'></a>
### Value `property`

##### Summary

Gets or sets the value as a Url.

<a name='P-Saml-MetadataBuilder-Logo-Width'></a>
### Width `property`

##### Summary

Gets or sets the width.

<a name='T-Saml-MetadataBuilder-Constants-NameIdFormatTypes'></a>
## NameIdFormatTypes `type`

##### Namespace

Saml.MetadataBuilder.Constants

##### Summary

NameIDFormats constant values

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Email'></a>
### Email `constants`

##### Summary

The email saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Encrypted'></a>
### Encrypted `constants`

##### Summary

The encrypted saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-EntityIdentifier'></a>
### EntityIdentifier `constants`

##### Summary

The entity identifier saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-KerberosPrincipalName'></a>
### KerberosPrincipalName `constants`

##### Summary

The kerberos principal name saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Persistent'></a>
### Persistent `constants`

##### Summary

The persistent saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-SubjectName'></a>
### SubjectName `constants`

##### Summary

The subject name saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Transient'></a>
### Transient `constants`

##### Summary

The transient saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-Unspecified'></a>
### Unspecified `constants`

##### Summary

The unspecified saml xml constant value

<a name='F-Saml-MetadataBuilder-Constants-NameIdFormatTypes-WindowsDomainQualifiedName'></a>
### WindowsDomainQualifiedName `constants`

##### Summary

The windows domain qualified name saml xml constant value

<a name='T-Saml-MetadataBuilder-Organization'></a>
## Organization `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

The organization inforamtion

<a name='P-Saml-MetadataBuilder-Organization-OrganizationDisplayName'></a>
### OrganizationDisplayName `property`

##### Summary

Gets or sets the display name of the organization. This is optional.

<a name='P-Saml-MetadataBuilder-Organization-OrganizationName'></a>
### OrganizationName `property`

##### Summary

Gets or sets the name of the organization. This is optional.

<a name='P-Saml-MetadataBuilder-Organization-OrganizationURL'></a>
### OrganizationURL `property`

##### Summary

Gets or sets the organization URL. This is optional.

<a name='T-Saml-MetadataBuilder-RequestedAttribute'></a>
## RequestedAttribute `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-RequestedAttribute-IsRequiredField'></a>
### IsRequiredField `property`

##### Summary

Gets or sets a value indicating whether this instance is required field.

<a name='P-Saml-MetadataBuilder-RequestedAttribute-IsRequiredFieldSpecified'></a>
### IsRequiredFieldSpecified `property`

##### Summary

Gets or sets a value indicating whether this instance is required field specified.

<a name='T-Saml-MetadataBuilder-RequestingAuthenticationContext'></a>
## RequestingAuthenticationContext `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Represents information about the authentication context requirements 
of authentication statements returned in responses

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-#ctor-System-String[]-'></a>
### #ctor(authnContextRefTypes) `constructor`

##### Summary

Initializes a new instance of the [RequestingAuthenticationContext](#T-Saml-MetadataBuilder-RequestingAuthenticationContext 'Saml.MetadataBuilder.RequestingAuthenticationContext') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| authnContextRefTypes | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The authn context reference types. |

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-#ctor-System-String-'></a>
### #ctor(authnContextRefTypes) `constructor`

##### Summary

Initializes a new instance of the [RequestingAuthenticationContext](#T-Saml-MetadataBuilder-RequestingAuthenticationContext 'Saml.MetadataBuilder.RequestingAuthenticationContext') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| authnContextRefTypes | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The authn context reference types. |

<a name='F-Saml-MetadataBuilder-RequestingAuthenticationContext-authnContextRefTypes'></a>
### authnContextRefTypes `constants`

##### Summary

The authn context reference types

<a name='F-Saml-MetadataBuilder-RequestingAuthenticationContext-comparisonType'></a>
### comparisonType `constants`

##### Summary

The comparison type

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-AuthenticationContext-System-String-'></a>
### AuthenticationContext(comparisonType) `method`

##### Summary

Authns the context.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| comparisonType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Type of the comparison. |

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-Better'></a>
### Better() `method`

##### Summary

Betters this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-Custom-System-String-'></a>
### Custom(comparisonType) `method`

##### Summary

Customs the specified comparison type.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| comparisonType | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Type of the comparison. |

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-Default'></a>
### Default() `method`

##### Summary

Defaults this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-Exact'></a>
### Exact() `method`

##### Summary

Exacts this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-Maximum'></a>
### Maximum() `method`

##### Summary

Maximums this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContext-Minimum'></a>
### Minimum() `method`

##### Summary

Minimums this instance.

##### Returns



##### Parameters

This method has no parameters.

<a name='T-Saml-MetadataBuilder-RequestingAuthenticationContextTypes'></a>
## RequestingAuthenticationContextTypes `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-RequestingAuthenticationContextTypes-FormsAuthentication'></a>
### FormsAuthentication `property`

##### Summary

Gets the forms authentication.

<a name='P-Saml-MetadataBuilder-RequestingAuthenticationContextTypes-WindowsAuthentication'></a>
### WindowsAuthentication `property`

##### Summary

Gets the windows authentication.

<a name='M-Saml-MetadataBuilder-RequestingAuthenticationContextTypes-Custom-System-String[],System-String-'></a>
### Custom(authnContextRefTypes,comparisonTypes) `method`

##### Summary

Customs the specified authn context reference types.

##### Returns



##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| authnContextRefTypes | [System.String[]](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String[] 'System.String[]') | The authn context reference types. |
| comparisonTypes | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The comparison types. |

<a name='T-Saml-MetadataBuilder-RoleDescriptor'></a>
## RoleDescriptor `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='P-Saml-MetadataBuilder-RoleDescriptor-CacheDuration'></a>
### CacheDuration `property`

##### Summary

Gets or sets the duration of the cache.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-ContactPersons'></a>
### ContactPersons `property`

##### Summary

Gets or sets the contact person.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-Extensions'></a>
### Extensions `property`

##### Summary

Gets or sets the extensions.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-Id'></a>
### Id `property`

##### Summary

Gets or sets the identifier.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-KeyDescriptor'></a>
### KeyDescriptor `property`

##### Summary

Gets or sets the key descriptor.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-Organization'></a>
### Organization `property`

##### Summary

Gets or sets the organization.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-ProtocolSupportEnumeration'></a>
### ProtocolSupportEnumeration `property`

##### Summary

Gets or sets the protocol support enumeration.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-Signature'></a>
### Signature `property`

##### Summary

Gets or sets the signature.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-ValidUntil'></a>
### ValidUntil `property`

##### Summary

Gets or sets the valid until.

<a name='P-Saml-MetadataBuilder-RoleDescriptor-ValidUntilFieldSpecified'></a>
### ValidUntilFieldSpecified `property`

##### Summary

Gets or sets a value indicating whether [valid until field specified].

<a name='T-Saml-MetadataBuilder-SPSSODescriptor'></a>
## SPSSODescriptor `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



##### See Also

- [Saml.MetadataBuilder.SSODescriptor](#T-Saml-MetadataBuilder-SSODescriptor 'Saml.MetadataBuilder.SSODescriptor')

<a name='P-Saml-MetadataBuilder-SPSSODescriptor-AssertionConsumerServices'></a>
### AssertionConsumerServices `property`

##### Summary

Gets or sets the assertion consumer services.

<a name='P-Saml-MetadataBuilder-SPSSODescriptor-AttributeConsumingService'></a>
### AttributeConsumingService `property`

##### Summary

Gets or sets the attribute consuming service.

<a name='P-Saml-MetadataBuilder-SPSSODescriptor-AuthnRequestsSigned'></a>
### AuthnRequestsSigned `property`

##### Summary

Gets or sets a value indicating whether [authn requests signed].

<a name='P-Saml-MetadataBuilder-SPSSODescriptor-AuthnRequestsSignedFieldSpecified'></a>
### AuthnRequestsSignedFieldSpecified `property`

##### Summary

Gets or sets a value indicating whether [authn requests signed field specified].

<a name='P-Saml-MetadataBuilder-SPSSODescriptor-WantAssertionsSigned'></a>
### WantAssertionsSigned `property`

##### Summary

Gets or sets a value indicating whether [want assertions signed].

<a name='P-Saml-MetadataBuilder-SPSSODescriptor-WantAssertionsSignedFieldSpecified'></a>
### WantAssertionsSignedFieldSpecified `property`

##### Summary

Gets or sets a value indicating whether [want assertions signed field specified].

<a name='T-Saml-MetadataBuilder-SSODescriptor'></a>
## SSODescriptor `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



##### See Also

- [Saml.MetadataBuilder.RoleDescriptor](#T-Saml-MetadataBuilder-RoleDescriptor 'Saml.MetadataBuilder.RoleDescriptor')

<a name='P-Saml-MetadataBuilder-SSODescriptor-ArtifactResolutionServices'></a>
### ArtifactResolutionServices `property`

##### Summary

Gets or sets the artifact resolution service.

<a name='P-Saml-MetadataBuilder-SSODescriptor-ManageNameIdServices'></a>
### ManageNameIdServices `property`

##### Summary

Used to configure handlers that are responsible 
for processing name identifier management messages from an IdP. 
These are protocol specific, but generally fall into two classes: 
requests, which inform the SP of a change, and responses, 
which conclude a change event initiated by the SP

.

<a name='P-Saml-MetadataBuilder-SSODescriptor-NameIdFormats'></a>
### NameIdFormats `property`

##### Summary

Gets or sets the name identifier format.

<a name='P-Saml-MetadataBuilder-SSODescriptor-SingleLogoutServices'></a>
### SingleLogoutServices `property`

##### Summary

Gets or sets the single logout service.

<a name='T-Saml-MetadataBuilder-ServiceCollectionExtensions'></a>
## ServiceCollectionExtensions `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='M-Saml-MetadataBuilder-ServiceCollectionExtensions-AddSamlMetadatBuilder-Microsoft-Extensions-DependencyInjection-IServiceCollection-'></a>
### AddSamlMetadatBuilder(services) `method`

##### Summary

Adds the saml metadat builder.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| services | [Microsoft.Extensions.DependencyInjection.IServiceCollection](#T-Microsoft-Extensions-DependencyInjection-IServiceCollection 'Microsoft.Extensions.DependencyInjection.IServiceCollection') | The services. |

<a name='T-Saml-MetadataBuilder-ServiceProviderConfiguration'></a>
## ServiceProviderConfiguration `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Saml2SPConfiguration class

<a name='M-Saml-MetadataBuilder-ServiceProviderConfiguration-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [ServiceProviderConfiguration](#T-Saml-MetadataBuilder-ServiceProviderConfiguration 'Saml.MetadataBuilder.ServiceProviderConfiguration') class.

##### Parameters

This constructor has no parameters.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-AssertionConsumerServices'></a>
### AssertionConsumerServices `property`

##### Summary

Gets or sets the assertion consumer services indexed endpoint.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-KeyInfos'></a>
### KeyInfos `property`

##### Summary

Gets the key infos.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-NameIdFormat'></a>
### NameIdFormat `property`

##### Summary

Gets or sets the name identifier format.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-Signature'></a>
### Signature `property`

##### Summary

Gets or sets the signature.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-SigningCredentials'></a>
### SigningCredentials `property`

##### Summary

Gets or sets the signing credentials.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-SingleLogoutServices'></a>
### SingleLogoutServices `property`

##### Summary

Gets or sets the single logout services endpoints.

<a name='P-Saml-MetadataBuilder-ServiceProviderConfiguration-TokenEndpoint'></a>
### TokenEndpoint `property`

##### Summary

Gets or sets the token endpoint.

<a name='T-MetadataBuilder-Schema-Metadata-SignaturePropertyType'></a>
## SignaturePropertyType `type`

##### Namespace

MetadataBuilder.Schema.Metadata

<a name='T-Saml-MetadataBuilder-SingleLogoutServiceTypes'></a>
## SingleLogoutServiceTypes `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

SingleLogoutService endpoint with different binding value types.

<a name='P-Saml-MetadataBuilder-SingleLogoutServiceTypes-Post'></a>
### Post `property`

<a name='P-Saml-MetadataBuilder-SingleLogoutServiceTypes-Redirect'></a>
### Redirect `property`

##### Summary

Gets the binding of type REDIRECT.

<a name='T-Saml-MetadataBuilder-UiInfo'></a>
## UiInfo `type`

##### Namespace

Saml.MetadataBuilder

##### Summary

Ui info

<a name='P-Saml-MetadataBuilder-UiInfo-Description'></a>
### Description `property`

##### Summary

Gets or sets the description.

<a name='P-Saml-MetadataBuilder-UiInfo-DisplayName'></a>
### DisplayName `property`

##### Summary

Gets or sets the display name.

<a name='P-Saml-MetadataBuilder-UiInfo-InformationURL'></a>
### InformationURL `property`

##### Summary

Gets or sets the information URL.

<a name='P-Saml-MetadataBuilder-UiInfo-Keywords'></a>
### Keywords `property`

##### Summary

Gets or sets the keywords.

<a name='P-Saml-MetadataBuilder-UiInfo-Logo'></a>
### Logo `property`

##### Summary

Gets or sets the logo.

<a name='P-Saml-MetadataBuilder-UiInfo-PrivacyStatementURL'></a>
### PrivacyStatementURL `property`

##### Summary

Gets or sets the privacy statement URL.

<a name='T-Saml-MetadataBuilder-Writer'></a>
## Writer `type`

##### Namespace

Saml.MetadataBuilder

##### Summary



<a name='M-Saml-MetadataBuilder-Writer-#ctor-Saml-MetadataBuilder-IMetadataMapper{Saml-MetadataBuilder-SpMetadata,MetadataBuilder-Schema-Metadata-SPSSODescriptorType}-'></a>
### #ctor(spMetadataMapper) `constructor`

##### Summary

Initializes a new instance of the [Writer](#T-Saml-MetadataBuilder-Writer 'Saml.MetadataBuilder.Writer') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| spMetadataMapper | [Saml.MetadataBuilder.IMetadataMapper{Saml.MetadataBuilder.SpMetadata,MetadataBuilder.Schema.Metadata.SPSSODescriptorType}](#T-Saml-MetadataBuilder-IMetadataMapper{Saml-MetadataBuilder-SpMetadata,MetadataBuilder-Schema-Metadata-SPSSODescriptorType} 'Saml.MetadataBuilder.IMetadataMapper{Saml.MetadataBuilder.SpMetadata,MetadataBuilder.Schema.Metadata.SPSSODescriptorType}') | The sp metadata mapper. |

<a name='T-MetadataBuilder-Constants-X509DataTypes'></a>
## X509DataTypes `type`

##### Namespace

MetadataBuilder.Constants

##### Summary



<a name='F-MetadataBuilder-Constants-X509DataTypes-Item'></a>
### Item `constants`

##### Summary

The item

<a name='F-MetadataBuilder-Constants-X509DataTypes-X509CRL'></a>
### X509CRL `constants`

##### Summary

The X509 CRL

<a name='F-MetadataBuilder-Constants-X509DataTypes-X509Certificate'></a>
### X509Certificate `constants`

##### Summary

The X509 certificate

<a name='F-MetadataBuilder-Constants-X509DataTypes-X509IssuerSerial'></a>
### X509IssuerSerial `constants`

##### Summary

The X509 issuer serial

<a name='F-MetadataBuilder-Constants-X509DataTypes-X509SKI'></a>
### X509SKI `constants`

##### Summary

The X509 ski

<a name='F-MetadataBuilder-Constants-X509DataTypes-X509SubjectName'></a>
### X509SubjectName `constants`

##### Summary

The X509 subject name
