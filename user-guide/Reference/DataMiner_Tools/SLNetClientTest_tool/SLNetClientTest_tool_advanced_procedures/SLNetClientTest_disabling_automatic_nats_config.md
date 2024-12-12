---
uid: SLNetClientTest_disabling_automatic_nats_config
---

# Disabling automatic NATS configuration

From DataMiner 10.2.0 [CU6]/10.2.8 onwards, you can enable the *NATSForceManualConfig* option so that NATS is not automatically configured in your DataMiner System. When you do so, you will need to either configure a NATS cluster manually instead, or manually call the *NatsCustodianResetNatsMessage* when changes are made to the DMS (see [Try a NATS reset](xref:Investigating_NATS_Issues#try-a-nats-reset)).

> [!CAUTION]
> If you disable automatic NATS configuration, this means you become responsible for maintaining the configuration of the [*SLCloud.xml*](xref:SLCloud_xml), [*nas.config*](xref:Investigating_NATS_Issues#nasconfig), and [*nats-server.config*](xref:Investigating_NATS_Issues#nats-serverconfig) files as well as ensuring the synchronization of the credentials in the system. From DataMiner 10.3.11/10.3.0 [CU8] onwards<!--RN 37401-->, when DataMiner makes changes to any of these files, the old version of that file is saved in the *C:\Skyline DataMiner\Recycle Bin* folder.

To disable automatic NATS configuration:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *NATSForceManualConfig*.

1. Configure the option as follows for each DMA in the cluster:

   1. Right-click the DMA and select *Edit value*.

   1. Specify *true* and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

> [!NOTE]
> Changes to the *NATSForceManualConfig* option are included in a DataMiner backup to make sure that the automatic NATS configuration status remains consistent after a backup is restored. From DataMiner 10.4.11/10.5.0 onwards<!--RN 40812-->, any changes made to the *nats-server.config* file after disabling automatic NATS configuration will also be included in DataMiner backups. Prior to this, you need to manually back up the *nats-server.config* file, located in the `C:\Skyline DataMiner\NATS\nats-streaming-server\` folder. See [nats-server.config file not included in DataMiner backups](xref:KI_nats-server_config_file_not_included_in_backups).
