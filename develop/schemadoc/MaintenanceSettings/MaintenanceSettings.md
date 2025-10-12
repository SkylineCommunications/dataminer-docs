---
uid: MaintenanceSettings
---

# MaintenanceSettings element

Configures general system settings.

## Children

| Name | Occurrences | Description |
| --- | --- | --- |
| All |  |  |
| &#160;&#160;[Aggregation](xref:MaintenanceSettings.Aggregation) | [0, 1] | Configures aggregation related settings. |
| &#160;&#160;[AlarmSettings](xref:MaintenanceSettings.AlarmSettings) | [0, 1] | Configures how timeout alarms are visualized in Microsoft Visio shapes. |
| &#160;&#160;[AutoElementLock](xref:MaintenanceSettings.AutoElementLock) | [0, 1] | When set to "true", an element will automatically be locked when a parameter set is performed on it by a user who is allowed to lock and unlock elements. |
| &#160;&#160;[BrokerGateway](xref:MaintenanceSettings.BrokerGateway) | [0, 1] | Specifies whether the BrokerGateway-managed NATS solution (nats-server service) is used instead of the SLNet-managed NATS solution (NAS and NATS services). |
| &#160;&#160;[Correlation](xref:MaintenanceSettings.Correlation) | [0, 1] | Configures correlation-related settings. |
| &#160;&#160;[DeltCache](xref:MaintenanceSettings.DeltCache) | [0, 1] | Configures the cleanup instructions for the `C:\Skyline DataMiner\System Cache\DELT\` folder. Every time a .dmimport package is exported from or imported onto a DataMiner Agent, it is stored in this folder. By default, the 20 most recent packages are kept. |
| &#160;&#160;[DELTUpgrades](xref:MaintenanceSettings.DELTUpgrades) | [0, 1] | Configures the automatic cleanup of DELT-related packages in the folder C:\Skyline DataMiner\Upgrades\. |
| &#160;&#160;[DMSRevision](xref:MaintenanceSettings.DMSRevision) | [0, 1] | Specifies when a double check has to be done. You can specify as many starting times as you want. |
| &#160;&#160;[Documents](xref:MaintenanceSettings.Documents) | [0, 1] | Configures settings regarding documents in the Documents module. |
| &#160;&#160;[Filtering](xref:MaintenanceSettings.Filtering) | [0, 1] | Configures filtering. |
| &#160;&#160;[HTTPS](xref:MaintenanceSettings.HTTPS) | [0, 1] | Configures DataMiner to use HTTPS. For more information, refer to [Configuring HTTPS settings in DataMiner](xref:Setting_up_HTTPS_on_a_DMA#configuring-https-in-dataminer) |
| &#160;&#160;[Logging](xref:MaintenanceSettings.Logging) | [0, 1] | Configures logging. |
| &#160;&#160;[NATSForceManualConfig](xref:MaintenanceSettings.NATSForceManualConfig) | [0, 1] | When set to "true", disables the automatic reset timer in NATSCustodian. |
| &#160;&#160;[Network](xref:MaintenanceSettings.Network) | [0, 1] | Configures network related settings. |
| &#160;&#160;[ProtocolSettings](xref:MaintenanceSettings.ProtocolSettings) | [0, 1] | Configures protocol-related settings. |
| &#160;&#160;[RecycleBinSize](xref:MaintenanceSettings.RecycleBinSize) | [0, 1] | Specifies the maximum size (in MB) of the DataMiner recycle bin. |
| &#160;&#160;[Replication](xref:MaintenanceSettings.Replication) | [0, 1] | Configures replication related settings. |
| &#160;&#160;[SLASPConnection](xref:MaintenanceSettings.SLASPConnection) | [0, 1] |  |
| &#160;&#160;[SLNet](xref:MaintenanceSettings.SLNet) | [0, 1] | Specifies a number of settings of the SLNet application. |
| &#160;&#160;[Spectrum](xref:MaintenanceSettings.Spectrum) | [0, 1] | Configures settings related to spectrum analyzers. |
| &#160;&#160;[Surveyor](xref:MaintenanceSettings.Surveyor) | [0, 1] | Specifies which statistical alarm data and/or ticket data you want to have displayed next to elements, services and views in the Surveyor. |
| &#160;&#160;[Trending](xref:MaintenanceSettings.Trending) | [0, 1] | Specifies settings related to trending. |
| &#160;&#160;[WatchDog](xref:MaintenanceSettings.WatchDog) | [0, 1] | Configures the watchdog process SLWatchdog. |
