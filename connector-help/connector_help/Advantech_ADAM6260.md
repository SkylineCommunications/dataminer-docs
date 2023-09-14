---
uid: Connector_help_Advantech_ADAM6260
---

# Advantech ADAM6260

This connector is a serial connector that controls the Digital Output device.

You can configure the outputs and the streams from the device.

## About

The connector communicates through a serial connection with the device to change its configuration and to monitor its outputs and streams.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | A1.05.B00                   |

## Installation and configuration

### Creation

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: 1025
  - **Bus address**: 01

## Usage

### General

Here you can find the **device name** and the **firmware version**.

### DI Status

On this page you can find the status of the 6 outputs.

### DI Configuration

Here you can configure the **outputs**. You can choose which **function** they are used for and a few more options.

You can change **multiple outputs** at once and click **save changes**. Only after you click save changes, will the changes be implemented on the device.

### Stream

On this page you can change the **IP addresses** of the **stream**, on the right side you can **enable/disable** each stream.

### Flags

you can configure the **GCL flags** on this page. At the bottom, there are 2 buttons that change all of them.
