---
uid: Connector_help_NBCU_SkyPath_Site_Manager
---

# NBCU SkyPath Site Manager

The NBCU SkyPath Site Manager manages 4 SFPs to gather flow data and execute switches.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**             |
|-----------|------------------------------------|
| 1.0.0.x   | Decapsulator 2.3.957 and 3.10.4447 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection - SFP 1

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

#### HTTP Connection - SFP 2

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

#### HTTP Connection - SFP 3

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

#### HTTP Connection - SFP 4

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).

### Initialization

On the **Flow Templates** page, fill in the **DataMiner ID/Element ID** of the remote element that holds the data to facilitate switching of the site.

### Redundancy

There is no redundancy defined.

## How to use

The connector will automatically poll the 4 SFPs defined in the element connections and fill the **SFP** table on the **General** page.

On that page, you can define the **Site Type** and **Site Mode**. If you change the **Site Mode**, the flows and networks associated with the SFPs will be changed to the selection.
