---
uid: Connector_help_Snell_Wilcox_IQSDA30
---

# Snell Wilcox IQSDA30

The Snell Wilcox IQSDA30 driver monitors and controls changes on the amplifier unit through a **RollCall** **smart-serial** protocol. The card is used on the **IQ Modular Chassis**.

The driver periodically polls relevant information from the device. This happens every 15 seconds for RollCall-protocol purposes and every two hours for back-channel purposes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.2. .5                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host:** The polling IP of the device.
  - **IP port:** The IP port of the device (default: 2050).
  - **Bus Address:** The bus of the card on the chassis. The default shows the expected structure of the address, where UU is the chassis ID, and PP is the card position, both in Hex (default: UU.PP (Hex)).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element consists of the following data pages:

- **General**: Contains general information about the card, such as the information shown on the display of the device, and its various versions and serial numbers.
- **Input**: Displays the basic configuration for each of the 2 available inputs. Configuration of the **SDI rates** and **On Signal Loss** behavior is available, as well as the ability to mute the channels.
- **Memories**: Displays the configurable User Memory setting slots 1 - 16. You can recall the settings from any of the slots with the **Recall Memory** selection. The **Last User Memory** parameter shows which memory setting slot was last used. To save a memory setting, you can select a memory slot setting via **Select Memory** (or select none), configure its name with the **Change Memory Name** setting (shown for the corresponding parameter in the Memory Name Values), and click **Save**. You can also do the same to clear a memory by clicking **Clear**. However, note that clearing the memory causes the configuration associated with it to be lost, which means it will need to be saved again later if you want to recreate it.
- **Logging**: Allows you to configure the logging associated with each of the card's input systems, as well as miscellaneous logging.
- **RollTrack**: Allows you to check the status of the RollTrack system of the card and configure this system. This includes indexes, sources, addresses and commands.
- **Setup**: Allows you to configure the names for each **input**, and data from the **board**. You can also reset data to **default** values or **restart** the device.
- **Connection Info**: Shows the current status of the remote connection to the card.
