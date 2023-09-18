---
uid: Connector_help_NHK_Generic_DCF
---

# NHK Generic DCF

This is a generic connector with one DCF input connection and one DCF output connection. It can be used to visualize and manage connections between data sources.

## About

| **Range**            | **Key Features**                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Contains DCF connections (one in and one out) and general device info. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Specify the IP, name, and location of the data source.

## How to use

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- one input interface
- One output interface
