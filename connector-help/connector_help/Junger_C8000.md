---
uid: Connector_help_Junger_C8000
---

# Junger C8000

With this connector, it is possible to monitor **Junger C8000** devices with **SNMP**.

## About

### Version Info

| **Range**     | **Description**                                                                            | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                           | No                  | No                      |
| 2.0.0.x              | SNMP traps; DVE; status: metadata, encoder, decoder, SDI input, etc.                       | No                  | No                      |
| 2.0.1.x \[Obsolete\] | Added support for C8492 module. Fixed several issues, renamed Authentication Failure trap. | No                  | No                      |
| 2.0.3.x \[SLC Main\] | Redesigned connector and added modules.                                                       | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |
| 2.0.1.x          | Unknown                     |
| 2.0.3.x          | Unknown                     |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General Page

This page displays general information and system information on the Junger device.

### Module Info Page

This page contains the **Modules List** table, with extra info for C8601, C8611 and 8612 cards.

### Bus Status Page (DVEs)

This page displays the bus status for the relevant card.

### Module Processing Status Page (DVEs)

This page displays the status of the audio channels for the relevant card.

## Notes

After updating from version 2.0.0.7 or earlier to version 2.0.0.8 or later, you will need to restart the element. This is necessary because index keys have been changed between version 2.0.0.7 and 2.0.0.8.
