---
uid: Connector_help_ATX_Networks_MP3_-_MPAC
---

# ATX Networks MP3 - MPAC

The **MPAC** is a modular power supply that supplies +24 VDC to the MAXNET II active chassis backplane. This allows any MAXNET II active module to be installed in any remaining active chassis slot to receive power.

## About

This connector was designed to monitor and receive statistics from the **MPAC**.

The connector is generated automatically by the connector **ATX Networks MP3.**

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Complaint** |
|------------------|-----------------|---------------------|-------------------------|
| 2.0.0.x          | DVE creation    | No                  | Yes                     |

## Installation and configuration

### Creation

This connector is used by DVEs that are **automatically generated** when DVE creation is enabled for the corresponding card in the **DVE Control Table** of the parent element.

## Usage

### General

This page displays general parameters, such as the **Description**, **Hardware** and **Firmware** **Revision**, **Serial** **Number**, **Manufacturer**, **Model**, **Alias** and **Asset ID** for the Power Supply (MPAC) module.

### Properties

The following parameters can be monitored on this page:

- Output Voltage
- Output Current
- Output Power
- Heatsink Temperature
- Fan Status
- Alarm Detection Control
