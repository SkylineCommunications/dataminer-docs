---
uid: Connector_help_FOR-A_MV-4220_Multiviewer
---

# FOR-A MV-4220 Multiviewer

This driver allows you to monitor the FOR-A MV-4220 Multiviewer device via an SNMP connection. From version 1.0.1.x of the driver onwards, an additional serial connection is used.

## About

### Version Info

| **Range**            | **Key Features**         | **Based on** | **System Impact**                      |
|----------------------|--------------------------|--------------|----------------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.         | \-           | \-                                     |
| 1.0.1.x \[SLC Main\] | Serial connection added. | 1.0.0.1      | New connection needs to be configured. |

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

#### Serial IP Connection - LAN Commands Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. The IP port is **always 51000 + the last octet of the IP address** (e.g. if the IP address is *192.168.0.112*, the IP port is *51112*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This driver will poll the **Unit Info**, **Unit Status**, **Output Status** and **Video Window Status**.

Device alarms can be reset via the **Reset Alarm** button on the Video Window Status page.

Output presets can be configured on the Screen Select page.

You can find the received traps in the Traps table on the Traps page. When a specific trap is received, the corresponding parameter(s) will be polled again to make sure the latest data is displayed.
