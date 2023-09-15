---
uid: Connector_help_Harmonic_NSG9000_40G
---

# Harmonic NSG9000 40G

The Harmonic NSG9000 40G is an HTTP connector that is used to control and monitor NSG9000 40G devices.

## About

This EdgeQAM device supports up to 9 modules, which house 2 RFs with 8 QAMs each. This results in a lot of parameters to monitor. Therefore, an additional page, **Overview**, groups all the parts together in a tree view. Where possible, the web interface is mimicked to provide a low threshold between both interfaces.

### Version Info

| **Range** | **Description**                                                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.1          | Initial version                                                               | No                  | Yes                     |
| 1.0.0.2          | Added MPTS Grooming; fixed issue with treeview                                | No                  | Yes                     |
| 1.0.0.3          | Changed naming on QAM Overview Table and MPTS Grooming Table                  | No                  | Yes                     |
| 1.0.0.4          | Third-line connector: Changed Start-Stop timers, debug logging, exception handling | No                  | Yes                     |
| 1.0.0.5          | Alarm overview table: implemented alarm storm feature                         | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | \[Not determined yet\]      |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

### Configuration

The NSG9000 devices have a default authentication setup that requires login details for a session. These details should be entered on the **Authentication Settings** page, which you can access via the page button on the **General** page. These default login details can be different depending on the device type, and consequently they are different for the NSG9000 3G version.

- **Username:** The username or login of the corresponding access level, e.g. *guest.*
- **Password:** The password of the user or access level, e.g. *nsgguest.*

## Usage

### General

This page provides basic information about the device.

- The column on the left shows identification information about the device. The **Authentication** page button provides access to authentication settings (see "Configuration" section above).
- The column on the right lists the 9 modules with their basic information.

### Alarm

This page contains a single table, **Alarm Overview**, that lists all the active alarms of the device.

Via the **Alarm Storm** page button, you can configure the parameters for the alarm storm prevention: **Upper Limit Concurrent Alarms**, **Lower Limit Concurrent Alarms**, **Rate Amount** and **Rate Timeframe**.

### CAS Settings

This page lists the CAS-related settings, similar to the web interface, but with a few differences. The following groups are displayed:

- **DVB Settings**
- **DVB Session Based**
- **Privacy Mode Settings**
- **CAS Properties**
- **DVB Tier Based**

The page also contains the **ECM Group Table**, which lists the ECM groups. To delete one or more rows, set the value in the **Delete ECM** column to *true* and then click the **Delete Selected** button below the table. To add a row, use the **Add ECM** page button and enter new values. Finally, click the **Set ECM** button to add the new row.

NOTE: When you **edit, add or remove rows**, you may need to **wait** some time for each action to be **synchronized**. Otherwise, if new changes are sent before the DMA is updated, the previous **changes might be lost.**

### IP Settings

The settings on this page are divided over the three tables listed below, with a toggle button at the top of the page to *enable* or *disable* the **ETH2 port:**

- **Ethernet Table**
- **Gigabit Ethernet Table**
- **Routing Table**

### NTP Settings

On this page, you can change the settings of the NTP server.

Via the **Change Time** page button, the data and time can be set.

Below the page button, you can change the **DST** settings.

### VOD Settings

This page contains the VOD settings:

- **Session Inactivity Teardown Threshold**
- **Allow Auto Detection**
- **PID Remapping Method**
- **PID Range Start**
- **PID Range End**
- **PAT Interval**
- **PMT Interval**
- **Update PMT Version**
- **Create SAT**
- **Original Network ID**
- **Serving Area Location In SAT**

### ECMG

On this page, you can find the communication parameters sent to the ECMG. Up to 10 ECMGs are supported.

Note: The row must be active for the settings to be saved. The NSG9000 clears inactive rows.

### SNMP and Syslog

On this page, the column on the left contains the **SNMP Settings**, with the **trap destinations** in the table at the bottom. On the right, the **Syslog Status** and **Server IP Address** can be configured.

### EdgeCluster

The following device settings can be changed on this page:

- **Device Mode**: Can be set to *Standalone + Mute all RFs*, *EdgeCluster* or *StandAlone*.
- **ETH Peer IP**: The first and second IP addresses of the peer device.
- **Device Type**: Indicates whether the device is a primary or backup device.

### QAMs

This page contains the **QAM Overview** table, listing all the QAMs with their status parameters.

### Modules

At the top of this page, an overview of the 9 **modules** is displayed. Below this, you can find an overview of the **RF**s.

### Licenses

On this page, all the **licenses** for the device can be reviewed and managed.

### Broadcast

This page contains the **PID Range** table.

### Traffic

This page displays a table with all the **Input views** **Services** and **Bitrates**.

### Overview

On the left side of this page, a tree view sorts all the **QAMs** by **RF** and **Module**. If you select an element, the status parameters are shown on the right. A list of the subelements and their information is shown at the bottom.

### Module Configuration

These 9 pages contain the settings for each specific module.

### Web Interface

This page provides access to the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
