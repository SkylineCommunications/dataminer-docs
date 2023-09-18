---
uid: Connector_help_Skyline_CCAP_Platform_WM
---

# Skyline CCAP Platform WM

The Skyline CCAP Platform Workflow Manager protocol is used to handle workflows and data exchange processes between the different DataMiner modules present in the DataMiner EPM Solution. These modules include elements, protocols, and the Correlation and Automation apps.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial release  | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you first start using this element, navigate to the **Configuration** page. A number of configuration options are available that can change the behavior of the connector. You can find more information about these settings in the "How to use" section below.

### Redundancy

There is no redundancy defined.

## How to use

As this is a virtual connector, **no data traffic** will be shown in **the Stream Viewer**.

The Skyline CCAP Platform WM is configured to handle requests for three connectors: **CISCO CBR-8 CCAP Platform Collector**, **CISCO Manager CIN Platform**, and **Juniper Networks Manager CIN Platform**.

There are five workflows to exchange data between these connectors and auxiliary data:

- **HPNA:** Communicates with the **Cox HP Network Automation** connector to retrieve relevant data based on the requestor's hostname. Used by all configured connectors.
- **DCF:** Collates all DCF information from configured connectors once exported to send to the **DCF Connectivity Discovery** script, which creates the report that allows the **Cox IDP EPM Connectivity** connector to create DCF connections for the entire system. Used by all configured connectors.
- **OUI:** Internally processes requests using the Master.csv file from OUI on matching manufacturer information with MAC addresses. Only used by **CISCO CBR-8 CCAP Platform Collector**.
- **Vecima RPM:** Communicates with the **Cox Vecima R-PHY Monitor** connector to get relevant data based on requested MAC addresses. Only used by **CISCO CBR-8 CCAP Platform Collector**.
- **Smart PHY**: Communicates with the **Cox Smart PHY** connector to get relevant data based on requested MAC addresses. Only used by **CISCO CBR-8 CCAP Platform Collector**.

On the **Configuration** page, the following settings are available:

- **WM Settings**: This section allows you to configure the handling of workflows that are added to the Workflow Overview table. Available options are:

  - **Processing Timer**: Determines how often DataMiner will check if workflows need to be processed.
  - **Wait Time**: Determines how long a workflow can have the processing status until it is re-processed.
  - **Retries**: Determines how many times DataMiner will attempt to process a workflow until it is considered to have failed.

- **Entity Export/Import Settings**: These sections allow you to export configuration files and import provisioning files. You can:

  - **Enable or disable** the exporting and importing feature with toggle buttons (**Entity Export** and **Entity Import**, respectively).
  - Specify the **file paths** where files can be exported and imported (with the **Entity Export Directory** and **Entity Import Directory**, respectively).
  - Specify whether to export/import to/from a **local or remote** location via a toggle button (**Entity Export Directory Type** and **Entity Import Directory Type**, respectively).
    Note that for the remote file handling to work, you must enter the credentials for the system in the **System Credentials** section and enter the path to the remote directory in the **Entity Export** or **Import Directory** parameter. The path must be shared/accessible, or this feature will not work.
  - Start the export or import by clicking the **Apply** button in the relevant section.

## Notes

This connector requires specific Correlation rules and Automation scripts for communication with auxiliary connectors such as **Cisco Smart PHY**, **HP Network Automation**, and **Vecima RPM** and EPM connectors such as **CISCO CBR-8 CCAP Platform Collector**, **CISCO Manager CIN Platform**, and **Juniper Networks Manager CIN Platform**. The Correlation rules and Automation scripts must be configured and enabled in order to get the full functionality of this connector.

For the DCF workflow to have its full use with the DCF framework, the **DCF Connectivity Discovery** script and **Cox IDP EPM Connectivity** connector are needed.
