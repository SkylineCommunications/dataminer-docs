---
uid: Connector_help_Motorola_GX2-CM100_B_-_GX2-RX200BX4
---

# Motorola GX2-CM100 B - GX2-RX200BX4

The **Motorola GX2-CM100 B - GX2-RX200BX4** connector is an SNMP-based connector used to monitor and configure the **Motorola GX2-RX200BX4**.

## About

This connector provides a monitoring interface for the **Motorola GX2-RX200BX4** module.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.1.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.1.x          | B                           |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Motorola GX2-CM100 B](xref:Connector_help_Motorola_GX2-CM100_B), from version 2.0.1.1 onwards.

## Usage

### General

This page displays general information about the card, including the **Unit Name**, **Module Type**, **Firmware** and **Hardware** **Version**, **IP Address** and **Physical Address**.

### Optical Receiver

This page contains the parameters **Optical Power** **1, 2, 3** and **4**, **Fan Current**, **Analog 12V Current**, **Digital Revert Time**, **Module Configuration**, **Digital Test Point** and **Default Reset**.

The **Settings** page button on this page displays a table where you can configure the digital parameters: **Mode**, **Wavelength**, **Attenuation** and **Switch Threshold**.

### Alarms

This page contains all **Status** parameters.

### Factory

This page displays **CRC Parameters**, **Flash Banks** and **Flash Counters**.

### Web Interface

This page displays the webpage of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
