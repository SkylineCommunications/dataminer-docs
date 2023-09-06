---
uid: Connector_help_Motorola_GX2-CM100_B_-_GX2-LM1000-E
---

# Motorola GX2-CM100 B - GX2-LM1000-E

The **Motorola GX2-CM100 B - GX2-LM1000-E** driver is an SNMP-based driver used to monitor and configure the **Motorola GX2-LM1000-E**.

## About

This driver provides a monitoring interface for the **Motorola GX2-LM1000-E** module.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.1.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 2.0.1.x          | D                           |

## Installation and configuration

### Creation

This driver is used by DVE child elements that are **automatically created** by the parent driver [Motorola GX2-CM100 B](xref:Connector_help_Motorola_GX2-CM100_B), from version 2.0.1.1 onwards.

## Usage

### General

This page displays general information about the card, including the **Unit Name**, **Module Type**, **Firmware** and **Hardware** **Version**, **IP Address** and **Physical Address**.

### Forward Transmitter

This page displays both **analog** and **digital** parameters. This includes the parameters **Offset Monitor**, **Offset Control**, **Attenuation**, **Optical Power**, **Laser BIAS,** **Laser** **Temperature**, **Temperature**, **Fan** and **12V** **Current**, **RF Input**, **Optical Power Output**, **Laser Mode**, **Video Offset**, **Fiber Length**, **Laser Secondary Mode** and **Factory Default**.

### Alarms

This page contains all **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
