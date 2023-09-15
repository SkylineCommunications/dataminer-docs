---
uid: Connector_help_Elastic_Calicux
---

# Elastic Calicux

Elastic Calicux receives and displays information from the Calicux framework, monitoring several KPIs in different dimensions.

### Version Info

| **Range** | **Key Features** | **Based on** | **System Impact** |
|-----------|------------------|--------------|-------------------|
| 1.0.0.x   | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 7.9.x                  |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - 0

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: https://calicux-api.service-insights.com
- **IP port**: 9202
- **Device address**: *BypassProxy*

### Initialization

When the element has been created, go to the **General** page and specify the **API Key**.

## How to use

On the **General** page, you can specify the **API Key**, which is necessary for the connector to be able to retrieve information.

A **Dimension** page is available for each available information dimension:

- **Geographic Area**
- **OLT**
- **SWD**
- **RAGG/SWC**
- **Channel**
- **Channel (Reprise)**
- **Error Code**
- **Service Type**
- **Service**
- **Metadata**

Each of these pages contains tables with more information related to that specific dimension. On the **Metadata** page, there is also an **Entry Limit** parameter, which determines the maximum number of entries allowed in the Metadata Metrics Table.
