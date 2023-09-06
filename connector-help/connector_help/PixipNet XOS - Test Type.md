---
uid: Connector_help_PixipNet_XOS_-_Test_Type
---

# PixipNet XOS - Test Type

This driver is used by DVEs (Dynamic Virtual Elements) created by the parent driver [PixipNet XOS](xref:Connector_help_PixipNet_XOS).

## About

### Version Info

| **Range**                | **Key Features** | **Based on** | **System Impact** |
|--------------------------|------------------|--------------|-------------------|
| 1.0.0.x **\[SLC Main\]** | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

## Configuration

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to Use

The parent driver [PixipNet XOS](xref:Connector_help_PixipNet_XOS) creates a DVE using this driver for each test type that is defined in it. The element using this driver displays all the monitors information for the relevant test type.
