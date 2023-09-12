---
uid: Connector_help_Harmonic_HLP4800_-_PWL4xxx
---

# Harmonic HLP4800 - PWL4xxx

This driver monitors DFB laser transmitter modules that were designed for advanced broadband networks.

## About

This driver uses **SNMP** polling to communicate with the corresponding device.

The driver is exported by the parent element **Harmonic HLP4800** if DVE creation is enabled. In that case, a child element using this driver will be created for each row in the **Physical Entities** table of the parent element.

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.1.x          | 1.45 2.10                   |

## Installation and configuration

### Creation

This driver is used by DVE child elements that are **automatically created** by the parent driver [Harmonic HLP4800](xref:Connector_help_Harmonic_HLP4800), from version 1.0.0.1 onwards.

## Usage

### General

This page contains module-specific hardware information.

### Environment

This page displays information about **Heat Sink Temperature**, **Fan Speed** and **Fan Alarm**.

### RF

This page displays information about **Pad Level** and **Composite RF**.

### Mode

On this page, you can configure the transmitter modulation module with the parameters **CW/Video Mode** and **Mode**.

### Laser

This page displays the following information regarding the laser: **Output Power**, **Wavelength**, **Bias Current** and **Temperature**.

### Power Supply

This page contains information related to the power supply.
