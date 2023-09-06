---
uid: Connector_help_Motorola_GX2-DRR-3X
---

# Motorola GX2-DRR-3X

The **Motorola GX2-DRR-3X** driver is an SNMP-based driver used to monitor and configure the **Motorola GX2-DRR-3X.**

## About

This driver provides a monitoring interface for the **Motorola GX2-DRR-3X** chassis.

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

### Digital Receiver

This page displays the parameters **Channel A**, **B** and **C RF Attenuation**, **Trippoint Level**, **Power Current**, **12V Current**, **Temperature**, **Fan Current**, **Trippoint Mode**, **Front Panel Test** and **Default Reset**.

### Alarms

This page contains all the **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
