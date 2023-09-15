---
uid: Connector_help_Generic_Dummy
---

# Generic Dummy

## About

This connector is a virtual connector developed to store parameter information. From range 1.0.2.x onwards, connections are made between all externally added interfaces (E.g. added by VC4 IMS).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.2.x          | DCF Integration | Yes                 | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## Usage

### Main View page

Dummy parameters are shown and editable from this page. In range 1.0.2.x, the dummy parameters are not always used, but they are available for future use.

## DataMiner Connectivity Framework

The 1.0.2.x connector range of the **Generic Dummy** protocol supports the usage of DCF and can only be used on a DMA with **8.5.8.5** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

### Interfaces

#### Dynamic Interfaces

Interfaces are added externally (E.g. added by VC4 IMS)

Virtual dynamic interfaces:

- For parametergroup **1**, interfaces are added in table **50000** of the type **inout**.

### Connections

After the interfaces are added externally, internal connections are made between all interfaces. To start making connections between added interfaces, a change has to be made on parameter **51000**.

#### Internal Connections

- Between all interfaces, an internal connection is created after a change is made (externally) on parameter **51000**.

## Notes

Make sure to make a change on parameter **51000** to trigger the creation of the internal connections.
