---
uid: Connector_help_Arris_E6000_CCAP_Platform
---

# Arris E6000 CCAP Platform

The Arris E6000 CCAP Platform is designed to support integrated-access architectures, DOCSIS 3.0 and 3.1, all video types, and software-defined networking.

This connector allows you to collect data from the Arris E6000 CCAP Platform along with complementary data from auxiliary connectors, e.g. the Generic CM Collector. This data is then centralized within the connector and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range**            | **Key Features**                          | **Based on** | **System Impact** |
|----------------------|-------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                          | \-           | \-                |
| 1.0.1.x              | Modifications for compatibility with EPM. | \-           | \-                |
| 1.0.2.x              | Modifications to improve performance.     | \-           | \-                |
| 1.0.3.x \[SLC Main\] | Updated the minimum DataMiner version.    | \-           | \-                |
| 1.0.4.x              | Modifications to improve performance      | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | CER_V04.05.00.0015     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination. **Default port: 161.**
- **Bus address**: The bus address of the device.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

The connector uses custom properties to configure the Network, Market, and Hub of the CCAP, so ensure that these are configured to link the views to the EPM data cards and full EPM functionality.

### Redundancy

There is no redundancy defined.

## How to use

There are a couple of settings on the Configuration page that need to be looked over on startup.

In range **1.0.0.x**:

- **Entity Export/Import Settings**: These sections allow the exporting of configuration files and importing of provisioning files. You can:

- **Enable or disable** the exporting and importing feature with toggle buttons (Entity Export and Entity Import, respectively).
  - Specify the **file paths** where files can be exported and imported (with the Entity Export Directory and Entity Import Directory, respectively).
  - Specify whether to export/import to/from a **local or remote** location via a toggle button (Entity Export Directory Type and Entity Import Directory Type, respectively). Note that for the remote file handling to work, you must enter the credentials for the system in the System Credentials section and enter the path to the remote directory in the Entity Export or Import Directory parameter. The path must be shared/accessible, or this feature will not work.
  - Start the export or import by clicking the **Apply** button in the relevant section.

<!-- -->

- **System Credentials**: This section is to be used if the element is configured to use a remote location for file import/export.

- **System Username**: The username of the user that has access to the directory. If no domain is specified, the domain from the element's DMA location will be used.
  - **System Password**: The password of the user to access the remote directory.

<!-- -->

- **Other Settings**: Additional settings to ensure proper data transfer and additional information.

- **Collector:** Fill this out with the DMA ID/element ID of the Generic CM Collector used to provision the CMs of the CCAP.

In range **1.0.1.x**:

- **System Credentials**: This section is to be used if the element is configured to use a remote location for file import/export.

- **System Username**: The username of the user that has access to the directory. If no domain is specified, the domain from the element's DMA location will be used.
  - **System Password**: The password of the user to access the remote directory.

<!-- -->

- **Export Topology**: When you click the **Apply** button in the **Entity Export Settings** section, the element's topology files will be exported. These files will be processed by the Skyline EPM Solution.
- **Import Topology**: When you click the **Apply** button in the **Entity Import Settings** section, the element will import the corresponding topology files created by the Skyline EPM Solution. These new files are based on the files originally exported by the Casa Systems CCAP Platform element.
- **SNMP Fast Interval**: Define how often the information related to the status of the CCAP should be polled. By default, the parameter is set to 15 minutes.
- **SNMP Slow Interval**: Define how often the information related to the configuration of the CCAP should be polled. By default, the parameter is set to 4 hours.
- **Virtual Interval**: Define how often the topology will be synced with EPM. By default, the parameter is set to 2 hours.

In range **1.0.3.x**:

- **Script Name**: Specify the Automation script to be executed.

## Notes

For range **1.0.0.x** of the connector, specific Correlation rules and Automation scripts are required for communication with auxiliary connectors such as the Generic CM Collector and EPM connectors such as Skyline Platform EPM and Skyline Platform WM. The Correlation rules and Automation scripts must be configured and enabled to get the full functionality of this connector. In range **1.0.1.x**, the Correlation rules are no longer required.

With larger devices/data sets, the polling performance may vary. You can control the number of rows and cells requested for larger tables by navigating to the **Configuration** page and enabling debug in the **Other Settings** section. This will make the Debug page visible, where you can then change SNMP Cell Amount and SNMP Row Amount to a value that works optimally for your system. Increasing these values can cause polling issues such as RTEs and missing data, so be careful and always double-check to make sure the system is stable.

In range **1.0.2.x** of the connector, the multi-threaded timer previously used to poll the DOCSIS version of each CM is removed. As a consequence, the DOCSIS version column is removed from the Cable Modems table. The versions are now polled solely by the Generic CM Collector connector.
