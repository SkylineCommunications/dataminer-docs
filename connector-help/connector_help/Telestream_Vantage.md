---
uid: Connector_help_Telestream_Vantage
---

# Telestream Vantage

The Telestream Vantage software can be installed and run on a Windows server machine. This software is used to monitor and control Telestream clusters used for video transcoding. At this stage, only monitoring is implemented.

## About

This connector queries a SOAP interface available on the target machine.

Multiple different SOAP requests are daisy-chained to query for the list of configured workflows and jobs. Additional details are also retrieved for each **workflow** and **job** (including completion percentage and other metrics, such as the total execution time).

The connector also queries the Vantage SOAP interface for the various **servers** available in the cluster and retrieves information for each of these machines, including their **service** **list**, state and metrics.

### Version Info

| **Range**     | **Description**               | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version               | No                  | Yes                     |
| 1.0.1.x              | Implemented redundant pooling | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | Added unicode option.         | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Vantage 6.3                 |
| 1.0.1.x          | Vantage 6.3                 |
| 1.0.2.x          | Vantage 6.3                 |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port number**: The port of the connected device, by default *8676*.
- **Bus Address:** By default, this field is filled in with "*ByPassProxy*". This is necessary to avoid network issues.

#### HTTP secondary connection:

This connector has a secondary connection and requires the following input during element creation.

HTTP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *10.11.12.13.*
- **Port number**: The port of the connected device, by default *8676*.
- **Bus Address**: By default, this field is filled in with "*ByPassProxy*". This is necessary to avoid network issues.

### Configuration of Redundant Polling

This connector supports redundant polling. If an HTTP request times out, a secondary connection will be used for a retry. In order to use this feature, you must configure the secondary HTTP connection.

## Usage

Two main sets of pages are available in the connector. One set displays the **cluster information** (**servers** and **services**) and the other displays the **workflows** and **jobs** information.

Each set consists of two pages, one displaying the information in a **tree view** and the other displaying the **source tables** that contain all the data retrieved from the server. Users can monitor either page according to preference.

### Domain Machines and Server

This page displays a list of **servers** available in the **domain**. For each server, a list of **services** is also displayed, along with all **service metrics**.

This page displays its data in a **tree view**.

### Domain Machines and Server Tables

This page displays the same data as the "Domain Machines and Server" page, but the data is displayed in a **table structure** instead of a tree view.

### Workflow and Jobs

This page displays a list of **workflows** that are configured on the cluster. For each retrieved **workflow**, a **list of jobs** is also retrieved, along with the **current completed percentage**. For each of these jobs, a **list of sessions** is also retrieved. This information contains a historical overview of each job with each different step.

This page displays its data in a **tree view** format.

### Workflow and Jobs Tables

This page displays the same data as the "Workflow and Jobs" page, but the data is displayed in a **table structure** instead of a tree view.

### Driver Configuration

This page allows you to filter the jobs by their present status, and filter the session by date.

These filters limit the information shown on the other pages according to the selected options.

### Web Interface

This page displays the web interface of the device. However, note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
