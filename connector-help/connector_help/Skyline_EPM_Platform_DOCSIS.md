---
uid: Connector_help_Skyline_EPM_Platform_DOCSIS
---

# Skyline EPM Platform DOCSIS

The Skyline EPM Platform DOCSIS connector allows the aggregation of KPIs from different collector elements for DOCSIS infrastructures.

This is an Experience and Performance Management connector, and as such it is designed to handle large amounts of data from DOCSIS infrastructures.

**Skyline EPM Platform DOCSIS** is a **back-end** connector compatible with the **EPM Solution**. A deployed EPM Solution contains one [Skyline EPM Platform](xref:Connector_help_Skyline_EPM_Platform) **front-end** element, but it can have one or multiple Skyline EPM Platform DOCSIS back-end elements. While the Skyline EPM Platform front-end element is responsible for the top-level data aggregation from different back-end elements, each back-end element is responsible for the aggregation of the data from the collectors.

Different topologies are presented in the Skyline EPM Platform. For the DOCSIS infrastructure, the following chains are present:

- **DOCSIS Network**

- Network
  - Market
  - Hub
  - CCAP Core
  - DS Line Cards - US Line cards
  - DS Ports - US Ports
  - Node Segment
  - CM

<!-- -->

- **DOCSIS Service**

- Network
  - Market
  - Hub
  - CCAP Core
  - Service Group \[Fiber Node\]
  - DS Service Group- US Service Group
  - CM

<!-- -->

- **Quick**

- Allows you to quickly access the Passives topology level by selecting the desired filter (Node, Amplifier, Tap).

<!-- -->

- **Configuration**

- Allows you to place Visual Overview layouts on a separate chain.

The KPIs present in the topologies are the result of aggregation performed in the Skyline EPM Platform DOCSIS back-end elements.

## About

### Version Info

| **Range**            | **Key Features**                                                                                                                                                                                                                                          | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x              | Initial version                                                                                                                                                                                                                                           | \-           | \-                |
| 1.0.1.x              | Decoupling and enhancements.                                                                                                                                                                                                                              | \-           | \-                |
| 1.0.2.x              | Remote view tables retrieve information from multiple source elements.                                                                                                                                                                                    | \-           | \-                |
| 1.0.3.x              | Adjusted CM QAM US/DS CM COL view tables to match with the source and added a status parameter to the CM QAM US/DS tables.                                                                                                                                | \-           | \-                |
| 1.0.4.x              | \- Partial table option enabled on several tables to improve loading time of the filter box on EPM topology. - Parameter added that lets the user change the name of the Automation script that notifies the back-end element of new data to be ingested. | \-           | \-                |
| 1.0.5.x \[SLC Main\] | New exceptions added for the correction of the default value for average percentage US and DS utilization.                                                                                                                                                | \-           | \-                |

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

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you create a **Skyline EPM Platform DOCSIS** element, you need to configure the following data:

- Define the **File Import Path** on the **Configuration** page. This same directory must be configured on all the elements of the EPM Solution.
- Define the **File Export Path** on the **Configuration** page. This same directory must be configured on all the elements of the EPM Solution.
- Add the **Generic DOCSIS CM Collector** elements in the **DOCSIS Collector Registration** table available on the **Backend** page.
- If the **import and export directory** is in a **remote location**, fill in the **Username** and **Password** fields in the System Credentials section of the **Configuration** page.

## How to use

While this connector is mostly self-reliant once the initial setup is done, there are a number of actions you can perform.

The **Provision button** will import all files by notifying the **CCAP Platform** and **Generic DOCSIS CM** **Collector** elements that the import needs to be performed.

The **Reset button** removes existing data from tables and performs provisioning logic to remove any erroneous data.

On the **Configuration Passives** page, the **Load Time** parameter allows you to configure the exact time the passive requests (Node, Amplifier, Tap, Subscriber) will be sent to the Skyline EPM Platform DOCSIS WM element. This must be filled in in the 24-hour format: HH: MM. On this same page, you can also disable specific passive requests or send the requests on demand.

In range **1.0.4.x**, the **Script Name** is added, which allows you to change the Automation script to be executed. This parameter is available on the **Configuration** page.

## Notes

The messaging system integration requires the use of Correlation rules and Automation scripts that will pick up on the information events and send the corresponding message to a message listener to begin the logical flow.

### Inner workflow of the EPM Solution

The provisioning of the EPM Solution is sequential and involves the following components:

- **Skyline EPM Platform**: Responsible for the top-level data aggregation and for displaying the topologies.
- **Skyline EPM Platform DOCSIS**: In charge of the data aggregation from the collectors.
- **CCAP Platform**: In charge of polling data from the different CMTSs.
- **Generic DOCSIS CM Collector**: Retrieves information from each individual available cable modem.
- **Skyline EPM Platform DOCSIS WM**: Creates compatible files regarding the passives available within the DOCSIS infrastructure.

The solution is based on the usage of CSV files and the DataMiner messaging system using information events.

First, the **CCAP Platform** elements export the necessary files containing the resources that need to be assigned DataMiner IDs. These elements notify the **Skyline EPM Platform front-end** element, which in turn initiates the ID assignment process. The ID request notifications will be handled in a FIFO (First-In-First-Out) fashion to ensure the sequential processing of requests. The front-end element will import the CSV files in order to perform the necessary steps of the provisioning.

Once the ID assignment is completed, the front-end element will export a series of CSV files for the **Skyline** **EPM** **Platform DOCSIS back end,** **CCAP Platform**, and **Generic DOCSIS CM Collector** elements to import. For this, the front-end element notifies the respective back-end element to process these files. The back-end element imports the resources with their assigned IDs and notifies the respective **CCAP Platform** and **Generic DOCSIS CM Collector** elements of ID assignment completion (these elements will import the new files).

The back-end elements are in charge of requesting the **passives** from the CMTS devices that they have assigned. For this, each back-end element sends a request every 24 hours to their respective **Skyline EPM Platform DOCSIS WM** element. This second element receives the request, creates the required passive CSV files, and notifies the back-end element. The back-end element then notifies the front-end element that its passive files are available and requests the ID assignment. Once this process is finished, the front-end element informs the back-end element, and it imports the passive resources with their assigned IDs.

## Notes

Only CCAP elements that are active and registered in the Registration table are used to filter out passive and non-passive files.
