---
uid: Enhanced_Services_tutorial
---

# Enhancing your service monitoring

In this tutorial you will learn how to enhance a television channel service to save time and simplify the monitoring experience.

The content and screenshots for this tutorial have been created using DataMiner 10.5.4.

Expected duration: 20 minutes.

> [!TIP]
> See also:
>
> - [Providing a customer-centric system view with services](xref:Service_tutorial).
> - [Kata #xx: Enhancing your service monitoring](https://community.dataminer.services/courses/kata-xx/) on DataMiner Dojo ![Video](~/user-guide/images/video_Duo.png).

## Prerequisites

- A DataMiner System that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

## Overview

This tutorial consists of the following steps:

- [Step 1: Deploy tutorial materials from the DataMiner Catalog](#step-1-deploy-tutorial-materials-from-the-dataminer-catalog)
- [Step 2: Duplicate an existing service and include an extra managed-object](#step-2-duplicate-an-existing-service-and-include-an-extra-managed-object)
- [Step 3: Enhance your service with a *Service Protocol*](#step-3-enhance-your-service-with-a-service-protocol)
- [Step 4: Leverage standard functionality, such as *templates* and *visuals*, within the enhanced service](#step-4-leverage-standard-functionality-such-as-templates-and-visuals-within-the-enhanced-service)
- [Step 5: Monitor your services using the *Dashboards* app](#step-5-monitor-your-services-using-the-dashboards-app)

## Step 1: Deploy tutorial materials from the DataMiner Catalog

1. Go to [Providing a customer-centric system view with services](https://catalog.dataminer.services/details/62840610-072c-4316-9e04-703f7688e857).

1. Deploy the package to your DataMiner Agent by clicking the *Deploy* button.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

When the package has been fully deployed, you will see the following view structure in the Surveyor in DataMiner Cube:

![Surveyor](~/user-guide/images/tutorial_services_step1_surveyor.png)

## Step 2: Duplicate an existing service and include an extra managed-object

1. In the Cube Surveyor, under the *TV Channels* view, right-click the *BBC News* service and select *Duplicate*.
1. On the *edit* page, change the *Name* to **BBC News Enhanced**.
1. Click Next.
1. On the *parameters* page, select the **ird-uk-lon-01** element and set the *Alias* field to **Site 1**.
1. Click *Add element*, add **ird-uk-lon-02**, and click *OK*.
1. Select the **ird-uk-lon-02** element and configure the following details:
    1. In the Alias field, specify **Site 2**.
    1. Uncheck the *All parameters* box and select the **Audio Output Level**.
1. Click *Create*.

At this point, you should have a service which contains to Sites. Take time to explore the available content.

![BBC News Enhanced service](~/user-guide/images/tutorial_enhanced_services_img01.png)

## Step 3: Enhance your service with a *Service Protocol*

1. Right-click the **BBC News Enhanced** service and click *edit*.
1. Under *Advanced*, set *Protocol* to *Generic Service Protocol Tutorial*.
1. Click apply.

You should now see that your service has been enhanced with additional data cards.

- General
- Alarms
- Elements
- General parameters

For example, the *Elements* card contains relevant information about the managed objects that are involved in the service, which is often used in centralized monitoring.

![BBC News Enhanced service - Elements card](~/user-guide/images/tutorial_enhanced_services_img02.png)

## Step 4: Leverage standard functionality, such as *templates* and *visuals*, within the enhanced service

1. Right-click the **BBC News Enhanced** service > *Protocols & Templates* and click *View available templates*
1. In the *Alarm* section, right-click and create a *New* template.
1. In the *new alarm template* screen, click *OK*.
1. Enable the monitoring of parameter *Monitor Active Alarms* and click *Apply*.
1. When prompted to link the new alarm template, click *Yes*.
1. Add the **BBC News Enhanced** service and click *Close*.

You should now see the *Monitor Active Alarms* parameter being monitored. Toggle the parameter to *Enabled* to see the alarms impacting the managed-objects associated with the service.

![BBC News Enhanced service - Alarms card](~/user-guide/images/tutorial_enhanced_services_img03.png).

Similarly, *Trend*, *Information*, and *Visual* templates can be created to enrich the functionality of the enhanced service.

## Step 5: Monitor your services using the *Dashboards* app

TBD.
