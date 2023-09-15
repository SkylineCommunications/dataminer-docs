---
uid: Connector_help_Snell_Wilcox_IQSDA32
---

# Snell Wilcox IQSDA32

The **Snell Wilcox IQSDA32** connector monitors and controls changes on the distribution amplifier unit through a **Rollcall** **smart-serial** protocol. The card is used in the **IQ Modular Chassis**.

## About

The connector periodically polls relevant information from the device. This happens every 15 seconds for Rollcall protocol purposes and every two hours for backchannel purposes.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | 5.2 .5                      |

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

### Input

This page displays the basic configuration for each of the 2 available inputs. It allows you to configure the **SDI rates** and **On Signal Loss** behavior, as well to mute the channels.

### Memories

The page displays the configurable **User Memory** setting slots **1 to 16** of the device.

You can recall the settings from any of the previous slots with the **Recall Memory** option and check the last used memory setting slot in the **Last User Memory**.

To save a memory setting, first use the **Select Memory** parameter to either select one of the memory slots or select *None*, configure the name using the **Change Memory Name** parameter (which will be displayed for the corresponding **Memory Name Values** parameter), and select whether to **Save** or **Clear** the memory. Note that when you clear the memory, the configuration associated with it will be lost, and you will need to save it again later in order to re-create it.

### Logging

On this page, you can configure the logging associated with each of the card's input systems. This includes the **Inputs** from the Input page and the **Miscellaneous** logging from the system.

### RollTrack

On this page, you can check the status of and configure the RollTrack system of the card. This includes **Indexes**, **Sources**, **Addresses** and **Commands.**

### Setup

On this page, you can configure the names for each **input**, configure data related to the **board**, **reset settings to the defaults**, and **restart** the device.

### Connection Info

This page displays the current status of the remote connection to the card.

### Web Interface

This page provides access to the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
