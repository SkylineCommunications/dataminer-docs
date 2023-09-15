---
uid: Connector_help_ASC_Signal_NGC-IDU
---

# ASC Signal NGC-IDU

This connector is used to control and monitor an NGC antenna control system. This is an advanced-level antenna control system intended for applications with high tracking requirements, complex geometries, and dynamic conditions.

An **SNMPv1** connection is used in order to retrieve information and configure the device. There are also different possibilities for **alarm monitoring** and **trending**.

## About

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.100.20.15*.

- **Device address**: Indicates the used port, e.g. *1*.

- The bus address will be checked after startup and before the element polls the device. An **invalid bus address** will result in an error message in the system log.
  - You can change the bus address when editing the element. Note that this will result in a restart of the element.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page contains general information about the device: **Serial Number**, **UTC Date**, **Remote Mode**, etc.

The following page buttons are available:

- **Diagnostic**: Opens a subpage with parameters that are used for system diagnostics. You can submit a command and an argument, and after that, a status and result will be displayed.
- **Device Info**: Displays information on capabilities supported by the system, such as **Track** information, **GPS**, **Polarization** and **Sub-Reflector**.

### Position/Jog

This page contains information about the current position of the antenna and allows you to control it using various settings such as **Azimuth Position**, **Jog State**, and **Motor Mode**.

Via page buttons, you can access the following subpages:

- **Motor Configuration**: Contains settings that allow you to configure the motors, as well as fault vectors and speed settings, and information about the current NGC Serial Bus Condition.
- **Configuration**: Contains antenna settings, including threshold and offset values, elevation and polarization limits, jog settings, etc.
- **Bus Devices Configuration**: Contains parameters that allow you to enable or disable devices connected to the serial bus**.**

### Receiver

This page contains information related to the receiver. These values are only retrieved if they are available on the device. The availability of these parameters is indicated on the **Availability State** subpage.

### Satellite Table

This page contains a table with information about the degrees of elevation, skew, as well as other general receiver info.

Above the table, you can execute a command for a satellite defined by index. The ASC Signal NGC-IDU can keep a connection with up to 60 satellites and can save information of up to 1000 satellites.

### Redundancy

This page contains two tables with the redundancy configuration and status information.

The **Faults**, **Amplifier** and **Switch** subpages each contain a status table and a configuration table.

### Axis

This page contains all the axis-related parameters, such as Deadband, Integrator Depth, time settings, rates, etc.

### Alarm Overview 1/2/3

These alarm pages contain the various alarms for the device.

### Web Interface

To access the web interface, the client machine needs to be able to connect to the device.
