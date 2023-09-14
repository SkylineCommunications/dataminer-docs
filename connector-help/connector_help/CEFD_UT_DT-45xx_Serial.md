---
uid: Connector_help_CEFD_UT_DT-45xx_Serial
---

# CEFD UT DT-45xx Serial

These high-performance **up-/down-converters** provide cost-effective C-Band & Ku-Band frequency conversion.

An **up-converter** can be used for SCPC, DAMA and TDMA, as well as full transponder HDTV and analog TV. Spectral purity and stability characteristics fully meet or exceed the requirements of all satellite networks, including the Eutelsat HotbirdTM family.

A **down-converter** can be used for SCPC, DAMA and TDMA, as well as full transponder HDTV and analog TV. Spectral purity and stability characteristics fully meet or exceed the requirements of all satellite networks.

## About

This is a generic connector for UT-4500, which uses a **serial** connection. The frequency range, frequency step size and attenuator step size need to be configured in the connector.

### Version Info

| **Range**         | **Description**                                                                                                                                                                                                                                                                                                                                                                                                | **DCF Integration** | **Cassandra Compliant** |
|--------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x                  | Initial version.                                                                                                                                                                                                                                                                                                                                                                                               | No                  | No                      |
| 2.0.0.x **\[SLC Main\]** | Support for all 4505, 4514 and 4518 models. Configuration via interface (Device Specification page): - Frequency range (mandatory, no default) - Frequency step size (default: 125 KHz) - Attenuation step size (default: 0.25 dB) Fixed "packed configuration state" response. Fixed "equipment type" response. Supports a virtual address in bus address to access converter controlled by backup converter. | No                  | No                      |
| 2.0.1.x                  | Major update on parameter descriptions.                                                                                                                                                                                                                                                                                                                                                                        | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 2.0.0.x          | 5.11                        |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

This page displays **System Information**, including the **Model Number** and **Date/Time**, as well as the **Device Overall Status**, including the **RF Frequency** and **Attenuation.**

### Config - Converter

This page provides access to a number of parameters, some of which can be set by the user. This includes the **RF Frequency**, **Attenuation, Transmission** and **Fault Recovery**.

This page also contains the **Primary Status** page button.

### Config - Reference

This page contains the parameters related to the **Reference Oscillator**.

### Config - Pre-Selects

On this page, the existing **Pre-selects** (stored configuration combinations of frequency and attenuation) are displayed.

Two page buttons, **Program Preset** and **Clear Preset**, allow you to configure and clear presets, respectively.

### Config - Utility

This page contains among others the **Date/Time** and **Circuit ID** parameters.

The **Time Synchronization** page button provides access to parameters that can be used to configure the time synchronization.

Via the **Firmware Information** page button, you can access a table with firmware information.

### Config - Redundancy

This page displays the **Redundancy Mode**, **Operation Mode** and **Polarity**.

Two page buttons are available, **Chain Position** and **Forced Backup**.

### Status

This page displays all **Status** information for the device, including **power supply** parameters and **tuning** parameters.

### Status - Faults

This page displays a table with all **Status Faults**. It lists stored alarms with the corresponding date and time.

### Device Specification

To adapt the connector to different device types (manufacturer models), on this page, you need to manually configure the **Frequency Range**, **Frequency Step Size** and **Attenuator Step Size**.
