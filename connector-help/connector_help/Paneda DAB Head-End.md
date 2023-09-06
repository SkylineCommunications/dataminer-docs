---
uid: Connector_help_Paneda_DAB_Head-End
---

# Paneda DAB Head-End

This connector retrieves the status information from four URLs (General System, Devices, Audio Services, and Data Services) for each provider configured in the system.

The data returned by the calls for each provider consists of data specific for that provider as well as general data on the overall system, which is identical for all the providers.The connector only displays the general data once, separately from the data that is unique for each provider. As such, if no provider is mentioned, this means the data relates to the overall system.

## About

### Version Info

| **Range**            | **Key Features**                           | **Based on** | **System Impact**                                                                         |
|----------------------|--------------------------------------------|--------------|-------------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                           | \-           | \-                                                                                        |
| 1.0.1.x              | Reorganization of the connector.           | 1.0.0.2      | Alarm and trend information lost. Table references lost. New element needs to be created. |
| 1.0.2.x \[SLC Main\] | Added HTTP support for multiple providers. | 1.0.1.2      | Alarm and trend information lost. Table references lost. New element needs to be created. |

### Product Info

| **Range** | **Supported Firmware**                       |
|-----------|----------------------------------------------|
| 1.0.0.x   | paneda_repo_version-2019.02.01.793-1-x86_64  |
| 1.0.1.x   | paneda_repo_version-2020.02.14.1160-1-x86_64 |
| 1.0.2.x   | paneda_repo_version-2020.02.14.1160-1-x86_64 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: 443

#### SNMP Connection - SNMP

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

On the **General** page, the correct authorization token must be filled in in the **Paneda Access Token** parameter. Otherwise, communication will fail.

Aside from this, no extra configuration is required.

### Redundancy

There is no redundancy defined.

## How to use

This connector retrieves information from the Paneda via HTTPS for each provider configured on the device.

The configured providers are retrieved from an SNMP table. The access token needs to be configured for each provider; otherwise no access will be provided.

The web interface is not available in the element. You can access it outside DataMiner Cube using Chrome.
