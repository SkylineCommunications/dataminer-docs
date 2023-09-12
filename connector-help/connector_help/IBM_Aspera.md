---
uid: Connector_help_IBM_Aspera
---

# IBM Aspera

IBM Aspera provides a fast alternative to FTP server software for reliable and secure file transfer and delivery.

## About

### Version Info

| **Range**            | **Key Features**                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                       | \-           | \-                |
| 1.0.1.x \[SLC Main\] | File name column, file table display key changes, transfer loss table. | 1.0.0.3      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 3.9.1.168954           |
| 1.0.1.x   | 3.9.1.168954           |

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
- **IP port**: The IP port of the destination (default: *9092*).
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

To connect to the API, on the **Security** page, you must specify a valid **Username** and **Password**.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

After you have specified a valid username and password on the Security page, this connector will allow you to monitor the general and system information for your IBM Aspera, as well as the available capabilities.

You will also be able to see the latest transfers and files you have downloaded or uploaded, the status, bitrate, and percentage completed, and much more.

The element contains a tree control with the Path Parent Folders and also the file names for each folder. In there you can check how many transfers have started, how many have been completed successfully, and how many have failed. For each file name in the folder, you can see how many transfer attempts have been made and also how many have failed or have been completed successfully.

There is also a list of events generated for each transfer.
