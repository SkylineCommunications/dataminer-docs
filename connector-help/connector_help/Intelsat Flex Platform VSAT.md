---
uid: Connector_help_Intelsat_Flex_Platform_VSAT
---

# Intelsat Flex Platform VSAT

The IntelSat Flex Platform VSAT functions as a virtual connector designed to streamline the presentation of critical data sourced from Intelsat terminals. This platform offers an intuitive front-end interface that enables users to conveniently interact with the data. To facilitate this process, a separate connector known as the Generic Kafka Consumer operates autonomously to ingest data from the Intelsat Kafka broker. This consumer collects the data and persists it as files within a designated location. Subsequently, the IntelSat Flex Platform VSAT injects these saved files, populating the corresponding data tables. This integrated approach ensures that the data is efficiently organized and instantly accessible via the connectors's interface.

## About

### Version Info

| **Range**            | **Key Features**      | **Based on** | **System Impact** |
|----------------------|-----------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | KAFKA Files Injection | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

A Generic KAFKA Consumer element must be created and configured before starting an IntelSat Flex Platform VSAT element.

### Redundancy

There is no redundancy defined.

## How to use

On the **Remotes** page of this connector, you will find the Terminals and SSPCs tables. These tables are populated with data pulled from KAFKA broker via the Generic KAFKA Consumer


The **Topic Settings** is where you can configure specific parameters related to importing data from KAFKA files.


