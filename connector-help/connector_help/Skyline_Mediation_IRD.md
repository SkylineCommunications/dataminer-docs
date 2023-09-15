---
uid: Connector_help_Skyline_Mediation_IRD
---

# Skyline Mediation IRD

This is a mediation connector for IRDs.

## About

This connector links to parameters in IRD elements, so that the parameters can be displayed in a uniform way.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|--|--|--|--|--|
| 1.0.0.x | No | Yes | - Ericsson RX8200<br>- Harmonic Proview PVR8130<br>- Ericsson RX8330<br>- Ateme Kyrion DR5000<br>- Scopus Network Technologies IRD-2900<br>- Cisco D9800<br>- Cisco D9854 | - |

## Creation

It is not possible to create elements with a mediation connector. Instead, elements of supported connectors will have an extra menu item in the element card menu that allows you to see the mediation parameters instead of the default parameters.

Supported connectors are:

- Ericsson RX8200
- Tandberg RX1290
- Harmonic Proview PVR8130
- Ericsson RX8330
- Ateme Kyrion DR5000
- Scopus Network Technologies IRD-2900
- Cisco D9800
- Cisco D9854

## How to Use

To view the information from this connector, click to the hamburger button of the element card for one of the supported connectors and select **Mediation layer** \> **Skyline Mediation IRD**.

The card will then display the information from the mediation layer on the **General** page. This information consists of the following parameters:

- BER
- C/N
- Signal Level
- Margin
