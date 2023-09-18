---
uid: Connector_help_Nokia_ISAM_7300_FX_GPON_Platform
---

# Nokia ISAM 7300 FX GPON Platform

The Nokia ISAM 7300 FX GPON Platform connector uses an SNMP connection to communicate with Nokia ISAM 7300 FX devices. This data is then centralized within the connector and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range** | **Key Features**                                                                     | **Based on** | **System Impact** |
|-----------|--------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x   | \- Initial version. - Compatibility with Skyline EPM Solution.                       | \-           | \-                |
| 1.0.1.x   | \- Modified passive logic. Now it is compatible with routes, distributions and FATs. | 1.0.0.6      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                  | **Exported Components** |
|-----------|---------------------|-------------------------|--------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \- Skyline EPM Solution - Skyline EPM Platform GPON WM | \-                      |
| 1.0.1.x   | No                  | Yes                     | \- Skyline EPM Solution - Skyline EPM Platform GPON WM | \-                      |

## Configuration

### Connections

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string is used when reading values from the device (default: *public*).
- **Set community string**: The community string is used when setting values on the device (default: *private*).

### Initialization

The connector uses custom properties to configure the Network, Market, and Hub of the OLT. To link the views to the EPM data cards and full EPM functionality, make sure these properties are configured.

The EPM solution works with a file system for internal element communication in relation to the topologies. Because of this, when an element is created, the following parameters must be defined on the **Configuration** page:

- **Entity Export/Import Settings**: These sections allow the exporting of the configuration files and importing of the provisioning files.

  - **Export State** and **Import State**: These parameters allow you to enable/disable the exporting and importing feature.
  - **Export Directory,** **Entity Import Directory, and ONT Import Directory**: Specify the paths where the files will be exported and imported.
  - **Entity Export Directory Type,** **Entity Import Directory Type, and ONT Import Directory Type**: Specify whether the export/import paths are **local or remote**. Note that for the remote file handling to work, you must enter the credentials for the system in the **System Credentials** section and enter the path to the remote directories. The path must be shared/accessible, or this feature will not work.

- **System Credentials**: This section is to be used if the element is configured to a remote file location.

  - **System Username**: The username of the user that has access to the directory. If no domain is specified, the domain from the element's DMA location will be used.
  - **System Password**: The password of the user to access the remote directory.

### Redundancy

There is no redundancy defined.

## How to Use - Range 1.0.0.x

The OLT connectors are used as links in the EPM GPON solution chain. These represent the lower layer in the GPON topology, where the information of ONTs is retrieved to then be processed/aggregated by the upper layers. It is important to take into account that some of the ONT KPIs come from an external source (e.g. KAFKA). You therefore need to make sure communication with that source is functioning properly. In addition, the number of updates received determines the efficiency, so the more updates, the longer processing will take.

Another important thing is to set the **Reset ONT Interval** parameter (on the Configuration page) according to the retrieval speed of the information from the ONTs.

Once the initial setup is done, the connector can function without further configuration. However, you can perform the following actions on the **Configuration** page:

- **Entity Export Settings/Apply**: When you click this button, the element's topology files will be exported (configuration files). These files will be processed by the Skyline EPM Solution.
- **Entity Import Settings/Apply**: When you click this button, the element will import the topology files created by the Skyline EPM Solution (provisioning files). These new files are based on the files originally exported by the element.
- **SNMP Fast Interval**: Determines how often the information related to the status of the OLT will be polled. By default, the parameter is set to 15 minutes.
- **SNMP Slow Interval**: Determines how often the information related to the configuration of the OLT will be polled. By default, the parameter is set to 4 hours.
- **Virtual Interval**: Determines how often the topology will be synced with EPM. By default, the parameter is set to 2 hours.
- **ONT Interval**: Determines how often state data of the ONTs will be requested. This data can for example come from a KAFKA stream. Default value: 15 minutes.

  The performance of this feature can vary depending on the number of updates received in the system.

## How to Use - Range 1.0.1.x

In this range, the OLT is no longer responsible for information retrieval from the external source (e.g. KAFKA). The OLT Interval parameter has therefore been removed.

Another important difference with the previous range is related to the passive logic: Split information is now divided over three tables to allow a better understanding and segmentation of the data in the topology. The Split page now contains the **Split Route Overview**, **Split Distribution Overview** and **Split FAT** **Overview** tables.

## Notes

This connector requires specific Automation scripts for communication with auxiliary connectors such as the Skyline EPM Platform GPON WM and with the DataMiner EPM Solution.

With larger devices or large data sets, the polling performance may vary.
