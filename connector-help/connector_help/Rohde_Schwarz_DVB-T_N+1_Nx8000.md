---
uid: Connector_help_Rohde_Schwarz_DVB-T_N+1_Nx8000
---

# Rohde Schwarz DVB-T N+1 Nx8000

With this connector, you can gather and view information from the **Rohde Schwarz DVB-T N+1 Nx8000** Switch Over unit, as well as configure the device.

## About

This connector uses SNMP to monitor the **Rohde Schwarz DVB-T N+1 Nx8000** device.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP Connection:**

- **IP Address/host**: The polling IP of the device, e.g. *10.64.7.62*.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page displays general information about the device, such as the **Serial Number**, **NTP Configuration** and **Software Version**.

### CCU Page

This page displays information about the switch over unit.
