---
uid: Connector_help_Imagine_Communications_XHD6801+
---

# Imagine Communications XHD6801+

The Imagine Communications XHD6801+ driver uses both serial and smart-serial communication. It can be used to monitor and configure a converter card in an Imagine Communications frame. It allows alarm monitoring of all important parameters.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.1.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

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
  - **IP port**: The IP port of the destination. fixed value: *4000*).

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **Alarms** page, you can find several alarm parameters (SDI1 Loss of Video, Reference Not Locked, Teletext Parity Err, Teletext Frame Err, Master Mute On, etc.). The state of the alarms can be "Alarm Inactive" or "Alarm Active". Alarm monitoring can be configured on these parameters. For each alarm, two buttons are available that allow you to enable or disable the alarm on the device.

On the **Audio** page, several page buttons are available, which allow you to fully monitor and configure all the audio parameters.

On the **Other** page, you can configure and monitor general parameters such as Serial Number, FW Version, FW Date, FW Time, etc. The **GPI Input** and **GPI Output** page buttons allow you to configure the GPI parameters.

The **Reference** page contains the information Reference Standard, Valid Reference Std, and Reference Locked and allows you to configure the Reference Source.

Finally, on the **Video** page, three page buttons are available, which allow you to fully monitor and configure all the video parameters.

## Notes

As this is a serial driver with a smart-serial connection, there has to be a connection to a real device. If there is a change on the device, a response will be pushed to the DMA, without the need to send a poll request.
