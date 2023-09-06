---
uid: Connector_help_Enensys_ASIIP_Guard
---

# Enensys ASIIP Guard

The Enensys ASIIP Guard is an ASI switch that enables automatic 2:1 or 3:1 switch redundancy of ASI and IP feeds.

This connector uses an SNMP connection to monitor and control the Enensys ASIIP Guard.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.5.2                  |

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

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

In order to perform automatic switching, the device relies on switching conditions. These conditions are displayed on the **ETR1**, **ETR2**, **ETR3**, **MIP**, **T2-MI**, **PSIP**, **Bitrate**, and **Advanced** subpages.

### Alarms

From version 1.0.0.6 onwards, you can select the display key format of the **Alarm Current Table**. You can choose between the formats *ID/Description/Severity* (default) or *Custom Description.*
If you select **Custom Description**, you can define a custom description in the **Alarm Configuration Table** that will be used as the display key for the Alarm Current Table.

If the **Custom Description** Column is **empty** for a specific alarm, the display key will be the default **ID/Description/Severity**.

### Polling Configuration

From version 1.0.0.6 onwards, the **Polling Configuration** page allows you to define the polling intervals for the following groups of parameters:

- **General**
- **General Status**
- **Device Options**
- **GPS Status**
- **System**
- **Network**
- **Alarms**
- **Alarm Configurations**
- **Monitoring**
- **Modulation**
- **TS Display**
- **IP Stats**
- **IP Settings**
- **Operation**
- **Input**
- **Switch Conditions ETR1**
- ****Switch Conditions ETR2****
- ****Switch Conditions MIP,****
- ****Switch Conditions T2-MI****
- ****Switch Conditions PSIP****
- ****Switch Conditions Bitrate****
- ****Switch Conditions Advanced****

By default, polling is enabled for these groups and the same polling intervals are used as in previous versions: 10 seconds for fast parameters, 1 minute for medium parameters, and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.
