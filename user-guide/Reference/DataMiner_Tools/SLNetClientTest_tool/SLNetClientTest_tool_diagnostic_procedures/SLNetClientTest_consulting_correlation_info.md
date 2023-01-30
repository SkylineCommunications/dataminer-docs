---
uid: SLNetClientTest_consulting_correlation_info
---

# Consulting Correlation information

The SLNetClientTest tool provides several functions to get more information about Correlation on a DMA.

To consult information about the Correlation engine, do the following:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *Correlation* > *CubeCorrelationStats.*

1. Double-click the new message that appears in the *Properties* tab of the main window, or select the message and check the *Text* pane on the right.

   The message will among others contain the stack size, a list of remote subscriptions from other Agents in the cluster, the last known remote Agent states (connected or disconnected), and some counters about the number of forwarded events between Agents.

To consult information about the Correlation rules of a DMA:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Advanced* menu, select *Correlation* > *Rule Status*.

   This opens the *Correlation Rule Status* window, which has several options:

   - To view disabled rules, clear the selection from *Hide Disabled*. Disabled rules will then be shown in gray.

   - To view remote rules, clear the selection from *Hide Remote*.

   - To view internal system rules, clear the selection from *Hide System*.

   - To automatically refresh the rule status, select *Auto Refresh* and specify a refresh interval (default: 5 seconds).

   The window lists the DMA handling each rule, buckets, sliding window status, etc. The context menu of the entries in the *Buckets* pane provides access to more detailed info.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
