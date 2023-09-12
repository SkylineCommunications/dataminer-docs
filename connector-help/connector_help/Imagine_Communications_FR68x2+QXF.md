---
uid: Connector_help_Imagine_Communications_FR68x2+QXF
---

# Imagine Communications FR68x2+QXF

The Imagine Communications FR68x2+QXF driver uses both serial and smart-serial communication. It can be used to monitor and configure the converter card in an Imagine Communications frame. It allows alarm monitoring of all important parameters.

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
  - **Bus address**: The bus address of the device, in the format *frameNumber****.****slotID*, e.g. *1.0* (the default value) represents frame 1 and slot 0. Range: *0* - *100* (0 because this is a frame controller card).

#### Serial PortDev Connection

This driver uses a serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- **IP address/host**: The local DataMiner IP to receive responses (e.g. *172.0.0.50 or keyword "any"*).
- **IP port**: The IP port of the DMA (fixed value: *4000*).

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **Alarms** page, you can find several alarm parameters (Fan 1 - 4 Fail, PS Right Fail, PS Left Fail, Max Temperature Approached and Exceeded). The state of the alarms can be "Alarm Inactive" or "Alarm Active". Alarm monitoring can be configured on these parameters. For each alarm parameter, there are also two buttons that allow you to enable or disable the alarm on the device.

On the **Processing** page, the **Other** page button opens a subpage with the frame controller parameters.

## Notes

As this is a serial driver with a smart-serial connection, there has to be a connection to a real device. If there is a change on the device, a response will be pushed to the DMA, without the need to send a poll request.
