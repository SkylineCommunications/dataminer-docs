---
uid: Connector_help_Technetix_NCC-1222
---

# Technetix NCC-1222

This connector can be used to monitor and control a Technetix NCC-1222 chassis and installed cards.

## About

An NCC-1222 chassis, as part of the Narrowcast Controller system, will control all the NarrowCast inserters (NCI-521/WB or NCI-521-12, maximum 22 units) attached to this controller. For each unit, a DVE element will be created in DataMiner.

An **SNMP** connection is used in order to retrieve and configure the information of the device.

Only one element can poll a device at a time. Polling one device with multiple elements at the same time could lead to unexpected behavior.

### Version Info

| **Range**     | **Description** |
|----------------------|-----------------|
| 1.0.0.x \[Obsolete\] | Initial version |
| 1.0.1.x \[SLC Main\] | New DVE names   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MIB version 1.6             |
| 1.0.1.x          | MIB version 1.6             |

### Exported Connectors

| **Exported Connector**                                                                  | **Description**     |
|----------------------------------------------------------------------------------------|---------------------|
| [Technetix NCC-1222 - NCI-521](xref:Connector_help_Technetix_NCC-1222_-_NCI-521) | NarrowCast Inserter |
| [Technetix NCC-1222 - NCI-321](xref:Connector_help_Technetix_NCC-1222_-_NCI-321) | NarrowCast Inserter |

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

### Configuration

No additional configuration is necessary in the element.

## Usage

### General

This page contains generic parameters such as the **name** of the device, the **IP address** and **software** **versions**.

### NCI Overview

This page provides an overview of all installed **NCI-521** **cards**, together with the **status** of each card.

### NCC Status

This page displays the **status** of the **NCC module**. The **input attenuation** and **input equalization** can be changed. With the configuration parameters, you can enable or disable the displayed alarms.

### RPS-UNI

This page contains the same information as the **RPS-UNI** page in the web interface. With the alarm configuration page button, you can enable or disable the alarms.

### Traps

This page displays the last generated trap. With the table displayed via the configuration page button, you can control the SNMP manager that sends the traps.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
