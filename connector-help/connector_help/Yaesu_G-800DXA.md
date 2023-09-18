---
uid: Connector_help_Yaesu_G-800DXA
---

# Yaesu G-800DXA

The **Yaesu G-800DXA** is an **antenna rotator**.

## About

This connector uses **serial communication** in order to send commands to the device and receive its current status.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | GS-232B                     |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

#### Serial Redundancy connection

This connector uses a second serial connection for redundancy purposes, which requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device.

## Usage

### General

This page contains all of the parameters in the connector.

It displays the current **Azimuth Angle** and **Elevation Angle** and allows you to set the **Azimuth Angle**, **Rotation Direction** and **Rotation Speed.**

There are also buttons available to stop the rotation (**Stop Rotation**) and to stop all actions (**All Stop**).
