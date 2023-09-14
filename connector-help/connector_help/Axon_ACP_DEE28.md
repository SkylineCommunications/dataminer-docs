---
uid: Connector_help_Axon_ACP_DEE28
---

# Axon ACP DEE28

The DEE28 is a next-generation Dolby multi-format decoder and Dolby E encoder with quad-speed ADD-ON audio bus.

The Axon ACP DEE28 connector is a serial connector used to control the Axon DEE28 card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0807                   |

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

  - **IP address/host**: The polling IP.
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial Broadcast Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP.
  - **IP port**: The IP port of the destination. Specify "any".
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: Displays information about the identity of the card, as well as other general information: Card Name, Card Description, SW Revision, HW Revision, etc.
- **System Settings**: Contains sample rate converters and other system control parameters.
- **Decoder Options**: Contains decoder control parameters such as inputs.
- **Decoder Metadata**: Contains parameters that indicate the value of the metadata parameters. This page also contains the **Program Scale Factor** page button.
- **E-encoder Inputs Ch1-4/5-8/9-12/13-16**: These pages contain information about the **sources**, **gain**, **phase**, **delay** and **audio** **system** of the output channels.
- **VO Control**: Contains the VO control parameters. The DBD handles voice-over channels. With the settings on this page, you can configure how the involved program out channels should react to a voice-over signal and how everything is triggered.
- **Encoder Options**: Contains encoder control parameters such as metadata, downmix, preprocessing, etc.
- **Add_On Bus**: Contains the ADD-ON bus parameters such as the meta bus control, the quad speed audio bus outputs (Slot 1/2 ~ Slot 31/32) and parameters used to pass processed audio from one quad-speed add-on card to another (override parameters).
- **Local Outputs**: Contains parameters used to route the default channels to the output muxes or to route the encoded Dolby E signal to a specific output.
- **Loudness**: Contains loudness control and monitoring parameters.
- **Monitoring**: Contains the current status information of the AES inputs and channels.
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.
