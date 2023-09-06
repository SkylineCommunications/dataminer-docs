---
uid: Connector_help_NBCU_CAG_Incident_Gateway
---

# NBCU CAG Incident Gateway

The driver receives incident information to be submitted to the CAG Incident Gateway, which is a system proprietary to NBCU.

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

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination, by default *443.*
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

Insert the correct **API Key** on the **General** page.

## How to use

On the **Submit Incident** page, you can specify the necessary information to manually create a ticket. The resulting CAG Message Number will be requested, and all the incident details will be displayed in the **Ticket History** table.

On the **Templates** page (introduced in version 1.0.0.3), templates can be used for automatically submitted tickets.

A new event in the string format **\<Template\>\|\<PlaceholderName\>;\<PlaceholderValue\>\|\<PlaceholderName\>;\<PlaceholderValue\>\|...** can be sent to parameter ID 4047 to generate incidents based on a particular template.
