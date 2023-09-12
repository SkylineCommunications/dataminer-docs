---
uid: Connector_help_Kvarta_DVB_Stream_Monitor
---

# Kvarta DVB Monitor

The DVB Stream Monitor is a solution for DVB-C and/or IPTV monitoring for unicast/multicast UDP streams. The device can be controlled remotely using an embedded website or via SNMP.

## About

### Version Info

| **Range**            | **Key Features**                                                                                            | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                             | \-           | \-                |
| 1.1.0.x \[Obsolete\] | New firmware version with different enterprise OID. Some parameters were no longer available on the new MIB | 1.0.0.2      |                   |
| 1.1.1.x \[SLC Main\] | Removed EPG table and refresh mechanism. Improved buffering system.                                         | 1.0.1.1      |                   |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.65A                  |
| 1.1.0.x   | 1.93A                  |
| 1.1.1.x   | 1.93A                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *8025*)
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

In order to communicate with the device, on the **Authentication** page, the **Username** and **Password** must be filled in.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element has the following data pages:

- **General**: This page displays general information about the card: **Device Name**, **Device Model**, **Firmware Version**, **Device ID**, etc.
- **Authentication**: This page allows the user to input the **Username** and **Password** to authenticate into the device.
- **IPTV**
- **DVB-C:** This page contains a subpage with the **Tuner Settings**.
- **Services Tree Control**
- **NIT Tree Control**
- **Services:** This page contains the table **Service** that consists of a list with all of the services retrieved. Each service has a current state and if it is deleted is possible to delete the service from the list by using the button on the **Delete** column.
- **PAT**
- **PMT**
- **SDT**
- **EPG (**Removed on 1.1.1.x)
- **NIT**
- **EIT**
- **CAT**
- **AIT**
- **Time**
- **TR 101 209**
- **Service Statistics**
- **Alarms Status**
- **Alarms Configuration:** This page contains the following subpages**: RF Alarms**, **HLS Alarms** and **TR 101 290 Alarms**.
- **Program Alarms**
- **Logged Alarms**
- **Configurations**
- **System Configuration**
- **Update Firmware**
- **SMTP - Settings**
- **SNMP - Settings**
- **Miscellaneous**
- **Network**
- **Commands**
- **Rx**
- **Tx**


