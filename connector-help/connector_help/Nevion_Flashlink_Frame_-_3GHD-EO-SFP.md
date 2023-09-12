---
uid: Connector_help_Nevion_Flashlink_Frame_-_3GHD-EO-SFP
---

# Nevion Flashlink Frame - 3GHD-EO-SFP

This exported driver shows data from a **3GHD-EO-SFP** module in a Nevion Flashlink frame. This module is a single or dual multi bit-rate electrical to optical converter, providing high-performance media conversion for various signal formats from 19.4 Mbps up to 2970 Mbps.

## About

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 2.0.3.x   | 5.0.4                  |

## Configuration

This **SNMP** driver is used by DVE child elements that are **automatically created** by the parent driver [Nevion Flashlink Frame](xref:Connector_help_Nevion_Flashlink_Frame).

## How to use

The element created using this driver consists of the data pages detailed below.

### General

This page contains general information about the module, including:

- Type
- Card Status
- Chassis Number
- Slot Number
- Label
- Alarm Status
- Alarm Trap
- Alarm Count
- Main Element Name
- Active Alarms in System

### Laser

This page displays the **Laser Table**, which contains information about laser parameters.

### GPIO

This page displays the **General Purpose Input Output Table**, which contains information regarding I/O blocks.

It also allows you to configure the **Mode**, **Status**, **Description** and **Alarms**.

### Signal Input

This page displays the **EQ Table**, which contains information about EQ parameters.

It also allows you to view the **Num** and **Status**, as well as to configure **Config** and **Alarms**.

### Reclocker

This page displays the **Reclocker Table**, which contains information about reclocker parameters.

It also allows you to view the Reclocker **Num**, **Status** and **Bit Rate**, as well as to configure **Config**, **ASI**, **Bandwidth** and **Alarms**.

### Temperature

This page displays the **Temperature Table**, which contains information about temperature measurements.

It also allows you to configure the **Nominal** value, **Upper** and **Lower Limit** and **Alarms**, as well as to view the actual temperature **Value**.

### Voltage

This page displays the **Voltage Table**, which contains information about voltage measurements.

It also allows you to configure the **Upper** and **Lower Limit** and **Alarms**, as well as to view the **Nominal** effect and the **Value** in volt and watt.
