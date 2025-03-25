---
uid: Enhanced_Services_tutorial
---

# Enhancing your service monitoring

In this tutorial, you will learn how to enhance a television channel service to save time and simplify monitoring. You will improve an existing service using a service protocol, adding value to operations. Additionally, you will learn how to access service data from web apps.

The content and screenshots for this tutorial have been created using DataMiner 10.5.4.

Expected duration: 20 minutes.
<!-- 
> [!TIP]
> See also: [Kata #XX: Enhancing your service monitoring](https://community.dataminer.services/courses/kata-xx/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png).
 -->
## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy tutorial materials from the DataMiner Catalog](#step-1-deploy-tutorial-materials-from-the-dataminer-catalog)
- [Step 2: Duplicate an existing service and include an extra managed object](#step-2-duplicate-an-existing-service-and-include-an-extra-managed-object)
- [Step 3: Enhance your service with a service protocol](#step-3-enhance-your-service-with-a-service-protocol)
- [Step 4: Leverage standard functionality, such as templates and visuals, within the enhanced service](#step-4-leverage-standard-functionality-such-as-templates-and-visuals-within-the-enhanced-service)
- [Step 5: Monitor your services using the Dashboards app](#step-5-monitor-your-services-using-the-dashboards-app)

## Step 1: Deploy tutorial materials from the DataMiner Catalog

1. Go to [Providing a customer-centric system view with services](https://catalog.dataminer.services/details/62840610-072c-4316-9e04-703f7688e857) in the DataMiner Catalog.

1. Deploy the package to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

When the package has been fully deployed, you will see the following view structure in the Surveyor in DataMiner Cube:

![Surveyor](~/user-guide/images/tutorial_services_step1_surveyor.png)

## Step 2: Duplicate an existing service and include an extra managed object

1. In the Cube Surveyor, under the *TV Channels* view, right-click the *BBC News* service and select *Duplicate*.

1. On the *edit* page, change the name to `BBC News Enhanced`, and click *Next*.

1. On the *parameters* page, select the *ird-uk-lon-01* element and set the *Alias* field to `Site 1`.

1. Click *Add element*, add *ird-uk-lon-02*, and click *OK*.

1. Select the *ird-uk-lon-02* element and configure the following details:

   1. Set the alias to `Site 2`.

   1. Clear the *All parameters* checkbox and select *Audio Output Level*.

1. Click *Create*.

At this point, you should have a service that contains two sites. Take your time to explore the available content.

![BBC News Enhanced service](~/user-guide/images/tutorial_enhanced_services_img01.png)

## Step 3: Enhance your service with a service protocol

1. Right-click the *BBC News Enhanced* service and click *edit*.

1. Expand the *Advanced* section and set *Protocol* to *Enhanced Service Tutorial*.

1. Click *Apply*.

> [!NOTE]
> If you intend to develop your own service protocol, we recommend using [Skyline Service Definition Basic](https://catalog.dataminer.services/details/809251d6-724d-499a-9c3c-d41ae1b5492b) as your starting point. This connector already includes many of the standard features required to enhance a service.

You should now see that your service has been enhanced with additional data cards.

- General
- Alarms
- Elements
- General parameters

For example, the *Elements* card contains relevant information about the managed objects that are involved in the service, which is often used in centralized monitoring.

![BBC News Enhanced service - Elements card](~/user-guide/images/tutorial_enhanced_services_img02.png)

## Step 4: Leverage standard functionality, such as templates and visuals, within the enhanced service

1. Right-click the **BBC News Enhanced** service > *Protocols & Templates* > click *View available templates*
1. In the *Alarm* section, right-click and create a *New* template.
1. In the *new alarm template* screen, click *OK*.
1. Select *Monitor Active Alarms* and click *Apply*.
1. When prompted to link the new alarm template, click *Yes*.
1. Add the **BBC News Enhanced** service and click *Close*.

You should now see the *Monitor Active Alarms* parameter being monitored. Toggle the parameter to *Enabled* to see the alarms impacting the managed-objects associated with the service.

![BBC News Enhanced service - Alarms card](~/user-guide/images/tutorial_enhanced_services_img03.png)

Similarly, *Trend*, *Information*, and *Visual* templates can be created to enrich the functionality of the enhanced service.

## Step 5: Monitor your services using the Dashboards app

### Step 5.1: Visualize standard service data in *Dashboards*

1. Create a new dashboard:

   1. In *Cube*, go to *Apps* > *Web Apps* and click *Dashboards*.

   1. If you are not logged in yet, log in using the same credentials as for Cube.

   1. In the Dashboards app, click on the *...* button at the top of the pane on the left and select *Create dashboard*.

   1. In the *Name* field, specify `Visualize service data`, and click *Create*.

      You should now have an empty dashboard. Let's learn how to get service data.

1. On the right-side panel, go to *Queries* and *Add* (+) and new query with the following configuration:
   1. Name: *Get standard service*.
   1. Select data sources: *Get services*.
   1. Select operator: *Select* > *Name* and *Alarm state*.
1. Click *Done* using the pencil icon.
1. Drag the *Get standard service* query into the dashboard.
1. In *Visualizations*, select the *Table*.
1. Adjust the table size to fit the data to the best extend possible.
1. With the table selected, on the right-side panel > Layout, set *Title* to *Standard Service Data*.

You should now have a table displaying the name of all the service in your system and their respective alarm state.

![Get Service Data table](~/user-guide/images/tutorial_enhanced_services_img04.png).

### Step 5.2: Visualize enhanced service data in *Dashboards*

1. Add a new query with the following configuration:
   1. Name: *Get enhanced service*.
   1. Select data source: *Get parameters for elements where*.
   1. Type: *Protocol* > *Service Definition Tutorial*.
   1. Parameters: Check *Service element status*.
   1. Operator: *Select*.
   1. Columns: *Alias*, *Element Name*, *Severity*, *State*, *Critical*, *Major*, *Minor*, *Warning*, *Element ID*, *Service Name*.
1. Click "Done".
1. Drag the *Get enhanced service* query into the dashboard.
1. In *Visualizations*, select *Table*.
1. Adjust the table size to fit the data to the best extend possible.
1. With the table selected, on the right-side panel > Layout, set *Title* to *Enhanced Service Data*.

You should now have a table displaying the information about the managed-objects (elements) for the services in your system.

![Get Enhanced Service Data table](~/user-guide/images/tutorial_enhanced_services_img05.png).

### Step 5.3: Visualize managed-objects data from a service perspective in *Dashboards*

In this step, we will see how to retrieve data directly from the managed-objects (elements) included in an enhanced service. This is rather useful as it provides a way to build a service-focused monitoring strategy.

1. Add a new query with the following configuration:
   1. Name: *Get managed-object data*
   1. Select data source: *Get parameters for elements where*.
   1. Type: *Protocol*.
   1. Protocol: *Philips DVS3810*.
   1. Parameters: *Audio Output Level*.
   1. Select operator: *Filter*.
   1. Column: *Element ID*.
   1. FIlter method: *Regex*.
   1. Value: Click on *Link to data* and select:
      1. Data: *Table 2*
      1. Type: *Tables*
      1. Property: *Element ID*
      1. Click *Link*
   1. Click *Done*.
1. Drag the *Get managed-object data* query into the dashboard.
1. In *Visualizations*, select *Table*.
1. Adjust the table size to fit the data to the best extend possible.
1. With the table selected, on the right-side panel > Layout, set *Title* to *Managed-object Data*.

You should now have a table displaying the information from the managed-objects (elements) for all the services in your system and the ability to filter using a service-centric approach.

![Visualize managed-object data using a service-centric approach](~/user-guide/images/tutorial_enhanced_services_img06.png).

Congratulations!
