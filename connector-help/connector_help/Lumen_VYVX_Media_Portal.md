---
uid: Connector_help_Lumen_VYVX_Media_Portal
---

# Lumen VYVX Media Portal

This connector communicates with the Lumen Media Portal Rest API. It shows the information available on the Linear Channel Distribution page of the web interface.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**       |
|-----------|------------------------------|
| 1.0.0.x   | Media portal API version 1.5 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: https://ws.lumen.com
- **IP port**: 443
- **Bus address**: *bypassproxy*

### Initialization

Specify the **API Key** and **API Secret Key** on the **General** page of the element.

From the Lumen web interface, on the Linear Channel Distribution page, **export a CSV file** with the necessary information. You can find the option to export the information as CSV in the top-right corner of the table.

In the element, specify the path to the exported CSV file and import it. This information is currently not available from the REST API.

Configure the **polling interval**. The default value is 1 minute. This setting will determine how often the Reservations Active Status is requested.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The **Linear Channel Distribution** page combines the information from the CSV import and the Reservations Active Status from the REST API.

Entries in the CSV that are not reported by the REST API will be marked as missing and can be deleted.

Entries reported by the REST API that are not in the CSV will be added to a separate table. The CSV synchronization status will be updated to reflect this situation. A new CSV should be imported to have the latest available information.
