---
uid: Connector_help_SSL_System-T_S500
---

# SSL System-T S500

This is a smart-serial driver (Ember+) that is used to monitor and configure the SSL System-T S500.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                             | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Changed primary key GPI/GPO Tables to index | 1.0.0.1      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection for Ember+ and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *9096*).

#### SNMP SNMP Connection Connection

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

## How to use

The element consists of the data pages detailed below.

### General

Contains the **PSU** and **NIC** information of the device

### GPI/GPO

Contains the Ember+ GPI and GPO Tables.

In the **GPI Table**, you can set the status based on a status mode:

- *Toggle*: Traditional toggle button mode.
- *One-Shot*: The status will automatically be set to "Off" some time after an operator sets it to "On". You can define the reset interval with the **One-Shot Reset Time** parameter above the table.
- *One-Shot Inverted*: The status will automatically be set to"On" some time after an operator sets it to "Off". You can define the reset interval with the **One-Shot Inverted Reset Time** parameter above the table.

### Tree

Contains the Ember+ **Tree** Table. Useful for troubleshooting.
