---
uid: Adding_a_DataMiner_Agent_to_a_DataMiner_System
---

# Adding a DataMiner Agent to a DataMiner System

The procedure to add a node to a DataMiner System can be different depending on the type of node and on the DMS setup:

- [Adding a regular DataMiner Agent](xref:Adding_a_regular_DataMiner_Agent)

- [Adding a DataMiner Agent to a DMS running STaaS](xref:Adding_a_DMA_to_a_DMS_running_STaaS)

- [Adding a DataMiner Probe](xref:Adding_a_DataMiner_Probe)

Please also note the following:

- The DataMiner Agent you add must use the same NATS solution as the DataMiner System. This means that if the DMS has been [migrated to BrokerGateway](xref:BrokerGateway_Migration), the DMA you add also needs to be migrated to BrokerGateway, but if the DMS still uses the SLNet-managed NATS solution, the DMA you add also has to use this solution.

- If a [manual configuration was forced for NATS](xref:Disabling_automatic_NATS_config) with the *NATSForceManualConfig* option in *MaintenanceSettings.xml*, you will need to manually adjust your NATS configuration with the added DMA.<!-- RN 42019+42020 -->

- In most cases, when you add a DataMiner Agent to a DataMiner System, all other DataMiner Agents in the DataMiner System will connect to it using its primary IP address. However, in some cases, you may need to configure the connection strings by hand. See [Connection strings](xref:Connection_strings).

- From DataMiner 10.6.2/10.7.0 onwards<!--RN 44171-->, adding a DataMiner Agent will fail in the following cases:

  - The DataMiner Agent is cloud-connected, but the DataMiner System is not.

  - The DataMiner Agent and the DataMiner System are cloud-connected, but they do not have the same identity (i.e. they are not part of the same cloud-connected system).

  - If the DataMiner System is a STaaS system, the operation will also fail if the DataMiner Agent is not cloud-connected.  

> [!WARNING]
>
> - If you add a DataMiner Agent to a DataMiner System, please make sure that it is a **new DataMiner Agent** that has not yet been put into use and that uses the **same software version** as the other Agents in the system.
> - When you add more than one DataMiner Agent, add them one at a time and wait until each Agent is synchronized with the cluster (indicated by an information event with parameter description "Synchronization finished") before adding another Agent.

> [!TIP]
> See also: [Setting up a new DataMiner System](xref:Before_you_begin_to_set_up_a_new_DMS).
