---
uid: Connector_help_General_Dynamics_RSC12V1
---

# General Dynamics RSC12V1

The **General Dynamics RSC12V1** is a redudundant system controller that is capable of controlling various types of equipment in 1:2 systems.

## About

The **Genaral Dynamics RSC12V1** will update its monitoring and configuration parameters by sending an **SNMP** command to the device.

This connector is based on RSC firmware version 3.00 and RCP Firmware Version 0.00.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (**SNMP**) connection and requires the following input during element creation:

**SNMP CONNECTION:**

- **IP addresss/host:** The polling IP of the device.

**SNMP Settings:**

- **Port Number:** The port of the connected device (default: *161*).
- **Get community string:** The community string used when reading values form the device (default: *public*).
- **Set community string:** the community string used when setting values on the device (default: *private*).

## Usage

### Status

Default page with the general information and status of the device.

### Monitor & Control

This page contains all device settings and monitoring parameters.
