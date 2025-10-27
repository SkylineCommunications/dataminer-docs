---
uid: EPMIntegration_Agent_cache_config
---

# Agent caching configuration

Typically, when an exposed topology item is requested, every Agent in the cluster is requested to verify whether it contains data for that topology item, while typically only two to three Agents will actually contain that item. In a cluster with many Agents, this increases unnecessary remote calls and adds an unnecessary load on the Agents.

In such a case, from DataMiner 10.4.0 [CU14]/10.5.0 [CU2]/10.5.5 onwards<!-- RN 42221+26232 -->, you can make an Agent store a full cache of where topology items are stored in the cluster, so that when this Agent (or an Agent connected to this Agent) receives a request for a topology item, only the Agents actually containing the data for the item will need to be contacted.

There is no limit as to how many Agents can hold such a cache, but keep in mind that depending on how many topology items are exposed in the system, this may increase the memory footprint of SLNet, and it will also add some extra syncing between Agents and forwarding of data from SLElement to SLNet when provisioning occurs.

This configuration will be stored in the *TopologyItemHostingCacheState* element of *DataMiner.xml*, for example:

```xml
<DataMiner>
...
   <TopologyItemHostingCacheState>true</TopologyItemHostingCacheState>
...
</DataMiner>
```

To enable or disable this cache:

1. Open SLNetClientTest tool from the DataMiner Taskbar Utility by selecting *Launch* > *Tools* > *Client Test*.

1. Connect to the DataMiner Agent by selecting *Connection* > *Connect*.

1. Select *Advanced* > *CPE* > *TopologyItemHostingCache*.

   This will open a window listing the Agents in the DataMiner System.

1. Right-click an Agent in the list and select *Enable Cache* or *Disable Cache*.

> [!NOTE]
> In the same window, you can also check whether all caches are in sync using the *Lookup* pane. If you specify a System Type and System Name in this pane and then click *Search*, you will get an overview of where the specified object can be found. If it is not included in every one of the caches, an error will be displayed.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.
