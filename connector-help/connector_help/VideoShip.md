---
uid: Connector_help_VideoShip
---

# VideoShip

The **VideoShip** is an enterprise video workflow and distribution system. This connector allows you to monitor all File Transfers and UDP Video Streams. It allows a user to create a new stream or terminate an existing one.

## About

The information displayed in this connector is delivered in different pages. The displayed information and settings of each page are described in the **Usage** section of this document.

### Version Info

| Range | Key Features | Based on | System Impact |
|--|--|--|--|
| 1.0.0.x [Obsolete] | Initial version. | - | - |
| 1.0.1.x [SLC Main] | Cassandra Compliant, use of options naming instead of display columns. | 1.0.0.5 | Lost of save data, trending and alarming |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|--|--|--|--|--|
| 1.0.1.x | No | Yes |  |  |

## Configuration

### Connections

This connector uses an **HTTP** connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

### File Transfers

Contains the **File Transfers** table. It includes the **start Time the File Mbps, Site Name, VOD Server and the File Pct Over VSAT.**

Only Active File Transfers are visible here.

### Completed File Transfers

All completed Files (with a specified **End-Time**) will appear in this table and be kept by default for 1 week. This **History Threshold** is configurable.

The **Clear** button executes the History Threshold and removes invalid and old rows. Every Day the Clear command is automatically executed.

### UDP Video Streams

Lists all Video Streams currently setup on the system. This includes their **start Time, Stream Type, Site Name and VOD Server.**

Streams can be created using the **New Stream...** page button, streams can be removed by clicking the **Terminate** button on the table.

Only Active Streams are visible here.

### Completed Video UDP Stream

All completed streams (with a specified **End-Time**) will appear in this table and be kept by default for 1 week. This **History Threshold** is configurable.

The **Clear** button executes the History Threshold and removes invalid and old rows. Every Day the Clear command is automatically executed.

### Sites

Lists all VideoShip Sites and their total **File** and **Stream Activity**. This table requires the user to load an Excel file that contains all Site IDs, Site Name and VOD Server name.

The Excel should have the following format:

- SheetName: VideoShip Servers

- Row 1 contains column names (names chosen are not important)

- Column B should hold all VideoShip Site Names.

- Column C should hold all VideoShip Site IDs.

- Column D should hold all VOD Server names.

## Version 1.0.1.1

### Tables changed

| Parameter ID |  ​Table Name |  ​Display Key |
|--|--|--|
| ​90 | ​VideoShip Sites | options=";naming=/91" |
| ​300 | ​File Transfers | options=";naming=/303" |
| ​350 | ​UDP Video Streams | options=";naming=/351" |
| ​500 | ​Completed UDP Video Streams | ​options=";naming=/501" |
| ​550 | ​Completed File Transfers | ​options=";naming=/551" |
