---
uid: Connector_help_NBCU_ServiceNow_Prism
---

# NBCU ServiceNow Prism

The ServiceNow Prism is a ticketing system that is created to create CAG incident tickets. This driver was developed for NBCU integration between **CAG** and **ServiceNow** driver.

About

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

After the user creates the element, they must configure the username and password param values placed on **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

On **General** page, the element has default parameter values that would be used for the API connection.

- For Incident and CI standalone parameters, the driver uses them to create the sysparam_query API header parameter. The format is the following: \[**fieldParamvalue** LIKE **valueParamValue**\]
- The **Maximum Records per Polling** parameter is used to set the limit number of data the user wants to receive.

The driver does not have set values that we need to send to the device. It contains three tables: **Incidents**, **CI** and **Assignment Groups** tables.

There is only one way to create new tickets: the parameter 150 receive the data in JSON format and just send it via API call to the device. The JSON format is the following:

{ "short_description": "string", "cmdb_ci": "CI_ID (string)", "active": "string (true/false)", "description": "string", "priority": "priorityNumber (string)", "assignment_group":"assignmentGroup_ID (string)"}
