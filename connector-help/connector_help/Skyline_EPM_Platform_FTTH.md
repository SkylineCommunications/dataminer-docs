---
uid: Connector_help_Skyline_EPM_Platform_FTTH
---

# Skyline EPM Platform FTTH

The **Skyline EPM Platform FTTH** connector allows the aggregation of KPIs from different collector elements deployed for different types of infrastructures.

This is an **Experience and Performance Management** connector, and as such it is designed to handle large amounts of data from the deployed infrastructures.

This same connector is used as the front-end element of the EPM Solution and also as a back-end element. A deployed EPM Solution contains one Skyline EPM Platform FTTH front-end element and can have one or multiple back-end elements. The front-end element is responsible for the top-level data aggregation from different back-end elements. Each back-end element is responsible for the aggregation of the data from the collectors.

Different topologies are presented in this connector. These topologies are diagrams shown in Visual Overview, which describe the connections between the entities of the different infrastructures. The current implementation integrates the Quick topology which allows you to quickly access the passive topology level by selecting the desired filter (**OLT**, **POP**, **Label**, **ONT**).

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

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

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you create a Skyline EPM Platform FTTH element, you need to configure the following data:

- Define the **File Import Path** on the Configuration page. This same directory must be configured on all the elements of the EPM Solution.
- Add the front-end, back-end, and collector elements on the **FE/BE Registration** page.

### Provisioning

The provisioning of the EPM Solution is sequential and involves the following components:

- **Skyline EPM Platform FTTH** as front-end element: Responsible for the top-level data aggregation and for displaying the topologies.
- **Skyline EPM Platform FTTH** as back-end element: In charge of the data aggregation from the collectors.
- **Skyline EPM Platform FTTH Collector**: In charge of the ONT data aggregation from an OLT.
- **Telenet EPM Platform FTTH WM**: Creates compatible files regarding the passives available within the GPON infrastructure and the KAFKA OLT KPIs.

## How to use

The solution is based on the usage of **CSV** files.

The implemented architecture has a central point of control where the front-end element notifies, using Inter-App messages, all the Workflow Managers in the DMS to generate the structured files for each entity. After that, the remaining blocks (collectors and back-end elements) are informed to ingest them.

A new provisioning process is initiated when you click the provision button in the front-end element. This action triggers a sequence of events spaced at 5-second intervals.

1. The Workflow Manager elements are notified to generate the structured files with the IDs for each entity. Once these have been generated/exported, the front-end element is notified of this.
2. The collector elements are notified to import the files.
3. The back-end elements are notified to import the files.

By default, the destination is expected to respond within 5 seconds, but this polling interval can be customized with the timer base option.

Since all blocks report to the front-end element, if one block fails to respond, the source of the failure can immediately by identified.
