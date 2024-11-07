---
uid: Tutorial_Apps_Ping_Monitoring_App
---

# Getting started with the Ping Monitoring tool

In this tutorial, you will learn how to use the Ping Monitoring tool for network monitoring and diagnostics.

Expected duration: 15 minutes

> [!NOTE]
> The content and screenshots for this tutorial have been created using DataMiner version 10.4.8 and Ping Monitoring version 1.0.1-CU12.

## Prerequisites

- A DataMiner System using DataMiner 10.3.9-CU2 or higher, which is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).
- Your dataminer.services [organization has been verified](xref:CloudConnectionVerification).

## Overview

- [Step 1: Deploy the Ping Monitoring package from the Catalog](#step-1-deploy-the-ping-monitoring-package-from-the-catalog)
- [Step 2: Create a new group](#step-2-create-a-new-group)
- [Step 3: Create a new destination](#step-3-create-a-new-destination)
- [Step 4: Analyze the results](#step-4-analyze-the-results)
- [Step 5: Filter and access destination details](#step-5-filter-and-access-destination-details)
- [Step 6: Delete a destination](#step-6-delete-a-destination)

## Step 1: Deploy the Ping Monitoring package from the Catalog

1. Look up the [Ping Monitoring](https://catalog.dataminer.services/details/cb1bd962-97a5-461b-80fd-a62b3799de96) package in the DataMiner Catalog.

1. click the *Deploy* button.

   > [!TIP]
   > See [Deploying a Catalog item](xref:Deploying_a_catalog_item).

1. Go to the root page of your DataMiner System and check if the tool has been added:

   ![DMS root page](~/user-guide/images/DMAroot-PingMonitoring.png)

   If you do not know where to find the homepage URL, open <https://dataminer.services/> in a browser, and copy the URL or click the *Home* button.

   ![dataminer.services](~/user-guide/images/dataminerservices-PingMonitoring.png)

1. Open the Ping Monitoring tool.

   This is what the application will look like:

   ![Ping Monitoring UI](~/user-guide/images/brand_new_destinations-PingMonitoring.png)

> [!TIP]
> See also: [Ping Monitoring UI overview](xref:Ping_Monitoring_UI)

## Step 2: Create a new group

Groups are used to organize the destinations configured in the application. Destinations that belong to the same group share the same properties that differentiate them from other destinations.

1. In the Ping Monitoring tool, go to the *Groups* page.

1. In the header bar, click *Create Group*.

   This will open a pop-up window.

1. 

![new group](~/user-guide/images/Create_New_Group-PingMonitoring.gif)

## Step 3: Create a new destination

A destination is a point in the network you want to test against. The Ping Monitor application allows you to easily manage hundreds and even thousands of destinations to monitor the availability of different devices and services in your network. See [adding a new destination](xref:Ping_Monitoring_managing_groups_destinations#adding-a-new-destination).

1. Create one or more destinations using IP addresses or hostnames accessible on the public internet, such as 8.8.8.8 (Google DNS)

![new destination](~/user-guide/images/Create_New_Destination-PingMonitoring.gif)

## Step 4: Analyze the results

After configuring your destination(s), the application will update to display the results of the latest test cycles.

1. Capture a screenshot of the Destinations table (similar to the one below), ensuring all columns are clearly visible.

> [!IMPORTANT]
> Assignment:
> Upload the screenshot to earn points for having completed this exercise. Additional points are awarded if participants manage to complete the challenge within the week.

Pay special attention to the value in the following columns:

**Ping Result:** The amount of time passed from the moment DataMiner sent the command to the moment it received the reply from each destination, e.g., 4 ms_.
**Cycle packet loss**: The percentage of lost packets during the last ping cycle, e.g., 0.00 %. By default, the application sends 4 packets in every cycle, configurable for each destination.

These values can help you monitor network congestion and detect outages. For more ideas, see [Ping Monitoring Use Cases - DataMiner Dojo](https://community.dataminer.services/use-case/ping-monitoring/).

![destinations](~/user-guide/images/destinations-PingMonitoring.png)

## Step 5: Filter and access destination details

1. Open the Grid View, which shows all the active destinations sorted by cycle packet loss.
1. Use the filter panel to the left of the grid to look for specific destinations.
1. Click on any destination to open its details, which include Host Information, Results, and Settings.

![filtering and details](~/user-guide/images/Filter_Details-PingMonitoring.gif)

## Step 6: Delete a destination

To finalize this tutorial, you will delete one or more of the destinations you created. Please take a look at [deleting a destination](xref:Ping_Monitoring_managing_groups_destinations#deleting-a-destination) if you have questions on how to do so.

![delete destination](~/user-guide/images/Delete_Destination-PingMonitoring.gif)
