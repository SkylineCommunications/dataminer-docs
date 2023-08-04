---
uid: Managing_cloud-connected_nodes
---
# Managing the nodes of a DMS connected to dataminer.services

As of DataMiner Cloud Pack version 2.5.0, you can use the Admin app to manage the nodes of a DMS that is connected to dataminer.services. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete.

> [!NOTE]
> If nodes in a DMS cannot be detected in the Admin app, this is likely because they are using an older version of the DataMiner Cloud Pack or because the DataMiner Cloud Pack is not yet installed. Download the latest version from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on every node in the DMS.

## Deploying a DxM on a node

Some DxMs are not included in the DataMiner Cloud Pack and must be deployed separately. To do so:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. Next to your module of choice, e.g. *ModelHost*, click *Deploy* to start the automatic installation process.

## Upgrading nodes to the latest DxM versions

To upgrade the DxMs used by the nodes in a DataMiner System connected to dataminer.services:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. To upgrade all DxMs installed on a node to the latest version, click *Install latest available versions*. Alternatively, to upgrade specific DxMs only, click the *Upgrade* button for those DxMs.

   > [!NOTE]
   > If a node has a higher DxM version installed than the current version, a *Downgrade* button will be displayed instead.

1. To view the changes after the upgrade, click the *Refresh* button.

## Removing an obsolete node from dataminer.services

When a node in a DataMiner System is no longer used, you can remove it from dataminer.services in the Admin app.

To do so:

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

   > [!TIP]
   > See also: [Accessing the Admin app](xref:Accessing_the_Admin_app)

1. If a different organization should be selected, click the organization selector ![Organization selector](~/user-guide/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *Nodes* page.

1. Click the "x" next to the obsolete node.

> [!NOTE]
> If you accidentally remove a node that is actually still in use, it will reappear in the overview as soon as the Orchestrator service is restarted on that node.
