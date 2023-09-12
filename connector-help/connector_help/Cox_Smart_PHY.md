---
uid: Connector_help_Cox_Smart_PHY
---

# COX Smart PHY

COX Smart PHY communicates with COX's Smart PHY Apigee API to gather auxiliary data involving RPDs to be assigned to CCAPs.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *30604*).

## How to use

The API connection requires the definition of the **Username** and **Password** on the **Configuration** page.

If these have been correctly filled in, the connector will poll the information and fill in the tables.

The data is also exported to a path defined in the **Export Path** parameter.
