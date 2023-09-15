---
uid: Connector_help_Newtec_MNT_Satlink_Manager
---

# Newtec MNT SatLink Manager

The Newtec MNT SatLink Manager connector implements a small subset of requests from the **Newtec** **SLC SIT Controller API**. The connector uses the **SOAP** API to interface with the SIT controller.

This connector is specifically used to enable/disable SCPC (SLM 1.0) or carrier (SLM 2.1) transmissions and reception.

## About

### Version Info

| **Range**            | **Key Features**                                                                             | **Based on** | **System Impact** |
|----------------------|----------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | \- Retrieval and configuration of modems, transmissions, and reception. - Supports 2 modems. | \-           | \-                |
| 1.1.0.x              | Updated to new firmware SLM 2.1.                                                             | 1.0.0.x      | \-                |
| 1.1.1.x \[SLC Main\] | Supports more modems (dynamic).                                                              | 1.1.0.x      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | SLM 1.0                |
| 1.1.0.x   | SLM 2.1                |
| 1.1.1.x   | SLM 2.1                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | EBU FNRMN MNT Manager | \-                      |
| 1.1.0.x   | No                  | Yes                     | EBU FNRMN MNT Manager | \-                      |
| 1.1.1.x   | No                  | Yes                     | EBU FNRMN MNT Manager | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

## How to use

The Newtec MNT SatLink Manager will request the following information via the SLM API:

- Modems
- Transmissions
- Receptions

The transmission and reception details can be configured via the Newtec MNT SatLink Manager.

As of range 1.1.1.x, the connector supports more than 2 modems.

## Notes

This connector is intended to be used in combination with the **EBU FNRMN MNT Manager** connector.

The EBU FNRMN MNT Manager element will perform sets on the Newtec MNT SatLink Manager element to configure the transmissions and reception. The Newtec MNT SatLink Manager passes information to the EBU FNRMN MNT Manager element via **data distribution**.
