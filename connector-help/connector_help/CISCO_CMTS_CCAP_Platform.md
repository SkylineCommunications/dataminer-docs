---
uid: Connector_help_CISCO_CMTS_CCAP_Platform
---

# CISCO CMTS CCAP Platform

The CISCO CMTS CCAP Platform is an **SNMP** connector that collects relevant data from **CISCO CMTS devices** based on the **DOCSIS** standard. This data is then centralized within the connector and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range** | **Key Features**                      | **Based on** | **System Impact** |
|-----------|---------------------------------------|--------------|-------------------|
| 1.0.0.x   | Initial version.                      | \-           | \-                |
| 1.0.1.x   | \-                                    | \-           |                   |
| 1.0.2.x   | Modifications to improve performance. | \-           | \-                |
| 1.0.3.x   | Added parameters to CCAP tables.      | \-           | \-                |
| 1.0.4.x   | Modifications to improve performance. | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 12.2(33)SCJ1           |
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

#### SNMP Main Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination (161 by default).

SNMP Settings:

- **Get community string**: The community string used when reading values from the device. (default: *public*)
- **Set community string**: The community string used when setting values on the device. (default: *private*)

### Initialization

The connector uses custom properties to configure the Network, Market, and Hub of the CCAP, so make sure that these are configured to link the views to the EPM data cards and full EPM functionality.

When the element has been created, you can configure the following settings:

- **Entity Export/Import Settings**: These settings allow the exporting of the configuration files and the importing of the provisioning files.

- **Entity Export** and **Entity Import**: Allows you to enable or disable the exporting and importing feature.
  - **Export Directory** and **Entity Import Directory**: Use these settings to specify the paths where the files should be exported and imported.
  - **Entity Export Directory Type** and **Entity Import Directory Type**: Specify whether the export/import paths are **local or remote**. Note that for the remote file handling to work, you must enter the credentials for the system in the System Credentials section and enter the path to the remote directory in the Entity Export or Import Directory parameter. The path must be shared/accessible, or this feature will not work.
  - **Apply Button**: Start the export or import by clicking this button.

<!-- -->

- **System Credentials**: This section is to be used if the element is configured to a remote file location.

- **System Username**: The username of the user that has access to the directory. If no domain is specified, then the domain of the element's DMA will be used.
  - **System Password**: The password of the user to access the remote directory.

<!-- -->

- **Other Settings**: Additional settings to ensure proper data transfer and additional information.

- **Collector**: Fill this out with the DMA ID/element ID of the Generic CM Collector used to provision the CMs of the CCAP.

## How to use

The connector is mostly self-reliant once the initial setup is done, but you can perform the following actions on the **Configuration** page:

- **Export Topology**: When you click the **Apply** button in the **Entity Export Settings** section, the element's topology files will be exported. These files will be processed by the Skyline EPM Solution.
- **Import Topology**: When you click the **Apply** button in the **Entity Import Settings** section, the element will import the corresponding topology files created by the Skyline EPM Solution. These new files are based on the files originally exported by the CISCO CMTS CCAP Platform element.
- **Topology Update Time Interval**: This parameter allows you to configure the frequency at which the topology files are exported automatically. By default, this is set to one hour.

<!-- -->

- In range **1.0.3.x**:

- **Script Name**: Specify the Automation script to be executed.

## Notes

This connector requires specific Correlation rules and Automation scripts for communication with auxiliary connectors such as the Generic CM Collector and EPM connectors such as Skyline Platform EPM and Skyline Platform WM. The Correlation rules and Automation scripts must be configured and enabled to get the full functionality of this connector.

For range **1.0.2.x** of the connector, the multi-threaded timer, previously used to poll the DOCSIS version of each cable modem, was removed. As a consequence of this change, the DOCSIS version column was removed from the Cable Modems table. The versions are now polled solely by the Generic CM Collector connector.
