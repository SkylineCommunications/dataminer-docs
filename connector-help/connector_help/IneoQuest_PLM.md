---
uid: Connector_help_IneoQuest_PLM
---

# IneoQuest PLM

This is an HTTP connector that will monitor and control the **Program Line-Up Manager device**. It allows you to configure a new line-up, associate the necessary probes, and download the configuration files for the associated probes.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | PLM-2.05.02.017        |

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
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

On the **Configuration** page, specify the **User Name** and **Password** to have access to the device.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

To **log in**, specify the username and password on the **Configuration** page.

To **add or delete table entries**, right-click a table entry and select the desire option. If an "Add" window is displayed, fill in all parameters in that window.

To **export alias files**, specify the directory and the file name for the export, and then select the line-up for which you want to export the alias file.

To **import alias** files, specify the directory and the file name of the file (\*.xls format) you want to import, select the file, and fill in the line-up details. If you specify a new name for the line-up, a new line-up will be added. If you specify an existing name, you can choose to overwrite the existing line-up with the one you are importing.
