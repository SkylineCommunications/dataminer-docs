---
uid: SLNetClientTest_configuring_how_long_alarm_statistics
---

# Configuring how long alarm statistics are kept in memory

The SLNetClientTest tool allows you to determine the time range of the alarm statistics to keep in memory, as well as the amount of time that requested time ranges other than the most recent one will stay in memory.

To configure the time range that the most recent active alarms will be kept in memory:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *ActiveAlarmStatsTimeToKeep*.

   A list of the Agents in the cluster will be displayed, indicating for each of them how long the alarm statistics are kept (in days). The default time is 2 days.

1. In the *Value* column, right-click the value you want to update, and select *Edit value*.

1. Enter the new number of days and click *OK*.

To configure how long time ranges other than the most recent one will be kept in memory after they have been requested:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *ActiveAlarmStatsExpirationTime*.

   A list of the Agents in the cluster will be displayed, indicating for each of them how long the time ranges are kept (in minutes). The default time is 10 minutes.

1. In the *Value* column, right-click the value you want to update, and select *Edit value*.

1. Enter the new number of minutes and click *OK*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
