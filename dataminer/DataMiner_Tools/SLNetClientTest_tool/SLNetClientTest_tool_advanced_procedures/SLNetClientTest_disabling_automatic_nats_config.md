---
uid: SLNetClientTest_disabling_automatic_nats_config
---

# Disabling automatic NATS configuration

From DataMiner 10.2.0 [CU6]/10.2.8 onwards, you can enable the *NATSForceManualConfig* option so that NATS is not automatically configured in your DataMiner System. When you do so, you will need to configure a NATS cluster manually. There are two distinct methods to enable *NATSForceManualConfig*:

- For all DMAs in the cluster [via SLNetClientTestTool](#disabling-automatic-nats-configuration-via-slnetclienttesttool) (recommended).
- For one DMA at a time [by changing *MaintenanceSettings.xml*](#disabling-automatic-nats-configuration-via-maintenancesettingsxml).

> [!IMPORTANT]
> Automatic NATS configuration must either be consistently enabled in the entire cluster or disabled in the entire cluster. You cannot have part of the cluster rely on automatic NATS configuration and the other part on manual configuration.

> [!CAUTION]
> If you disable automatic NATS configuration, this means **you become responsible for maintaining the configuration** of the [*SLCloud.xml*](xref:SLCloud_xml), [*nas.config*](xref:Investigating_NATS_Issues#nasconfig), and [*nats-server.config*](xref:Investigating_NATS_Issues#nats-serverconfig) files as well as ensuring the synchronization of the credentials in the system. From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37401-->, when DataMiner makes changes to any of these files, the old version of that file is saved in the `C:\Skyline DataMiner\Recycle Bin`folder.

> [!NOTE]
> Changes to the *NATSForceManualConfig* option are included in a DataMiner backup to make sure that the automatic NATS configuration status remains consistent after a backup is restored. From DataMiner 10.4.11/10.5.0 onwards<!--RN 40812-->, any changes made to the *nats-server.config* file after disabling automatic NATS configuration will also be included in DataMiner backups. Prior to this, you need to manually back up the *nats-server.config* file, located in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder. See [nats-server.config file not included in DataMiner backups](xref:KI_nats-server_config_file_not_included_in_backups).

## Disabling automatic NATS configuration via SLNetClientTestTool

To disable automatic NATS configuration for the entire cluster in one go:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *NATSForceManualConfig*.

1. Configure the option as follows for each DMA in the cluster:

   1. Right-click the DMA and select *Edit value*.

   1. Specify *true* and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

The entire cluster should now be configured, **except for offline Failover Agents**. In case you are configuring a DMS with Failover, also configure the offline Agents one by one by [changing *MaintenanceSettings.xml*](#disabling-automatic-nats-configuration-via-maintenancesettingsxml)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

## Disabling automatic NATS configuration via MaintenanceSettings.xml

To disable the automatic NATS configuration one Agent at a time (or on offline Agents of a Failover pair):

1. Stop the DataMiner Agent in question.

1. Navigate to `C:\Skyline DataMiner\MaintenanceSettings.xml` and add the *NATSForceManualConfig* tag within the *SLNet* tag.

   Create the SLNet tag if it does not exist yet.

   ```xml
   <SLNet>
   <NATSForceManualConfig>true</NATSForceManualConfig>
   </SLNet>
   ```

1. Start DataMiner.

1. Repeat this process for every Agent in the cluster (or every offline Failover Agent in the DMS in case you have already disabled automatic NATS configuration for the other Agents using SLNetClientTestTool).
