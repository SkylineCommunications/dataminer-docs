---
uid: Connector_help_Telos_Alliance_VX
---

# Telos Alliance VX

The driver is capable of getting information from the **Telos VX Control Center**. It implements part of the communication API available on the **LiveWire Control Protocol for Phone Systems**. It is also capable of receiving Syslog messages from the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Server: 2.0.1. LWCP: 1 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The port of the connected device, by default *20518*.
- **Bus address**: *ByPassProxy*

#### Serial SyslogMessages connection

This driver uses a smart serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 514

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The driver uses the **VX LWCP: LiveWire Control Protocol for Phone Systems** to communicate with the **Telos VX Control Center** device. It is a serial protocol based on text commands/responses.

The driver also receives **Syslog** information from the device through a smart-serial connection.

### General page

This page displays system parameters: **Server ID**, **Server Version**, **Server Caps**, **LWCP Version,** **Zone**, and **UID**.

The page also contains a **Credentials** page button, which opens a subpage where you can fill in the **Username** and **Password** to establish communication. The subpage also shows the **Login Status**.

### Studios page

This page displays the **Studios Table**. It contains information related to the available studios in the system.

### Shows page

This page displays the **Shows Table**. It contains information related to the available shows in the system.

### Lines page

This page displays the **Lines Table**. It contains information related to the lines that are currently available in a studio.

### Syslog page

This page displays the **SyslogTable**. It contains information related to the received syslog messages. It is possible to limit the number of messages stored in the table.
