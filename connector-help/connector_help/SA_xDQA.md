---
uid: Connector_help_SA_xDQA
---

# SA xDQA

This connector is a **QAM modulator**, which allows you to monitor alarms and configure QAM settings on the device.

## About

### Version Info

| **Range**            | **Key Features**                           | **Based on** | **System Impact** |
|----------------------|--------------------------------------------|--------------|-------------------|
| 1.1.1.x \[SLC Main\] | Monitoring and setting of QAM frequencies. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.1.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.1.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

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

On the **General** page, you can monitor the name, location and the **QAM Open Streams Channel**, as well as the **GBE Input** parameters. This page also contains a button to **reboot** the device.

On the **Configuration** page, you can set the **QAM Freq. Channel 1** parameters and all 6 of the **GBE QAM RF Output** parameters. This page also displays the **QAM Freq. Channel 2** parameters.
