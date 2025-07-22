---
uid: DOM_DomInstanceNetworkAttachmentSettings
---

# DomInstanceNetworkAttachmentSettings

The `DomInstanceNetworkAttachmentSettings` object is introduced in DataMiner version 10.5.9/10.6.0<!--RN43114--> and contains the settings related to how attachments are saved linked to a `DomInstance`. [The DOM helper class page](xref:DomHelper_class#attachments) contains more info about attachments. It currently contains settings to change the default location where attachments for DOM are saved from the `C:\Skyline DataMiner\Documents` folder to a network share of your choosing.

|Property |Type   |Description |
|---------|-------|------------|
| NetworkSharePath | string | The UNC path to the network share where the attachments should be saved. |
| CredentialId | Guid | ID of the credential in the credential library. |

## NetworkSharePath

e.g. `\\CompanyServer\DomAttachments`

Contains the UNC path to the network share. It needs to start with `\\` and cannot contain any characters that are illegal for a path (e.g. '<') or strings that allow directory traversal (e.g. '../'). When left empty, attachments are saved to the `C:\Skyline DataMiner\Documents` folder, this is the default behavior. Can only be used in combination with the [CredentialId](#credentialid)

## CredentialId

In order for DataMiner to access the network share, it needs credentials to a user that has read/write access to it. These credentials have to be saved in the credentials library, this can be accessed in Cube, through System Center > System settings > credentials library. It has to be a 'Username and password credentials', in case you have a Windows network share, you need to add the domain name (for domain user) or hostname (for local user) in front of the username (e.g. 'MYPC\userName'). The Guid of the credential can be found in the `C:\Skyline DataMiner\Security\Credentials\Library.xml` file.

>[!NOTE]
> When configuring a DOM module to save attachments to a network share. It is validated that the user creating/updating the `ModuleSettings` has permission to access the credential. Once this is set up, any user that permissions to create/update a `DomInstance` can now save attachments to the network share under the configured user.
