---
uid: Connector_help_OpenDrives_Storage
---

# OpenDrives Storage

The **OpenDrives Storage** driver shows the relevant information of an OpenDrives device, such as system information, sensor status information, pools and interfaces. It also contains monitoring data related to the device fan speed, voltage and temperature. The **OpenDrives Atlas Platform** provides features related to the device performance and data integrity and has centralized data without modulation.

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

#### HTTP Main Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When the element has been created, fill in the **User** and **Password** parameters on the **Credentials** page. The connector will only be able to retrieve data from the device after this has been done and the **Connection Status** parameter indicates *OK*.

### Redundancy

There is no redundancy defined.

## How to use

This driver uses **HTTP** communication and only retrieves device data. The unique POST is to authenticate with the credentials.

It has the following data pages:

- The **General** page, containing system information (name, uptime, memory, etc.).
- The **Pools** page, with a table listing device pools.
- The **Devices** page, containing a table with the registered devices on the OpenDrives device.
- The **HA** page, with high availability information.
- The **Services** page, which contains a table with each service and the status of each one.
- The **Health Sensors** page, containing three tables with sensor data and status information.
