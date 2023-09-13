---
uid: Connector_help_Huawei_5688-5800_CCAP_Platform
---

# Huawei 5688-5800 CCAP Platform

The Huawei 5688-5800 CCAP Platform is designed to support integrated-access architectures, DOCSIS 3.0 and 3.1, all video types, and software-defined networking.

This connector allows you to collect data from the Huawei 5688-5800 CCAP Platform along with complementary data from auxiliary connectors, e.g. the Generic CM Collector. This data is then centralized within the connector and used by DataMiner EPM for aggregation actions.

## About

### Version Info

| **Range**            | **Key Features**                      | **Based on** | **System Impact** |
|----------------------|---------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                      | \-           | \-                |
| 1.0.1.x              | Compatibility with new EPM Solution.  | \-           | \-                |
| 1.0.2.x              | Modifications to improve performance. | \-           | \-                |
| 1.0.3.x              | Updated the minimum DMA version.      | \-           | \-                |
| 1.0.4.x              | Modifications to improve performance. | \-           | \-                |
| 1.0.5.x \[SLC Main\] | SDF implementation.                   | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 0141                   |
| 1.0.1.x   | 0141                   |
| 1.0.2.x   | 0141                   |
| 1.0.2.x   | 0141                   |
| 1.0.4.x   | 0141                   |
| 1.0.5.x   | 0141                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.5.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: The IP port of the destination.

SNMP Settings:

- **Get community string**: The community string used when reading values from the device (default: *public*).
- **Set community string**: The community string used when setting values on the device (default: *private*).

### Initialization

The connector uses custom properties to configure the Network, Market, and Hub of the CCAP, so ensure that these are configured to link the views to the EPM data cards and full EPM functionality.

When you have created the element, configure the following settings:

- **Entity Export/Import Settings**: These sections allow the exporting of the configuration files and importing of the provisioning files.

  - **Entity Export** and **Entity Import**: These parameters allow you to enable/disable the exporting and importing feature.
  - **Export Directory** and **Entity Import Directory**: It is necessary to specify the paths where the files will be exported and imported.
  - **Entity Export Directory Type** and **Entity Import Directory Type**: Specify whether the export/import paths are **local or remote**. Note that for the remote file handling to work, you must enter the credentials for the system in the System Credentials section and enter the path to the remote directory in the Export Directory or Import Directory parameter. The path must be shared/accessible, or this feature will not work.

- **System Credentials**: This section is to be used if the element is configured to a remote file location.

  - **System Username**: The username of the user that has access to the directory. If no domain is specified, the domain from the element's DMA location will be used.
  - **System Password**: The password of the user to access the remote directory.

In range **1.0.0.x**, also configure the following settings:

- **Other Settings:** Additional settings to ensure proper data transfer and additional information.

- **Collector:** Fill this out with the DMA ID/element ID of the Generic CM Collector used to provision the CMs of the CCAP.

## How to use

Once the initial setup is done, the connector can function without further configuration. However, you can perform the following actions on the **Configuration** page:

- In range **1.0.0.x**:

  - **Export Topology**: When you click the **Apply** button in the **Entity Export Settings** section, the element's topology files will be exported. These files will be processed by the Skyline EPM Solution.
  - **Import Topology**: When you click the **Apply** button in the **Entity Import Settings** section, the element will import the corresponding topology files created by the Skyline EPM Solution. These new files are based on the files originally exported by the CISCO CBR-8 CCAP Platform element.
  - **Topology Update Time Interval**: This parameter allows you to configure the frequency at which the topology files are automatically exported. This parameter is set to one hour by default.

- In range **1.0.1.x**:

  - **Export Topology**: When you click the **Apply** button in the **Entity Export Settings** section, the element's topology files will be exported. These files will be processed by the Skyline EPM Solution.
  - **Import Topology**: When you click the **Apply** button in the **Entity** **Import Settings** section, the element will import the corresponding topology files created by the Skyline EPM Solution. These new files are based on the files originally exported by the CISCO CBR-8 CCAP Platform element.
  - **SNMP Fast Interval**: Define how often the information related to the status of the CCAP should be polled. By default, the parameter is set to 15 minutes.
  - **SNMP Slow Interval**: Define how often the information related to the configuration of the CCAP should be polled. By default, the parameter is set to 4 hours.
  - **Virtual Interval**: Define how often the topology will be synced with EPM. By default, the parameter is set to 2 hours.

- In range **1.0.3.x**, the **Script Name** parameter is added, which allows you to specify the Automation script to be executed.

## Notes

For range **1.0.0.x** of the connector, specific Correlation rules and Automation scripts are required for communication with auxiliary connectors such as the Generic CM Collector and Skyline Platform EPM Solution. The Correlation rules and Automation scripts must be configured and enabled to get the full functionality of this connector:

- Correlation rule **CcapOltToFe**: The parameter description (by protocol) must be set to **Huawei 5688-5800 CCAP Platform** parameter **Epm On Request**. The rule must **accept information events** and run the Automation script **CcapOltToFe**.
- Correlation rule **CcapToCollector**: The parameter description (by protocol) must be set to **Huawei 5688-5800 CCAP Platform** parameter **QAM Collector Ready**. The rule must **accept information events** and run the Automation script **CcapToCollector**.

In range **1.0.1.x**, the Correlation rules are no longer required.

With larger devices/data sets, the polling performance may vary. You can control the number of rows and cells requested for larger tables by navigating to the **Configuration** page and enabling the **Debug** page in the **Other Settings** section. This will make the Debug page visible, where you can then change SNMP **Cell Amount** and **SNMP Row Amount** to a value that works optimally for your system. Increasing these values can cause polling issues such as RTEs and missing data, so be careful and always double-check to make sure the system is stable.
