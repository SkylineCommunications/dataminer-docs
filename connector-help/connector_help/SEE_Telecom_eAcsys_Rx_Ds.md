---
uid: Connector_help_SEE_Telecom_eAcsys_Rx_Ds
---

# SEE Telecom eAcsys Rx Ds

## About

This connector makes it possible to monitor a **SEE Telecom eAcsys Rx Ds Receiver** with **SNMP**. The retrieved parameters are displayed on several pages, depending on the kind of parameter.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host:** The polling IP of the device, *e.g. 10.67.7.206*
- **Device address**: The bus address of the device, e.g. *4*

**SNMP Settings:**

- **Port number:** The port of the connected device, by default *161.*
- **Get community** The community string needed to read from the device. The default value is *public*.
- **Set community string:** The community string needed to set to the device. The default value is *private*.

## Usage

The following pages are displayed:

- **General**
- **Optical**
- **Main RF**
- **Backup RF**
- **RF Switch**
