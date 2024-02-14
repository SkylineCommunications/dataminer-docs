---
uid: DM_and_storage_selfhosted
---

# Self-hosted DataMiner nodes and storage nodes

It is possible to host DataMiner yourself. This can be on premises, in a private cloud, or hybrid, or you could also decide to run it in a public cloud.

The DataMiner System Center provides a complete overview for setup and maintenance of a DataMiner System, with an intuitive UI to manage the users, user groups, access rights, and size of the database, to read and flush log files, etc. System Center is also the place where the administrator can configure the DataMiner redundancy settings (i.e. high-availability or Failover nodes), and it includes an upgrade center to easily trigger a software update, regardless of the number of DataMiner nodes.

In terms of **redundancy**, each DMA (DataMiner node) in a DataMiner System can be teamed up with a dedicated backup DMA. Within a DMA redundancy team, the backup DMA will continuously be synchronized so that, at all times, it is ready to take over from its team member the moment that one fails. When you team up a particular DataMiner node with a backup DMA, a virtual DMA team will be created. Within a DMA team, the two team members will act as peers. In other words, they will not act as master DMA versus slave DMA, but as active DMA versus passive DMA.

By default, all synchronization traffic between the active and the passive team member will pass via the corporate network. If necessary, both team members can also be equipped with an additional network card to be used for synchronization traffic only.

The decision when to switch from the active to the passive DMA can be taken either by a person (i.e. manual Failover) or by the DMAs themselves (i.e. automatic Failover). In the latter case, the two DMAs in the team will check each other’s status by exchanging heartbeats.

> [!TIP]
> See also: [Failover User Guide](xref:failover)

In terms of **backup and restore**, DataMiner nodes require a one-time configuration by the administrator in order to fully automatically take care of backups. The administrator can choose:

- When the DMAs need to take a backup (e.g. every 24 hours at 01:00 AM).
- What kind of information needs to be included in those backups (configuration, core software, connectors, historical alarms, etc.).
- How many backups to maintain (e.g. 7 backups, with a backup taken every 24 hours, so that you can always go back one week).
- Where to store the backup file. The backup file can be stored locally on the DMA (e.g. on a second hard drive), but it can also be stored on a secured network drive on a file server.

A default DataMiner System also comes with a set of features and capabilities that increase the availability and that enable proactive maintenance and support. This includes for example:

- Automatic and user-definable reboot procedure.
- Generic watchdog strategy.
- Automatic collection and email forwarding of fault and logging information.
- Automated backup.
- Scheduled email health reporting.
- Self-maintaining database with user-definable settings.
- Etc.

From a storage point of view, each DataMiner System requires its own system data storage. This data storage serves as a repository for configuration data, historical parameter information, and alarm data. It is possible to configure a dedicated clustered storage setup, using a Cassandra-compatible database service and an indexing database (i.e. a Search Cluster).

DataMiner supports a Cassandra and OpenSearch (or Elasticsearch) database for system data storage. Other data storage solutions can be added optionally, for example to offload data from the DataMiner System and to make it available for third-party systems.

These databases can be run on premises, in a private cloud, hybrid, or in a public cloud. Cassandra and OpenSearch/Elasticsearch clustering capabilities are supported.

> [!TIP]
> See also: [Dedicated clustered storage](xref:Dedicated_clustered_storage)
