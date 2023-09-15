---
uid: Connector_help_Paradise_HPAK-2200
---

# Paradise HPAK-2200

The Compact Outdoor SSPA is a one-piece integrated Satcom amplifier system.

## About

This connector is used to retrieve all data information and control the HPAK-2200 amplifier system.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| **Range** | **Device Firmware Version**                                                  |
|------------------|------------------------------------------------------------------------------|
| 2.0.0.x          | Unknown. Possibly 3.5 or 3.6. Based on HPA_2250_20160425101307840 datasheet. |

## Installation and configuration

### Creation

This connector uses a TCP/IP or serial connection and requires the following input during element creation:

**TCP/IP Connection**:

- **IP address**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the destination, by default *80*.
- **Bus address**: Device's bus address eg. *1*.
- **Network:** Device's network address eg. 2.

## Usage

The connector contains 3 pages.

### General

This page displays parameter's such as **Summary Fault, Unit State, Temperature** etc.

### HPA

This page displays the device's settings such as **Mute**, **Unit Startup State**, **HPA Attenuation** among others.

### Alarms

This page contains the device's alarm parameters such as **High** **Temperature Fault**, **Spare Fault**, **BUC Fault** etc.
