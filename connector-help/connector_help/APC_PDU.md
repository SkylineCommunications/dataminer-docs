---
uid: Connector_help_APC_PDU
---

# APC PDU

This power bar device measures the power used by all attached devices and can be used to cut the power for certain devices when necessary.

## About

The connector uses an **SNMP** connection to retrieve the status of the APC PDU device.

### Version Info

| **Range**     | **Description**                                        | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Added additional traps.                                | No                  | No                      |
| 1.0.1.x \[SLC Main\] | Added missing OIDs; removed displayColumn from tables. | No                  | Yes                     |
| 1.0.2.x              | Added support for SNMPv3.                              | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 6.4.0                       |
| 1.0.1.x          | 6.4.0                       |
| 1.0.2.x          | 6.4.0                       |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.16.160.14*.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Username:** Unique user name
- **Authentication password:** Secret key
- **Encryption password:** Encrypted secret key

## Usage - Version 1.0.0.x

### General Page

This page displays hardware factory information, outlet information and device details.

### Load Management Page

This page displays the **Load Status Info** table as well as the **Poll Load Table At Predefined Time Interval** toggle button, which enables/disables polling.

The **Load Config** page button displays the **Load Config Info** table as well as the **Poll Load Configuration Table At Predefined Time Interval** toggle button.

### System Outlet Page

This page displays the **Outlet Status Info** and **Status Outlet Info** tables as well as the **Power Status** parameters.

It also includes a polling toggle button for each table and a set of power parameters, as well as the following page buttons:

- **Outlet Control**: Displays the **Outlet Control Info** table as well as the **Poll Outlet Control Table At Predefined Time Interval** toggle button, and the **Immediate Disabled**, **Immediate Enabled**, and **Reboot All** buttons.
- **Outlet Config**: Displays the **Outlet Config Info** and **Outlet Config Monitored Info** tables.

### System Bank Page

This page displays the **Bank Status Info** table as well as the **Poll System Bank Status At Predefined Time Interval** toggle button, which enables/disables polling.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage - Version 1.0.1.x & Version 1.0.2.x

### General

This page displays hardware factory information, outlet information, device details and information on **Network Port Sharing**.

### Device Data

This page displays the device information, configuration and control tables.

### Load Management

This page displays the **Load Status Info** table as well as the **Poll Load Table At Predefined Time Interval** toggle button, which enables/disables polling. Note that the page contains more information regarding voltage, power and energy measurements than in version 1.0.0.x.

The **Load Config** page button displays the **Load Config Info** table as well as the **Poll Load Configuration Table At Predefined Time Interval** toggle button

### System Outlet

This page displays the **Outlet Status Info** and **Status Outlet Info** tables as well as the **Power Status** parameters.

It also includes a polling toggle button for each table and a set of power parameters, as well as the following page buttons:

- **Max**: Displays the **Max Outlet Info** table as well as the **Poll Max Outlet Info Table At Predefined Time Interval** toggle button.
- **Devices**: Displays device-related parameters as well as the **Poll Outlet Device Params At Predefined Time Interval** toggle button.
- **Outlet Control**: Displays the **Outlet Control Info** table as well as the **Poll Outlet Control Table At Predefined Time Interval** toggle button, and the **Immediate Disabled**, **Immediate Enabled**, and **Reboot All** buttons.
- **Outlet Config**: Displays the **Outlet Config Info** and **Outlet Config Monitored Info** tables.
- **Outlet Metered Properties**: Displays the outlet metered information.

### System Bank

This page displays the **Bank Status Info** table as well as the **Poll System Bank Status At Predefined Time Interval** toggle button, which enables/disables polling.

### Phase

This page displays the **Status Phase Info** and **Outlet Phase Info** tables, as well as the **Poll Status Phase Table At Predefined Time Interval** and **Poll Outlet Phase Info Table At Predefined Time Interval** toggle buttons, which enable/disable polling on the tables. It also includes the **Status Phase Table Size** parameter.

The **Phase to Phase subpage** displays relative measurement data between each phase in the device.

### Environment Sensor

This page displays temperature and humidity measurements. It also contains the **Temperature and Humidity Sensor Configuration** table, where you can configure alarm thresholds for temperature and humidity values.

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
