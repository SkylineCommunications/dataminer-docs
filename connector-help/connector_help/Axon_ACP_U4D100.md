---
uid: Connector_help_Axon_ACP_U4D100
---

# Axon ACP U4D100

The **U4D100** is a 4K (3840x2180) to 1080p, 4-wire down-converter. The low-latency unit combines and filters the four quadrants into a 1080p (1920x1080) signal.

The Axon ACP U4D100 driver is used to monitor status information and configure control parameters of the U4D100 card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | 1014 1215 1316 1417 1418 1619 |

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
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

#### Serial IP Connection - Events Connection

This driver uses a smart-serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination (fixed value: *2071*).
  - **Bus address**: The bus address or slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following pages:

- **General**: This page displays general information about the card: Card Name, Card Description, SW Revision, HW Revision, etc.
- **Status**: This page displays signal input, IO delay and reference status information.
- **I/O**: This page contains input/output control parameters that are used to configure the I/O settings of the card.
- **Video**: This page contains Gain and Black control parameters. These parameters are available for firmware versions 1417 and above.
- **Settings**: This page contains control parameters other than I/O and Gain such as the Lock Mode, Reference Type, etc.
- **Alarm Priority**: This page displays the event messages of the card, i.e. special messages generated asynchronously on the card.
