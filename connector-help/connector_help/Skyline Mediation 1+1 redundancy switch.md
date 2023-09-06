---
uid: Connector_help_Skyline_Mediation_1+1_redundancy_switch
---

# Skyline Mediation 1+1 redundancy switch

This is a mediation connector for redundancy switches. It links to parameters in redundancy switch elements, so that the parameters can be displayed in a uniform way.

## About

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### Version Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                     | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- Snell Wilcox IQHCO3193-1A- Snell Wilcox HCO51 RollCall | \-                      |

## Creation

It is not possible to create elements with a mediation connector. Instead, elements of supported connectors will have an extra menu item in the element card menu that allows you to see the mediation parameters instead of the default parameters.

The following connectors are supported:

- Snell Wilcox IQHCO3193-1A
- Snell Wilcox HCO51 RollCall

## How to Use

To view the information from this connector, click the hamburger button on the element card of an element using one of the supported connectors, and select **Mediation layer** \> **Skyline Mediation 1+1 redundancy switch**.

The card will then display the information from the mediation layer on the **General** page. This information consists of the following parameters:

- Output Selection Status
- Output Selection Configuration
- Valid Input Status
