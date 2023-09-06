---
uid: Connector_help_VideoShip
---

# VideoShip

The **VideoShip** is an enterprise video workflow and distribution system. This driver allows you to monitor all File Transfers and UDP Video Streams. It allows a user to create a new stream or terminate an existing one.

## About

The information displayed in this driver is delivered in different pages. The displayed information and settings of each page are described in the **Usage** section of this document.

### Version Info

| **Range**            | **Key Features**                                                      | **Based on** | **System Impact**                        |
|----------------------|-----------------------------------------------------------------------|--------------|------------------------------------------|
| 1.0.0.x \[Obsolote\] |                                                                       |              |                                          |
| 1.0.1.x \[SLC Main\] | Cassandra Compliant, use of options naming instead of display columns | 1.0.0.5      | Lost of save data, trending and alarming |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     |                       |                         |



## Installation and Configuration

### Creation

This driver uses an **HTTP** connection and needs the following user information: **HTTP CONNECTION**:

- ? **IP address/host**: \[*The polling IP or URL of the destination*\]
- ? **IP port**: \[*The IP port of the destination*\]
- ? **Bus address**: \[*If the proxy server has to be bypassed, specify: bypassproxy*\]

## Usage

The **Driver** contains the following pages:

- ### File Transfers:

  Contains the **File Transfers** table. It includes the **start Time the File Mbps, Site Name, VOD Server and the File Pct Over VSAT.**
  Only Active File Transfers are visible here

- ### Completed File Transfers

  All completed Files (with a specified **End-Time**) will appear in this table and be kept by default for 1 week. This **History Threshold** is configurable.
  The **Clear** button executes the History Threshold and removes invalid and old rows. Every Day the Clear command is automatically executed.

- ### UDP Video Streams:

  Lists all Video Streams currently setup on the system. This includes their **start Time, Stream Type, Site Name and VOD Server.**
  Streams can be created using the **New Stream...** Pagebutton, streams can be removed by clicking the **Terminate** button on the table.
  Only Active Streams are visible here

- ### Completed Video UDP Stream

  All completed Streams (with a specified **End-Time**) will appear in this table and be kept by default for 1 week. This **History Threshold** is configurable.
  The **Clear** button executes the History Threshold and removes invalid and old rows. Every Day the Clear command is automatically executed.

<!-- -->

- ### Sites:

  Lists all VideoShip Sites and their total **File** and **Stream Activity**. This table requires the user to load an Excel file that contains all Site IDs, Site Name and VOD Server name.
  The Excel should have the following format:

- SheetName: VideoShip Servers

  - Row 1 are columnsNames (names chosen are not important)

  - Column B should hold all VideoShip Site Names.

  - Column C should hold all VideoShip Site IDs.

  - Column D should hold all VOD Server names.



## Version 1.0.1.1

#### Tables changed:

