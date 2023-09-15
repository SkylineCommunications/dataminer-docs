---
uid: Connector_help_Harmonic_HLP4800_-_HLD7105T
---

# Harmonic HLP4800 - HLD7105T

This connector monitors DFB laser transmitter modules that were designed for forward path narrowcasting applications.

## About

This connector uses **SNMP** polling to communicate with the corresponding device.

The connector is exported by the parent element **Harmonic HLP4800** if DVE creation is enabled. In that case, a child element using this connector will be created for each row in the **Physical Entities** table of the parent element.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 1.35                        |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Harmonic HLP4800](xref:Connector_help_Harmonic_HLP4800), from version 1.0.0.1 onwards.

## Usage

### General

This page contains module-specific hardware information.

### Operation

This page displays information about **Common Temperature**, **Fan Speed**, **Fiber Length** and **Power Reduction Mode**.

### RF

This page displays information about **Pad Level** and **Detector Level**.

### Laser

This page displays the following information regarding the laser: **Laser Power**, **Wavelength** and **Bias Current**.

### Power Supply

This page contains information related to the power supply.
