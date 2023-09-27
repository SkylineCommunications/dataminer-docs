---
uid: SLNetClientTest_finetuning_CPECollectorHelper
---

# Fine-tuning the CPECollectorHelper API timeout

When a call is performed via the CPECollectorHelper API, a timeout is calculated that is scaled based on how many items are requested. This way, the timeout time is dynamically adjusted to the number of requested items. This is calculated based on the following formula:

`Total Timeout = ((requested number of items / EPMBulkCount) + 1) * EPMASyncTimeout`

From DataMiner 10.0.9 onwards, you can fine-tune how the timeout is calculated using the SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Depending on what you want to configure, select one of the following options in the drop-down box at the top of the window:

   - *EPMAsyncTimeout*: The base value for a timeout when the CPE collector contacts another DataMiner Agent.

   - *EPMBulkCount*: The maximum number of items that can be requested in bulk before the timeout is increased.

1. Right-click the setting in the table and select *Edit Value*.

1. Specify the new value and click *OK*.

> [!CAUTION]
> Be careful when changing these values, as an incorrect configuration can lead to problems with EPM. If the EPMAsyncTimeout is too low, it can occur that not all data is displayed in the EPM elements, but it if it is too high, the system may become unresponsive. The inverse is the case for the EPMBulkCount.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
