---
uid: Connector_help_Anritsu_MS2712E
---

# Anritsu MS2712E

The Anritsu MS2712E is a **Compact Handheld Spectrum Analyzer** that perfoms complex interference analysis and assesses signal quality.

With this device, you can monitor, locate, identify and analyze a broad range of cellular 2G/3G/4G, land mobile radio, Wi-Fi, broadcast signals and CPRI RF.

## About

This connector retrieves data via **Serial Communication TCP/IP**. Commands are sent to the device with or without a response in return.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.21                        |

## Installation and configuration

### Creation

#### GPIB main connection

This connector uses a serial connection and requires the following input during element creation:

GPIB CONNECTION:

- Interface connection:

  - **Device address**: The polling device address of the device.
  - **I/O API**: The I/O API of the device.

## Usage

### Spectrum Analyzer

This page displays the **Spectrum Analyzer pane** and its related parameters, such as **Reference Level**, **Amplitude Scale**, **Start Frequency**, **Stop Frequency**, **Frequency Span**, **Center Frequency**, **Resolution Bandwidth**, **Video Bandwidth**, **Sweeptime** and **Input Attenuation**.

### General

This page shows information such as **Manufacturer**, **Model Number/Options**, **Serial Number**, **Firmware Number**, **Selected Mode**, **Operation Status** and **Installed Options.**

There is also a **Reset**, **Preset** and **Copy All Measurements** button. With the **DMS Spectrum Measurements** toggle button, you can put the spectrum analyzer in automatic sweep mode.

Finally, there is also a parameter to show the **Storage Location**, and a **Copy Destination** parameter.

### Web Page

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
