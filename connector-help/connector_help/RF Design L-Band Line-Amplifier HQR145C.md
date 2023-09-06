---
uid: Connector_help_RF_Design_L-Band_Line-Amplifier_HQR145C
---

# RF Design L-Band Line-Amplifier HQR145C

This connector monitors the HQR145C amplifier, which is a 1:1 redundant L-band line amplifier (950 to 2150 MHz) with variable gain adjustment in 1 dB steps, variable gain control (MGC/ AGC), slope equalization, RF power monitoring, threshold alarming, two front-panel monitoring ports, and 1:1 redundant dual power supply (hot-swappable). The unit comes with two independent and 1:1 redundant amplifier boards together with an internal RF switch and 1:1 redundant power supplies. This line amplifier is typically used for RF distribution infrastructures in teleports, satellite earth stations, and broadcast and broadband facilities.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (usually *161*).
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

## How to Use

### General Page

These are the main parameters on this page:

- **Remote Status**: Indicates whether the local login is used or not.

- **Unit Status**: Shows the general status of the amplifier (*OK*, *Alarm*, or *Warning*).

- **K3/4**: *Warning* if one of the two local PSUs has a fault or a slave has a PSU fault, *Alarm* if a local matrix MUX has an error, a slave matrix MUX has an error, or a module status is *Alarm*.
  - **MFC3**: *Warning* if one of the two PSUs has a fault.

- **Power Supply Status (1/2)**: Shows the status of the corresponding power supply.

- **Unit Config**: Router config slave quantity or MFC slot quantity.

- **MFC**: 00 = 1 slot unit, 01 = 2 slot units, 02 = 4 slot units, 03 = 8 slot units, and 04 = 16 slot units.
  - **K3/S3**: 00 = no slave connected; 01 - 99 = the quantity of connected slaves.

- **Quantity of Inputs**

- **Quantity of Outputs**

- **Bus Delay**: K33: IýC-bus delay in milliseconds.

- **Debug Level**: Debug level output on external RS232 (*No debug*, *Debug 1*, or *Debug 2*).

- **Config Byte**: Numerical value represented by the Device Type parameter.

- **Device Type**: *MFC3*, *K3/S3*, *K3/S3 Ext*, *MFC3 Red*, *K4*, *MFC3 Red Ext*, or *K33*.

- **Unit Serial Number**

- **Firmware Version**

- **Display Version**

### Module 1 and 2 Pages

These two pages show information related to different aspects of the modules: general information, RF power, limiter, THD (Total Harmonic Distortion), AGC (Automatic Gain Control) and amplifier redundancy.
