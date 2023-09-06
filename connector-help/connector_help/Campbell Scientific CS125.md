---
uid: Connector_help_Campbell_Scientific_CS125
---

# Campbell Scientific CS125

The Campbell Scientific CS125 is a forward-scatter visibility and present weather sensor for automatic weather stations, including road, marine and airport-based stations.

Via serial communication, this driver allows you to monitor the weather sensor, including its configuration and the specific message type (METAR), which contains parameters such as the Sensor ID, System Status, Visibility, Relative Humidity, User Alarms, etc.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | OS Version: 007646v10  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
  - **IP port**: The IP port of the device, e.g. 4009
  - **Bus address**: The bus address of the device. Range: 0 to 9.

## How to use

The element consists of the data pages detailed below.

### General

This page shows information about the device configuration, such as the sensor ID, user alarms, baud rate, etc.

It also provides access to a Debug page, which shows the response of the GET and POLL commands. You can also check the configured bus address.

### METAR message

This page shows all the parameters that come in the METAR POLL message, such as Message ID, Sensor ID, Visibility, Intensity, Relative Humidity, User Alarms, etc.

There is also a table summarizing the message that comes from the METAR code.
