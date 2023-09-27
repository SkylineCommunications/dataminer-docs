---
uid: Overview_of_the_files_found_in_the_root_folder
---

# Overview of the files found in the root folder

> [!NOTE]
> All DataMiner system files can be found in the *C:\\Skyline DataMiner* folder of a DataMiner Agent.

| Name | Description | Synchronized? |
|--|--|--|
| BaseSubscriptions.xml | Base subscriptions, i.e. element subscriptions that remain open, so that the element info is cached in SLNet. | No |
| Brain.xml | Correlation rules. | Yes |
| ClientApps.lic | License file for client applications. No longer used. When you upgrade to a recent DataMiner version, this file is removed during the upgrade. | No |
| ClusterInfo.xml | Contains the ID ranges for the views of each DMA in the cluster. | Yes |
| DataMiner.lic | DataMiner license file. | No |
| DataMiner.xml | General DataMiner configuration. See [DataMiner.xml](xref:DataMiner_xml). | Partially |
| DB.xml | Database configuration. See [DB.xml](xref:DB_xml). | Partially |
| DMS.xml | IP addresses of the different DMAs in the DMS cluster. See [DMS.xml](xref:DMS_xml). | Partially |
| ElementTypes.xml | Currently not used. | Yes |
| EPMConfig.xml | Overrides of EPM topology cells/chains/search chains. See [EPMConfig.xml](xref:EPMConfig_xml). | No |
| Hyperlinks.xml | Custom commands in Alarm Console shortcut menu. See [Hyperlinks.xml](xref:Hyperlinks_xml). | Yes |
| Info.xml | Operator info, etc. | Partially |
| LogSettings.xml | See [LogSettings.xml](xref:LogSettings_xml). | No |
| MaintenanceSettings.xml | See [MaintenanceSettings.xml](xref:MaintenanceSettings_xml). | Partially |
| NotifyMail.html | Email notification template | No |
| OEM.xml | Optional file used for co-branding | No |
| PropertyConfiguration.xml | See [PropertyConfiguration.xml](xref:PropertyConfiguration_xml). | Yes |
| PWD.lic | No longer used. | No |
| Request.lic | Request file for offline demo license. | No |
| Response.lic | Response file for offline demo license. | No |
| Schedule.xml | Configuration of scheduled tasks. | No |
| Security.xml | Security configuration (groups and users). | Yes |
| SLCloud.xml | See [SLCloud.xml](xref:SLCloud_xml) | No |
| SNMP Managers.xml | See [SNMP Managers.xml](xref:SNMP_Managers_xml). | Partially |
| SoftlaunchOptions.xml | This file is not present by default, but can be added manually to activate specific soft-launch options.<br> See [Soft-launch options](xref:SoftLaunchOptions). | No |
| SpectrumMonitors.xml | Monitors for a specific DataMiner/element. | No |
| Spectrum.xml | Scripts, Globals. | Yes |
| StartupDataMiner.bat | Batch file executed at startup. | No |
| SyncRules.xml | Synchronization rules that can prevent file synchronization between DMAs running different versions of DataMiner. See [SyncRules.xml](xref:SyncRules_xml). | Yes |
| videoservers.xml | Configuration of video servers (for video thumbnails). | No |
| Views.xml | View configuration. | Yes |

> [!NOTE]
>
> - Files marked as “synchronized” in the rightmost column are synchronized among all DMAs in the cluster every day at midnight (00:00). Therefore, it is of great importance that the time settings of all DMAs in the cluster are synchronized as well. For more information, see [How do I synchronize time settings within a DMS?](xref:General_configuration#how-do-i-synchronize-time-settings-within-a-dms).
> - From DataMiner 9.5.9 onwards, *DBMaintenance.xml* and *DBMaintenanceDMS.xml* have been moved to the Database subfolder, along with a number of other database-related files.
