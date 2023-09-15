---
uid: Connector_help_General_Dynamics_ModuMAX
---

# General Dynamic ModuMAX

The **General Dynamics ModuMAX** is a High Power Amplifier that combines the RF Output from *eight* identical, fully interchangeable RF plug-in modules (16 in a phase-combined system) to obtain the rated power capacity. These modules can be individually enabled or disabled.

## About

The connector enables a user to monitor all important parameters available in the device, it also allows the enabling or disabling of amplifier modules.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.21                        |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **IP port**: The IP port of the device, e.g. *2050*.
  - **Bus address**: Used to fill in the unit address and the unit port, e.g. *10.0D* is for unit address *0x10* and unit port *0x0D*.

## Usage

### General

Provides general status information including the **Power Up State, Mute State, General Alarm States** and if the device is in **Local or Remote Mode.** The general Page also contains data concerning the **Firmware and IP Address** of the device. A page button **Commands** leads to a page where a user can **Reset the Unit**, **Reset the Faults** or start a **Self Test**. When clicking the **Hardware Options** page button you will find an overview of all available **Modules** and **Add-Ons** for the ModuMAX.

### Alarms

Provides a complete overview of every single **Alarm** possible on the device. If something is wrong, one of the parameters will indicate a ***FAULT***.

### Modules

Displays the status of every **Amplifier Module** in the system. This includes such parameters as the **Temperature**, **Current** and **Voltage**. The **Module State** column allows the *enabling* or *disabling* of a module.

### Measurement

This page contains the measured and calculated **Forward Power and Reflected Power** including their **Units**.

### Configuration

Displays all currently configured settings on the device, including the **Power Fault Limits,** **Calibration Offset** and selected **Units** used on the device.

### Amplifier Network Status

Provides an overview of the **Amplifier Network Status** including what parts of the device are ***Muted, Inhibited or Turned Off.***

### Parallel I/O

Provides a full look at the **Parallel Input/Output** states including a **latch state** that is retrieved from the device and indicates if a change in status occurred in between polling.
