---
uid: Connector_help_Touchstream_StreamCAM
---

# Touchstream StreamCAM

Touchstream StreamCAM is a cloud-based stream monitoring solution.

## About

This connector uses an HTTPS connection to retrieve data from Touchstream StreamCAM, allowing users to monitor and configure streams.

### Version Info

| **Range**     | **Description**                                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                                                                                  | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Restructured Live Status Detail table (2200) to support unlimited Stream Status Detail elements. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | V5                          |
| 1.0.1.x          | API V9                      |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. The default value is *443*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Configuration of authentication

To start using this connector, you need to specify the **Authorization Token** and **X-TS-ID Token** on the **General** page.

## Usage

### General

See "Configuration of authentication" section above.

### Live Overview

On this page, the **Status Overview** table displays a high-level overview of all production streams. The table contains the following information:

- **Product**: The name of the streaming product.
- **Format**: The stream format.
- **Channel**: The name of the stream channel.
- **Location**: The POP location that is monitoring the stream.
- **Status:** The percentage of successful monitoring results for the last 30 measurements.
- **Current Status:** The current status of the stream.
- **Average Speed:** The stream average speed.
- **Max Speed:** The stream maximum speed.

### Live Status Detail

This page contains the **Status Detail** table. This table is similar to the **Status Overview** table, but breaks each stream down further, displaying the following information:

- **Product**
- **Format**
- **Channel**
- **Manifest Status**: The status of the call to obtain the stream manifest.
- **BR1 - BR11 Speed**: The status of up to 11 individual bitrates.

In the **1.0.1.x** range, the **Live Status Detail** table contains more rows than in the 1.0.0.x range, because the status details are implemented by row (instead of by column). The columns are also adjusted accordingly.

### Stream Availability

This page displays the **Stream Availability** table, with availability statistics for a particular time period. The table contains the following information:

- **Product**
- **Format**
- **Channel**
- **CDN**
- **Availability**: The availability as a percentage of time for the specified time period.
- **Outage Count**: The number of outage records created for the stream in the specified time period.
- **Outage Duration**: The total amount of time for all outage records in the specified time period.
- **MTBF**: The Mean Time Between Failures for the stream in the specified time period.
- **MTTR**: The Mean Time to Repair for the stream in the specified time period.

Via the **Config Time Period** page button, you can access a subpage where you can specify the time frame for which stream availability statistics should be displayed.

### Channels

This page contains the **Channels** table, which displays the following information:

- **ID**: The channel identifier.
- **Name**: The channel name.
- **Category**: The chosen category.
- **Default APP**: The default app.

It is possible to add, edit or delete a channel in the table. To add a channel, click the **Add Channel** page button, specify the **ID**, **Name** and **Category** of the channel, and click the **Add Channel** button.

### Products

This page contains the **Products** table, which displays the **Name** of each product as well as the **Default APP**.

It is possible to add, edit or delete a product in the table. To add a product, click the **Add Product** page button, specify the name and click the **Add Product** button.

### Stream Types

This page contains the **Stream** **Types** table, which displays the following information:

- **Product**
- **Format**
- **CDN**
- **Status**

It is possible to add, edit or delete a stream type in the table. To add a stream type, click the **Add** **Stream** **Type** page button, specify the **Product**, **Format** and **CDN**, and click the **Add Stream Type** button.

### Streams

This page contains the **Streams** table, which displays the following information:

- **Channel**
- **Stream Type**
- **Manifest URL**
- **Status**
- **Media Format**

It is possible to add, edit or delete a stream in the table. To add a stream, click the **Add Stream** page button, specify the **Channel**, **Stream Type**, **Manifest URL** and **Media Format**, and click the **Add Stream** button.

### VOD Status / Detailed VOD Status / Manifest Trawl - Failed Assets

These three pages apply to data sources that have VOD services.

In the **1.0.1.x** range of the connector, you can **enable/disable** VOD-related data polling using the **VOD Polling** toggle button. In case the data source does not support VOD, disabling the polling will help to prevent the element from going into timeout (404 NOT FOUND status).

### Planned Outages

This page allows you to schedule an outage for one or more streams.

A **tree view** displays the planned outages information. The tables that are used to generate the tree view are located on the **Planned Outage Tables** subpage.

The tree view contains the following information:

- **Change Request**
- **Description**
- **Start**: The start time of the planned outage.
- **End**: The end time of the planned outage.
- **Streams**: The streams that are available to be added to this planned outage.
- **Impacted Streams**: The selected impacted streams.

### Event Scheduler

This page displays a **tree view** that allows you to edit or delete an event scheduler. The tree view contains the following information:

- **Description**
- **Start**
- **End**
- **Type**
- **Status**
- **Streams**
- **Impacted Streams**

### Web Interface

This page displays the Touchstream StreamCAM web interface. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
