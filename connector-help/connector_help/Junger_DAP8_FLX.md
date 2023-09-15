---
uid: Connector_help_Junger_DAP8_FLX
---

# Junger DAP8 FLX

Junger DAP8 FLX is a digital audio processor with a choice of multiple I/O formats including AES, SDI, MADI, Danter, and analog.

With this connector, you can configure and monitor this device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**   |
|-----------|--------------------------|
| 1.0.0.x   | rel_dap8_mei_5_1_8_54512 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** |
|-----------|---------------------|-------------------------|-----------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    |

## Configuration

#### SNMP main connection

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

On the **General** page, you can find system information.

The rate calculation method, number of interfaces, and interface table are displayed on the **Interface** page.

The **Audio products** page contains information related to audio products. This information is divided over multiple subpages.
