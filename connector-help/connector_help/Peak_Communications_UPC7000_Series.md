---
uid: Connector_help_Peak_Communications_UPC7000_Series
---

# Peak Communications UPC7000 Series

The **Peak Communications UPC7000 Series** connector can be used to monitor and configure the Peak Communications UPC7000 Series L-band uplink power controller.

## About

This connector uses serial commands to retrieve the data from the **Peak Communications UCP7000 Series** controller every **5 seconds**.

### Version Info

| **Range**     | **Description**    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version    | No                  | Yes                     |
| 1.0.1.x              | DCF implementation | Yes                 | Yes                     |
| 1.0.2.x \[SLC Main\] | DCF update         | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.x.x          | 1.\*                        |
| 1.0.1.x          | 1.\*                        |
| 1.0.2.x          | 1.\* & 2.04                 |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device (*1 - 255*).

## Usage

### General

This page shows an overview with system information of the **unit**, **general settings** and **alarms** on the unit.

### Internal Beacon Receiver

This page shows an overview with **monitoring** **data** and **alarms** related to the **internal beacon receiver**.

### External Beacon Receiver

This page shows an overview with **monitoring** **data** and **alarms** related to the **external beacon receiver**.

### UPC

This page shows an overview with **monitoring** data, **UPC settings**, **channels** and **alarms** related to the **UPC**.

### Web Interface

This page is linked to the **web interface** of the device.

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.

## DataMiner Connectivity Framework

**DCF** has been implemented in a different way in the **1.0.1.x** range and the **1.0.2.x** range. The **1.0.2.x** range is the preferred range to use when you want to use DCF.

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **Fixed Input Beacon Receiver** (in)
- **Fixed Output Beacon Receiver** (out)

#### Dynamic Interfaces

Physical dynamic interfaces:

**1.0.1.x:**

- **UPC Channel Status Overview**: Each channel represents an input/output (inout).

**1.0.2.x:**

- **UPC Channel Status Overview:**

  - Each channel will create an **input interface.**
  - Each channel will create an **output interface.**

### Connections

#### Internal Connections

- Between **Fixed Input Beacon Receiver** (in) and **Fixed Output Beacon Receiver** (out), an internal connection is created.

- **UPC Channel Status Overview**:

  - Each channel where the **UPC Channel Mode** is not *Off* is an internal connection.

## Notes

Some modules/functionalities are not implemented in the connector:

- EXP Expansion Unit
- Redundancy
