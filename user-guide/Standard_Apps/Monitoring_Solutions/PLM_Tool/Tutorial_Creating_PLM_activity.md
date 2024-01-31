---
uid: Tutorial_Creating_PLM_activity
---

# Creating a PLM activity

The DataMiner Planned Maintenance tool facilitates the scheduling and management of one-time or recurring maintenance events for the various resources and entities within a system. Through a unified interface, you can define system resources, schedule maintenance events, and observe historical maintenance records. Once you have defined resource types, scheduling maintenance events is only a few clicks away. For this, you will need to specify an event title, a resource and resource type, the start and end time, and the type of recurrence.

This tutorial will show how you can deploy and configure the PLM Solution and then create a PLM activity for a Windows server that is being monitored on a DMS via the Microsoft Platform protocol. The purpose of the activity is to schedule a maintenance window for upcoming Windows updates, so that alarm events during that window can be appropriately attributed to the maintenance event.

The content and screenshots for this tutorial were created in DataMiner version 10.4.2.

<!-- Expected duration: TBD -->

## Prerequisites

- A DataMiner System using DataMiner 10.3.6 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- A Low-Code Apps license.
- A user account with all [user-definable apps user permissions](xref:DataMiner_user_permissions#modules--user-definable-apps) enabled

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Deploy the Microsoft Platform protocol](#step-1-deploy-the-microsoft-platform-protocol)
- [Step 2: Create an element using the Microsoft Platform protocol](#step-2-create-an-element-using-the-microsoft-platform-protocol)
- [Step 3: Deploy the PLM package and configure the PLM element](#step-3-deploy-the-plm-package-and-configure-the-plm-element)
- [Step 4: Configure a PLM resource in the PLM app](#step-4-configure-a-plm-resource-in-the-plm-app)

## Step 1: Deploy the Microsoft Platform protocol

To create a planned maintenance activity, you first need an element that you can schedule the activity for. For this tutorial, a Microsoft Platform element is used. This will allow you to monitor the server used to host the DataMiner Agent. Before you can create this element, you first need to add the protocol to your DataMiner System.

> [!NOTE]
> If the Microsoft Platform protocol has already been deployed on your DataMiner System, you can skip this step and continue with [step 2](#step-2-create-an-element-using-the-microsoft-platform-protocol).

1. Look up the [Microsoft Platform connector in the Catalog](https://catalog.dataminer.services/details/connector/251).

1. Click the *Deploy* button to deploy the protocol to your DMA.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. [Open DataMiner Cube](xref:Opening_the_desktop_app) and go to *Apps* > *Protocols & Templates*.

1. Right-click the latest Microsoft Platform protocol version and select *Set as Production*.

   > [!TIP]
   > See also: [Promoting a protocol version to production version](xref:Promoting_a_protocol_version_to_production_version)

## Step 2: Create an element using the Microsoft Platform protocol

1. In DataMiner Cube, right-click the Surveyor and select *New* > *Element*.

1. Specify the following information:

   - Name: `DMA-Localhost`
   - Protocol: *Microsoft Platform*
   - Version: *Production*
   - IP address/host: `127.0.0.1` (for both connections)

     ![Microsoft Platform element configuration](~/user-guide/images/PLM_Tutorial_1.png)

1. Go to the *views* tab and select the view where you want to add the element.

1. Click *Create*.

1. Verify if the element is polling data correctly:

   1. Open the *DMA-Localhost* element.

   1. Navigate to the *DATA* > *Performance* > *Device Info* page.

   1. Check whether the value of the *Computer Name* parameter is filled in.

      ![Microsoft Platform element Computer Name parameter](~/user-guide/images/PLM_Tutorial_2.png)

## Step 3: Deploy the PLM package and configure the PLM element

1. Look up the [EPM PLM package in the Catalog](https://catalog.dataminer.services/details/package/5064).

1. Click the *Deploy* button to deploy the package to your DMA.

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item)

1. In DataMiner Cube, locate the *EPM PLM* element under the *EPM PLM* view.

1. Configure the settings of the element according to your preferences.

   > [!TIP]
   > See also: [Configuring the EPM PLM element](xref:Installing_PLM_tool#configuring-the-epm-plm-element)

## Step 4: Configure a PLM resource in the PLM app

To create a PLM activity, you will first need to configure a resource subscriber. In this case, this will be a resource that will allow you to create PLM activities for Windows servers that are monitored via the Microsoft Platform protocol.

1. Go to `http(s)://[DMA name]/root` and open the *EPM PLM* app.

   > [!TIP]
   > See also: [Accessing the PLM tool](xref:The_PLM_user_interface#accessing-the-plm-tool).

1. Click the cogwheel icon in the sidebar on the left to go to the *Configuration* page.

   ![PLM Configuration page](~/user-guide/images/PLM_Tutorial_7.png)

1. Scroll down and click the *Add Type* button.

1. In the *Type* box, enter `Windows Machine`, and click *OK*.

   ![Resource Types dialog](~/user-guide/images/PLM_Tutorial_8.png)

1. Scroll up and click the *Add Resource Subscriber* button.

1. In the dialog, fill in the information illustrated below, and click *OK*:

   ![Resource Subscriber configuration](~/user-guide/images/PLM_Tutorial_3.png)

   The PID 165 that you fill in here is the parameter ID of the *Computer Name* parameter of your Microsoft platform element. You can find this parameter ID by double-clicking the parameter in DataMiner Cube.

> [!TIP]
> For more info on configuring PLM resources, see [Configuring resources](xref:PLM_tool_configuring_resources).

## Step 5: Create a PLM activity

1. Click the pencil icon in the sidebar on the left to go to the *PLM instances* page.

1. In the top-left corner, click *Add*.

   ![Add PLM instance button](~/user-guide/images/PLM_Tutorial_4.png)

1. In the dialog, fill in the following information, and click *OK*:

   - *Title*: The name for the maintenance event, in this case `DMA Server Windows Updates`.
   - *Resource Type*: The resource you configured in the previous step, i.e. `Windows Machine`.
   - *Resource*: The value of the *Computer Name* parameter of the *DMA-Localhost* element you created in step 2.
   - *Start Time* and *End Time*: The start and end time of the maintenance window.
   - *Recurrence*: For the purpose of this tutorial, you can set this to *Once*, but you can also set this to a daily, weekly, or monthly interval. In that case, you will also need to fill in the *Range of Recurrence*, i.e. the start and end date of the recurrence.

   ![PLM instance configuration](~/user-guide/images/PLM_Tutorial_5.png)

A new row will now be added to the PLM overview table. This indicates that you have successfully created the activity.

![Overview table](~/user-guide/images/PLM_Tutorial_6.png)

> [!TIP]
> For more info on configuring PLM activities, see [Configuring maintenance events](xref:Adding_maintenance_event).
