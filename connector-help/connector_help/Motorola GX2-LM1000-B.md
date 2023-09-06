---
uid: Connector_help_Motorola_GX2-LM1000-B
---

# Motorola GX2-LM1000-B

The **Motorola GX2-LM1000-B** driver is an SNMP-based driver used to monitor and configure the **Motorola GX2-LM1000-B.**

## About

This driver provides a monitoring interface for the **Motorola GX2-LM1000-B** chassis.

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

### Broadcast Transmitter

This page displays both **analog** and **digital** parameters: **Offset Monitor**, **Offset Control**, **Attenuation**, **Optical Power**, both **Laser BIAS** and **Temperature**, **Temperature**, **Fan** and **12V** Current, **RF Input**, **Laser Mode**, **Video Offset** and **Factory Default**.

### Alarms

This page contains all the **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
