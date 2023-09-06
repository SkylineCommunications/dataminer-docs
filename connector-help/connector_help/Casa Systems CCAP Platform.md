---
uid: Connector_help_Casa_Systems_CCAP_Platform
---

# Casa Systems CCAP Platform

The Casa Systems CCAP Platform is an SNMP connector that collects relevant data from Casa Systems devices based on the DOCSIS standard. This data is centralized by the connector and used by DataMiner EPM.

## About

### Version Info

| **Range**            | **Key Features**                          | **Based on** | **System Impact** |
|----------------------|-------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                          | \-           | \-                |
| 1.0.1.x              | Modifications for compatibility with EPM. | \-           | \-                |
| 1.0.2.x              | Compatibility with new EPM Solution.      | \-           | \-                |
| 1.0.3.x              | Modifications to improve performance.     | \-           | \-                |
| 1.0.4.x \[SLC Main\] | Updated the minimum DataMiner version.    | \-           | \-                |
| 1.0.5.x              | Modifications to improve performance      | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | \-                     |
| 1.0.1.x   | \-                     |
| 1.0.2.x   | \-                     |
| 1.0.3.x   | \-                     |
| 1.0.4.x   | \-                     |
| 1.0.5.x   | \-                     |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.1.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.2.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.3.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.4.x   | Yes                 | Yes                     | \-                    | \-                      |
| 1.0.5.x   | Yes                 | Yes                     | \-                    | \-                      |

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

When you have created the element, configure the following settings:

- **Entity Export/Import Settings**: These sections allow the exporting of the configuration files and importing of the provisioning files.

- **Entity Export** and **Entity Import**: These parameters allow you to enable/disable the exporting and importing feature.
  - **Export Directory** and **Entity Import Directory**: It is necessary to specify the pathswhere the files should be exported and imported.
  - **Entity Export Directory Type** and **Entity Import Directory Type**: Specify whether the export/import paths are **local or remote**. Note that for the remote file handling to work, you must enter the credentials for the system in the System Credentials section and enter the path to the remote directory in the Export Directory or Import Directory parameter. The path must be shared/accessible, or this feature will not work.

<!-- -->

- **System Credentials**: This section is to be used if the element is configured to a remote file location.

- **System Username**: The username of the user that has access to the directory. If no domain is specified, the domain from the element's DMA location will be used.
  - **System Password**: The password of the user to access the remote directory.

In addition, in range **1.0.0.x and 1.0.1.x**, configure the following settings:

- **Other Settings**: Additional settings to ensure proper data transfer and additional information.

- **Collector**: Fill this out with the DMA ID/element ID of the Generic CM Collector used to provision the CMs of the CCAP.

### Redundancy

There is no redundancy defined.

## How to use

### Configuration

On the **Configuration** page, you can configure the following element functionality:

- In range **1.0.0.x and 1.0.1.x**:

- **Export Topology**: When you click the **Apply** button in the **Entity Export Settings** section, the element's topology files will be exported. These files will be processed by the Skyline EPM Solution.
  - **Import Topology**: When you click the **Apply** button in the **Entity Import Settings** section, the element will import the corresponding topology files created by the Skyline EPM Solution. These new files are based on the files originally exported by the Casa Systems CCAP Platform element.
  - **Topology Update Time Interval**: This parameter allows you to configure the frequency at which the topology files are automatically exported. This parameter is set to one hour by default.

<!-- -->

- In range **1.0.2.x**:

- **Export Topology**: When you click the **Apply** button in the **Entity Export Settings** section, the element's topology files will be exported. These files will be processed by the Skyline EPM Solution.
  - **Import Topology**: When you click the **Apply** button in the **Entity Import Settings** section, the element will import the corresponding topology files created by the Skyline EPM Solution. These new files are based on the files originally exported by the Casa Systems CCAP Platform element.
  - **SNMP Fast Interval**: Define how often the information related to the status of the CCAP should be polled. By default, the parameter is set to 15 minutes.
  - **SNMP Slow Interval**: Define how often the information related to the configuration of the CCAP should be polled. By default, the parameter is set to 4 hours.
  - **Virtual Interval**: Define how often the topology will be synced with EPM. By default, the parameter is set to 2 hours.

<!-- -->

- In range **1.0.4.x**:

- **Script Name**: Specify the Automation script to be executed.

## Notes

For range **1.0.0.x** and **1.0.1.x** of the connector, specific Correlation rules and Automation scripts are required for the communication with auxiliary connectors such as the Generic CM Collector and with EPM connectors such as Skyline Platform EPM and Skyline Platform WM. To get the full functionality of this connector, make sure these Correlation rules and Automation scripts are configured and enabled. In range **1.0.2.x**, the Correlation rules are no longer required.

With larger devices or large data sets, the polling performance may vary.

In range **1.0.3.x** of the connector, the multi-threaded timer previously used to poll the DOCSIS version of each CM is removed. As a consequence, the DOCSIS version column is removed from the Cable Modems table. The versions are now polled solely by the Generic CM Collector connector.
