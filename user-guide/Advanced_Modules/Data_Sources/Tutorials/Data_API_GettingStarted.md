---
uid: Data_Sources_Tutorials_GettingStarted
---

# Creating a scripted connector

This tutorial will teach you how to create your first scripted connector with Python.

The content and screenshots for this tutorial were created in DataMiner version 10.4.2.

Expected duration: 15 minutes

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

![Admin](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_1.png)

![Nodes Installer](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_2.png)

> [!TIP]
> See also: [Installing the necessary DxMs](xref:Data_Sources_Setup#installing-the-necessary-dxms)

## Step 2: Create a scripted connector

1. To open the Data Sources module, navigate to `https://<dmaip>/data-sources/`.

1. Click *Create Data Source*.

   ![Create New](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_3.png)

1. Go to the [SLC-SC-Example_ScriptedConnectors GitHub repository](https://github.com/SkylineCommunications/SLC-SC-Example_ScriptedConnectors) and copy the Amsterdam Internet Exchange Python example.

   ![Copy Github](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_4.png)

1. In the Data Sources module, paste the example code in the code editor window and finish configuring the data source.

   ![Final DataSource](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_5.png)

## Step 3: View your data source

1. [Open DataMiner Cube](xref:Using_the_desktop_app) and locate your newly created element in the Surveyor.

1. Verify that your newly created element is being populated with data.

   ![New Element](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_6.png)
