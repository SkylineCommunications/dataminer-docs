---
uid: Connector_help_CEFD_NetVue_Remote_Gateway
---

# CEFD NetVue Remote Gateway

The CEFD NetVue Remote Gateway is a virtual connector that displays information about a remote device belonging to the NetVue system.

The connector does not do any polling: the data displayed by the connector is pushed by the **CEFD NetVue HUB Gateway** element managing this remote.

The remote gateway elements are created automatically by the **CEFD NetVue Manager** element and must not be created manually.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                      | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | CEFD NetVue ManagerCEFD NetVue HUB Gateway | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

The **General** page displays information about the hub gateway managing this remote.

The **Circuit** page displays information about the circuits managed by this remote.
