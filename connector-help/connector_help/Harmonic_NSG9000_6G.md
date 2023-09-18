---
uid: Connector_help_Harmonic_NSG9000_6G
---

# Harmonic NSG9000 6G

The **Harmonic NSG9000 6G** v.1.0.0.3 is an HTTP connector that is used to control and monitor NSG9000 6G devices.

## About

This EdgeQAM device supports up to 9 modules, which house 2 RFs with 8 QAMs each. This results in a lot of parameters to monitor. Therefore, an additional page, **Overview**, groups all the parts together in a tree view. Where possible, the web interface is mimicked to provide a low threshold between both interfaces.

## Installation and configuration

### Creation

This connector uses an HTTP connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP or URL of the destination, e.g. *10.11.12.13.*
- **IP port**: The port of the destination, e.g. *80.*
- **Bus address**: This field can be used to bypass the proxy. To do so, fill in the value *bypassproxy*.

### Configuration

The NSG9000 devices have a default authentication setup that requires a session to provide login details. These details are entered on the **Authentication Settings** page, accessed by the page button on the **General** page. The default logins can be different depending on the device type, and consequently, for this device they are different from the NSG9000 3G version.

- **Username:** The username or login of the corresponding access level, e.g. *guest.*
- **Password:** The password of the user or access level, e.g. *nsgguest.*

## Usage

### General

This page provides basic information about the device.

- The column on the left shows identification information about the device and has a page button leading to the **Authentication Settings** page.
- The column on the right has a list of the 9 modules and their basic information.

### Alarm

This page contains a single table, which lists all the active alarms of the device.

### CAS Settings

This page contains a list of all the CAS-related settings. The following groups are displayed:

- **DVB Settings**
- **DVB Session Based**
- **Privacy Mode Settings**
- **CAS Properties**
- **DVB Tier Based**
- **ECM Group Table:** A table with the ECM groups. To delete one or more rows, set the value in the **Delete ECM** column to *true* and then click the **Delete Selected** button below the table. To add a row, click the **Add ECM.** page button, enter new values, and click the **Set ECM** button to add the new row.
  Note: When editing, adding and removing rows, it is important that you wait for each action to synchronise. If new changes are sent before the DMA is updated, the previous changes might be lost.

### IP Settings

The settings on this page are divided over the following three tables:

- **Ethernet Table**
- **Gigabit Ethernet Table**
- **Routing Table**

In addition, a toggle button at the top of the page allows you to *enable* or *disable* the **ETH2 port**.

### NTP Settings

On this page, you can change the settings of the NTP server, including the **Server IP Address**, **Time Offset** (time zone), **Daylight Saving Status** (DST), **Location** (continent) and **City / Province**.

You can also set the date and time without synchronizing with a server on the pop-up page **Change Time**.

### VOD Settings

This page contains the following VOD settings:

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

This page displays the communication parameters sent to the ECMG. Up to 10 ECMGs are supported.

Note: A row must be active for the settings to be saved. The NSG9000 clears inactive rows.

### SNMP and Syslog

On this page, the column on the left contains the **SNMP Settings**, with the trap destinations in the table at the bottom. On the right, the **Syslog Status** and **Server IP Address** can be edited.

### EdgeCluster

The following device settings can be changed on this page:

- **Device Mode**: Can be set to *Standalone + Mute all RFs*, *EdgeCluster* or *StandAlone*.
- **ETH Peer IP**: Displays the first and second IP addresses of the Peer device.
- **Device Type**: Indicates whether the device functions as primary or as backup.

### QAMs

This page contains a table of all the QAMs, showing their status parameters.

### Modules

At the top of this page, an overview of the 9 modules is displayed, while at the bottom of the page there is an overview of the RFs.

### Licenses

On this page, all the licenses for the device can be reviewed and managed.

### Broadcast

This page contains the **PID Range** table.

### Traffic

This page contains a table with all the **Input Views** **Services** and **Bitrates**.

### Overview

This page contains a tree view on the left that sorts all the **QAM**s by **RF** and **Module**. Once an element is selected, the status parameters are shown on the right. A list of the sub-elements and their information is shown at the bottom.

### Module Configuration

These 9 pages contain the settings for each specific module.

### Web Interface

The web interface of the device can be accessed if the user is connected to the same network as the device.
