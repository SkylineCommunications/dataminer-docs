---
uid: Connector_help_Nokia_OMS_1350
---

# Nokia OMS 1350

The **Nokia Optical Management System** (OMS) **1350** centralizes multiple network management functions in one unified management system for the entire Nokia optics portfolio.

This connector uses the CORBA protocol to communicate with the **Nokia OMS 1350**.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                                                                                                                                                                                                                                                                                                                                                                                                                        |
|-----------|---------------------|-------------------------|-----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \- [Nokia OMS 1350 - Node](xref:Connector_help_Nokia_OMS_1350_-_Node) - [Nokia OMS 1350 - 11DPM8](xref:Connector_help_Nokia_OMS_1350_-_11DPM8) - [Nokia OMS 1350 - 11QPA4](xref:Connector_help_Nokia_OMS_1350_-_11QPA4) - [Nokia OMS 1350 - 32EC2](xref:Connector_help_Nokia_OMS_1350_-_32EC2) - [Nokia OMS 1350 - AHPHG](xref:Connector_help_Nokia_OMS_1350_-_AHPHG) - [Nokia OMS 1350 - USRPNL](xref:Connector_help_Nokia_OMS_1350_-_USRPNL) |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

In order to use this connector, you must configure the **IP** **Address**, **Port** **number**, **User** **Name** and **Password**. These parameters can be found on the **General** page.

In addition, the DLL files **IIOPChannel.dll** and **OMS_1350.dll** also have to be placed in the folder "C:\Skyline DataMiner\ProtocolScripts" on the DMA.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

On the **Overview** page, you can find a tree view of the nodes managed by this OMS and the card equipment installed on these nodes.

DVEs can be created for each of the tree view components, which will handle general system parameters and specific alarm information. Creating and deleting DVEs can be done on the **Equipment** page. A DVE can be created for each managed node, as a virtual representation of the node setup, and for the supported card types. Currently, only the following card types are supported: 11DPM8, 11QPA4, 32EC2, AHPHG and USRPNL.
