---
uid: Connector_help_Adtec_RD-71_-_PRX
---

# Adtec RD-71 - PRX

The **Adtec RD-71 - PRX** connector is a DVE created by the **[Adtec RD-71](xref:Connector_help_Adtec_RD-71)** connector.

## About

This connector is created when the **RD-71** device is using the **PRX** model demodulator board.

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [**Adtec RD-71**](xref:Connector_help_Adtec_RD-71), from version 1.0.1.x onwards.

## Usage

### Main View

This page contains important information about the device.

Some general parameters such as the **System Up Time,** **Status**, **Source**, **Source Status** are displayed on this page as well as **Local Oscillator** related parameters and **RF Status** parameters.

### General

This page contains general information about the device, such as the **Product Type, Product Name** and **Product Version**.

You can also find the IRD specific parameters on this page as well as a section to be able to select the active service running on the device.

### Network

In this page it is possible to see the **Entity IP Address** table.

### Chassis

In this page are displayed chassis specific information such as **Power Supply** and **Fan** information.

### IRD

Displayed on this page are among others:

- **Manual Local Oscillator**: Allows manual entry of the LNB frequencies provided either for C: Manual or Ku: Manual
- **Oscillator**
- **Low Band**: Allows you to enter the L-Band frequency.
- **Symbol Rate:** Represents the number of symbols transmitted per second.
- **Carrier Frequency Offset**

### Input

On the left side of this page are presented parameters related to the configuration of the Active Inputs, such as:

- **Oscillator:** Specifies the frequency of the LNB local oscillator.
- **Manual Local Oscillator:** Allows you to enter the LNB local oscillator frequency manually, provided that either **C: Manual** or **Ku: Manual** is selected.
- **Downlink**: Allows you to enter the satellite downlink frequency.
- **Acquisition Range**
- **Low Band**: Allows you to enter the L-Band frequency.

On the right side, you can find the following parameters related to the demodulator:

- **Type:** Allows you to select the mod type
- **Symbol Rate**
- **Mode:** Allows you to select the desired modulation mode and FEC code rate
- **Rolloff**

### Video

This page displays the genlock status and settings. It contains parameters such as **Lock State**, **Detected Reference Format**, **Out Video Standard**, **Cross Reference**, **Decode Status**, **Number Lock Lost**, **Reference Lost**, **Video Skips**, **Video Repeats**, **Genlock Settings**, **Mode**, **Horizontal Adjust**, **Vertical Adjust**, **Pixel Phase**, **CVBS**, **OSD Mode**, **Service Lines**, **Service Blink**, **Color Bar Mode**, **Type** and **OSD Size**.

### Audio

This page contains the **Audio Table**, where you can find parameters such as **PID Input**, **Offset**, which adjusts each individual pair of audio sync, and **Current**.

### CAS

This page contains information about the **CAS Mode**, **Key String A** and **Key String B**.

### Transport Service

This page displays all the information related to the **Transport Service Table** and **Services Tables**.

### Tuner Status

This page displays all of the **Tuner Status** table parameters.

### SAT Feed

This page displays all of the **SAT Feed** table parameters.

### LNB

In this page the **LNB table** allows for control over te **State**, **Polarity** and **Tone** of each of the available **LNBs.**

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
