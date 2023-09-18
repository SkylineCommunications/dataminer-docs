---
uid: Connector_help_Kubotek_MNB960
---

# Kubotek MNB960

The Kubotek MNB960 is a **Encoder / Decoder** device.

## About

SNMP based connector for the Kubotek MNB960.

### Version Info

This will list the different ranges of this connector and a short description what the reason of the range change was.

| **Range** | **Description**                                                                                 |
|------------------|-------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Initial version for the Kubotek MNB960v1                                                        |
| 1.1.0.x          | Initial version for the Kubotek MNB960v2. Different firmware version than the Kubotek MNB960v1. |

### Product Info

This will list the firmware versions that are fully compatible with the connector per connector range.

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | MNB960ENC MNB960DEC         |
| 1.1.0.x          | MNB960V2ENC MNB960V2DEC     |

## Installation and configuration

### Creation

***SNMP connection***
This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host:** The polling IP of the device

SNMP Settings:

- **Port number**: \[The port of the connected device (default: *161*)\]
- **Get community string:** The community string used when reading values from the device (default value: *public*).
- **Set community string:** The community string used when setting values on the device (default value: *private*).

## Usage

This connector contains 6 pages.

### General

The General page contains **general information** regarding the device itself.

It is possible to find a toggle button, **Type of Device** , which the user has to change to meet the device type (**Encoder or Decoder**).

This page, also, displays the **Encoder/Decoder State**, **Temperature** and **Firmware Version**.

### Encoder Monitor

This page displays the monitoring parameters of the **Encoder** device. It shows the **Audio** and **Video Sources**, **IRQ Counters**, **CPU buffer**, **DMA buffer**, **Vbit Counter** and **Vbit Offset**.

It also has information regarding **Networking Configuration** (**IP Addresses**, **Unicast/Multicast**, **Port** and **LAN1/LAN2 Link States**)

### Encoder Configuration

The Encoder Configuration page, allows the user to change configuration settings like: **Method**, **Shapping**, **Media Type**, **Frame Rate**, **Camera**, **Video** and **Audio Input Source**, **Frame Size**, **Video** and **Audio Bit Rate**.

It also contains **Encoder Network** page button with **network configurations settings** (**Addresses**, **Ports**, **TTL**, **TOS**, **NTP**, **NAT**, **LAN1** and **LAN2 settings**). The **MNB960v2** adds **WLAN configuration settings.**

### Decoder Monitor

The Decoder Monitor page holds information like: **VSYNC Counter**, **Frame Counter**, **Audio Frame Counter**, **Audio and Video PTS**, **AV Sync Counter**, **Audio Mute Counter**, **Video Error Level**, **VCXO**, **Packets/Sec**, **Total Received Packets**, **Loss Packets**, **Loss Data** and **Parity Packets**, **Correct Packets**, **Recovery Requests**, **Recovery ACKs** and **Received Bit Rate**.

### Decoder Configuration

This page contains settings like **Media Type**, **Auto Start**, **Frame Rate**, **Display Size**, **Genlock HPhase** and **VPhase**.

It has a **Decoder Network** page button with **network configurations settings**, like the Encoder Network page button. The **MNB960v2** adds **WLAN configuration settings**.

### Web Page

Displays the web interface of the device.

The client machine has to be able to access the device. If not, it won't be possible to open the web interface.
