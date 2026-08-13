---
uid: Adding_a_DataMiner_Agent_to_a_DataMiner_System
description: "Learn what is needed to add a node to a DataMiner cluster, whether the node is a regular DataMiner Agent or a DataMiner Probe."
---

# Adding a node to a DataMiner cluster

The procedure to add a node in a DataMiner cluster can be different depending on the type of node and on the cluster setup:

- [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent)

- [Adding a node to a cluster running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS)

- [Adding a DataMiner Probe](xref:Adding_a_DataMiner_Probe)

In each case, the [prerequisites](#prerequisites) below apply.

## Prerequisites

### General

- When you add a node to a cluster, make sure that it is a **new DataMiner Agent** that has not yet been put into use. If you do want to add a previously used DataMiner Agent as a node in a , make sure it has been **fully cleaned** via the [Factory Reset Tool](xref:Factory_reset_tool).

- If you intend to add **more than one** node:

  - Add the nodes **one at a time** and wait until each node is synchronized with the cluster (indicated by an information event with parameter description "Synchronization finished") before adding another node.
  - Make sure each node you add uses the **same software version** as the other nodes in the system.

### Network

- Before you add a node, make sure the [IP network ports](xref:Configuring_the_IP_network_ports) are configured correctly and [connection strings](xref:Connection_strings) are configured if necessary.

- If you are running a DataMiner version lower than 10.4.0 [CU16]/10.5.0 [CU4]/10.4.7, also make sure the machine where you are running Cube can access the new node over the IP that is used for adding it, even when connection strings are used.

### Connection to dataminer.services

- From DataMiner 10.6.2/10.7.0 onwards<!--RN 44171-->:

  - To add a DataMiner Agent that is connected to dataminer.services, the cluster also has to be connected to dataminer.services.
  - Before you add a DataMiner Agent to a STaaS system, make sure that Agent is connected to dataminer.services.
