---
uid: Connector_help_Evertz_7703BPX-DC-RF
---

# Evertz 7703BPX-DC-RF

The 7703BPX-DC-RF is a 2x1 RF protection switch for a wide range of frequencies. It provides automatic changeover functionality to provide bypass protection of RF signals from 1-2250 MHz, and for DC LNB bias. The 7703BPX-DC-RF has integrated technology for remote control and monitoring capability via **SNMP**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.3.46                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.

## How to use

The **General** page contains basic status parameters for the device.

The frame controller supports **more modules** fitted in the chassis. The connector will display these as instances. The names of the added card types can be found in the **Monitor Table** on the **Control** page.

For each of those modules, you can configure the input in the **Input Control Table** on the **Control** page. The connector handles the switching logic taking into account the fact that different cards supported by the connector (SWRF16B7703, SWRF8B7703, SWRF47703) have a different number of inputs available (16, 8, 4, respectively).
