---
uid: Connector_help_Evertz_7700R2x2-HD
---

# Evertz 7700R2x2-HD

The 7700R2x2 series modules are bypass protection routers for high-definition 1.5 GB/s or standard-definition 270 MB/s serial digital video signals, or for 270 Mbps ASI-based MPEG2 TS signals.

This connector can be used to monitor conditions and status information of input video, audio, router selection, and crosspoint configuration.

The connector also allows manual configuration of monitoring via SNMP.

## About

### Version Info

| **Range**            | **Key Features**                              | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                              | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Update for compliance with current standards. | 1.0.0.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the Evertz 7x00 Frame containing the card, e.g. *192.168.100.161*.
- **IP port**: The IP port of the destination. Default: *161*.
- **Bus address**: The frame card slot number for the device. Default: *15*. Range: *1* - *100.*

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

### HD-SDI or ASI Mode

The connector is designed to detect the video standard of the signals plugged into the card and poll the corresponding parameters associated with that signal type. For ASI signals, this includes the various parameters related to the transport stream.

### General Page

The General page provides a summary of vital input and control parameters. It serves as a kind of dashboard giving the basic status of the card and its signals, and also allows you to switch between inputs.

### Switch Page

The Switch page provides a full set of ACO function controls, as well as some general configuration and status parameters.

### Monitor Page

The Monitor page provides basic input video standard status parameters and a full set of ASI input status parameters.

### Input 1 and Input 2 Pages

The Input 1 and Input 2 pages provide a full set of HD-SDI video and audio input alarm status parameters, as well as a full set of ASI input alarm status parameters. These parameters are a duplicate of those in the faults table but arranged in a more user-friendly layout.

### De-Embedder Page

The De-Embedder page provides additional configuration and status parameters related to the de-embedder function.

### SNMP Traps Page

The SNMP Traps page allows you to log and monitor incoming SNMP traps.

### Trap Settings Page

To tailor the configuration of trap monitoring on the **SNMP Traps** page, you can use the following parameters:

- **Max Traps**: Allows you to select the maximum number of traps in the table.
- **Max Age**: Allows you to configure the maximum age of the traps.
- **Trap Timeout**: Allows you to configure the trap reception timeout time for traps.
- **Automatically Deactivate Alarms After**: Determines after how much time alarms will be deactivated.
- **Age Refresh Frequency**: Determines the frequency at which the age of each trap is updated.

### Faults Page

The Faults page contains the parameters required to configure fault alarm thresholds, to configure the sending of traps for specific faults, and to configure which faults will contribute to automatic changeover.
