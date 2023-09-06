---
uid: Connector_help_Sony_Professional_Video_Monitor
---

# Sony Professional Video Monitor

This is a serial driver that is used to monitor and configure the **Sony Professional Video Monitor** (BVM-E171 / BVM-E251 / BVM-X300 / BVM-HX310 / PVM-X550 / PVM-A250 / PVM-A170 / LMD-A240 / LMD-A220 / LMD-A170) equipment.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.00                   |

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
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *53484*.

#### Serial SDAP Connection

This driver uses a serial connection for SDAP and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *53862*.

### Initialization

No extra configuration is needed to use this driver. However, we advise you to check if the **Group ID** and **Unit ID** are correct to communicate with your device.

### Redundancy

There is no redundancy defined.

## How to use

The element created using this driver has two data pages, as detailed below.

### General

This page displays the **Model**, **Serial Number** and other general parameters.

It also allows you to **switch input** **signal**. Since the buttons on the actual device can be customized, an option is available to set up different switch input values according to the assigned button. This can be done via the **Switch Input** page button.

The **Group ID** and **Unit ID** to include in the command packets can also be modified. If you want to go to **All Connection** mode, you can set the Group ID and Unit ID to this mode using the check box. This mode assumes simultaneous control of all monitors in a LAN consisting of a client and multiple monitors. An operation request is issued to all monitors in the LAN using the UDP broadcast. No information acquisition request can be issued.

NOTE: There is a delay between the manual set for **Group ID** and **Unit ID** and the actual change in the packets.

### Status

This page displays status information of the device, e.g. **Aspect Ratio**, **Power**, **Audio Level**, etc.
