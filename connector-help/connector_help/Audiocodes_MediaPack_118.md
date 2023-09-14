---
uid: Connector_help_Audiocodes_MediaPack_118
---

# Audiocodes MediaPack 118

AudioCodes' MediaPack 1xx series of analog VoIP gateways are cost-effective, standalone VoIP gateways that provide superior voice technology to connect legacy telephones, fax machines and PBX systems with IP telephony networks and IP-based PBX systems. The MediaPack 1xx series gateways support a wide variety of service provider and enterprise applications.

## About

This is an SNMP-based protocol for Audiocodes MediaPack 118 telephone gateways.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | GW 8 FXS                    |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device.
- **Get community string**: The community string used when reading values from the device, by default *public*.
- **Set community string**: The community string used when setting values on the device, by default *private*.

## Usage

### General

This page displays general device parameters such as the **System Description** and **System Uptime**.

### Alarms

This page contains the **Active Alarms Table**, which displays all the active alarms on the device.

### Application Settings

This page contains general settings for the device, such as **NTP** and **Daylight Saving Time**.

### Interfaces

This page contains the **Interfaces Table**, which contains information such as the **incoming**/**outgoing** packets, **errors**, **discards**, **bitrate**, and both **in** and **out utilization**.

### Trunk Settings

This page contains the **Trunks and Trunk Status tables**, with detailed information on the trunks.

### Trunk Utilization

This page contains a table with utilization information on each trunk, such as the interval, utilization, average, max, min, volume, etc.

### Routing General Params

This page contains information on general routing settings.

### Performance

This page contains **IP to Tel** and **Tel to IP** call statistics. There is also a **Reset Frequency** parameter, which can be used to reset all parameters on the page based on the selection (*Manual*, *Daily* or *Monthly*).

### Tel to IP Routing

This page contains the **Tel to IP Routing Table**, where you can modify the **Route** **Name**, **Destination** **Phone**, **Destination** **IP**, **Transport** **Type**, etc.

### IP to Tel Routing

This page contains the **IP to Tel Routing** **Table**, where you can modify the **Route Name**, **Source IP Address**, **Destination Phone**, **Phone Prefix**, etc.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
