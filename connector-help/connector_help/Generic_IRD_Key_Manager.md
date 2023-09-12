---
uid: Connector_help_Generic_IRD_Key_Manager
---

# Generic IRD Key Manager

This connector is used to upload key files to elements running an Ericsson RX8200 connector.

## About

### Version Info

| **Range** | **Key Features**             | **Based on** | **System Impact** |
|-----------|------------------------------|--------------|-------------------|
| 1.0.0.x   | Uploading key files to IRDs. | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

## How to use

### General

This page contains the **IRD Key Encryption Upload Table**, a list with all available elements that are running the Ericsson RX8200 connector. This list is continuously updated and can also be manually refreshed with the Refresh List button.

Uploading key files can be done for each element separately or for all of them at once. Elements can be excluded from this process with the **Include/Exclude Element** toggle button.

On the **Config** subpage, you can set the directory and file to select the key file on the devices. You can also select to automatically apply the most recent file that is available in the directory.
