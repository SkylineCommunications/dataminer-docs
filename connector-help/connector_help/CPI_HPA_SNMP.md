---
uid: Connector_help_CPI_HPA_SNMP
---

# CPI HPA SNMP

The TouchPower HPA is part of a comprehensive line of communication amplifiers comprising TWTAs, Klystron Amplifiers (KPAs) and Solid State Power Amplifiers (SSPAs). All are designed specifically for service in satellite earth stations operating in standard frequency bands.

## About

Standard SNMP connector.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Not specified.              |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses an SNMP connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays the **System** **Description**, **Contacts**, and **Locations**.

### System

This page displays the **Model**, **Serial**, **Tube** **Model**, and **Tube** **Serial** **Number**, as well as the **Firmware** **Table**.

### Switch

This page contains two tables, the **Switch** **Version** and **Amplifier** **State** **Table**, with separate parameters about the switch information.

### Switch Position

This page displays an overview of command toggle buttons, a page button that opens the **Preset Table**, and two control page buttons to go to the **Priority** and **Position** **Table**.

### Event Control

This page displays an overview of parameters monitoring the **Alarm** and **Fault** **Threshold** **Table**.

### Amplifier

This page displays an overview of parameters monitoring the **Timer** as well as configurable parameters for the amplifiers.

### Faults

This page displays an overview of the faults.

### Alarms

This page displays an overview of the alarms.

### Inhibits

This page displays an overview of the inhibits.

### Advanced

This page displays configurable parameters for the device, including **Band** **Select**, **Life** **Extender** **Option**, **Run** **Life** **Extender**, and **Life** **Extender** **Auto** **Timer**.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the CPI HPA SNMP protocol supports the usage of DCF and can only be used on a **DMA with 8.5.7** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- A virtual fixed interface named **Input** of type **input** is available, representing the **input** the device.
- A virtual fixed interface named **Output** of type **output** is available, representing the **Output** the device.

### Connections

#### Internal Connections

- Connections from the **input** interface to the **output** interface.

- The fixed connection is always there.
