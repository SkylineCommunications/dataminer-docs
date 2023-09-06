---
uid: Connector_help_Verizon_WM_Collectors
---

# Verizon WM Collectors

This is strictly a system driver. Its function is to perform different actions in the workflow that allows the different **Verizon Collector** drivers to communicate with the **Profile Manager** app.

## About

### Version Info

| **Range**            | **Key Features**                                   | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                   | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Logic that interfaces with the collectors removed. | 1.0.0.1      | \-                |

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

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

**As this driver is strictly a system driver, it requires no user interaction.**
