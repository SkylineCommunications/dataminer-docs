---
uid: Connector_help_Motorola_GX2-RX1000
---

# Motorola GX2-RX1000

The **Motorola GX2-RX1000** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-RX1000**.

## About

This connector provides a monitoring interface for the **Motorola GX2-RX1000** chassis.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 2.0.0.x          | DVE focused     | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | D                           |

## Usage

### General

This page displays general information about the card. **Unit Name**, **Module Type**, **Firmware** and **Hardware** version, **IP Address** and **Physical Address** are some of the parameters that can be found on this page.

### Digital Receiver

This page displays the parameters **Optical Power**, **Temperature**, **Heatsink Temperature**, **Fan Current**, **12V Current**, **Slope**, **Attenuation**, **Wavelength**, **Factory Default**, **Switch Mode Threshold** and **Switch Mode**.

### Alarms

This page contains all the **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
