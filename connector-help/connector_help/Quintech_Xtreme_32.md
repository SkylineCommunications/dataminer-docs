---
uid: Connector_help_Quintech_Xtreme_32
---

# Quintech Xtreme 32

The Quintech Xtreme 32 is a dual band matrix switching system featuring 32 ports in a compact 1 RU chassis. The system is a full fan-out, non-blocking signal management solution that routes an input to any or all outputs.

## About

This is an SNMPv2 connector that can be used to monitor and configure the Quintech Xtreme 32 matrix switching systems.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.15.15                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device.
- **Get community string:** The community string used when reading values from the device.
- **Set community string:** The community string used when setting values on the device

## Usage

### General

This page contains general information about the device, such as the **Model**, **Model Number**, **Protocol Version**, **Number of Inputs**, **Number of Outputs**, etc.

### Crosspoints

This page contains a **matrix** component that displays the actual crosspoints and allows you to connect and disconnect inputs and outputs, change labels and lock or unlock certain rows and columns.

### Inputs

This page contains the **Inputs Table**. For each input, this table displays the following parameters: **Name**, **Lock Status**, **Connected Output** (for the QXF Model), **Gain** and **RF Level**.

### Outputs

This page contains the **Outputs Table**. For each output, this table displays the following parameters: **Name**, **Lock Status**, **Connected Input** (for the QXM Model), **Gain**, **RF Level** and **AGC Model**.

### Configuration

This page contains configuration parameters such as **IP Address**, **Gateway**, **Netmask**, **SNMP credentials**, etc.

### Status

This page contains the following tables:

- **System Modules Table**: Lists all the modules installed in the system. For each module, the **Type**, **Address**, **Inputs**, **Outputs**, **Output Gain**, etc. are displayed.
- **System Status Table**: Lists status parameters for all the modules installed in the system, such as **Type**, **Address**, **Fan**, **CPU**, **Temperature**, **PSU**, etc.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
