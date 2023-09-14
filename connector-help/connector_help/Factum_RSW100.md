---
uid: Connector_help_Factum_RSW100
---

# Factum RSW100

The **Factum RSW100** connector displays information related to the **Factum RSW100 Redundancy Switch** device.

## About

This connector uses an SNMP connection to communicate with the **Factum RSW100** device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.6.02                      |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP Connection:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General Page

This page displays status parameters such as the **Agent Version**, **System Contact**, **Operation Mode**, etc.

### Alarms Page

This page displays the alarm statuses, such as the **Agent Alarm Status**, **Change-Over Alarm Status**, **Internal Alarm Status**, etc.

## DataMiner Connectivity Framework

Version **1.0.0.5** and following of the **Factum RSW100** protocol support the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Connections

#### Internal Connections

- If **selected input** is **A**, an internal connection is created between **input A** and the two outputs (**output A** and **output B**).
- If **selected input** is **B**, an internal connection is created between **input B** and the two outputs (**output A** and **output B**).
