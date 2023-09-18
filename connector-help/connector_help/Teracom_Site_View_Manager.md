---
uid: Connector_help_Teracom_Site_View_Manager
---

# Teracom Site View Manager

This virtual connector reads and processes data from an .xlsx file in order to make Site Views Visio drawings.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | No                      | \-                    | \-                      |

## Configuration

This connector uses a **virtual** connection and does not require any input during element creation.

## How to Use

On the **General** page, two buttons are available:

- **Import File**: Imports a file adding new entries while keeping the existing positions.
- **Import File (w/ Reset)**: Imports a file overriding existing positions.

On this page, you can also see the current **Processing Task** and the **Current Task Status**.

The other data pages of the connector contain tables with the data used to created specific types of Visio drawings.
