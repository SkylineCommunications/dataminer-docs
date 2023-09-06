---
uid: Connector_help_Moxa_ioLogik_E2210
---

# Moxa ioLogik E2210

This driver allows you to monitor a configured Moxa ioLogik E2210 device via SNMP. It displays basic information about the device, as well as the status of the existing DI and DO channels. For each DI/DO channel, some settings can also be configured

## About

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact**                                |
|----------------------|---------------------------------------|--------------|--------------------------------------------------|
| 1.0.0.x              | Monitoring of DI and DO channels      | \-           | \-                                               |
| 1.1.0.x \[SLC Main\] | Updated discrete values for DI Status | 1.0.0.x      | Different discrete values are used for DI Status |

### Product Info

| **Range**       | **Supported Firmware** |
|-----------------|------------------------|
| 1.0.0.x/1.1.0.x | v3..13                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General Page

This page displays **system information**: the total number of channels, server model, system uptime and firmware version.

### DI Channel Settings Page

On this page, you can find the **DI Channel Settings table**. This table allows you to monitor all available DI channels, as well as set specific parameters for each channel such as mode, filter, trigger and counter.

### DO Channel Settings Page

On this page, you can find the **DO Channel Settings table**. This table allows you to monitor all available DO channels, as well as set specific parameters for each channel such as mode, status and pulse.
