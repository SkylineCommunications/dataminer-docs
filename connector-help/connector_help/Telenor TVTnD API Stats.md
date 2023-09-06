---
uid: Connector_help_Telenor_TVTnD_API_Stats
---

# Telenor TVTnD API Stats

The Telenor TVTnD API Stats is a virtual connector that displays information about how many times the "TV TD - DiagnoseCustomer" API has been called.Each time the API runs, it sends information about the request made to this connector so that it can display certain information, such as how many requests per minute/hour were made.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**             | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | TV TD - DiagnoseCustomer (script) | \-                      |

## Configuration

### Connections

#### Virtual Connection

This connector uses a virtual connection and does not require any input during element creation.

## How to Use

This connector listens for incoming requests. When a request arrives, the connector will process the data.

You can reset all the counters by clicking the **Reset** button on the **General page**.
