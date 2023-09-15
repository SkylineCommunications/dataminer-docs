---
uid: Connector_help_Eutelsat_FTVO_Program_Service
---

# Eutelsat FTVO Program Service

This enhanced service enables the user to include or exclude the program from the mosaic.

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

To create a service with this connector, select the connector in the service editor. For more information, see [Adding a service](https://aka.dataminer.services/adding-a-service) in the DataMiner Help.

## How to use

The enhanced service will contain the Program State, Mosaic State, and the date since when the program is missing if it is no longer available on the AJIMI probe.

When the mosaic state is changed, the service will trigger the **CreateProgramServices** script. The script is responsible for checking the AJIMI probe and updating the enhanced services.
