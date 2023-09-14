---
uid: Connector_help_Eaton_Remote_Power_Panel
---

# Eaton Remote Power Panel

The Eaton RPP connector is used to monitor the Eaton Remote Power Panel.

## About

### Version Info

| **Range**            | **Key Features**                                | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. Monitors the EATON RPP system. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v2.24                  |

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

On the **Overview** page, you can find a **tree control** that shows the relationship between the **panel** and **breaker**.

On the **RPP** page, you can find:

- General RPP information.
- The Breaker table, containing detailed information on breaker ratings, meters, and phase meters.
- The Panel table, containing detailed information on each panel.

On the **Power Chain Device** page, you can find the **PCD Digital Inputs table**, which shows the digital inputs for each power chain device.
