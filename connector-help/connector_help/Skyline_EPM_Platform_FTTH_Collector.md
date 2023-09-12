---
uid: Connector_help_Skyline_EPM_Platform_FTTH_Collector
---

# Skyline EPM Platform FTTH Collector

The **Skyline EPM Platform FTTH Collector** is in charge of ingesting data towards the integration with EPM platform back-end and front-end elements.

This collector represents an OLT (Optical Line Terminal) in the system, where all the ONTs (Optical Network Terminal) connected to it are displayed.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### General

This page contains general information related to the device:

- Number Headend
- Number OLT
- Number ONT

### ONT

This page contains a table with an overview of all the ONTs. The following columns are displayed:

- Name
- Time
- Status: Offline or Online
