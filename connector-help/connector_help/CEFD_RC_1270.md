---
uid: Connector_help_CEFD_RC_1270
---

# CEFD RC 1270

This connector can poll the redundancy switch via SNMP. It can read all parameters that are available in the web interface, and it can also be used to change the redundancy settings. CEFD is an abbreviation for Comtech EF Data. This is a redundancy switch controller, hence the abbreviation RC, where R stands for Redundancy and C for Controller.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**              |
|-----------|-------------------------------------|
| 1.0.0.x   | Boot:1.1.1 Bulk1:1.1.3 Bulk2: 1.1.3 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: default value: *161*
- **Get community string**: default value: *public*
- **Set community string**: default value: *private*

### Initialization

No additional initialization is needed in the DataMiner element.

However, to make it possible to change the redundancy settings, the device itself needs to be set to Manual Mode. This can only be changed physically at the device.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

You need to specify the credentials when you access the web interface for the first time. By default, these credentials are "comtech/comtech".

## How to Use

On the **General** page of this connector, you can configure the general parameters of the device, like the System Name or System Description and Switch Positions. You can also set the Redundancy Mode here.

On the **Status Summary** page, you can check all parameters that indicate the status of the device, like the power supplies or the current.

On the **Configuration** page, you can configure the redundancy settings, such as the mute settings, and determine which units are online or offline. Calibration can also be done here.

Via the **Web Interface** page, you can access the web interface of the device directly.
