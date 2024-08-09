---
uid: EPM_Introduction_Tutorial
---

# Getting started with EPM

This tutorial will provide a brief introduction on how you can use many EPM-specific features.

Expected duration: 30 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.5.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud), and where the [CPEIntegration](xref:Overview_of_Soft_Launch_Options#cpeintegration) soft-launch option is enabled.

> [!TIP]
> A [DataMiner as a Service](xref:Creating_a_DMS_on_dataminer_services) system comes with a dataminer.services connection out of the box and has most soft-launch options enabled, so it automatically meets this requirement.

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the DataMiner EPM Integration Training package from the Catalog](#step-1-deploy-the-dataminer-epm-integration-training-package-from-the-catalog)
- [Step 2: Create a new collector element and rebalance the system](#step-2-create-a-new-collector-element-and-rebalance-the-system)
- [Step 3: Use EPM relations to filter out alarms](#step-3-use-epm-relations-to-filter-out-alarms)
- [Step 4: Using the EPM Feed in Dashboards and Low-Code Apps](#step-4-using-the-epm-feed-in-dashboards-and-low-code-apps)
- [Step 5: Link EPM entities to Views](#step-5-link-epm-entities-to-views)

## Step 1: Deploy the *DataMiner EPM Integration Training* package from the Catalog

1. Go to <https://catalog.dataminer.services/details/b661f936-d6e7-447c-baee-f0a5503e75b4>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether the following items have been added to your DataMiner Agent:

   - A **view** named *EPM Training*.

   - A **front-end element** named *EPM Training FE*.

   - Two **back-end elements** named *EPM Training BE 1* and *EPM Training BE 2*.

   - Three **collector elements** named *EPM Training Collector 1*, *EPM Training Collector 2*, and *EPM Training Collector 3*.

   - The **Topology app** in between the Surveyor and Activity module.

   ![Cube sidebar with Topology app](~/user-guide/images/EPM_GS_step_1.png)

> [!NOTE]
> If the Topology app does not show up right away, restart the Cube client.

## Step 2: Create a new collector element and rebalance the system

The EPM architecture allows horizontal scaling: you can add more collector elements at any time to reduce the load on individual elements without adding any load to the front-end element. In this step, you will add such a collector element and then rebalance the system.

1. Create a new collector element in the *EPM Training* view:

   1. Open the Surveyor in DataMiner Cube.

   1. Right-click the *EPM Training* view (e.g. the root view), and select *New* > *Element*.

   1. Enter the element name *EPM Training Collector 4*, select the DMA where the element should be added, select the *Skyline EPM Integration Training Collector* protocol, and click *Create*.

      > [!NOTE]
      > If you are using a DMS consisting of multiple DMAs, select the same DMA as the one hosting the *EPM Training BE 2* element. If you do not know which DMA is hosting this element, right-click this element and select *Properties*. The DMA ID is the first number in the ID, before the slash.

   ![Creation of new Collector element](~/user-guide/images/EPM_GS_step_2_1.png)

1. Right-click the newly created element, select *Properties*, and copy the DMA ID/element ID of the element.

   ![DMA ID/element ID in element properties](~/user-guide/images/EPM_GS_step_2_2.png)

1. Configure the *EPM Training BE 2* element as the parent manager of the *EPM Training Collector 4* element:

   1. Open the *EPM Training BE 2* (1) element, and go to the *Configuration* visual page (2) and then the *Collectors* tab (3).

   1. Paste the DMA ID/element ID you copied earlier into the *Add Collector Element* box, and click *SET* (4).

   ![Collectors tab back-end element](~/user-guide/images/EPM_GS_step_2_3.png)

1. Register the new element in the front-end configuration:

   1. Open the **Topology** app (1), select the *Configuration* topology chain (2), and click the sideward arrow (3).

      ![Topology chain](~/user-guide/images/EPM_Tutorial_Topology_Chain.png)

   1. Go to the *Configuration* visual page (1) and then the *Collectors* tab (2).

   1. Paste the DMA ID/element ID you copied earlier into the *Add Collector Element* box, and click *SET* (3).

      ![Collectors tab front-end element](~/user-guide/images/EPM_GS_step_2_4.png)

1. Initiate the front-end provisioning cycle:

   1. Navigate to the *General* tab (1) of the *EPM Training FE* element.

   1. Next to *Import*, click the *SET* button (2).

   ![Import button on General page](~/user-guide/images/EPM_GS_step_2_5.png)

   The Manager connectors will now redistribute the load on the collectors, to prevent one element from having too much data.

1. To confirm whether this has been completed successfully, open the *EPM Training Collector 4* element and check whether the *Number Endpoints* parameter on the *General* page is filled in.

   ![Number Endpoints parameter](~/user-guide/images/EPM_GS_step_2_6.png)

## Step 3: Use EPM relations to filter out alarms

At this point, all of the collectors have pinged their endpoint devices, and a lot of station alarms are created. This happens because many of these stations only have 1 endpoint associated with them. You can filter these alarms to only show station alarms where the issue is only present on the station and not on the "Hub" parent entity level.

1. Right-click the *EPM Training FE* element and select *Protocols & Templates* > *View alarm template 'Alarm_Default'*.

   This will open the alarm template assigned to the *EPM Training FE* element.

   ![Opening the alarm template from the context menu](~/user-guide/images/EPM_GS_step_3_1.png)

1. In the alarm template, scroll down to the *Station* section and locate the *Percentage Unreachable Endpoints* parameter, then scroll to the right until you can see the *Condition* column.

1. In the *Condition* column, click the row of the *Percentage Unreachable Endpoints* parameter, and select *\<New>*.

   ![Adding a new condition](~/user-guide/images/EPM_GS_step_3_2.gif)

1. Configure an alarm template condition to filter out any *Station Unreachable Endpoints* alarms when the parent hub is also in alarm for the same KPI:

   1. Name the condition *Hub Relation*.

   1. Click *Select a filter* and select the *Hub Overview Table: Percentage Unreachable Endpoints* parameter.

   1. Click *Equal to* and select *Greater than* instead.

   1. Click *\<Click to select>* and enter the value `24.9`.

   With this configuration, if the parent hub has 25% or more unreachable endpoints, the station alarm will be ignored.

   ![Alarm condition configuration](~/user-guide/images/EPM_GS_step_3_3.png)

1. Click *OK* to save the condition and *OK* again to save the alarm template.

The system should now have a large decrease in critical alarms.

## Step 4: Using the EPM Feed in Dashboards and Low-Code Apps

1. In the Dashboards module, create a folder called *Customer* under the Training folder. Then create a new dashboard called *01. Device Overview* in the new Customer folder.

   ![Device Overview folder](~/user-guide/images/EPM_GS_step_4_1.png)

1. Add the EPM Feed component to the dashboard. You can quickly find it by searching *EPM* in the component search.

   ![EPM Feed component](~/user-guide/images/EPM_GS_step_4_2.png)

1. The EPM Feed component is an exclusive component that can only be linked to a Frontend EPM Manager element. To do so, add the EPM Training FE Element under the Elements tab in the Data section.

   ![Adding data to the EPM Feed component](~/user-guide/images/EPM_GS_step_4_3.gif)

1. Now that the element data is in the component, the topology information needs to be configured. To do so, navigate to the settings section of the EPM Feed component and changing the CPE Chain from *Location Topology* to *Customer Topology* and then checking the Customer chain filter. Once configured, feel free to expand the component to fill in more of the dashboard.

   ![Component settings](~/user-guide/images/EPM_GS_step_4_4.png)

1. Back in the data section, go to the *Queries* section and create a new query. Name it *All Endpoints* and select the *Get parameters for elements where* data source. Select the Skyline EPM Integration Training Collector Protocol and then the Production version.

1. Once the parameters populate, select the *Endpoint Overview Table*. Afterwards, select the *Select* operator and select the Index, IP, Customer, Jitter, Latency, Packet Loss Rate, and RTT parameters.

1. Now that we have all the **Endpoint** information we want from all of the **Collectors**, we will now filter to only show the Endpoints associated to the Customer selected in the EPM Feed. Select Filter in the operator and select the *Customer Name* parameter. The Filter method will be *equals* and for the value, we will link the field to the EPM Feed component. Select the little chain icon on the right and then select *EPM Feed 1* for the feed and then the *System name* property. Once done it should look like this:

   ![Query configuration](~/user-guide/images/EPM_GS_step_4_5.png)

1. Drag the query onto the dashboard to create an empty component. Once created, hover over the component and select the Pie Graph icon to change the component to a Table component.

   ![Component selection](~/user-guide/images/EPM_GS_step_4_6.png)

1. Once the table component has been created, stretch it out to cover the remaining white space and stop editing the dashboard. It should look similar to this:

   ![Stretched out table component](~/user-guide/images/EPM_GS_step_4_7.png)

1. Now selecting a Customer on the EPM Feed will update the table below to show all of the Endpoints associated to the selected Customer.

   ![Selecting a customer in the EPM feed](~/user-guide/images/EPM_GS_step_4_8.gif)

## Step 5: Link EPM entities to Views

1. Create a View under the Root view called *Florida*, then a view under the Florida view called *Miami*, and finally a view under the Miami view called *South Beach*. This is to simulate the tree structure of the relationships.

   ![South Beach view](~/user-guide/images/EPM_GS_step_5_1.png)

1. Navigate to the Frontend configuration page (can be accessed by selecting the Configuration Topology Chain in the Topology app) and press the Update Views button on the General page

   ![Update Views button](~/user-guide/images/EPM_GS_step_5_2.png)

All of the views are now linked to their EPM objects and inherit their alarm properties from the EPM entity. Selecting any of the views will show a data section displaying the EPM KPI information.

![Data section with EPM KPI information](~/user-guide/images/EPM_GS_step_5_3.png)
