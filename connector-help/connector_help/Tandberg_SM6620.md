---
uid: Connector_help_Tandberg_SM6620
---

# Tandberg SM6620

The **Tandberg SM6620** connector can be used to display and configure information via SNMP.

## About

The SM6620 modulator provides a feature-rich modulation solution while maintaining ease of use and control.

## Installation and configuration

### Creation

This connector uses an SNMP connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the SM6620 Modulator, e.g. *10.11.12.13*.

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private*.

## Usage

### General Page

This page contains general parameters, together with the alarms status and current alarm table.

### Modulator

This page contains configuration parameters of the modulator.

### Webpage

The webpage of the device.
