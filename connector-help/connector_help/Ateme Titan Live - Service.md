---
uid: Connector_help_Ateme_Titan_Live_-_Service
---

# Ateme Titan Live - Service

From version 4.0.0.7 of the Ateme Titan Live driver onwards, for each service, a DVE is created that uses this exported driver. Each service DVE can be used to monitor that particular service.

## About

This driver is exported by the parent driver, **Ateme Titan Live**, from version 4.0.0.7 onwards.

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 4.0.0.x   | 4.1.10.5               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 4.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

The element using this driver is automatically created by the parent element using the Ateme Titan Live driver. No user input is required.

## How to Use

The element using this driver contains two pages:

- **General**: Contains general parameters related to the service.
- **Services Overview**: Displays a tree control containing each output stream of the service. Via the **Service Tables** page button, you can view the raw data displayed in the tree control. This button opens a subpage with the Output Transport Stream table, the Output Audio Parameters table, the Output Video Parameters table and the Output Data Parameters table.
