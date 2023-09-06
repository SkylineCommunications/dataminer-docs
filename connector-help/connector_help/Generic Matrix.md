---
uid: Connector_help_Generic_Matrix
---

# Generic Matrix

This connector is a simple matrix connector. It does not communicate with a device and its primary function is to define connections in a DCF environment.

## About

### Version Info

| **Range**           | **Key Features**                                                                          | **Based on** | **System Impact** |
|---------------------|-------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x             | Initial version                                                                           | \-           | \-                |
| 9001.0.0.x \[Demo\] | Inputs and Outputs tables for resource creation. InterApp and FlowInfo messages receiver. | 1.0.0.2      | \-                |

### System Info

| **Range**  | **DCF Integration** | **Cassandra Compliant** | **Linked Components** |
|------------|---------------------|-------------------------|-----------------------|
| 1.0.0.x    | Yes                 | Yes                     | \-                    |
| 9001.0.0.x | Yes                 | Yes                     | \-                    |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

This connector contains a single page containing a matrix, along with options to define the number of inputs and outputs for the matrix. Crosspoints are set locally and saved when the element is restarted.

## DataMiner Connectivity Framework

The 1.0.0.x range of the Generic Matrix connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- The **Matrix** interface is of type inout and can be used to dynamically link inputs to outputs.
