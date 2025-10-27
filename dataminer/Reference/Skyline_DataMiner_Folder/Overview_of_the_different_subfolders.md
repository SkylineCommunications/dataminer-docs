---
uid: Overview_of_the_different_subfolders
---

# Overview of the different subfolders

Below you can find an overview of the subfolders located within the `C:\Skyline DataMiner` folder, with information on their purpose and on whether they are synchronized within a DataMiner System or not.

Except when otherwise mentioned in the relevant documentation, manual changes should never be needed to the files in these folders.

| Subdirectory | Contents | Synchronized? |
|--|--|--|
| Aggregation | The aggregation rules configured on the DMA. See [Aggregation](xref:Aggregation). | Yes |
| Applications | Configuration for [low-code apps](xref:Application_framework). | Yes |
| Analytics | Configuration of DataMiner Analytics features (e.g. [custom alarm grouping rules](xref:Customizing_alarm_grouping_rules)). | Yes |
| AppPackages | Uploaded and installed *.dmapp packages. | Partially (only *Installed* subfolder) |
| AssetManager | DataMiner Inventory and Asset Management configuration. Only the *Configs*, *Cache*, and *MediaConfigs* subfolders are synchronized in a DMS. | Partially |
| Backup | Backup settings, backup DLLs, backed-up data. | Partially |
| BPA | [BPA tests](xref:Running_BPA_tests). The *Default* subfolder, which is not synced, contains the default BPA tests deployed by DataMiner upgrades. These same BPA tests are also available in the main *BPA* folder. | Partially (all except *Default* subfolder) |
| Certificates | Certificates for TLS encryption. See [Enabling TLS encryption for serial communication](xref:Enabling_TLS_encryption). | No |
| ClusterNodes | Cluster configuration for Agents connected to dataminer.services. | Partially (only *Configuration* subfolder) |
| Configurations | Contains information about the endpoints in the cluster, required to be able to [migrate to BrokerGateway](xref:BrokerGateway_Migration). | No |
| Connectivity | *Connectivity.xml* files. See [About DCF](xref:About_the_DataMiner_Connectivity_Framework). | Yes |
| Correlation | Correlation rules. See [About Correlation](xref:About_DMS_Correlation). | Yes |
| Dashboards | Configuration for the [Dashboards app](xref:newR_D). | Yes |
| Database | Database-related configuration files. See [Database](xref:Database). | Partially |
| DeployerTokens | Used for the *APIDeployment* soft-launch feature, which is obsolete as of DataMiner 10.4.0. | Yes |
| Documents | Documents added to the DataMiner Agent. | Yes |
| DOM | Documents related to [DataMiner Object Models](xref:DOM). | No |
| Elements | Element data (one subdirectory per element). See [Elements](xref:Elements1#elements). | No |
| Files | EXEs, DLLs, configuration files, etc. | No |
| Filters | No longer used. | No |
| Generic Interface | GQI queries. See [About GQI](xref:About_GQI). | Yes |
| Icons | Custom icons. See [Icons](xref:Icons). | Yes |
| Jobs | Contains configuration related to the migration of the [Jobs](xref:jobs) module to the indexing database. | No |
| Logging | Log files. | No |
| Maps | DataMiner Maps configuration. See [Configuring the DataMiner Maps host servers](xref:Configuring_the_DataMiner_Maps_host_servers). | Yes |
| MIBs | DataMiner MIBs. | No |
| Mobile Gateway | Configuration files for the Mobile Gateway. | No |
| Ownership | Currently unused. | No |
| ProtocolFunctionManager | Advanced SRM configuration. See [Advanced SRM settings](xref:Function_resource_settings). | Yes |
| Protocols | A subdirectory for every protocol installed on the DMA.<br> Each of these protocol subdirectories contain a subdirectory for every version of that protocol. | Yes |
| ProtocolScripts | External scripts, DLLs, and compiled QActions. | Partially (all except `*.QAction.*.dll` files) |
| Recycle Bin | Backup of changed data. See [Recycle bin](xref:Recycle_bin). | No |
| Redundancy | Redundancy group configuration. | No |
| RemoteServices | Services hosted on other DMAs in the cluster. Each of the subfolders in this folder has the DMA ID of the DMA hosting the synchronized services. | Yes |
| ResourceManager | Resource Manager configuration. | No |
| Scripts | Automation scripts. | Yes |
| Security | Within this folder, only the *Credentials* subfolder, which contains the credentials library configuration, and the *Ownership* subfolder are synchronized. | Partially |
| ServiceManager | Service Manager configuration. | No |
| Services | Services hosted on the DMA. | See note below. |
| SharedItems | Information about dashboards that have been shared on dataminer.services. See [Sharing a dashboard](xref:Sharing_a_dashboard). | Yes |
| Simulations | Simulation files. | No |
| Sounds | Custom alert sounds. See [Configuring a custom alert sound for an alarm tab](xref:ConfiguringACustomAlertSoundForAnAlarmTab). | Yes |
| Spectrum Alarm Recordings | Alarm records of spectrum elements. | No |
| System Cache | See [System Cache](xref:System_Cache). | No |
| Ticketing | Contains configuration related to the migration of the [Ticketing](xref:ticketing) module to the indexing database. | No |
| Tools | Tools (StandaloneUpgrade, etc.). Within this folder, only the *SLLogCollector* subfolder is synchronized in the DMS. | Partially |
| Upgrades | Information concerning the last upgrade. | No |
| Users | Stored user information. See [ClientSettings.json](xref:ClientSettings_json#clientsettingsjson). This includes private and public [alarm filters](xref:Alarm_filters) (with public alarm filters being stored in the `C:\Skyline DataMiner\Users\SharedUserSettings\Filters` subfolder). | Yes |
| Views | Visio files. | Yes |
| VisualData | Visual Data Manager configuration. | No |
| Webpages | All webpages of the DataMiner client applications. Within this folder, only the following things are synchronized in a DMS:<br>- The *CustomerLogo* image files.<br>- The *Public* subfolder (from DataMiner 10.5.10/10.6.0 onwards<!-- RN 43458 -->).<br>- The data for legacy dashboards (`C:\Skyline DataMiner\WebPages\Dashboards\Db\`).<br>- The data for legacy reports (`C:\Skyline DataMiner\WebPages\Reports\Templates\`), except for the `tmp_img` subfolder, which contains temporary files.<br>- The data for legacy annotations (`C:\Skyline DataMiner\WebPages\Annotations\DMS Images\` and `C:\Skyline DataMiner\WebPages\Annotations\Views\`). | Partially |

> [!IMPORTANT]
> The synchronization of files across all DMAs in a DataMiner System happens every day at midnight (00:00). It is therefore of great importance that the time settings of the DMAs are synchronized as well. For more information, see [How do I synchronize time settings within a DMS?](xref:General_configuration#how-do-i-synchronize-time-settings-within-a-dms)
