---
uid: Connector_help_Keysight_FieldFox_Handheld_Analyzer
---

# Keysight FieldFox Handheld Analyzer

The Keysight FieldFox Handheld Analyzer can be used for monitoring and supports both a Spectrum Analyzer and a built-in Power Meter mode. The analyzer can handle tough working environments during routine maintenance, in-depth troubleshooting, and anything in between.

## About

### Version Info

| **Range**            | **Key Features**                                                                                            | **Based on** | **System Impact** |
|----------------------|-------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Support for spectrum analyzer. - Support for built-in power meter mode with multiple measurement points. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | A.12.31                |

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
  - **IP port**: The IP port of the destination (default: *5025*).

### Initialization

When you first start using this element, go to the **General** page and make sure the **Operating Mode** is set as expected. By default, *Spectrum Analyzer Mode* is selected.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page, you can find generic information regarding the model, manufacturer, power information and much more.

Depending on the configured **operating mode**, the element should be used differently:

- **Spectrum Analyzer Mode**: The Spectrum Analyzer page should be used when the element is in this mode. All spectrum controls are available on this page.
- **Channel Power Meter Mode**: With this mode, the Channel Power Meter page should be used. It will allow you to set up different measurement points. Via the **Add Measurement** page button, you can add a new measurement point.

Note:

- The **Measurement Points Polling Time** determines when round-robin polling starts for all measurement points.
- The **Settling Time** determines the wait time between applying the settings and getting the measurement. This can be configured per measurement point.

## Notes

For the moment, this connector only supports sweeps that take a maximum time of 5 seconds. This should be improved in the future. This device is not able to report the sweep time before initiating a sweep. This makes it impossible to use a pop-up message to ask the user if they really want to request a trace when the sweep time is large. It also makes it hard to know how long to wait after initiating a sweep. For these reasons, the connector uses a 5-second maximum to ensure correct functionality.
