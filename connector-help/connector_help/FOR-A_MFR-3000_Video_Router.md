---
uid: Connector_help_FOR-A_MFR-3000_Video_Router
---

# FOR-A MFR-3000 Video Router

This connector allows you to monitor the FOR-A MFR-3000 Video Router via an SNMP connection. An additional serial connection is used to retrieve matrix information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

#### Serial IP Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *23*).
  - **Bus address**: The bus address of the device.

### Initialization

The connector retrieves matrix information via serial communication. This requires that the command protocol on the **Port Settings** page of the **device** is set to **Crosspoint Remote Control 2**.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector will poll the **Power Status**, **Fan Status**, **CPU Status**, **Remote Units Status** and **GPI Units Status**.

You can find the received traps in the Traps table on the Traps page. When a specific trap is received, the connector will poll the corresponding parameter(s) again to have the latest data.

A **matrix** is available, representing the **sources** (**inputs**) and **destinations** (**outputs**).

When setting a label, you can use the prefix "A\_" or "K\_" to indicate whether you want to set the ASCII or Kanji name.
