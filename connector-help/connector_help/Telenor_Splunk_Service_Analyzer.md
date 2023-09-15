---
uid: Connector_help_Telenor_Splunk_Service_Analyzer
---

# Telenor Splunk Service Analyzer

The **Telenor Splunk Service Analyzer** is a connector that communicates with a Splunk Enterprise server to retrieve information about services and channels in the Telenor EPM system.

The connector communicates with the Splunk server using an HTTP connection.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 8.0.5.1                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. Default value: *443.*
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

## Initialization

To be able to poll data from the server, fill in the username and password of the Splunk server on the **General** page.

## How to use

The connector polls multiple KPIs from the server. You can configure these KPIs in the **KPI Configuration** table on the **General** page. For each KPI, you can specify the search string, the timer period and the timeout.

The **Services** page displays the list of all the retrieved services and the links between them. The **Live Channels** and **Catch-Up Channels** pages display the list of retrieved channels.

The names of the channels retrieved from the Splunk server are different from the name of the channels in the Telenor EPM system. The **Channel Mapping** table, on the Channel Mapping subpage of the General page, contains the mapping between the channels. This content of this table is based on a provisioning file. The path and access details for that file can be configured on the Channel Mapping subpage.

If a channel cannot be found in the mapping, it will be added in the **T-We Live Channels - Unknown** or **T-We Catch-Up Channels - Unknown** table.
