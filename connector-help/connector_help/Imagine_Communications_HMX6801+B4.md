---
uid: Connector_help_Imagine_Communications_HMX6801+B4
---

# Imagine Communications HMX6801+B4

The Imagine Communications HMX6801+B4 connector combines a serial and smart-serial connection to monitor and configure the audio embedder card in an Imagine Communications frame. Alarm monitoring can be activated on all important parameters, including configuration parameters.

The Imagine Communications audio embedder card allows flexible audio group configurations, with all four groups being accessible and any mix of input audio and/or test tones being supported.

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

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *4050*)
  - **Bus address**: The bus address of the device (range: *0* - *100*).

#### Serial PortDev Connection

This connector uses a serial connection and requires the following input during element creation:

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

The element created with this connector consists of the following data pages:

- **Alarms**: Contains all alarm parameters. The state of the alarms can be *Alarm Inactive* or *Alarm Active*. Alarm monitoring is available for these parameters. With the buttons **Enable** and **Disable** you can change the monitoring state of the device card.
- **Input**: Contains page buttons to the **AudioProc**, **Multiplex**, **EDH** and **Other** subpages, where you can view input status information and configure related settings.
- **Other**: Contains the **Factory Recall** parameter.
- **Output**: Contains page buttons to the AudioProc and Multiplex subpages. On the **Multiplex** subpage, you can configure the eight output sources. The **AudioProc** subpage contains the format Fb and status parameters for all outputs. The **Output Format** can also be configured for all outputs.
- **Processing**: Contains page buttons to the AudioProc, Delaying and Embedding subpages, where you can configure the **Input Channel Delays**, **Embedder Modes** and **Output Gain**, **Invert** and **Mute** parameters. Several **Error Status** parameters are also available.

## Notes

As this is a serial connector with smart-serial connection, there has to be a connection to a real device. If there is a change on the device, a response will be pushed to the DMA even if no poll request is sent.
