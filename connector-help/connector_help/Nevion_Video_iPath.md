---
uid: Connector_help_Nevion_Video_iPath
---

# Nevion Video iPath

The Nevion Video iPath is a management platform for managing media networks and the services that run on them. Its key functionalities rely on monitoring of services and network resources, including alarm management.

This connector is used to retrieve all data information from the Nevion Video iPath network suite using HTTP. It allows deep monitoring not only of the device configuration, but also of its entire operation and real-time alarms.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                         | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                                                                         | No                  | Yes                     |
| 1.1.0.x              | New firmware.                                                                                                                                                                                                                                                            | No                  | Yes                     |
| 1.2.0.x \[Obsolete\] | New firmware.                                                                                                                                                                                                                                                            | No                  | Yes                     |
| 1.2.1.x \[Obsolete\] | Improved performance.                                                                                                                                                                                                                                                    | No                  | Yes                     |
| 1.2.2.x \[Obsolete\] | Removed Delete button.                                                                                                                                                                                                                                                   | No                  | Yes                     |
| 1.2.3.x \[Obsolete\] | Endpoints table now uses the partial option to accommodate bigger data influx.                                                                                                                                                                                           | No                  | Yes                     |
| 1.2.4.x \[Obsolete\] | \- Added time zone configuration. - Ensured that history sets work again.                                                                                                                                                                                                | No                  | Yes                     |
| 1.2.5.x \[Obsolete\] | Corrected Endpoints table to reflect the correct column names for Descriptor Description, Descriptor Label and FDescriptor Label data.                                                                                                                                   | No                  | Yes                     |
| 1.2.6.x              | InterApp communication upgraded on QAction 9000000. All external integrations that communicate with this connector will need to upgrade their own InterApp communication. Following methods need to be upgraded: - Message.Send(); - InterAppCallFactory.CreateFromRaw() | No                  | Yes                     |
| 1.2.7.x \[Obsolete\] | InterApp code moved to NuGets. Minimum required DataMiner version: 10.0.10.x                                                                                                                                                                                             | No                  | Yes                     |
| 1.2.8.x \[SLC Main\] | Performance improvements. General code review fixes.                                                                                                                                                                                                                     | No                  | Yes                     |

### Product Info

| **Range** | **Supported Firmware**                        |
|-----------|-----------------------------------------------|
| 1.0.0.x   | 3.6.1                                         |
| 1.1.0.x   | API 5 (not compatible with previous versions) |
| 1.2.0.x   | 5.12.4                                        |
| 1.2.1.x   | 5.12.4                                        |
| 1.2.2.x   | 5.12.4                                        |
| 1.2.3.x   | 5.12.4                                        |
| 1.2.4.x   | 5.12.4                                        |
| 1.2.5.x   | 5.12.4                                        |
| 1.2.6.x   | 5.12.4                                        |
| 1.2.7.x   | 5.12.4                                        |
| 1.2.8.x   | 5.12.4                                        |

## Configuration

### Connections

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address**: The polling IP or URL of the destination.
- **IP Port**: The IP port of the destination, by default *80*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy*.

### Initialization

When the element has been created, on the **General** page, specify the **Username** and **Password** to connect to the device, and click the **Login** button. On this same page, the connection status is displayed in real time.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to use

Depending on the version of the connector, it can consist of the data pages detailed below.

### General

On this page, you can specify the device access credentials. It also displays general system information.

From version 1.1.0.x onwards, a **Polling Config** page button is available that allows you to control the polling times.

### Connect (v.1.2.0.x)

This page displays the **Source** and **Destination** tables.

### Current Services (v1.2.0.x)

This page contains the **Current Services** table, with data collected from connection and service alarm databases. It displays the active connections, including the alarm status for each connection.

### Alarms

This page contains an endpoint tree view of alarms for each device. It displays the **Alarm Severity**, **Alarm Name**, **Device IP**, and **Alarm Card** parameters.

Via the **Current Alarms Time Zone Configuration**, you can change the time zone for the alarm data. This determines how the time information for the alarms is displayed in the alarms table. Changing this configuration will also affect the timing of the alarms generated for this connector in the Alarm Console.

### Endpoints (v1.2.0.x)

This page contains the **Endpoint Table**, which displays the connection and alarm status for each endpoint, along with its **Severity**, **Card**, **Device Name**, **number of alarms**, and more.

### Edges (v1.2.1.x)

This page contains the **Edges Table**, which shows the device route used by each service. **Hop**, **Tag**, **From ID**, and **To ID** are shown in the table, among others.

### Devices per Service (v1.2.1.x)

This page contains the **Devices per Service Table**, which lists all devices used by each service.

### Endpoints per Device (v1.2.3.x)

This page contains the **Endpoints per Device tree view**, which groups all endpoints used by each device.

### Debug (v1.2.0.x)

This page summarizes the Delta and Alarms state.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to able to access the device, as otherwise it will not be possible to open the web interface.

## Notes

**API 5** is not compatible with previous versions. Some features are currently not supported on this version because of API documentation constraints. To be more specific, it is not possible in this version to create a new service between the source and destination on the **Connect** page, and the **Service History** and **Endpoint Alarms** page are not available.

In order to improve performance, some columns and properties from the Current Alarms Table were removed in later versions.

- Removed columns: Equipment ID, Root Cause Counter, Root Cause Services, Device Time, Clean Service Name.
- Removed alarm properties: CleanServiceName, DeviceTime, EquipTypeId, ServiceName, RootCauseCounter, RootCauseService.
