---
uid: Connector_help_DEVA_Broadcast_DB45
---

# DEVA Broadcast DB45

The DEVA Broadcast DB45 protocol can be used to monitor the FM signals analyzed and monitored by the DEVA Broadcast DB45.

## About

### Version Info

| **Range**            | **Key Features**             | **Based on** | **System Impact**                                                                       |
|----------------------|------------------------------|--------------|-----------------------------------------------------------------------------------------|
| 1.0.0.x \[SLC Main\] | Implements DB45-MIB.         | \-           | \-                                                                                      |
| 1.1.0.x              | Supports firmware v1.7.1841. | 1.0.0.1      | If the device does not support the new firmware, some parameters will not be filled in. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.3.1702 2019/03/06    |
| 1.1.0.x   | 1.7.1841 2019/11/12    |

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

## How to Use

### Channel Measurements

This driver can be used to measure the **signals** for **multiple frequencies**. This can be configured in the **Channel Measurements** table.

Depending on the configured **Round Robin Interval**, every x seconds, the signals for a frequency in the Channel Measurements table will be retrieved. When a time interval has elapsed, the next frequency will be set and polled during a next interval.

To add a new frequency that should be measured, simply click the **Add Channel** button and configure the **frequency** in the table. Once everything is configured, you can **enable** this channel to add it to the round-robin loop. In case you want to make sure it is **polled** **immediately**, use the **Force** button to immediately start polling the signals for that frequency.
