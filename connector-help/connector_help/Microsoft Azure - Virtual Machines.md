---
uid: Connector_help_Microsoft_Azure_-_Virtual_Machines
---

# Microsoft Azure - Virtual Machines

Azure Virtual Machines (VM) are one of several types of on-demand, scalable computing resources that Azure offers. Typically, you choose a VM when you need more control over the computing environment than the other choices offer. An Azure VM gives you the flexibility of virtualization without the need to buy and maintain the physical hardware that runs it.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**      |
|-----------|-----------------------------|
| 1.0.0.x   | REST-API version 2018-01-01 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                   | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | [Microsoft Azure Cloud Platform](xref:Connector_help_Microsoft_Azure) | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection. However, it requires no input from the user, as this connector is automatically created by the **Microsoft Azure Cloud Platform**.

## How to use

This connector requires no user input. The metrics that are polled for this resource type element are displayed on the **Metrics** page. The following metrics are monitored:

- Percentage CPU
- Available Memory Bytes
- Network In Total
- Network Out Total
- Disk Read Bytes
- Disk Write Bytes

On the **General** page, you can configure the **Polling Interval** for the metrics. This same page also displays the scope (Subscription and Resource Group) this resource type element belongs to.

## Notes

This connector is intended to be used together with the **Microsoft Azure Cloud Platform** connector.It requires this manager connector to work, as the authentication to the Azure Cloud Platform is done via the manager connector.
