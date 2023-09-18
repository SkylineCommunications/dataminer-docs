---
uid: Connector_help_ProTelevision_Technologies_PT_5879
---

# ProTelevision Technologies PT 5879

The ProTelevision Technologies PT 5879 is a purpose-built device for inserting MIP information into a MPEG-2 transport stream. The PT 5879 is therefore a central building block in the implementation of an SFN network for DVB-T/H transmission.

This connector uses **SNMP** to poll information from the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | SW4.2. 912             |

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
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Redundancy

There is no redundancy defined.

## How to use

On the **General** and **System** pages, you can find system-related information and settings.

The **Mode Settings** contains all settings related to the device mode.

On the **Input/Output** page, you can configure input and output settings.

The **Reference Settings** page contains **Source**, **Impedance** and **Trigger Reference** settings.

You can find all the alarms on the **Alarms** page and configure the alarms on the relevant subpages.

All the settings related to carousel management are available on the **Carousel** page, including the **Carousel Table**.

From version 1.0.0.7 onwards, a **Polling Configuration** table is available, where you can define the polling intervals for the following groups of parameters:

- **General**
- **System**
- **Controller Board**
- **Inserter Board**
- **Mode Settings**
- **Input/Output**
- **Reference Settings**
- **Alarms**
- **Relay 1 Trigger**
- **Relay 2 Trigger**
- **SNMP Trap Trigger**
- **Carousel**

By default, polling for these groups is enabled and the same polling intervals are used as in previous versions of the connector: 10 seconds for fast parameters and 30 minutes for slow parameters.

The **Polling Table** allows you to configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.
