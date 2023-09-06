---
uid: Connector_help_SYes_GPS_Receiver
---

# SYes GPS Receiver

This connector monitors the activity of the SYes GPS Receiver, a professional high-precision GPS receiver designed for broadcasting purposes.

This device provides a high number of time and reference signals (10x5/10 MHz and 10x1 pps) with the possibility of full redundancy in all relevant modules (dual radio receiver, dual oscillator, and dual power supply).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | Version: 3; Code: FW469180234 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

- The **General** page displays general information about the device such as the **General Status**, **Device Mode**, **Active Module**, and **Board Temperature**. The subpages display additional information about the **Hardware** and **Firmware**.
- On the **Configuration** page, you can set up the configuration of the device: **Switch Mode**, **External Reference**, **10 Mhz Output Power**, **Label**, **Holdover**, **Traps**, and **PPS** settings.
- The **GNSS** page displays information related to the GNSS (Global Navigation Satellite System) configuration and modules. The device has two modules: **Module A** and **Module B**.
- The **Alarms** page has alarm parameters associated with the **PSUs**, **Fan** modules, **Board Temperature**, **Inputs**, and **Outputs**.
