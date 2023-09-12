---
uid: Connector_help_TDF_Plan_Maintenance
---

# TDF Plan Maintenance

This connector is used to retrieve information about the TDF transmitter sites under maintenance and associated tickets.

The information is retrieved via an HTTPS ServiceNow API.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### HTTP Connection - Main

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling URL. e.g. [https://tdfprod.service-now.com/](https://tdfprod.service-now.com/api/now/).
- **IP port**: The IP port of the API. e.g. *443*.

### Initialization

After creating a new element, specify the **Username** and **Password** on the **General** page, so that the API connection can be authenticated.

Optionally, you can also specify a proxy server.

## How to Use

At element startup, the information is automatically retrieved. A button is also available to manually retrieve the information. There are no timers to refresh the data. When the information is retrieved, the tables are cleared and repopulated.

On the **General** page, you can define filters for retrieving the information:

- **Sub Domains Filter:** The connector will only load tickets belonging to these domains. The domains must be separated by a comma. e.g. *DIFFUSION TNT,HEBERGEMENT TNT.*
- **Ticket Opened Time**: The maximum opened date and time of the tickets to be retrieved. At element startup, this will automatically be set to tomorrow at 6:00.
- **Ticket End Time**: The minimum closed date and time of the tickets to be retrieved. At element startup, this will be automatically set to today at 6:00.

After the tickets have been loaded, the corresponding location and service data will be loaded. In case multiple tickets point to the same location, the location is only displayed once.
