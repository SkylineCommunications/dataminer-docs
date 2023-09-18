---
uid: Connector_help_Adtec_RD-60
---

# Adtec RD-60

The Adtec RD-60 is an Integrated Multi-CODEC Receiver/Decoder. This MPEG 4/MPEG 2 capable IRD includes ASI, Composite and 3G HD-SDI (x4 Bank A and B). It also includes 2 Dolby E Passthru and 4 stereo pairs (8 mono) of MPEG-1 Layer 2, with an optional upper 4 stereo pairs (8 stereo pairs or 16 mono channels), and features BISS-1/E decryption, genlock with frame store and redundant AC power supplies, and optional DVB-S/S2 demodulator packages.

## About

This connector was designed for use with the models **Adtec RD-60** and **Adtec RD-70**. Information is retrieved from the device and sets are done by the connector via the **SNMP** protocol. All the device information is displayed by the connector in a format similar to that of the device web interface. The connector allows one SNMP trap *"Decoder Status Change"* (OID 1.3.6.1.4.1.19587.6006.1.1000), from which it repolls the *"Decoder Status"* parameter's group.

The range 1.1.0.1 only supports the **Adtec RD-60**.

### Version Info

| **connector Range** | **Description**                              | **DCF Integration** | **Cassandra Compliant** |
|------------------|----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                              | No                  | Yes                     |
| 1.0.1.x          | connector review and expansion to support RD-70 | No                  | Yes                     |
| 1.1.0.x          | New update for the RD-60                     | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.11.03                     |
| 1.1.0.x          | 1.13.03                     |

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

## Usage - Versions prior to 1.1.0.1

### Main View

This page contains important information about the device. The **System Up Time** is the total time the device has been up and running. **Status**, **Source**, **Source Status**, **Local Oscillator**, **Input Transmux Rate** and **Status Transmux Rate** are other important parameters displayed on this page.

### General

This page contains general information about the device, such as the **Product Type**, **Product Name** and **Product Version**.

You can also find the **Temperature**, **Status**, **Source**, **Source Status**, **Program**, **PCR**, **PMT**, **STC**, **Input Transmux Rate** and **Video Transmux Rate** on this page.

### IRD

This page displays the **LBN1 and LBN2 Availability**, which allows you to enable or disable power on the input connector to the power of the LNB. The **Polarity** control allows you to select LNB polarization. The **Tone** parameter can be used to route the high or low band from either polarity to the IRD.

Other parameters displayed on this page are among others:

- **Carrier Frequency Offset**
- **Manual Local Oscillator**: Allows manual entry of the LNB frequencies provided either for C: Manual or Ku: Manual.
- **Oscillator**
- **Low Band**: Allows you to enter the L-Band frequency.
- **Symbol Rate:** Represents the number of symbols transmitted per second.

### Input

This page contains information about the active inputs and demodulator parameters.

The following parameters related to the active inputs can be found on the left-hand side of the page:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator**: Allows you to enter the LNB local oscillator frequency manually, provided that either C: Manual or Ku: Manual is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-Band frequency.

On the right-hand side, you can find the following parameters related to the demodulator:

- **Type**: Allows you to select the mod type.
- **Mode**: Allows you to select the desired modulation mode and FEC code rate.
- **Rolloff:** Determines the shape of the input filter.
- **Frame Type**
- **CCM**
- **Symbol Rate**
- **Pilot**: Allows you to reduce the data rate by approximately 3.0%.

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset** (which adjusts each individual pair of audio sync) and **Current**.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**.

### Transport Services

This page displays all the information related to the **Transport Service Table** and **Services Tables**.

### Embedded Web Server

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## Usage - From version 1.1.0.1 onwards

### General

This page contains general information about the device, such as the **Product Type**, **Product Name** and **Product Version**.

You can also find the **Temperature**, **Status**, **Source**, **Source Status**, **Program**, **PCR**, **PMT**, **STC**, **Input Transmux Rate** and **Video Transmux Rate** on this page.

### Input

This page contains information about the active inputs and demodulator parameters.

The following parameters related to the active inputs can be found on the left-hand side of the page:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator**: Allows you to enter the LNB local oscillator frequency manually, provided that either C: Manual or Ku: Manual is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-Band frequency.

On the right-hand side, you can find the following parameters related to the demodulator:

- **Type**: Allows you to select the mod type.
- **Mode**: Allows you to select the desired modulation mode and FEC code rate.
- **Rolloff:** Determines the shape of the input filter.
- **Frame Type**
- **CCM**
- **Symbol Rate**
- **Pilot**: Allows you to reduce the data rate by approximately 3.0%.

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset** (which adjusts each individual pair of audio sync) and **Current**.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**.

### Services

This page displays all the information related to the **Transport Service Table** and **Services Tables**. The page also contains the tables **Service Detail** and **TMR**.

### Device Status

This page displays the status of the **Power Supplies** and **Fans** of the device.

### Network

This page displays the **Interfaces** and **Interfaces Extended** tables.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
