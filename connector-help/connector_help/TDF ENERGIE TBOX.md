---
uid: Connector_help_TDF_ENERGIE_TBOX
---

# TDF ENERGIE TBOX

This is a virtual driver. It retrieves parameters from elements using the **Semaphore TBox** driver. Via the Configuration Virtual Element toolbox, it is possible to link the driver parameters with parameters present in elements using the Semaphore TBox driver.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

In the element created with this driver, you will find the following parameters: Defaut Tension Normale (Amont INS), Defaut Tension Aval INS, Inverseur NalSec - Normal Enclenche, and INS - Secours Enclenche.

The **Inversion** parameter allows you to invert the discrete logic used for each of the parameters when necessary.
