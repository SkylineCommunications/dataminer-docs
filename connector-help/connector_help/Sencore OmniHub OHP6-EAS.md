---
uid: Connector_help_Sencore_OmniHub_OHP6-EAS
---

# Sencore OmniHub OHP6-EAS

Similar to the **Sencore OmniHub 6-16**, the **OmniHub OHP6-EAS** polls data from the inputs and outputs of the EAS card, using SNMP in range 1.0.x.x. and HTTP in range 1.1.x. The EAS processing module supports EAS triggering by analog EAS input and digital EAS input.

## About

### Version Info

| **Range**            | **Key Features**                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                                          | \-           | \-                |
| 1.1.0.x              | Changed from "SNMP" connection type to "HTTP" connection. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | V0.3.0                 |
| 1.1.0.x   | V0.3.0                 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main connection

In range 1.1.0.x, this connector is used to create a standalone element with an HTTP connection, requiring the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.
- **Number of Retries**: The number of retries for HTTP commands. This should be set to "0" for write parameters to work properly.
- **Timeout of a single command (ms)**: The time between HTTP commands. This should be set to "10000" for write parameters to work properly.

#### SNMP Connection

In range 1.0.0.x, this connector is a DVE of the Sencore OmniHub 6-16 connector. It uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **SNMP Type**: SNMPv2.
- **IP address/host**: The polling IP or URL of the destination. **Important**: The IPmust be set to the **IP address assigned to the specific card in the System Settings Advanced Network tab** of the device, as the connector has to access the card directly to work properly because of limitations in the device SNMP implementation.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device (default: *ByPassProxy*).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

See "Authentication and Element Slot Assignment" below.

### Redundancy

There is no redundancy defined.

## How to use

### SNMP Version: DVE of Sencore OmniHub Frame

The Sencore OmniHub 616 has a limited SNMP feature set. Parameters are limited to status and configuration parameters defined in a limited MIB, and SNMP traps are not supported.

Each DVE page contains information related to the EAS card. Status information is displayed on the **General** page, while the configuration can be changed on the **Settings** page.

### HTTP Version

The Sencore OmniHub EAS has a full feature set at parity with the device web interface.

Each page contains information related to the EAS card. Status information is displayed on the **General** page, while the configuration can be changed on the **Settings** page.

On the **System Operations** page, you can reboot the card.

### Authentication and Element Slot Assignment

For the range with the HTTP connection, you need to specify a username and password on the **General** page of the element. You also have to specify the **EAS Slot Number** associated with the card you wish to poll with this element.

Note: The device **only supports a single HTTP login session**, so any user currently logged into the device **web interface** **will be disconnected every time the DataMiner element polls the device** using an HTTP REST API call. Should a user need to access the web interface, all elements that are accessing the device using HTTP must be **paused** to prevent this issue.
