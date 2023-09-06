---
uid: Connector_help_Tata_Sky_India_Limited_Mediation_IRD
---

# Tata Sky India Limited Mediation IRD

This is a mediation connector for the IRDs used by Tata Sky India.

Only the connectors in use by Tata Sky India are implemented for this mediation connector. They are mapped to parameters in the ranges used by them.

## About

### Version Info

| **Range**            | **Key Features** | **Based on**          | **System Impact** |
|----------------------|------------------|-----------------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | Skyline Mediation IRD | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                                                                                                                                                 | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Ateme Kyrion DR5000 3.0.4.x Cisco D9800 1.2.0.x Cisco D9854 1.0.0.x Ericsson RX8200 2.0.1.x Ericsson RX8330 2.0.4.x Ericsson RX8330C 1.0.0.x Harmonic Proview PVR8130 1.0.1.x Motorola DSR-4460 1.0.1.x Scopus Network Technologies IRD-2900 1.1.2.x Tandberg RX1290 3.0.0.x Thomson Video Networks RD Series 1.0.0.x | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No additional configuration is necessary

## How to use

It is not possible to create elements with a mediation connector. Instead, elements of supported connectors will have an extra menu item in the element card menu that allows you to see the mediation parameters instead of the default parameters.

Supported connectors are:

- Ateme Kyrion DR5000 3.0.4.x
- Cisco D9800 1.2.0.x
- Cisco D9854 1.0.0.x
- Ericsson RX8200 2.0.1.x
- Ericsson RX8330 2.0.4.x
- Ericsson RX8330C 1.0.0.x
- Harmonic Proview PVR8130 1.0.1.x
- Motorola DSR-4460 1.0.1.x
- Scopus Network Technologies IRD-2900 1.1.2.x
- Tandberg RX1290 3.0.0.x
- Thomson Video Networks RD Series 1.0.0.x

To view the information from this connector, click the hamburger button of the element card for one of the supported connectors and select **Mediation layer** \> **Tata Sky India Limited Mediation IRD**.

The card will then display the information from the mediation layer on the **General** page. This information consists of the following parameters:

- BER
- C/N
- Signal Level
- Margin
- Service ID
- RF Status
- Video Bit Rate
- Audio 1 Bit Rate
- Audio 2 Bit Rate
- Firmware Version
- Serial Number
