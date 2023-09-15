---
uid: Connector_help_Harmonic_HOA82XX
---

# Harmonic HOA82XX

This device is an **Optical Amplifier** designed to provide a cost-effective optical amplification of RF video signals in Passive Optical Networks (PONs).

## About

This connector is used to monitor the major parameters (inputs and outputs) and makes it possible to configure these.

## Installation and configuration

### Creation

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

**SNMP CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*

**SNMP Settings**:

- **Port number**: The port of the connected device, by default *161.*
- **Get community string**: The community string in order to read from the device. The default value is *public*.
- **Set community string**: The community string in order to set to the device. The default value is *private.*

## Usage

### General

This page displays standard device parameters (e.g. **Model, Temperature, Location**). The configurable parameters are on the right side and are **Serial Number, Location, Name** and **Contact.**

### Controls

On this page, you can find the general **Status** of the device, as well as the **Output Power** and **Power Save Mode**. These modes can also be configured.

### Optics

On this page, you can find the **Input** and **Output** **Power**, and configure the **Output Set Point**.

### Alarms

This page contains a summary table of the **Current Alarms** present on the device.

### Web Interface

This page refers to the web interface made for the device.
