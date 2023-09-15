---
uid: Connector_help_Nokia_OMS_1350_-_AHPHG
---

# Nokia OMS 1350 - AHPHG

The **Nokia** **Optical** **Management** **System** (OMS) **1350** centralizes multiple network management functions in one unified management system for the entire Nokia optics portfolio.

This connector uses the CORBA protocol to communicate with **Nokia** **OMS** **1350**.

This type of Nokia OMS DVE is a representation of an installed AHPHG card.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.5                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

The exported element is defined in the **Exported Cards** table on the General page of the main element.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The element created with this connector consists of a page with general parameters and a page with an alarm table. This table can be used to monitor the state of the module.
