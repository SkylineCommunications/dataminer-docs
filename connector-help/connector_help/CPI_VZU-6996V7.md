---
uid: Connector_help_CPI_VZU-6996V7
---

# CPI VZU-6996V7

The CPI VZU-6996V7 is a High-Power Amplifier (HPA).

This connector uses serial communication to communicate with the HPA.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC MAIN\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. This is required.
  - **Bus address**: The bus address of the device. Range: 48 - 112.

## How to Use

### General

This page displays some of the most important parameters for the device, such as **High Reflected RF Fault**, **RF Output Power (dBm)**, **Helix Voltage**, and **System State**.

### General Control

This page displays some of the most important parameters that control device options, such as **High Tube Temperature Alarm Trip Point**, **Heater Time Delay**, **RF Inhibit**, and **System State**.

### Control RF Output

On this page, you can view and configure the **RF Output Power in dBm**, the **ALC RF Output Power in dBm**, and the same parameters in W or dBW.

The page also contains a button that can be used to **disable the ALC**.

### Meter Query

This page displays meter values such as the **RF Output Power (dBm)**, **Reflected RF**, **Helix Voltage**, and **Cabinet Temperature**.

### Configuration

This page displays configuration parameters such as **Linearizer Installed**, **Switch System Configuration**, and **Relay 1 Configuration**.

### Status Info

This displays alarm information such as **External Interlock Fault**, **DC Bus Fault**, **Helix Over Voltage Fault**, and **BUC Fault**.

This page also contains page buttons to the following subpages:

- **Secondary Status**: Displays alarm states and settings such as **Low RF Alarm**, **Tube Over Temperature Alarm**, **CIF Control**, and **Power Sensor Failure**.
- **Summary Status**: Displays additional parameters such as **ALC**, **W/G Switch Controller Mode**, **Latched Fault**, and **Transmit Request**.

### Log

This page allows you to retrieve a **log entry** and to set the **Auto Log Time**. For each entry, it displays parameters such as **Entry Date**, **Entry Time**, **Activity Type**, **Log Attenuation**, **Log Fan Control Voltage**, etc.
