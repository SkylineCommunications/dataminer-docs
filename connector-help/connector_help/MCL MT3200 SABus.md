---
uid: Connector_help_MCL_MT3200_SABus
---

# MCL MT3200 SABus

The **MT3200** is a medium power satellite amplifier designed for both mobile and earth station based applications.

The **MCL MT3200 SABus** driver is used to monitor MT3200 devices that use the SABus protocol.

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
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This driver uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- Interface connection:

- **IP address/host**: The polling IP or URL of the destination.
  - **IP port**: The IP port of the destination.
  - **Bus address**: The bus address of the device.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, the **RF Digital Attenuator** will initially be set to *Not Initialized* since it only has a write command. After a new value has been set, the parameter will display the new value if the set was successful.

On the **Analog** **Status** page, the **Gain Percentage** parameter can be used to adjust (increase or decrease) the **Gain** of the HPA. When this parameter is changed, the Gain will also change proportionally. For example, if the Gain Percentage is changed from 20% to 25%, the Gain will increase by 5.
