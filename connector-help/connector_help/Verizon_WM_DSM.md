---
uid: Connector_help_Verizon_WM_DSM
---

# Verizon WM DSM

This is strictly a system driver. Its function is to perform different actions in the workflow that allows the **Verizon DSM SO** driver to communicate with the **Profile Manager**.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

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

**As this connector is strictly a system driver, it requires no user interaction.**

## Notes

An **Automation script** is needed to trigger this connector. The connector will process information events, perform the correct actions in the workflow with the **Profile Manager** and update the **Verizon DSM SO**.
