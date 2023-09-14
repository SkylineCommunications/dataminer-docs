---
uid: Connector_help_Teleste_CATVisor_EMS
---

# Teleste CATVisor EMS

The **Teleste CATVisor EMS** is a software tool that can be used to monitor and control any product with an SNMP agent.

## About

This connector uses SNMP to monitor the **Teleste CATVisor EMS**, mainly via trap monitoring.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP Address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device. (Default=*161)*
- **Get community string**: The community string required to read from the device. (Default=*public)*
- **Set community string**: The community string required to set to the device. (Default=*public)*

## Usage

### General Page

This page displays two parameters:

- **Server Name**
- **Max Alarm Duration**: The maximum allowed time (in days) that an event can remain available in the Alarm Table. After this time has passed, the event will be cleared.

This page also displays the **Alarm Table**, which lists the received traps. The displayed columns are:

- **Event Id**
- **Element Type**
- **Element Ip Address**
- **Element Name**
- **Element Location**
- **Event Start Time**
- **Severity**
- **Event Message**
- **Event Group Id**
- **Event Log Message Id**
- **Remove**: Contains a button to clear the event from the table.
