---
uid: Dedicated_clustered_storage
keywords: Cassandra Cluster
description: "Learn how to size and protect self-managed Cassandra and OpenSearch clusters for a DataMiner System using dedicated Linux machines."
---

# Dedicated clustered storage

> [!IMPORTANT]
> This architecture is supported but not recommended. Instead, we recommend using [Storage as a Service (STaaS)](xref:STaaS).

Dedicated clustered storage uses one Cassandra cluster and one OpenSearch cluster for the entire DataMiner System (DMS). Unlike storage per DataMiner Agent (DMA), the databases can be scaled for the DMS as a whole, independently of the number of DMAs. This architecture supports [Swarming](xref:Swarming).

Host Cassandra and OpenSearch on **dedicated Linux machines**, on premises or in a cloud environment. DataMiner itself runs on separate Windows machines. A machine can be a physical server or a virtual machine. All machines must meet the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

You are responsible for database installation, capacity, monitoring, upgrades, redundancy, and backups. For the configuration procedure, see [Configuring dedicated clustered storage](xref:Configuring_dedicated_clustered_storage).

## Single DMA setups

A one-DMA DMS still uses separate Cassandra and OpenSearch clusters. A single DMA does not provide compute redundancy, even when its storage is redundant.

![One DMA with Cassandra and OpenSearch hosted on dedicated machines](~/dataminer/images/Recommended-Setup-1.png)

For limited test, development, and staging environments, the [pre-installed DataMiner Virtual Hard Disk](xref:Using_a_pre_installed_DataMiner_Virtual_Hard_Disk) can run Cassandra and OpenSearch locally on Linux through Windows Subsystem for Linux (WSL). This is not a recommendation to install either database natively on Windows, and this setup is not intended for normal production use. See [One-box system](xref:Architecture_single_agent) for the complete architecture and alternatives using STaaS.

![Development setup with DataMiner and local databases on the same host](~/dataminer/images/Development-setup-DataMiner-Cassandra-and-OpenSearch.png)

<a id="multiple-dma-non-failover-setups"></a>

## Multiple DMA setups

All DMAs share the Cassandra cluster and the OpenSearch cluster. Adding DMAs does not automatically add storage capacity or redundancy. Size and maintain the two database clusters separately.

![Multiple DMAs sharing Cassandra and OpenSearch on dedicated machines](~/dataminer/images/Recommended-Setup-2.png)

For a typical complete system, see [Centralized cluster](xref:Architecture_centralized_cluster). For local collection across several locations, see [Distributed multi-site system](xref:Architecture_distributed_sites).

## Database capacity and redundancy

For a hardware-redundant starting point, use at least three Cassandra nodes and at least three OpenSearch cluster-manager-eligible nodes, on separate machines. Additional capacity can be required for the workload or to maintain service during a failure or maintenance.

- **OpenSearch**: Use an odd number of cluster-manager-eligible nodes, at least three in production. A voting majority must remain available. Configure shard replicas and allocation so that a node failure does not remove all copies of the required data. Do not confuse the number of voting nodes with the total number of data nodes in a larger cluster. See [Installing an OpenSearch database](xref:Installing_OpenSearch_database).
- **Cassandra**: Capacity and availability depend on the number of nodes, replication factor, and consistency level. Cassandra does not use the same cluster-manager voting model as OpenSearch. See [Configuring the replication factor and consistency level](xref:replication_and_consistency_configuration).
- **Failure domains**: Separate redundant database nodes across physical hosts and, where possible, independent power and storage. Redundant virtual machines on one host do not protect against loss of that host.
- **Sizing**: Use the [Cassandra requirements](xref:DataMiner_Compute_Requirements#cassandra-requirements) and [OpenSearch requirements](xref:DataMiner_Compute_Requirements#opensearch-requirements), and test with representative polling, trending, alarm, and query loads.

Compute redundancy is a separate requirement. Use Swarming with [Node Recovery](xref:NodeRecovery_About), and leave enough capacity on surviving DMAs to take over supported workloads. Database redundancy does not make equipment reachable from a replacement DMA.

## Storage across sites

Do not stretch an OpenSearch cluster across high-latency links. Its nodes need stable, low-latency connectivity. Use [allocation awareness](xref:Configuring_multiple_datacenter_OpenSearch_cluster) for a supported multi-zone setup. For Cassandra, configure replication and consistency for the chosen data centers.

Surviving the loss of a site requires a design covering compute, storage, and connectivity together, not just copies of the databases. See [Geo-redundant system](xref:Architecture_geo_redundant) for the complete example and its network requirements. For deployments across distant regions, consider [Independent and federated DataMiner Systems](xref:Architecture_multiple_systems) instead of stretching one storage cluster.

## Backups and migration

Database replication is not a backup. Configure [Cassandra backups](xref:Backup_Restore_Cassandra_Cluster_Medusa) and [OpenSearch backups](xref:Configuring_OpenSearch_Backups), alongside DataMiner backups. Store recovery copies outside the failure domains they protect and test restores. See [Backups and disaster recovery](xref:Architecture_design_considerations#backups-and-disaster-recovery).

For existing storage per DMA, see [Migrating the general database to a DMS Cassandra cluster](xref:Migrating_the_general_database_to_a_DMS_Cassandra_cluster). To move to managed storage instead, see [Migrating existing data to STaaS](xref:Migrating_existing_data_to_STaaS).

## Legacy deployments

Elasticsearch and the cloud-provider database setups described below are not recommended for new deployments. Check [Software support lifecycles](xref:Software_support_life_cycles) before maintaining or upgrading an existing system.

### Failover setups (without geo-redundancy)

[Failover](xref:failover) has reached End of Engineering and is being replaced by Swarming. Existing Failover pairs still depend on the availability of their shared storage. The [database redundancy requirements](#database-capacity-and-redundancy) apply independently of the compute redundancy mechanism.

### Failover setups (with geo-redundancy)

The [storage network requirements](#storage-across-sites) also apply to existing geo-redundant Failover deployments. Adding a Failover pair at another site does not remove the need to protect storage and its network connections.

Setups with Amazon Keyspaces, Azure Managed Instance for Apache Cassandra, and Amazon OpenSearch Service are deprecated as of DataMiner 10.3.0 [CU9]/10.3.12. For cloud storage, migrate to STaaS instead.
