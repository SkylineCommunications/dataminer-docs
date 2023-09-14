---
uid: Connector_help_Panasonic_Super_Hi-Vision_Recorder
---

# Panasonic Super Hi-Vision Recorder

The Panasonic Super Hi-Vision Recorder connector allows the user to remotely operate, control, and monitor the device.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 26.7F-00-0.00          |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.

SERIAL Settings (1.0.0.x):

- **Port number**: The port of the connected device, by default *4001*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use (1.0.0.x)

The element created with this connector consists of the following data pages:

- **General:** Displays general device information as well as vital operation elements and their status.
- **Status:** Contains status information of important parameters, including information on the operating status and cueing details.
- **Control Panel:** Contains various important device settings, including **Local Operation**, **Timer Mode**, **Play Control** settings (e.g. Cue Up with Data, Play, Stop, Fast Forward and Rewind) and **Speed control** settings (e.g. buttons to **Jog**, **Var** and **Shuttle** in both forward and reverse directions).
- **Web Interface:** Displays the web interface of the polling IP address.

## Notes

Please ensure that the **Local Operation** is set to *Remote* in order to enable remote control and monitoring of the device.
