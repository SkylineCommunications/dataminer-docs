---
uid: Connector_help_Teleste_HDP301_TSEMP_DVX
---

# Teleste HDP301 TSEMP DVX

This driver monitors a Power Supply for HDO devices with load sharing.

## About

This driver is used to control and monitor the HDP301 module using the DVX bus.

## Installation and creation

### Creation

This driver uses a serial connection and needs the following user information:

**SERIAL CONNECTION**:

- **IP address/host**: The polling IP of the Moxa connected to the DVX Bus, e.g. *10.11.12.13.*
- **IP port**: The port of the Local TCP connection used by the Moxa, e.g. *4001.*
- **Bus address**: The bus address of the connected device, in the format: *X.Y* (where X = Rack Number, Y = Slot Number).

## Usage

### General page

On this page, you can find an overview of the module, along with statistic information (uptime, temperature, etc.).

Click the **Alarm Limits** page button to view or configure the analog and discrete alarm limits.

### Power Supply

Thispage displays the state of the **Input Voltage**, the **Total Output Power** and **6.3V/25V Output Parameters**.

## Notes

N/A
