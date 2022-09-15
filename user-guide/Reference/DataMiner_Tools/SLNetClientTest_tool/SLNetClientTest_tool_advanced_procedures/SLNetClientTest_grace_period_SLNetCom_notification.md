---
uid: SLNetClientTest_grace_period_SLNetCom_notification
---

# Changing the grace period for the SLNetCom Notification thread

When the SLNetCom notification thread reaches a certain threshold, DataMiner assumes something is wrong and stops processing messages. A DMA restart is then required. However, to make sure this does not happen when it is not needed in setups where the threshold is only briefly reached, there is a grace period where the DMA does not start ignoring messages for a short time (by default 1 minute). This feature is available from DataMiner 9.6.0 \[CU23\]/10.0.0\[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards.

If necessary, you can change the duration of this grace period using the SLNetClientTest tool.

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin*.

1. Right- click the DMA for which you want to edit the grace period and select *Edit value*.

1. Specify the new value and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
