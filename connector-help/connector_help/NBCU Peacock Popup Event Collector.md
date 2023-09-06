---
uid: Connector_help_NBCU_Peacock_Popup_Event_Collector
---

# NBCU Peacock Popup Event Collector

The source of event information for the NBCS Peacock SLE (Single Live Events, a.k.a. popups) is a shared Google spreadsheet used by many different entities within NBCS. The Event Collector driver collects and validates data from the sheet. It works in conjunction with the NBCU Popup Event Manager to store the event information.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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

#### HTTP Main Connection

This driver uses an HTTP connection to retrieve the spreadsheet information and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

#### HTTP Refresh Token Connection

This driver uses an HTTP connection for request authorization and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To make sure the driver can retrieve information from the spreadsheet, get the **access token** from Google OAuth.

### Redundancy

There is no redundancy defined.

## How to use

On the **General** page,you can configure the ID of the spreadsheet from which information events need to be retrieved. You should also specify the access token, the client ID and the client secret.
