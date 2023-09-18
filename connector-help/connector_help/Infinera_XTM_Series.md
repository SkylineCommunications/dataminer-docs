---
uid: Connector_help_Infinera_XTM_Series
---

# Infinera XTM Series

This connector allows you to monitor and control **Infinera XTM** devices. It uses **SNMP** to regularly poll data from the devices.

## About

### Version Info

| **Range**            | **Key Features**                                                                       | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version: monitoring of interfaces, client interfaces, Mes Ports, Mes Vlan Map. | \-           | \-                |

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
- **IP port**: The IP port of the destination (default: *161*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

When you have created the element, you can configure different polling behavior using the **Polling Mode** parameter on the General page. You can set this to *Automatic* (the default setting) or *Manual*.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General** page contains information about the device. You can also disable automatic polling on this page. When you switch to manual mode, the timers will not be used to poll data, and instead you will need to click a button to update the element data.

The other tables are grouped by functionality. For example, the **Mes** page contains subpages for the Mes Ports table and Mes Vlan Map table.
