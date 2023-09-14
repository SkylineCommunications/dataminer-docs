---
uid: Connector_help_Harmonic_HLP4800_-_PWL4xxx
---

# Harmonic HLP4800 - PWL4xxx

This connector monitors DFB laser transmitter modules that were designed for advanced broadband networks.

## About

This connector uses **SNMP** polling to communicate with the corresponding device.

The connector is exported by the parent element **Harmonic HLP4800** if DVE creation is enabled. In that case, a child element using this connector will be created for each row in the **Physical Entities** table of the parent element.

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.1.x          | 1.45 2.10                   |

## Installation and configuration

### Creation

This connector is used by DVE child elements that are **automatically created** by the parent connector [Harmonic HLP4800](xref:Connector_help_Harmonic_HLP4800), from version 1.0.0.1 onwards.

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
