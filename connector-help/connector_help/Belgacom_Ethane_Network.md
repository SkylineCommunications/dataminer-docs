---
uid: Connector_help_Belgacom_Ethane_Network
---

# Belgacom Ethane Network

This is a **virtual connector** that can be used to manage connections between **Cisco Managers** and **Alcatel SR Managers**.

## About

This connector allows the user to **create and manage input, in/out and output interfaces**. The input interfaces connect to the Cisco Managers, while the output interfaces connect to the Alcatel SR Managers. The in/out interfaces can be used to configure a "mesh" in the connector itself.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### General

This page displays the **Connections Table**, which shows the current **internal connections** and their **properties**.

The table has a **Delete button** for each row, which you can use to delete a specific connection.

The page contains parameters that allow you to make connections from **NodePort to NodeService**, **NodeService to ENA** and **NodeService to NodeService**.

### Add/Remove Interfaces

This page displays the **Node**, **Node Port**, **Node Services** and **ENA** tables. Each table contains a **Delete** **button** that can be used to delete a specific connection.

The page also allows you to **add** or **delete** a **Node**, **Node Port**, **Node Service** or **ENA** interface.

## DataMiner Connectivity Framework

### Interfaces

#### Dynamic Interfaces

Virtual dynamic interfaces:

- **Input** - **NodePort:** Connects to the Cisco Managers.
- **In/Out** - **NodeService:** Allows you to configure and manage a mesh inside the connector.
- **In/Out** - **Node:** These interfaces are not controllable. They allow you to configure and manage connections inside the connector.
- **Output** - **ENA:** Connects to Alcatel SR Managers.

### Connections

#### Internal Connections

- Between **NodePort** and **NodeService**, an internal connection is created with the following properties:

- **VLAN** connection property of type **inout** with a value depending on the Cisco Manager connected to the NodePort.

- Between **NodeService** and **Node**, an internal connection is created with the following properties:

- **Service** connection property of type **inout** with a value depending on the ENA connected to Alcatel SR Manager.

- Between **NodeService** and **NodeService.**

- Between **Node** and **ENA**, an internal connection is created with the following properties:

- **SDP** connection property of type **inout** with a value depending on the ENA connected to Alcatel SR Manager.

#### External Connections

- Between **NodePort** and **Cisco Manager (Output)**
- Between **ENA** and **Alcatel SR Manager (Input)**

## Notes

The **external interfaces** (NodePort and ENA) must be **created first** and connected to the Cisco Manager and Alcatel SR Manager, as the connector gets data on the fly from them. This **information is added as a connection property** when NodePort-NodeService and NodeService-Node/Node-ENA connections are made.
