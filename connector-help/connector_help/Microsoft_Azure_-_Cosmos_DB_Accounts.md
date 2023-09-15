---
uid: Connector_help_Microsoft_Azure_-_Cosmos_DB_Accounts
---

# Microsoft Azure - Cosmos DB Accounts

Azure Cosmos DB is a fully managed NoSQL database for modern app development. Single-digit millisecond response times as well as automatic and instant scalability guarantee speed at any scale. Business continuity is assured with SLA-backed availability and enterprise-grade security. App development is faster and more productive thanks to turnkey multi-region data distribution anywhere in the world, open-source APIs and SDKs for popular languages. As a fully managed service, Azure Cosmos DB takes database administration off your hands with automatic management, updates and patching. It also handles capacity management with cost-effective serverless and automatic scaling options that respond to application needs to match capacity with demand.

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

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection. However, it requires no input from the user, as this connector is automatically created by the **Microsoft Azure connector**.

### Redundancy

There is no redundancy defined.

## How to use

The connector requires no user input.

The connector provides an overview of all resources of type "Cosmos DB" in a specific resource group as configured in the Microsoft Azure connector.

The General page gives you an overview of which resources are included, as well as general information related to Capacity Mode and to the activated APIs.

In order to monitor performance and resource usage, metrics have been implemented in relation to **throughput**, **data usage**, **latency** on several levels such as **Database**, **Region**, **Collection**, **Partitions**, **Operation Type** and **Status Code**.

## Notes

This connector is intended to be used together with the **Microsoft Azure** connector. Without that manager connector, this connector will not work, as the authentication to the Azure Cloud Platform is done via the manager connector.
