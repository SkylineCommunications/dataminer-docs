---
uid: SLNetClientTest_having_rca_chains_updated
---

# Having RCA chains updated by the DCF engine

You can make the DataMiner Connectivity Framework Engine update RCA chains automatically. To do so:

1. [Connect to the DMA using the SLNetClientTest tool](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool).

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *GetRCAConnectivityMessage*.

1. Configure the following fields:

   - *ActivePath*: Set this field to "true" to use property-based path highlighting, or to "false" to only take external connections into account.
   - *AutoGenerate*: Set this to "true".
   - *ChainName*: The name of the DCF chain (which specifies the *Connectivity.xml* file to be used) or the automatically generated context GUID (type = service link).
   - *ContextID*
   - *DataMinerID*: The entry point.
   - *ElementID*
   - *RCAChainName*: The name of the RCA chain.

1. Click *Send Message*.

> [!NOTE]
> A DMS Correlation license is required to be able to configure RCA chains.

> [!TIP]
> See also: [Defining connectivity chains in XML files](xref:Defining_connectivity_chains_in_XML_files)

> [!WARNING]
> Always be extremely careful when using the SLNetClientTest tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
