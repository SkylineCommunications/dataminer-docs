---
uid: Connector_help_Skyline_EPM_Platform
---

# Skyline EPM Platform

The Skyline EPM Platform connector allows the aggregation of KPIs from different collector elements deployed for different types of infrastructures.

This is an Experience and Performance Management connector, and as such it is designed to handle large amounts of data from the deployed infrastructures.

**Skyline EPM Platform** is the **front-end** connector of the **EPM Solution**. A deployed EPM Solution contains one Skyline EPM Platform front-end element and can have one or multiple back-end elements (using [Skyline EPM Platform DOCSIS](xref:Connector_help_Skyline_EPM_Platform_DOCSIS)). The Skyline EPM Platform front-end element is responsible for the top-level data aggregation from different back-end elements. Each back-end element is responsible for the aggregation of the data from the collectors.

Different **topologies** are presented in the Skyline EPM Platform. These topologies are diagrams shown in Visual Overview, which describe the connections between the entities of the different infrastructures. The current implementation integrates the following topologies: **DOCSIS Network**, **DOCSIS Service**, **Network**, and **Quick**. Each topology represents a connected entity from top to bottom. The following chains are present:

- **DOCSIS Network**

- Network
  - Market
  - Hub
  - CCAP Core
  - DS Line Cards - US Line Cards
  - DS Ports - US Ports
  - Node Segment
  - CM

<!-- -->

- **DOCSIS Service**

- DOCSIS Network
  - DOCSIS Market
  - DOCSIS Hub
  - CCAP Core
  - Service Group \[Fiber Node\]
  - DS Service Group - US Service Group
  - CM

<!-- -->

- **DOCSIS Passives**

- Node
  - Amplifier
  - Tap
  - CM

<!-- -->

- **GPON Service**

- GPON Network
  - GPON Market
  - GPON Hub
  - OLT
  - Slot
  - Port
  - ONT

<!-- -->

- **DOCSIS Quick**

- Allows you to quickly access the **DOCSIS** topology level by selecting the desired filter.

<!-- -->

- **GPON Quick**

- Allows you to quickly access the **GPON** topology level by selecting the desired filter (Including Split Route, Split Distribution, Split FAT).

<!-- -->

- **Configuration**

- Allows you to place Visual Overview layouts on a separate chain.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                                       | **Based on** | **System Impact** |
|----------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version.                                                                                                                                                                                                                                                       | \-           | \-                |
| 1.0.1.x              | Integration of PNM KPIs.                                                                                                                                                                                                                                               | \-           | \-                |
| 1.0.2.x              | Decoupling and enhancements.                                                                                                                                                                                                                                           | \-           | \-                |
| 1.0.3.x              | Remote view tables retrieve information from multiple source elements.                                                                                                                                                                                                 | \-           | \-                |
| 1.0.4.x              | \- Partial table option enabled on several tables to improve loading time of the filter box for the EPM topology. - Parameter added that lets the user change the name of the Automation script that notifies the CCAPs/CM collector pairs of new data to be ingested. | \-           | \-                |
| 1.0.5.x              | \- New exceptions added for the correction of the default value for average percentage US and DS utilization.                                                                                                                                                          | \-           | \-                |
| 1.0.6.x              | \- Quick topology for GPON now contains Split Route, Split Distribution, and Split FAT. Generic Split level was removed.                                                                                                                                               | \-           | \-                |
| 1.0.7.x              | Remote views removed from DOCSIS CPE level (Cable Modem, QAM Channels).                                                                                                                                                                                                | \-           | \-                |
| 1.0.8.x              | Remote views removed from GPON CPE level (ONT).                                                                                                                                                                                                                        | \-           | \-                |
| 1.0.9.x \[SLC Main\] | Organization and grouping for KPIs through GPON Service, DOCSIS Network, and DOCSIS Service topologies.                                                                                                                                                                | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | N/A                    |
| 1.0.1.x   | N/A                    |
| 1.0.2.x   | N/A                    |
| 1.0.3.x   | N/A                    |
| 1.0.4.x   | N/A                    |
| 1.0.5.x   | N/A                    |
| 1.0.6.x   | N/A                    |
| 1.0.7.x   | N/A                    |
| 1.0.8.x   | N/A                    |
| 1.0.9.x   | N/A                    |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.2.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.3.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.4.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.5.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.6.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.7.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.8.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.9.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you create a **Skyline Platform EPM** element, you need to configure the following data:

