---
uid: Connector_help_Rohde_Schwarz_NRP
---

# Rohde Schwarz NRP

The Rohde & Schwarz NRP Power Meter provides numerous modes for measuring complex signal shapes using communication standards such as GSM, EDGE, DECT, etc.: continuous, average, burst, timeslot, timegate and scope mode.

This is a serial connector that can be used to manage the Rohde & Schwarz NRP Power Meter.

## About

### Version Info

| **Range**            | **Key Features**                                                              | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------|--------------|-------------------|
| 3.0.0.x \[SLC Main\] | Bus address is used to select sensor. Only one sensor is displayed at a time. | \-           | \-                |
| 3.0.1.x              | The range for parameter 2000 has been changed to 30 to 100.                   | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 3.0.0.x   | 06.03.020              |
| 3.0.1.x   | 06.03.020              |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 3.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 3.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: *9600*.
  - **Databits**: *7*.
  - **Stopbits**: *1*.
  - **Parity**: *No*.
  - **FlowControl**: *No*.

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **Bus address**: The bus address of the device (sensor number).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

### Main View

The **Output Level** and **Power Frequency** are displayed on this page.

### General

This page displays device-related information such as the **device type**, **serial number**, **firmware**, etc.

The **Error List** page button opens a subpage where you can click the **Load List** button to view the error numbers and text from the error/event queue of the R&S NRP.

### Power Meter

The **Output Level,** **Power Frequency** and **Resolution** are displayed on this page. The power frequency and resolution can be configured.

This page contains page buttons to the following subpages:

- **Normalize**: Allows you to set the normalize output level parameter, which is used to normalize the alarm on the output level.
- **Sensor Info**: Contains information related to the sensor.
