---
uid: DM_selfhosted_and_StaaS
description: DataMiner Storage as a Service (STaaS) provides hassle-free database storage for your self-managed DataMiner nodes.
---

# Self-managed DataMiner nodes with Storage as a Service (STaaS)

If you choose to [manage the DataMiner nodes yourself](#self-managed-dataminer-nodes), you can host them on premises, in a private cloud, or in a hybrid setup, or you could also decide to run them in a public cloud. Different license models are available. You can make use of [usage-based services or perpetual-use licensing](xref:Pricing_Commercial_Models), depending on which model best suits your business models and strategy.

[DataMiner Storage as a Service (STaaS)](#storage-as-a-service-staas) provides hassle-free database storage for your self-managed DataMiner nodes. By connecting your DataMiner System to the scalable and user-friendly cloud-native storage platform, you will be able to save on infrastructure and IT maintenance costs, as storage will be fully managed for you. You will not need to estimate your storage requirements in advance, place specific VM orders, or configure complex data storage clusters with the necessary replication and backup. Instead, everything is done automatically.

## Self-managed DataMiner nodes

To set up and maintain your DataMiner System, you can make use of the DataMiner **System Center** in DataMiner Cube. This provides an intuitive UI to manage DataMiner nodes, users, log files, and so on. System Center is also the place where the administrator can configure the DataMiner redundancy settings (i.e., high-availability or Failover nodes), and it includes an upgrade center to easily trigger a software update, regardless of the number of DataMiner nodes.

In terms of **redundancy**, each DMA (DataMiner node) in a DataMiner System can be teamed up with a dedicated backup DMA in a so-called [Failover setup](xref:failover). Within a DMA redundancy team, the backup DMA will continuously be synchronized so that, at all times, it is ready to take over from its team member the moment that one fails. When you team up a particular DataMiner node with a backup DMA, a virtual DMA team will be created. Within a DMA team, the two team members will act as peers. In other words, they will not act as master DMA versus slave DMA, but as active DMA versus passive DMA.

By default, all synchronization traffic between the active and the passive team member will pass via the corporate network. If necessary, both team members can also be equipped with an additional network card to be used for synchronization traffic only.

The decision when to switch from the active to the passive DMA can be taken either by a person (i.e., manual Failover) or by the DMAs themselves (i.e., automatic Failover). In the latter case, the two DMAs in the team will check each other’s status by exchanging heartbeats.

In terms of **backup and restore**, DataMiner nodes require a [one-time configuration by the administrator](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube#configuring-the-dataminer-backups) in order to fully automatically take care of backups. The administrator can choose:

- When the DMAs need to take a backup (e.g., every 24 hours at 01:00 AM).
- What kind of information needs to be included in those backups (configuration, core software, connectors, files, etc.).
- How many backups to maintain (e.g., 7 backups, with a backup taken every 24 hours, so that you can always go back one week).
- Where to store the backup file. The backup file can be stored locally on the DMA (e.g., on a second hard drive), but it can also be stored on a secured network drive on a file server.

A default DataMiner System also comes with a set of features and capabilities that increase the availability and that enable proactive maintenance and support. This includes for example:

- [Proactive support](xref:Proactive_Support) via dataminer.services.
- Automatic collection and email forwarding of fault and logging information.
- Automated backups.
- Scheduled email health reporting.
- Etc.

## Storage as a Service (STaaS)

With Storage as a Service, you can connect your DataMiner System to a scalable and easy-to-use storage platform, without the effort of setting up and managing your own data storage cluster. While your DataMiner nodes remain self-managed, and you can use our redundancy/high-availability capabilities on these nodes, but we take care of the database nodes and redundancy implementation.

Enjoy fast, secure, and reliable storage with STaaS:

- Effortless storage management: No need to mess around with storage clusters or VMs.
- Easy installation: Installed in just a few clicks.
- High scalability: Start small and grow as you go.
- Cost-effective: Only pay for what you use.
- Fast, secure, and reliable: Learn more about how we keep dataminer.services safe and secure.

*Grow as you go*

The service is powered by Microsoft Azure’s cloud-native storage solutions, such as Cosmos DB, which offer outstanding performance, scalability, and redundancy. This means that you can start small and easily evolve without any extra effort.

*Easy & flexible configuration*

Our development team has worked tirelessly to ensure all data types are added to the most suitable cloud-native storage provided by Microsoft Azure. And while all of this is being tested and validated rigorously, they are now working on migration options for existing systems and ensuring easy and flexible configuration.

*Pay as you go*

In addition to streamlining your entire workflow, DataMiner STaaS is also extremely cost-effective. You only pay for the storage you are using, making it a great solution for businesses of all sizes.

*Safe & secure*

With DataMiner STaaS, you can rest assured that your data is safe and secure. All data is encrypted with 256-bit AES encryption, which is the default in Azure. We also understand that data sovereignty is crucial to our users, so we offer the option to choose where your data is stored.

> [!TIP]
> See also:
>
> - [DataMiner STaaS: shifting the responsibility and financial burden of managing data storage infrastructure and technology to a highly professional cloud provider](https://community.dataminer.services/storage-as-a-service/)
> - [DataMiner STaaS: a game-changer for your storage needs](https://community.dataminer.services/dataminer-staas-a-game-changer-for-your-storage-needs/)
> - [Storage as a Service (STaaS)](xref:STaaS)
