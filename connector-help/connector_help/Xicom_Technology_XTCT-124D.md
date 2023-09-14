---
uid: Connector_help_Xicom_Technology_XTCT-124D
---

# Xicom Technology XTCT-124D

The **Xicom Technology XTCT-124D** connector can be used to display and configure information of the Xicom amplifiers and the switch controller (Controller/HPA A/HPA B).

The device is a rack-mount controller that is used to control external high-power amplifiers (HPAs). It replaces the need for separate controllers in case of TWTAs or SSPAs.

The connector is set up for 3 amplifiers and 2 HPAs.

## About

A **smart-serial** connection is used to retrieve the information of the HPA via **UDP broadcast** messages.

A **serial** connection is used to display the settings of the controller.

### Version Info

| **Range**     | **Description**                                                                                                                               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                              | No                  | No                      |
| 1.1.0.x \[SLC Main\] | Based on 1.0.0.3. Implemented support for new firmware (cf. "Supported firmware versions" table). **UDP Broadcast** status messages (Rev. L). | No                  | Yes                     |
| 1.1.1.x              | Third serial connection (HPA sets).                                                                                                           | No                  | Yes                     |
| 2.0.0.x              | Initial version updated range.                                                                                                                | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.1.0.x          | V.23 (1.4.0+)               |
| 1.1.1.x          | Unknown                     |
| 2.0.0.x          | 0.11                        |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device, by default *9600*.
  - **Databits**: Databits specified in the manual of the device, by default *8*.
  - **Stopbits**: Stopbits specified in the manual of the device, by default *1*.
  - **Parity**: Parity specified in the manual of the device, by default *No*.
  - **FlowControl**: FlowControl specified in the manual of the device, by default *No*.
- Interface connection:
  - **IP address/host**: The polling IP of the controller device.
  - **Port Type**: The connection port type: *TCP/IP*.
  - **IP port**: The IP port of the device, by default *2000*.
  - **Bus address**: The bus address of the device, by default *64*. (Range: *255 - 64*.)

#### Serial Smart Serial Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:
  - **Baudrate**: Baudrate specified in the manual of the device.
  - **Databits**: Databits specified in the manual of the device.
  - **Stopbits**: Stopbits specified in the manual of the device.
  - **Parity**: Parity specified in the manual of the device.
  - **FlowControl**: FlowControl specified in the manual of the device.
- Interface connection:
  - **IP address/host**: *any*.
  - **Port Type**: The connection port type: UDP/IP.
  - **IP port**: The IP port of the device, by default *2100*.

## Usage

### General

This page displays information about the controller. It shows the status of the 4 **Waveguide Switches** alongside the different device **Modes** and the status of both **Power Supply Units (PSU)**.

Via page buttons, you can access the following subpages:

- The **Polling** subpage contains information related to the polling settings, specifically whether the **Attenuation** has to be polled and what the maximum number of **retries** is for the **UDP** communication.
- The **Communication** subpage contains port-related settings. If **Serial Ports** are used, this is where you need to define the **Baud Rate**, **Parity**, **Data Bits** and **Stop Bits**.
- The **Amplifier Address** subpage allows you to define the IP addresses for 3 **amplifiers** and 2 **HPAs**.

### UPC

This page displays information about the **Uplink Power Control** for the controller and the HPAs.

It also allows you to set the currently monitored values as the **Clear Sky** settings. These will then be compared with future values in order to adjust the **Attenuator Level.**

### Control

On this page, you can set parameters of the controller device. In particular, it allows you to change the 4 **Waveguide Switches.**

### HPA 1

This page displays information about the HPA 1 amplifier status parameters and HPA 1 alarms.

It also allows you to configure the **Transmitter Mode**, **Inhibit RF** and **Attenuation level**.

### HPA 2

This page displays information about the HPA 2 amplifier status parameters and HPA 2 alarms.

It also allows you to configure the **Transmitter Mode**, **Inhibit RF** and **Attenuation level**.

### Web UI

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
