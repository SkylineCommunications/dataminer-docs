---
uid: Connector_help_ND_Satcom_HPA_3412A
---

# ND Satcom HPA 3412A

The **ND Satcom HPA 3412A** connector is a serial connector that is used to monitor and configure the **ND Satcom 3412A** **High Power Amplifier**.

## About

The **ND Satcom HPA 3412A** connector uses serial communication to monitor and configure the connected HPA.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **IP port**: The port of the connected device.
- **Bus address**: The bus address of the connected device.

## Usage

### Main View

The **Main View** page of the connector displays general status information, such as the **HPA Operating State** and the **Operating Band**.

Some measurements are also displayed, such as the **Temperature**, **Helix** **Voltage**, **Helix** **Current**, etc.

### General

The **General page** displays general information about the HPA, such as the **Device ID** and **Protocol Version**.

The page also allows the user to configure some of the settings for the HPA, such as the **HPA Operating State** or the **Operating Band**.

There are 2 page buttons on this page: "**Diode Set.**" and "**Coupler Set.**" These buttons open a separate page to configure the **Diode** **Settings** or the **Coupler** **Settings** respectively.

### Alarms

The **Alarms** page displays alarm information about the device. For some of the alarms, the trip point can be set.
