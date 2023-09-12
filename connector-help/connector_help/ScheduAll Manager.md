---
uid: Connector_help_ScheduAll_Manager
---

# ScheduAll Manager

ScheduAll is an application running on Windows OS that manages bookings (a.k.a. work orders) and resources.

## About

This driver allows communication to and from ScheduAll via a web service API and/or via an interop chorus API.

The **web service** API is an XML interface over HTTP. DataMiner can send requests and receives responses accordingly. The interop chorus API works in a different way. Via **interop**, ScheduAll sends data in a specific format to DataMiner without getting a request first (i.e. eventing). The structure of this message is defined via message templates in ScheduAll.

### Ranges of the driver

| **Driver Range** | **Description**                        | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------|---------------------|-------------------------|
| 2.0.0.x          | Initial version                        | No                  | Yes                     |
| 2.0.1.x          | Support for SRM added                  | No                  | Yes                     |
| 3.0.0.x          | POC for Voice of America driver review | No                  | Yes                     |

## Installation and Configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Driver Range</strong></td>
<td><strong>Connections</strong></td>
</tr>
<tr class="even">
<td>2.0.0.x / 2.0.1.x</td>
<td><p>This protocol uses <strong>HTTP</strong> to communicate with the ScheduAll services, and requires the following input during element creation:</p>
<p>HTTP connection:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the main HTTP connection.</li>
<li><strong>Port</strong>: The main port the driver will communicate through.</li>
</ul>
<p>WEB SERVICE API BACKUP connection:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the web service API.</li>
<li><strong>Port:</strong> The port used for the web service communication.</li>
</ul>
<p>INTEROP SERVICE connection:</p>
<ul>
<li><strong>IP address/host:</strong> The IP address of the interop service.</li>
<li><strong>Port:</strong> The port used for the interop service communication.</li>
</ul>
<p>INTEROP LISTENER connection:</p>
<ul>
<li><strong>IP address/host</strong>: The IP address of the interop listener.</li>
<li><strong>Port:</strong> The port used for the interop listener communication.</li>
</ul>
<p>Note: To make sure the ScheduAll Manager has sufficient time to retrieve the information from the Resource Information table, increase the timeout to 60s.</p></td>
</tr>
<tr class="odd">
<td>3.0.0.x</td>
<td><p>This driver uses a <strong>smart-serial</strong> connection and requires the following input during element creation:</p>
<p>SMART-SERIAL CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP or URL of the destination.</li>
<li><strong>IP port</strong>: The IP port of the destination.</li>
</ul></td>
</tr>
</tbody>
</table>

## ScheduAll table structure

The driver combines data coming from several tables in ScheduAll. Below, you can find an overview of the different tables in ScheduAll:

![ScheduAll Structure.png](~/connector-help/images/ScheduAll_Manager_ScheduAll_Structure.png)

## Usage (range 2.0.0.x / 2.0.1.x)

### General

This page contains basic **status information** for both the ScheduAll web service and the interop service.

### Configuration

This page contains **basic configuration** parameters for both the web and the interop services. It is among others possible to **enable or disable** either of the two services here.

This page includes both the **Task Configuration** and the **Message Fields Configuration**.

The task configuration is used to launch an Automation script when new bookings (or updates) are retrieved.

### Configuration - Web Service

This page contains **communication configuration** parameters related to the web service. This includes the following settings:

- Disabling or enabling the communication with the web service.
- Adjusting the polling time with the **Communication Web Service Polling Time** parameter.
- Disabling or enabling polling of the client info or resource info tables from ScheduAll.
- Time format used by ScheduAll.

#### Timespan configuration

With a start and stop parameter, the size of a sliding window can be defined (in minutes) in which data (bookings + resources) have to be retrieved. For example, if you configure a start of -1440 min and a stop of 1440 min, DataMiner is going to retrieve all bookings that have a start or stop time 24 hours before and 24 hours after the current time.

#### Query Configuration

If not all bookings have to be retrieved from ScheduAll but only a subset, this section can be used for defining a filter. There are two filters available:

