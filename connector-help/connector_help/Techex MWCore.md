---
uid: Connector_help_Techex_MWCore
---

# Techex MWCore

The Techex MWCore connector is an HTTP-based connector that can be used to monitor and configure the **MWCore IPTV Management Platform**.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                        | **Based on** | **System Impact**                                                                    |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Initial version (includes DCF integration).                                                                                                                                                                                             | \-           | \-                                                                                   |
| 1.0.1.x \[obsolete\] | Reformat of the MWEdge stream keys.                                                                                                                                                                                                     | 1.0.0.2      | **Old trend and alarm data will be lost for Streams, Input Sources, and Outputs.**   |
| 1.0.2.x \[obsolete\] | \- Single output/input is retrieved upon context menu operation instead of MwEdge polling. - MWEdges are retrieved separately instead of all at once. - Reverse foreign key relation between Streams Resources table and Streams table. | 1.0.1.19     | **Because NuGets are now used, the minimum DataMiner version is now 10.0.10.**       |
| 1.0.3.x \[SLC Main\] | \- Statistics Connections table and "IP Connection - Statistics Interface" connection removed. - Columns added to the Servers Info table to enable the statistics interface for each server.                                            | 1.0.2.3      | **Existing elements need to be reconfigured to account for the connection changes.** |

### Product Info

| **Range**                         | **Supported Firmware**                                                            |
|-----------------------------------|-----------------------------------------------------------------------------------|
| 1.0.0.x, 1.0.1.x,1.0.2.x, 1.0.3.x | **MWCore version:** 5.2.3 (Build 784), 5.2.4 \| **MWEdges version:** 1.9.2, 1.9.3 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components**                                                                      |
|-----------|---------------------|-------------------------|-----------------------|----------------------------------------------------------------------------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | [Techex MWCore - Generic Device](xref:Connector_help_Techex_MWCore_-_Generic_Device) |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | [Techex MWCore - Generic Device](xref:Connector_help_Techex_MWCore_-_Generic_Device) |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | [Techex MWCore - Generic Device](xref:Connector_help_Techex_MWCore_-_Generic_Device) |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | [Techex MWCore - Generic Device](xref:Connector_help_Techex_MWCore_-_Generic_Device) |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination (e.g. [*https://middleware.techex.co.uk*](https://middleware.techex.co.uk/)).
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

This connection is used to perform the regular polling, to retrieve data from the device based on a request/response mechanism.

#### HTTP Secondary Connection

This connector also uses a redundant HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination (e.g. [*https://middleware.techex.co.uk*](https://middleware.techex.co.uk/)).
- **IP port**: The IP port of the destination (default: *443*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

This is the redundant connection, used to perform the regular polling when the main connection is no longer responding.

#### IP Connection - Statistics Interface (range 1.0.0.x-1.0.2.x only)

This connector uses a TLS TCP IP connection and requires the following input during element creation:

TLS TCP IP CONNECTION:

- **IP address/host**: The hostname of the destination, which needs to be the same as the CN (Subject) of the certificate (e.g. [*middleware.techex.co.uk*](https://middleware.techex.co.uk/)).
- **IP port**: The IP port of the destination, which is defined in the product (System \> Telemetry).
- **SSL/TLS:** Select this check box to enable the TLS protocol (default: disabled).

This connection is used to receive incoming statistics notification event messages. It is no longer used since range 1.0.3.x.

### Initialization

In order to initialize the connector, you need to specify the following input configuration on the **Communication** page:

**HTTP Communication**:

- **Username:** Name of the user used in the HTTP login operation.
- **Password:** Password of the user used in the HTTP login operation.

**IP Connection - Statistics Interface**:

- **IP Connection State:** State of the referred connection, which needs to be set to *Enabled* in order to receive the statistics notification event messages.
- **Client Certificate Path:** Path to the .pfx client certificate. Note that the .pfx certificate file contains both public and private keys.
- **Client Certificate Password:** Password of the client certificate related to the referred path.
- **Server DNS Names:** Introduced in range 1.0.1.x. Add a semicolon-separated list of the DNS name of each MWCore server for statistics polling.

Note that if the public and private key certificates are in the .pem format, they have to be exported to a .pfx file, as documented in [OpenSSL](https://www.openssl.org/docs/man1.0.2/man1/pkcs12.html) (e.g. openssl pkcs12 -inkey private_key.pem -in public_key.pem -export -out client_certificate.pfx).

In addition, note that *openssl.exe* comes alongside a [Git](https://git-scm.com/) installation.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

This connector provides a monitoring and configuration interface for the **Techex MWCore Platform.** It allows you to perform operations on monitored **Devices**, **Channels**, **MWEdges**, **Streams**, and **Input** and **Output Sources**.

The **IP Connection - Statistics Interface** provides statistics information for the input sources and output sources, including ETR290 statistics data**.**

**REST API** calls are used to establish communication with the server.

Optionally, the connector can **export a DVE for each device** monitored by the Techex MWCore Platform.

## DataMiner Connectivity Framework

The **1.0.0.x** range of the Techex MWCore - Generic Device connector supports the usage of DCF and can only be used on a DMA with **8.5.4** as the minimum version.

DCF can also be implemented through the DataMiner DCF user interface and through DataMiner third-party connectors (for instance a manager).

Connectivity for all exported connectors is managed by this connector.

### Interfaces

#### Dynamic interfaces

Virtual dynamic interfaces:

- **Output:** Created to interface with the DVE table with **interface type out**.
