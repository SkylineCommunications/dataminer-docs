---
uid: Connector_help_Snell_Wilcox_IQSYN10
---

# Snell Wilcox IQSYN10

The **Snell Wilcox IQSYN10** connector monitors and controls changes on the frame synchronizer unit through a **Rollcall smart-serial** protocol. The card is used in the **IQ Modular Chassis**.

## About

The connector periodically polls relevant information from the device. This happens every 15 seconds for Rollcall protocol purposes and every two hours for backchannel purposes.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.27. .21                   |

## Installation and configuration

### Creation

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:
  - **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *2050*.
  - **Bus Address:** The bus of the card on the chassis. The default, *UU.PP (Hex)*, shows the expected structure of the address, where UU is the chassis ID, and the PP is the card position, both in Hex.

## Usage

### General

This page contains general information on the card hardware, including the **information shown on the display** of the device, and its various **versions** and **serial numbers**.

It is also possible to configure general **Product** **Settings** here.

### Video

On this page, you can configure general video-related options. It contains settings related to the **Video Inputs** and to the output **Defaults**, and also allows control of video **Freeze** and **Line Blanking**.

### ProcAmp

On this page, you can configure settings related to the **Processing Amplifier** functionality of the card.

### Pattern And Caption

On this page, you can configure the **Caption Type** and select its **pattern**.

### Genlock

This page contains settings related to the Genlock's **Phase** and **Video** **Delay**.

### Memories

The page displays the configurable **User Memory** setting slots **1 to 16** of the device.

You can recall the settings from any of the previous slots with the **Recall Memory** option and check the last used memory setting slot in the **Last User Memory**.

To save a memory setting, first use the **Select Memory** parameter to either select one of the memory slots or select *None*, configure the name using the **Change Memory Name** parameter (which will be displayed for the corresponding **Memory Name Values** parameter), and select whether to **Save** or **Clear** the memory. Note that when you clear the memory, the configuration associated with it will be lost, and you will need to save it again later in order to re-create it.

### RollTrack

On this page, you can check the status of and configure the RollTrack system of the card. This includes **Indexes**, **Sources**, **Addresses** and **Commands.**

### Logging Miscellaneous

This page contains the **Miscellaneous Values** for the card, which include states, versions and uptimes. The page also allows you to configure whether to **log** those values or not.

### Logging Video Input 1

This page contains the first **Video Input Values** for the card, which include states, errors and identification. The page also allows you to configure whether to **log** those values or not.

### Logging Video Input 2

This page contains the second **Video Input Values** for the card, which include states, errors and identification. The page also allows you to configure whether to **log** those values or not.

### Logging Reference

This page contains the **Reference Values** for the card, which include states and identification. The page also allows you to configure whether to **log** those values or not.

### Logging Video Output

This page contains the **Video Output Values** for the card, which include states and identification. The page also allows you to configure whether to **log** those values or not.

### Connection Info

This page displays the current status of the remote connection to the card.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
