---
uid: Managing_cloud-connected_nodes
---
# Managing the nodes of a cloud-connected DMS

As of DataMiner Cloud Pack version 2.5.0, you can manage the nodes of a cloud-connected DMS in the DCP Admin app. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete.

> [!NOTE]
> If nodes in a DMS cannot be detected in the Admin app, this is likely because they are using an older version of the DataMiner Cloud Pack or because the DataMiner Cloud Pack is not yet installed. Download the latest version from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on every node in the DMS.

## Upgrading nodes to the latest DxM versions

To upgrade the DxMs used by the nodes in a cloud-connected DataMiner System:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. To upgrade all DxMs installed on a node to the latest version, click *Install latest available versions*. Alternatively, to upgrade specific DxMs only, click the *Upgrade* button for those DxMs.

   > [!NOTE]
   > If a node has a higher DxM version installed than the current version, a *Downgrade* button will be displayed instead.

1. To view the changes after the upgrade, click the *Refresh* button.

## Removing an obsolete node from the cloud

When a node in a DataMiner System is no longer used, you can remove it from the cloud in the DCP Admin app.

To do so:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector in the top-right corner and select the organization in the list.

   ![Organization selector](~/user-guide/images/CloudAdmin_Selector.png)

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. Click the "x" next to the obsolete node.

> [!NOTE]
> If you accidentally remove a node that is actually still in use, it will reappear in the overview as soon as the Orchestrator service is restarted on that node.
