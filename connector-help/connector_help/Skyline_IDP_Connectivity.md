---
uid: Connector_help_Skyline_IDP_Connectivity
---

# Skyline IDP Connectivity

This connector is part of DataMiner IDP. It is used to manage DCF connections between elements.

## About

### Version Info

| **Range**            | **Key Features**                                           | **Based on** | **System Impact**               |
|----------------------|------------------------------------------------------------|--------------|---------------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                           | \-           | \-                              |
| 1.0.1.x \[SLC Main\] | Increased minimum DataMiner version to 10.0.0.0 - 9517 CU6 | 1.0.0.x      | The DMS may need to be updated. |

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

This connector can only be used as part of **DataMiner IDP**.

Use the **IDP_Example_Custom_ConnectivityDiscovery** script as a starting point to start using this connector. The script will get the interfaces/ports information of the elements and send it to the Skyline IDP Connectivity element. This element will then process the data and start creating DCF connections between elements.

The connector contains two main tables:

- The **Mapping** table, which contains element information (Chassis ID, Agent ID, Element ID).
- The **Connections** table, which contains interfaces/ports information (Port ID, DCF ID).
