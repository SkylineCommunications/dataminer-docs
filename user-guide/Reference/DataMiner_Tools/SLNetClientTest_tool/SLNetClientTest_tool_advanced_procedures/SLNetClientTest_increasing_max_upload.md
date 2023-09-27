---
uid: SLNetClientTest_increasing_max_upload
---

# Increasing the maximum upload size for upgrade packages in a DMS

The default maximum upload size of upgrade packages depends on the DataMiner version:

- Prior to 9.0.0, this is 200 MB.

- From DataMiner 9.0.0 up to DataMiner 10.0.2, this is 500 MB.

- From DataMiner 10.0.3 onwards, this is 4000 MB.

However, it is also possible to increase the maximum upload size via the SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, go to *Options* > *SLNet Options.*

1. In the drop-down list next to *Option values for*, select *MaxUploadSize*.

1. Right-click the indicated value for this setting, and select *Edit value*.

1. Enter a new value and click *OK*.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
