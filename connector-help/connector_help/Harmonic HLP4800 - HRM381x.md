---
uid: Connector_help_Harmonic_HLP4800_-_HRM381x
---

# Harmonic HLP4800 - HRM381x

The HRM381x modules are optical receivers ideal for supertrunking and hub interconnections. They use state-of-the-art GaAs amplifiers for low noise, low non-linear distortions and superior flatness.

## About

This driver uses **SNMP** polling to communicate with the corresponding device.

The driver is exported by the parent element **Harmonic HLP4800** if DVE creation is enabled. In that case, a child element using this driver will be created for each row in the **Physical Entities** table of the parent element.

### Supported firmware versions

| **Driver Range** | **Device Firmware Version**                          |
|------------------|------------------------------------------------------|
| 1.0.1.x          | Module version: unknown Controller version: 4.1.0.24 |

## Installation and configuration

### Creation

This driver is used by DVE child elements that are **automatically created** by the parent driver [Harmonic HLP4800](xref:Connector_help_Harmonic_HLP4800), from version 1.0.0.1 onwards.

## Usage

### General

This page contains module-specific hardware information.

### Environment

This page displays information about **Heat Sink Temperature** and **Fan Speed**.

### Forward Receiver

This page displays information about **Wavelength** and **Optical Power**.

### RF

This page displays information about **Pad Level** and **Composite RF**.

### Personality

This page displays information about **Direction** and **Unit**.

### Route

This page contains route-specific information.

### Power Supply

This page contains information related to the power supply.
