---
uid: Connector_help_Advantech_ADAM5050
---

# Advantech ADAM5050

The ADAM-5050 features sixteen digital input/output channels. Each channel can be independently configured to be an input or an output channel via the setting of its DIP switch. The digital outputs are open collector transistor switches that can be controlled from the ADAM-5000. The switches can also be used to control solid-state relays, which in turn can control heaters, pumps, and power equipment. The ADAM-5000 can use the module's digital inputs to determine the state of limit or safety switches, or to receive remote digital signals.

The connector uses **serial** communication with the device. It is possible to invert the mode line.

## About

### Version Info

| **Range** | **Key Features**                                      | **Based on** | **System Impact** |
|-----------|-------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version                                       | \-           | \-                |
| 1.1.1.x   | Translation value for linked parameter in Alarm table | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.29                   |
| 1.1.1.x   | 1.29                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device, by default *502*.
  - **Bus address**: The bus address of the device. Range: *0-7*.Note: This module is typically mounted in a 4- or 8-slot ADAM-5000 rack module and the bus address is determined by the slot position.

## Usage

This connector consists of two pages, the **Main View** page and the **General** page.

On these pages, you can find the **Real State** for each of the 16 channels.

You also have the option to independently:

- assign a read-only familiar name to the **User Value** for each channel.
- use normal line sense (default) or invert the line sense using the **Inversion Mode Line** control for each channel.
