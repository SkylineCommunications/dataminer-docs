---
uid: Connector_help_Imagine_Communications_DA-S6802+
---

# Imagine Communications DA-S6802+

The Imagine Communications DA-S6802+ driver uses both serial and smart-serial communication. It can be used to monitor and configure an amplifier card in an Imagine Communications frame. It allows alarm monitoring of all important parameters.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *4050*).
  - **Bus address**: The bus address of the device (range: *0* - *100*).

#### Serial PortDev Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *4000*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **Alarms** page, you can find several alarm parameters (Loss of Input, Input Not Locked, and Loss of Looped Output). The state of the alarms can be "Alarm Inactive" or "Alarm Active". Alarm monitoring can be configured on these parameters. For each alarm, two buttons are available that allow you to enable or disable the alarm on the device.

On the **Input** page, the **Other** page button provides access to signal presence information. The **Output** page also contains such a page button, which allows you to configure the Slew Rate.

On the **Processing** page, you can find the **Serial Number** and configure the **License Key**. This page also has an **Other** page button, which allows you to configure the Loss of Input Alarm.

## Notes

As this is a serial driver with a smart-serial connection, there has to be a connection to a real device. If there is a change on the device, a response will be pushed to the DMA, without the need to send a poll request.
