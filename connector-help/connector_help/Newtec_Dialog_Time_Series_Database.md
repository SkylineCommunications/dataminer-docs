---
uid: Connector_help_Newtec_Dialog_Time_Series_Database
---

# Newtec Dialog Time Series Database

The Newtec Dialog Time Series Database connector collects and organizes data from a Newtec Dialog platform that stores its metrics in a Time Series Database (TSDB, i.e. Influx DB).

## About

The Newtec Dialog monitoring system collects metrics from the Newtec dialog platform and stores them in a Time Series database. The connector retrieves data from the Newtec Dialog Platform via its **REST API** and via the **TSDB API**. Data from both sources is aggregated into the connector.

The connector uses the following APIs:

- Newtec Dialog Restful Standard API (Central Dialog NMS): Configuration data of the Dialog system is retrieved using this API.
- Newtec Dialog TSDB API (Hub Gateway Database): Statistics, metrics of terminals, and Sat Networks are retrieved using the Time Series Database API.
- Newtec Dialog Mobility API: This API is used to track terminals moving from one beam to another.

The connector collects the following metrics:

- Satnet-specific metrics, grouped into forward and return metrics.
- Modem-specific metrics.

This connector exports different types of DVEs, representing modems, network (forward), and network (return). Creation of DVEs can be enabled or disabled in the main element. The connector typically connects to a central NMS that monitors several dialog hubs.

### Version Info

| **Range**            | **Description**                                                        | **DCF Integration** | **Cassandra Compliant** |
|----------------------|------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version                                                        | No                  | Yes                     |
| 1.0.1.x \[Obsolete\] | Connector DVE structure changed.                                       | No                  | Yes                     |
| 1.0.2.x \[SLC Main\] | Added SNMP connection. New connection has to be configured on startup. | No                  | Yes                     |

### Product Info

| **Range**            | **Supported Firmware** |
|----------------------|------------------------|
| 1.0.0.x \[Obsolete\] | 2.2.1, 2.2.2           |
| 1.0.1.x \[Obsolete\] | 2.2.1, 2.2.2           |
| 1.0.2.x \[SLC Main\] | 2.2.1, 2.2.2           |

### Exported connectors

#### Range 1.0.0.x

| **Exported Connector**                                                                                                                         | **Description**                                                               |
|------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------|
| [Newtec Dialog Time Series Database - Remotes](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Remotes)                   | Represents modem/terminal components.                                         |
| [Newtec Dialog Time Series Database - Network Forward](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Network_Forward) | Represents network components in the forward direction (VSAT HUB to Terminal) |
| [Newtec Dialog Time Series Database - Network Return](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Network_Return)   | Represents network components in the return direction (Terminal to VSAT HUB)  |

#### Range 1.0.1.x

| **Exported Connector**                                                                                                        | **Description**                       |
|------------------------------------------------------------------------------------------------------------------------------|---------------------------------------|
| [Newtec Dialog Time Series Database - Remotes](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Remotes) | Represents modem/terminal components. |
| [Newtec Dialog Time Series Database - Network](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Network) | Represents network components.        |

#### Range 1.0.2.x

| **Exported Connector**                                                                                                        | **Description**                       |
|------------------------------------------------------------------------------------------------------------------------------|---------------------------------------|
| [Newtec Dialog Time Series Database - Remotes](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Remotes) | Represents modem/terminal components. |
| [Newtec Dialog Time Series Database - Network](xref:Connector_help_Newtec_Dialog_Time_Series_Database_-_Network) | Represents network components.        |

## Configuration

### Connections

This connector uses three HTTP connections.

#### HTTP Connection 1, 2 & 3

These are used to communicate with the Newtec Dialog Restful Standard API. The following input is required during element creation:

- **IP address/host**: The IP of the Newtec Central NMS.
- **IP port:** *80* (default connection 1) & *8086* (default connection 2 & 3)
- **Device address**: *BypassProxy*

### Configuration of Main and Backup CNMS

Additional settings need to be filled in on the **Standard API Polling** page if a main and backup CNMS are present. On this page, the IP and port of the main and backup should be configured, and polling can be enabled to either main or backup. The IP addresses specified in the element editor will then not matter.

Note: If there is only one CNMS, it is enough to simply configure the HTTP connections above only.

- **Polling IP format**: 10.0.0.1:80

### TSDB configuration

All TSDBs that need to be polled need to be added to the **Database Configuration** table on the **TSDB Polling** page.

## How to use

Below you can find more information on how to use the most important pages of the connector.

### General page

On this page, you can configure and apply the **credentials** for user authentication of the REST API in order to collect data from the Dialog platform.

### Standard API Polling page

On this page, you can:

- **Enable** **polling** of the restful API.
- **Configure** the main and backup **CNMS IP address and port**.
- **Switch** **polling** between the main and backup CNMS.

### TSDB Polling page

On this page, you can:

- **Enable** or disable TSDB **polling**.
- **Configure** **TSDB database details** to be polled in the Database Configuration table.
- **Configure the timespan** of the queries sent to the databases for each measurement.

### TSDB page

This page displays three tables that contain important information about each remote, forward satellite network and return satellite network. For each row in the tables, a DVE can be created with all relevant information.

The following settings are also available:

- **Auto enable DVEs**: When this is enabled, if the connector detects a new remote or network, a new DVE element will automatically be created
- **Auto Delete DVEs**: When this is enabled, if a remote or network is deactivated or removed, the corresponding DVE element will automatically be deleted in DataMiner. When this is disabled, you can delete the DVE manually by clicking the **Delete** button in the table.

### Remotes TSDB page

This page displays tables with information about each remote. All the information is available in the "Remotes" DVE.

### Forward Link TSDB page (range 1.0.0.x)

This page displays tables with information about each forward link. All the information is available in the "Network Forward" DVE.

### Return Link TSDB page (range 1.0.0.x)

This page displays tables with information about each return link. All the information is available in the "Network Return" DVE.

### Networks TSDB page (range 1.0.1.x)

This page displays tables with information about each satellite network/beam.

The page contains several tables with info regarding the forward and return links statistics.

## Notes

### Connector flow

The connector is designed around the TSDB as the "master" source of data of remotes and networks. Data from the Dialog API is used to fetch static configuration data of remotes and networks to build the full information.
For example, a terminal is retrieved from the TSDB and then all associated mapping data is fetched from the Dialog API (like terminal name, MAC address, etc.). All stats and metrics are retrieved from the TSDB.
