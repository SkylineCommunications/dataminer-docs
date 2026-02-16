---
uid: Tutorial_Apps_Ping_Monitoring_App
---

# Getting started with the Ping Monitoring tool

In this tutorial, you will learn how to use the Ping Monitoring tool for network monitoring and diagnostics.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.8 and Ping Monitoring version 1.0.1-CU12.

> [!TIP]
> See also: [Kata #47: Monitor a network with ping commands](https://community.dataminer.services/courses/kata-47/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System using DataMiner 10.3.9-CU2 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Your dataminer.services [organization has been verified](xref:CloudConnectionVerification).

## Overview

- [Step 1: Deploy the Ping Monitoring package from the Catalog](#step-1-deploy-the-ping-monitoring-package-from-the-catalog)
- [Step 2: Create a new group](#step-2-create-a-new-group)
- [Step 3: Create a new destination](#step-3-create-a-new-destination)
- [Step 4: Analyze the results](#step-4-analyze-the-results)
- [Step 5: Filter and access destination details](#step-5-filter-and-access-destination-details)
- [Step 6: Delete the destinations](#step-6-delete-the-destinations)

## Step 1: Deploy the Ping Monitoring package from the Catalog

1. Look up the [Ping Monitoring](https://catalog.dataminer.services/details/cb1bd962-97a5-461b-80fd-a62b3799de96) package in the Catalog.

1. Click the *Deploy* button.

   > [!TIP]
   > See [Deploying a Catalog item](xref:Deploying_a_catalog_item).

1. Go to the root page of your DataMiner System and check if the tool has been added:

   ![DMS root page](~/dataminer/images/DMAroot-PingMonitoring.png)

   If you do not know where to find the home page URL, open <https://dataminer.services/> in a browser, and copy the URL or click the *Home* button.

   ![dataminer.services](~/dataminer/images/dataminerservices-PingMonitoring.png)

1. Open the Ping Monitoring tool.

   This is what the application will look like:

   ![Ping Monitoring UI](~/dataminer/images/brand_new_destinations-PingMonitoring.png)

> [!TIP]
> See also: [Ping Monitoring UI overview](xref:Ping_Monitoring_UI)

## Step 2: Create a new group

Groups are used to organize the destinations configured in the application. Destinations that belong to the same group share the same properties that differentiate them from other destinations.

1. In the Ping Monitoring tool, go to the *Groups* page.

1. In the header bar, click *Create Group*.

   This will open a pop-up window.

1. Enter group name *Demo*, then click *Next*.

1. Populate the three property fields with the values `Americas`, `Gold`, and `CustomerXYZ`, respectively, and then click *Next*.

1. Set the interval to `60`.

1. Click *Save*.

![new group](~/dataminer/images/Create_New_Group-PingMonitoring.gif)

## Step 3: Create a new destination

A destination is a point in the network you want to test against. The Ping Monitor application allows you to easily manage hundreds and even thousands of destinations to monitor the availability of different devices and services in your network.

In this step, you will create three destinations using the following addresses accessible on the public internet. The first value corresponds with the address, and the second is the description:

- 8.8.8.8 (Google DNS)
- skyline.be (Skyline website)
- dataminer.services (DataMiner Services)

Carry out the following steps for each one of the destinations above:

1. In the Ping Monitoring tool, go to the *Destinations* page.

1. In the header bar, click *Add Destination*.

1. Select the *Demo* group.

1. Specify the address and description in the corresponding boxes.

1. Click *Add Destination*.

![new destination](~/dataminer/images/Create_New_Destination-PingMonitoring.gif)

> [!TIP]
> See also: [Adding a new destination](xref:Ping_Monitoring_managing_groups_destinations#adding-a-new-destination).

## Step 4: Analyze the results

When you have configured the destinations, the application will update to display the results of the latest test cycles.

1. In the *Destinations* table, take a look at the values in the following columns:

   - *Ping Result*: The amount of time passed from the moment DataMiner sent the command to the moment it received the reply from each destination, e.g., *4 ms*.
   - *Cycle packet loss*: The percentage of lost packets during the last ping cycle, e.g., *0.00 %*. By default, the application sends 4 packets in every cycle, configurable for each destination.

   These values can help you monitor network congestion and detect outages.

1. If you are a member of the DevOps Program, take a screenshot of the *Destinations* table (similar to the one below), ensuring all columns are clearly visible, and upload it on the [Kata page on DataMiner Dojo](https://community.dataminer.services/courses/kata-47/).

   ![destinations](~/dataminer/images/destinations-PingMonitoring.png)

> [!TIP]
> For more ideas, see [Ping Monitoring Use Cases - DataMiner Dojo](https://community.dataminer.services/use-case/ping-monitoring/).

## Step 5: Filter and access destination details

1. In the app, go to the *Grid View* page.

   This page shows all the active destinations sorted by cycle packet loss.

1. In the panel on the left, under *Destination Address*, select *skyline.be*.

   This will filter out all other destinations in the grid.

1. Click the destination tile in the grid to open its details.

   The details will be shown on the right, including host information, results, and settings.

1. Close the panel on the right with the *Close* button near the top-right corner.

![filtering and details](~/dataminer/images/Filter_Details-PingMonitoring.gif)

## Step 6: Delete the destinations

To finalize this tutorial, delete each of the destinations you have created as follows:

1. On the *Destinations* page, click the garbage can icon next to the destination.

1. Click *Next* to permanently delete the destination.

![delete destination](~/dataminer/images/Delete_Destination-PingMonitoring.gif)

> [!TIP]
> See also: [deleting a destination](xref:Ping_Monitoring_managing_groups_destinations#deleting-a-destination).
