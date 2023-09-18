---
uid: Connector_help_SES_S.A._Skala
---

# SES S.A. Skala

This is an **HTTP** connector that communicates with **iDirect Pulse** via the **Restful API** provided by the system. It displays the data in such a way that users can easily monitor the different terminals controlled by the iDirect Pulse.

## About

### Version Info

| **Range**            | **Key Features**                               | **Based on** | **System Impact** |
|----------------------|------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                | \-           | \-                |
| 1.0.1.x \[SLC Main\] | New design and new API endpoint to gather data | 1.0.0.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP WebService Interface Connection

This connector uses a Hypertext Transfer Protocol (HTTP) connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the data source.

HTTP Settings:

- **Port number**: 443

#### HTTP WebSocket Interface Connection

This connector uses a Hypertext Transfer Protocol (HTTP) connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The IP address of the data source.

HTTP Settings:

- **Port number**: 443

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use - Range 1.0.0.x

On the **Remotes** page, you can find the remotes and all their information in the **Remotes Overview** table. This information is polled according to the **Config Polling Interval** and **Status Polling Interval** parameters on the **DB Polling Config** page. An XML file is then created with all the remotes, and it is exported at a regular interval to a user-specified directory. The export path and export time interval are defined in the **File Export Path** and **Export Processing Time** parameters, respectively, on the **Collector Setup** page.

A JSON-structured file is then ingested from a user-specified directory at a regular interval. The purpose of this is to update circuits in the **Circuits Overview** table with config information, if any. The import directory and import interval are defined in the **File Import Path** and **Import Processing Time** parameters on the **Collector Setup** page.

Circuits are added to the **Circuits Overview** table once IDs have been assigned to the remotes. Every polling cycle, there is a check to see if there are any remotes in the **Remotes Overview** table that do not exist in the **Circuit Overview** table. If a remote does not exist, it will be added to a CSV file in a user-specified directory, and an inter-element set will occur to the **Verizon VSAT Platform Manager** so that it can properly assign the IDs to the remote. The **Verizon VSAT Platform Manager** then does another inter-element set back to **SES S.A. Skala**, and it ingests a JSON-structured file with all the circuits and their IDs. These circuits are then added to the **Circuits Overview** table on the **Circuits** page.

## How to Use - Range 1.0.1x

On the **General** page, you can find the **Subscription Key**. The **Configuration** page contains the **Polling Frequency**. This can be set to a value ranging from 1 to 30 minutes, with a default value of 5 minutes.

Every polling cycle, the **Terminals Overview** table is filled up with KPI data for each terminal, and the **Available Metrics** table shows the available metrics via an HTTP request every hour.
