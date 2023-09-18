---
uid: Connector_help_Snell_Wilcox_IQFDA30
---

# Snell Wilcox IQFDA30

The **Snell Wilcox IQFDA** is an optical amplifier.

## About

This connector allows the management of the **Snell Wilcox IQFDA30** using a serial connection.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.0.7                       |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.14.10*.
  - **IP Port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: The Unit Address and the Unit Port, e.g. *26.02* for Unit Address *0x26* and Unit Port *0x02*.

## Usage

### General Page

This page contains the **Display** parameter and general status parameters.

The page also provides an overview of miscellaneous log settings, such as OS Version, Firmware version, etc.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Inputs Page

This page provides an overview of the input settings.

The **Config Restart.**.. page button provides an overview of restart settings.

### Outputs Page

This page provides an overview of the output settings.

### SFP Output Page

This page provides an overview of the SFP output settings.

### System Memory Page

This page provides an overview of the system memory. The context menu allows you to save, recall, clear and rename a memory slot.

### Logging Inputs Page

This page provides an overview of the input log settings.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Logging SFP Page

This page provides an overview of SFP log settings.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Rolltrack Page

This page provides an overview of RollCall-related settings.

### System Setup Page

This page contains information about the card, e.g. Product, Software Version, Build.

The page also contains buttons that allow you to restart the device (**Restart**), and set the device back to the factory settings **(Factory Default**) or default settings (**Default Settings**).

### SFP Setup Page

This page contains information about the SFP setup.

### Connection Info Page

This page displays information related to the connection, e.g. **Unit Address**, **Unit Port**.

### Web Interface Page

This page allows the user to access the original web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
