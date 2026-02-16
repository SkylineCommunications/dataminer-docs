---
uid: Managing_cloud-connected_nodes
keywords: cloud nodes
reviewer: Alexander Verkest
---

# Managing the nodes of a DMS connected to dataminer.services

As of DataMiner Cloud Pack version 2.5.0, you can use the Admin app to manage the nodes of a DMS that is connected to dataminer.services. You can upgrade the installed DxM versions on the nodes and remove nodes that have become obsolete.

> [!NOTE]
> If nodes in a DMS cannot be detected in the Admin app, this is likely because they are using an older version of the DataMiner Cloud Pack or because the DataMiner Cloud Pack is not yet installed. Download the latest version from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on every node in the DMS.

## Deploying a DxM on a DMS node

Some DxMs are not included in the DataMiner Cloud Pack and must be deployed separately. To do so:

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, expand the DataMiner System, and select the *DxMs* page.

   This page lists the different nodes in the DMS, with all possible DxMs that can be deployed on each node.

1. Next to a DxM, e.g., *ModelHost*, click *Deploy* to start the automatic installation process.

## Upgrading nodes to the latest DxM versions

To upgrade the DxMs used by the nodes in a DataMiner System connected to dataminer.services:

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, expand the DataMiner System, and select the *DxMs* page.

1. For each DxM you want to upgrade, click the *Upgrade* button next to that DxM.

   > [!NOTE]
   > If a node has a higher DxM version installed than the current version, a *Downgrade* button will be displayed instead.

1. To view the changes after the upgrade, click the *Refresh* button.

> [!NOTE]
> If you want to quickly check whether a DMS needs DxM upgrades, on the *Organization* > *Overview* page, click the DMS name under *DataMiner Systems*. This will show a page with information on the (connection) status of the DMS and the available updates.<!-- RN 38960 -->

## Removing an obsolete node from dataminer.services

When a node in a DataMiner System is no longer used, you can remove it from dataminer.services in the Admin app:

1. In the [Admin app](xref:Accessing_the_Admin_app), check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the top-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, expand the DataMiner System, and select the *DxMs* page.

1. Click the garbage can icon next to the obsolete node.

> [!NOTE]
> If you accidentally remove a node that is still in use, it will reappear in the overview as soon as the Orchestrator service is restarted on that node.
