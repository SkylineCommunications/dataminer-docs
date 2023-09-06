---
uid: Connector_help_DAZN_Broadcast_Bridge
---

# DAZN Broadcast Bridge

The DAZN Broadcast Bridge platform translates the DOTS livestream module data into a standardized output for use in broadcast services.

## About

### Version Info

| **Range**            | **Key Features**                              | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Initial version.- Event stream monitoring. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware / API** |
|-----------|------------------------------|
| 1.0.0.x   | v1                           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).

### Initialization

When the element has been created, go to the **Settings** page, and specify the **API key**. Polling will start as soon as a correct API key has been added.

## How to use

The Events table is displayed on the **General** page.

On the **Settings** page, you can find the API key and the event request size.
