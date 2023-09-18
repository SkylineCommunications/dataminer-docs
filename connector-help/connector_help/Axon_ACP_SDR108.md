---
uid: Connector_help_Axon_ACP_SDR108
---

# Axon ACP SDR108

The SDR108 is a single-channel SD-SDI distribution amplifier. This card can be used as a reclocking or non-reclocking amplifier. It is ASI/DVB compatible.

The Axon ACP SDR108 connector can be used to display and configure information related to this device. This connector is linked with [Axon ACP Frame Manager](xref:Connector_help_Axon_ACP_Frame_Manager) and will appear in the overview table in the corresponding frame slot.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0900                   |

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
  - **Bus address**: The slot number/position of the card in the frame.

#### Serial IP Connection - Broadcast Connection

This connector uses a serial connection and requires the following input during element creation:

SMART-SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: *any*
  - **Bus address**: The slot number/position of the card in the frame.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: Displays general information about the card: Card Name, Card Description, SW Revision, HW Revision, etc.
- **Status**: Displays status parameters related to the card itself, such as SDI Input, PLL Rate, SFP Status, SFP Temperature Status, SFP Voltage Status, Ports 1 and 2 Power, Bias and Wavelength, etc.
- **Settings**: Allows you to configure card settings such as PLL Set, Reclock, Mute, HDMI, HMDI Format, HDMI DVI Mode, HDMI Mute All, CBVS and CBVS Format.
- **Events**: Displays information related to events.
