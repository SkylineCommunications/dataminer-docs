---
uid: Connector_help_Cox_HP_Network_Automation
---

# COX HP Network Automation

The Cox HP Network Automation driver communicates with COX's Apigee API to fetch device configuration information. HPNA information is displayed in tables, depending on the configured settings.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version. | \-           | \-                |

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
- **IP port**: The IP port of the destination. Default port: *443*.
- **Bus address**: If the proxy server has to be bypassed, specify *bypassproxy.*

### Initialization

To make sure the driver can connect to the API, specify the **API Key**, **Username** and **Password** on the Configuration page.

### Redundancy

There is no redundancy defined.

## How to use

The driver contains a number of settings that allow you to customize its behavior:

- **Interface Settings**: A toggle button allows you to enable/disable the **polling from an interface (HTTP)**. You can also specify an interval to configure **how frequently the interface will be polled**. Finally, you can also select which of the following operating modes should be used:

- **Distributed**: Only requests data associated with elements hosted by the same DataMiner Agent.
  - **Centralized**: Requests data associated with all elements within the DMS
  - **Generic**: Request all data from the interface. Import/export logic does not apply.

<!-- -->

- **Entity Export/Import Settings**: These sections handle the exporting of configuration files and importing of provisioning files.
  You can:

- **Enable/disable** the exporting/importing feature with the toggle buttons **Entity Export** and **Entity Import**, respectively.
  - Configure the path where files will be exported and imported, with the **Entity Export Directory** and **Entity Import Directory** parameters.
  - Select whether to export/import to a local or to a remote location with the toggle buttons **Entity Export Directory Type** and **Entity Import Directory Type**, respectively.
    Note that for the **remote** file handling feature to work, you need to enter the credentials for the system in the **System Credentials** section, and enter the path to the remote directory in the **Entity Export/Import Directory** parameter. The **path** **must be shared/accessible**.
  - Manually perform the export/import by clicking the **Apply** button in the respective section.
