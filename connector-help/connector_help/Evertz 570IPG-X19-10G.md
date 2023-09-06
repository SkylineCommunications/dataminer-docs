---
uid: Connector_help_Evertz_570IPG-X19-10G
---

# Evertz 570IPG-X19-10G

This driver is used to monitor and control the Evertz 570IPG-X19-10G card, which is a video gateway.

An SNMP connection is used in order to successfully retrieve and configure the device's information. There are also different possibilities available for alarm monitoring and trending.

This driver is a standalone driver, **not** an exported driver for the **Evertz 7x00 General Platform** driver.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.00.0540-App F        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this driver consists of the following data pages:

- **System**: This page contains several general settings, including ports configuration and time source configuration. It also contains three tables with data port, SPF and external reference monitoring information.
- **Product Features**: This page lists the product features. It also shows the serial number and MAC address of the card.
- **SDI Input/Output**: These pages allow you to configure and monitor the SDI inputs and outputs, respectively. On the SDI Output page, you can also configure and monitor **virtual SDI outputs**.
- **IP Output/Input**: These pages allow you to configure and monitor the IP outputs and inputs, respectively. The IP Input page also contains **global IP input settings**, such as Next Timeout, LAN Mode and IP Input Loss Duration.
- **Video Notify**: Allows you to monitor video signals (in the Video Monitoring Control table) and monitor and configure video traps (in the Video Notify table).
- **Audio Notify**: Allows you to configure and monitor audio traps.
- **Notify**: Allows you to configure and monitor board traps, as well as traps related to certain Ethernet parameters, and encapsulator and decapsulator traps.
- **SNMP Trap**: Allows you to add and remove **trap destinations**.
