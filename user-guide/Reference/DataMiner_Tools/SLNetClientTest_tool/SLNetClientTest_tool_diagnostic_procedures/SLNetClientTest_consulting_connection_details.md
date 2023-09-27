---
uid: SLNetClientTest_consulting_connection_details
---

# Consulting connection details

To view connection details for a specific client or process, do the following:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *Connection details*, and then select the client or process for which you want to see the connection details.

   The detailed information will open in a separate window. It mentions among others the time when the connection was made and the time of the last activity, the number of bytes of requests, responses and events, whether the connection was made via .NET Remoting or via Web Services, and much more. From DataMiner 9.6.4 onwards, this also mentions whether protocol buffer serialization ("ProtoBuf") is enabled.

To view the number of currently active calls between different DMAs in the DMS:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. In the *Diagnostics* menu, select *Connections* > *View DMA Connections*.

   The *Agent Connections* window will be displayed. This window lists among others the number of waiting and active calls towards the DMA (“*Calls to*”) and coming in from a remote DMA (“*Calls From*”), and the number of event packets that have been received from the remote DMA but not yet processed (“*Pending Event Packs*”).

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
