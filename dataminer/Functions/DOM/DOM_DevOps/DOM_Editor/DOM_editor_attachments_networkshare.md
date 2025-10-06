---
uid: DOM_editor_attachments_networkshare
---

# Configuring a network share to store attachments

<!--RN43726-->

From DataMiner 10.5.10/10.6.0 onwards, you can specify a UNC path and select credentials from the credentials library to store DOM attachments linked to DOM instances.

By default, this feature is not enabled, and attachments are saved locally in the `C:\Skyline DataMiner\Documents` folder.

1. Make sure a correct set of credentials of the type *Username and password credentials* is available in the credentials library (accessible in Cube via *System Center* > *System settings*).

1. In the Automation app in DataMiner Cube, run the *DOM Editor* script.

   You can find this script in the folder `DOM\DOM Main scripts`.

   The script window will show a list of the available modules, as well as several buttons.

1. Next to the module for which you want configure a network share, click *Edit*.

   A window with four buttons will be displayed.

   ![DOM Editor: edit module window](~/dataminer/images/DOM_Editor_edit_module.png)

1. Click *Manager Settings*.

1. Click *Network Share Attachment Settings* to open a new page to configure the settings.

    ![DOM Editor: manager settings window](~/dataminer/images/DOM_Editor_managersettings.png)

1. Select the correct set of credentials from the *Credential* dropdown.

   If the expected credentials are not available, verify if your account has permission to use the credentials.

1. In the *Network Share Path* box, fill in the UNC path to the network share.

   Makes sure the path starts with `\\` and does not contain any characters that are illegal for a path (e.g. "<") or strings that allow directory traversal (e.g. "../").

    ![DOM Editor: network attachment settings window](~/dataminer/images/DOM_Editor_networkshare.png)

1. Click *Back* again and then click *Apply* and *OK*.

1. Click *Back* again and click the *Reinitialize* button next to the module you have configured.

> [!NOTE]
> The configuration creates a [DomInstanceNetworkAttachmentSettings](xref:DOM_DomInstanceNetworkAttachmentSettings) object.
