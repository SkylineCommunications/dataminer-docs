---
uid: Connector_help_Sydney_Trains_NSW_Announcement_Manager
---

# Sydney Trains NSW Announcement Manager

The **Sydney Trains NSW Announcement Manager** is used to make **live announcements** to the NSW train stations. This connector is similar to the Sydney Trains Announcement Manager, but is used to announce to the NSW district of Sydney Trains.

## About

This manager connector is designed to be used in combination with the **Sydney Trains NSW Announcement Manager Visio** file. The **Visio** will be used to select the **station** to which the user wants to announce. The connector is designed to allow multiple announcements by different users at the same time.

This manager connector is similar to the **Sydney Trains Announcement Manager**, but the biggest difference is, that the stations that will be announced to by this connector are **no longer available via IP**.
This means that instead of configuring the node crosspoint to the specific station, a **PBX call** needs to be set up to the selected station's **phone number**. For that the *Sydney Trains PBX Manager* is used. This connector still interfaces with the *Delec Oratis Matrix System* connector to configure the crosspoint of the NMS matrix, that is used to enable the sound of the microphone.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Stations

The **Lines**, **Nodes** and **Stations** tables must first be populated, before a user can select the destination for the announcement in the Visio file. These tables can be found on the **Stations** page of the connector and can be populated by importing a **CSV** file.

To import the CSV file, click the **"Import..."** button at the bottom of the **Stations** page. This will open the **Import** page where the available **CSV** files can be selected and imported. The CSV files need to be stored in *"C:\Skyline DataMiner\Documents\Sydney Trains NSW Announcement Manager"* and have the following headers: *"zone id, zone name, zone type, station, station acronym, station type, node, node acronym, line, telephone"*.

### Configuration of Matrices

All *"Delec Oratis Matrix System"* elements will be retrieved by the **Announcement Manager** connector and added ot the **Matrices** table on the **Matrices** page. The **NMS** matrix needs to be configured so the Announcement Manager knows in which element the crosspoint(s) need to be set.

### Configuration of Enhanced System Log

In version **1.0.0.3**, the **Enhanced System Log** was implemented.

This will log all **announcements** (datetime, state, user, stations/zones \[and error\]) to a **CSV file**. To be able to do this, the **Enhanced System Log Path** needs to be configured. In case this path is a **network share**, then the **username** and **password** for this share will also need to be set.

### General configurations

There is an extra Configuration page available with some general configurations that are used by the connector:

- **Debug Logging**: if enabled, all steps will be logged (only use when necessary)
- **Crosspoint dB Value**: this value is used to open the crosspoints in a matrix (default: -*20 dB*)
- **Crosspoint Configuration Timeout**: the max amount of time that the Announcement Manager will check if the crosspoint was correctly set (after that the set is assumed to have failed) (default: *5s*)
- **Release Crosspoint Delay**: the time that Announcement Manager will wait to close the crosspoints after the user stops announcing or configures the announcement (default *30s*)
- **Max Announcement Duration**: max time an announcement can take (after that, crosspoints will be closed) (default: *5min*)
- **Remove Announcement Delay**: the time between the end of the announcement and when it's removed from the Visio (default: *10s*)
- **Max PBX Call Initialization Time**: the maximum it's allowed to take to initialize the PBX call (after that the initialization is assumed to have failed) (default: *40s*)
- **Max PBX Call Retries**: if the initialization time is reached without a successful answer from the PBX Manager, then the initialization will be retried x times, depending on how this parameter is configured (default: 3)

## Usage

### Overview

The **overview** displays a **tree view** of the lines with their respective nodes and stations.

### Announcements

The **Announcements** page displays a table containing the announcements that are currently busy (or configured). This table is used to display the necessary information in the **Visio** file.

When an announcement is finished, it's **automatically removed** from this table. The announcements are moved to the **Announcement History** table when removed from the **Visio**, so it's still possible to check them later. On the **Announcement History** page, it's also possible to configure how long these announcements should be saved.

### Statistics

This page displays the **statistics of the last day**.

### Stations

The **Stations** page displays the information that is imported via **CSV**. The following tables are available on this page:

- **Lines**
- **Nodes**
- **Stations**

### Presets

This page contains 2 tables:

- **Presets (Personal)**: presets linked to a specific user
- **Presets (Shared)**: presets that can be used by every user

These **presets** can only be created from the **Visio** file. This is done by selecting the **Lines, Nodes**, **Stations** or **Zones** in the tree, and saving the selection as a preset. Note that only the user who created the preset can also delete it.

### Configuration

As explained already in the **Installation and Configuration** section, this page contains extra **configuration** **settings** applicable to announcements.

### Matrices

This page contains the **Matrices** table with all the available *"Delec Oratis Matrix System"* elements in the DMS and their configured location.
