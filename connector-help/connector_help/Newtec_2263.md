---
uid: Connector_help_Newtec_2263
---

# Newtec 2263

The DVB-S2 satellite demodulator NTC/2263/xF is a member of the Azimuth series and is designed to receive and demodulate a single DVB-S2 modulated signal before correcting and detecting transmission errors and restoring the output digital signal in formats such as IP or MPEG transport packets.

## About

This connector uses a **serial** connection to retrieve information from the device and set parameters on the device.

### Version Info

| **Range**     | **Description**                                       | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------|---------------------|-------------------------|
| 2.2.4.x              | Range for software ID 6242 and software version 2.04. | No                  | Yes                     |
| 2.3.0.x \[SLC Main\] | New range for SW ID 6242 and SW version 2.0.1.        | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**      |
|------------------|----------------------------------|
| 2.3.0.x          | SW ID 6242 and SW version 2.0.1. |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *5933*.
  - **Bus address**: The bus address of the device, by default *100*.

## Usage (2.2.4.x)

### Unit

This page allows you to set up, monitor and control general unit parameters.

- The **Unit Control** parameters are generally set once during installation and not changed on an operational basis.
- The **Unit Monitor** section allows you to monitor the status of internal parameters such as **Temperature** and **Power** **Supply** voltages.

The page button **Unit Setup** allows you to configure general unit parameters, most of which define how to communicate with the device:

- The section **Serial Port Settings** contains all settings for the serial management interface of the unit.
- The section **Ethernet Settings** contains the settings for the Ethernet management interface of the unit.
- The section **Display Settings** contains settings related to the display of the device.
- The section **SNMP Settings** contains settings related to SNMP.

The page button **Architecture** provides information about modules, boards and plug-ins that are installed in the unit. Only the general architecture is displayed here.

### Demodulator

This page allows you to control and monitor the operational parameters of the device.

In expert mode, additional (infrequently used) parameters become available. In normal mode, only relevant operational parameters are shown.

### Demodulator - Monitor

This page allows you to monitor the behavior of the demodulator.

### Alarm

This page contains a table that displays the list of alarms and information regarding the status, the time the alarm was last raised and the time of the last removal.

### Configuration

This page contains a table showing a list of the available configurations. You can **Save** and **Load** up to 48 different operational configurations in permanent memory. A configuration can be defined as a group of all the device configuration parameters that can be set in the device.

Only global system parameters are not saved in a configuration, as these are written in permanent memory at the moment they are set. They are parameters that are common to all configurations, such as Device Mode, RMCP Version, Display Contrast, Serial Interface Type, Device RMCP Address, Serial Baudrate. Device IP Address, Device IP Mask, Default Gateway, Ethernet Interface Alarm Mode (*normal*, *masked*, *forced*). All other parameters are configuration parameters that can differ in the different stored configurations.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage (2.3.0.x)

### General

This page allows you to set up, monitor and control general device parameters. It also displays the **Overall Status** of the device.

There are also page buttons to the following pages:

- **Architecture:** Provides information about modules, boards and plug-ins that are installed in the unit. Only the general architecture is displayed here.
- **Display:** Displays the configurable display settings.
- **Power Supply:** Displays the different power supply voltage levels.
- **External**: Allows you to configure the external parameters **LNB Power Supply**, **LO Frequency IFL** and **Spectrum Inversion**.
- **Ethernet**: Allows you to view and configure the device interface and IP information.
- **S2 Statistics**: Provides information on the S2 parameters.
- **Unit Test:** Allows you carry out various tests on the unit.
- **SNMP:** Contains configurable SNMP information.
- **Serial**: Allows you to configure the serial **Interface Type**, the **RMCP Address** and the **Baud Rate**.

### Demodulator - Config

This page allows you to control and monitor the operational parameters of the device.

In expert mode, additional (infrequently used) parameters become available. In normal mode, only relevant operational parameters are shown.

### Demodulator - Monitor

This page allows you to monitor the behavior of the demodulator.

### Alarm

This page contains a table that displays the list of alarms, as well as information regarding the alarm status, the time the alarm was last raised and the time it was last removed.

### Configuration

This page contains a table listing the available configurations. You can **Save** and **Load** up to 48 different operational configurations in permanent memory. A configuration can be defined as a group of all the device configuration parameters that can be set in the device.

Only global system parameters are not saved in a configuration, as these are written in permanent memory at the moment they are set. They are parameters that are common to all configurations, such as Device Mode, RMCP Version, Display Contrast, Serial Interface Type, Device RMCP Address, Serial Baudrate. Device IP Address, Device IP Mask, Default Gateway, Ethernet Interface Alarm Mode (*normal*, *masked*, *forced*). All other parameters are configuration parameters that can differ in the different stored configurations.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
