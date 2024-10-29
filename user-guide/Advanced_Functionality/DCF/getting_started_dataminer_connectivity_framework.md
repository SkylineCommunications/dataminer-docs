---
uid: getting_started_dataminer_connectivity_framework
---

# Getting started with DCF

This tutorial shows how you can get started with DataMiner Connectivity Framework (DCF) based on a basic example. In this example, you will create DCF connections between elements that expose external DCF interfaces and visualize them using a Visio-based overview in Cube and a node edge graph in a dashboard.

The content and screenshot of this tutorial were created in DataMiner version 10.4.11.

Expected duration: 20 minutes

> [!TIP]
> See also: [Kata #45: DataMiner Connectivity Framework (DCF)](https://community.dataminer.services/courses/kata-45/) on DataMiner Dojo.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- To be able to expose DCF interfaces and connections in dashboards/low-code apps, you may need to activate the [GenericInterface](xref:Overview_of_Soft_Launch_Options#genericinterface) soft-launch option. See [Soft-launch options](xref:SoftLaunchOptions).

> [!TIP]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Objective

The objective of this tutorial is to build the following network connectivity diagram in a visual overview and a node edge graph using DCF:

![Kata DCF Network Diagram](~/user-guide/images/kata_dcf_tutorial_0.png)

Where:

- RO-x: Router
- SW-x: Switch
- 1/x: Represents the port number from the device

For example, from the diagram you can infer the following:

- RO-01 connects to SW-01 using the interface Port Ethernet 1/1.
- SW-01 connects to RO-01 using the interface Port Ethernet 1/1.
- SW-01 connects to PC-11 using the interface Port Ethernet 1/2.
- PC-11 connects to SW-01 using the interface Port Ethernet 1/1.

## Overview

- [Step 1: Deploy the tutorial package from the catalog](#step-1-deploy-the-tutorial-package-from-the-catalog)
- [Step 2: Create external DCF connections](#step-2-create-external-dcf-connections)
- [Step 3: Create a node edge graph](#step-3-create-a-node-edge-graph-using-dcf-connections)
- [Step 4: Configure the nodes](#step-4-configure-the-nodes)
- [Step 5: Configure the edges](#step-5-configure-the-edges)
- [Step 6: Display KPIs related to a connection](#step-6-display-kpis-related-to-a-connection)

## Step 1: Deploy the tutorial package from the Catalog

To deploy the package:

1. Go to the [Kata DCF package](https://catalog.dataminer.services/details/1b2baca9-9fa6-4a62-84c1-69e836612a8e) in the DataMiner Catalog.

1. Click the *Deploy* button to deploy the package on your DMA.

   While the package is being deployed, you can follow the progress of the deployment in the [Admin app](xref:Accessing_the_Admin_app), on the *Deployments* page for your DMS. Make sure to use the *Refresh* button in the top-left corner.

   The package will deploy the following components:

   - The **Generic Data Simulator** connector, which exposes DCF interfaces and will be used by the elements created for this tutorial.

   - The **SLC-AS-Kata-DCF** Automation script, which will be used to provision the view and elements required for this tutorial.

   - The **kata_dcf_view.vsdx** Visio file, which will be used to visualize DCF connections in Cube.

   - The **KATA_DCF** dashboard, located in the dashboard folder with the same name. This is a blank dashboard containing the following GQI queries, which are required to create the node edge graph for this tutorial:

     - **DCF_ELEMENTS**: The nodes representing the routers, switches, and PCs available in the network diagram.
     - **DCF_INTERFACES**: The DCF interfaces exposed by the elements created for this tutorial
     - **DCF_CONNECTIONS**: The DCF connections created for this tutorial

1. When the package has been fully deployed, in the **Automation** module in DataMiner Cube, go to the folder **Kata DCF** and execute the script **SLC-AS-Kata-DCF** to provision the components required for this tutorial.

   > [!TIP]
   > See also: [Manually executing a script](xref:Manually_executing_a_script)

   When the script is complete, the following items should become available in the Surveyor:

   - Views:
     - SLC_KATA_DCF
     - 00_ROUTER
     - 01_SWITCH
     - 02_PC
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

   ![Kata DCF Provisioned Elements](~/user-guide/images/kata_dcf_tutorial_1.png)

1. Right-click the view **SLC_KATA_DCF** and *set as active Visio file* the file **kata_dcf_view.vsdx**. This Visio file will be available in the context menu when selecting the option *Existing*.

> [!TIP]
> For more information on how to set a Visio file as active, see [Editing a Visual Overview in DataMiner Cube](xref:Editing_a_visual_overview_in_DataMiner_Cube).

> [!NOTE]
>
> In case the Visio file is not listed, you could try below options:
>
> - If there is access to the *C:\Skyline DataMiner* folder, the Visio file can be found in the folder *C:\Skyline DataMiner\Views*.
> - If there is no access to the *C:\Skyline DataMiner* folder, try restarting the DMA. After restarting the DMA, the Visio file should be listed when assigning an existing Visio file.

## Step 2: Create external DCF connections

1. Define connections between the router and switches:

   1. Right-click the element **RO-01**, select *Properties*, and go to the *connectivity* tab.

   1. Go to the *external* tab.

   1. In the *State* column, select *Connected* for the interface **Port Ethernet 1/1**.

   1. In the *External* column, select the element **SW-01**.

   1. In the *Interface* column, select the interface **Port Ethernet 1/1**.

      ![DCF Connection Visual Overview](~/user-guide/images/kata_dcf_tutorial_2.png)

   1. Click the *Apply* button to apply these changes. Once the connection is created, the Visio file assigned to the view **SLC_KATA_DCF** should display the DCF connection

      ![DCF Connection Visual Overview](~/user-guide/images/kata_dcf_tutorial_3.png)

   1. In the *State* column, select *Connected* for the interface **Port Ethernet 1/2**.

   1. In the *External* column, select now the element **SW-02**.

   1. In the *Interface* column, select the interface **Port Ethernet 1/1**. This new connection should be displayed in the visual overview.

1. Define connections between the switches and PCs:

   1. Right-click the element **SW-01**, select *Properties*, and go to the *connectivity* tab.

   1. Go to the *external* tab.

   1. In the *State* column, select *Connected* for the interface **Port Ethernet 1/2**.

      > [!NOTE]
      > You will notice that there is already a connection in interface **Port Ethernet 1/1**. This is because DCF creates both connections on both ends.

   1. In the *External* column, select the element **PC-01**.

   1. In the *Interface* column, select the interface **Port Ethernet 1/1**. This new connection should be displayed in the visual overview.

Proceed with the remaining connections according to the diagram above.

> [!NOTE]
> For the next steps, it is required to create all the DCF connections, according to the diagram above.

## Step 3: Create a node edge graph using DCF connections

1. Go to the [Dashboards app](xref:Accessing_the_Dashboards_app).

1. In the pane on the left, navigate to *KATA_DCF* > *KATA_DCF* to open the *Node_Edge* dashboard.

1. Click the pencil icon in the dashboard header bar to start editing the dashboard.

1. Drag a *Node edge graph* visualization from the pane on the left onto the dashboard.

![Node edge graph visualization](~/user-guide/images/kata_dcf_tutorial_4.png)

1. In the *Data pane* on the right, expand the *Queries* node, and drag the following queries to the visualization were added:

- *DCF_ELEMENTS*: This GQI query contains the nodes

- *DCF_CONNECTIONS*: This GQI query contain the connections between the nodes

  ![Add queries to the visualization](~/user-guide/images/kata_dcf_tutorial_5.png)

> [!NOTE]
>
> Although the GQI query *DCF_INTERFACES* is not used directly in the node edge graph, it is used by the GQI query *DCF_CONNECTIONS*. The GQI query *DCF_INTERFACES* contains the link between the DCF interfaces and the parameters from the element.

## Step 4: Configure the nodes

1. Click the node edge graph component you have added to select it.

1. Select the *Settings* pane on the right. The queries you added earlier will be listed under *Unassigned queries*

1. Under the query *DCF_ELEMENTS*, select *Set as node*.

   ![Select GQI query as node](~/user-guide/images/kata_dcf_tutorial_6.png)

   The selected query will be moved to the bottom of the pane.

1. For the same query, set *Node ID column* to the column *Element ID*.

   This way, you indicate that the *Element ID* column contains the ID representing the different entities that should be shown as nodes.

   Nine nodes will be now displayed in the node edge graph component, representing the router, switches, and PCs. By default, the icon displayed for each node is a circle.

   ![Nodes available in the GQI query](~/user-guide/images/kata_dcf_tutorial_7.png)

1. Add an override for the **router** node:

   1. Click *Add override*.

      ![Add override to node](~/user-guide/images/kata_dcf_tutorial_8.png)

   1. In the *Filter* box, select *Description*. A text box will now be displayed to right of the filter.

   1. In the text box, specify `ROUTER`.

      ![Select node as router](~/user-guide/images/kata_dcf_tutorial_9.png)

   1. In the *Weight* box, specify `3`. This will ensure that the node representing the router is positioned at the top of the component. This is because with the default layout settings, the higher the weight of a node, the higher of the node in the graph.

   1. In the *Shape* box, select *Hexagon*. The node representing the router will now have a hexagon shape behind. Optionally you can also change the color of the shape by clicking the colored circle to the right of the *Shape* box

   1. In the *Icon* box, change select *NetworkDeviceScanning*.

      > [!NOTE]
      > To quickly find a specific icon in the list, start typing the name of the icon in the box.

   1. In the *Label* box, select *Name*. The name of the device should now be displayed below the nodes.

      ![Router node fully configured](~/user-guide/images/kata_dcf_tutorial_10.png)

1. Add an override for the **switch** node:

   1. Click *Add Override* again.

   1. In the *Filter* box, select *Description*, and enter the value `SWITCH` in the box on the right.

   1. Keep the *Weight* set to 2.

      This will ensure that the nodes representing the switches are positioned below the router node.

   1. In the *Shape* box, select *Decagon*.

      The node representing the switch will now have a decagon shape. Optionally, you can also change the color of the shape by clicking the colored circle to the right of the *Shape* box.

   1. In the *Icon* box, select *Switch*.

   1. In the *Label* box, select *Name*. The nodes should now look like this:

      ![Switch node fully configured](~/user-guide/images/kata_dcf_tutorial_11.png)

1. Add an override for the **pc** node:

   1. Click *Add Override* again.

   1. In the *Filter* box, select *Description*, and enter the value `PC` in the box on the right.

   1. Keep the *Weight* set to 1.

      This will ensure that the nodes representing the switches are positioned below the switch node.

   1. In the *Shape* box, select *Circle*.

      The node representing the switch will now have a circle shape. Optionally, you can also change the color of the shape by clicking the colored circle to the right of the *Shape* box.

   1. In the *Icon* box, select *ThisPC*.

   1. In the *Label* box, select *Name*.

The nodes should now look like this:

![Switch node fully configured](~/user-guide/images/kata_dcf_tutorial_12.png)

## Step 5: Configure the edges

1. At the top of the *Unassigned queries* list, under the query *DCF_CONNECTIONS*, select *Set as edge*.

   The query will be moved to the bottom of the pane.

1. In the *Source* box, select *Source Device ID*.

1. In the *Destination* box, select *Destination Device ID*.

   The edges connecting the router and switches will now be displayed in the node-edge graph visualization.

   ![Edges between router and switch nodes](~/user-guide/images/kata_dcf_tutorial_13.png)

## Step 6: Display KPIs related to a connection

By default, when clicking in a connection you will be able to see all the information related to the connection:

![Default Connection Details](~/user-guide/images/kata_dcf_tutorial_14.png)

The objective will be to display only the parameters *Operational State* and *Bitrate* in the details related to the connection.

1. Go to the GQI query "DCF_CONNECTION" and drag and drop the columns *Bit Rate* and *Operational Status*

![Filtering columns from the query](~/user-guide/images/kata_dcf_tutorial_15.png)

When clicking on a connection, you should be able to see only these two properties:

![Filtered Connection Details](~/user-guide/images/kata_dcf_tutorial_16.png)
