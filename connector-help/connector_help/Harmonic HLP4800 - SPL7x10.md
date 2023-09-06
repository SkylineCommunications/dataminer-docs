---
uid: Connector_help_Harmonic_HLP4800_-_SPL7x10
---

# Harmonic HLP4800 - SPL7x10

The SPL7110C and SPL7210 modules are designed as universal replacement transmitters suitable for a wide variety of broadcast and narrowcast architectures.

## About

This driver uses **SNMP** polling to communicate with the corresponding device.

The driver is exported by the parent element **Harmonic HLP4800** if DVE creation is enabled. In that case, a child element using this driver will be created for each row in the **Physical Entities** table of the parent element.

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | 1.081.122.04                |

## Installation and configuration

### Creation

This driver is used by DVE child elements that are **automatically created** by the parent driver [Harmonic HLP4800](xref:Connector_help_Harmonic_HLP4800), from version 1.0.0.1 onwards.

## Usage

### General

This page contains module-specific hardware information.

### Laser

This page displays the following information regarding the laser: **Output Power**, **Wavelength**, **Bias Current**, **Temperature**, and **Gain Control Mode**.

### Operation

This page displays information about **Common Temperature**, **Fan Speed**,**Fan Alarm**, and **Auto Calibration Mode**.

### RF

This page displays information about **Composite RF**, **RF Heat** and **RF** **Pad Level.**

### Transmission

On this page, you can configure the transmission distances of the transmitter.

## Notes

This driver applies both to modules SPL7210 and 7110C.
