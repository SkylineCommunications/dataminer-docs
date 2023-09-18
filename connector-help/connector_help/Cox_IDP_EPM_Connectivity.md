---
uid: Connector_help_Cox_IDP_EPM_Connectivity
---

# COX IDP EPM Connectivity

This connector is used to manage DCF connections between non-CI Type elements.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

Use the **IDP_Helper_DVE_Connectivity** script as a starting point to start using this connector. The script will get the interfaces/ports information of the elements and send it to the COX IDP EPM Connectivity element. This element will then process the data and start creating DCF connections between non-CI Type elements.

The connector contains two main tables:

- The **Mapping** table, which contains element information (Chassis ID, Agent ID, Element ID).
- The **Connections** table, which contains interfaces/ports information (Port ID, DCF ID).
