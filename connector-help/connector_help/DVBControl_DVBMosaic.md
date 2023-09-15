---
uid: Connector_help_DVBControl_DVBMosaic
---

# DVBControl DVBMosaic

The DVBMosaic shows multiple services received from multiple transport streams, in a real-time mosaic overview, featuring detection, visualization and signaling of freeze, black, silence, PID lost, service lost and input lost behavior. This connector can be used to monitor this device.

## About

This connector monitors the state of the inputs, channels and PIDs.

For the 1.0.0.x connector range, the connector uses SNMP and DCF integration. For the 3.0.0.x range, the connector uses HTTP, SNMP (for traps only) and DCF integration.
The 3.0.0.x range was created because of memory problems with the SNMP agent on the device itself and therefore primarily uses HTTP calls instead of SNMP requests.

### Version Info

| **Range**     | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version                    | Yes                 | Yes                     |
| 3.0.0.x              | Initial version with HTTP          | Yes                 | Yes                     |
| 3.0.1.x \[SLC Main\] | Changed Tally color label to State | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.0.9.x                     |
| 3.0.0.x          | \> 3.0.9.28                 |
| 3.0.1.x          | \> 3.0.9.28                 |

## Installation and configuration

### Creation - range 1.0.0.x

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Creation - range 3.0.0.x

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

#### SNMP Trap Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device, such as **Version**, **Location**, **Contact**, etc. It also contains the **Acknowledge All Alarms** button, which allows the user to acknowledge all the active alarms on the device.

### Administration \[1.0.0.x\]

On this page, you can perform the following actions:

- Select a **Channel Status** with a specified **Audio Track**.
- Switch to a different **Wall**.
- Make a **Channel** fullscreen.
- Acknowledge an **Input** and/or **Channel**.

### Inputs

This page displays the **Input Table**, which contains the **ID**, **Name** and **Status** (*Stopped*, *Running* or *Error*) of the inputs. This table also indicates if an input has a Continuity Counter Error (**CC Error**). The **Acknowledge** button of this table allows you to acknowledge alarms of a specific input.

The page also contains the **ERT290 Error Table**, which displays information on all received **ERT290 Error Traps**. Via the **Auto Clear** page button, you can configure the maximum number of days that an entry should be displayed and the maximum number of entries in the table.

### Channels

This page displays the **Channel Table**. This table shows if a channel is not running or if it has any of the following errors:

- Not Running
- Freeze Error
- Black Error
- Silence Error
- Service Lost Error
- PIDLost Error
- Input Lost Error
- Encryption Error
- Aspect Error
- Etr290 Error
- Eit Now Error
- Tele text Error
- Reserved 2
- Reserved 3
- Reserved 4

The **Acknowledge** buttons of the **Channel Table** allow you to acknowledge the alarms of a specific channel.

### PIDs

This page displays the **PID Table**. This table shows the **Monitor, Subtitles, Teletext, Video** and **Audio PIDs** (if present) of each channel and the errors of each PID. The **Acknowledge** button of this table allows you to acknowledge the alarms of a specific PID.

### Overview

This page displays an overview of the **Input**, **Channel** and **PID Table**. When you select an **Input**, you can view its corresponding **Channels (Channel Table)** and **PIDs (PID Table)**.

### Alarm Preset

To facilitate the process of creating alarm templates, the **Input**, **Channel** and **PID** tables have an **Alarm Preset column**. The content of this column corresponds to that of the **Alarm Preset Table** on the Alarm Preset page.

Configuring presets in the **Alarm Preset Table** can be done by importing an XML file. To do so:

1. Select the XML file using the **Select Alarm Preset File** drop-down list. Use the **Refresh** button to update this drop-down list if necessary.

   The connector looks for the XML files in the following directory: *C:\Skyline DataMiner\Documents\DVBControl DVBMosaic\Configurations\\*

1. Click the button **Import File**.

You can also add a preset in the table by selecting **Create Preset** in the table's context menu. This way, you can add the presets one by one. To delete a preset, right-click the entry in the table and select **Delete Preset**. The **Remove All** button can be used to delete all the entries from the table at once. To save an alarm preset in an XML file, click the button **Export Alarm Preset**.

Once an alarm preset has been assigned to a certain input, channel or PID, this preset name can be used as a filter when you create alarm templates in DataMiner. This will allow you to configure different thresholds for the same parameter (e.g. PID bitrate), depending on the alarm preset filter.

### Tallys

This page displays the **Tallys Table**. This table displays the tally overview, where you can set the tally state according to the colors list.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
