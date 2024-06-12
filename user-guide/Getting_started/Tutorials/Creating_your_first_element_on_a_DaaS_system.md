---
uid: Creating_your_first_element_on_a_DaaS_system
---

# Creating your first element on a DaaS system

This tutorial guides you through setting up a free DataMiner Community Edition system as a service and creating your first Skyline Generic Ping element. With this element, you will be able to monitor a website of your choice.

The content and screenshots for this tutorial have been created in DataMiner version 10.4.6.

Estimated duration: 15 minutes

## Prerequisites

- You must be a member of an [organization](xref:Pricing_Usage_based_service#organization).

## Overview

The tutorial consists of the following steps:

- [Step 1: Create a staging DataMiner System in the cloud](#step-1-create-a-staging-dataminer-system-in-the-cloud)
- [Step 2: Deploy the 'Generic Ping' protocol from the Catalog](#step-2-deploy-the-generic-ping-protocol-from-the-catalog)
- [Step 3: Install the DataMiner Cube desktop application](#step-3-install-the-dataminer-cube-desktop-application)
- [Step 4: Access your newly created DaaS system for the first time](#step-4-access-your-newly-created-daas-system-for-the-first-time)d
- [Step 5: Create an element to monitor a website of your choice](#step-5-create-an-element-to-monitor-a-website-of-your-choice)

## Step 1: Create a staging DataMiner System in the cloud

Deploy a [DataMiner Community Edition system as a service](xref:Pricing_Commercial_Models#dataminer-community-edition). This system will be free for the first 7 days.

> [!NOTE]
> To keep using this DataMiner System after the initial 7 days, move to the standard [usage-based services](xref:Pricing_Commercial_Models#usage-based-services) by [purchasing DataMiner credits](xref:Order_DataMiner_credits).

1. Log on to [dataminer.services](https://dataminer.services).

1. Next to *DataMiner Systems*, click *+ Add DataMiner System*.

   ![Add DataMiner System](~/user-guide/images/Add_DataMiner_System.png)

1. Click *DataMiner as a Service*.

   ![DataMiner as a Service](~/user-guide/images/DataMiner_as_a_Service.png)

1. Specify the following information:

   - Select the *Organization* under which you want to register the DataMiner System.

   - Enter a *DataMiner System Name* of your choice.

   - Enter a custom *DataMiner System URL* if you want the URL to be different from the *DataMiner System Name*.

   - Enter a username and password for your DataMiner account.

1. Select the box next to *I agree to the terms of service*.

1. Click *Deploy*.

> [!TIP]
> See also: [Creating a new DMS on dataminer.services](xref:Creating_a_DMS_on_dataminer_services)

## Step 2: Deploy the 'Generic Ping' protocol from the Catalog

Now that you have set up your staging DataMiner System, add the *Generic Ping* protocol (also known as connector), through which your element will communicate with your DMA.

1. Look up the [*Generic Ping* connector](https://catalog.dataminer.services/details/253977dd-efa6-4095-b22e-de9adb9cc23d) in the DataMiner Catalog.

1. Go to the *Versions* tab.

1. Click the sideward arrow next to *3.1.2.14* and select *Deploy*.

   ![Deploy Generic Ping connector](~/user-guide/images/Generic_Ping_Connector.png)

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

## Step 3: Install the DataMiner Cube desktop application

To access and interact with your new DataMiner System, install DataMiner Cube, the main DataMiner client application.

> [!NOTE]
> If DataMiner Cube is already installed, proceed to the next step.

1. Go to [dataminer.services](https://dataminer.services).

1. Select *Desktop installation* in the top-right corner of the dataminer.services home page and run the downloaded file.

1. In the installation window, open the *Options* section:

   - Add a shortcut to the desktop and start menu.

   - Optionally, allow DataMiner Cube to start with Windows.

1. Click *Install*.

## Step 4: Access your newly created DaaS system for the first time

Now that you have installed DataMiner Cube, you can use it to access your new DaaS system.

1. Go to [dataminer.services](https://dataminer.services).

1. Under *DataMiner Systems*, click *Open in desktop app*.

1. If required, confirm by clicking *Open DataMiner Cube*.

1. Click *Connect* in the lower right corner of the *New DataMiner System* pop-up window.

   ![New DataMiner System](~/user-guide/images/daas_access_003.png)

> [!TIP]
> See also: [Accessing a newly created DMS for the first time](xref:Accessing_a_new_DMS)

## Step 5: Create an element to monitor a website of your choice

Finally, you will create an element that allows you to monitor a website of your choice. This element will use the *Generic Ping* protocol you deployed earlier, which can be used to regularly send ping commands to the website to ensure it is accessible and functional.

1. In the Cube sidebar, go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, select the *Generic Ping* protocol.

1. Right-click in the *Elements* column, and select *New element*.

   A card will open.

1. Specify the following information:

   - *General* > *Name*: `Ping element`

   - *General* > *Description*: `Element to monitor a website's availability`

1. Click *Create* to add the element.

1. Go to *DATA* > *Ping* > *Add New Ping With Options*.

1. Add a new destination address:

   1. Specify the following information:

      - **New: Destination Address**: Enter the hostname of your chosen website, e.g. `www.skyline.be`.

      - **New: Description**: Enter a short description, e.g. `Skyline`.

      - **New: Admin Status**: Set to `Enabled`.

      > [!NOTE]
      > A parameter is only saved once you click the green checkmark and confirm your choice.

   1. Select *Add Ping* in the lower right corner and confirm you wish to execute the *Add Ping* command.

   A new entry has now been added to the Ping Table on the *DATA* > *Ping* page.

   ![Ping page](~/user-guide/images/Ping_Page.png)

You have now created an element that allows you to monitor the ping status of a website. By default, a ping command is sent out every 5 seconds.

## Step 6: Create an alarm template for your element

1. Look up your newly created element in the Cube Surveyor.

1. Right-click the element and select *Protocols & Templates* > *Assign alarm template* > *New alarm template*.

1. In the *new alarm template* pop-up window, choose a name for your template and click *OK*.

1. Under *Ping*, select the *Ping Table: Avg Time* parameter and configure as follows:

   ![Avg Time](~/user-guide/images/Ping_Table_Avg_Time.png)

1. Select *OK* in the lower right corner.

![Alarm template](~/user-guide/images/Ping_Alarm_Template.png)

Opening the element card will allow you to ...
