---
uid: Data_Sources_Tutorials_GettingStarted
---

# Creating a scripted connector

This tutorial will teach you how to create your first scripted connector with Python.

Using example code, you will create a scripted connector that connects to the Amsterdam Internet Exchange (AMS) and collects traffic data from some of its available locations. This will give you real-life data illustrating how the Data Sources module works.

The content and screenshots for this tutorial were created in DataMiner version 10.4.2.

Expected duration: 15 minutes.

> [!TIP]
> See also: [Kata #18: Creating a scripted connector](https://community.dataminer.services/courses/kata-18/) on DataMiner Dojo ![Video](~/dataminer/images/video_Duo.png)

## Prerequisites

- A DataMiner System using DataMiner 10.4.0/10.4.2 or higher that is [connected to dataminer.services](xref:Connecting_your_DataMiner_System_to_the_cloud).

- Depending on your DataMiner version, you may need to [enable the DataAPI soft-launch option](xref:Activating_Soft_Launch_Options).

> [!NOTE]
> If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), these prerequisites are automatically met.

## Overview

- [Step 1: Set up your system](#step-1-set-up-your-system)
- [Step 2: Create a scripted connector](#step-2-create-a-scripted-connector)
- [Step 3: View your Data Source](#step-3-view-your-data-source)

## Step 1: Set up your system

Navigate to <https://admin.dataminer.services/> and deploy the latest version of the *DataAPI* and *DataAggregator* DxMs.

![Admin](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_1.png)

![Nodes Installer](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_2.png)

> [!TIP]
> See also: [Installing the necessary DxMs](xref:Data_Sources_Setup#installing-the-necessary-dxms)

## Step 2: Create a scripted connector

1. Open the Data Sources module:

   - In DataMiner Cube, click *Apps* in the sidebar to the left and select *Data Sources*, or

   - Navigate to `https://<dmaip>/data-sources/` using any modern browser.

1. Click *Create Data Source*.

   ![Create New](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_3.png)

1. Configure the *Data source name* field with an identifiable name (e.g., AMS) and ensure the *Type* is set to **Python**.

   ![Basic Settings](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_3_1.png)

1. Go to the [SLC-SC-Example_ScriptedConnectors GitHub repository](https://github.com/SkylineCommunications/SLC-SC-Example_ScriptedConnectors) and copy the Amsterdam Internet Exchange Python example.

   ![Copy Github](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_4.png)

1. In the Data Sources module, paste the example code in the code editor window and click the *Create* button.

   ![Final DataSource](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_5.png)

The scripted connector you have just created will now be automatically configured to run every minute. It will collect traffic data and send it to DataMiner via the Data API.

When the scripted connector is first executed, an element named `ams-ix.net` will automatically be created.

## Step 3: View your data source

1. [Open DataMiner Cube](xref:Connecting_to_a_DMA_with_Cube) and locate the newly created element in the Surveyor.

1. Verify that the element is being populated with data.

   ![New Element](~/dataminer/images/Data_Sources_Tutorials_GettingStarted_6.png)
