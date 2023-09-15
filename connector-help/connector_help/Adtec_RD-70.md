---
uid: Connector_help_Adtec_RD-70
---

# Adtec RD-70

The **Adtec RD-70** is a 1080P multi-CODEC very low latency MPEG 2 and MPEG 4 AVC/H.264 high-definition IRD. The RD-70 is interoperable with other encoders, making it ideal for mission-critical ASI/IP trunking, ad-hoc OB, DSNG and teleport applications.

## About

This connector retrieves information from the device using **SNMP**. All the device information is displayed by the connector in a format similar to that of the device web interface. The connector allows one SNMP trap *"Decoder Status Change"* (OID 1.3.6.1.4.1.19587.6006.1.1000), from which it repolls the *"Decoder Status"* parameter's group.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.02.11                     |

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

### General

This page contains general information about the device, such as the **Product Type**, **Product Name** and **Product Version**.

### Status

This page contains IRD status information, such as **Source**, **Source Status**, **Program**, **PCR**, **PMT**, **STC**, **Input Transmux Rate** and **Video Transmux Rate**.

### Input

This page contains information about the active inputs, services and IP parameters.

The following parameters related to the active inputs can be found on RF subpages:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator**: Allows you to enter the LNB local oscillator frequency manually, provided that either C: Manual or Ku: Manual is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-Band frequency.

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset** (which adjusts each individual pair of audio sync) and **Current**. This page also contains the **Volume**, **Dolby Digital** and **Pairs** configuration.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**. It also contains **BISS** information.

### Device Status

This page displays the status of the **Power Supplies** and **Fans** of the device.

### Network

This page displays the **Interfaces** and **Interfaces Extended** tables.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
