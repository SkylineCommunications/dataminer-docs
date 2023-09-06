---
uid: Connector_help_Junger_DAP4_VAP
---

# Junger DAP4 VAP

The DAP4 VAP features a two-channel voice signal path and separate stereo program path either for standalone voice processing or to provide automatic or manual integration of voice and program signals.

Flexible I/O options include AES, analog, 3G SDI, MADI, Danter Audio over IP and high-quality mic pre-amps.

## About

### Version Info

| **Range**            | **Key Features**                                                        | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Minimum required DataMiner version: 10.1.11.0 - 11105. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1234rel_vap_2_0_9      |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) version 2 connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, system information is displayed.

The **Interface** page displays the rate calculation method, the number of interfaces, and the interface table.

The **Audio Products** page contains information related to audio products, divided over multiple subpages.
