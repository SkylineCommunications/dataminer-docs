---
uid: Connector_help_Skyline_EPM_Platform_GPON_WM
---

# Skyline EPM Platform GPON WM

The **Skyline EPM Platform GPON WM** is a configuration manager used to handle workflows and data exchange processes between different components of the **GPON Module** present in the **Skyline EPM Platform Solution**. Currently the connector manages two workflows: **ONT KPI Requests** and **Passive Data Requests**.

### Version Info

| **Range**            | **Key Features**                                                                                                             | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | \- Initial version - Manages the workflow and creation of OLT KPI files - Manages the workflow and creation of Passive files | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components**                                                                                                                                                                     | **Exported Components** |
|-----------|---------------------|-------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | Automation scripts: - WmGponToOlt - OltToGponWm Generic KAFKA Consumer OLT Connectors: - ZTE ZXA10 C600 GPON Platform - Huawei 5600-5800 GPON Platform - Nokia ISAM 7300 FX GPON Platform | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Before the creation of a **Skyline EPM Platform GPON WM** element it is necessary to install the Automation Scripts **WmGponToOlt** and **OltToGponWm** (without these scripts the element will not function).

Additionally, all components of the **Skyline EPM Platform Solution** work with a file system for internal communication. Because of this, when a new **Skyline EPM Platform GPON WM** element is created the following parameters must be defined in the **Configuration** page:

1\. Import Settings

- **Entity Import Directory**: Specify the generic GPON entity import path that is used throughout the EPM Solution. From this path the **Skyline EPM Platform GPON WM** will retrieve the ONT CSV file, or the Subscriber/Splitter CSV files required for the **ONT KPI Requests** and **Passive Data Requests**, respectively.
- **KAFKA Import Directory**: Specify the path where the KAFKA Stream update files are located.
- **Entity/KAFKA Import Directory Type**: Specify whether the respective import path is local or remote. Note that for the remote file handling to work, the credentials for the system must be entered in the **System Credentials** section and directory must be set to a remote path. The path has to be shared/accessible, or this feature will not work.

2\. Export Settings

- **Entity Export Directory**: Specify the generic GPON entity export path that is used throughout the EPM Solution. In this path the output Subscriber and Splitter CSV files will be exported as a result of the **Passive Data Requests**.
- **KAFKA Import Directory**: Specify the path where the output KAFKA Stream JSON files will be exported as a result of the **ONT KPI Requests**.
- **Entity/KAFKA Import Directory Type**: Specify whether the respective export path is local or remote. Note that for the remote file handling to work, the credentials for the system must be entered in the **System Credentials** section and directory must be set to a remote path. The path has to be shared/accessible, or this feature will not work.

3\. System Credentials: This section is to be used if the element is configured to a remote file location.

- **System Username**: The username that has access to the remote directory. If no domain is specified, the domain from the element's DMA location will be used.
- **System Password**: The password of the user to access the remote directory.

Finally, if considered necessary it is possible to configure the handling of the workflow requests in the **Workflow Settings** section of the **Configuration** page. The available options are:

- **Processing Timer**: Determines how often the element will check if there are workflow requests that need to be processed.
- **Wait Time**: Determines how long a workflow must wait to be re-processed in case it has failed.
- **Retries**: Determines how many times the element will attempt to process a workflow until it is considered to have failed.

## How to use

The **Skyline EPM Platform GPON WM** is configured to handle requests from the OLT elements [ZTE ZXA10 C600 GPON Platform](xref:Connector_help_ZTE_ZXA10_C600_GPON_Platform), [Huawei 5600-5800 GPON Platform](xref:Connector_help_Huawei_5600-5800_GPON_Platform) and [Nokia ISAM 7300 FX GPON Platform](xref:Connector_help_Nokia_ISAM_7300_FX_GPON_Platform). These workflow requests and their respective result status are visible in the **Workflow Overview** table.
The supported workflows are the following:

### ONT KPI Requests

The objective of this workflow is to retrieve the main KPIs (provided by a KAFKA platform) of the ONTs available in a specific OLT.

1. Enable the processing of the KAFKA Streams in the **Configuration** page.
1. Configure the **KAFKA Interval** in the Configuration page (default value: 15 mins). This parameter defines how often the KAFKA streams will be processed.
1. The **Skyline EPM Platform GPON WM** adds the KAFKA stream process to the **Workflow Overview** table depending on the time interval defined in the **KAFKA Interval** parameter.
1. The **Skyline EPM Platform GPON WM** accesses the directory defined in the **Entity Import Directory** parameter and imports all the OLT CSV files. These files are created by the OLT elements and they contain a list of all the their ONTs.
1. Then the **Skyline EPM Platform GPON WM** element goes through the JSON stream files available in the **KAFKA Import Directory** and creates a single KPI Provisioning JSON file for each OLT that only contains the data related to its ONTs.
1. The new OLT KPI Provisioning files are exported to the **KAFKA Export Directory** and a message is sent to each OLT element indicating that the file is ready. After this, the **Status** of the request in the **Workflow Overview** table is set to **Completed.**

> [!NOTE]
> If an unexpected error occurs during the workflow, the **Status** of the request in the **Workflow Overview** table is set to **Failed**.

### Passive Data Requests

This workflow allows an OLT to obtain the passive components (Subscribers and Splitters) linked to its topology.

1. An **OLT element** sends a request for the **Subscriber** or **Splitter** information to the **GPON WM**.
1. The **Skyline EPM Platform GPON WM** receives the request and adds it to the **Workflow Overview** table to later process it depending on the parameters defined in the Configuration page.
1. The **Skyline EPM Platform GPON WM** access the directory defined in the **Entity Import Directory** and retrieves the respective Subscriber or Splitter CSV files. The element proceeds to process the required file and create a new compatible CSV file with the OLT element.
1. The new compatible **Subscriber** or **Splitter** file is exported to the **Entity Export Directory** and a message is sent to the OLT indicating that the file is ready. After this, the **Status** of the request in the **Workflow Overview** table is set to **Completed.**

> [!NOTE]
> If an unexpected error occurs during the workflow, the **Status** of the request in the **Workflow Overview** table is set to **Failed**.

## Notes

The Subscriber, Splitter and KAFKA Stream files are created by connectors external to the Skyline Platform EPM Solution, like the Generic KAFKA Consumer or the Telefonia por Cable S.A de C.V Geomarketing DB GPON.
