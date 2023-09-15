---
uid: Connector_help_Advantech_ADAM6251
---

# Advantech ADAM6251

This connector is a serial connector that controls the Digital Input device.

You can configure the inputs and the streams from the device.

## About

The connector communicates through a serial connection with the device to change its configuration and to monitor its inputs and streams.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial Version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | A1.05.B00                   |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the device.
  - **IP port**: 1025
  - **Bus address**: 01

## Usage

### General

Here you can find the **device** **name** and the **firmware** **version**.

### DI Status

On this page you can find the statuses of the *16* **inputs**.

### DI Configuration

Here you can configure the **inputs**, you can choose what **function** they are used for and a few more options.

you can change **multiple** **inputs** at once and press **save** **changes**, only after you click on save changes will the changes be done on the device.

### Stream

On this page you can change the **IP** **addresses** of the **stream**, on the right side you can **enable/disable** each stream.

### Flags

you can configure the **GCL** **flags** on this page, at the bottom are *2* **buttons** that change all of them.

### Web Interface

The client machine has to be able to access the device. If not, it won't be possible to open the web interface.
