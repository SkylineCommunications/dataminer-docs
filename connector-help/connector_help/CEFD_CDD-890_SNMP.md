---
uid: Connector_help_CEFD_CDD-890_SNMP
---

# CEFD CDD-890 SNMP

The CDM-890 multi-receiver router serves as the hub expansion utility component of Comtech EF Data's Advanced VSAT Series group of products.

## About

The CEFD CDD-890 connector is used to monitor and control a CEFD CDD-890 device. This connector is intended to get/set information from/to the device via an Element in a DataMiner System, using SNMP commands.

## Installation and configuration

### Creation

#### SNMP connection - Main

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- IP address/host: the polling IP of the device, *e.g.* *10.11.12.13*
- Device address: not required

SNMP Settings:

- Port number: the port of the connected device (default: 161)
- Get community string: The community string used when reading values from the device. The default value in the connector is *public*.
- Set community string: The community string used when setting values on the device. The default value in the connector is *private*.

## Usage

### General page

This page displays information about the **System Information**, **Service Contact** and **Device Overall Status**.

### Admin page

The **Admin** page displays the selected configuration and options. The page shows information about the **FAST Configuration** and it is possible to set the **SNMP Configuration**, **Auto Logout Configuration**, **CTOG** and **MEO**.

Also there are two page buttons available that will open pop-up pages which display additional information regarding the subject stated on the page button. It concerns the **Firmware Configuration** and the **Vipersat Management System Configuration**.

### Configuration - Interface page

This page is used to assign the device's IPs using the **Interface Table** and also to set the **Port Diversity** function.

### Configuration - WAN - Demod page

All related demodulator configurations are done in this page. The individual configurations are set using the **Individual Demodulator Settings** Table and the global configurations under the **Global Demodulator Settings** label.

### Configuration - WAN - ACM page

In this page the **Rx ACM Log** and the **Link Adaptation Config Table** are available.

### Configuration - WAN - LNB page

This page can be used to set the **LNB** **Control** configurations and to check its meausurements under the **LNB Status** label.

### Configuration - Network page

On this page, several configurations can be done.

- In the **ARP Table** the ARP configurations can be set. New entries can be added to the table using the pop-up window that opens by the **Create New entry...** page button.
- The **Working Mode** is used to set the Working Mode to *Router* or *BPM*.
- The Encryption ... page button makes it possible to set the 8 **Encryption Keys**.

### Configuration - Network - Routing page

Still related to the Network configuration, the **Route Table** can be found here as well as the **Mesh Location** setting.

### Configuration - ECM page

The **ECM Remote Configuration** can be set on this page and the **ECM Remote Status** can be consulted.

### Status - Stats - Interface page

In this page it is possible to check the interfaces rates in the **Interfaces Information** table.

### Status - Stats - Traffic page

In this page, the **Ethernet Stats Table** is available.

### Status - Stats - Demod page

Several status tables related to the demodulator are available in this page:

- **Demod Status Table**
- **Link Adaptation Status Table**
- **VS Status Table**

### Status - Stats - Router page

This page displays the **Interface**, **Routers** and **Management Counters**. The **Clear Statistics** button clears them all.

### Status - Stats - Managed Switch page

The **Managed Switch Statistics** and the **Managed Switch LAN Statistics** are display on this page.

### Status - Monitor - Alarms page

Various information about alarms can be found here:

- Alarms - **Unit**, **LNB**, **Traffic Ethernet** and **PTP** general **Alarms**.
- Rx Alarms - Related to the Demodulators.

- **Demodulator Alarms...** - In depth information about **Demod Alarm State**/**Mask**.
- **Unit Alarms...** - In depth information about **Unit** **Alarm States**/**Masks**.

### Status - Monitor - Events page

If there's an event on the device, it will be shown in the **Event Table**. The **Clear** button can be use to clean the buffer.

### Utility page

In this page some utility functions are present:

- **Modem** - Some modem settings and general information.
- **Save/Load Configuration** - To save current settings in the device's memory or to load settings from one of the 10 available memory's indexes.
- Memory Usage (**Diagnostic...**) - Information about memory usage.
- The **Time Synch...** page button makes it possible to synchronize the device.

### Utility - BERT / Redundancy page

Settings related to **BERT** and data related to **BERT Monitor** and **Redundancy** are present on this page.

### Traps page

Traps sent from the device are stored in the **Traps** table.

### FTP page

Settings related to download or upload firmware to and from the device can be found here.

### Web Interface

Use this page to have access to the Web Interface provided by the device's web server. The client machine has to be able to access the device. If not, it will not be possible to open the web interface.
