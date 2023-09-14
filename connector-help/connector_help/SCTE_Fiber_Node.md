---
uid: Connector_help_SCTE_Fiber_Node
---

# SCTE Fiber Node

The **SCTE Fiber Node** is an optical transmitter/receiver that can be used to monitor the optical levels of the SG4 optical switch and SG4 optical amplifier. RF parameters can be monitored as well.

## About

This is an **SNMP**-based connector for the SCTE Fiber Node device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Device Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 1\. B 2. B1 3. CC           |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

On most of the pages of this element that contain tables, a parameter is available that can be used to *Enable* or *Disable* the polling of each table (individually).

### General

This page contains general parameters, such as **Model Number**, **Serial Number**, **Network Address**, **Line Voltage 1** and **Line Voltage 2**, **DC Power Supply Mode** and **Reset Cause**.

### Transponder

This page displays the **Frequency**, **Power** and **Width** for both **Down** and **Up** **Channels** in the transponder, as well as the **SNR Quality**.

### Polling Control

This page allows you to enable or disable the polling for particular SNMP modules, in the same way as can be done above each individual table in the connector.

### Interfaces

This page displays the **Interface Table**.

### SCTE RF

This page contains the **SCTE RF Active Table** and **SCTE RF Optical Receiver RF Port Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### SCTE RF Amplifier

This page displays both the **SCTE RF Amplifier RF Port Table** and **SCTE RF Amplifier DC Power Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### SCTE Laser & Power

This page displays the **SCTE Return Laser Table** and **SCTE DC Power Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### SCTE Optical Receiver

This page displays the **SCTE Optical Receiver Table** and **SCTE Optical Receiver AB Switch Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### SG4 Return Receiver

This page contains three tables: **SG4 Return Receiver Unit**, **SG4 Return Receiver Input** and **SG4 Return Receiver Output**. There are three **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### SG4 Optical Switch

This page contains three tables: **SG4 Optical Switch Unit**, **SG4 Optical Switch Input** and **SG4 Optical Switch Output**. There are three **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### SG4 Optical Amplifier

This page displays both the **SG4 Optical Amplifier Unit Table** and **SG4 Optical Amplifier Laser Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables**.**

### SG4 Optical Amplifier In & Out

This page displays the **SG4 Optical Amplifier Input Table** and **SG4 Optical Amplifier Output Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### Power Supply

This page displays the following tables: **Power Supply Device**, **Power Supply String** and **Power Supply Battery**. There are three **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### Power Supply Output & Sensors

This page displays the **Power Supply Output Table** and **Power Supply Temperature Sensor Table**. There are two **toggle buttons** that can be used to enable/disable the polling of each of these tables.

### Web Interface.

This page shows the web page of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
