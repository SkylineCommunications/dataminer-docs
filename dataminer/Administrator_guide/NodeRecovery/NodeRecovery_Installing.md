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
> Do not configure [trigger scripts](xref:NodeRecovery_Triggers) before installing the DxM on all nodes. Outages will be detected right away for nodes that to not have the DxM installed yet, which can lead to unintended consequences if you have scripts that trigger on these detections.

## Further configuration

On [Swarming](xref:Swarming)-enabled systems, the DxM will start monitoring the cluster for outages right away. No further actions will happen unless you configure a [trigger script](xref:NodeRecovery_Triggers).

The [Catalog](https://catalog.dataminer.services/) contains an example script which can be used to rebalance swarmable elements to healthy nodes when an outage is detected. You can use this as a starting point for your own scripts or as inspiration for your own custom logic.
