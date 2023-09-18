---
uid: Connector_help_Andrew_APC300
---

# Andrew APC300

This connector is used to monitor and track satellites.

## About

The **Andrew APC300** connector uses a **serial** connection with the device.

### Version Info

| **Range** | **Description**                                                                     | **DCF Integration** | **Cassandra Compliant** |
|------------------|-------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.1.0.16         | Smartrack enabling when using multiple satellites                                   | No                  | Yes                     |
| 1.1.1.1          | Connector review: added tables, changed logic, ... Impact: Loss of alarm/trending data | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.1.0.16         | Unknown                     |
| 1.1.1.1          | Unknown                     |

## Installation and configuration

### Creation

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: (1200 - 19200)
  - **Databits**: 7
  - **Stopbits**: 1
  - **Parity**: Even
  - **FlowControl**: No

Or

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Required.

## Usage

### Main View

This page contains some parameters that you can also find on the General page, but here they are read-only. A few examples are **Motion Status**, **Position Error**, **Summary Alarm**, etc.

### General

On this page you can find the **Current Satellite**, as well as its **Azimuth**, **Elevation** and **Polarization**. The page also contains the **Jog** controls.

### Satellite List

This page contains the **Satellite List Table**, which shows the **Name**, **Azimuth**, **Elevation**, **Polarization**, **Smartrack Status**, etc. of the satellites.

### Track

This page displays the **Track Cycle**, **Scintillation**, **Step-Track**, etc.

### Smartrack Table

This page displays the **Smartrack Table**. Here you can get the full table for a satellite or one record for a satellite at a certain time.

Via the **Create Entry** page button, you can add a record in the table.

### Resolver Settings

This page contains the resolver settings, for example **Azimuth Resolver Scale Multiplier**, **Elevation Resolver Scale Divisor**, **Polarization Resolver Starting Point**, etc.

The page also contains a page button with the **Resolver Correction Factor Table**.

## Notes

There is a **Visio** file available for use with this connector.

Keep in mind that the **startup** of the connector **may take a few minutes** depending on the connection speed with the device.
