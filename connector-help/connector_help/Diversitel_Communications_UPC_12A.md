---
uid: Connector_help_Diversitel_Communications_UPC_12A
---

# Diversitel Communications UPC 12A

This device is an **uplink power controller**. Its purpose is to compensate the rain fade effect in satellite communications by automatically adjusting the transmitting power. It provides a method of determining the rain attenuation along the path to the satellite and controlling the uplink transmitter power so that the power incident at the satellite remains nearly constant during rain attenuation events. Additional external gain control modules can be connected and configured.

With this driver, you can monitor and configure this device via a serial connection.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### Serial Main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

- **Baudrate**: default: *19200* \[range: *300, 1200, 2400, 9600, 19200, 38400*\]
  - **Databits**: *8*
  - **Stopbits**: *0*
  - **Parity**: No
  - **FlowControl**: No

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device.

## How to use

The element consists of the data pages detailed below.

### General

This page contains general information about the device, such as the Status, Antenna Temperature, Mean, Variance, Uplink Attenuation and various angles and coordinates calculated by the device.

### Configuration

This page contains all available configuration options. These parameters influence the calibration and internal calculations for the uplink attenuation.

With the **Calibrate** button, you can calibrate the radiometer.

### Gain Units

This page contains the gain table, which has an entry for each address (0-15) of a possible gain unit or individual channel.

Gain units or channels can be set to *on* or *off* and have a configurable gain limit.

When the unit or channel is on, the current gain value can be monitored and a status message is shown.

## Notes

- The driver cannot detect the difference between an unused address and a gain unit that is powered off.
- The status message could possibly have a different format if a certain gain unit reached its limits. If you notice this, please take a [stream viewer](https://help.dataminer.services/dataminer/#t=DataMinerUserGuide/part_6/logging/Connecting_to_an_element_using_Stream_Viewer.htm%23XREF_41758_43_1_1_Connecting) capture and let us know.
- The calibration command is not implemented.
