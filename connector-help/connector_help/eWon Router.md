---
uid: Connector_help_eWon_Router
---

# eWon Router

The eWon Router is the industrial LAN/modem router version of a complete range of Ethernet/internet gateways also known as "Programmable Industrial Routers" (PIR).

This connector uses SNMP to poll information from the device.

## About

### Version Info

| **Range**            | **Key Features**                                                                                 | **Based on** | **System Impact**                                                               |
|----------------------|--------------------------------------------------------------------------------------------------|--------------|---------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                 | \-           | \-                                                                              |
| 1.0.1.x \[SLC Main\] | \- Changed the Web Interface Address.- Changed Tag Alarm Status SNMP Column to Retrieved Column. | 1.0.0.3      | \- Alarm filters- Automation scripts- Visual overview- DMS reports- DMS Web API |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | EW_6_3s1f_FR - 6.3     |
| 1.0.1.x   | EW_6_3s1f_FR - 6.3     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device. (default: *public*).
- **Set community string**: The community string used when setting values on the device. (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The **General page** displays general information such as Identification, Memory, Boot Time, Device Type, Serial Number, etc.

On the **Tag page**, the **Tag Table** can be used as an alarm configuration table. It also displays the **Alarm Status**, which is updated based on polling and received traps.

In range 1.0.1.x, the Tag page also contains a **Tag Table Acknowledgement** button, which allows you to configure how acknowledgement is defined:

- **Manually**: For each received alarm, the user needs to set the respective **Alarm Status** to *Acknowledge* in order for the device to stop sending back this alarm.
- **Automatic**: If an alarm is received by the connector, it will automatically send an Acknowledge message to the device.

The 1.0.1.x range also includes a **Polling Configuration** table, which allows you to define the polling intervals for the following groups of parameters:

- **General Status**
- **General Identification**
- **General Configuration**
- **Tag Status**
- **Tag Configuration**

By default, polling for these groups is enabled, and the same polling intervals are used as in previous versions: 30 seconds for fast parameters, 1 minute for medium parameters, and 1 hour for slow parameters.

In the **Polling Table**, you can configure the intervals in the **Time** column, enable or disable the polling in the **State** column, and poll a specific group on demand in the **Refresh on Demand** column.
