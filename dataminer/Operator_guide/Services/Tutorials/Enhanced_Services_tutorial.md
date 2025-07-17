---
uid: Enhanced_Services_tutorial
---

# Enhancing your service monitoring

In this tutorial, you will learn how to enhance a television channel service to save time and simplify monitoring. You will improve an existing service using a service protocol, adding value to operations. Additionally, you will learn how to access service data from web apps.

The content and screenshots for this tutorial have been created using DataMiner 10.5.4.

Expected duration: 20 minutes.

> [!TIP]
> See also: [Kata #64: Enhancing your service monitoring](https://community.dataminer.services/courses/kata-64/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png).

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy tutorial materials from the Catalog](#step-1-deploy-tutorial-materials-from-the-catalog)
- [Step 2: Duplicate an existing service and include an extra managed object](#step-2-duplicate-an-existing-service-and-include-an-extra-managed-object)
- [Step 3: Enhance your service with a service protocol](#step-3-enhance-your-service-with-a-service-protocol)
- [Step 4: Configure an alarm template for the service](#step-4-configure-an-alarm-template-for-the-service)
- [Step 5: Visualize standard service data in a dashboard](#step-5-visualize-standard-service-data-in-a-dashboard)
- [Step 6: Visualize enhanced service data in your dashboard](#step-6-visualize-enhanced-service-data-in-your-dashboard)
- [Step 7: Visualize data for managed objects from a service perspective in your dashboard](#step-7-visualize-data-for-managed-objects-from-a-service-perspective-in-your-dashboard)

## Step 1: Deploy tutorial materials from the Catalog

1. Go to [Providing a customer-centric system view with services](https://catalog.dataminer.services/details/62840610-072c-4316-9e04-703f7688e857) in the Catalog.

1. Deploy the package to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

When the package has been fully deployed, you will see the following view structure in the Surveyor in DataMiner Cube:

![Surveyor](~/dataminer/images/tutorial_services_step1_surveyor.png)

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

![BBC News Enhanced service](~/dataminer/images/tutorial_enhanced_services_img01.png)

## Step 3: Enhance your service with a service protocol

1. Right-click the *BBC News Enhanced* service and click *Edit*.

1. Expand the *Advanced* section and set *Protocol* to *Enhanced Service Tutorial*.

1. Click *Apply*.

You should now see that your service has been enhanced with additional data cards:

- General
- Alarms
- Elements
- General parameters

For example, the *Elements* card contains relevant information about the managed objects that are involved in the service, which is often used in centralized monitoring.

![BBC News Enhanced service - Elements card](~/dataminer/images/tutorial_enhanced_services_img02.png)

> [!NOTE]
> If you intend to develop your own service protocol, we recommend using [Skyline Service Definition Basic](https://catalog.dataminer.services/details/809251d6-724d-499a-9c3c-d41ae1b5492b) as your starting point. This connector already includes many of the standard features required to enhance a service.

## Step 4: Configure an alarm template for the service

1. Right-click the *BBC News Enhanced* service in the Surveyor and select *Protocols & Templates* > *View available templates*.

   This will open the Protocols & Templates module and immediately select the service protocol in the module.

1. In the *Alarm* section, right-click and select *New* to create a new alarm template for the service protocol.

   This will open a pop-up window.

1. In the pop-up window, specify a name of your choice (e.g. *Service Tutorial*) and click *OK*.

1. Select *Monitor Active Alarms* and click *Apply*.

1. When prompted to link the new alarm template, click *Yes*.

1. Add the *BBC News Enhanced* service and click *Close*.

You should now see the *Monitor Active Alarms* parameter being monitored. Toggle the parameter to *Enabled* to see the alarms impacting the managed objects associated with the service.

![BBC News Enhanced service - Alarms card](~/dataminer/images/tutorial_enhanced_services_img03.png)

In a similar way, you can also create [trend templates](xref:About_trend_templates) and [information templates](xref:Information_templates) to enrich the functionality of the enhanced service. In the same Protocols & Templates module, you can also add a [custom Visio file](xref:Managing_Visio_files_linked_to_protocols) to customize the visuals for your service.

## Step 5: Visualize standard service data in a dashboard

1. Create a new dashboard:

   1. In *Cube*, go to *Apps* > *Web Apps* and click *Dashboards*.

   1. If you are not logged in yet, log in using the same credentials as for Cube.

   1. In the Dashboards app, click on the *...* button at the top of the pane on the left and select *Create dashboard*.

   1. In the *Name* field, specify `Visualize service data`, and click *Create*.

      You should now have an empty dashboard where you can add the service data.

1. In the *Data* pane on the right, expand *Queries* and click the + button to add a new query.

1. Configure your new query as follows:

   1. Specify the name *Get standard service*.

   1. Select the data source *Get services*.

   1. Select the operator *Select*, and then select the columns *Name* and *Alarm state*.

   1. Click the pencil icon at the top of the query to finish the configuration.

1. Drag the *Get standard service* query onto the dashboard.

1. In the component, click the button next to *Pick a visualization* and select the *Table* visualization.

1. Drag the edges of the component to adjust the table size until as much data as possible is shown.

1. With the table selected, go to the *Layout* pane on the right, and set *Title* to `Standard Service Data`.

You should now have a table displaying the name of all the services in your system and their respective alarm state.

![Standard Service Data table](~/dataminer/images/tutorial_enhanced_services_img04.png).

## Step 6: Visualize enhanced service data in your dashboard

1. In the *Data* pane, click the + button below *Queries* to add another new query.

1. Configure your new query as follows:

   1. Specify the name *Get enhanced service*.

   1. Select the data source *Get parameters for elements where*.

   1. Select the type *Protocol* > *Enhanced Service Tutorial*.

   1. Select the parameter *Service element status*.

   1. Add the operator *Select*.

   1. Make sure the following columns are selected: *Alias*, *Element Name*, *Severity*, *State*, *Critical*, *Major*, *Minor*, *Warning*, *Element ID*, and *Service Name*.

   1. Click the pencil icon at the top of the query to finish the configuration.

1. Drag the *Get enhanced service* query onto the dashboard.

1. Select the *Table* visualization like before.

1. Adjust the table size to fit the data to the best extent possible.

1. With the table selected, go to the *Layout* pane on the right, and set *Title* to `Enhanced Service Data`.

You should now have a table displaying the information about the managed objects (i.e. elements) for the services in your system.

![Enhanced Service Data table](~/dataminer/images/tutorial_enhanced_services_img05.png).

## Step 7: Visualize data for managed objects from a service perspective in your dashboard

In this final step, you will have the dashboard retrieve data directly from the managed objects included your enhanced services. This way you can use the dashboard for a service-focused monitoring approach.

1. Add another query and configure it as follows:

   1. Specify the name *Get managed-object data*.

   1. Select the data source *Get parameters for elements where*.

   1. Select the type *Protocol* > *Philips DVS3810*.

   1. Select the parameter *Audio Output Level*.

   1. Add the operator *Filter*.

   1. Select the column *Element ID*.

   1. Select the filter method *Regex*.

   1. Click the link icon next to the *Value* box.

   1. In the *Link to* panel, configure the fields as follows and then click *Link*:

      - Data: *Table 2*
      - Type: *Tables*
      - Property: *Element ID*

   1. Click the pencil icon at the top of the query to finish the configuration.

1. Drag the *Get managed-object data* query onto the dashboard.

1. Select the *Table* visualization like before.

1. Adjust the table size to fit the data to the best extent possible.

1. With the table selected, go to the *Layout* pane on the right, and set *Title* to `Managed-Object Data`.

You should now have a table displaying the information from the managed objects of all the services in your system, with the ability to filter using a service-centric approach.

![Visualize managed-object data using a service-centric approach](~/dataminer/images/tutorial_enhanced_services_img06.png).
