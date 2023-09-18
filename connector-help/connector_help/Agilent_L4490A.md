---
uid: Connector_help_Agilent_L4490A
---

# Agilent L4490A

The **Agilent L4490A** connector is a serial connector that is used to monitor the RF/microwave switch platform Agilent L4490A.

## About

With this **serial switch** connector, you can monitor and control the switch platform, which in turn monitors and controls custom switch matrices built on this platform.

Range 1.0.1.x of the connector contains updated features.

### Version Info

| **Range** | **Description**                               | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                               | No                  | Yes                     |
| 1.0.1.x          | Fixed DIS issues and updated to new features. | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 2.43 and prior              |
| 1.0.1.x          | 2.43                        |

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
  - **Bus address**: The bus address of the device, by default *1*. Range: *1 - 8*.

## Usage

### General

This page contains general information about the device, such as the **Manufacturer** and **Model**.

### Banks

This page displays the status and configuration of the available banks.

### Switches Bank 1

This page displays the status and configurable options for **Bank 1**.

### Switches Bank 2

This page displays the status and configurable options for **Bank 2**.

### Switches Bank 3

This page displays the status and configurable options for **Bank 3**.

### Switches Bank 4

This page displays the status and configurable options for **Bank 4**.

### Digital

This page displays information related to the data channels available in the RF switch (Data Channel 2001 and 2002).

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
