---
uid: Connector_help_Harmonic_ProStream_9000
---

# Harmonic ProStream 9000

This connector allows monitoring of Harmonic ProStream 9000 transcoders.

## About

The connector uses an HTTP connection to access the device and retrieve non-gzip encoded information. It also uses an HTTP-over-serial connection to access gzip-encoded information. SNMP traps can be retrieved, if this is enabled on the device, via a third connection.

Aside from the IP address parameter, all settings in this connector require that the user has at least **security level 4**.

### Version Info

| **Range** | **Description**                                                                                                                                   | **DCF Integration** | **Cassandra Compliant** |
|-----------|---------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version.                                                                                                                                  | No                  | No                      |
| 1.0.1.x   | New firmware based on 1.0.1.x (see below).                                                                                                        | No                  | No                      |
| 1.1.0.x   | HTTP-over-serial connection implemented for gzip encoding (because not yet supported by DataMiner via HTTP connection).                           | No                  | No                      |
| 1.1.1.x   | HTTP connection for non-gzip encoding along with HTTP-over-serial for gzip encoding (because not yet supported by DataMiner via HTTP connection). | No                  | No                      |
| 1.1.2.x   | More meaningful display keys.                                                                                                                     | No                  | Yes (1.1.2.3 onwards)   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 10.5                   |
| 1.0.1.x   | 10.6                   |
| 1.1.0.x   | 17.6.2.0.173           |
| 1.1.1.x   | 17.6.0.0.9             |
| 1.1.2.x   | 17.6.0.0.9             |

## Configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection to receive traps and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.

#### HTTP "Http" connection

This connector uses an HTTP connection to access the device and retrieve information and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13*.
- **Port number**: The port of the connected device, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

#### Serial "serial" Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

Note: This connection is only used in **version 1.1.0.x and 1.1.1.x**.

## How to Use

### Platform Page

This page displays general information, such as the **System Name**, **System Uptime**, **Software Version** and **Chassis type**.

From version 1.0.1.6 onwards, a **Credentials page button** is available, which allows you to enter login credentials (username/password).

With the **Encoding Type** toggle button, you can specify whether the connector should use gzip or non-gzip encoding.

### Status Page

This page displays tables with the **active alarms** and the **alarm history**.

### Tools Page

This page displays a table with the **license** information.

### Redundancy Page

This page displays a table with defined redundancy groups.

### Traps Page

This page displays the traps received from the device.

### Configuration Page

On this page, you can save and load configuration files.

### Firmware Upgrade Page

On this page, you can upgrade the device or delete one of the available firmware versions on the device.

### Overview Page

This page displays two tree views of the transport streams. On the left the inputs TS is displayed, on the right the outputs TS.

### Slots Page

This page displays a table with information on each slot.

### Ports Page

This page displays a table with information on each GbE port of each slot.

### Physical Inputs Page

This page displays a table with information on the input sockets of each GbE port.

### Logical Inputs Page

This page displays a table with information on the input transport streams of each GbE port.

### Logical Outputs Page

This page displays a table with information on the output transport streams of each GbE port.

### Physical Outputs Page

This page displays a table with information on the output sockets of each GbE port.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

A **BULK** parameter is added from version 1.0.0.10 onwards to update the "Socket Active Source (In)" for multiple rows in one call.The set will be done from within a script. It should set a string value on the BULK parameter:

- Read PID: 12000
- Write PID:12001

The string should consist of semicolon-separated commands, where a single command is a "\|"-separated string containing the key and its value: *KEY\|value*. The value can be 1 (Primary) or 2 (Backup). E.g. *index_X\|Value;index_Y\|Value;index_Z\|Value;*...

**Important Note**: When you **update** elements that use a connector version **prior to 1.0.0.9** to version 1.0.0.9 or higher, you need to clean the element data of these elements while they are stopped. From version 1.0.0.9 onwards, the option UNICODE is enabled in the connector. Old saved data from an element using an older connector that does not have this option will become unreadable because of this encoding change.
