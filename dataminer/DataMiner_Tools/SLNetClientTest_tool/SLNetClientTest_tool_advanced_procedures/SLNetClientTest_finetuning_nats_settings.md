---
uid: SLNetClientTest_finetuning_nats_settings
---

# Fine-tuning NATS settings

From DataMiner 10.1.0/10.1.1 onwards, DataMiner processes use the NATS open-source messaging system to communicate with each other. From DataMiner 10.1.0/10.1.3 onwards, you can check and fine-tune the settings for this in the SLNetClientTest tool.

To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Depending on what you want to check or configure, select one of the following options in the drop-down box at the top of the window:

   - *NATSDisasterCheck*: If this is set to true, automatic detection and triggering of NATS cluster self-healing is activated (default: false).

   - *NATSResetWindow*: A value in seconds representing the time window during which only one NATS reset can occur. This prevents situations where NATS disaster recovery is triggered too often. The minimum value is 60.

   - *NATSRestartTimeout*: The maximum time (in seconds) to wait for NATS to restart (default: 10). A NATS restart can for example be necessary when an Agent goes offline or is removed from the DMS.

1. To modify the setting, right-click it in the table and select *Edit Value*.

1. Specify the new value and click *OK*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
