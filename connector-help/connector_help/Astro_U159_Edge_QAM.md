---
uid: Connector_help_Astro_U159_Edge_QAM
---

# Astro U159 Edge QAM

With this connector, it is possible to gather and view information from the device **Astro U159 Edge QAM**, as well to configure the device. The Astro U159 Edge QAM device is an IP-to-QAM signal converter.

## About

### Version Info

| **Range**            | **Key Features**           | **Based on** | **System Impact** |
|----------------------|----------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | IP-to-QAM signal converter | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 6420                   |

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

#### SNMP Extra Connection 2 Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

On the **General** page, click the **Login** page button and specify the **Username** and **Password**.

### Redundancy

There is no redundancy defined.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

The credentials of the device must be filled in on the Login page (General \> Login).

Some important parameters are available on the General page:

- **Controller Name**: This parameter shows the name of the **Astro Virtual Controller** element that manages this device. If no such element is used, the parameter will show the exception value *No Virtual Controller Found*.

- **Communication Type**:

  - *Direct Communication*: The element sends the requests directly to the Astro module device.
  - *U100C Proxy*: The element sends the requests to the Astro U100 Controller, which will forward them to the Astro module. The controller acts as a proxy.

- **Communication Method**:

  - *Login*: The element logs in to the device for every request (read and write requests).
  - *Anonymous*: The element only logs in to the device for write requests. The device does not log in for read requests.

To most tables a row/new entry can be added by right-clicking the table and selecting **Add New Entry**. This action will display a pop-up window with the required parameters to add a new entry.

Downloaded files can be found under *C:\Skyline DataMiner\Documents\\protocol name"\\element name"\\file name"*.
To upload a file, the file must be located in the following folder: *C:\Skyline DataMiner\Documents\\protocol name"\\element name"\\file name"*. The connector will display a list of available files in that location to upload.
