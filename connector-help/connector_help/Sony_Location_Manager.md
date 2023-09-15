---
uid: Connector_help_Sony_Location_Manager
---

# Sony Location Manager

This connector manages the possible Sony locations.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | Any (virtual connector)   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element created with this connector has the following data pages:

- **General**: This page displays **Studio Locations**, **OBTruck Locations**, **Control Room Locations** and **Server Room Locations.** Via the right-click menu, locations can be added or deleted.
- **Configuration**: This page displays the **File Name.** This parameter contains a reference to the SRM provisioning file. This file is updated every time a new location is added. It allows operators to know in which location a resource can be placed at the time of its creation.
