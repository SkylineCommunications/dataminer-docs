---
uid: Connector_help_Keysight_U2040_X-Series
---

# Keysight U2040 X-Series

The Keysight U2040 X-Series is a device capable of executing power measurements over multiple measurement points. This connector can be used to monitor the power measurements collected by this device.

## About

The U2040 X-Series wide dynamic range power sensors consist of four USB models and a LAN model:

- U2041XA USB wide dynamic range average power sensor (10 MHz to 6 GHz)
- U2042XA USB peak and average power sensor (10 MHz to 6 GHz)
- U2043XA USB wide dynamic range average power sensor (10 MHz to 18 GHz)
- U2044XA USB peak and average power sensor (10 MHz to 18 GHz)
- U2049XA LAN power sensor (10 MHz to 33 GHz, LXI Class C compliant)

The U2040 X-Series is capable of measuring the average and peak power of modulated, pulsed, and continuous wave (CW) signals in a 10 MHz to 33 GHz frequency range and -70 dBm to 26 dBm power range.

The U2049XA is capable of long-distance remote monitoring of up to 100 meters via the Power over Ethernet (PoE)/LAN connectivity. The PoE connectivity complies with the IEEE 3 W, 802.3af or 802.3at Type 1 standard.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | A.02.04                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page displays basic information on the device, such as the **Vendor**, **Model**, **Serial Number** and **Firmware Version**.

### Measurements

On this page, you can **reset all configuration** on the device with the **Presets** button, set a **frequency value for measurements** and check the measurements in the **Measurements Table.**

The **Value** column in the **Measurements Table** supports **Trending** and **Alarm monitoring**.

### Calibration

This page provides access to the calibration methods of the device such as **Zero** calibration, **Calibration** and **Calibration + Zero**. It also allows you to set the **Auto Calibration State** and the **Zero Calibration Type**.
