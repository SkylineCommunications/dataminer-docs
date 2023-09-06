---
uid: Connector_help_Tata_Sky_India_Limited_MCR_DB_Provision
---

# Tata Sky India Limited MCR DB Provision

This connector is designed to poll a database containing channel information, and to generate, update, or delete DataMiner services based on this information and on the configured service template.

## About

### Version Info

| **Range**            | **Key Features**                                                              | **Based on** | **System Impact**                                                                                                                                                                                                                                                                 |
|----------------------|-------------------------------------------------------------------------------|--------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x \[obsolete\] | Generates/updates a DataMiner service with the retrieved channel information. | \-           | \-                                                                                                                                                                                                                                                                                |
| 1.0.1.x \[SLC Main\] | DataMiner services generation updated.Error table messages improved.          | 1.0.0.1      | \- Exception value on column (param 1011) was updated. Column was changed from string to int (param 1004), and low range was added.- Parameters 102/152, 103/153, 110/160 were moved to a subpage.- Page button parameter name got renumbered and renamed (parameter 153 -\> 50). |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.0.1.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (default: *80*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

## How to use

The element's data pages are organized as follows:

- **General page**: Allows you to select the service template and Visio drawing to be used when a new view is generated. Note that this connector was designed with the "Channel Template" in mind. As such, when you change the template, you must ensure that all the necessary information is present in the template and that the template will not request additional information.
- **Services page**: Displays all information retrieved from the database in table format. On this page, you can also enable/disable the automation functionality for managing services, or manually manage (generate, update, delete) services.
- **Error Log subpage**: Displays a table with the errors encountered when parsing the retrieved information, and when generating, updating, or deleting a service.
