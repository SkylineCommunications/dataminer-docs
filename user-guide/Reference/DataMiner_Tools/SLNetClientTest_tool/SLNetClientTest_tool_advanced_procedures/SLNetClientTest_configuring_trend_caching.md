---
uid: SLNetClientTest_configuring_trend_caching
---

# Configuring trend caching

Data for trend data queries is cached in the SLNet process after it has been received from SLDataGateway, and before it is processed further. This speeds up e.g. switching a trend graph's range from last day to last week, closing a trending card and opening it again shortly afterwards, opening the same trend graph on multiple clients, etc. In the SLNetClientTest tool, several options are available related to the trend cache.

Most of the trend cache options can be configured as follows:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down list at the top of the window, select an option and then configure it using the right-click menu in the pane below.

   The following options are available:

   - *TrendCacheEnable*: Can be set to "true" or "false" in order to enable or disable trend caching.
   - *TrendCacheExpirationTime*: A value in seconds (by default 120 seconds). Determines how long an entry remains in the cache.
   - *TrendCacheLogVerbose*: Can be set to "true" or "false" in order to enable or disable additional logging in the *SLNet.txt* log file, indicating whether a trend data request was resolved from the database or from the cache.
   - *TrendCacheMaxRecordsInCache*: The maximum number of trend records in the cache, by default 1000000. Older entries will be removed to make room for new entries.

   > [!NOTE]
   > These options are not synchronized among the Agents in a DMS.

In addition, if you go to *Diagnostics* > *Caches & Subscriptions* > *Trend Cache*, you can also:

- Select *Stats* or *List Contents* to view more information on the trend cache.

- Select *Clear Cache* to clear the trend cache.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
