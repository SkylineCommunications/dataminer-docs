---
uid: Connector_help_Newtec_MDM6000
---

# Newtec MDM6000

This connector allows you to monitor and manage the Newtec MDM6000 equipment. Based on received SNMP traps, it will update a table with alarms.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x              | Initial version. | \-           | \-                |
| 1.0.1.x \[SLC Main\] | New range.       | 1.0.0.15     | \-                |
| 2.0.0.x              | Branch version.  | 1.0.0.x      | \-                |

### Product Info

| **Range**            | **Supported Firmware**         |
|----------------------|--------------------------------|
| 1.0.0.x              | MDM6000_1.3.0.461793.1.0.66732 |
| 1.0.1.x \[SLC Main\] | MDM6000_1.3.0.461793.1.0.66732 |
| 2.0.0.x              | N/A                            |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 2.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector allows you to monitor and configure system information.

It is also possible to **configure the polling** for specific sections for the modulator and demodulator.

For the **modulator**, you can check information such as Mode, Transmit, Transmit State, Output Frequency, Output Band, Roll-off, Occupied Bandwidth, Spectrum Polarity, Output Level, Clock Output, Carrier Modulation, and Amplifier Slope Equalizer.

For the **demodulator**, you can find information for Mode, Input Frequency, Symbol Rate, Roll-off, Input Selection, LNB Power Supply, Spectral Inversion, Carrier Input Level, EsNo, MOD COD, L-Band Input Level, Frame Counter, Errored Frame Counter, Link Margin Est, C/D Est, and Channel Quality Est.

Information about traffic shaping, remote terminals, ACM, BBF, redundancy, and GSE is also displayed.

Finally, the element will also show **active and historic alarm information**.
