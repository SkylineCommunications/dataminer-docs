---
uid: Connector_help_NBCU_ServiceNow_Prism
---

# NBCU ServiceNow Prism

The ServiceNow Prism is a ticketing system that is created to create CAG incident tickets. This connector was developed for NBCU integration between **CAG** and the **ServiceNow** connector.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTPS Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTPS CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: 443).
- **Bus address**: The bus address of the device. If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

When you have created the element, configure the username and password on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On the **General** page, the element has the default parameter values that will be used for the API connection.

- For Incident and CI standalone parameters, the connector uses these to create the sysparam_query API header parameter. The following format is used: \[**fieldParamvalue** LIKE **valueParamValue**\]
- The **Maximum Records per Polling** parameter is used to limit how much data will be received.

The connector does not set values to the device. It contains the following tables with information: **Incidents**, **CI**, and **Assignment Groups**.

There is only one way to create new tickets: the parameter 150 has to receive the data in JSON format and then send it via API call to the device. The following JSON format is used:

{
"short_description": "string",
"cmdb_ci": "CI_ID (string)",
"active": "string (true/false)",
"description": "string",
"priority": "priorityNumber (string)",
"assignment_group":"assignmentGroup_ID (string)"
}
