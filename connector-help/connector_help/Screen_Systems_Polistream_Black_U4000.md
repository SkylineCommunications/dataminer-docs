---
uid: Connector_help_Screen_Systems_Polistream_Black_U4000
---

# Screen System Polistream Black U4000

The Screen System Polistream Black U4000 connector is used to monitor data from the corresponding device.

Every table contains a list of parameters that indicate if all communication is working properly.

## About

This connector uses the SNMP protocol to request data from the device. The data is shown in multiple tables depending on the specification region of the data.

SNMP traps can be retrieved when this is enabled on the device.

### Version Info

| **Range** | **Description**                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                                     | No                  | Yes                     |
| 1.0.1.x          | Major change: refactored the way data is retrieved. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default this is *161.*
- **Get community string**: The community string used when reading values from the device. The default value is *public.*
- **Set community string**: The community string used when setting values to the device. The default value is *private*.

## Usage

### General

This page contains general information about the device, including the **System Name**, **System Description** and **Device IP** address.

### Channels

This page contains a **Channel Table** with an overview of all the channels available on the device and their status.

### Inputs

This page contains all the input tables (**SDI, VBI, GPI, Software, ASI, COM, Network**) with an overview of all the channels available on the device and their status.

### Outputs

This page contains all the output tables (**SDI, GPO, ASI, Network**) with an overview of all the channels available on the device and their status.

### Servers

This page contains a **Server Table** with an overview of all the servers available on the device and their status.

### Streams

This page contains a **Stream Table** with an overview of all the streams available on the device and their status.
