---
uid: Connector_help_SLC_SDF_DCF
---

# SLC SDF DCF

This is an example connector illustrating DCF.

## About

### Version Info

| Range | Key Features | Based on | System Impact |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x [SLC Main] | Example DCF      | -           | -                |

## Configuration

### Initialization

No additional configuration of parameters is necessary in a newly created element.

### Redundancy

There is no redundancy defined.

## How to Use

The QuickAction 1: DCFHelper contains the namespace ProtocolDCF that can be copy-pasted into other connectors.

This connector contains 4 pages.

The *DCF Example - ...* pages contain examples for specific DCF situations.

Clicking *Save* on a specific page will remove any DCF connection and property configuration you applied on the other pages. An exception are the fixed connections made between virtual interfaces for *DCF Example - Fixed Interfaces*.

### DCF Example - Fixed Interfaces

This displays two parameters. Depending on the toggled state of these two parameters, different connections will be made between fixed interfaces.

### DCF Example - Unique Source

This uses the interfaces set up in the Table Interfaces page. The Unique Source example allows you to add rows to the table to specify a connection where each source interface can only have a single connection.

### DCF Example - DVE

Allows you to add DVEs to the connector. Each DVE has one source interface and two destinations. Depending on the Destination toggle button, the connection inside of the DVE will be different.

### DCF Example - Matrix

Displays a matrix that is connected to the DCF module in DataMiner. Every input and output is an interface, and every connection you make on the matrix will automatically create a DCF connection in the background. The *Log Matrix Interface* button runs a small example code that will filter and show every interface made from the matrix in the logging.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the SLC SDF DCF connector supports the usage of DCF and can only be used on a DMA with DataMiner version **8.5.4** or higher.

DCF can also be implemented through the DataMiner DCF user interface and through third-party DataMiner connectors (e.g. a manager).
