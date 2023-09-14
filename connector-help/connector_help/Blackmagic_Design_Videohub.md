---
uid: Connector_help_Blackmagic_Design_Videohub
---

# Blackmagic Design Videohub

This connector can be used to monitor and control a **Blackmagic Design Videohub** router frame.

## About

The Blackmagic Design Videohub device is a video router. Frames come in a choice of two sizes that let you expand your router up to either a 72 x 72 or a 288 x 288 crosspoint size. The connector automatically detects the size of the matrix, and the user controls are adjusted accordingly.

The connector provides read-write access to the matrix. It is possible to view and change crosspoints, labels of the inputs and outputs, and the lock status.

A smart-serial connection is used to retrieve the data from the device.

### Version Info

| **Range**     | **Description**    | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version    | No                  | Yes                     |
| 1.0.1.x \[SLC Main\] | DCF implementation | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |

## Installation and configuration

### Creation

#### Smart-serial main connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Direct connection:

  - **Baudrate**: Baudrate specified in the manual of the device, e.g. *9600.*
  - **Databits**: Databits specified in the manual of the device, e.g. *7.*
  - **Stopbits**: Stopbits specified in the manual of the device, e.g. *1.*
  - **Parity**: Parity specified in the manual of the device, e.g. *No.*
  - **FlowControl**: FlowControl specified in the manual of the device, e.g. *No.*

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device. Required. Default value: *9990*.

## Usage

### General

This page contains general information, such as the device name, the size of the matrix (number of inputs and outputs), etc.

The **Ping** parameter indicates if the connection between the controller and the matrix chassis is working properly.

### Video Routing Matrix

This page displays the matrix control with crosspoints. In the DataMiner UI, you can set crosspoints, change the labels of inputs and outputs, and lock/unlock outputs.
