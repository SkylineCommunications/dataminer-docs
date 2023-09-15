---
uid: Connector_help_Enensys_T2-Mi_Gen
---

# Enensys T2-Mi Gen

T2-MIGen is ENENSYS's T2-MI generator for local headends managing few TV services. It can encapsulate one or two transport streams stemming from a multiplexer or directly from encoders into a T2-MI stream. It outputs the resulting T2-base or T2-lite compliant multiplex through ASI and IP.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.2.1                  |

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

On the **General** page, you can find general configurable system information such as the **Name**, **Type**, **Location**, and **Update URL**, and whether SNMP **Polling** is enabled for this page. The **Identify** button on this page can be used to make an LED blink on the front panel of the device in order to easily identify it.

On the **Polling configuration** page, you can configure whether polling should be enabled for specific pages.

Since version 1.0.0.2 of the connector, you can remove alarms with severity "No Log" from the Alarm Current table by setting the **No Log Entries Displayed** toggle button to ***No***.
