---
uid: Connector_help_Techex_MWCore_-_Generic_Device
---

# Techex MWCore - Generic Device

This driver is used by Dynamic Virtual Elements (DVEs) exported by the Techex MWCore parent driver.

## About

### Version Info

| **Range**            | **Key Features**                            | **Based on** | **System Impact** |
|----------------------|---------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version (includes DCF integration). | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 5.3.0-alpha.3          |

## Configuration

This driver is automatically created by the parent driver [Techex MWCore](xref:Connector_help_Techex_MWCore).

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element contains general information, network information and settings for a device monitored by the MWCore platform.

## DataMiner Connectivity Framework

The **1.0.0.x** driver range of the Techex MWCore - Generic Device protocol supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner Third Party protocols (for instance a manager).

Connectivity for this protocol is managed by the parent protocol Techex MWCore.

### Interfaces

#### Dynamic interfaces

Virtual dynamic interfaces:

- **Output:** Created to interface with the DVE table with **interface type** **out**.
