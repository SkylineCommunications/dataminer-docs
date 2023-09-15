---
uid: Connector_help_Raritan_Dominion_KX
---

# Raritan Dominion KX

The **Raritan Dominion KX** is a single port, KVM-over-IP switch that provides secure BIOS-level IP access and control.

## About

This connector uses SNMP in order to monitor and configure the **Raritan Dominion KX**.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

**SNMP Settings:**

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

## Usage

### General

This page displays general device parameters.

### Configuration

This page contains control parameters that can be used to configure the device.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
