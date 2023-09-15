---
uid: Connector_help_ONATi_Bandwidth_Aggregator
---

# ONATi Bandwidth Aggregator

The ONATi Bandwidth Aggregator connector was developed with the goal of identifying the total received (RX) and transmitted (TX) bitrates of a certain path. For this purpose, it allows you to select which interfaces should be considered for that path. To facilitate the configuration, a filtered list of interfaces is displayed after you select a DataMiner element from the list of supported connectors.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

The element has the following data pages:

- **General**: Displays the aggregated received (RX) and transmitted (TX) bandwidth, as well as the last time data was fetched from the included interfaces.
- **Configuration**
- **Add Interface**: Allows you to add a new interface to the monitored list. To do so, you can select an element and interface from a pre-filtered and ordered list. When the element has been selected, information such as the DMS element ID, protocol version and element state are displayed.

## Notes

Supported connectors and parameters:

- CISCO ASR Manager - Rx/Tx sources: Bitrate column from Detailed Interface Info Rx/Tx tables
- RAD Data Communications ETX-203AX - In Bit Rate and Out Bit Rate columns from Interfaces table
- CISCO Manager - Rx/Tx sources: Bitrate column from Detailed Interface Info Rx/Tx tables
