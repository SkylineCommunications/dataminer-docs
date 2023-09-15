---
uid: Connector_help_Paradise_P3000_PD25_Evolution
---

# Paradise P3000 PD25 Evolution

The **Paradise P3000 PD25 Evolution** is a **Satellite Modem**.

The Evolution Series PD25 has been designed for cost-critical modem applications and discern-ing users who demand quality and reliability at an affordable price. This 25 Mbps capable modem offers full compliance with IESS-308, 309, 310, 314 & 315, plus a range of data interfaces including Ethernet

## About

The Paradise P3000 PD25 Evolution connector retrieves data via **SNMP**.

### Version Info

| **Range**     | **Description**                                                                                                                                 | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                                                                                                 | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | Added Firmware Version Controller to support different versions Added new Firmware ParametersReorganized pages without moving parameters across | No                  | Yes                     |

### Product Info

| **Range**     | **Device Firmware Version** |
|----------------------|-----------------------------|
| 1.0.0.x              | 1.6.57b                     |
| 1.0.1.x \[SLC Main\] | 1.6.57b, 1.6.74             |

## Installation and configuration

### Creation

#### SNMP connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device (default value if not overridden in the connector: *public*).
- **Set community string**: The community string used when setting values on the device (default value if not overridden in the connector: *private*).

## Usage

### Unit

This page displays the data regarding the unit itself: **Modem ID**, **Manufacturer ID**, **Serial Number**, **Software and Firmware Versions**, **Board Configuration**, **RX/Tx OneForOne Changeover**. It also shows the cards that are "Fitted" or "Not Fitted" .

There is a page button that leads to the following subpages: **Unit Alarms**, **M&C**, **Station Clock**, **Special Modes**, **Operation** and **SAF**.

### Monitor

The Monitor page displays **Tx and RX Data Rates**, **Loopback Status** and the **Modem Temperature**.

Contains the **Voltages** page button, which shows the **Voltages of the modem**.

### Status

The Status page shows data related to the **transmission and reception** of data **(IF-Band Carrier Frequency**, **Data Rate**, and **Symbol Rate**). It contains information regarding the **Demodulator**, such as: **Rx Eb/No**, **Final BER**, **RX Power Level**, **RX Buffer Fill Status** and **Demodulator Status**.

### Alarms

The Alarms page displays the **Tx and Rx Alarms**.

### Tx Configuration and Rx Configuration pages

This two pages allow the user to view and modify configurations, such as: **Service**, **BaseBand Mode**, **Path Clock Source**, **Modulation**, **FEC**, **Scrambler Mode**, **Carrier Mode** and **Spectral Inversion**.

Both have the following page buttons with the corresponding configuration: **Clocks**, **Demodulation**, **FEC**, **Descrambler**, **Carrier**, **Framing**, **Timeslots**, **Closed+ESC**, **IBS/SMS**, **IDR** and **BUC/LNB**.

### Paired Carrier

This page shows all Paired Carrier configuration parameters, related to the **Satellite Coordinates** and **Round Trip Delay.**

### Interface

This page shows all the configuration parameters for the interfaces.

It contains multiple subpages such as **IP Address**, **IP Miscellaneous** and **G.703.**

### SNMP

This page allows the configuration of the SNMP interface.

### Email

This page allows to configure the Email parameters.

### Network

This page allows to configure the network routes.

### Memories

This page allows to save, recall and delete configurations.

To perform the save, recall and delete commands the DMA must be logged on the PUP protocol. Check **PUP Manager** below to read the details about the Log In.

The page contains a **Save Configuration File Name** which needs to be set in order to be able to save the configuration.

Additionally there is a toggle button that can be used to enable/disable the use of a recall delay when pressing the recall button of a specific configuration. This makes the recall to only be taken after the time defined on **Recall Delay.**

### 1-for-N

The page allows to configure the **CPU Modem Priorities**.

### Test

In this page, the user can modify the **Loopback**, **PRBS** **BER Modes**, **PRBS Channels** and **PRBS Patterns**.

### PUP Manager

In this page, the user can log himself by inserting the **Administrator Password** defined for the UI and pressing Log In.

This action is required to allow interactions with the configuration memory management.

Additionally, one can see the incoming response from a **PUP command request.**

### Web Interface

This page displays the web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

### Firmware Management

The connector is built to allow multiple firmware versions. If a firmware version is not described in the supported firmware, the device will try to fit the most adequate version.

The most adequate version is the closest and lowest version compared to the current firmware version.

E.g. Current Firmware Version 1.6.58 - the most adequate version will be 1.6.57b.

E.g. Current Firmware Version 1.6.79 - the most adequate version will be 1.6.74.
