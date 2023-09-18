---
uid: Connector_help_Harmonic_DMS
---

# Harmonic DMS

Harmonic's DMS video distribution management system provides broadcasters and content providers with powerful control tools over large populations of edge devices. It allows flexible device or group addressability, entitlements, and authorization management, as well as over-the-air (OTA) in-band control of Harmonic XOS in edge configuration.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 11.4.0.0               |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.
- **Device address**: The bus address of the device. If the proxy server has to be bypassed, specify *BypassProxy*.

### Initialization

When you have created the element, go to the **Login** page, and configure the **Username** and **Password** for polling to work.

### Redundancy

There is no redundancy defined.

## How to use

HTTP REST calls are used to retrieve all relevant information from the DMS. The **API Endpoint Status** page contains a table of all GET endpoints that are polled. **Refresh Frequency** determines how often that specific endpoint is polled. The **Status** determines if the endpoint should be polled or not. The **Refresh** button will automatically poll the endpoint.

The **Devices** table has a **Custom Description** column that will edit the **display key** of the following tables: the **Devices** table, all tables on the **Authorization** page, and the **Destination** table.

On the **Authorization** page, the **Allow Schedule Authorization** parameter will enable/disable schedule authorization sets on all **Authorization** tables.

On the **Alarms** page, the **Alarm Retrieval** parameter allows you to configure whether all alarms should be polled or only active alarms.
