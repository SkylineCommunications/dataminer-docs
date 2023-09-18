---
uid: Connector_help_Panasonic_AW-HE40
---

# Panasonic AW-HE40

This connector is obsolete.

The **Panasonic AW-HE40** connector can be used to display and configure Panasonic IP Camera AW-HE40 parameters and settings, as well as to control movements.

## About

An **HTTP** connection is used in order to retrieve and configure the information of the device.

In addition, the connector offers several possibilities for **alarm monitoring** and **trending** of the supported Panasonic parameters.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device.
- **Device address**: The device address, by default *ByPassProxy*.

## Usage

### General

This page displays general parameters such as **Power Status**, **Polling IP**, **Model**, **Camera Title**, **CGI Time**, **Error Status**, etc.

### System

This page contains information about the installation of the device and its settings, such as **Preset Speed**, **Preset Speed Table**, **Preset Scope**, **Speed with Zoom Position**, etc.

The **Presets** page button opens a subpage where you can monitor how many entries are set up.

### Image

On this page, you can change the image **Scene** setting, as well as monitor all image features, such as **Shutter Mode**, **Color Temperature**, **Detail**, **R Gain**, **B Gain**, **Iris Mode**, **Iris Follow**, etc.

### Control

This page allows you to control the camera movements with the parameters **Pan Position** (X-axis), **Tilt Position** (Y-axis), **Movement Speed**, **Limit Movements**, **Zoom Position**, **Focus Position** and **Horizontal/Vertical Panning**.

### Alarm

This pages shows the status of device parameters like the **Motor Driver**, **Pan Sensor**, **Tilt Sensor**, **IF/FPGA UART Over Run**, **IF/FPGA UART Framing**, **IF/NET UART Over Run**, **IF/NET UART Framing**, **IF/FPGA Buffer Overflow**, **IF/NET Buffer Overflow**, **System Error**, **PT Limit Over**, **NET Life-Monitoring**, **BE Life-Monitoring**, **IF/BE UART Buffer Overflow**, **IF/BE UART Framing Error** and **CAM Life-Monitoring**.
