---
uid: Creating_hybrid_cluster
description: Learn how to create a hybrid DataMiner cluster by combining DaaS and self-managed nodes, including setup options and key requirements.
---

# Combining DaaS and self-managed nodes in one cluster

It is possible to combine DaaS and self-managed nodes within the same DataMiner cluster, creating a hybrid cluster. Between the DaaS nodes and the self-managed nodes, a site-to-site VPN connection will need to be set up.

## Setup approaches

The approach for this is different depending on whether you start from DaaS nodes or self-managed nodes:

- If you have a cluster consisting of DaaS nodes and want to add self-managed nodes, refer to [Starting from a DaaS cluster](xref:Starting_from_DaaS_cluster).
- If you have a self-managed cluster and want to add DaaS nodes, refer to [Starting from a self-managed cluster](xref:Starting_from_self-managed_cluster).

In either case, keep the key considerations below in mind.

## Key considerations

### Network address space

The DaaS network uses **address space 172.23.0.0/16** by default. If your on-premises network overlaps with this range, you will need to contact Skyline to change the DaaS address space before or after deployment, depending on the approach you use.

### Latency

Deploy DaaS in a region close to the location where your self-managed nodes are deployed to **minimize latency**. High latency between DaaS and on-premises DMAs can affect cluster synchronization, communication between nodes, and communication with on-premises devices.

### Storage

In a hybrid setup, all nodes in the cluster, both DaaS and on-premises DMAs, must use Storage as a Service (STaaS).

Hybrid clusters are **not supported with [self-managed storage nodes](xref:DM_and_storage_selfhosted)**.
