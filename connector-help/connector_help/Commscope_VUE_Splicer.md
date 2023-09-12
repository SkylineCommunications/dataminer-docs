---
uid: Connector_help_Commscope_VUE_Splicer
---

# Commscope VUE Splicer

This SNMP driver allows the user to monitor the Commscope VUE Splicer device. Its main feature is the composed alarm information coming from three different tables parsed into the Alarms and Alarm Variables tables.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \-               | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: \[The polling IP or URL of the destination.\]
- **IP port**: \[The IP port of the destination.\]

SNMP Settings:

- **Get community string**: \[The community string used when reading values from the device. (default: *public*)\]
- **Set community string**: \[The community string used when setting values on the device. (default: *private*)\]

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

**General** page: shows **System Info** parameters like **Name**, **Description**, **Model** and **Uptime**. It also has the information for the **Nodes** and **Interfaces**.

**Alarms** page: this page shows the Active **Alarms** as well as the Active **Alarm Variables** which gives extra information. It has a subpage with the **Alarm Definition** table where the **Severity** and **Description** of the alarm are fetched from.

## Notes

This driver does not perform any SET.


