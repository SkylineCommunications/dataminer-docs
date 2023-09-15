---
uid: Connector_help_General_Dynamics_Generic_Redundancy_Controller
---

# General Dynamics Generic Redundancy Controller

Generic Redundancy Controller with a serial interface. General Dynamics LRC12M32-1 is supported by this protocol.

## About

This protocol uses a **serial** connection to allow the user to monitor and configure the device.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 1.092                       |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page contains general information and settings for the device, such as the **power supply voltage** and a **Reset** button. **Automatic and manual switch control** and manual **lock/unlock** operations (disabling the device front panel) are also available.

### Alarms

This page displays the **general status** of the device, including internal and external alarm sources (e.g. external oscillator faults), active or latched.

In case there is a fault, you can see more detailed information about the failure, reset latched faults and mask active alarms.
