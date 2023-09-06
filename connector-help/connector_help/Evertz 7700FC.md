---
uid: Connector_help_Evertz_7700FC
---

# Evertz 7700FC

The 7700FC VistaLINKr Frame Controller handles all SNMP communication between the frame (7700) and the network manager (NMS), and serves as a gateway to individual cards in the frame.

This connector can be used to monitor and configure the Evertz 7700FC VistaLINKr Frame Controller card.

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

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector displays product location information in a table on the **General** and **Software** pages.

On the **Product Location** page, you can see which slots are used in the system.

On the **Hardware** page, you can find general information about the status parameters, and on the **Hardware LED** page you can find information about the status of the LEDs in the system.

On the **SNMP Traps** page, you can add and remove trap destinations.

The **Trap Management** page includes information about the trap status of the various slots in the chassis.
