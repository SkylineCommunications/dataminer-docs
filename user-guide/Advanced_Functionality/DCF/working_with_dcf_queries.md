---
uid: working_with_dcf_queries
---

# Working with DCF GQI Queries

This tutorial shows you how to work with GQI queries that contains DCF data sources. For this specific example, you will work with DCF interface properties available in the data source DCF Interface Properties.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](https://docs.dataminer.services/user-guide/Cloud_Platform/Connecting_to_cloud/Connecting_your_DataMiner_System_to_the_cloud.html).
- Make sure that the [Generic Interface](https://docs.dataminer.services/user-guide/Reference/Soft-launch_options/Overview_of_Soft_Launch_Options.html#genericinterface) soft-launch option is enabled. See [Soft-launch options](https://docs.dataminer.services/user-guide/Reference/Soft-launch_options/SoftLaunchOptions.html).

>[!TIP]
>If you use a [DaaS system](https://docs.dataminer.services/user-guide/Getting_started/Creating_a_DMS_in_the_cloud.html), these prerequisites are automatically met.

>[!TIP]
>This tutorial is a continuation of the [Kata #45: DataMiner Connectivity Framework](https://community.dataminer.services/courses/kata-45/), available on DataMiner Dojo.

## Objective

The objective of this tutorial is to display information about DCF interface properties using a grid component. Furthermore, using a GQI Query filter components, we will be able to filter items in the grid component.

## Overview

- [Step 1: Deploy the tutorial package from the catalog](#step-1-deploy-the-tutorial-package-from-the-catalog)
- [Step 2: Provision DCF Connections and properties](#step-2-provision-dcf-connections-and-properties)
- [Step 3: Create a node edge graph](#step-3-create-a-node-edge-graph-using-dcf-connections)
- [Step 4: Configure the nodes](#step-4-configure-the-nodes)
- [Step 5: Configure the edges](#step-5-configure-the-edges)
- [Step 6: Display KPIs related to a connection](#step-6-display-kpis-related-to-a-connection)

## Step 1: Deploy the tutorial package from the Catalog

To deploy the package:

1. Go to the [Kata DCF package](https://catalog.dataminer.services/details/1b2baca9-9fa6-4a62-84c1-69e836612a8e) in the DataMiner Catalog.

1. Select the last version of the catalog (currently version 1.0.0.3) and click the *Deploy* button to deploy the package on your DMA.

  While the package is being deployed, you can follow the progress of the deployment in the [Admin app](xref:Accessing_the_Admin_app), on the *Deployments* page for your DMS. Make sure to use the *Refresh* button in the top-left corner.

  The package will deploy the following components:

    - The **Generic Data Simulator** connector, which exposes DCF interfaces and will be used by the elements created for this tutorial.

    - The **SLC-AS-Kata-DCF** Automation script, which will be used to provision the view, elements, DCF interface properties, DCF connections and properties required for this tutorial.

    - The **kata_dcf_view.vsdx** Visio file, which will be used to visualize DCF interfaces, connections, and related properties in Cube.

    - The **KATA_DCF** dashboard, located in the dashboard folder with the same name. This is a blank dashboard containing the following GQI queries, which are required to create the node edge graph for this tutorial:

      - **DCF_ELEMENTS**: The nodes representing the routers, switches, and PCs available in the network diagram.
      - **DCF_INTERFACES**: The DCF interfaces exposed by the elements created for this tutorial
      - **DCF_CONNECTIONS**: The DCF connections created for this tutorial.

    > [!NOTE]
    > This dashboard has been used for the previous Kata session [Kata #45](https://community.dataminer.services/courses/kata-45/) and was kept for reference.

    - The **KATA_DCF_ADVANCED** dashboard, located in the same folder. This blank dashboard will be used for this tutorial and contain the following GQI queries:

      - **DCF_ELEMENTS**: The nodes representing the routers, switches, and PCs available in the network diagram.
      - **DCF_ELEMENTS_POSITION**: The positions for the nodes available in this tutorial.
      - **DCF_INTERFACES**: The DCF interfaces exposed by the elements created for this tutorial.
      - **DCF_CONNECTIONS**: The DCF connections created for this tutorial.
      - **DCF_CONNECTIONS_PROPERTIES**: Properties related to the DCF connections available in this tutorial.

1. When the package has been fully deployed, in the **Automation** module in DataMiner Cube, go to the folder **Kata DCF** and execute the script **SLC-AS-Kata-DCF** to provision the components required for this tutorial.

   > [!TIP]
   > See also: [Manually executing a script](xref:Manually_executing_a_script)

   When the script is complete, the following items should become available in the Surveyor:

   - Views:
     - SLC_KATA_DCF
     - 00_ROUTER
     - 01_SWITCH
     - 02_PC
     - 10_PROVISIONING

   - Elements:
     - RO-01
     - SW-01
     - SW-02
     - PC-11
     - PC-12
     - PC-13
     - PC-21
     - PC-22
     - PC-23
     - SKYLINE_GENERIC_PROVISIONING

1. In the Cube Surveyor, select the view **SLC_KATA_DCF**.

1. Right-click the *VISUAL* page, select *Set as active Visio file* > *Existing*, and select the file **kata_dcf_view.vsdx**.

    If you cannot see that Visio file listed in the window, click *Other file* and browse to the folder *C:\Skyline DataMiner\Views*. You will be able to select the file there. If you do not have access to this folder, restarting the DMA will also make the Visio file become available in the window.

    > [!TIP]
    > See also: [Editing a Visual Overview in DataMiner Cube](xref:Editing_a_visual_overview_in_DataMiner_Cube).

## Step 2: Provision DCF Connections and properties

1. In the **Automation** module in DataMiner Cube, go the folder **Kata DCF** and execute the script **SLC-AS-Kata-DCF-Advanced** to provision the DCF interface properties.

1. To confirm that these properties were correctly provisioned, open any element (router, switch or PC) and go to the page **General Parameters** > and click the button *Configure..* for the parameter **DataMiner Connectivity Framework**. The table [Interface Properties] should contain the DCF Interface property *Bandwidth* for each port available in the Interface table (4 in total).

    > [!TIP]
    > See also: [General Parameters](xref:General_parameters)

1. Open the element **SKYLINE_GENERIC_PROVISIONING**. In the page **DCF Import**, click the button *Import*. Once the **Progress** parameter is set to 100, the **Status** parameter should indicate that 8 connections were found, and imported.

1. Open the overview available in the view **SLC_KATA_DCF** and confirm that all the connections were provisioned correctly. The following connections should be displayed.

1. 
