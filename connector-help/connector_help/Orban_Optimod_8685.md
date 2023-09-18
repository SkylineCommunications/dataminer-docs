---
uid: Connector_help_Orban_Optimod_8685
---

# Orban Optimod 8685

The Optimod 8685 is a surround loudness controller from Orban. Its main goal is to automate loudness control in as straightforward a manner as possible. Its main features are:

- Support of audio from 2.0 to 7.1 surround
- Standard AES3id, SD, HD-SDI and optionally Dolby-E encoding/decoding
- Compliant with BS.1770 standard and the CALM Act (EBU R128)
- Dual redundant power supplies
- True peak control / 0 dBFS+
- Optimix upmixer stereo to 5.0

## About

This connector for the Orban Optimod 8685 supports monitoring only, with only basic configuration for the device identification and SNMP.

This connector uses the SNMP protocol to obtain and configure the data for the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.

SNMP Settings:

- **IP port**: The IP port of the device. The default is *161*.

## Usage

### General

This page contains general device information such as its **Name**, **Location**, **Up Time** and **Software Version**.

### SNMP

On this page, you can configure the network information for the SNMP protocol, i.e. the **IP** and **Port** configuration.

### Monitoring

This page contains all the status monitoring for the device. It displays information on the **General Status** of the **Optimix** and **Power Supplies**, several **Input Error Status** parameters, the **Loudness Status** of the streams, and the status for the **Silence Detection Software** points in the system.
