---
uid: Connector_help_Double_D_Electronics_DDA-219-310
---

# Double D Electronics DDA219-310

This driver monitors the activity of a **Double D Electronics DDA219-310** switch controller.

## About

This driver uses serial communication with the device. It makes use of the "Printable ASCII" communication protocol.

It displays information from the device and allows the user to control the switch configuration.

### Ranges of the driver

| **Driver Range**     | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial Version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | V1.25 dev 6                 |

## Installation and configuration

### Creation

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device. (default: 7)
  - **Stopbits**: Stopbits specified in the manual of the device. (default: 1)
  - **Parity**: Parity specified in the manual of the device. (default: Even)
  - **FlowControl**: FlowControl specified in the manual of the device. (default: )
- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.
  - **Bus address**: The bus address of the device. Starts on 'A' until '}'

## Usage

### General

This page displays information about the **Software Version**, the **Device Name**, the **Maximum of Switches Supported** and the number of **Main Chains Supported**.

On this page, you can define the **Control Mode** (*Remote* or *Local*) and the **Global Device Mode** (*Auto* or *Manual*).

In addition, you can also view the state of the **Alarms** and the **Chains connections**, and there is a button to **Acknowledge** the alarms. The Chain Status subpage displays the Connection, the Alarm Inputs, a Low Power Alarm, an Auxiliary Input Alarm and the Muted state of the chains supported by the device.

### Chains

This page displays information about the **Connection** and **Alarms** of the different chains of the device.

### Switches

This page displays information about the **Status**, the **Position**, the **Locked** state and the **Alarm** of the different switches of the device.

### Web Interface

Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
