---
uid: Connector_help_Snell_Wilcox_IQAES00
---

# Snell Wilcox IQAES00

The Snell Wilcox IQAES00 connector monitors and controls changes on the amplifier unit through a **RollCall** **smart-serial** protocol. The card is used on the **IQ Modular Chassis**.

The connector periodically polls relevant information from the device. This happens every 15 seconds for RollCall-protocol purposes and every two hours for back-channel purposes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.1. .6                |

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
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (default: 2050).
  - **Bus Address:** The bus of the card on the chassis. The default shows the expected structure of the address, where UU is the chassis ID, and PP is the card position, both in Hex (default: UU.PP (Hex)).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Contains general information about the card, such as the information shown on the display of the device, and its various versions and serial numbers.
- **Status**: Shows the main status of each of the input's systems: Lock, Sample Rate, PCM, ProSumer, CRC Error, CS Mode and CS Value.
- **Logging**: Allows you to configure the logging associated with each of the card's input systems.
- **RollTrack**: Allows you to check the status of the RollTrack system of the card and configure this system. This includes indexes, sources, addresses and commands.
- **Setup**: Allows you to configure the number of inputs used through its mode, as well as the test bits. You can also reset data to **default** values or **restart** the device.
- **Connection Info**: Shows the current status of the remote connection to the card.
