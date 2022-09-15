---
uid: SLNetClientTest_changing_number_records_protocol_cache
---

# Changing the number of records in the protocol cache

From DataMiner 10.0.11 onwards, you can customize how many records can be contained in the protocol cache. This can be useful to tweak the performance of a DMA. However, **always check with Skyline** before you make any changes to this setting, as an **incorrect configuration can cause serious issues**.

To change this setting:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Select *protocolCacheMru* in the drop-down box at the top of the pop-up window.

1. Right-click the current value and select *Edit Value*.

1. Specify the new value in the pop-up window and click OK.

1. Click OK again to close the *SLNet Options* window.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
