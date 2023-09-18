---
uid: Connector_help_Nagra_Contego
---

# Nagra Contego

The **Nagra Contego** is a conditional access system.

## About

This connector uses HTTPs to monitor the Nagra Contego equipment.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.0                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - \[Main\]

This connector uses an HTTPs connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination
- **IP port**: The IP port of the destination



### Initialization

Before the data will be retrieved, the **User Name** and **Password** must be filled in on the **General** page.

### Redundancy

There is no redundancy defined.

## How to Use

At startup of the element or when using the **Login** button, data will be retrieved every minute using the login information.
In case this would fail, a message will be shown on the **General** page.


