---
uid: Connector_help_General_Dynamics_CG-2022
---

# General Dynamics CG-2022

The General Dynamics CG-2022 is a digital tracking receiver developed for satellite tracking and uplink power control applications. The DSP-based receiver accepts wideband RF inputs, performs frequency selection, and digitally processes the selected signal.

The General Dynamics CG-2022 connector is used to control and monitor this device via a serial connection.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | No           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0048003C               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Serial Main Connection

This connector uses a serial connection and requires the following input during element creation:

SERIAL CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

### General

This page displays the configurable parameters, namely **Frequency**, **POL Select**, **Input Attenuation**, **Output Attenuation**, and the **Acknowledgement Fault** button.

### Rxer Operation

This page displays configurable parameters related to the DAC, such as **DAC1 Range**, **DAC1 Slope** and **DAC1 Output.**

### System

This page contains the device **Time** and **Date** parameter.

### Interface Options

This page displays the configurable parameters **Low Signal Level** and **High Temperature Limit**.

### Beacon

This page displays the configurable parameters **Store Beacon** and **Restore Beacon**.

### Alarms

This page displays the **Alarms Table**.

### Version

This page displays the **Display Version**.

### Get All

This page displays the parameters from **General**, **Rxer Operation**, **Interface Options**, and **System**.
