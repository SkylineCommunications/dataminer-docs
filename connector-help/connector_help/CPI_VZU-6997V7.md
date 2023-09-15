---
uid: Connector_help_CPI_VZU-6997V7
---

# CPI VZU-6997V7

The CPI VZU-6997V7 is a 750W outdoor TWT High Power Amplifier (HPA).

## About

The CPI VZU-6997V7 connector uses **serial** communication to communicate with the corresponding HPA.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC MAIN\] | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

MAIN CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. This is required
  - **Bus address**: The bus address of the device. Range: *48 - 112*.

## Usage

### Main View

This page displays some of the most important parameters for the device, such as **High Reflected RF Fault**, **RF Output Power (dBm)**, **Helix Voltage** and **System State**.

### General Control

This page displays some of the most important parameters that control device options, such as **High Tube Temperature Alarm Trip Point**, **Heater Time Delay**, **RF Inhibit** and **System State**.

It also contains a button that can be used to **disable the ALC**.

### Control RF Output

On this page, you can view and configure the **RF Output Power in dBm**, the **ALC RF Output Power in dBm**, and the same parameters in W or dBW.

### Meter Query

This page displays meter values such as the **RF Output Power (dBm)**, **Reflected RF**, **Helix Voltage** and **Cabinet Temperature**.

### Linearizer Query

This page displays linearizer values and offset values such as **Gain**, **Phase Offset** and **Magnitude**.

### Configuration

This page displays configuration parameters such as **Linearizer Installed**, **Switch System Configuration** and **Relay 1 Configuration**.

### Status Info

This displays alarm information such as **External Interlock Fault**, **DC Bus Fault**, **Helix Over Voltage Fault**, **BUC Fault**.

This page also contains page buttons to the following subpages:

- **Secondary Status**: Displays alarm states and settings such as **Low RF Alarm**, **Tube Over Temperature Alarm**, **CIF Control** and **Power Sensor Failure**.
- **Summary Status**: This additional parameters such as **ALC**, **W/G Switch Controller Mode**, **Latched Fault** and **Transmit Request**.
- **Normalize Alarms**: Allows the normalization of the RF output power in dBm, W and dBW, via the parameters **Nominal RF Output Power (dBm)**, **Nominal RF Output Power (W)** and **Nominal RF Output Power (dBW)**.

### Log

This page allows you to retrieve a **log entry** and to set the **Auto Log Time**. For each entry, it displays parameters such as **Entry Date**, **Entry Time**, **Activity Type**, **Log Attenuation**, **Log Fan Control Voltage**, etc.
