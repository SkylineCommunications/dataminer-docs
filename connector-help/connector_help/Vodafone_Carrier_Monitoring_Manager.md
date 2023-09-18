---
uid: Connector_help_Vodafone_Carrier_Monitoring_Manager
---

# Vodafone Carrier Monitoring Manager

This is a virtual connector that is used to manage carrier monitoring (including carriers, measurement points and spectrum presets) at Vodafone.

### Version Info

| **Range**            | **Key Features**   | **Based on** | **System Impact**                                                                                              |
|----------------------|--------------------|--------------|----------------------------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version    | \-           | \-                                                                                                             |
| 1.0.1.x \[SLC Main\] | Renamed parameters | 1.0.1.5      | Filters, Automation scripts, Visio drawings, reports, and DataMiner Web API usage may need to be reconfigured. |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

This connector uses a **virtual** connection and does not require any input during element creation.

### Initialization

The connector uses an interactive Automation script to perform the "Create" and "Update Carrier" actions. Make sure this **Carrier Configurations** script is installed.

You can also assign the dedicated **Visio drawing** to the element for easy navigation between the configured carriers and their spectrum thumbnails.

## How to use

- **Driver Status**: Will show *Not Busy* if no operation is being done or *Busy* if an operation is being executed (e.g. creating a new carrier).
- **Carrier Table**: In this table, you can add, update, or delete specific carriers via the right-click menu.
- **Spectrum Monitor Table**: This table is automatically filled in with all available spectrum monitor elements and their measurement points.
- **Configuration:** On this page, you can configure default values that will be used to configure carriers.
