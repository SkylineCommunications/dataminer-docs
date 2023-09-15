---
uid: Connector_help_Skyline_CCAP_Platform_EPM
---

# Skyline CCAP Platform EPM

The Skyline CCAP Platform EPM connector allows the aggregation of KPIs from different collector elements deployed in the DOCSIS infrastructure.

## About

This is an **EPM** (Experience and Performance Management) driver, and as such it is designed to poll large amounts of data from the deployed infrastructure, using **front-end** and **back-end** EPM Manager elements. Both of these types of elements use the same EPM Manager connector.

The DOCSIS system contains one front-end element and several back-end elements. The front-end element is responsible for the top-level data aggregation from different back-end elements. Each back-end element is responsible for the aggregation of a section of the data from the collectors.

Topologies describe the connections in the diagram shown in the visual interface. The current implementation integrates 4 different topologies: **CCAP Overview**, **CCAP DOCSIS Network**, **CCAP DOCSIS Service**, and **Quick**. Each topology represents a connected entity from top to bottom. Chains are mainly used to display topology views. In this case, the following chains are present:

- **CCAP Overview**

  - Network
  - Market
  - Hub
  - CCAP Core
  - RPD
  - CM

- **CCAP DOCSIS Network**

  - Network
  - Market
  - Hub
  - CCAP Core
  - DPIC
  - DPIC Interface
  - DS Controller - US Controller
  - Node Segment
  - CM

- **CCAP DOCSIS Service**

  - Network
  - Market
  - Hub
  - CCAP Core
  - Service Group
  - DS Service Group - US Service Group
  - Fiber Node
  - Node Segment
  - CM

- **Quick**

  - Allows you to quickly access any platform topology level by selecting the desired filter (Network, Market, Hub, Manufacturer, CCAP Core, RPD, CM).

- **Configuration**

  - Allows you to place Visual Overview layouts on a separate chain.

### Version Info

| **Range**            | **Key Features**                                                                        | **Based on** | **System Impact** |
|----------------------|-----------------------------------------------------------------------------------------|--------------|-------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                                        | \-           | \-                |
| 1.0.1.x \[SLC Main\] | Added CCAP core Relations KPIs table. Removed Service Group table and its dependencies. | 1.0.0.8      | \-                |

### Product Info

| **Range** | **Supported Firmware** |
|-----------|------------------------|
| 1.0.0.x   | 2.9.2.r1.588           |
| 1.0.1.x   | 2.9.2.r1.588           |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

For each manager, the following data should be configured on the Configuration page:

For back-end managers:

- **Role** (back-end)
- **File Import Path**
- **List of registered collectors** (**Collector Registration** table on the Backend Information page)

For front-end managers:

- **Role** (front-end)
- **File Import Path**
- **List of registered back-end elements** (**Backend Registration** table on the Frontend page)
- **List of all the collectors in the system** (**All Collectors Registration** table on the Frontend page)

### Provisioning

Provisioning of the entire solution happens sequentially and involves platform collector elements as well as the front-end and back-end elements. The solution is based on the usage of .CSV files as DataMiner messaging system using information events.

After the collector has exported the necessary files containing the resources that need to be assigned DataMiner IDs, it will notify the assigned front-end element, which in turn initiates the ID assignment process. ID request notifications will be handled in a FIFO (First-In -First-Out) fashion to ensure the sequential processing of requests.

The front-end element will import a series of CSV files in order to perform the necessary steps of the provisioning.

Once the ID assignment is completed, the front-end element will export a series of CSV files for the back-end elements and collectors to import. It will then notify the relevant back-end elements to process these files.

Back-end elements import info on the resources with their assigned IDs, and notify the respective collector elements of ID assignment completion.

**Provisioning Workflow Overview:**

1. Collector elements export info on resources without IDs.
1. Collector elements interrogate the assigned front-end manager for ID assignment.
1. The front-end element imports info on resources without IDs.
1. The front-end element exports info on resources with assigned IDs.
1. The front-end element notifies the handling back-end element.
1. The handling back-end element imports info on resources with IDs.
1. The handling back-end element notifies the assigned collector elements that the ID request has been fulfilled.
1. The collector element imports info on resources with the assigned IDs.

### Redundancy

There is no redundancy defined.

## How to use

1. Ensure that the configuration tables are properly filled in (See Configuration section above).

1. Specify the file paths for the import and export paths and ensure they all line up as follows:

   - Collector import = Front-end export

   - Collector export = Front-end import

   - Front-end export = Back-end import

1. If an import or export directory is a remote location, fill in the Username and Password fields in the System Credentials section of the Configuration page.

1. Click the **Provision** button to import and export all files and add any new entities found to the managers table. This will notify back-end elements and collectors to perform an import.

You can use the **Reset** button to remove existing data from tables and perform provisioning logic to remove any erroneous data that may have been lingering. A reset is also done daily to ensure that data is up to date. This will also inform back-end elements and collectors to import the new files.

## Notes

The messaging system integration requires two Correlation rules and two Automation scripts that will pick up on the information events and send the corresponding message to a message listener to begin the logical flow.
