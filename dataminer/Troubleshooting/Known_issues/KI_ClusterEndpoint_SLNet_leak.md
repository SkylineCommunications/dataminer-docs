---
uid: KI_ClusterEndpoint_SLNet_leak
---

# SLNet memory leak caused by ClusterEndpoint.json sync

## Affected versions

- Feature Release: DataMiner 10.5.7 and 10.5.8
- Main Release: DataMiner 10.5.0 [CU4], 10.5.0 [CU5]

## Cause

After an upgrade to one of the affected DataMiner versions, it is possible that `C:\Skyline DataMiner\Configurations\ClusterEndpoint.json` starts to sync incorrectly, resulting in a storm of updates, which in turn causes a memory leak in SLNet that causes Agents to disconnect. The severity of the issues scales with the size of the DataMiner System and the number of Failover pairs in the cluster.

## Fix

Install DataMiner 10.5.0 [CU6]/10.5.9.<!-- RN 43407 -->

## Workaround

In DataMiner 10.5.0 [CU5]/10.5.8, you can prevent this issue by setting the [ClusterEndpointsManager](xref:Overview_of_Soft_Launch_Options#clusterendpointsmanager) soft-launch option to "false" on each DataMiner Agent in the cluster. However, note that it is not possible to [migrate to BrokerGateway](xref:BrokerGateway_Migration) while this option is disabled.

## Description

After an upgrade to one of the affected DataMiner versions, a serious SLNet memory leak can occur, causing DataMiner Agents to disconnect frequently.
