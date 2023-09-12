---
uid: Connector_help_Snell_Wilcox_KudosPro_Frame
---

# Snell Wilcox KudosPro Frame

This connector was designed to interface with the KudosPro and provide the features found in the RollCall Control Panel.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.5D.10                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### IP Connection

This connector uses a serial connection and requires the following input during element creation:

Serial connection:

- **IP address/host**: The polling IP of the device, e.g. *172.16.61.11*.
- **IP Port**: The IP port of the device, e.g. *2050*.
- **Bus address**: Fill in the unit address and port. For example, if *26.02* is filled in, this represents the unit address *0x26* and unit port *0x02*.

## How to use

You can find more information about the different data pages of the element below.

### General

The General page provides information related to the **status** of the device.

### Genlock

On the Genlock page, you can view and adjust **source** and **timing** parameters for **channels 1 and 2**.

### Audio Routing

On the Audio Routing page, you can view and adjust the routing for the **AES** and **analog outputs**.

### Audio Control

On the Audio Control page, you can view and adjust the unit's **input** and **output** audio handling options.

### Dolby Page

On the Dolby page, you can view and adjust the unit's **Dolby** parameters.

### Network Page

The Network page provides access to the unit's network details and setup.

When you update the **IP Address**, **IP Gateway**, **IP Netmask**, or **IP Configuration** parameters, click the **Apply IP Changes** button to ensure that the updated parameters are properly saved to the unit's configuration.

### Front Panel Page

On the Front Panel page, you can view and adjust the front panel features such as **LCD Display** and **Headphone** parameters.

### Memories

The Memories page allows you to save up to eight system-level memory setups and recall them when required.

The options **Reset to Defaults** and **Factory Reset** are also available. Use these with caution, as they will reset previously configured parameters.

### Logging

The Logging page displays how the parameters will be displayed when made available to the logging device.

The **Logging Config** subpage allows you to configure which parameters are available to the logging device.
