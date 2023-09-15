---
uid: Connector_help_CLS_Tracking_Platform
---

# CLS Tracking Platform

This is a **virtual** connector that retrieves data from an FTP drive and stores it in the database.

## About

This connector reads TXT files in CSV format from an FTP drive with geographic coordinates gathered from PTT trackers. The connector is integrated with DataMiner Maps, in order to show the current geographical location of the trackers.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Exported connectors

| **Exported Connector**                                                                          | **Description**                                                                                                               |
|------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------------------|
| [CLS Tracking Platform - Tracker](xref:Connector_help_CLS_Tracking_Platform_-_Tracker) | Exported protocol for each tracker, showing the last known position coordinates, the timestamp and other general information. |

## Installation and configuration

### Creation

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

On this page, you must specify the credentials to log in on the relevant FTP server. Once these credentials (**FTP IP Address, User** and **Password**) have been filled in, you can enable or disable the automatic reading of the files or manually give the command to read all files present on the FTP server.

Files that have already been read will be displayed in the **FTP Table**, with the **State** value as *Processed*.

Please note that files are only read once. Only entries that are not yet present in the table will be processed. However, it is possible to **clear the FTP table** and re-read all files again.

### GPS

The **GPS Table** is a logger table with all the valid information retrieved from the TXT files. As this is a logger table, it is not possible to manually clear it and entries will stay in the table for the default time of 365 days. This table will interact with DataMiner Maps.

**Important:** To ensure compatibility with the Cassandra database, it is no longer possible to change the structure of this table.

### Trackers

This page contains the **Trackers Table**, which contains the most recent value from the **GPS Table**, i.e. the last known position and message timestamp for each tracker. This is an export table that generates a DVE for each of those trackers.

Manual removal of individual DVEs or of all DVEs is possible, as well as automatic removal of deleted DVEs.

It is also possible to **add a new row** to this table. To do so, right-click anywhere in the table, select **Add new row** and fill in the tracker ID (PTT).
