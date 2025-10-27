---
uid: SLNetClientTest_configuring_frequency_smart_baseline
---

# Configuring the frequency of smart baseline calculations

From DataMiner 10.2.7/10.3.0 onwards, you can change the frequency of smart baseline calculations using the SLNetClientTest tool.

On systems that aggregate large amounts of data from parameters with smart baselines, it can be useful to increase this frequency. By default, it is set to 5 minutes.

To change this frequency:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *SmartBaselineThreadTime*.

1. Right-click the DMA for which you want to change the setting and select *Edit value*.

1. Specify the new value and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
