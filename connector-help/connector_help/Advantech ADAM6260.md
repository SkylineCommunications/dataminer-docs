---
uid: Connector_help_Advantech_ADAM6260
---

# Advantech ADAM6260

This driver is a serial driver that controls the Digital Output device.

You can configure the outputs and the streams from the device.

## About

The driver communicates through a serial connection with the device to change its configuration and to monitor its outputs and streams.

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version** |
|------------------|-----------------------------|
| 1.0.0.x          | A1.05.B00                   |

## Installation and configuration

### Creation

#### Serial Main connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: \[The polling IP of the device.\]
  - **IP port**: 1025
  - **Bus address**: 01

## Usage

### General

Here you can find the **device** **name** and the **firmware** **version**.

### DI Status

On this page you can find the statusses of the *6* **outputs**.

### DI Configuration

Here you can configure the **outputs**, you can choose what **function** they are used for and a few more options.

you can change **multiple** ****outputs**** at once and press **save** **changes**, only after you click on save changes will the changes be done on the device.

### Stream

On this page you can change the **IP** **addresses** of the **stream**, on the right side you can **enable/disable** each stream.

### Flags

you can configure the **GCL** **flags** on this page, at the bottom are *2* **buttons** that change all of them.
