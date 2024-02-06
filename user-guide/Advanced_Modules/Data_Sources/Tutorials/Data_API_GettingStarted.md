---
uid: Data_Sources_Tutorials_GettingStarted
---

# Creating a scripted connector

Explore the brand new Data Sources module, designed to revolutionize how you access and retrieve data from diverse sources, across hardware, software, and cloud services.

This tutorial will teach you how to create your first scripted connector with Python and unleash that limitless opportunities to bring your data to DataMiner.

The content and screenshots for this tutorial were created in DataMiner version 10.4.2.

Expected duration: 15 minutes

## Overview
* [Step 1: Initial Setup](#step-1-initial-setup)
* [Step 2: Create your Scripted Connector](#step-2-create-your-scripted-connector)
* [Step 3: View your Data Source](#step-3-view-your-data-source)

## Step 1: Initial Setup
1. Your Development/Staging environment running DataMiner 10.4.2 or a [DaaS system](xref:Creating_a_DMS_in_the_cloud)
   
   ![DaaS](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_0.png)
1. Navigate to: https://admin.dataminer.services/ and install DataAPI and DataAggregator DxMs

   ![Admin](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_1.png)

   ![Nodes Installer](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_2.png)
1. Configure [DataAPI soft-launch option](xref:Overview_of_Soft_Launch_Options#dataapi) in your system.
   You can read more about how to activating soft-launch options here [Activating soft-launch options](xref:Activating_Soft_Launch_Options)
   > [!NOTE]
   > If you use a [DaaS system](xref:Creating_a_DMS_in_the_cloud), the soft-launch flag is automatically configured.

## Step 2: Create your Scripted Connector
1. Navigate to `https://<dmaip>/data-sources/`
1. Click to **Create Data Source**

   ![Create New](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_3.png)
1. From this [GitHub repository](https://github.com/SkylineCommunications/SLC-SC-Example_ScriptedConnectors) copy the
   Amsterdam Internet Exchange python example

   ![Copy Github](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_4.png)
1. Paste the example code in the code editor window and finish configure the Data Source

   ![Final DataSource](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_5.png)

## Step 3: View your Data Source
1. [Open DataMiner Cube](xref:Opening_the_desktop_app) and in the surveyor locate your newly created element
1. Verify your newly created element is being populated with data

   ![New Element](~/user-guide/images/Data_Sources_Tutorials_GettingStarted_6.png)
