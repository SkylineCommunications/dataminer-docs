---
uid: SLNetClientTest_retrieving_dcf_debug_info
---

# Retrieving DCF debug information

To get debug information on DCF connections, from DataMiner 9.0.0 CU16/9.5.3 onwards, you can send SLNet requests for DCF path highlighting with a DEBUG flag.

Responses will then contain a *DebugInfo* string with additional information on why certain connections were added and others were not. This information also includes the service context match or mismatch, the direction that was used to resolve the connections, the element path found, the top 10 most frequent connections in case of a circular dependency, and protocol links that were not applied.

This can for example be of use when an exception is thrown because a possible circular dependency is detected, as you can then use the DEBUG flag to check which path was calculated.

To retrieve DCF debug information:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select one of the following messages, depending on which information you want to retrieve:

   - *GetAlarmConnectivityMessage*

   - *GetElementConnectivityMessage*

   - *GetRCAConnectivityMessage*

   - *GetRedundancyConnectivityMessage*

   - *GetServiceConnectivityMessage*

1. Set the *Debug* field to *True*.

1. Click *Send Message*.

   In the *Properties* tab of the main window, a new message will appear with the debug information. Select the message to view the details in the *Text* pane on the right.
