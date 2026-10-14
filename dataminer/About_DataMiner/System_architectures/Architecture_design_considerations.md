---
uid: Architecture_design_considerations
description: Review network, platform, virtualization, storage, backup, and sizing guidelines that apply when you design a DataMiner System architecture.
keywords: architecture, design, latency, network, virtualization, backup, disaster recovery, sizing, pitfalls
---

# Architecture design considerations

The guidelines on this page apply to all [DataMiner System architectures](xref:Architecture_overview). Taking them into account early in the design helps you avoid issues that are difficult to fix once the system is in production.

## Network

- **Latency between DataMiner nodes**: A latency between 30 ms and 50 ms or lower, and a throughput between 100 Mbps and 1 Gbps, is recommended. Higher latency does not prevent cluster synchronization, but it can become an issue when many values need to be exchanged between nodes. See the network requirements in [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements#network).
- **Latency within self-managed database clusters**: OpenSearch nodes must not be spread over high-latency links. For geo-redundant setups, see [Geo-redundant on-premises system](xref:Architecture_geo_redundant#network-requirements).
- **Reachability**: Every DataMiner node must be able to reach every other node in the cluster and all storage nodes it uses. With STaaS, every node needs outbound HTTPS access, directly or via a proxy. See [Setting up STaaS](xref:Setting_up_StaaS).
- **Ports and firewalls**: Open the required ports between DataMiner nodes, clients, and storage nodes. See [Configuring the IP network ports](xref:Configuring_the_IP_network_ports).
- **DMZ setups** are currently not supported with STaaS.
- **Name resolution and time**: Make sure hostnames resolve correctly on all nodes and that all servers use the same time source. Recovery procedures often depend on DNS and hostnames.
- **Unreliable WAN links**: Do not make critical functions depend on links that are known to be unreliable. Treat remote sites with poor connectivity as data collection points, for example with a local node or [DataMiner Edge](xref:DataMiner_Edge), rather than as an integral part of the central cluster.

## Platforms and virtualization

- **Operating systems**: DataMiner nodes run on Windows Server. Self-managed Cassandra and OpenSearch nodes run on Linux. Cassandra is no longer supported on Windows from Cassandra 4.x onwards.
- **Virtualization**: Running DataMiner and the database nodes on virtual machines is common and fully supported. Make sure the virtual machines get the CPU, memory, and disk performance described in the [compute requirements](xref:DataMiner_Compute_Requirements), and avoid overcommitting resources on the hypervisor.
- **High availability of the hypervisor is not the same as application redundancy.** Restarting a virtual machine on another host protects against hardware failure, but not against issues in the operating system, DataMiner, or the database. It also causes downtime during the restart.
- **Separate failure domains**: Place redundant DataMiner nodes and database nodes on different physical hosts, storage systems, and if possible power feeds. Two "redundant" virtual machines on the same host are not redundant.
- **Disk performance**: DataMiner and especially the database nodes require fast storage with low latency. Shared storage arrays used by many virtual machines can become a bottleneck.

## Storage

- **The storage is part of the critical path.** DataMiner cannot start if its storage is not available. When you design redundancy for DataMiner nodes, also design redundancy for the storage.
- **Avoid two-node database clusters.** A cluster of two nodes cannot keep a majority when one node fails. Use at least three Cassandra nodes and an uneven number of OpenSearch nodes, at least three.
- **Plan for growth**: Trending, alarms, and solutions such as EPM or MediaOps can generate large amounts of data. With self-managed storage, monitor disk usage and plan capacity ahead. STaaS scales automatically.
- **Deprecated storage setups**: Setups with a separate database per DMA are deprecated. If your system still uses such a setup, plan a migration to [STaaS](xref:STaaS) or [dedicated clustered storage](xref:Dedicated_clustered_storage).

## Backups and disaster recovery

- **DataMiner backups**: Configure automatic [DataMiner backups](xref:Backing_up_a_DataMiner_Agent_in_DataMiner_Cube) on every node and store them at a location other than the node itself.
- **Storage backups**: With STaaS, daily backups are taken automatically and retained for 30 days. With self-managed storage, configure backups of Cassandra and OpenSearch with their native snapshot mechanisms, and schedule them close to the DataMiner backups so the restore points match as closely as possible.
- **Virtual machine snapshots** are not a replacement for database backups, as they do not guarantee a consistent state of a distributed database.
- **Test your recovery**: Regularly test restoring a node and, for critical systems, the full system. Document the recovery procedure, including the dependencies on DNS, certificates, licenses, and network configuration.
- **Define your targets**: Decide how long the system may be unavailable and how much data may be lost, and choose the redundancy and backup strategy accordingly.

## Sizing

- Size every DataMiner node and every self-managed database node according to the [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements). The number of elements is only one factor. Polling frequency, the number of parameters and table rows, trending, alarm rates, and the solutions you use also have a large impact.
- For self-managed Cassandra clusters, use the [node calculator](https://community.dataminer.services/calculator/).
- **Keep spare capacity.** With Failover, the backup DMA must be able to take over the full load of the active DMA. With Swarming, the remaining nodes must be able to take over the elements of a failed node, so no node should run at full capacity.
- Separate roles when the load grows, for example nodes for user-facing functionality and nodes for polling, so that heavy polling does not affect the user experience.

## Operations

- **Responsibilities**: Clearly define who is responsible for each part of the system: the DataMiner configuration, the servers and virtual machines, the operating systems, the databases, the network, and the backups.
- **Monitoring the monitoring system**: Use the built-in health features, such as [proactive support](xref:Proactive_Support) via dataminer.services, and monitor the servers and databases that DataMiner runs on.
- **Upgrades**: All nodes in a DMS run the same DataMiner version. Plan upgrades, test them on a [staging system](xref:Architecture_lab_and_staging) first, and make sure you can roll back.

## Common pitfalls

| Pitfall | Why it is a problem |
|--|--|
| Redundant DataMiner nodes with a single database node | The database is a single point of failure, so the system is not redundant. |
| Two-node database clusters | No majority is possible when one node fails. |
| Stretching a database cluster over a high-latency link | The database cluster can become unstable or unavailable. |
| Relying only on hypervisor high availability or virtual machine snapshots | These do not protect against application or database issues and do not guarantee consistent database backups. |
| All redundant nodes on the same physical host or storage array | One hardware failure takes down all redundant nodes. |
| A staging system with a different storage architecture than production | Issues that only occur in production are not detected during testing. |
| No spare capacity in the cluster | When a node fails, the remaining nodes cannot take over its load. |
| Keeping a small, non-redundant system after it has become business-critical | The architecture no longer matches the importance of the system. Review the architecture when the role of the system changes. |
