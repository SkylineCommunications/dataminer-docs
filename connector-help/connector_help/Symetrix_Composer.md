---
uid: Connector_help_Symetrix_Composer
---

# Symetrix Composer

The Symetrix Composer is a Windowsr application used to program Radius, Prism, Edge, and Solus NX DSPs.

## About

This connector uses two connection a Serial and HTTP connection to poll data from the Symetrix Composer. The serial connection is responsible for the polling of the controllers' value and the HTTP is responsible for the polling

of the system information.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | True                    |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.100                       |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### HTTP Secondary Connection

This connector uses a HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.

## Usage

### General

This page contains general information about the device such as, **Name, Fan Speed, Board Temp and Main DC.** This page also containts two system commands, **Flash LEDs** that allows the user to flash leds on the main console based on how much cycles selected, and **Load Preset** that allows the user to load a preset to the device.

### Controller

This page contains the **Controller Table,** on this page the user can add controllers to the table one by one or in bulk using a Csv file. In table the user can also make sets to the different type of controllers available. Note that information entered in the dropdown list column in the table, must be entered in **Controller Number/Option** format.

### Best Practice

This page contains information on how to use the connector.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
