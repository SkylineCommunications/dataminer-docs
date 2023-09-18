---
uid: Connector_help_Mitec_12125_Transmit_Switching_Controller
---

# Mitec 12125 Transmit Switching Controller

The **Mitec 12125 Transmit Switching Controller** makes it possible to configure and monitor the switches.

## About

The **Mitec 12125 Transmit Switching Controller** connector will update its monitoring and configuration parameters by sending serial commands to the device.

### Version Info

| **Range** | **Description** |
|------------------|-----------------|
| 1.0.0.x          | Initial version |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.15.1.4                    |

## Installation and configuration

### Creation

This connector uses a serial connection and requires the following input during element creation:

**SERIAL CONNECTION:**

- Direct connection:

  - **Baudrate:** Baudrate specified in the manual of the device. E.g. 9600
  - **Databits:** Databits specified in the manual of the device. E.g. 7
  - **Stopbits:** Stopbits specified in the manual of the device. E.g. 1
  - **Parity:** Parity specified in the manual of the device. E.g. No
  - **FlowControl:** Flowcontrol specified in the manual of the device. E.g. No

- Interface connection:

  - **IP address/host:** The polling IP of the device.
  - **IP port:** The IP port of the device.

## Usage

### General

In the general page, the user can observe some general information from the device on the left such as the **RSU model**; the **Configuration version**; the **Software version**.

At the right of the page, the user can observe the device's mode (**Operating Mode**) and configure the **Switching Mode**.

### Switches

In the switches page, the user can configure the position of the switches and see the lock status of some switches. On the bottom there are two page buttons available that allows the user to configure the maintenance and priority settings.

### Alarms

In the alarms page, the user can observe if there is any existing faults regarding: **PSU Summary Alarm**; **Switch** **Summary Alarm**; HPA alarms. There is a button available at the bottom to acknowledge the alarms.
