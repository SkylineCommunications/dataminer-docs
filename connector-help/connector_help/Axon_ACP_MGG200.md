---
uid: Connector_help_Axon_ACP_MGG200
---

# Axon ACP MGG200

The MGG200 is a building block of the Synapse multiviewer.

The **Axon ACP MGG200** driver can be used to display and configure information related to this device.

## About

This driver can be connected to the **Axon ACP Frame Manager** to generate and update the MGG200 elements that are part of the frame.

There are different possibilities available for **alarm monitoring** and **trending**.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1614                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Installation and configuration

### Creation

The element using this driver can be automatically created by the parent element using the **Axon ACP Frame Manager** driver, but it can also be created as a standalone element.

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the destination.
  - **Bus address**: The bus address of the device, being the slot number of the card.

#### Serial Broadcast Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

  - **IP address/host**: The polling IP of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page of the element, you can find information about the card (**Card Name**, **Card Description**, **SW Revision**, **HW Revision**, etc.).

After startup, you can adjust settings to fine-tune and customize the multiviewer screens:

- **Clock Settings** page: Allows you to manipulate the look and feel of the clock on the multiviewer.
- **Notepad Settings** page: Allows you to add a notepad and write lines onto the screen of the multiviewer.
- **Tally and UMD Settings** Page: Allows you to set up the **UMD** settings per input and their responsible **T**a**llies**.

You can customize the layout of the inputs to your preference. These settings are available on the **Layout Input 1-4** and **Layout Input 5-8** pages:

- Width
- Height
- Position (X-position and Y-position)
- Overlay
- Extra options (UMD, Tally, Audio Meter, etc.)

On the **Network** page, you can set up the network settings for the device:

- The **IP Configuration** allows you to set the network polling type of the device (**DHCP**, **Manual** or **Disabled**).
- Depending on the **IP Configuration** parameter, other parameters such as **Manual IP Address**, **Netmask**, **Manual Gateway**, **Primary** **DNS** and **Secondary** **DNS** can be set.
