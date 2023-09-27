---
uid: SLNetClientTest_protocol_buffer_serialization
---

# Enabling or disabling protocol buffer serialization

From DataMiner 9.5.10 onwards, it is possible to enable protocol buffer serialization, which can considerably increase overall DataMiner performance. This is enabled by default from DataMiner 9.5.14 onwards.

You can configure this as follows in the SLNetClientTest tool:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select one of the following messages, depending on what you want to configure:

   - *DisableProtoBufSerializationMessage*: Disables protocol buffer serialization on all open connections that have it enabled and on all future connections.

   - *EnableProtoBufSerializationMessage*: Enables server-side protocol buffer serialization. Any future connection will use protocol buffer serialization. Existing connections that are not using protocol buffer serialization will continue not using it.

   - *GetProtoBufInfoMessage*: Checks whether a connection uses protocol buffer serialization.

1. Click *Send Message*.

> [!NOTE]
> When you connect to a DMA with the SLNetClientTest tool, you can also select the attribute *NoProtoBufSerialization* in order to create a connection that does not use protocol buffer serialization.

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
