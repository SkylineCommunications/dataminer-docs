---
uid: Connector_help_Generic_sFlow_Monitor
---

# Generic sFlow Monitor

The Generic sFlow Monitor is used to monitor the persistent sFlows handled by the Generic sFlow Manager.

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

On the **General** page, the **Missing Flows Table** shows the missing flows filters. Each row is an individual filter that checks the Elasticsearch database for missing flows matching its filter data.

- The **Count** column shows the number of flows found matching the filter request.
- The **Details** column allows you to view the top 50 matching flows received in the filter request in the Missing Flows Details Table.

Click the **Add Missing Flow Filter** button to open a page with the filter properties:

- Both the **Condition Name** and **Amount of Time** parameters must be filled in.
- Add \* to the start and/or end of the filter parameter value to specify that the value can have a possible prefix and/or suffix, respectively. This indicates that a wildcard is used for the filter parameter.
