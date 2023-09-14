---
uid: Connector_help_TDF_GE_TBOX
---

# TDF GE TBOX

This is a virtual connector. It retrieves parameters from elements using the **Semaphore TBox** driver. Via the Configuration Virtual Element toolbox, it is possible to link the connector parameters with parameters present in elements using the Semaphore TBox driver.

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

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

In the element created with this connector, you will find the following parameters: Marche GE, GE en Manuel, Forcage Marche GE, Defaut GE, Marche Forcee GE Distante, and Arret Marche Forcee GE Distante.