- Define the **File Import Path** on the **Configuration** page. This same directory must be configured on all the elements of the EPM Solution.
- Define the **File Export Path** on the **Configuration** page. This same directory must be configured on all the elements of the EPM Solution.
- If the **File Import Path** or **File Export Path** are in a remote location, fill in the **Username** and **Password** fields in the System Credentials section of the **Configuration** page.
- Add the **DOCSIS back-end** elements to the **Backend Registration** table on the **Frontend** page.
- Add the **GPON back-end** elements to the **Backend Registration GPON** table on the **Frontend** page.
- Add the **Generic DOCSIS CM Collector** elements in the **DOCSIS Collector Registration** table on the **Frontend** page.
- Add the **PON OLT** elements in the **GPON Collector Registration** table on the **Frontend** page.

### Provisioning

The provisioning of the EPM Solution is sequential and involves the following components:

- **Skyline Platform EPM**: Responsible for the top-level data aggregation and for displaying the topologies.
- **Skyline Platform EPM DOCSIS**: In charge of the data aggregation from the collectors.
- **Skyline Platform EPM GPON**: In charge of the data aggregation from the OLTs.
- **CCAP Platform**: In charge of polling data from the different CMTSs.
- **GPON Platform**: In charge of polling data from the different OLTs.
- **Generic DOCSIS CM Collector**: Retrieves information from each individual available cable modem.
- **Skyline Platform EPM DOCSIS WM**: Creates compatible files regarding the passives available within the DOCSIS infrastructure.
- **Skyline Platform EPM GPON WM**: Creates compatible files regarding the passives available within the GPON infrastructure and the KAFKA OLT KPIs.

### Redundancy

There is no redundancy defined.

## How to use

The solution is based on the usage of .CSV files and the DataMiner messaging system using information events.

The **CCAP Platform** and **GPON Platform** elements export the necessary files containing the resources that need to be assigned DataMiner IDs. These elements notify the **Skyline Platform EPM front-end** element, which in turn initiates the ID assignment process. The ID request notifications will be handled in a FIFO (First-In -First-Out) fashion to ensure the sequential processing of requests. The front-end element will import the CSV files in order to perform the necessary steps of the provisioning.

Once the ID assignment is completed, the front-end element will export a series of CSVs. For DOCSIS, the files will be imported by the **Skyline Platform EPM DOCSIS back end**, **CCAP Platform**, and **Generic DOCSIS CM Collector** elements. For GPON, the files will be imported by the **Skyline Platform EPM GPON back end** and **OLT Platform** elements. For this process to occur, the front-end element notifies the respective back-end element to process these files. The back-end element imports the resources with their assigned IDs and notifies the respective **OLT Platform** or **CCAP Platform** and **Generic DOCSIS CM Collector** elements of ID assignment completion (these elements will import the new files).

For DOCSIS, the back-end elements are in charge of requesting the **passives** from the CMTS devices that they have assigned. For this, each back-end element sends a request every 24 hours to their respective **Skyline Platform EPM DOCSIS WM** element. This second element receives the request, creates the required passive CSV files, and notifies the back-end element. The back-end element then notifies the front-end element that its passive files are available and requests the ID assignment. Once this process is finished, the front-end element informs the back-end element, and it imports the passive resources with their assigned IDs.

The **Provision** button makes the element import and export all files and add any new entities. This will notify the back-end, Platform, and Generic DOCSIS CM Collector elements that they need to perform the import.

The **Reset** button will remove existing data from tables and performs provisioning logic to remove any erroneous data.

In range **1.0.4.x**, the **Script Name** parameter is added, which allows you to change the Automation script to be executed. This parameter is available on the **Configuration** page.

## Notes

The messaging system integration requires the use of Correlation rules and Automation scripts that will pick up on the information events and send the corresponding message to a message listener to begin the logical flow.
