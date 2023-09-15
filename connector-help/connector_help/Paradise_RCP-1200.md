---
uid: Connector_help_Paradise_RCP-1200
---

# Paradise RCP-1200

The **Paradise RCP-1200** protocol is used to monitor and control amplifiers configured in redundant systems.

## About

This protocol can be used to monitor and control any Paradise RCP-1200 device. A **TCP/IP** connection is used in order to successfully retrieve and configure the settings of the device.

## Installation and configuration

### Creation

**SERIAL Connection:**

- **Type of port:** The type of port of the connection, by default: *TCP/IP*.
- **IP Address/host:** The polling IP of the device. For instance: *10.1.48.70*.
- **IP Port:** The IP port of the connection device, by default: *4012*.
- **Bus Address:** The source address of the device, within the range of **0-31**. For instance: *06*.

## Usage

### General

- Status Information: **Summary Fault**, **PS**, **Panel/Remote Mode**, etc.

- Extra Pages:

  - **Communication**: **Unit Address**, **Serial Baud Rate**, **Communication Protocol**, **Unit Hierarchy**, **System Redundancy.**
  - **External UID**: The **External User Defined Inputs**.

### Fault Status

The fault status information of the device:

- **Summary Fault:** Displays whether a summary fault occurred (amplifiers, processor, power supplies and RF switches).
- **PS**: Displays whether the power supply is *Faulted* or *Normal*.
- **RF Switch**: Displays whether the position of the switch is set to *POS1* or *POS2*.
- **Fault Monitoring**
- **(External) Amplifier Power**: Displays whether the external amplifier is *Faulted* or *Normal*.

System Setup

The control settings of the device:

- **Panel/Remote Mode**
- **Auto/Manual Mode**
- **Amplifier Standby**
- **Priority**
- **Buzzer**
