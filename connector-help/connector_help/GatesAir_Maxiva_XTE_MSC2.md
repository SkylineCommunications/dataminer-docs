---
uid: Connector_help_GatesAir_Maxiva_XTE_MSC2
---

# GatesAir Maxiva XTE MSC2

The GatesAir Maxiva XTE Multi-System Controller (MSC2) monitors and controls transmitter systems and controls RF switching. The MSC2 supports a range of backup options, including 1+1, full N+1, and dual-transmitter installations.

This connector monitors the activity of the GatesAir Maxiva XTE MSC2 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page displays information about the system such as the **Controller Status**, the **Switch State**, and the **Control State**. On the **Configuration** subpage, you can configure the **system parameters** and enable the **controller events**.

On the **Transmitter** page, you can check the current status of the **Alarm** parameters and the current values of transmission parameters like the **Frequency**, **Power**, and **VSWR**. On the **Events** and **Configuration** subpages, you can set the transmitter definition parameters.
