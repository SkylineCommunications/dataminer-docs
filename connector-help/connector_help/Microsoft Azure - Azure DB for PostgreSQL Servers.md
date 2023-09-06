---
uid: Connector_help_Microsoft_Azure_-_Azure_DB_for_PostgreSQL_Servers
---

# Microsoft Azure - Azure DB for PostgreSQL Servers

Azure DB for PostgreSQL Servers is a fully managed, intelligent, and scalable PostgreSQL.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

This driver uses an HTTP connection. However, it requires no input from the user, as this driver is automatically created by the **Microsoft Azure Cloud Platform**.

## How to use

The driver requires no user input. The metrics that are polled for this resource type element are displayed on the **Metrics** page. The following metrics are monitored:

- Active Connections
- Failed Connections
- CPU percent
- IO percent
- Memory percent
- Storage percent

On the **General** page, you can configure the **Polling Interval** for the metrics. This same page also displays the scope (Subscription and Resource Group) this resource type element belongs to.

## Notes

This driver is intended to be used together with the **Microsoft Azure Cloud Platform** driver.Without this manager driver, the driver will not work, as the authentication to the Azure Cloud Platform is done via the manager driver.
