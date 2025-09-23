---
uid: Creating_your_first_element_on_a_DaaS_system
---

# Creating your first element on a DaaS system

This tutorial guides you through setting up a free DataMiner Community Edition system as a service and creating your first Skyline Generic HTTP Query element. With this element, you will be able to monitor a website of your choice.

The content and screenshots for this tutorial have been created in DataMiner version 10.4.6.

Estimated duration: 30 minutes

## Prerequisites

- You must be a member of an [organization](xref:Pricing_Usage_based_service#organization).

## Overview

The tutorial consists of the following steps:

- [Step 1: Create a staging DataMiner System in the cloud](#step-1-create-a-staging-dataminer-system-in-the-cloud)
- [Step 2: Install the DataMiner Cube desktop application](#step-2-install-the-dataminer-cube-desktop-application)
- [Step 3: Deploy the 'Generic HTTP Query' protocol from the Catalog](#step-3-deploy-the-generic-http-query-protocol-from-the-catalog)
- [Step 4: Access your newly created DaaS system for the first time](#step-4-access-your-newly-created-daas-system-for-the-first-time)
- [Step 5: Create an element to monitor a website of your choice](#step-5-create-an-element-to-monitor-a-website-of-your-choice)
- [Step 6: Create an alarm template for your element](#step-6-create-an-alarm-template-for-your-element)
- [Step 7: Hide the unnecessary table columns (optional)](#step-7-hide-the-unnecessary-table-columns-optional)

## Step 1: Create a staging DataMiner System in the cloud

Deploy a [DataMiner Community Edition system as a service](xref:Pricing_Commercial_Models#dataminer-community-edition). This system will be free for the first 7 days.

> [!NOTE]
> To keep using this DataMiner System after the initial 7 days, move to the standard [usage-based services](xref:Pricing_Commercial_Models#usage-based-services) by [purchasing DataMiner credits](xref:Order_DataMiner_credits).

1. Log on to [dataminer.services](https://dataminer.services).

1. Next to *DataMiner Systems*, click *+ Add DataMiner System*.

   ![Add DataMiner System](~/dataminer/images/Add_DataMiner_System.png)

1. Click *DataMiner as a Service*.

   ![DataMiner as a Service](~/dataminer/images/DataMiner_as_a_Service.png)

1. Specify the following information:

   - Select the *Organization* under which you want to register the DataMiner System.

   - Enter a *DataMiner System Name* of your choice.

   - Enter a custom *DataMiner System URL* if you want the URL to be different from the *DataMiner System Name*.

   - Enter a username and password for your DataMiner account.

1. Select the box next to *I agree to the terms of service*.

1. Click *Deploy*.

1. Wait until your DaaS system has been initialized. This can take around 15 minutes.

> [!TIP]
> See also: [Creating a new DMS on dataminer.services](xref:Creating_a_DMS_on_dataminer_services)

## Step 2: Install the DataMiner Cube desktop application

To access and interact with your new DataMiner System, install DataMiner Cube, the main DataMiner client application.

> [!NOTE]
> If DataMiner Cube is already installed, proceed to the next step.

1. Go to [dataminer.services](https://dataminer.services).

1. Select *Desktop installation* in the top-right corner of the dataminer.services home page and run the downloaded file.

1. In the installation window, open the *Options* section:

   - Add a shortcut to the desktop and start menu.

   - Optionally, allow DataMiner Cube to start with Windows.

1. Click *Install*.

## Step 3: Deploy the 'Generic HTTP Query' protocol from the Catalog

Now that you have set up your staging DataMiner System and installed DataMiner Cube, add the *Generic HTTP Query* protocol (also known as connector), through which your element will communicate with your DMA.

1. Look up the [*Generic HTTP Query* connector](https://catalog.dataminer.services/details/d29994e3-f2a6-4da4-972f-21cbb7b1cd62) in the Catalog.

1. Click the *Deploy* button.

1. Select the target DataMiner System and confirm the deployment. The package will be pushed to the DataMiner System.

   ![Deploy Generic HTTP Query connector](~/dataminer/images/Generic_HTTP_Query_Connector.png)

   > [!TIP]
   > See also: [Deploying a Catalog item to your system](xref:Deploying_a_catalog_item).

## Step 4: Access your newly created DaaS system for the first time

Access your new DaaS system.

1. Go to [dataminer.services](https://dataminer.services).

1. Under *DataMiner Systems*, click *Open in desktop app*.

1. If required, confirm by clicking *Open DataMiner Cube*.

1. Click *Connect* in the lower-right corner of the *New DataMiner System* pop-up window.

   ![New DataMiner System](~/dataminer/images/daas_access_003.png)

> [!TIP]
> See also: [Accessing a newly created DMS for the first time](xref:Accessing_a_new_DMS)

## Step 5: Create an element to monitor a website of your choice

Next, you will create an element that allows you to monitor a website of your choice, such as your corporate website. This element will use the *Generic HTTP Query* protocol you deployed earlier, which can be used to regularly send HTTP/HTTPS requests. This helps assess the website's availability.

1. In the Cube sidebar, right-click in the Surveyor and select *New > Element*.

   ![Add element](~/dataminer/images/Add_Element.png)

   A card will open.

1. Specify the following information:

   - *General* > *Name*: Enter a name for your element, e.g. `My corporate website`.

   - *General* > *Description*: Enter a description for your element, e.g. `Element to monitor a website's responsiveness`.

   - *Device details* > *Protocol*: `Generic HTTP Query`.

1. Click *Create* to add the element.

   > [!TIP]
   > See also: [Adding elements](xref:Adding_elements)

1. On the *DATA* > *General* page, right-click the *HTTP Queries* table and select *Add GET*.

   ![Add GET](~/dataminer/images/Add_GET.png)

1. Provide the following information:

   - **URI (HTTP Queries)**: Enter the hostname of your chosen website. Use this format: `http(s)://[address]`, e.g. `https://www.skyline.be`.

   - **Interval (HTTP Queries)**: 10 s.

     The HTTP query will be executed every 10 seconds.

   - **Timeout (HTTP Queries)**: 900 s.

     The system will wait 900 seconds for a response from the remote server after an HTTP query is sent. If the server does not respond within this time frame, the query is considered failed.

   - **Name (HTTP Queries)**: Enter a name for your entry, e.g. `Skyline`.

1. Select *OK* in the lower-right corner.

   A new entry has now been added to the *HTTP Queries* table on the *DATA* > *General* page of your element.

   ![*HTTP Queries* table](~/dataminer/images/HTTP_Queries_Table.png)

You have now created an element to monitor the status of a website. By default, a HTTP/HTTPS request is sent out every 10 seconds.

## Step 6: Create an alarm template for your element

To monitor the website's availability effectively, you will focus on the HTTP response status code in the *Status Code* column. These codes are grouped into five categories based on their first digit, each representing a different class of response:

| Category | Type of response | Example |
|--|--|--|
| 1xx | Informational | `102 Processing`: The server has received and is processing the request, but no response is available yet. |
| 2xx | Success | `200 OK`: The request was successful. |
| 3xx | Redirection | `301 Moved Permanently`: The requested resource has been permanently moved to a new URL. |
| 4xx | Client errors | `404 Not Found `: The server cannot find the requested resource. |
| 5xx | Server errors | `502 Bad Gateway`: The server, while acting as a gateway or proxy, received an invalid response from the upstream server. |

> [!TIP]
> For an overview of all status codes, see [HTTP response status codes](https://developer.mozilla.org/en-US/docs/Web/HTTP/Status/100).

A status code in the `2xx` category indicates a successful response. All other codes should trigger a warning or critical alarm.

In this final step, you will create an alarm template to monitor the *Status Code* parameter.

1. Look up your newly created element in the Cube Surveyor.

1. Right-click the element and select *Protocols & Templates* > *Assign alarm template* > *New alarm template*.

1. In the *new alarm template* pop-up window, enter a name for your template and click *OK*.

1. Under *General*, select the *HTTP Queries: Status Code* parameter.

1. Configure the following alarm thresholds:

   - In the *NORMAL* column, enter `2*`.

   - In the *WARN HI* column, enter `1*;3*`.

   - In the *CRIT HI* column, enter `4*;5*`.

   With this configuration, if the HTTP response status code in the *Status Code* column starts with a 1 or 3, a *Warning high* alarm will be triggered. If a status code starts with a 4 or 5, a *Critical high* alarm will be triggered.

   ![Alarm template HTTP Queries](~/dataminer/images/Alarm_Template_HTTP_Queries.png)

1. Select *OK* in the lower-right corner.

   On the *DATA* > *General* page of your element, the alarm severity will now be shown with appropriate colors for the *Status Code* column.

   ![Alarm template](~/dataminer/images/Ping_Alarm_Template.png)

You are now monitoring the *Status Code* parameter. If a warning or alarm is triggered for your chosen website, it indicates an issue that should be investigated.

> [!TIP]
> See also:
>
> - [About alarm templates](xref:About_alarm_templates)
> - [Configuring normal alarm thresholds](xref:Configuring_normal_alarm_thresholds)

## Step 7: Hide the unnecessary table columns (optional)

By default, the *HTTP Queries* table shows a lot of columns that are not useful for this tutorial. In this step, you will hide these to get a cleaner view on the data.

1. Right-click the top row of the table and hover the mouse pointer over the *Columns* option until it expands to show all columns in the table.

1. Clear the selection from all columns except *Name*, *Interval*, *Status Code*, *Avg Response Time*, *Execute*, and *Response Time*.

1. At the bottom of the menu, select *Save layout*.

   Only the *Name*, *Interval*, *Status Code*, *Avg Response Time*, *Execute*, and *Response Time* columns will be displayed now.

   ![Unnecessary columns](~/dataminer/images/Unnecessary_columns.png)
