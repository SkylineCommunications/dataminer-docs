---
uid: Connector_help_Snell_Wilcox_HCO51_RollCall
---

# Snell Wilcox HCO51 RollCall

The Snell Wilcox HCO51 protocol uses the RollCall community library package to communicate with the device. The protocol is able to retrieve, set and monitor information regarding inputs, standards, output, genlock, video and audio delays.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                    |
|-----------|-----------------------------------------------------------|
| 1.0.0.x   | Device Firmware 4.18.20 \| RollCall Library Version 3.0.9 |

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
  - **Bus address**: The bus address of the device. Specify the bus address in the format **UU.PP**, with UU being the rollnet address and PP being the slot number (chassis is 00). Example: *10.01*.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this driver has the following data pages:

- **General**: Shows the Display, Information Selected to Display and Card in Mode values. Also allows you to check the polling state and enable/disable debug mode.
- **Summary**: Displays the summary of the input state and statistics.
- **Input 1 Valid** and **Input 2 Valid:** Allows you to enable/disable input standards, and check and change the audio pairs and audio and video configurations.
- **Output**: Allows you to verify and change the output configuration and routing options.
- **Genlock and Delay**: Allows you to configure the Genlock, as well as audio and video delays.

## Notes

In the initial version of this protocol, only a subset of the information available in the device is implemented, i.e. the Summary, Input 1, Input 2, Output, Genlock and Delay pages.
