---
uid: Connector_help_Phoenix_Broadband_SPSM
---

# Phoenix Broadband SPSM

Smart Power Switch Multifunction (SPSM) contains an internal microcontroller that measures many critical internal parameters and transmits this information to an optional remotely-located status monitoring transponder by means of a single coaxial cable interconnection. The remote status monitoring transponder can be connected directly to a TCP/IP data network, or a cable modem can be used to transport the data over an existing DOCSIS infrastructure. The transponder uses industry-standard SNMP protocols, and it is fully compliant with SCTE HMS MIBs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | 01.3 (080415) CPK_580_XPTEX |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: The device address.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device (default: public).
- **Set community string**: The community string used when setting values on the device (default: private).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element has the following data pages:

- **General**: Contains general information about the device. Several parameters allow you to configure settings of the device.
- **Alarms**: Contains a table listing the alarms noted by the device. Below this, alarm statistics are displayed.
- **Units**: Contains a table with the units and corresponding values of the device.
- **Aux Inputs**: Shows the measured values of the auxiliary inputs of the device.
- **MAC Stats**: Displays the pathloss event, framing errors, CRC error and invalid MAC commands.
- **RF**: Shows a summary of encountered problems and statistics concerning radiofrequency operations.
- **Trap Table**: Contains a table listing the traps DataMiner received from the device. Via a button, you can open a subpage where you can configure settings for the automatic cleanup of the table. You can disable the cleanup mechanism, set the maximum number of rows that should be kept in the table, or set the maximum number of days that records should be kept.
