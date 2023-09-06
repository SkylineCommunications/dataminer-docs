---
uid: Connector_help_Motorola_GX2-CM100_B_-_GX2-PSDC10D-R
---

# Motorola GX2-CM100 B - GX2-PSDC10D-R

The **Motorola GX2-CM100 B - GX2-PSDC10D-R** driver is an SNMP-based driver used to monitor and configure the **Motorola GX2-PSDC10D-R**.

## About

This driver provides a monitoring interface for the **Motorola GX2-PSDC10D-R** module.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.1.x          | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 2.0.1.x          | G                           |

## Installation and configuration

### Creation

This driver is used by DVE child elements that are **automatically created** by the parent driver [Motorola GX2-CM100 B](xref:Connector_help_Motorola_GX2-CM100_B), from version 2.0.1.2 onwards.

## Usage

### General

This page displays general information about the card, including the **Name**, **Serial Number**, **Module Type**, **Firmware** and **Hardware** **Version**, **IP Address** and **Physical Address**.

### AC Power Supply

This page displays the parameters **Fan Current**, **12V Backplane**, **3.7V Backplane**, **Heatsink Temperature**, **5.1V Anode**, **3.7V Anode**, **12V Anode**, **Temperature** and **5.1V Backplane.**

### Alarms

This page contains all **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
