---
uid: Connector_help_CPI_T5DI
---

# CPI T5DI

The **CPI T5DI** is a High Power Amplifier (HPA).

## About

This connector uses **serial** communication to manage the **CPI T5DI** device.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 01.00.15                    |

## Installation and configuration

### Creation

#### Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General Page

On this page, general parameters are displayed, such as the **System State**, **Control Point** and **ALC**.

The page also displays the software version of different components (e.g. **RF Supply Main Program Software Version**), the set time and the time that certain components have been running (e.g. **Heater On Time**).

The **Inhibit** page button displays a page with the inhibit parameters, e.g. **Local Inhibit**, **Ethernet Inhibit**.

The **Reset Faults** button can be used to reset the faults.

### Measurements Page

This page displays an overview of parameters monitoring voltages (**Helix Voltage**, **Heater Voltage**), currents (**Helix Current**, **Heater Current**), power (e.g. **Reflected RF Output Power**) and temperatures (e.g. **Cabinet Temperature**)

### Switch Controller Page

On this page, you can configure the switch positions and amplifier priorities.

### Switch System Status Page

This page displays an overview of the comm state (e.g. **Switch \#1 Comm State**) and stall state (e.g., **Switch \#1 Stall State**) of the switches.

### Settings Page

This page contains the configurable parameters of the device, such as the **ALC RF Output Power**, **Attenuation**, **Time** and **Amplifier Name**.

### Alarms Page

This page displays an overview of the alarm and fault states the device can generate, e.g. **High RF Driver State**, **High RF Driver Fault**.

### Web Interface Page

On this page, you can access the original web interface of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
