---
uid: About_DataMiner_Systems
---

# About DataMiner clusters

A DataMiner cluster, also called a DataMiner System (DMS), is a collection of DataMiner Agents interconnected via a TCP/IP network.

A cluster makes the system appear as a single entity to the user and minimizes repetitive tasks. In DataMiner Cube, you can [view information on all individual nodes](xref:Viewing_information_on_the_DMAs_in_a_DMS) you have [added to your cluster](xref:Adding_a_DataMiner_Agent_to_a_DataMiner_System).

When you [set up a multi-node cluster](xref:Before_you_begin_to_set_up_a_new_DMS), you need to decide whether you want to use the recommended [DataMiner Storage as a Service](xref:STaaS) or host the DataMiner storage nodes yourself. This second option is not recommended and is not supported for [hybrid setups](xref:TBD) where DaaS nodes are combined with self-hosted nodes. If you choose to use this option, you will need to set up the necessary [data storage nodes](xref:About_storage) yourself.
