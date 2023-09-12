---
uid: Connector_help_Imagine_Communications_DA-H6802+
---

# Imagine Communications DA-H6802+

This driver allows you to monitor a DA-H6802+ amplifier card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters.

Serial commands are used to set parameters on the device and information is retrieved through smart-serial responses.

## About

### Version Info

| **Range** | **Key Features**               | **Based on** | **System Impact** |
|-----------|--------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                | \-           | \-                |
| 1.1.0.x   | New firmware based on 1.0.0.x. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.00                   |
| 1.1.0.x   | 2.00                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |
| 1.1.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

This driver uses both a serial and smart-serial connection. During element creation, the following information must be specified:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device (e.g. *172.32.65.38*).
- **IP port**: The IP port of the device (fixed value: *4050*).
- **Bus address**: This is a combination of the frame number and slot number/ID in the format \<frameNumber **.** slotID\>. For example, frame 1 and slot 12 correspond to bus address *1.12.*

SMART-SERIAL CONNECTION:

- **IP address/host**: The local DataMiner IP to receive responses (e.g. *172.0.0.50*).
- **IP port**: The IP port of the DMA (fixed value: *4000*).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **Alarms**: Displays alarm parameters, e.g. Loss of Input. The state of each alarm can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring can be activated on these parameters. There are also buttons available that allow you to enable or disable alarms.
- **Input**: Contains a page button that displays **signal presence** information
- **Output**: Contains a page button to a subpage where you can configure the **slew rate**.
- **Processing**: Contains the **Serial Number** and **License Key**. The license key can also be configured here. There is a button to restore default parameters (**Factory Recall**) and a button to reset the device (**Soft Reset**).

## Notes

As this is a serial driver with smart-serial connection, there must be a connection with a real device. When there is a change on the device, a response will be pushed to the DMA even though no poll request is sent.
