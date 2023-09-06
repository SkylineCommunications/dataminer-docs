---
uid: Connector_help_Al_Jazeera_Media_Network_ScheduAll
---

# Al Jazeera Media Network ScheduAll

This is a custom connector developed for Al Jazeera. It can be used to parse location and reporter information from ScheduAll.

A custom restful API was developed on the ScheduAll side to retrieve certain info (like "Locations" and "Reporters") that is not available in the regular chorus API.

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

### Creation

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *127.1.2.3*.
- **IP port**: The IP port of the device, with value *80*.

## How to use

The element consists of the following pages:

- **General**: Shows the status code of the locations and the reporter responses.
- **Locations Overview**: Shows the locations information retrieved from ScheduAll. A button at the top allows you to refresh the displayed information.
- **Reporters Overview**: Shows the reporters information retrieved from ScheduAll. A button at the top allows you to refresh the displayed information.
