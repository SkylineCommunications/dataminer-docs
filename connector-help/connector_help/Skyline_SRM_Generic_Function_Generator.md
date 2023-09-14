---
uid: Connector_help_Skyline_SRM_Generic_Function_Generator
---

# Skyline SRM Generic Function Generator

This connector can be used to generate resources for an SRM environment. It is intended for use in an environment with one or more matrices. An element will represent a product that is not monitored by DataMiner (an output and input in the matrix). Based on this element, a resource can then be created.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

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

The element created with this connector consists of only one parameter, which allows you to specify the name of the product. This name will then be used to create a resource.
