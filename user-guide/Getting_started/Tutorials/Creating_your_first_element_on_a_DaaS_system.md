---
uid: Creating_your_first_element_on_a_DaaS_system
---

# Creating your first element on a DaaS system

This tutorial guides you through setting up a free DataMiner Community Edition system as a service and create your first Microsoft Platform element. With this element, you will be able to monitor your own PC.

The content and screenshots for this tutorial have been created in DataMiner version 10.4.6.

Estimated duration: 15 minutes

## Prerequisites

- You must be a member of an [organization](xref:Pricing_Usage_based_service#organization).

## Overview

The tutorial consists of the following steps:

- [Step 1: Create a staging DataMiner System in the cloud](#step-1-create-a-staging-dataminer-system-in-the-cloud)
- [Step 2: Deploy the 'Microsoft Platform' protocol from the Catalog](#step-2-deploy-the-microsoft-platform-protocol-from-the-catalog)
- [Step 3: Install the DataMiner Cube desktop application](#step-3-install-the-dataminer-cube-desktop-application)
- [Step 4: Access your newly created DaaS system for the first time](#step-4-access-your-newly-created-daas-system-for-the-first-time)d
- [Step 5: Create an element to monitor your PC](#step-5-create-an-element-to-monitor-your-pc)

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

## Step 2: Deploy the 'Microsoft Platform' protocol from the Catalog

Now that you have set up your staging DataMiner System, add the *Microsoft Platform* protocol (also known as connector), through which your Microsoft Platform element will communicate with your DMA.

1. Look up the [*Microsoft Platform* connector](https://catalog.dataminer.services/details/4abcf220-c001-4ffd-bab8-559dee47088f) in the DataMiner Catalog.

1. Deploy the catalog item to your DataMiner Agent by clicking the *Deploy* button.

   ![Deploy Microsoft Platform connector](~/user-guide/images/Microsoft_Platform_Connector.png)

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

## Step 5: Create an element to monitor your PC

Finally, you will create an element that allows you to monitor your own PC. This element will use the *Microsoft Platform* protocol you deployed earlier.

1. In the Cube sidebar, go to *Apps* > *Protocols & Templates*.

1. Under *Protocols*, select the *Microsoft Platform* protocol.

1. Right-click in the *Elements* column, and select *New element*.

   ![Add Microsoft Platform element](~/user-guide/images/Microsoft_Platform_Element.png)

   A card will open.

1. Specify the following information:

   - *General* > *Name*: `My Windows server`

   - *General* > *Description*: `Element to monitor my PC`

   - *SNMP connection* > *IP address/host*: `127.0.0.1`

   - *Serialconnection* > *IP address/host*: `127.0.0.1`

1. Click *Create* to add the element.

You have now created an element that allows you to monitor your PC.

Opening the element card will allow you to view the current value of a multitude of parameters (e.g. total processor load, available physical memory, running processes and services, disk information, and much more).

![Monitor PC](~/user-guide/images/Monitor_PC.png)

If you want to monitor some of those parameters in real time, you can assign an alarm template to the element, and configure alarm thresholds per parameter. For more information, see [About alarm templates](xref:About_alarm_templates).
