---
uid: Connector_help_Emcore_Optiva_NMS_-_Transmitter
---

# Emcore Optiva NMS - Transmitter

The **Emcore Optiva NMS - Transmitter** connector is a DVE child connector that makes it possible to retrieve information from a transmitter and to control its behavior.

## About

This connector uses **SNMP** polling to communicate with the device.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 1.1                         |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Emcore Optiva NMS](xref:Connector_help_Emcore_Optiva_NMS), from version 1.0.1.1 onwards.

## Usage

### General

This page displays specific information for each transmission card. It also contains the following buttons:

- **+0.5 dB/-1dB**: With these two buttons, you can adjust the **RF Gain** with +0.5 dB or -1 dB, respectively.
- **Activate**: This button is used to activate **TX Peak Performance**, which changes RF gain so that the RF power at the laser is approximately at a value for peak (optimum) performance.
