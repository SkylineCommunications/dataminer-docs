---
uid: Connector_help_Snell_Wilcox_MACH-HD3
---

# Snell Wilcox MACH-HD3

The Snell Wilcox MACH-HD3 connector is used to monitor and control the **Mach-HD3 HD/SD motion-compensated standards converter.**

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v3.11a                 |

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
- **IP port**: Default:*161*.

SNMP Settings:

- **Get community string**: Default: *public-community.*
- **Set community string**: Default: *private-community.*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector has one data page, **User Memory**, which contains:

- The memory name drop-down list for both index and recall.
- Save, clear, and reset buttons.
- A subpage listing the user memory names.

The drop-down list for the current memory name selection is dynamically generated from the list of user memory names.

Select the correct user memory before you perform any edit actions.
