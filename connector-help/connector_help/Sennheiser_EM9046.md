---
uid: Connector_help_Sennheiser_EM9046
---

# Sennheiser EM904

The **SennheiserEM9046** is a wireless microphone sound system equipped with bell pack transmitters, handheld transmitters and an 8-channel receiver system that covers the UHF range from 470 to 798 MHz.

The EM9046 consists of an analogue output module with 16 analog output channels, a digital output module that supports 24 AES output channels and 2 audio output modules. The receiver itself integrates up to 8 RF transmitters and 2 antenna boosters.

The driver monitors the different modules configured in the EM9046 device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | EM9046_4_0_0_12916     |

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

  - **IP address/host**: The polling IP of the device, e.g. *192.168.56.201*.
  - **Type of port**: By default *UDP/IP*.
  - **IP Port**: By default *45*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

- **General**: Displays basic information about the device such as the vendor, firmware version, serial number, etc.

- **Overview**: Contains a tree view of the slots and corresponding output modules.

- **Output Modules:**

- Analog output modules table: The analogue output module EM9046AAO supports 16 output channels.
  - Digital output module table: The digital output module EM9046DAO supports 24 output channels.

- **Detachable Components**:

- The detachable devices table contains information about connected external devices, i.e. antenna boosters and RF transmitters.
  - The RF transmitters table contains up to 8 transmitters.
