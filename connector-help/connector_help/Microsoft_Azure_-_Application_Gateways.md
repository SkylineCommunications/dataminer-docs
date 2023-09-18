---
uid: Connector_help_Microsoft_Azure_-_Application_Gateways
---

# Microsoft Azure - Application Gateways

An Azure Application Gateway is a web traffic load balancer that enables you to manage traffic to your web applications. Traditional load balancers operate at the transport layer (OSI layer 4-TCP and UDP) and route traffic based on source IP address and port, to a destination IP address and port.

Application Gateway can make routing decisions based on additional attributes of an HTTP request, for example URI path or host headers. You can for example route traffic based on the incoming URL. So if `/images` is in the incoming URL, you can route traffic to a specific set of servers (known as a pool) configured for images. If `/video` is in the URL, that traffic is routed to another pool that is optimized for videos.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**                                                                        |
|-----------|-----------------------------------------------------------------------------------------------|
| 1.0.0.x   | REST-API version 2018-01-01 for Metrics REST-API version 2020-11-01 for Backend Health Status |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                   | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Microsoft Azure Cloud Platform](xref:Connector_help_Microsoft_Azure) | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection. However, it requires no input from the user, as this connector is automatically created by the **Microsoft Azure connector**.

## How to use

The connector requires no user input.

The available metrics are divided into **Performance**, **Latency**, **Traffic**, **Backend** and **Billing** categories and each are available on their corresponding page.

**Key metrics** are Throughput, Application Gateway Total Time, Backend Connect Time, Failed Requests, etc.

The **Backed Health status** on the Backend page allows you to detect any unhealthy backend servers. **Contributor role** is required in the service principal since POST requests are performed to retrieve the Backend Health status.

On the **General** page, you can configure the **Polling Interval** for the metrics. This same page also displays the scope (Subscription and Resource Group) this resource type element belongs to.

## Notes

This connector is intended to be used together with the **Microsoft Azure** connector. Without that manager connector, this connector will not work, as the authentication to the Azure Cloud Platform is done via the manager connector.
