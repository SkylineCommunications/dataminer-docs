---
uid: Connector_help_Evertz_EMX-FC
---

# Evertz EMX-FC

The **Evertz EMX** Frame Controller provides a unified platform for routing digital audio, MADI audio, data, and time code. The EMR uses a packet routing core that allows for highly dense applications and also provides the flexibility for expansion as demand grows.

## About

The **Evertz EMX-FC** connector provides general information about the device and a **Faults Table** where you can enable or disable traps, and check the status of each fault.

### Version Info

| **Range**            | **Key Features**                                 | **Based on** | **System Impact**                      |
|----------------------|--------------------------------------------------|--------------|----------------------------------------|
| 1.0.1.x \[Obsolete\] | Full connector QA changing IDs and parameter names. | 1.0.0.1      | \-                                     |
| 1.0.2.x \[SLC Main\] | Adds redundant polling.                          | 1.0.1.2      | Added interface for redundant polling. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

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

The element created with this connector consists of the following data pages:

- **General**: Provides device information, including the **Device Description**, **Device Up Time**, **Device Contact**, **Device Name**, and **Device Location**.
- **Faults**: Contains the **Faults Table**. The **Name** column of the table lists the index combined with the monitored device, the **Fault** column contains the alarm value, **Status** shows if the alarm is *Enabled* or *Disabled*, and the **Send Trap** column can be used to enable or disable the trap functionality on the device.
