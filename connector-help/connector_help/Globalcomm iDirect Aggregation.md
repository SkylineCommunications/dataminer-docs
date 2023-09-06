---
uid: Connector_help_Globalcomm_iDirect_Aggregation
---

# Globecomm iDirect Aggregation

This virtual driver can be used for aggregation of data from iDirect Platform elements. It can perform sum, average, percentage, minimum and maximum calculations, as well as MODCOD date rate and distribution aggregation.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

This driver requires that the type of the iDirect Platform elements is manually added to the platform table, so that it can process the calculations.

### Redundancy

There is no redundancy defined.

## How to use

On the **Overview**, **Status** and **MODCOD** pages, you can see the results of the various aggregation operations.

On the **Platform** page, you can select the iDirect Platform elements in the DMS that should be taken into account for these operations.

On the **Platform Operation Control** page, you can manage which operations are performed for each parameter. When the virtual element is created for the first time, the table contains default values according to the type of parameter.
