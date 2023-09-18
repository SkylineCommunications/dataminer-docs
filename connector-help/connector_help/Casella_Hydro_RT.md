---
uid: Connector_help_Casella_Hydro_RT
---

# Casella Hydro RT

The **Casella Hydro RT** connector is a serial connector that is used to communicate with a **Telemetry Logger** measuring rainfall.

## About

The objective of the **Casella Hydro RT** connector is to retrieve rainfall information from a **Isodaq Telemetry Logger** and to display it according to the preferences of the user. The data consists of the number of times a bucket with a known capacity tips. This way, the amount of rain can be computed for a certain period of time.

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- **IP address/host**: The polling IP of the device, e.g. *172.32.65.38*.
- **IP port**: The IP port of the device, e.g. *4001.*
- **Bus address**: The bus address of the device. This configuration parameter is not required for this connector.

## Usage

### General

On this page, various device information is displayed, such as the **Device ID,** **Firmware Version,** **Serial Number,** and **Battery Voltage**. The most important parameter is the **Rainfall**: it represents, with trending, the quantity of water that has fallen during each period of time specified in the **Polling Interval** parameter (by default: 15 minutes).

Alarm monitoring and trending monitoring are assigned to the parameters **Battery Voltage (Internal)** and **Rainfall**. The user can also monitor the evolution of a chosen **Polling Interval** value with trending.

An **Advanced** page button displays the **PC, Device, Reset,** and **Last Polling** **times.** The clocks of the computer executing the DMA and of the device are synchronized with a reset at element startup. Other device information of secondary importance is also displayed on this subpage.
