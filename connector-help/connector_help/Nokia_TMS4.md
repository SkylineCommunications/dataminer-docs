---
uid: Connector_help_Nokia_TMS4
---

# Nokia TMS4

The Nokia TMS4 (Transmission Management System version 4) is a legacy device dedicated to the management of Nokia PDH network elements (NEs). These NEs may be Nokia PDH/Primary Rate transmission equipment, microwave radios or Nokia D generation equipment.

The purpose of this connector is to provide the capability to listen to printed alarm messages originating from the Nokia TMS4 via a terminal server proxy (serial-to-Ethernet (IP) converter).

## About

### Version Info

| **Range**            | **Key Features**                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version. Processes incoming serial alarms. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Fixed some parameter descriptions.                 | 1.0.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 04A                    |
| 1.0.1.x   | 04A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a smart serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The IP or hostname of the destination (i.e. the terminal server that the TMS4 is connected to).
  - **IP port**: The IP port of the destination. (i.e. the port on the terminal server configured to relay messages to the TMS4 device).
  - **Accepted IP address:** This field can be left blank. Refer to DataMiner User Guide for more details regarding this field.

## How to use

Messages parsed by the connector will be displayed in the Alarms table on the General page:

- The connector will only display messages of type "ALARM".
- When messages of type "CANCEL" are received, the connector will automatically remove the corresponding "ALARM" message.
- Messages of type "DISTUR" are ignored and not displayed in the table.
