---
uid: Connector_help_Sydney_Trains_Announcement_Manager
---

# Sydney Trains Announcement Manager

The **Sydney Trains (SDT) Announcement Manager** is used to make **live announcements** to the configured train stations.

## About

This manager connector is designed to be used in combination with the **Sydney Trains Announcement Manager Visio** file. The **Visio** will be used to select the **station platforms** to which the user wants to announce. The connector is designed to allow multiple announcements by different users at the same time.

The **SDT Announcement Manager** will configure the necessary matrix (*"Delec Oratis Matrix System"*) crosspoints to allow the user to announce to the selected stations/platforms.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Stations

The **Nodes**, **Stations** and **Platforms** tables must first be populated, before a user can select the destinations for the announcements in the Visio file. These tables can be found on the **Stations** page of the connector and can be populated by importing a **CSV** file.

To import the CSV file, click the **"Import..."** button at the bottom of the **Stations** page. This will open the **Import** page where the available **CSV** files can be selected and imported. The CSV files need to be stored in *"C:\Skyline DataMiner\Documents\Sydney Trains Announcement Manager"* and have the following headers: *"platform name;platform type;station;station acronym;station type;node;node acronym"*.

### Configuration of Matrices

All *"Delec Oratis Matrix System"* elements will be retrieved by the **SDT Announcement Manager** connector and added ot the **Matrices** table on the **Matrices** page. Each matrix needs to be linked to the correct **node** or **NMS** so the SDT Announcement Manager can configure the crosspoints on the correct matrix.

### Configuration of Enhanced System Log

In version **1.0.0.9**, the **Enhanced System Log** was implemented.

This will log all **announcements** (datetime, state, user, stations/zones \[and error\]) to a **CSV file**. To be able to do this, the **Enhanced System Log Path** needs to be configured. In case this path is a **network share**, then the **username** and **password** for this share will also need to be set.

### General configurations

There is an extra Configuration page available with some general configurations that are used by the connector:

- **Debug Logging**: if enabled, all steps will be logged (only use when necessary)
- **Crosspoint dB Value**: this value is used to open the crosspoints in a matrix (default: -*20 dB*)
- **Crosspoint Set Timeout**: the max amount of time that the SDT Announcement Manager will check if the crosspoint was correctly set (after that the set is assumed to have failed) (default: *5s*)
- **Close Crosspiont Delay**: the time that SDT Announcement Manager will wait to close the crosspoints after the user stops announcing or configures the announcement (default *30s*)
- **Max Announcement Duration**: max time an announcement can take (after that, crosspoints will be closed) (default: *5min*)

## Usage

### Overview

The **overview** displays a **tree view** of the Nodes with their respective stations. For each stations, all platforms are also displayed.

### Announcements

The **Announcements** page displays a table containing the announcements that are currently busy (or configured). This table is used to display the necessary information in the Visio file.

When an announcement is finished, it's **automatically removed** from this table.

### Statistics

This page displays the **statistics of the last day**. The **total**, **successful** and **failed** number of announcements are displayed for all nodes. There is also a table containing the same statistics on a **node level**.

### Stations

The **Stations** page displays the information that is imported via **CSV**. The following tables are available on this page:

- **Lines**
- **Nodes**
- **Stations**
- **Zones**
- **Failed Zone:** Used by Visio to indicate zones that couldn't be configured

### Presets

This page contains 2 tables:

- **Presets (Personal)**: presets linked to a specific user
- **Presets (Shared)**: presets that can be used by every user

These **presets** can only be created from the **Visio** file. This is done by selecting the **Lines, Nodes**, **Stations** or **Zones** in the tree, and saving the selection as a preset. Note that only the user who created the preset can also delete it.

### Configuration

As explained already in the **Installation and Configuration** section, this page contains extra **configuration** **settings** applicable to announcements.

### Matrices

This page contains the **Matrices** table with all the available *"Delec Oratis Matrix System"* elements in the DMS and their configured location.
