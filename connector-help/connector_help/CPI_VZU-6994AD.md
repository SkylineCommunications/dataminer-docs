---
uid: Connector_help_CPI_VZU-6994AD
---

# CPI VZU-6994AD

The **CPI VZU-6994AD** is a 400W compact medium power amplifier (CMPA) designed for satellite communication earth stations, satellite news gathering vehicles and fly-away applications in the Ku frequency band.

## About

The connector uses the serial interface to retrieve information from the device and sends configuration commands every time a user changes a setting through DataMiner's interface. More information: <http://www.cpii.com/product.cfm/4/10/23>

### Version Info

| **Range** | **Description**                    | **DCF Integration** | **C**as**sandra Compliant** |
|------------------|------------------------------------|---------------------|-----------------------------|
| 1.0.0.x          | Initial version (**obsolete**)     | No                  | Yes                         |
| 1.1.0.x          | New release version (**obsolete**) | Yes                 | Yes                         |
| 1.1.1.x          | Connector review                      | Yes                 | Yes                         |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | CPI 01019345 Rev. 19        |
| 1.1.0.x          | CPI 01019345 Rev. 19        |
| 1.1.1.x          | CPI 01019345 Rev. 19        |

## Installation and Configuration

### Creation

Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Default: *9600*
  - **Databits**: Default: *7*
  - **Stopbits**: Default: *1*
  - **Parity**: Default: *No*
  - **FlowControl**: Default: *No*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: Range: 48-111

## Usage

### Main

On this page are shown the **Summary** and **Secondary** status information as well as the current device's **Measurements**.

### Control

On this page is possible to set the **High/Low Alarm/Fault Trip-Points** as well as to control the RF module.

### Status

On this page are shown the **Fault**, **Information** and **Error** status.

## DataMiner Connectivity Framework

The 1.1.1.x connector range of the CPI VZU-6994AD protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- Input (type in)
- Output (type out)

### Connections

#### Internal Connections

- **Between the input and output**, an internal connection is created when the **operating state of the CMPA** is active. The connection is interrupted when the CMPA is in Standby or Beam Off Sequence.
