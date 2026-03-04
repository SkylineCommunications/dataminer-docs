---
uid: NodeRecovery_Installing
---

# Installing Node Recovery

## Prerequisites

- The [Swarming](xref:Swarming) feature must be enabled in the system. If it is not enabled, the NodeRecovery process will run but will not take any actions.

- This functionality requires DataMiner 10.6.0/10.6.2 or higher.

## Installation

1. Contact <support.data-core@skyline.be> to receive the most recent NodeRecovery DxM release.

   You will receive a *DataMiner NodeRecovery* MSI file.

1. Upload and execute the MSI file on all the Agents in the cluster to deploy the NodeRecovery DxM.

> [!NOTE]
> Only configure [trigger scripts](xref:NodeRecovery_Triggers) **after** the DxM has been installed on all nodes. Otherwise, if installing takes over 30 minutes, earlier installed nodes might start generating outages for nodes that do not have the DxM installed yet, which could lead to unintended consequences if this triggers scripts.

## Further configuration

The DxM will start monitoring the cluster for outages right away. However, no further actions will happen unless you have configured a [trigger script](xref:NodeRecovery_Triggers).

For example, the following trigger script is available in the Catalog: [NodeRecovery - Global State Change](https://catalog.dataminer.services/details/3de8405e-7156-4a0a-b8c5-80937de0f4ed). Once deployed, this script will execute a simple rebalancing algorithm whenever the global cluster state changes. Elements hosted on nodes that are in outage will be moved to healthy nodes, while load remains balanced across the cluster as much as possible. You can use this script as is if it fits your needs, or you can use it as a starting point for your own scripts.
