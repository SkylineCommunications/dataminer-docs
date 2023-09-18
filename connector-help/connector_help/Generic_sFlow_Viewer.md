---
uid: Connector_help_Generic_sFlow_Viewer
---

# Generic sFlow Viewer

The Generic sFlow Viewer is used to view the persistent sFlow logs created by the Generic sFlow Manager.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

#### HTTP Connection

This connector uses an HTTP connection to establish a connection with an **Elasticsearch database**.

## How to use

On the **General** page, the **Flow Logs Table** shows the persistent flow logs.

The **Poll** **button** obtains the persistent flow logs based on the filters and the information filled in in the **Flow Logs Table**.

Click the **Filters button** to open a page with the filter properties.

- Add \* to the start and/or end of the filter parameter value to specify that the value can have a possible prefix and/or suffix, respectively. This indicates that a wildcard is used for the filter parameter.
- The **Poll** **button** behaves the same way as the Poll button on the **General page**.
