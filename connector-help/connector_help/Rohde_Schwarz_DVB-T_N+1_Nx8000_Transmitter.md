---
uid: Connector_help_Rohde_Schwarz_DVB-T_N+1_Nx8000_Transmitter
---

# Rohde Schwarz DVB-T N+1 Nx8000 Transmitter

With this driver, you can gather and view information from the transmitters and exciters of the **Rohde Schwarz DVB-T N+1 Nx8000 Transmitter**.

## About

This driver uses SNMP to monitor the **Rohde Schwarz DVB-T N+1 Nx8000** device.

## Installation and configuration

### Creation

This driver uses a Simple Network Management Protocol (SNMP) connection and needs the following user information:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.7.62*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### Status Page

This page displays a table with the status of the transmitters and exciters.

### Command Page

This page displays a table with commands to send to the device.
