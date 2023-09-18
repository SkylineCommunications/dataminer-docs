---
uid: Connector_help_Astro_OHPA
---

# Astro OHPA

The **Astro OHP** is an optical high-power amplifier for FttH RF overlay networks, with optical connectors SC/APC for input and LC/APC for output. It also provides a redundant power supply.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

The element created with this connector consists of the data pages detailed below.

### General Page

This page displays general information about the device, such as **Serial Number**, **Model Number**, etc.

There is also a **Reset** button, and a **Configuration** page button that displays a subpage with several settings, such as **Alarm Detection Mode**, **Backoff** **Period**, **Minimum** **MAC** **Layer** **Retries**, etc.

### Amplifier Page

This page displays the **Amplifier Unit**, **Amplifier Input**, **Amplifier Laser** and **Amplifier Output** tables.

### Power Supply Page

This page displays the **Power Supply Output** table.

### Fan Page

This page displays the **Fan Status** table.

### Alarms Page

This page displays the **Current Alarm Table**, and contains two page buttons:

- **Properties**: Displays the **Property Table** and the **Discreet Property Table**.
- **Logs**: Displays the **Alarm Log Table.**
