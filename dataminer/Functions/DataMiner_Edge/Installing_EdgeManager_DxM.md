---
uid: Installing_EdgeManager_DxM
keywords: Site Manager, Edge Manager
description: Learn how to install the EdgeManager DxM, a prerequisite for using DataMiner Edge Gateway and Edge Node functionality.
---

# Installing the EdgeManager DxM

The EdgeManager DxM, previously known as SiteManager DxM, is required for both the [Edge Gateway](xref:About_Edge_Gateways) and [Edge Node](xref:About_Edge_Nodes) functionalities.

This DxM is **by default included in the DaaS image of DataMiner 10.5.10**. If your DaaS system is using an older DataMiner version, you will need to [upgrade DataMiner](xref:Upgrading_a_DataMiner_Agent) and [deploy the EdgeManager DxM](xref:Managing_cloud-connected_nodes#deploying-a-dxm-on-a-dms-node).

For a **self-managed DataMiner System**, the EdgeManager DxM must run on the same machine as the DataMiner Agent that requires Edge Gateway or Edge Node functionality. The DxM requires DataMiner 10.5.10/10.6.0 or higher and Windows 10 or Windows Server 2019 (build 17134) or higher.

To deploy the EdgeManager DxM:

1. Open the Admin app. See [Accessing the Admin app](xref:Accessing_the_Admin_app).

1. In the Admin app, check whether the correct organization is mentioned in the header bar.

1. If a different organization should be selected, click the organization selector ![Organization selector](~/dataminer/images/Cloud_Admin_Selector_icon.png) in the upper-right corner and select the organization in the list.

1. In the pane on the left, under *DataMiner Systems*, select your DataMiner System and select the *DxMs* page.

1. Next to *EdgeManager*, select to install this DxM.
