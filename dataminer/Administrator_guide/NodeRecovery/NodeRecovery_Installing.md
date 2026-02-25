---
uid: NodeRecovery_Installing
---

# Installing NodeRecovery

## Prerequisites

- The system needs to be Swarming-enabled. If the [Swarming](xref:Swarming) feature is not enabled, the process will run but will not take further actions.
- This functionality requires a DataMiner version of at least 10.6.0/10.6.2.

## Installing

- Contact Skyline Communications to get hold of a copy of the most recent NodeRecovery DxM release.

- Install the *DataMiner NodeRecovery* DxM on all the agents in the cluster.

> [!NOTE]
> Do not configure [trigger scripts](xref:NodeRecovery_Triggers) before installing the DxM on all nodes. If installing takes over 30 minutes in total, earlier installed nodes might start generating outages for nodes that do not have the DxM installed yet, which can lead to unintended consequences if you have scripts that trigger on these detections.

## Further configuration

On [Swarming](xref:Swarming)-enabled systems, the DxM will start monitoring the cluster for outages right away.

No further actions will happen unless you configure a [trigger script](xref:NodeRecovery_Triggers).

One such example Global State Change script is available here: [Catalog: NodeRecovery - Global State Change](https://catalog.dataminer.services/details/3de8405e-7156-4a0a-b8c5-80937de0f4ed). Once deployed, this script will execute a simple rebalancing algorithm whenever the global cluster state changes. Elements hosted on nodes that are in outage will be moved to healthy nodes, while trying to keep the load balanced across the cluster as much as possible. This script can be used as a starting point for your own scripts or can be used as is if it fits your needs.
