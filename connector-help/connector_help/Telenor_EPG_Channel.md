---
uid: Connector_help_Telenor_EPG_Channel
---

# Telenor EPG Channel

This connector is used to process an XML TV file describing the schedule of a TV channel. It will parse the XML TV file and list the scheduled programs. The connector will also retrieve the same information from an HTTP server and detect any mismatch.

**Telenor EPG Channel** elements are automatically created by a **Telenor EPG Manager** element.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                              | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Telenor EPG Manager](xref:Connector_help_Telenor_EPG_Manager) | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector automatically uses an HTTP connection that is determined by the Manager element. No user input is required.

## How to use

On the **General** page, the **Channel ID** and the path to the folder containing the XML files are displayed. Those parameters are set by the **Telenor EPG Manager** parent element.

The **Programs** page lists all the programs, along with some statistics related to the programs.
