---
uid: Connector_help_Ateme_Titan_File
---

# Ateme Titan File

The **Ateme Titan File** is a multi-codec/format video transcoding software, for mezzanine, STB and ABR VOD, post-production, playout and archive applications.

## About

An HTTP connection is used to retrieve information from the software. Data is received in XML format.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**  |
|------------------|------------------------------|
| 1.0.0.x          | Firmware: 3.8.22 API: 1.10.2 |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: By default *byPassProxy*.

## Usage

### General

The **General** page, which is the default landing page, provides an overview of the **System** and the **Integration**. This page contains information about the firmware the device is running and its compatibility with the connector.

### Server Health

This page contains a table with critical information about each server within the system. Some of the critical information is **CPU Cores**, **Memory Usage** and **CPU Usage.**

### Partitions

This page contains a table with the different partitions available within the system. The page also displays what is the **default partition**.

### Jobs

This page is divided into two sections, **Jobs Overview** and **Job List Overview**:

- **Job Overview** contains overall information about the jobs within the software, for example the **Total** number of jobs, the **Jobs Completed**, **Jobs Failed** and **Jobs Aborted.**
- **Job List Overview** is a table that contains all the jobs in the system with more details about each one, for example its **State**, **Progress**, **Start Time** and **Estimated End Time.**

The page also contains a page button **Job Stats**, which displays the following information:

- Overall information about the **Jobs Statistics** within the software, for example the **Jobs Aborted**, **Jobs Completed**, **Jobs Invalid** and **Jobs Waiting**.
- The **Jobs Stats Per Node** table, which contains the job statistics for each server, for example the **Jobs Aborted**, **Jobs Completed**, **Jobs Invalid** and **Jobs Waiting**.

### Segments

This page contains a table with all the segments available within the software, displaying among others the **Job ID,** **URL** and **URI**.

### Presets

This page contains a table with all the presets available within the software, displaying among others the **URL**, **Brief** and **Description**

### Dashboard

This page is divided into three sections, **Dashboard, Dashboard Statistics** and **Dashboard End State**:

- **Dashboard** contains overall information about the dashboard within the software, for example the **Input Number**, **Runtime Input**, **Output Number** and **Runtime Output.**
- **Dashboard Statistics Overview** is a table with statistics for each dashboard timestamp for the **last 7 days**, including the **Average FPS Encoding, Farm Capacity** and **Farm Utilization.**
- **Dashboard End State** is a table that shows the different end states for the dashboard and their count.

### Configuration

This page contains status information related to the **security settings** of the software. It states whether the software has the **security settings enabled/disabled** and what the **token** is if they are **enabled**.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
