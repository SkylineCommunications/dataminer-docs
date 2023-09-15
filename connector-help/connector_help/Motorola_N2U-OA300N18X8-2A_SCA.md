---
uid: Connector_help_Motorola_N2U-OA300N18X8-2A_SCA
---

# Motorola N2U-OA300N18X8-2A_SCA

This is an **SNMP** connector that is used to monitor and configure the **Motorola N2U-OA300N18X8-2A/SCA** equipment.

## About

The information on tables and parameters is retrieved via SNMP polling.

SNMP traps are used to update the Interfaces table and the Amplifier History table.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.140                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, default *public*.
- **Set community string**: The community string used when setting values on the device, default *private.*

## Usage

### General

This page displays the following general information: **System Description**, **System Contact**, **System Name**, **System Location**, **System Up Time**, **System Last Change** and **System Service Layers.**

The page also contains the following page buttons:

- **Interfaces**: Displays the **Interfaces** table.
- **IP Address**: Displays the **IP Address**, **IP Routers** and **IP Net to Media** tables.
- **IP Information**: Displays the **IP** information of the device.
- **ICMP**: Displays the **ICMP** information of the device.
- **TCP**: Displays the **TCP** information of the device.
- **UDP**: Displays the **UDP** information of the device.
- **SNMP**: Displays the **SNMP** information of the device.

### Amplifier

This page displays general information about the amplifier, such as the **Model Number**, **System Number**, **Vendor Product Name** and **Serial Number**, **Date of Manufacture**, **Firmware Revision**, etc.

The page also contains the following page buttons:

- **Settings**: Displays the amplifier settings.
- **Alarms**: Displays alarms related to the amplifier.
- **History**: Displays the **Amplifier History** table.
- **Status**: Displays the amplifier status.
- **Alarm Status**: Displays the alarm status of the amplifier.
- **Relay Status**: Displays the relay status of the amplifier.
