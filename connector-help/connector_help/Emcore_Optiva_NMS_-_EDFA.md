---
uid: Connector_help_Emcore_Optiva_NMS_-_EDFA
---

# Emcore Optiva NMS - EDFA

The **Emcore Optiva NMS - EDFA** connector is a DVE child connector that makes it possible to retrieve information from an EDFA to control its behavior.

## About

This connector uses **SNMP** polling to communicate with the device.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 1.1                         |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the connector [Emcore Optiva NMS](xref:Connector_help_Emcore_Optiva_NMS), from version 1.0.0.1 onwards.

## Usage

### General

This page displays specific information for the EDFA card. It also allows you to configure the following settings:

- **EDFA Laser Mode:** Sets the operation mode of the laser to *Off*, *Power*, *Gain* or *Current*.
- **EDFA Laser Temperature:** Sets the value of the laser temperature between 15 and 40 degrees Celsius.
- **EDFA Laser Power set Point:** Sets the value of the laser power between 0 and 25 dBm.
- **EDFA Laser Current set Point:** Sets the value of the laser current between 1 and 1400 mA.
