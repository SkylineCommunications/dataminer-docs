---
uid: Connector_help_Ateme_AMS_WAP
---

# Ateme AMS WAP

The Ateme Management System (AMS) web application provides real-time monitoring and control of service delivery for all Ateme solutions deployed on premises and in the cloud.

This connector is able to communicate with the application and fetch the information about instances, services, inputs, outputs and alarms available from the HTTP REST API.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 1.25.1                 |

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
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

No initialization required when creating the element.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The implemented communication uses HTTP REST calls to fetch data from the data source.

The parameter **HTTP State**, available on the **Generic** page, indicates the communication activity:

- *Idle* state means no request has been sent.
- *Busy* state indicates that a request has been sent and the connector is waiting for the response.

You can configure the polling period for each individual request on the **Communication** page in the **Polling Configuration** table.

These requests require authentication; therefore the credentials, on the **General** or **Communication** page, need to be configured. Once the authentication is done, the **HTTP Authentication State** will change from the *Logged Out* state to *Logged In.*

If the **Polling Configuration** Table indicates that a request has *Failed,* it means some unexpected status code was received or the response was not received in the expected format. If the **HTTP Retry Period After Request Fails** parameter is configured, the connector will use that period to keep retrying the request. Another solution is to restart the element.
