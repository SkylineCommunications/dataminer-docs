---
uid: Connector_help_Snell_Wilcox_LC4000
---

# Snell Wilcox LC4000

This protocol implements the proprietary RollCall protocol for the LC4000 device (sometimes also referred to as the Snell Wilcox KUDOSIQP).

A smart-serial single protocol is used, so that connections from different elements are not combined in one connection to the device. When a client connects to the server, it is assigned a unique port that will identify it on the RollCall network.

## About

### Version Info

| **Range**            | **Key Features**             | **Based on** | **System Impact** |
|----------------------|------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version              | \-           | \-                |
| 2.0.0.x \[SLC Main\] | Initial smart-serial version | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 2.0.0.x   | 2.2B.10                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Smart Serial Single RollCall connection

This driver uses a smart-serial single connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: Required. Default: *2050*.
  - **Bus address**: Required. Uses the format UU:PP, where UU is the unit address of the IP server on RollNet network (e.g. 06), and PP is the unique port address assigned by the server (e.g. 01).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the data pages detailed below.

### General

Displays general information about the device including the Unit Name, Port, Address, Status, and more. This page also contains the following page buttons:

- **Connection Info**: Displays the status of the connection and the assigned session number.
- **SNMP**: Displays the Control and Traps Configuration as well as a Resend Traps button.

### Input

Allows you to select the Input Source. The Current Input Standard is based on the selected input.

### Output

Contains various output controls. With the **Delete** button, you can delete the currently selected logo.

### Video

Displays various controls related to video. The **Preset** button is used in conjunction with the Conversion Aperture parameters.

### Convert

Contains conversion controls.

### ARC

Contains various ARC controls.

### Audio Routing

Displays the statuses of all input pair sources. The **Sources** page button provides access to controls for each process pair source.

### Audio Control

Contains all global delay pair offset controls, as well as all pair totals and various other controls. The **Gain Config** page button provides access to gain controls for each of the 8 L/R pairs.

### Audio Shuffle

Contains various shuffle controls for each of the 8 pairs as well as the status of each pair.

### Timecode

Contains timecode controls, the Timecode Status, the Output Line status and a Timecode Load button.

### Metadata

Contains metadata controls, the Input Status, and the CEA-708 Output Line Status.

### Memories

Contains several controls that allow you to save or recall a memory slot setting, or to reset the settings to the default values.

### Logging

Contains various WST input/output line controls, WST input/output line statuses, and other statuses/controls related to the logging.
