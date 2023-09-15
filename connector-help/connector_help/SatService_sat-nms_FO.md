---
uid: Connector_help_SatService_sat-nms_FO
---

# SatService sat-nms FO

With this connector, you can gather and view information from the **SatService sat-nms FO** system and from the frames and modules connected to it.

It monitors a **SatService sat-nms MNC** system, but only as far as the **fiber-optic links** information is concerned. For each **fiber-optic link** frame, it will generate a DVE containing a table with modules information and **power supply unit** information.

## About

### Version Info

| **Range**     | **Description**                      | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                     | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Fault State as standalone parameter. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 3.1.676 2018-05-07          |
| 1.0.1.x          | 3.1.676 2018-05-07          |

### Exported connectors

| **Exported Connector**         | **Description**                                                               |
|-------------------------------|-------------------------------------------------------------------------------|
| SatService sat-nms FO - Frame | Detailed frame data of linked modules (RX card, TX card, power supply units). |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device. Note that the default port used by many SatService systems is *2261* instead of *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general system information, such as the **System** **General** **Name**, **System** **Version**, **System** **Fault** **State**, **System** **Contact**, **System Up Time**, etc.

### Frames

This page contains a table with all the **Frames** in the system that will generate DVEs. There is a toggle button to control the **Automatic Frame DVE Removal** and it is also possible to manually **Remove** DVEs that are no longer in the system via a button on each table row.
