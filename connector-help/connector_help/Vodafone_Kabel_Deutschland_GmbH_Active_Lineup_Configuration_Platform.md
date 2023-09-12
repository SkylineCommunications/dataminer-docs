---
uid: Connector_help_Vodafone_Kabel_Deutschland_GmbH_Active_Lineup_Configuration_Platform
---

# Vodafone Kabel Deutschland GmbH Active Lineup Configuration Platform

The Vodafone Deutschland GmbH Active Lineup Configuration Platform connector collects all active lineup configurations from every enhanced service protocol present in the DataMiner System.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                              | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Vodafone Kabel Deutschland GmbH RegioMUX Lineup Service](xref:Connector_help_Vodafone_Kabel_Deutschland_GmbH_RegioMUX_Lineup_Service) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

No extra configuration is needed.

### Redundancy

There is no redundancy defined.

## How to use

You can find all the information you need to monitor on the General data page.

On the **Configuration** page of this connector, you can configure the discovery and heartbeat intervals. The **discovery interval** determines how frequently the connector will search for new enhanced services. The **heartbeat interval** determines how frequently the connector will collect the data from the enhanced services.
