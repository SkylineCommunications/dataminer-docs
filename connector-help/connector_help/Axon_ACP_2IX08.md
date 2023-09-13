---
uid: Connector_help_Axon_ACP_2IX08
---

# Axon ACP 2IX08

The **2IX08** is a dual-channel high-performance SDI video and embedded audio probe (signal integrity monitor) with clean switchover function.

The **Axon ACP 2IX08** driver is used to monitor and display status information of the 2IX08 card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2834                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial IP Connection - Events Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART SERIAL CONNECTION:

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
- **Status:** Displays the status information of different parameters of the card.
- **I/O:** This page contains control parameters used to configure the input and output settings.
- **Probing:** This page contains control parameters used to configure the different detection settings such as **Carrier**, **TRS**, **EDH** and **Monochrome**.
- **Alarm Priority:** Displays the event messages of the card, i.e. special messages generated asynchronously on the card.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Axon ACP 2IX08 protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Fixed interfaces

Physical fixed interfaces:

- **SDI Input A:** A single fixed interface of type in.
- **SDI Input B:** A single fixed interface of type in.
- **SDI Output A-1:** A single fixed interface of type out.
- **SDI Output A-2:** A single fixed interface of type out.
- **SDI Output A-3:** A single fixed interface of type out.
- **SDI Output B-1:** A single fixed interface of type out.
- **SDI Output B-2:** A single fixed interface of type out.
- **SDI Output B-3:** A single fixed interface of type out.

### Connections

#### Internal Connections

- **SDI Input A -\> SDI Output A-1**.
- **SDI Input A -\> SDI Output A-2**.
- **SDI Input A -\> SDI Output A-3**.
- **SDI Input A -\> SDI Output B-1**.
- **SDI Input A -\> SDI Output B-2**.
- **SDI Input A -\> SDI Output B-3**.
- **SDI Input B -\> SDI Output A-1**.
- **SDI Input B -\> SDI Output A-2**.
- **SDI Input B -\> SDI Output A-3**.
- **SDI Input B -\> SDI Output B-1**.
- **SDI Input B -\> SDI Output B-2**.
- **SDI Input B -\> SDI Output B-3**.
