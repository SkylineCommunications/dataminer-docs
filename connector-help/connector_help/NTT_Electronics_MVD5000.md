---
uid: Connector_help_NTT_Electronics_MVD5000
---

# NTT Electronics MVD5000

This connector is used to monitor and configure the **MVD5000** decoder from **NTT Electronics**.

## About

This connector contains different pages with information and settings. More detailed information on these can be found in the **Usage** section of this document. The connector uses the **SNMP** protocol to communicate with the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |
| 1.0.1.x          | DCF Integration | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MVD5000 FirmVersion.04.30   |
| 1.0.1.x          | MVD5000 FirmVersion.04.30   |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general information about the device, such as the **Firmware Version**, **Serial Number** and **Mac Address**.

### Status

This page displays information about the status of the device, including the **Device Icon**, **Temperature** and **Fan Status**.

The page includes the following page buttons: **Alarms**, **Audio** **Decoding**, **Video** **Decoding**, **Packets** **Counter**, **Seamless** **Protection**, **Input** **Aux** and **Input** **Stream**.

### Configuration

This page allows you to view and configure the device settings.

The page includes the following page buttons: **Output**, **Decode**, **Multicast**, **Receive Error Correction**, **Receive Common** and **Receive AUX**.

### Network

This page allows you to view and configure the Gigabit Ethernet interface (**GbE Interface**) and the Fast Ethernet interface (**FE Interface**).

Additional settings are available via the **Net FE Advanced** and **Net GbE Advanced** page buttons.

### Network Services

This page allows you to view and configure the SAP, pass through, syslog and SNMP trap information. It includes the **SAP** and **Pass Through** page buttons.

### Administration

This page displays general information about the device and allows you to configure the **Time Zone**, **Date and Time**, **NTP Server Address**, etc.

At the bottom of the page, two buttons are available that allow you to **synchronize the clock** and **reset** the device.

### Preferences

This page allows you to view and configure the preset information.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

The **1.0.1.x** connector range of the **NTT Electronics MVD5000** protocol supports the usage of DCF and can only be used on a DMA with **8.5.7.2** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **IP Input FE**: Physical IP FE interface with type **in**.
- **IP Input GbE**: Physical IP GbE interface with type **in**.
- **ASI Input**: Physical ADI with interface with type **in**.
- **SDI Output**: Physical SDI interface with type **out**.
- **SDI Analog Audio Output**: Physical SDI with analog audio interface with type **out**.

### Connections

#### Internal Connections

Connections are made based on the parameters **Audio/Video** **Interface**, **Receive** and **Receive Interface** on the **Configuration** page.

The connections start from the selected input interface and go to both the **SDI Output** and the **SDI Analog Audio Output**. If **Receive** is **disabled**, no connections are made.
