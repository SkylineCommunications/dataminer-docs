---
uid: Connector_help_Ramiaudio_Watchdog_CS510
---

# Ramiaudio Watchdog CS510

The Ramiaudio Watchdog CSS510-2 is designed to continuously monitor five stereo digital audio sources.

## About

This connector displays information that is polled from the device with **SNMP**. Each parameter will be written to the SNMP configuration, and must be saved before being applied to the device.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x \[SLC Main\] | 1.3                         |

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General Page

This page displays general information, such as the **Name** and **Version**.

Below the parameters, you can find the following buttons:

- **System Reset**: Reboots the device.
- **Refresh Device Info**: Polls the **Name**, **Version**, **Date**, **Serial Number**, **System Date Time** and **Device Label** immediately.
- **Set Switch Mode**: Changes the **Switch Mode** of the device to either *Manual* or *Auto*.
- **Monitor** buttons: These set the current monitoring channel to any of the 5 different channels.
- **Force Input**: Changes the **Switch Mode** to *Manual*, and then sets the current input channel to any of the 5 different channels.
- **Refresh All**: Polls every parameter in the connector again.

### Inputs Page

The **Input Table** is located on this page, displaying controls for the inputs of the device. The information in the table can be refreshed using the **Refresh Table** button.

Via a page button, you can access the **Input Status** table.

On the **Controls** pop-up page, you can access and modify the **Monitor Input**, **Active Input** and **Switch Mode** parameters. Below those, you can find the **Manual Mode**, **Audio Output** and **Bypass Status** parameters.

### Traps Page

The **Inactive**, **Output**, **Software Mode**, **Manual Mode** and **Bypass Trap** states can be found on this page. Each state is either *Invalid*, *Disabled*, or *Enabled*. There are also controls for the **SNTP Server**, **Timezone** and **Interval.**

The **Trap Destinations** table is displayed via a page button.

### AES Error Page

The **Error AES Table** is displayed on this page, which contains information such as the status of the **Validity** or **Confidence.**

### Web Interface Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
