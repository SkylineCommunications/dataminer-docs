---
uid: Connector_help_British_Telecom_CMON
---

# British Telecom CMON

The **British Telecom CMON** is a management platform of multiple carriers.

## About

This **SNMP** connector monitors the British Telecom CMON management platform.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device, e.g. *10.145.1.12*.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string required to read from the device. The default value is *public*.
- **Set community string**: The community string required to set to the device. The default value is *public*.

## Usage

### General

This page displays the system's general information parameters such as **System Contact**, **System Name**, **Device Status**, etc.

### Carriers

This page displays the number of monitored carriers (**Carrier Number**) and the **Carrier Table** with the following parameters:

- **Carrier Name**
- **Carrier C+N/N**
- **Carrier Power**
- **Carrier Alarm**
- **Carrier Measurement Mode**
