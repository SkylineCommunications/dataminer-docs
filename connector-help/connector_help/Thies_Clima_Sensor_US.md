---
uid: Connector_help_Thies_Clima_Sensor_US
---

# Thies Clima Sensor US

The **Thies Clima Sensor US** is a weather station. It can capture real-time information about wind speed, temperature, precipitation, etc.

## About

The **Thies Clima Sensor US** can operate with the proprietary **Thies** protocol, or with the serial **Modbus RTU** protocol**.
**This connector implements the **Modbus RTU** protocol.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 4.11                        |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: Must be between 0 and 98.

### Configuration

The device must be switched to **Modbus RTU** mode in order to work with the connector.

If this still needs to be done, press the **Switch to Modbus RTU** button on the **Settings** page.

## Usage

### General

This page contains general parameters, such as **Serial Number**, **Software Version**, **Thies Order Number**, **Baud Rate**, etc.

### Measurements

This is the main page of the connector. It displays the following measurements:

- Wind
- Humidity
- Precipitation
- Error Statuses
- Temperature
- Pressure
- Brightness
- Position

This includes for example the **Mean Wind Speed**, **Relative Humidity**, **Precipitation Status**, **Heating Release**, **Air Temperature**, **Absolute Air Pressure**, **Brightness West** and **Sun Elevation**.

### Settings

On this page, you can configure the following settings: **Averaging Interval**, **North Correction**, **Station Height**, **Time Zone**, **Low Threshold of Supply Voltage**, **Heating Control** and the **Height Settings**.

The page also allows you to switch the device to **Modbus RTU mode**.