- **Work Order Query Resource Filter**: Only bookings that contain one of the resources defined in this filter will be retrieved.
- **Work Order Query Resource Group Filter**: Only bookings that contain resources that are in the resource group defined in this filter will be retrieved. Note that in order for this to work, the polling of the 'Resource Information' table has to be enabled.

The **Message field configuration** allows you to define which data fields from ScheduAll have to be retrieved:

- **Work Order Custom Fields**: Here you can define which fields have to be retrieved in addition to the default fields from the work order table in ScheduAll. Per work order, the values are JSON-encoded and stored in the "Custom WO Fields" column in the "Work Order Overview" table.
- **Query Custom WO USER Fields**: Here you can define which fields have to be retrieved in addition to the default fields from the WO_USER table in ScheduAll. Per work order, the values are JSON-encoded and stored in the "Custom WO USER Fields" column in the 'Work Order Overview" table.
- **Resource Custom Fields**: Here you can define which fields have to be retrieved in addition to the default fields from the booking resource table in ScheduAll. Per resource, the values are stored in the "RES Custom xx" columns in the "Resource Overview" table.
- **Query Custom SEVT EX Fields**: Here you can define which additional fields have to be retrieved on top of the default ones from the SEVT_EX table in ScheduAll. Per resource, the values are JSON-encoded and stored in the "Custom SEVT EX Fields" column in the "Resource Overview" table.
- **Query Custom Resource Details Fields**: Here you can define which fields have to be retrieved in addition to the default fields from the Resource Details table in ScheduAll. Per resource, the values are JSON-encoded and stored in the "Custom Resource Details Fields" column in the "Resource Overview" table.
- **Query Custom Client Details Fields**: Here you can define which fields have to be retrieved in addition to the default fields from the client table in ScheduAll. Per resource, the values are JSON-encoded and stored in the "Custom Client Details Fields" column in the "Client Overview" table.
- **Query Custom Values**: Here you can define which fields have to be retrieved in addition to the default fields from the resource info table in ScheduAll. Per resource, the values are stored in the "Custom x" columns in the "Resource Information" table.

### Configuration - Interop Service

This page contains the **interop-specific configuration** parameters. Via the **Credentials** button, you can access a subpage where you can enter **user credentials**. These credentials are the **ScheduAll credentials** that will allow communication between DataMiner and the interop service.

### Configuration - Parameter Mapping

This page contains a table of **Parameter Mapping Names.** Via the right-click menu, you can add extra mapping lines to this table. This table can be used by Automation scripts to map field names from ScheduAll with field names in DataMiner.

### Work Order Overview

This page contains a table of current **work order information**. This table contains an overview of all the information related to the present work orders, and provides the possibility to delete a specific work order.

The page also displays the current **resources scheduled** by ScheduAll.

### Category Overview

This page contains two tables. The table on the left lists all **Category Names**, while the table on the right contains **Category Type** information.

### Client Overview

This page contains a table of **Client Names**.

### Statistics - Web Service

This page contains **web service statistics** for current **queries** and **work orders**.

### Statistics - Interop Service

On this page, a single parameter displays the **Interop Received Time**. In addition, there is a button linking to the **Interop Listener**. The interop listener provides information on the responses DataMiner receives from the interop service.

## Usage (range 3.0.0.x)

### Events

This page contains the **Booking Overview** and **Timeline Reservations** tables. These tables display the scheduled bookings and the resource reservations.

- The **Booking Overview Table** includes parameters such as **Work Order Number, Language, Start Time, End Time, Work Order Status**, etc.
- The **Timeline Reservations Table** includes parameters such as **Reservation GUID, Work Order Sequence Number, Source, Resource, Start Time, End Time**, etc.

Via the **Configuration** page button, you can access various configuration options, including **As-Run Log File Location**, **Work Order Failure Margin**, **Booking Maximum Age** and **Pre-Tally** configuration options.

### Resources

This page contains the **Resources** table, which lists all the resources available for reservations. This table includes parameters such as **Mnemonic**, **Identification**, **Type**, **Task ID**, etc.

Via the context menu of the table, you can **add** new resources and **delete** existing resources.

There are also buttons available that can be used to import a .csv file containing the list of resources.

A progress bar at the bottom of the page displays the progress of slow operations such as the import of a large .csv file or the deletion of a large group of resources.
