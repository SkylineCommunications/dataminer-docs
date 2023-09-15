---
uid: Connector_help_Huawei_iManager_U2000
---

# Huawei iManager U2000

The **Huawei iManager U2000** connector communicates with a Huawei iManager U2000 device to gather information about all **managed elements** in the network and the **links** between them.

## About

**HTTP SOAP** calls are used to retrieve all information.

This connector will create **dynamic virtual elements** for each managed element in the Huawei network.

### Version Info

| **Range** | **Description**                             | **DCF Integration** | **Cassandra Compliant** |
|------------------|---------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version                             | Yes                 | Yes                     |
| 1.0.1.x          | DVEs are now generated on a per shelf basis | Yes                 | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | U2000V100R009C00SPC301      |

### Exported connectors

| **Exported Connector**         | **Description** |
|-------------------------------|-----------------|
| Huawei iManager U2000 Element | Managed element |

## Installation and configuration

### Creation

#### HTTP Main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Configuration

The **username** and **password** need to be configured on the Configuration page.

## Usage

### General

This page displays general information about the Huawei iManager U2000 and allows you to initiate actions such as:

- **Refreshing all data** (note that this can take some time depending on the size of the network).
- **Removing all missing data**.
- **Automatically arranging the managed elements** for the Visio image of the main element.
- **Updating DCF** (note that you should make sure all data is up to date, as otherwise connections and connection properties could be removed)

Buttons to initiate an update of a single type of data can be found on the corresponding page.

### Treeview

This page displays a tree view starting from the resource sites.

The following data is available in the tree view:

- **Resource Sites**
- **Managed elements**
- **Shelves**
- **Slots**
- **Equipment**
- **Physical Termination Points**
- **Floating Termination Points**
- **Cross Connections**

### Elements

This page displays all **managed elements** in a table with some additional information.

**DVEs** are created based on this table.

### Equipment

This page displays all **shelves**, **slots** and **equipment** with their name and state.

### Termination Points

This page displays all **Physical Termination Points** and **Floating Termination Points**.

### Cross Connections

This page displays all **Cross Connections** with some information.

### Topological Links

This page displays all **Topological Links** of the Huawei network.

### Resource Sites

This page displays all **Resource Sites** with their name and type.

### Sub Network Connections

This page displays all **Sub Network Connections** (**services**) in a table.

### Configuration

The **username** and **password** need to be configured on this page in order to communicate with the Huawei iManager U2000 device.

## DataMiner Connectivity Framework

The 1.0.0.x connector range of the Huawei iManager U2000 protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5\[DCF\]** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported protocols is managed by this protocol.

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- For each entry in the **Floating Termination Points Table**, an interface is created. These interfaces are inout.

Physical dynamic interfaces:

- For each entry in the **Physical Termination Points Table**, an interface is created. These interfaces are inout.

### Connections

#### Internal Connections

- For each **Cross Connection**, an internal connection is created with the following properties:

- If the connection is used in 1 or multiple services, connection property **Service** of type **generic** is added with a semicolon-separated list of the **service names** as value.

#### External Connections

- For each **Topological Link**, an external connection is created.

## Notes

The connector does not allow the user to configure anything on the device. Only requesting information is supported.

The connector does not support multiple management domains.

**Custom Visio files** are available for the main element and the DVEs.
The Visio image for the **main element** displays all managed elements and connects them with DCF.
The **DVE** Visio image displays the shelf overview. **Multiple shelves** will be displayed on different pages.
Currently the following types of shelves are supported:

- **OptiX OSN 8800 T32**
- **OptiX OSN 8800 T16**
- **OptiX OSN 6800**
- **OptiX OSN 3500**
