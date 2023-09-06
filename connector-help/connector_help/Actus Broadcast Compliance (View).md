---
uid: Connector_help_Actus_Broadcast_Compliance_(View)
---

# Actus Broadcast Compliance (View)

Actus View is a professional broadcast compliance recording and monitoring platform for recording any number of TV or radio channels, from any input and any format.

## About

### Version Info

| **Range**            | **Key Features**                                                                                  | **Based on** | **System Impact** |
|----------------------|---------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial support for Actus Rest API:- Exporting transport stream- Authenticating (scope: clipping) | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | v8.1.0.12645           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                              | **Exported Components** |
|-----------|---------------------|-------------------------|----------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Skyline.DataMiner.ActusInterAppAPI (NuGet package) | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

HTTP calls are used to export a transport stream. On the Export Transport Stream page, you can configure the necessary parameters to perform an export.

On the Jobs page, jobs related to the exported transport streams are displayed. A progress and description column are available and will display the current status of the job.

## Notes

Currently, the General page contains two parameters to define credentials (user and password). These are used to send an Authenticate command (with scope: clipping). They are not used for anything else. All commands related to exporting transport streams do not need any credentials. In the future, we are planning to add support for more commands from the API.
