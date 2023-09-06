---
uid: Connector_help_Grass_Valley_Audio_Live
---

# Grass Valley Audio Live

Audio Live is a multi-channel audio routing and processing solution for the IP domain. The primary purpose of the device is to configure the delays on the audio channels and perform audio channel shuffling.

## About

### Version Info

| **Range**            | **Key Features**                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Audio channel shuffling Audio channel delay configuration | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Tested on 1.5.2.18     |

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
  - **IP port**: The IP port of the destination (default: *2050*).
  - **Bus address**: The bus address of the device. Format: UU.PP where UU is the unit address and PP is the unit port. For example: *01.01*.

### Initialization

Default stream names are used in the router control tables. If you want custom names to be displayed, you can change the names in the DataMiner element. Custom names already configured on the device need to be retrieved separately. This can be done via the **Get Stream Names** button on the **General** page. **Do not change any configuration while this action is running, because then that change could be applied on the wrong stream!**

### Redundancy

There is no redundancy defined.

## How to use

The **General** page displays the overall status of the device.

The **Input** and **Output** pages can be used to configure the individual input/output streams. Stream status information is also displayed here. **Channel Delay** configuration can be accessed via the **Channels** page button.

The **Router Control** page provides an overview of all input and output channels. This is used for **audio channel shuffling** operations. Changing the **Connected Input** will cause a **Take** to be performed on the device.

The **Setup** page can be used to display and change all global configurations on the device.
