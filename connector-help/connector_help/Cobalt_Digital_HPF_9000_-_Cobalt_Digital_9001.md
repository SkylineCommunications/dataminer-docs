---
uid: Connector_help_Cobalt_Digital_HPF_9000_-_Cobalt_Digital_9001
---

# Cobalt Digital HPF 9000 - Cobalt Digital 9001

The Cobalt Digital 9001 is an exported DVE SNMP card for a modular frame. The card contains temperature, voltage, as well as the slot on the frame it is inserted. The table is exported via DVE creation as requested by the user on the Cobalt Digital HPF 9000.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial Version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   |                        |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                      |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     |                       | [Cobalt Digital HPF 9000](xref:Connector_help_Cobalt_Digital_HPF_9000) |

## Configuration

## Connections

This element is created by the parent element using the **Cobalt Digital HPF 9000** driver by a toggle button. No additional configuration is needed.

Initialization

This exported element is defined in the Card 9001 of the parent element **Cobalt Digital HPF 9000** driver.

Redundancy

There is no redundancy defined.

## How to use

This dynamic virtual element is created by the SNMP driver Cobalt Digital HPF 9000 via a toggle button. The user can toggle DVE creation for the specific card in the slot which exports the information virtually.


