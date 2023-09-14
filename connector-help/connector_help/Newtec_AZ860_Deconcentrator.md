---
uid: Connector_help_Newtec_AZ860_Deconcentrator
---

# Newtec AZ860 Deconcentrator

The Newtec AZ860 concentrator/deconcentrator is used to realize transparent and efficient transmissions of several MPEG transport streams on a single transmission channel, such as a Satellite DVB-S or DVB-S2 carrier, or a terrestrial leased line.

## About

This connector is to be used as a deconcentrator.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                  |
|------------------|----------------------------------------------|
| 1.0.0.x          | Hardware version: 6.0 Software version: 2.07 |

## Installation and creation

### Creation

#### Serial connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host:** The device IP.
- **IP port:** The default value is *5933*.
- **Bus address:** The default value is *100*, but a custom value can be specified.

### Configuration

For this connector to work properly, make sure the **RMCP version** on the device itself is set to **v2.0** (web UI).

## Usage

### General Page

This page displays general device information, as well as the operating mode. The page contains several page buttons:

- **Device Info**: Displays device **Software** and **Hardware** information such as **Version**, **Product ID**, **Serial Number** and **Capabilities**.
- **Display**: This page allows you to control the device **Display Settings**.
- **Power Supply**: Displays **Power Supply** information.
- **Security**: This page displays **Security** information, such as the **Password** and **Licence Key**.
- **Ethernet**: Displays **Ethernet** information. It is also possible to configure the **Ethernet Interface**.
- **Serial**: This page allows you to control serial settings such as the **Device Address** and **Serial Baudrate**.
- **Config**: On this page, you can **Save** and **Load** up to 48 different operational configurations in permanent memory.

The page button **Security** is used to enter the credentials.

### Deconcentrator

This page displays information about the deconcentrator. The page contains two page buttons:

- **Outputs**: This page can be used to configure **Output Framing** and **Signal** settings for the different **Outputs**.
- **Channels**: This page allows you to configure the settings regarding the **Scrambling Mode** and **Descrambling Key** for each channel.

### Alarms

This page displays all available alarms reported by this device.
