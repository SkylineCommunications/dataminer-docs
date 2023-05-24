---
uid: Adding_a_protocol_or_protocol_version_to_your_DataMiner_System
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

## Deploying a protocol from the catalog

See [Deploying a DataMiner connector to your system](xref:Deploying_A_DataMiner_Connector_to_your_system).

## Adding a protocol or protocol version in DataMiner Cube

In DataMiner Cube, you can upload either *Protocol.xml* files or entire protocol packages (extension *.dmprotocol*). In addition, you can also update the protocols in your DMS via the Update Center.

### Uploading a Protocol.xml file

1. Go to *Apps* > *Protocols & Templates*.

1. Under *Protocols* or *Versions*, right-click a random protocol or protocol version and select *Upload*.

   Alternatively, you can click the *Upload* button in the lower right corner of the card.

1. In the *Open* dialog box, select the *Protocol.xml* file to be uploaded, and click *Open*.

### Uploading a protocol package

1. Go to *Apps* > *Protocols & Templates*.

1. In the lower right corner of the card, click *Upload*.

1. In the *Open* dialog box, select the *.dmprotocol* package to be uploaded, and click *Open*.

### Updating protocols with the Update Center

> [!TIP]
> See also: [Rui’s Rapid Recap – Protocol Update Center](https://community.dataminer.services/video/ruis-rapid-recap-protocol-update-center/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png)

With the Update Center, you can check if protocol updates are available and, if so, install these.

To do so:

1. In DataMiner Cube, go to the Update Center in one of the following ways:

   - From DataMiner 10.0.0/10.0.2 onwards:

     - In the Cube header bar, click the user icon on the right and select *Check for updates*.

     - In the Protocols & Templates module, click the *Check for updates* (or *Updates*) link in the upper right corner.

   - Using a version prior to DataMiner 10.0.0/10.0.2:

     - On the right-hand side of the DataMiner Cube header bar, click the “Updates are available” icon.

     - On the right-hand side of the DataMiner Cube header bar, click the Help icon and select *Check for updates* from the menu.

     - In the Protocols & Templates module, click the *Check for updates* (or *Updates*) link in the upper right corner.

1. Click the *Check for updates* button.

1. Enter your DCP credentials, and click *OK*.

1. In the list of available protocols, select the protocols you want to install or update, and click *Install*.

   > [!NOTE]
   >
   > - By default, only the most recent new versions of protocols in your DMS will be shown. However, if you want to see all available versions, click the *Show all available updates* button at the bottom of the list of available protocols.
   > - To check for the latest version of a protocol, DataMiner will only look for versions in the same branch as you currently have installed. This means that the first number of the protocol version number needs to match. For example, if you have version 1.1.4.8 installed, only updates for range 1.x.x.x will be considered. This is because this first number indicates different implementations of the protocol, so that a higher number does not necessarily mean an improved version.
   > - You can see more information on each update by selecting the protocol version and then clicking *Version history* in the pane on the right. For protocols that are already installed on your DMS, only information on newer versions is shown. Otherwise, information on all versions is displayed.

1. When the installation is done, a window will appear where you can choose to set the new protocol versions as the production version:

   - Select the protocol versions you want to set as the production version and click *OK*.

   - If you do not want to set any of the updates as the production version, simply click *OK*.

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
