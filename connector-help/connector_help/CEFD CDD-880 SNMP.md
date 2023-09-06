---
uid: Connector_help_CEFD_CDD-880_SNMP
---

# CEFD CDD-880 SNMP

The CDM-880 Multi Receiver Router serves as the hub expansion utility component of Comtech EF Data's Advanced VSAT Series group of products. It can receive transmissions from up to 12 CDM-840 Remote Routers.

## About

This driver is intended to get/set information from/to the device via an Element in a DataMiner System, using SNMP commands.
To get more detailed information consult the website <http://www.comtechefdata.com/support/docs/advancedvsatdocs>.

### Version Info

| **Range**            | **Key Features**                                                                                                    | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                                     | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Multiple tables now uses naming instead of displayColumn to make the database for these tables Cassandra-compliant. | 1.0.0.22     | \-                |



### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Unknown                |
| 1.0.1.x   | Unknown                |



### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |



## Installation and configuration

### Creation

**SNMP CONNECTION**:

\- **IP address/host**: the polling IP of the device eg *10.11.12.13*

\- **Device address**: (define if needed or not + the default / range if any)

**SNMP Settings**:

\- **Port number**: the port of the connected device, default *161*

\- **Get community string**: the community string in order to read from the device. The default value is *public*.

\- **Set community string**: the community string in order to set to the device. The default value is *private.*

## Usage

### General

This page contains information about the **System Information**, **Service Contact** and **Device Overall Status**.

### Admin

In this page is given information about the **FAST Configuration** and is also possible to set the **SNMP Configuration**, **Auto Logout Configuration**, **Firmware Configuration** and **Vipersat Management System Configuration**.

### Configuration - Interface

Use this page to assign the device's IPs using the **Interface Table** and also to set the **Port Diversity** function.

### Configuration - WAN - Demod

All related demodulator configurations are done in this page. Set individual configurations using the **Individual Demodulator Settings** Table and set global configurations in the **Global Demodulator Settings** menu.

### Configuration - WAN - ACM

In this page is available the **Rx ACM Log** and also the **Link Adaptation Config Table**.

### Configuration - WAN - LNB

Use this page to set the **LNB**'s **Control** configurations and also to check its meausurements under the **LNB Status** label.

### Configuration - Network

In his page several configurations can be done:

- **ARP Table** to set ARP configurations;
- **Working Mode** to set the Working Mode to *Router* or *BPM*.
- **PTP Configuration** and **Status**.

<!-- -->

- Encryption ... - To set the 8 **Encryption Keys**.

### Configuration - Network - Routing

Still related to the Network configuration, the **Route Table** can be found here as well as the **Mesh Location** setting.

### Configuration - ECM

To set **ECM Remote Configuration** and to consult the **ECM Remote Status**.

### Status - Stats - Interface

In this page is possible to check the interfaces rates in the **Interfaces Information** table.

### Status - Stats - Traffic

In this page is available the **Ethernet Stats Table**, the **Demod Stats Table** and also **Rx Satellite** measurements.

### Status - Stats - Demod

Several status tables related to the demodualotor are available in this page:

- **Demod Status Table**
- **Link Adaptation Status Table**
- **VS Status Table**

### Status - Stats - Router

In this page are available the **Interface**, **Routers** and **Management Counters**. The **Clear Statistics** button clears them all.

### Status - Stats - PTP

This page provides information about **PTP LAN** and **WAN** Statistics.

### Status - Stats - Managed Switch

In this page are available the **Managed Switch** and the **Managed Switch LAN Statistics**.

### Status - Monitor - Alarms

Several information about alarms can be found here:

- Alarms - **Unit**, **LNB**, **Traffic** **Ethernet** and **PTP** general **Alarms**.
- Rx Alarms - Related to the Demodulators.

<!-- -->

- **Demodulator Alarms** - In depth information about **Demod Alarm State**/**Mask**.
- **Unit Alarms** - In depth information about **Unit** **Alarm States**/**Masks**.

### Status - Monitor - Events

If there's an event on the device it will be shown in the **Event Table**. Use the **Clear** button to clean the buffer.

### Utility

In this page are present some utility functions:

- **Modem** - Some modem settings and general information.
- **Save/Load Configuration** - To save current settings in the device's memory or by the other hand, to load settings from one of the 10 available memory's indexes.
- Memory Usage (**Diagnostic**) - Information about memory usage.

### Utility - BERT / Redundancy

Settings related to **BERT** and **Redundancy** are present under this page.

### Traps

Traps sent from the device are stored in the **Traps** table.

### FTP

Settings related to download/upload firmware to/from device can be found here.

### Web Interface

Use this page to have access to the Web Interface provided by the device's web server (Only accessible in LAN environment).
