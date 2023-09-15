---
uid: Connector_help_Janitza_Electronics_UMG_96_RM
---

# Janitza Electronics UMG 96 RM

The **Janitza Electronics UMG 96 RM** connector can be used to display and configure information of the related device.

## About

The UMG96 RM is suited for fixed mounting and can measure voltage, current, power, etc. in low voltage switchgear. An **SNMP** connection is used in order to successfully retrieve and configure the device's information.

## Installation and configuration

### Creation

**SNMP Connection**

- **IP Address/host:** The polling IP of the device.

**SNMP Settings**

- **Port Number:** The port of the connection device, by default *161*.
- **Get community string:** The community string used when reading values from the device. The default value is *public*.
- **Set community string:** The community string used when setting values on the device. The default value is *private*.

## Usage

The Janitza Electronics UMG 96 RM protocol contains the following pages:

- **General:** System information (**Description**, **Up Time**, **Name**).
- **Power:** All power-related settings (e.g. **Voltage Phase**, **Current Phase**, **Real Power**, etc.).
- **Energy:** The **Active Energy** and **Reactive Energy** settings.
- **Total Harmonic Distortion:** The different **THD Voltage Phase** and **THD Current Phase** settings.
- **Miscellaneous:** Additional information about the device (e.g. **frequence**, **temperature**).
- **User:** The **Jasic User Variable** settings.
