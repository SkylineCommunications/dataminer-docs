---
uid: Connector_help_SLC_SDF_DCF
---

# SLC SDF DCF

Example protocol illustrating DCF.

## About

### Version Info

**This subsection can only be omitted for an exported connector**

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Example DCF      | \-           | \-                |

## Configuration

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

There is no redundancy defined.

## How to use

### The help page on the connector provides more info on how to use this connector.



## Dataminer Connectivity Framework

The **1.0.0.x** range of the SLC SDF DCF connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager).

The QuickAction 1: DCFHelper contains the namespace ProtocolDCF that can be copy pasted into other drivers.
This driver contains 4 Pages.The DCF Example - ... pages contain examples for specific DCF Situations.Clicking Save on a specific page will remove any DCF Connection and Property Configuration you applied on the other pages.An exception is the Fixed Connections made between virtual interfaces for DCF Example - Fixed Interfaces.
DCF Example - Fixed Interfaces This displays two parameters, depending on the toggled state of these two parameters different connections will be made between fixed interfaces.DCF Example - Unique Source This uses the Interfaces setup in the Table Interfaces page. The Unique Source example allows you to add rows to the table to specify a connection where each source interface can only have a single connection.DCF Example - DVE Allows a user to add DVE's to the driver. Each DVE has one Source interface and two destinations. Depending on the Destination togglebutton the connection inside of the DVE will be different.DCF Example - Matrix Displays a matrix that's connected to the DCF module in DataMiner. Every Input and Output is an interface and every connection you make on the matrix will automatically create a DCF connection in the background. The Log Matrix Interface button runs a small example code that will filter and show every interface made from the Matrix in the logging.

### Interfaces

#### Fixed interfaces

Virtual fixed interfaces:

- Description of the interface: for what **parameter** is the virtual fixed interface created and what is the interface **type** (in / out / inout).

Physical fixed interfaces:

- Description of the interface: for what **parameter** is the physical fixed interface created and what is the interface **type** (in / out / inout).

#### Dynamic interfaces

Virtual dynamic interfaces:

- Description of the interface: for what **parameter** is the virtual dynamic interface created and what is the interface **type** (in / out / inout).

Physical dynamic interfaces:

- Description of the interface: for what **parameter** is the physical dynamic interface created and what is the interface **type** (in / out / inout).

### Connections

#### Internal Connections

- Between **\[...\]**, an internal connection is created with the following properties:
  - **\[...\]** connection property of type **\[ in / out / inout / generic\]** with value **\[...\]**.

#### External Connections

- Between **\[...\]**, an external connection is created with the following properties:
  - **\[...\]** connection property of type **\[ in / out / inout / generic\]** with value **\[...\]**.
