---
uid: SLNetClientTest_disabling_automatic_nats_config
---

# Disabling automatic NATS configuration

From DataMiner 10.2.0 \[CU6]/10.2.8, you can enable the *NATSForceManualConfig* option so that NATS is not automatically configured in your DataMiner System. When you do so, you will need to either configure a NATS cluster manually instead, or manually call the *NatsCustodianResetNatsMessage* when changes are made to the DMS (see [Try a NATS reset](xref:Investigating_NATS_Issues#try-a-nats-reset)).

To disable automatic NATS configuration:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *NATSForceManualConfig*.

1. Configure the option as follows for each DMA in the cluster:

   1. Right-click the DMA and select *Edit value*.

   1. Specify *true* and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

> [!CAUTION]
> When enabling the *NATSForceManualConfig* option, it is the user's responsibility to maintain the configuration of the SLCloud.xml, nas.config, and nats-server.config files, as well as ensure synchronization of the credentials in the system.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
