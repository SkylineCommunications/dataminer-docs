---
uid: Connector_help_Snell_Wilcox_IQOTX81
---

# Snell Wilcox IQOTX81

The **Snell Wilcox IQOTX81** is an optical transmitter.

## About

This connector allows the management of the **Snell Wilcox IQOTX81** using a serial connection.

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
  - **IP Port:** The IP port of the device, e.g. *2050*.
  - **Bus address:** Used to fill in the Unit Address and the Unit Port, e.g. *26.02* is for Unit Address *0x26* and Unit Port *0x02*.

## Usage

### General Page

This page contains the **Display** parameter.

This page also provides an overview of miscellaneous log settings such as OS Version, Firmware version, etc.

The log settings for the parameters can be configured via the **Log Config...** page button.

### SDI-Inputs 1-4 Page

On this page, you can configure SDI inputs 1-4.

The **Output Config.**.. page button provides an overview of the corresponding outputs.

### SDI-Inputs 5-8 Page

On this page, you can configure SDI inputs 5-8.

The **Output Config.**.. page button provides an overview of the corresponding outputs.

### System Memory Page

This page provides an overview of the system memory. The context menu allows you to save, recall, clear and rename a memory slot.

### Logging SDI 1-4 Page

This page provides an overview of log settings related to SDI inputs 1-4.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Logging SDI 5-8 Page

This page provides an overview of log settings related to SDI inputs 5-8.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Logging Fiber Tx 1-4 Page

This page provides an overview of log settings related to Fiber Tx 1-4.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Logging Fiber Tx 5-8 Page

This page provides an overview of log settings related to Fiber Tx 5-8.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Logging Fiber Rx 1-4 Page

This page provides an overview of log settings related to Fiber Rx 1-4.

The log settings for the parameters can be configured via the **Log Config...** page button.

### Logging Fiber Rx 5-8 Page

This page provides an overview of log settings related to Fiber Rx 5-8.

The log settings for the parameters can be configured via the **Log Config...** page button.

### System Setup Page

This page contains information about the card, e.g. Product, Software Version, Build.

The page also contains buttons that allow you to restart the device (**Restart**), and set the device back to the factory settings **(Factory Default**) or default settings (**Default Settings**).

Finally, it is also possible to define a name for the different inputs here.

### Rolltrack Page

This page provides an overview of RollCall-related settings.

### Web Interface Page

This page allows the user to access the original web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
