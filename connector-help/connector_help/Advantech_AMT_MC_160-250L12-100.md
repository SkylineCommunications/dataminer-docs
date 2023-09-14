---
uid: Connector_help_Advantech_AMT_MC_160-250L12-100
---

# Advantech AMT MC 160-250L12-100

The Advantech AMT MC 160-250L12-100 is a monitor and control panel for redundant amplifiers.

## About

The monitor and control panel is used for redundant high-power amplifiers, monitoring the status of two units in a redundant system and providing control to the amplifiers. It can monitor three slave SSPA units continuously, collecting and updating information, as well as controlling these SSPAs when required. In other words, the monitor and control panel can control any slave system connected to it, such as the redundant 1:2 SSPA system.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | False                   |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## Usage

### General

This page contains some general parameters of the **Control Panel**, such as the **Serial Number**, **Shroud Temperature** and the two **Power Supply** **Voltages**.

In addition, the page contains the **Reset Main Control Board button**, the **Switches Alarm** and the **Connection Status**, as well as the **Redundancy Status** and **Mode**.

### SSPA Unit A

This page displays the SSPA **Unit A Status**, **Transmission Status**, **Mute/Unmute Condition**, **Attenuation**, **Transmission** and **Reflected Power**, **ALC Value**, **Elapsed Time**, **Low Power Threshold**, **Communication**, **Fault and Power Status**, **Alarm Summary**, **ALC High**, and **Low** and **Suspended Alarms**. In addition, it also displays the **Shroud and Hot Spot Temperature**, **P/S Voltage**, **Current**, **Serial Number**, **Software Revision Number**, **Unit Version**, **Device Type**, **Power Class** and **Frequency Band**.

### SSPA Unit B

This page contains the same parameters as the SSPA Unit A page, but instead related to Unit B.

### SSPA Unit S

This page contains the same parameters as the SSPA Unit A page, but instead related to Unit S.
