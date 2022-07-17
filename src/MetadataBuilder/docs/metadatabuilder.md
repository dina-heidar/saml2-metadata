<a name='assembly'></a>
# MetadataBuilder

## Contents

- [AssertionConsumerService](#T-MetadataBuilder-Endpoints-AssertionConsumerService 'MetadataBuilder.Endpoints.AssertionConsumerService')
  - [Artifact](#P-MetadataBuilder-Endpoints-AssertionConsumerService-Artifact 'MetadataBuilder.Endpoints.AssertionConsumerService.Artifact')
  - [Post](#P-MetadataBuilder-Endpoints-AssertionConsumerService-Post 'MetadataBuilder.Endpoints.AssertionConsumerService.Post')
  - [Redirect](#P-MetadataBuilder-Endpoints-AssertionConsumerService-Redirect 'MetadataBuilder.Endpoints.AssertionConsumerService.Redirect')
- [Binding](#T-MetadataBuilder-Bindings-Binding 'MetadataBuilder.Bindings.Binding')
  - [#ctor(binding)](#M-MetadataBuilder-Bindings-Binding-#ctor-System-String- 'MetadataBuilder.Bindings.Binding.#ctor(System.String)')
  - [binding](#F-MetadataBuilder-Bindings-Binding-binding 'MetadataBuilder.Bindings.Binding.binding')
  - [Url(location,responseLocation)](#M-MetadataBuilder-Bindings-Binding-Url-System-String,System-String- 'MetadataBuilder.Bindings.Binding.Url(System.String,System.String)')
  - [Url(location,index,isDefault)](#M-MetadataBuilder-Bindings-Binding-Url-System-String,System-Int32,System-Boolean- 'MetadataBuilder.Bindings.Binding.Url(System.String,System.Int32,System.Boolean)')
- [Bindings](#T-MetadataBuilder-Constants-Bindings 'MetadataBuilder.Constants.Bindings')
  - [Artifact](#F-MetadataBuilder-Constants-Bindings-Artifact 'MetadataBuilder.Constants.Bindings.Artifact')
  - [Post](#F-MetadataBuilder-Constants-Bindings-Post 'MetadataBuilder.Constants.Bindings.Post')
  - [Redirect](#F-MetadataBuilder-Constants-Bindings-Redirect 'MetadataBuilder.Constants.Bindings.Redirect')
- [Endpoint](#T-MetadataBuilder-Domains-Endpoint 'MetadataBuilder.Domains.Endpoint')
  - [Binding](#P-MetadataBuilder-Domains-Endpoint-Binding 'MetadataBuilder.Domains.Endpoint.Binding')
  - [Location](#P-MetadataBuilder-Domains-Endpoint-Location 'MetadataBuilder.Domains.Endpoint.Location')
  - [ResponseLocation](#P-MetadataBuilder-Domains-Endpoint-ResponseLocation 'MetadataBuilder.Domains.Endpoint.ResponseLocation')
- [IndexedEndpoint](#T-MetadataBuilder-Domains-IndexedEndpoint 'MetadataBuilder.Domains.IndexedEndpoint')
  - [index](#P-MetadataBuilder-Domains-IndexedEndpoint-index 'MetadataBuilder.Domains.IndexedEndpoint.index')
  - [isDefault](#P-MetadataBuilder-Domains-IndexedEndpoint-isDefault 'MetadataBuilder.Domains.IndexedEndpoint.isDefault')
  - [isDefaultSpecified](#P-MetadataBuilder-Domains-IndexedEndpoint-isDefaultSpecified 'MetadataBuilder.Domains.IndexedEndpoint.isDefaultSpecified')
- [NameIDFormats](#T-MetadataBuilder-Constants-NameIDFormats 'MetadataBuilder.Constants.NameIDFormats')
  - [Email](#F-MetadataBuilder-Constants-NameIDFormats-Email 'MetadataBuilder.Constants.NameIDFormats.Email')
  - [Encrypted](#F-MetadataBuilder-Constants-NameIDFormats-Encrypted 'MetadataBuilder.Constants.NameIDFormats.Encrypted')
  - [EntityIdentifier](#F-MetadataBuilder-Constants-NameIDFormats-EntityIdentifier 'MetadataBuilder.Constants.NameIDFormats.EntityIdentifier')
  - [KerberosPrincipalName](#F-MetadataBuilder-Constants-NameIDFormats-KerberosPrincipalName 'MetadataBuilder.Constants.NameIDFormats.KerberosPrincipalName')
  - [Persistent](#F-MetadataBuilder-Constants-NameIDFormats-Persistent 'MetadataBuilder.Constants.NameIDFormats.Persistent')
  - [SubjectName](#F-MetadataBuilder-Constants-NameIDFormats-SubjectName 'MetadataBuilder.Constants.NameIDFormats.SubjectName')
  - [Transient](#F-MetadataBuilder-Constants-NameIDFormats-Transient 'MetadataBuilder.Constants.NameIDFormats.Transient')
  - [Unspecified](#F-MetadataBuilder-Constants-NameIDFormats-Unspecified 'MetadataBuilder.Constants.NameIDFormats.Unspecified')
  - [WindowsDomainQualifiedName](#F-MetadataBuilder-Constants-NameIDFormats-WindowsDomainQualifiedName 'MetadataBuilder.Constants.NameIDFormats.WindowsDomainQualifiedName')
- [Saml2SPConfiguration](#T-MetadataBuilder-Configuration-Saml2SPConfiguration 'MetadataBuilder.Configuration.Saml2SPConfiguration')
  - [#ctor()](#M-MetadataBuilder-Configuration-Saml2SPConfiguration-#ctor 'MetadataBuilder.Configuration.Saml2SPConfiguration.#ctor')
  - [AssertionConsumerServices](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-AssertionConsumerServices 'MetadataBuilder.Configuration.Saml2SPConfiguration.AssertionConsumerServices')
  - [KeyInfos](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-KeyInfos 'MetadataBuilder.Configuration.Saml2SPConfiguration.KeyInfos')
  - [NameIdFormat](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-NameIdFormat 'MetadataBuilder.Configuration.Saml2SPConfiguration.NameIdFormat')
  - [Signature](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-Signature 'MetadataBuilder.Configuration.Saml2SPConfiguration.Signature')
  - [SigningCredentials](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-SigningCredentials 'MetadataBuilder.Configuration.Saml2SPConfiguration.SigningCredentials')
  - [SingleLogoutServices](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-SingleLogoutServices 'MetadataBuilder.Configuration.Saml2SPConfiguration.SingleLogoutServices')
  - [TokenEndpoint](#P-MetadataBuilder-Configuration-Saml2SPConfiguration-TokenEndpoint 'MetadataBuilder.Configuration.Saml2SPConfiguration.TokenEndpoint')
- [SignaturePropertyType](#T-MetadataBuilder-Schema-Metadata-SignaturePropertyType 'MetadataBuilder.Schema.Metadata.SignaturePropertyType')
- [SingleLogoutService](#T-MetadataBuilder-Endpoints-SingleLogoutService 'MetadataBuilder.Endpoints.SingleLogoutService')
  - [Post](#P-MetadataBuilder-Endpoints-SingleLogoutService-Post 'MetadataBuilder.Endpoints.SingleLogoutService.Post')
  - [Redirect](#P-MetadataBuilder-Endpoints-SingleLogoutService-Redirect 'MetadataBuilder.Endpoints.SingleLogoutService.Redirect')

<a name='T-MetadataBuilder-Endpoints-AssertionConsumerService'></a>
## AssertionConsumerService `type`

##### Namespace

MetadataBuilder.Endpoints

##### Summary

AssertionConsumerService indexed endpoint with different binding value types.

<a name='P-MetadataBuilder-Endpoints-AssertionConsumerService-Artifact'></a>
### Artifact `property`

##### Summary

Gets the binding of type ARTIFACT.

<a name='P-MetadataBuilder-Endpoints-AssertionConsumerService-Post'></a>
### Post `property`

##### Summary

Gets the binding of type POST.

<a name='P-MetadataBuilder-Endpoints-AssertionConsumerService-Redirect'></a>
### Redirect `property`

##### Summary

Gets the binding of type REDIRECT.

<a name='T-MetadataBuilder-Bindings-Binding'></a>
## Binding `type`

##### Namespace

MetadataBuilder.Bindings

##### Summary



<a name='M-MetadataBuilder-Bindings-Binding-#ctor-System-String-'></a>
### #ctor(binding) `constructor`

##### Summary

Initializes a new instance of the [Binding](#T-MetadataBuilder-Bindings-Binding 'MetadataBuilder.Bindings.Binding') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| binding | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The binding. |

<a name='F-MetadataBuilder-Bindings-Binding-binding'></a>
### binding `constants`

##### Summary

The binding

<a name='M-MetadataBuilder-Bindings-Binding-Url-System-String,System-String-'></a>
### Url(location,responseLocation) `method`

##### Summary

Creates the SAML URL endpoint with the specified location and optionally with a response location.

##### Returns

Endpoint

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| location | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The location. |
| responseLocation | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The response location (optional). |

##### Exceptions

| Name | Description |
| ---- | ----------- |
| [MetadataBuilder.Saml2MetadataSerializationException](#T-MetadataBuilder-Saml2MetadataSerializationException 'MetadataBuilder.Saml2MetadataSerializationException') | Endpoint location is not a valid Url orEndpoint response location is not a valid Url. |

<a name='M-MetadataBuilder-Bindings-Binding-Url-System-String,System-Int32,System-Boolean-'></a>
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
| [MetadataBuilder.Saml2MetadataSerializationException](#T-MetadataBuilder-Saml2MetadataSerializationException 'MetadataBuilder.Saml2MetadataSerializationException') | Endpoint location is not a valid Url |

<a name='T-MetadataBuilder-Constants-Bindings'></a>
## Bindings `type`

##### Namespace

MetadataBuilder.Constants

##### Summary

Binding contstant values

<a name='F-MetadataBuilder-Constants-Bindings-Artifact'></a>
### Artifact `constants`

##### Summary

The HTTP artifact saml xml constant value

<a name='F-MetadataBuilder-Constants-Bindings-Post'></a>
### Post `constants`

##### Summary

The HTTP post saml xml constant value

<a name='F-MetadataBuilder-Constants-Bindings-Redirect'></a>
### Redirect `constants`

##### Summary

The HTTP redirect saml xml constant value

<a name='T-MetadataBuilder-Domains-Endpoint'></a>
## Endpoint `type`

##### Namespace

MetadataBuilder.Domains

##### Summary

Endpoint class

<a name='P-MetadataBuilder-Domains-Endpoint-Binding'></a>
### Binding `property`

##### Summary

Gets or sets the binding.

<a name='P-MetadataBuilder-Domains-Endpoint-Location'></a>
### Location `property`

##### Summary

Gets or sets the location.

<a name='P-MetadataBuilder-Domains-Endpoint-ResponseLocation'></a>
### ResponseLocation `property`

##### Summary

Gets or sets the response location.

<a name='T-MetadataBuilder-Domains-IndexedEndpoint'></a>
## IndexedEndpoint `type`

##### Namespace

MetadataBuilder.Domains

##### Summary

IndexedEndpoint which inherits from Endpoint.

<a name='P-MetadataBuilder-Domains-IndexedEndpoint-index'></a>
### index `property`

##### Summary

Gets or sets the index.

<a name='P-MetadataBuilder-Domains-IndexedEndpoint-isDefault'></a>
### isDefault `property`

##### Summary

Gets or sets a value indicating whether this index value is the default value.

<a name='P-MetadataBuilder-Domains-IndexedEndpoint-isDefaultSpecified'></a>
### isDefaultSpecified `property`

##### Summary

Gets or sets a value indicating whether if default value is specified.

<a name='T-MetadataBuilder-Constants-NameIDFormats'></a>
## NameIDFormats `type`

##### Namespace

MetadataBuilder.Constants

##### Summary

NameIDFormats contstant values

<a name='F-MetadataBuilder-Constants-NameIDFormats-Email'></a>
### Email `constants`

##### Summary

The email saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-Encrypted'></a>
### Encrypted `constants`

##### Summary

The encrypted saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-EntityIdentifier'></a>
### EntityIdentifier `constants`

##### Summary

The entity identifier saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-KerberosPrincipalName'></a>
### KerberosPrincipalName `constants`

##### Summary

The kerberos principal name saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-Persistent'></a>
### Persistent `constants`

##### Summary

The persistent saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-SubjectName'></a>
### SubjectName `constants`

##### Summary

The subject name saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-Transient'></a>
### Transient `constants`

##### Summary

The transient saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-Unspecified'></a>
### Unspecified `constants`

##### Summary

The unspecified saml xml constant value

<a name='F-MetadataBuilder-Constants-NameIDFormats-WindowsDomainQualifiedName'></a>
### WindowsDomainQualifiedName `constants`

##### Summary

The windows domain qualified name saml xml constant value

<a name='T-MetadataBuilder-Configuration-Saml2SPConfiguration'></a>
## Saml2SPConfiguration `type`

##### Namespace

MetadataBuilder.Configuration

##### Summary

Saml2SPConfiguration class

<a name='M-MetadataBuilder-Configuration-Saml2SPConfiguration-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [Saml2SPConfiguration](#T-MetadataBuilder-Configuration-Saml2SPConfiguration 'MetadataBuilder.Configuration.Saml2SPConfiguration') class.

##### Parameters

This constructor has no parameters.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-AssertionConsumerServices'></a>
### AssertionConsumerServices `property`

##### Summary

Gets or sets the assertion consumer services indexed endpoint.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-KeyInfos'></a>
### KeyInfos `property`

##### Summary

Gets the key infos.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-NameIdFormat'></a>
### NameIdFormat `property`

##### Summary

Gets or sets the name identifier format.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-Signature'></a>
### Signature `property`

##### Summary

Gets or sets the signature.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-SigningCredentials'></a>
### SigningCredentials `property`

##### Summary

Gets or sets the signing credentials.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-SingleLogoutServices'></a>
### SingleLogoutServices `property`

##### Summary

Gets or sets the single logout services endpoints.

<a name='P-MetadataBuilder-Configuration-Saml2SPConfiguration-TokenEndpoint'></a>
### TokenEndpoint `property`

##### Summary

Gets or sets the token endpoint.

<a name='T-MetadataBuilder-Schema-Metadata-SignaturePropertyType'></a>
## SignaturePropertyType `type`

##### Namespace

MetadataBuilder.Schema.Metadata

<a name='T-MetadataBuilder-Endpoints-SingleLogoutService'></a>
## SingleLogoutService `type`

##### Namespace

MetadataBuilder.Endpoints

##### Summary

SingleLogoutService endpoint with different binding value types.

<a name='P-MetadataBuilder-Endpoints-SingleLogoutService-Post'></a>
### Post `property`

<a name='P-MetadataBuilder-Endpoints-SingleLogoutService-Redirect'></a>
### Redirect `property`

##### Summary

Gets the binding of type REDIRECT.
