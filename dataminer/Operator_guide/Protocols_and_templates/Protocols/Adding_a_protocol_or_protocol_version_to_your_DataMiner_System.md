---
uid: Adding_a_protocol_or_protocol_version_to_your_DataMiner_System
keywords: adding a driver, adding a connector
---

# Adding a protocol or protocol version to your DataMiner System

Before you can start adding elements that represent a particular device, you first have to upload the protocol for that device.

You can upload:

- a single *Protocol.xml* file (in DataMiner Cube), or

- an entire *.dmprotocol* package (in DataMiner Cube or using DataMiner Taskbar Utility).

> [!TIP]
> See also: [DataMiner packages](xref:DataMiner_packages)

> [!CAUTION]
> When you replace a protocol version (i.e. when you add a protocol version that was already available on your DataMiner System), all elements using that protocol version will restart automatically.

> [!NOTE]
> From DataMiner 10.4.10/10.5.0 onwards<!--RN 40291-->, when you install a protocol for the first time by [uploading a protocol package](#uploading-a-protocol-package) or by [deploying a protocol from the Catalog](#deploying-a-protocol-from-the-catalog), this protocol version will automatically be promoted to the production version.
>
> You will need to manually [promote the protocol version to production version](xref:Promoting_a_protocol_version_to_production_version) in the following cases:
>
> - When you later deploy a new version of the same protocol and want it to be set as the production version.
> - When you install a protocol by [uploading a *Protocol.xml* file](#uploading-a-protocolxml-file).
> - In all instances prior to DataMiner 10.4.10/10.5.0.

## Deploying a protocol from the catalog

See [Deploying a Catalog item](xref:Deploying_a_catalog_item).

## Adding a protocol or protocol version in DataMiner Cube

In DataMiner Cube, you can upload either *Protocol.xml* files or entire protocol packages (extension *.dmprotocol*). In addition, you can also update the protocols in your DMS via the Update Center.

> [!NOTE]
> If uploading a protocol fails, and you see an error message saying "DataMiner was unable to upload protocol", this is most likely because the minimum required DataMiner version for the protocol is higher than your current DataMiner version. Verify the requirements for the protocol and [upgrade DataMiner](xref:Upgrading_a_DataMiner_Agent) if necessary.

### Uploading a Protocol.xml file

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Protocols* or *Versions*, right-click a random protocol or protocol version and select *Upload*.

   Alternatively, you can click the *Upload* button in the lower-right corner of the card.

1. In the *Open* dialog box, select the *Protocol.xml* file to be uploaded, and click *Open*.

### Uploading a protocol package

1. Go to *Apps* > *Protocols & Templates*.

1. In the lower-right corner of the card, click *Upload*.

1. In the *Open* dialog box, select the *.dmprotocol* package to be uploaded, and click *Open*.

### Updating protocols with the Update Center

With the Update Center, you can check if protocol updates are available and, if so, install these.

To do so:

## [From DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 onwards](#tab/tabid-1)

1. In DataMiner Cube, go to the Update Center in one of the following ways:

   - In the Cube header bar, click the user icon on the right and select *Check for updates*.

   - In the Protocols & Templates module, click the *Check for updates* (or *Updates*) link in the upper right corner.

1. Authenticate yourself with your corporate email address. If your corporate email address is linked to a Microsoft (personal or work), Google, Amazon, or LinkedIn account, you can authenticate yourself via one of those identity providers<!--RN 39466-->.

   > [!NOTE]
   > In case you are using the Microsoft login and get an error that says you need admin approval, you can find the steps that your system administrator needs to take to resolve this on [this instructions page](https://dataminer.services/make-an-account/access_dcp.html).

   This will open the Update Center window.

1. Click the *Check for updates* button.

   ![Updating protocols](~/dataminer/images/Updating_Protocols.png)<br>*Update Center in DataMiner 10.4.5*

1. In the list of available protocols, select the protocols you want to install or update, and click *Install*.

   > [!NOTE]
   >
   > - By default, only the most recent new versions of protocols in your DMS will be shown. However, if you want to see all available versions, click the *Show all available updates* button at the bottom of the list of available protocols.
   > - To check for the latest version of a protocol, DataMiner will only look for versions in the same branch as you currently have installed. This means that the first number of the protocol version number needs to match. For example, if you have version 1.1.4.8 installed, only updates for range 1.x.x.x will be considered. This is because this first number indicates different implementations of the protocol, so that a higher number does not necessarily mean an improved version.
   > - You can see more information on each update by selecting the protocol version and then clicking *Version history* in the pane on the right. For protocols that are already installed on your DMS, only information on newer versions is shown. Otherwise, information on all versions is displayed.

1. When the installation is done, a window will appear where you can choose to set the new protocol versions as the production version:

   - Select the protocol versions you want to set as the production version and click *OK*.

   - If you do not want to set any of the updates as the production version, simply click *OK*.

## [Prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7](#tab/tabid-2)

1. In DataMiner Cube, go to the Update Center in one of the following ways:

   - In the Cube header bar, click the user icon on the right and select *Check for updates*.

   - In the Protocols & Templates module, click the *Check for updates* (or *Updates*) link in the upper right corner.

1. Click the *Check for updates* button.

   ![Updating protocols](~/dataminer/images/Updating_Protocols.png)<br>*Update Center in DataMiner 10.4.5*

1. Enter your dataminer.services credentials, and click *OK*.

1. In the list of available protocols, select the protocols you want to install or update, and click *Install*.

   > [!NOTE]
   >
   > - By default, only the most recent new versions of protocols in your DMS will be shown. However, if you want to see all available versions, click the *Show all available updates* button at the bottom of the list of available protocols.
   > - To check for the latest version of a protocol, DataMiner will only look for versions in the same branch as you currently have installed. This means that the first number of the protocol version number needs to match. For example, if you have version 1.1.4.8 installed, only updates for range 1.x.x.x will be considered. This is because this first number indicates different implementations of the protocol, so that a higher number does not necessarily mean an improved version.
   > - You can see more information on each update by selecting the protocol version and then clicking *Version history* in the pane on the right. For protocols that are already installed on your DMS, only information on newer versions is shown. Otherwise, information on all versions is displayed.

1. When the installation is done, a window will appear where you can choose to set the new protocol versions as the production version:

   - Select the protocol versions you want to set as the production version and click *OK*.

   - If you do not want to set any of the updates as the production version, simply click *OK*.

***

There are different types of updates. The type of update is indicated next to each protocol version in the list of available updates.

| Type of update | Description |
|--|--|
| New | A newly ordered protocol that has not yet been installed on your DataMiner System. |
| Update | A new version of a protocol that is installed on your DataMiner System. |
| Available | An older protocol version that is available for you to install. These protocols only appear after you click the *Show all available updates* button, which is only available after you have checked for updates. |
| Trial | A trial version of a protocol that you are allowed to install on your DataMiner System. |
| Help update | A protocol update that only contains updated protocol help. |
| Visio update | A protocol update that only contains updated Visio drawings. |

> [!NOTE]
> To access the Update Center, you need to have the following user permissions:
>
> - [Modules > Protocols & Templates > Protocols > Download protocols from DCP](xref:DataMiner_user_permissions#modules--protocols--templates--protocols--download-protocols-from-dcp)
> - [General > Software updates > Download software updates from DCP](xref:DataMiner_user_permissions#general--software-updates--download-software-updates-from-dcp)
> - [Modules > Protocols & Templates > Protocols > UI available](xref:DataMiner_user_permissions#modules--protocols--templates--protocols--ui-available)
> - [Modules > Protocols & Templates > Protocols > Add](xref:DataMiner_user_permissions#modules--protocols--templates--protocols--add)

## Adding a protocol or protocol version with DataMiner Taskbar Utility

Using DataMiner Taskbar Utility, you cannot upload *Protocol.xml* files, only protocol packages (extension *.dmprotocol*).

1. In the system tray of the DataMiner Agent, right-click the DataMiner Taskbar Utility icon and select *Backup/Restore \> Upload dmprotocol*.

1. In the *Upload dmprotocol package* dialog box, select the *.dmprotocol* package to be uploaded, and click *Upload*.
