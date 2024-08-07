---
uid: EPM_Introduction_Tutorial
---

# Getting started with EPM

This tutorial will provide a brief introduction on the EPM architecure and how you can use many EPM specific features.

Expected duration: 30 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.5.

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy the DataMiner EPM Integration Training package from the Catalog](#step-1-deploy-the-dataminer-epm-integration-training-package-from-the-catalog)
- [Step 2: Create a new Collector element and rebalance system](#step-2-create-a-new-collector-element-and-rebalance-system)
- [Step 3: Use EPM relations to filter out alarms](#step-3-use-epm-relations-to-filter-out-alarms)
- [Step 4: Using the EPM Feed in Dashboards and Low-Code Apps](#step-4-using-the-epm-feed-in-dashboards-and-low-code-apps)
- [Step 5: Link EPM entities to Views](#step-5-link-epm-entities-to-views)

## Step 1: Deploy the *DataMiner EPM Integration Training* package from the Catalog

1. Go to <https://catalog.dataminer.services/details/b661f936-d6e7-447c-baee-f0a5503e75b4>.

1. Deploy the Catalog item to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. Open DataMiner Cube and check whether the following items have been added to your DataMiner Agent:

   - A view named *EPM Training*

   - A **Frontend** element named *EPM Training FE*

   - Two **Backend** elements named *EPM Training BE 1* and *EPM Training BE 2*

   - Three **Collector** elements names *EPM Training Collector 1* and *EPM Training Collector 2* and *EPM Training Collector 3*

   - The **Topology app** in between the Surveyor and Activity module

> [!NOTE]
> If the Topology app does not show up right away, restart the Cube client.

![Cube sidebar with Topology app](~/user-guide/images/EPM_GS_step_1.png)

## Step 2: Create a new Collector element and rebalance system

1. Create a new **Collector** element in the EPM Training view called *EPM Training Collector 4* using the Skyline EPM Integration Training Collector protocol

   > [!NOTE]
   > If installed in a DMS cluster, create the Collector element on the same DMA as the EPM Training BE 2 element.

   ![Creation of new Collector element](~/user-guide/images/EPM_GS_step_2_1.png)

1. Copy the DMA ID/element ID of the newly created Collector element. Easiest way is to view the element's properties

   ![DMA ID/element ID in element properties](~/user-guide/images/EPM_GS_step_2_2.png)

1. Open the *EPM Training BE 2* (1) element and navigate to the *Configuration* visual page (2) and then the *Collectors* tab (3). Add the new Collector DMA ID/Element ID to the registration table by pasting the **Collector DMA ID/Element IDs** in the textbox and pressing the *SET* button (4). This will make the *EPM Training BE 2* element the parent manager of the *EPM Training Collector 4* element.

   ![Collectors tab back-end element](~/user-guide/images/EPM_GS_step_2_3.png)

1. Go to the front-end configuration by selecting the *Configuration* Topology Chain in the **Topology** app (1) then navigate to the *Configuration* visual page (2) and then the *Collectors* tab (3). Add the new **Collector DMA ID/Element ID** to the registration table the same way as the Backend element

   ![Collectors tab front-end element](~/user-guide/images/EPM_GS_step_2_4.png)

1. Navigate to the *General* visual page (1) and press the *Import* button (2) to initiate the front-end provisioning cycle.

   ![Import button on General page](~/user-guide/images/EPM_GS_step_2_5.png)

   The Manager connectors will now redistribute the load on the collectors, to prevent one element from having too much data.

1. To confirm whether this has been completed successfully, open the *EPM Training Collector 4* element and check whether the *Number Endpoints* parameter on the *General* page is filled in.

   ![Number Endpoints parameter](~/user-guide/images/EPM_GS_step_2_6.png)

## Step 3: Use EPM relations to filter out alarms

1. At this point, all of the collectors have pinged their endpoint devices and there are a lot of **Station** alarms created. This is caused because many of these **Stations** only have 1 **Endpoint** associated to them. You can filter these out to only show **Station** alarms where the issue is only present on the **Station**, and not an alarm on the **Hub** level, the parent entity.

1. Open the alarm template assigned to the *EPM Training FE* element. This can be done in the right click menu.

   ![Opening the alarm template from the context menu](~/user-guide/images/EPM_GS_step_3_1.png)

1. Navigate to the **Station** alarms, they should be all the way to the bottom. Take note of the row for *Percentage Unreachable Endpoints* and scroll all the way to the right. Under the conditions column, select that cell and *\<New>*

   ![Adding a new condition](~/user-guide/images/EPM_GS_step_3_2.gif)

1. Here we will be creating the relation to filter any *Station Unreachable Endpoints* alarms when the parent Hub is also in alarm for the same KPI. Name the relation *Hub Relation*. Under the condition filter, select the *Hub Overview Table: Percentage Unreachable Endpoints* parameter. Change the *Equal to* comparer to *Greater than* and in the *\<Click to select>* field we will put 24.9 so if the parent hub has more than or equal to 25% Unreachable Endpoints the Station alarm will be ignored.

   ![Alarm condition configuration](~/user-guide/images/EPM_GS_step_3_3.png)

1. click *OK* to save the condition and *OK* again to save the alarm template.

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
