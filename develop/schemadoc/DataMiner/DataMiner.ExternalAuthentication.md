---
uid: DataMiner.ExternalAuthentication
---

# ExternalAuthentication element

Configures external authentication.

## Parents

[DataMiner](xref:DataMiner)

## Attributes

| Name | Type | Required | Description |
| --- | --- | --- | --- |
| [autoproxy](xref:DataMiner.ExternalAuthentication-autoproxy) | boolean |  | Overrides the automatic detection of proxy server settings. |
| [host](xref:DataMiner.ExternalAuthentication-host) | string |  | Specifies the host. |
| [ipMetadata](xref:DataMiner.ExternalAuthentication-ipMetadata) | anySimpleType |  | Specifies the path to or the URL of the identity provider's metadata file. |
| [password](xref:DataMiner.ExternalAuthentication-password) | string |  | Specifies the password. |
| [port](xref:DataMiner.ExternalAuthentication-port) | integer |  | Specifies the port. |
| [sharedSecret](xref:DataMiner.ExternalAuthentication-sharedSecret) | string |  | Specifies the shared secret. |
| [spMetadata](xref:DataMiner.ExternalAuthentication-spMetadata) | anySimpleType |  | Specifies the path to or the URL of the DataMiner metadata file. |
| [timeout](xref:DataMiner.ExternalAuthentication-timeout) | anySimpleType |  | The number of seconds DataMiner should wait for the user to be authenticated by the identity provider. |
| [type](xref:DataMiner.ExternalAuthentication-type) | string |  | Specifies the authentication type. |
| [username](xref:DataMiner.ExternalAuthentication-username) | string |  | Specifies the user name. |

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| [AutomaticUserCreation](xref:DataMiner.ExternalAuthentication.AutomaticUserCreation) | [0, 1] |  |

## Remarks

For more information, see:

- [Configuring SAML with Microsoft Entra ID as identity provider](xref:SAML_using_Entra_ID)
- [Configuring SAML with Okta as the identity provider](xref:SAML_using_Okta)
- [Configuring Atlassian Crowd settings](xref:Configuring_Atlassian_Crowd_settings)
- [Configuring RADIUS settings](xref:Configuring_RADIUS_settings)
