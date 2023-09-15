---
uid: Connector_help_SYes_P75-04_UHF_Controller
---

# SYes P75-04 UHF Controller

The SYes P75-04 UHF Controller operates several multi-standard TV transmitters.

## About

The **SYes P75-04 UHF Controller SNMP** connector controls and monitors the transceiver rack.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 469180143-25                |

## Installation and configuration

### Creation

#### SNMPv2 main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMPv2 Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays information about the system such as **Description**, **Up Time**, **Name**, etc.

Buttons are available that allows you to **clear the cache**, **update the configuration** or **restart the agent**.

Finally, this page also contains 3 page buttons that will navigate to the **MIB Registry Table**, the **Load Average Table** and the available **Memory Parameters**.

### System Overview

This page contains a list of all system status parameters as well as general information, such as **System Status**, **TX Summary Status**, **Reserved Summary Status**, **Number of Transmitters**, etc.

### N+K System

This page displays N+K-specific info, such as **Priority Order**, **Input Matrix Model**, **N+K Command Table**, **ASI Selector Table** and **RF Detector Table**.

### TX

This page contains all the transmitter tables, such as the **TX Table**, **TX Configuration Table**, **Measure TX Table** and the **Auto Switch Table**.

There are also 2 page buttons that navigate to the **TX Restore Table** and the **Coax Relay Table**.

### Reserved

This page contains tables related to the reserved TX: **Reserved Table** and **Measure Reserved Table**.

### Maintenance

This page contains the maintenance status parameters: **Maintenance Status**, **Maintenance Running**, **Maintenance Reserved Status** and **Maintenance Relay Status**.

### Command

This page contains all the command modes and their settings.

### SNMP Traps

This page contains all the possible settings to configure traps.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
