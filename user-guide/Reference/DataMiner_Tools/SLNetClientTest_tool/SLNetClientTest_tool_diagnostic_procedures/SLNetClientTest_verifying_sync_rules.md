---
uid: SLNetClientTest_verifying_sync_rules
---

# Verifying sync rules

With the SLNetClientTest tool, you can check which sync rules are in effect on a DMA. To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *DMS* > *Config*.

1. Select the new message that appears in the *Properties* tab of the main window, and read the details in the *Text* pane on the right. The sync rules are listed at the bottom of the pane.

   > [!NOTE]
   >
   > - This info also lists the detected versions per DMA in the cluster. If version info for local IP addresses or Sync IP addresses is known, which is mainly for Failover Agents, there is also a section “Extra known versions.”
   > - Any DMAs running DataMiner versions prior to 8.5.5 will be considered to be running 8.0.0, as the version cannot be detected in that case.

> [!TIP]
> See also: [SyncRules.xml](xref:SyncRules_xml#syncrulesxml)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
