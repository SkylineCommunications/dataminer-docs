---
uid: Connector_help_Skyline_Panel_Manager
---

# Skyline Panel Manager

The Skyline Panel Manager connector is designed to manage and create links between software panel elements and hardware panel elements. You can also create those elements using this connector.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### General

This page displays the **Panel Manager** **table**, which allows you to connect software panel elements to hardware panel elements. There can only be one software panel per hardware panel.

To add or remove links, use the right-click menu of the table.

### Hardware Panels

This page displays status information for the existing hardware panel elements.

You can also enable or disable the management of these elements. If you disable management, the panel manager will not be able to use them for the linking process.

Right-click the table to access the context menu, which allows you to add new hardware elements, remove them, or recreate them (if a specific element was removed but still has a record in the Hardware Panel table).

### Software Panels

This page displays status information for the existing software panel elements.

You can also enable or disable the management of these elements. If you disable management, the panel manager will not be able to use them for the linking process.

Right-click the table to access the context menu, which allows you to add new software elements, remove them, or recreate them (if a specific element was removed but still has a record in the Software Panel table).

### Capabilities

This page displays information about the capabilities files found in the Documents folder.
