---
uid: Connector_help_FEI_Zyfer_GSync_II_Model_402
---

# FEI Zyfer GSync II Model 402

The GSync II is the 2U compact version of the GSync, and provides eight output module slots. The heart of the GSync II is the GTF (GPS Time and Frequency) module within the unit. If a system needs a Primary Reference Source (PRS), the GSync II provides either Standard Positioning Service (SPS) GPS (the civil C/A signal) or SAASM Precision Positioning Service (PPS) GPS receivers (for approved users only). With GPS as the reference source, the GSync II provides a frequency accuracy of 1E-12 and a time accuracy to \< 50 ns Peak to UTC, for calibrated units. The GSync II is also designed to take external inputs to provide internal frequency synchronization to the accuracy of the external source.

## About

This protocol uses a **serial** connection to allow the user to monitor and configure the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: 19200 (default baudrate specified in the manual of the device).
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page contains status parameters of the device, such as the **Date, Temperature, System Operation Mode, System Time Figure of Merit, On Line Module, GTF 1/2 FDM State, GTF 1/2 FDM Learn Status** and **GTF 1/2 Time Figure of Merit**. It also contains satellite signal quality parameters, including **Satellite PRN Number** 1 to 8, **Signal Strength** 1 to 8 and **Tracking Mode** 1 to 8. Finally, there is also a **Reset** page button, allowing you to choose between the GPS receiver **GTF** and the **Reset Option**.

### GTF Status

This page allows you to monitor the GTF 1/2 status of parameters such as **Power Status, 10 MHz, GPS Communication, 1 PPS Status, DAC Status, Hold Over Integrity Status, Status, Intermodule Communication Status, Module Status, GPS Lock Status, GPS Antenna Over Status, GPS Antenna Under Status, Rb Lock Status, External Input Missing Status** and **External Input Divider Selection**.

### Modules Status

This page displays all module fault status parameters, such as **Power Supply, Fiber Optic Antenna Interface, 5 and 10 MHz, High Freq Sine Output, Phase Aligned, Clock Rate, Dual Clock Rate, T1/E1, IRIG Time Code, HaveQuick Time Code, PTTI Time Code, Dual NTP Module, RS-232 I/O, Ethernet I/O, RS-232 I/O External Input** and **Time Code Input**.
