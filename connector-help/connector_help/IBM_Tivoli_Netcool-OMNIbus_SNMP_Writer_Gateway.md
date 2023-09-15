---
uid: Connector_help_IBM_Tivoli_Netcool-OMNIbus_SNMP_Writer_Gateway
---

# IBM Tivoli Netcool-OMNIbus SNMP Writer Gateway

The IBM Tivoli Netcool-OMNIbus SNMP Writer Gateway connector acts as a **trap receiver** and **orchestrator**. With this connector it is possible to retrieve traps via **SNMP or TCP (Smart-Serial).** Furthermore the connector is able to create **DVE**'s based on location or subdomain, which in terms show the events for the selected location/subdomain. It is also possible to forward the incoming events to other DMAs that use this connector via TCP based on the event domain configurations.

## About

The IBM Tivoli Netcool-OMNIbus SNMP Writer Gateway device is a **monitoring platform** that is able to **forward Netcool alerts**. The alerts are forwarded as **SNMP traps** to an SNMP reader. This allows Tivoli Netcool-OMNIbus to generate traps that are forwarded to other management platforms such as **DataMiner**.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.6.0.0                     |

### Exported connectors

| **Exported Connector**                                    | **Description**                                                   |
|----------------------------------------------------------|-------------------------------------------------------------------|
| IBM Tivoli Netcool-OMNIbus SNMP Writer Gateway Subdomain | This protocol is used to show the events based on their subdomain |
| IBM Tivoli Netcool-OMNIbus SNMP Writer Gateway Location  | This protocol is used to show the events based on their location  |

## Installation and configuration

### Creation

SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, the default value is public.
- **Set community string**: The community string used when setting values on the device, the default value is private.

Smart-Serial smart connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

The "General" page contains the **Orchestrator Table**. For every incoming event the **domain** of the event is checked and if it is not present in the Orchestrator table it will get added to the table. Each domain in the Orchestrator table has a matching **function**. The functions are explained in following table. It is also possible to manually add domains and functions by right-clicking the Orchestrator table and selecting "Add Domain(s)".

| Function                     | Description                                                                                                                                                                                                                                                                                                          |
|------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **Not Configured (Default)** | When an incoming event has a Domain value which is not already registered, the value gets added to the orchestrator table with the default function of not configured. When a domain is not configured, all incoming events for that domain are stored into a configuration buffer until the domain gets configured. |
| **Show per Subdomain**       | Creates DVEs for this domain based on the subdomain value of the incoming events.                                                                                                                                                                                                                                   |
| **Show per Location**        | Creates DVEs for this domain based on the location value of the incoming events.                                                                                                                                                                                                                                    |
| **Forward**                  | Forward the incoming event via a TCP connection with the destination that is specified in the **IP:Port column** of the orchestrator table. If the connection fails, the events are stored in the connectivity buffer. After a configured amount of minutes, the events in the connectivity buffer are re-forwarded. |
| **Discard**                  | Drops the incoming events for this domain.                                                                                                                                                                                                                                                                           |

### DVE Table

When for a certain domain the functions "**Show per Subdomain**" or "**Show per Location**" are selected, **DVE**'s will be created for these traps based on the selected function. On the "DVE Tables" there is a table "**Sub Domain Table**" which list all existing DVEs based on subdomain and a table "**Location Table**" which lists all the DVEs based on location. It it also possible to add DVEs manually by right-clicking one of the table and selecting Add Subdomain\[or Location\].

### Events

On the events page the "**Netcool.Events Table**" is displayed. This table contains all the netcool event **entries that are destined for this DMA**.

### Configuration

On the Configuration page it is possible to configure the **Community String** that has to be match for incoming traps via Smart-Serial connection. Furthermore the **buffer configurations** are located on this page. There are two buffers, the connectivity buffer and the configuration buffer. For each buffer it is possible to specify the **Buffer Size Limit** which determines the maximum number of entries in the buffer and The **Buffer Time Limit** which is the maximum amount of time that an entry can stay in the buffer. Also the **amount of entries** in both buffers are shown on the Configuration page. For the Connectivity Buffer it is also possible to configure the **Forward Retry Time**. This is the time interval for executing retries to forward the content of the connectivity buffer.
