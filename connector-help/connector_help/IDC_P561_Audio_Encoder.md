---
uid: Connector_help_IDC_P561_Audio_Encoder
---

# IDC P561 Audio Encoder

The P561 Audio Encoder features MPEG-4 advanced audio coding (MPEG-4 AAC) and MPEG Layer II encoding capabilities. All of the common bit rates and sample rates are offered to enhance the IP delivery of audio.

The P561 is an audio encoder for up to eight stereo channels, capable of transporting elementary streams over IP and DVB-compliant MPEG-2 transport stream output via IP or ASI.

## About

The **IDC P561 Audio Encoder** connector is used to monitor and control a P561 Audio Encoder device. It provides an overview of the different parameters of the device along with its statuses and generated alarms. The connector uses **SNMP** to retrieve the data from the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device, by default *skyline*.
- **Set community string**: The community string used when setting values on the device, by default *skyline*.

## Usage

### General

This page contains general information on the device, such as the **System Description, Uptime, System Contact, System Name, Location, Device Name, Device Type, Language, Reboot** and **External Clock**.

### Alarm

This page displays information about alarms on the audio level: **Origin, Channel Index, Audio Channel, Cause** and **Status**.

### Interface

This page allows you to manage information about the **Interfaces, System Network Interface Configuration** and **System Network Interface Status**.

### Encoder

This page allows you to manage all the information about the **Encoder**.

### Decoder

On this page, you can view and configure the **Channel Status, Channel Common** and **Ancillary Data**.

### Transport Stream

This page allows you to configure the transport streams on the device.

The page also displays the number of entries used in each UDP and the settings of the PSI.

- **Entries:** **TS UDP 1 IP in Use** up to **TS UDP 16 IP in Use**. To facilitate the use of the information provided in the MIB file, these entries are gathered from all the tables in the MIB file to just display a single table with all available entries.
- **Settings:** PSI Transport Stream ID, PSI Original Network ID, PSI Network ID, PSI Network Name and PSI Program Count.

### IRD

On this page, you can manage the following information:

- **Oscillator:** Receive Frequency, Low Band Intermediate Frequency and Low Band State
- **Satellite:** LNB Control System, LNB Control Power, LNB Control 22KHz, LNB Control Polarization Horizontal and LNB Control Satellite ID.
- **Status:** Transponder, Transponder Frequency, Satellite Transponder Symbol Rate, Satellite Standard, Satellite Puncture Rate, Satellite ModCode, Satellite Modulation, Satellite Pilots, Satellite Frame Length, Satellite Roll Off, RF Power, RF Carrier to Noise, RF BER and Satellite IQ Inversion.
- **Search:** Search Receive Frequency and Transponder Symbol Rate.

### Status

This page displays information about the **Encoder Channel Status**.

### Polling Flags

This page shows which transport stream is used: **Transport Stream UDP 1** to **16 Polling**.
