---
uid: Connector_help_Smartgrid_PDU_General
---

# Smartgrid PDU General

This driver can be used to gather and view information from the device **Smartgrid PDU**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

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

The **General** page displays general information about the device, such as the Device ID, Up Time, System Name and Temperature.

There is also a page with **PDU** status information and a page with information on the **power** of the device (circuit A and B), including the Voltage, Frequency and Active Power.

On the **Network** page, you can find the network settings of the device and enable the **LITE functionality**.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the Smartgrid PDU General protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- Circuit A: For parameters related to circuit A type **in**.
- Circuit B: For parameters related to circuit B type **in**.

#### Dynamic interfaces

Physical dynamic interfaces:

- Outlets: Outlet table type **out**.
- Remote DCFs: Remote connections type **inout**.
