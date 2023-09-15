---
uid: Connector_help_Nautel_NV5-LT_Transmitter
---

# Nautel NV5-LT Transmitter

The Nautel NV5-LT is an analog/digital FM broadcasting transmitter with integrated direct-to-digital exciter(s), parallel power amplifiers, parallel power modules and switching power supplies.

## About

With this connector, the FM transmitter device can be monitored via **SNMP** communication. DVE elements are generated to represent its exciters. A list of exported connectors can be found in the section "Exported Connectors" below.

### Version Info

| **Range**     | **Description** |
|----------------------|-----------------|
| 1.0.0.x \[SLC Main\] | Initial version |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

### Exported connectors

| **Exported protocol**               | **Description**            |
|-------------------------------------|----------------------------|
| Nautel NV5-LT Transmitter Exciter A | Part of controller module. |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection to receive traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g., 10.11.12.13

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, i.e. *public*.
- **Set community string**: The community string used when setting values on the device, i.e. *private*.

## Usage

### General

This page displays general parameters related to the FM transmitter:

- **Local/Remote**: Indicates the operational control status of the transmitter.
- **RF On/Off State**: Allows you to enable/disable the transmitter's RF power stage.
- **Main Exciter**: Allows you to select the main exciter to operate the transmitter (A = internal, B = external).
- **Active Exciter**: Indicates which exciter is currently active.
- **Active Preset Index**: Allows you to select a preset from a list of preset options.
- The low and high power supply are also displayed.

### Controller Meter

This page contains the **controller meter information**, as well as page buttons linking to the **Controller Power Amplifier** and **Controller Power Supply** pages. These subpages display metrics such as DC Input Power, PWB Temperature, and Average Voltage.

### Alarms

On this page, controller alarms are displayed.

### Web Interface Page

This page displays the web interface of the chassis. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
