---
uid: Connector_help_Motorola_GX2-LM1000-E
---

# Motorola GX2-LM1000-E

The **Motorola GX2-LM1000-E** driver is an SNMP-based driver used to monitor and configure the **Motorola GX2-LM1000-E**.

## About

This driver is exported from the Motorola GX2-CM100 B and provides a monitoring interface for the **Motorola** **GX2-LM1000-E** card.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |
| 2.0.0.x          | DVE focused     | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 2.0.0.x          | D                           |

## Usage

### General

This page displays general information about the card. **Unit Name**, **Module Type**, **Firmware** and **Hardware** version, **IP Address** and **Physical Address** are some of the parameters that can be found here.

### Forward Transmitter

This page displays both **analog** and **digital** parameters: **Offset Monitor**, **Offset Control**, **Attenuation**, **Optical Power**, both **Laser BIAS** and **Temperature**, **Temperature**, **Fan** and **12V** **Current**, **RF Input**, **Optical Power Output**,**Laser Mode**, **Video Offset, Fiber Length, Laser Secondary Mode** and **Factory Default**.

### Alarms

This page contains all **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
