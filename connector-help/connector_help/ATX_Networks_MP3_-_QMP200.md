---
uid: Connector_help_ATX_Networks_MP3_-_QMP200
---

# ATX Networks MP3 - QMP200

The **QMP200 MAXNET II** modules are return RF/IF amplifiers, which offer two gain versions (20dB and 28dB) that are determined at the time of ordering. The QMP200 amplifier is a single-stage amplifier. The QMP200 amplifiers are dual-width, taking up two slots in the Active MAXNET II Chassis. They are powered through a hot-swapping backplane in the Active MAXNET II Chassis. An appropriate MAXNET II Power Supply in the Active MAXNET II Chassis powers these modules. The QMP200 modules feature the standard MAXNET II functionality including high-density packaging through the use of MCX coaxial cable connectors in conjunction with Mini-RG59 coaxial cable.

## About

This driver was designed to monitor and receive statistics from the **QMP200**.

The driver is generated automatically by the driver **ATX Networks MP3**.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Complaint** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | DVE creation    | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 2.0.0.x          | 1.0.9                       |

## Installation and configuration

### Creation

This driver is used by DVEs that are **automatically generated** when DVE creation is enabled for the corresponding card in the **DVE Control Table** of the parent element.

## Usage

### General

This page displays general parameters, such as the **Description**, **Hardware** and **Firmware** **Revision**, **Serial** **Number**, **Manufacturer**, **Model**, **Alias** and **Asset ID** for the QMP200 module.

### Properties

The following parameters can be monitored on this page:

- Input Voltage
- Input Current
- Input Power
- Heatsink Temperature
- Fan Status
- Alarm Detection Control
