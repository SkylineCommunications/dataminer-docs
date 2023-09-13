---
uid: Connector_help_FOR-A_MFR-6100_Video_Router
---

# FOR-A MFR-6100 Video Router

This driver allows you to monitor the FOR-A MFR-6100 Video Router via an SNMP connection. From range 1.0.1.x onwards, an additional serial connection is used to retrieve matrix information.

## About

### Version Info

| **Range**            | **Key Features**                                  | **Based on** | **System Impact**                                                        |
|----------------------|---------------------------------------------------|--------------|--------------------------------------------------------------------------|
| 1.0.0.x              | Initial version (SNMP).                           | \-           | \-                                                                       |
| 1.0.1.x \[SLC Main\] | \- Added matrix. - Added extra serial connection. | 1.0.0.x      | Existing elements must be edited to configure the additional connection. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

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

#### Serial IP Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (default: *23*).
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed in range 1.0.0.x.

From range 1.0.1.x onwards, the driver retrieves matrix information via serial communication. This requires that the command protocol on the **Port Settings** page of the **device** is set to **Crosspoint Remote Control 2**.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This driver will poll the **Power Status**, **Fan Status**, **CPU Status**, **Card Status**, **Slot Status**, **SDI Status**, **Remote Units Status** and **GPI Units Status**.

You can find the received traps in the Traps table on the Traps page. When a specific trap is received, the driver will poll the corresponding parameter(s) again to have the latest data.

From range 1.0.1.x onwards, a **matrix** is available, representing the **Sources** (**inputs**) and **Destinations** (**outputs**).

When setting a label, you can use the prefix "A\_" or "K\_" to indicate whether you want to set the ASCII or Kanji name.
