---
uid: Connector_help_GatesAir_Maxiva_ULX-OP_Driver
---

# GatesAir Maxiva ULX-OP Driver

The GatesAir Maxiva ULX-OP Driver was developed for the GatesAir Ultra-Compact series of broadcast transmitters/exciters/repeaters. These provide power levels from 1 to 600 W RMS in UHF bands IV/V or in VHF band III (depending on the model). The firmware of the modulator board is compatible with many different worldwide modulation standards, such as DVB-T, DVB-T2, ISDB-Tb, ATSC, DAB, DAB+, PAL, and NTSC. Also, different input board options are available, such as:

- Multi-stream DVB-S/S2 satellite receiver with integrated CAM
- A four ASI inputs board
- A two ASI inputs and two Gigabit Ethernet inputs (transport stream over IP) board
- An RF receiver board for operation as a repeater or iso-frequency gap filler
- A regenerative RF receiver board with full demodulation to baseband for operation as a regenerative repeater
- A board with analogue video and audio inputs, as well as ASI, for analog television

The equipment can be remotely controlled through SNMP protocol and a web GUI interface.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                                  |
|-----------|---------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | Software Release: 5.4.5 \| Kernel Release: 1.0.0 \| Ramdisk Release: 1.0.4 \| Controller Release: 3.6.7 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *161*

SNMP Settings:

- **Get community string**: *public*
- **Set community string**: *private*

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The driver provides the following pages:

- **General:** Displays the device's identification (name, serial number, kernel release, etc.), as well as its location and the point of contact.

- **System:** Allows you to configure the system date, its time reference (local, GPS, NTP) and the alarm temperature threshold.

- **TX Configuration:** Displays a table with the Tx configuration (presence and priority).
  - **PSU Alarms:** Displays a table with the PSU alarms (voltage and current).

- **Amplifier:** Displays the amplifier model.

- **Amplifier Alarms:** Contains an alarm table for monitoring power forward high/low, power reflected, feedback power and fans.

- **External Amplifier:** Allows you to monitor and configure the external amplifier (nominal, actual and reflected power, power percentage, switch mode, etc.).

- **External Amplifier Alarms:** Displays alarms for monitoring power forward high/low, power reflected, feedback power, temperature and fans.
  - **External PSU Alarms:** Displays a table with the PSU alarms (voltage and current).

- **Modulator:** DVB-T2 modulator overview (presence of 1PPS, 10MHz and TX frequency signals).

- **Modulator Configuration:** Displays a table with DVB-T2 settings, i.e. the channel number, country, channel offset and channel frequency.
  - **Modulator Alarms:** Displays a table with DVB-T2 alarms (e.g. temperature, 1PPS, 10MHz and TS presence, etc.).

- **Input:** Provides information related to the inputs (GbE1/2 and ASI1/2) TS status (locked, bitrate, ASI format and selected input) in table format.

- **Input Alarms:** Contains a table with input-related alarms (e.g. seamless inputs, 10MHz, 1PPS, hitless, etc.).

- **GbE:** Provides an overview of the GbE (source 1/2 status and selected source), as well as data related to the GbE status (TS, ASI format, TS bitrate, delay and alignment, etc.) and GbE Alarms (GbE1/2 lock and ASI1/2 Lock).

- **GbE Configuration Seamless:** Contains settings related to the GbE seamless (enable, input 1/2, forced input, source switch command and TS ID control).
  - **GbE Control Seamless:** Contains seamless control settings (enable mask, enabled alarm mask, user PID and interval).
  - **GbE Status Seamless:** Displays a table with seamless stream error counters (e.g. continuity, CRC, PAR, PMT, Sync Byte, Sync Loss, etc.).
