---
uid: Connector_help_PixipNet_XOS_-_Location
---

# PixipNet XOS - Location

This connector is used by DVEs (Dynamic Virtual Elements) created by the parent connector [PixipNet XOS](xref:Connector_help_PixipNet_XOS).

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

The parent connector [PixipNet XOS](xref:Connector_help_PixipNet_XOS) creates a DVE using this connector for each location that is defined in it. The element using this connector displays all the monitors information for the relevant location.
