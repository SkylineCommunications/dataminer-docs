---
uid: AboutCloudPlatform
---

# About dataminer.services

By connecting to dataminer.services, you can augment your DataMiner System with a host of additional services.

The dataminer.services home page is available via <https://dataminer.services>. For more information on how to log on, see [Logging on to dataminer.services](xref:Logging_on_to_the_DataMiner_Cloud_Platform).

For more information on how to connect to dataminer.services (i.e. connect to the cloud), see [Connecting your DataMiner System to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Other apps

On the dataminer.services home page, you will find links to the different available dataminer.services apps:

- [Project Collaboration](xref:Collaboration)

- [DataMiner Catalog](xref:About_the_Catalog_module)

- [DataMiner Sharing](xref:Sharing)

- [DataMiner Community](xref:Community)

- [Admin](xref:CloudAdminApp)

When your DMS has been connected to dataminer.services, you can also make use of the [DataMiner Teams bot](xref:DataMiner_Teams_bot).

## System overview

The home page also lists the DataMiner Systems that have been [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), provides links to different URLs for [remote access](xref:Cloud_Remote_Access), and allows you to [link your dataminer.services and DataMiner account](xref:Linking_your_DataMiner_and_DCP_account).

### Connection states

On the dataminer.services page you can see the state of the connection between your system and the dataminer.services platform. Next to the name of your DMS you will have an icon that will change color based on the state.

#### DMS has a connection to dataminer.services

Everything is okay and you can access your system and use all the features that the dataminer.services platform offers. This is indicated by the green colored icon and the green bar next to the DMS information.

![Connection status ok](~/user-guide/images/DMS_status_overview_ok.png)

#### DMS has a connection to dataminer.services but not online

Your DMS has a connection to dataminer.services but the DMS itself is not running. This is indicated by the orange colored icon and the orange color next to the DMS information. You also get an indication of the last point in time where the system was detected as being online.

![DMS offline](~/user-guide/images/DMS_status_overview_dms_offline.png)

#### DMS has no connection to dataminer.services

Your DMS has no connection to dataminer.services. This is indicated by the red colored icon which has a line through it and the red bar next to the DMS information. You also get an indication of the last point in time where the system was detected as being online.

![No connection](~/user-guide/images/DMS_status_overview_no_connection.png)

#### Something is wrong in the cloud

We can't determine the status of the connection because of an error in dataminer.services. In this case you will get a warning.

![Problem in dataminer.services](~/user-guide/images/DMS_status_overview_cloud_error.png)

> [!TIP]
> For information about the security of dataminer.services, see [Cloud connectivity and security](xref:Cloud_connectivity_and_security).
