---
uid: DOM_DomInstanceNetworkAttachmentSettings
---

# DomInstanceNetworkAttachmentSettings

The `DomInstanceNetworkAttachmentSettings` object is introduced in DataMiner version 10.5.10/10.6.0<!-- RN 43114+43366 --> and contains the settings related to how attachments are saved linked to a `DomInstance`. [The DOM helper class page](xref:DomHelper_class#attachments) contains more info about attachments.

This object currently contains settings to change the default location where attachments for DOM are saved from the `C:\Skyline DataMiner\Documents` folder to a network share of your choosing.

We recommend configuring your DOM modules using the [DOM Editor](xref:DOM_Editor) tool, because that way you will be able to configure these settings directly through the tool.

> [!NOTE]
>
> - When a DOM module is configured to save attachments to a network share, the system will validate whether the user creating/updating the `ModuleSettings` has permission to access the credentials. Once this is set up, any user that has permissions to create or update a `DomInstance` can now save attachments to the network share under the configured user.
> - When a DOM module is configured to save attachments to a network share, no migration is done of existing attachments. They will continue to exist in the `C:\Skyline DataMiner\Documents` folder, but will no longer work. You can copy them over or move them to the network share; the folder structure is the same. Likewise, when removing the configuration to save attachments to a network share, no migration is done of attachments available on the previously configured network share.

|Property |Type   |Description |
|---------|-------|------------|
| NetworkSharePath | string | The UNC path to the network share where the attachments should be saved. |
| CredentialId | Guid | The ID of the credentials in the credentials library. |

## NetworkSharePath

For example: `\\CompanyServer\DomAttachments`

Contains the UNC path to the network share. It needs to start with `\\` and cannot contain any characters that are illegal for a path (e.g. "<") or strings that allow directory traversal (e.g. "../").

When the path is left empty, attachments are saved to the `C:\Skyline DataMiner\Documents` folder. This is the default behavior.

Can only be used in combination with [CredentialId](#credentialid).

## CredentialId

In order for DataMiner to access the network share, it needs the credentials of a user that has read/write access to the path defined in [NetworkSharePath](#networksharepath).

These credentials have to be saved in the **credentials library**, which can be accessed in Cube, via *System Center* > *System settings* > *credentials library*. They have to be credentials of type *Username and password credentials*. In case you have a Windows network share, you need to add the domain name (for domain user) or hostname (for local user) in front of the username (e.g. "MYPC\userName").
