---
uid: Connector_help_NTT_Electronics_XVE9310
---

# NTT Electronics XVE9310

The **NTT ELECTRONICS XVE9310** can transmit full HD dual channel videos with built-in TS Multiplexer. 4K contribution by cascading two XVE9310s.

## About

Using this connector, is possible to monitor the hardware and performance status of XVE9310. It is also possible to change configuration on writable parameters. This connector uses a **SNMP connection** to retrieve data from this device and to set parameters on it.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 06.00                       |

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general device information (**Description**, **Version**, **System Uptime**).

There is a **Reset** button that can be used to perform a system-wide reset.

- Page Buttons:

- Memory
  - NTP
  - Test Signal

### Device Status Page

This page contains general information about the status of the device. Examples are **Device services, Temperature** and **Fan Status.**

### Alarms Page

This page displays the alarms reported by the device in a table format.

### Transport Stream Page

This page displays The format select of the **Stream** transmission, i.e Channel 1 Packet Type.

### Video Page

This page displays information related to the **Video Format.** Examples are **Video Aspect**, **Latency** **Mode** and **Entropy**.

### Audio Page

On this page can view the general information about Audio, such as **Audio Gain Level** and **Audio Map**.

- Page Buttons:

- Settings
  - Audio Gain Level
  - Audio Map Mode

### Ancillary

This page contains information about the **Encoder Ancillary**.

### Status ID

On this page can view the general information about **PID**, such as **Audio Packet ID** and **Video ID**.

- Page Buttons:

- Audio ID

### IO Page

This page displays information about **Output service.**

- Page Buttons:

- PSI
  - BISS

### IP Page

This page contains **IP** parameters. Examples are **IP Address**, **IP FEC** and **Encryption** of the channel.

### Device Settings

This page displays information about **Encoder Settings**.

- Page Buttons:

- Param Select

### Network

On the Network page you are able to view and configure the Control and Data.

- Page Buttons:

- Settings

### Web Interface Page

This page shows the device's Webinterface through DataMiner.

## Notes

Note that, the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
