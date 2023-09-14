---
uid: Connector_help_TV2_Norway_Sumo_Monitoring
---

# TV2 Norway Sumo Monitoring

This connector is a manager connector that retrieves a list of assets and then configures an analyzer device to monitor the assets.

## About

This connector is used by TV2 Norway to manage the analysis of OTT services. It retrieves a list of assets from the SUMO platform, and determines for each of them whether it has to be analyzed.

If an asset has to be analyzed, a command will be sent to the Agama analyzer element to configure the monitoring.

## Installation and configuration

### Creation

The TV2 Norway Sumo Monotoring protocol is an **HTTP** connector. The **hostname** of the SUMO service has to be configured during creation of the **element**.

**HTTP CONNECTION**:

- **Type of port**: TCP/IP.
- **IP address**: The hostname of the device (e.g. *sumo.tv2.no*).
- **IP Port**: The IP port of the device (default: *443* for HTTPS).

Configuration

On the **Configuration** page, the element must be further configured:

- **Platform Code**: The value of this parameter will be filled in on the URL to request the asset details. ("\<platform\>" placeholder)
- **Webservice username and password**: The credentials to log on to the SUMO server. Header based authentication is used.
- **Asset details url**: Play URL to request the asset details. The following placeholders can be used and are automatically filled in : \<platform\>, \<serverId\>, \<assetId\>.
- **User-Agent Header**: User agent to use in the HTTP requests.
- **Vman Server ID**: The server ID that is used in the URL to request the asset details. ("\<serverId\>" placeholder)
- **Vman Server Base URI**: This is the base URI to use when configuring tests on the analyzer. This replaces "\<server\>" in the manifest URLs.
- **Agama Element ID**: DMA/Element ID of the DataMiner element for the Agama analyzer device.
- **Agama Test Template Name**: The name of a configured test template on the Agama device. Be sure that this name is identical to that on the Agama device.
- **Asset Sources Table**: Use the shortcut menu of this table to specify the source where you can retrieve the list of assets. The correct type (live or 24hrs) should also be selected.

## Usage

### General page

Displays the total number of retrieved assets and the login status of the webservice.

### Assets page

A table with all the retrieved assets from the SUMO webservice. Data is also read from the Agama analyzer element: Number of defined tests. The derived Analyzing state for an asset is OK when analysis is required and there are tests running on the Agama for that asset.

### Actions page

This table provides an overview of when the tests are started or stopped for each asset.

### Encoders page

A table with all the configured encoders on the SUMO system. Here it's possible to enable or disable the analysis for each encoder.

### Vman Servers page

A table with all the Vman servers.

### Configuration page

See the "Installation and configuration" section.
