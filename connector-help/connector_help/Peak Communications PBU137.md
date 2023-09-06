---
uid: Connector_help_Peak_Communications_PBU137
---

# Peak Communications PBU137

The PBU137 belongs to a series of upconverters. These high grade units are designed to accept the signal at L-band and provide a further conversion to the appropriate SHF band.

This connector can be used to display and set information when this device is configured to remote mode. It uses serial commands to retrieve the data from the Peak Communications PBU137 controller every 10 seconds.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP of the device.
  - **IP port**: The IP port of the device (Default 4000)
  - **Bus address**: The bus address of the device (*1 - 255*). For this particular device, the documentation indicates the value *32*.

## How to use:

The element has the following data pages:

- **General**: Displays general information about the unit - **Attenuation**, **Control** **Mode**, **External** **Reference**, **1:1 Status**, **Unit** **Type**, **Serial** **Number** and **Software Version**.
- **Alarms**: Displays an overview of all the alarms present - **Summary** **Alarm**, **Phase Locked Oscillator Status 1**, **Phase Locked Oscillator Status 2** and **Alarm** **Status**.
- **Redundancy**: Displays the redundancy parameters - **Redundancy** **Mode**, **Unit** **Priority**, **Unit to Go Online**, **Online Status**, **Redundancy Type**, **Unit Identifier** and **Coax Switch Position.**
