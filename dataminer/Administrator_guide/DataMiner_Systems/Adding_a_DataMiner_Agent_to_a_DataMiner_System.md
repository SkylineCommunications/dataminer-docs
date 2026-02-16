---
uid: Adding_a_DataMiner_Agent_to_a_DataMiner_System
---

# Adding a DataMiner Agent to a DataMiner System

The procedure to add a node to a DataMiner System can be different depending on the type of node and on the DMS setup:

- [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent)

- [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS)

- [Adding a DataMiner Probe](xref:Adding_a_DataMiner_Probe)


## Prerequisites

Please also note the following prerequisites:

### General

- When adding a DataMiner Agent to a DataMiner System, please make sure that it is a **new DataMiner Agent** that has not yet been put into use.
- When adding a previously used DataMiner Agent to a DataMiner System, please make sure it has been **fully cleaned** via the [Factory Reset Tool](xref:Factory_reset_tool).
- When adding **more than one** DataMiner Agent, add them **one at a time** and wait until each Agent is synchronized with the cluster (indicated by an information event with parameter description "Synchronization finished") before adding another Agent.
- Ensure the DataMiner Agents being added use the **same software version** as the other Agents in the system.

### Network

- Before you add a DataMiner Agent, make sure the [IP network ports](xref:Configuring_the_IP_network_ports) are configured correctly and [connection strings](xref:Connection_strings) are configured if necessary.
- If you are running a DataMiner version lower than 10.4.0 [CU16]/10.5.0 [CU4]/10.4.7, also make sure the machine where you are running Cube can access the new Agent over the IP that is used for adding it, even when connection strings are used.

### Cloud

- From DataMiner 10.6.2/10.7.0 onwards<!--RN 44171-->, adding a DataMiner Agent will fail in the following cases:

  - The DataMiner Agent is connected to dataminer.services, but the DataMiner System is not.

  - If the DataMiner System is a STaaS system, the operation will also fail if the DataMiner Agent is not connected to dataminer.services.  



> [!TIP]
> See also: [Setting up a new DataMiner System](xref:Before_you_begin_to_set_up_a_new_DMS).
