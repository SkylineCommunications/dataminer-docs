---
uid: Connector_help_SeaChange_ProdIS
---

# SeaChange ProdIS

This driver will read the different messages placed in the provider's folder and move them to another folder. These messages will then be placed in a table.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This driver uses a virtual connection and does not require any input during element creation.

### Initialization

To configure this driver, on the **General** page, you must configure the proper **Path for ContentStore**, with the correct **Username, Password and Domain**. On this same page, the parameter **Search ContentStore** must be **enabled** in order to make it possible to search and display the needed assets and offers.

In addition, you must make sure that the Content Store is accessible via the server where DataMiner is installed.

### Redundancy

There is no redundancy defined.

## How to use

This driver contains the following pages:

- **General**: Contains login settings and the settings for the ProdIS. For more information, refer to the Configuration \> Initialization section above.
- **Assets Overview**: Contains the **Assets Overview** table, which displays information on the messages placed in the **folders** **Loader**, **Rejected** and **Failed.**
- **Offers Overview**: Contains the **Offers Overview** table, which displays information on the messages placed in the **folder** **Loaded\offering**.
- **Ingested Content**: Displays the **Contentstore** table.
