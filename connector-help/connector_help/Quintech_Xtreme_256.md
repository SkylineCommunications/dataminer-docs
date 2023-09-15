---
uid: Connector_help_Quintech_Xtreme_256
---

# Quintech Xtreme 256

The Quintech Xtreme 256 is an L-band matrix switching system featuring 256 ports in a compact 12 RU chassis. The system is a full fan-out (or fan-in), non-blocking L-band RF matrix switch, which allows any input to be routed to any or all outputs and vice versa.

## About

This is an SNMPv3 connector that can be used to monitor and configure Quintech Xtreme 256 matrix switching systems.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.15.13                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Username**: The SNMPv3 username.
- **Security level**: The SNMPv3 security level.
- **Authentication type**: The SNMPv3 authentication type.
- **Authentication password**: The SNMPv3 authentication password.
- **Privacy type**: The SNMPv3 privacy type.
- **Privacy password**: The SNMPv3 privacy password.

## Usage

### General

This page contains general information about the device, such as the **Model**, **Model Number**, **Protocol Version**, **Number of Inputs**, **Number of Outputs**, etc.

### Crosspoints

This page displays a **matrix** component that displays the actual crosspoints and allows you to connect and disconnect inputs and outputs, change labels and lock or unlock specific rows and columns.

### Inputs

This page contains the **Inputs Table**. For each input, this table displays the following parameters: **Name**, **Lock Status**, **Connected Output** (for the QXF Model), **Gain** and **RF Level**.

### Outputs

This page contains the **Outputs Table**. For each output, this table displays the following parameters: **Name**, **Lock Status**, **Connected Input** (for the QXM Model), **Gain**, **RF Level** and **AGC Model**.

### Configuration

This page includes configuration parameters such as the **IP Address**, **Gateway**, **Netmask**, **SNMP credentials**, etc.

### Status

This page contains the following tables:

- **System Modules Table**: Lists all the modules installed in the system. For each module, the **Type**, **Address**, **Inputs**, **Outputs**, **Output Gain**, etc. are displayed.
- **System Status Table**: Lists status parameters for all the modules installed in the system, such as **Type**, **Address**, **Fan**, **CPU**, **Temperature**, **PSU**, etc.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
