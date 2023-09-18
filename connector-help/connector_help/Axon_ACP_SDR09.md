---
uid: Connector_help_Axon_ACP_SDR09
---

# Axon ACP SDR09

The **SDR09** is a dual-channel distribution amplifier, with channel A having 3 outputs and channel B having 4 outputs. The SDR09 re-clocks the input signal to ensure stability of the outputs.

The **Axon ACP SDR09** connector is used to monitor and display status information of the SDR09 card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0600                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial IP Connection - Events Connection

This connector uses a smart-serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination. Specify "any".
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following pages:

- **General:** Displays information about the identity of the card and other general information: Card Name, Card Description, SW Revision, HW Revision, etc.
- **Amplifier:** Displays the **Bitrate** and **SDI Input** parameters.
- **Alarm Priority:** Displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The **1.0.0.x** connector range of the Axon ACP 2IX08 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input A:** A single fixed interface of type in.
- **SDI Input B:** A single fixed interface of type in.
- **SDI Output A1:** A single fixed interface of type out.
- **SDI Output A2:** A single fixed interface of type out.
- **SDI Output A3:** A single fixed interface of type out.
- **SDI Output B1:** A single fixed interface of type out.
- **SDI Output B2:** A single fixed interface of type out.
- **SDI Output B3:** A single fixed interface of type out.
- **SDI Output B4:** A single fixed interface of type out.

### Connections

#### Internal Connections

- **SDI Input A -\> SDI Output A1**.
- **SDI Input A -\> SDI Output A2**.
- **SDI Input A -\> SDI Output A3**.
- **SDI Input B -\> SDI Output B1**.
- **SDI Input B -\> SDI Output B2**.
- **SDI Input B -\> SDI Output B3**.
- **SDI Input B -\> SDI Output B4**.
