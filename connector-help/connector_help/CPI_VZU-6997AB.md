---
uid: Connector_help_CPI_VZU-6997AB
---

# CPI VZU-6997AB

The **CPI** **VZU-6997AB** is a 750 watts TWT High Power Amplifier in a 5 rack unit package, digital ready, for wideband, single and multi-carrier satellite service in the 12.75 to 14.50 GHz frequency band.

## About

This connector is intended to communicate with the device using serial commands as described in the device's manual. For more information, refer to <http://www.cpii.com/product.cfm/4/10/23>.

### Version Info

| **Range** | **Description**                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version (**obsolete**)     | Yes                 | Yes                     |
| 1.1.0.x          | New release version (**obsolete**) | No                  | Yes                     |
| 1.1.1.x          | Connector review                      | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Not Available               |
| 1.1.0.x          | CPI 01023245 Rev. B         |
| 1.1.1.x          | CPI 01023245 Rev. B         |

## Installation and configuration

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
  - **Bus address**: Range: *48-111*.

## Usage

### Main

This page displays the **Summary** and **Secondary** status information, as well as the **Measurements** of the current device.

### Control

On this page, you can set the **High/Low Alarm/Fault Trip-Points** and control the RF module.

### Status

This page displays the **Fault**, **Information** and **Error** status.

## DataMiner Connectivity Framework

The **1.0.0.x** and **1.1.1.x** connector ranges of the CPI VZU-6997AB protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- A virtual fixed interface named **Input** of type **input** is available, representing the device's **input**.
- A virtual fixed interface named **Output** of type **output** is available, representing the device's **Output**.

### Connections

#### Internal Connections

- Between the **Input** and **Output**, an internal connection is created with no properties.
