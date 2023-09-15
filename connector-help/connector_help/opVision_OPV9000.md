---
uid: Connector_help_opVision_OPV9000
---

# opVision OPV9000

This connector monitors and controls the state of the **opVision OPV9000** rack controller through a serial connection. The information of the device is polled with one single timer every five seconds.

## About

The protocol uses serial communication to retrieve information and to control the device.

The connector will export other connectors depending on the installed racks at the device. The exported connectors are described in the exported connectors section.

### Version Info

| **Range** | **Description**  |
|------------------|------------------|
| 1.0.0.x          | Initial version. |

### Product Info

| **Range** | **Device Firmware Version**                                                                                |
|------------------|------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | No available information, except for the Network Manager Card version, which is OPVNM-1.0 for the OPV9000. |

### Exported Connectors

| **Exported Connector** | **Description**                                                       |
|-----------------------|-----------------------------------------------------------------------|
| opVision OPV9000 Card | Exported connector based on the information from a single opVision card. |

## Installation and Configuration

### Creation

#### Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP of the device.
- **IP port**: The IP port of the device. No default value is specified.

## Usage

The opVision OPV9000 parent connector has several different pages: **General Information, Video, Optical, Hardware,** **Channel Control State** and **Custom Serial Command**.

### General Information

On this page, the general information for each card installed in the opVision OPV9000 is displayed in the **System Information Table**.

This includes:

- **Card Identification**
- **Card Address**
- **Board Description, Name,** **Nickname** and **Extended Bit Information**
- **Frame Description, Name, Nickname** and **Extended Bit Information**
- **Main** and **Backup Versions**
- **IP, Network Mask** and the **Gateway addresses**
- **Equipment/Function Type**
- **Ethernet**, **Video**, **Audio** and **Optical Fiber Ports**
- **Ethernet**, **Video**, **Audio**, **Fans** and **Optical Fiber Control**

In addition, the following settings are also possible:

- A factory reset or reboot of the OpVision 9000 device, by means of the buttons at the top of the page.
- A factory reset or reboot of each individual card, by means of the buttons in the **System Information Table**.

### Video

On this page, the following information is displayed in the **Video Table:**

- The table row identification, in the **Video Index** column
- The **card index**
- The **channel index** associated with the card index
- The lock **input/output**
- The **video type** for the card/channel combination

### Optical

This page displays the following information in the **Optical Modules Table:**

- The table row identification, in the **Index** column
- The **card index**
- The **optical module** associated with the card index
- The connection state, in the **connected column**
- The **link state** for the card/module combination

### Hardware

On this page, the following information is displayed:

- The temperature of the cards, in the **Temperature Table**
- The power state of the cards, in the **Power State Table**
- The fan states of each card, in the **Fan Table**

The **Temperature Table** has the following two columns: **Card Index** and **Temperature.**

The **Power State Table** contains the following information:

- The row identification, in the **Power Index** column, which combines the card identification and the power unit in use
- The card identification, in the **Card Index** column
- The **Power Unit** identification
- The **Power State**

The **Fan Table** displays the following information:

- The row identification, in the **Fan Index** column, which combines the card and its fan identification
- The card identification, in the **Card Index** column
- The **Fan Unit** identification
- The **Fan State**
- The **Work Mode**

### Channel Control State

This page displays the **Channel Control State Table**, which displays the card and channel combination state and its medium type.

This table has the following columns:

- The table row **Index**, which consists of a combination of card and channel
- The **Card Index**
- The **Channel Index**
- The channel's **State**
- The channel's medium **Type**

With the **Settings** page button, you can configure whether a particular channel for a particular medium type can be opened or closed. To do so, fill in every field and then click **Apply**.

### Custom Serial Command

On this page, you can enter any serial command to be sent to the opV9000 device in the **Custom Command** field at the top. The response, both ASCII and HEX, will be displayed below, by the **Received Response** parameter.
