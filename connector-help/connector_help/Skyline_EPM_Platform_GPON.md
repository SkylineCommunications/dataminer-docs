---
uid: Connector_help_Skyline_EPM_Platform_GPON
---

# Skyline EPM Platform GPON

The **Skyline EPM Platform GPON** connector allows the aggregation of KPIs from different platform elements of the GPON infrastructures. This connector is an Experience and Performance Management connector, and as such it is designed to handle large amounts of data from the GPON infrastructures.

**Skyline EPM Platform GPON** is a **back-end** connector compatible with the **Skyline** **EPM Platform Solution**. A deployed EPM Solution contains one [Skyline EPM Platform](xref:Connector_help_Skyline_EPM_Platform)**front-end** element, but it can have one or multiple **Skyline EPM Platform GPONback-end** elements.
The **Skyline EPM Platform** front-end element is responsible for the top-level data aggregation from different **back-end** elements, while each **back-end** element is responsible for the aggregation of the data from the OLT Platform elements. The available OLTs are the following: [ZTE ZXA10 C600 GPON Platform](xref:Connector_help_ZTE_ZXA10_C600_GPON_Platform), [Huawei 5600-5800 GPON Platform](xref:Connector_help_Huawei_5600-5800_GPON_Platform) and [Nokia ISAM 7300 FX GPON Platform](xref:Connector_help_Nokia_ISAM_7300_FX_GPON_Platform)

Different topologies are presented in the **Skyline EPM Platform**. For the GPON infrastructure, the following chains are present:

- **GPON Service:**

  - Network
  - Market
  - Hub
  - OLT
  - Slot
  - Port
  - ONT

- **Quick**

  - Split Route, Split Distribution, Split FAT

- **Configuration**

  - Allows you to place Visual Overview layouts on a separate chain.

The KPIs in the topologies are the result of aggregation performed in the **Skyline EPM Platform GPONback-end** elements.

## About

### Version Info

| Range | Key Features | Based on | System Impact |
|--|--|--|--|
| 1.0.0.x | Initial version | \- | \- |
| 1.0.1.x \[SLC Main\] | Quick topology for GPON now contains Split Route, Split Distribution, Split FAT. Generic Split level was removed. | \- | \- |
| 1.0.2.x \[SLC Main\] | Removed remote view for ONT level | \- | \- |

### System Info

| Range | DCF Integration | Cassandra Compliant | Linked Components | Exported Components |
|--|--|--|--|--|
| 1.0.0.x | No | Yes | Automation scripts: - EpmBeToOlt - EpmBeToOltPassives Generic KAFKA Consumer Connectors: - ZTE ZXA10 C600 GPON Platform - Huawei 5600-5800 GPON Platform - Nokia ISAM 7300 FX GPON Platform - Skyline EPM Platform | \- |
| 1.0.1.x | No | Yes | Automation scripts: - EpmBeToOlt - EpmBeToOltPassives Generic KAFKA Consumer Connectors: - ZTE ZXA10 C600 GPON Platform - Huawei 5600-5800 GPON Platform - Nokia ISAM 7300 FX GPON Platform - Skyline EPM Platform | \- |
| 1.0.2.x | No | Yes | Automation scripts: - EpmBeToOlt - EpmBeToOltPassives Generic KAFKA Consumer Connectors: - ZTE ZXA10 C600 GPON Platform - Huawei 5600-5800 GPON Platform - Nokia ISAM 7300 FX GPON Platform - Skyline EPM Platform | \- |

## Configuration

### Connections

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

Before the creation of a **Skyline EPM Platform GPON** element it is necessary to install the Automation Scripts **EpmBeToOlt** and **EpmBeToOltPassives** (without these scripts the element will not function).

All components of the **Skyline EPM Platform Solution** work with a file system for internal communication. Because of this, when a new **Skyline EPM Platform GPON** element is created the following parameters must be defined in the **Configuration** page:

1. Import Settings

   - **Entity Import Directory**: Specify the generic GPON entity import path that is used throughout the EPM Solution. From this path the **Skyline EPM Platform GPON** will retrieve the OLT topology CSV file.

   - **Entity Import Directory Type**: Specify whether the import path is local or remote. Note that for the remote file handling to work, the credentials for the system must be entered in the **System Credentials** section and directory must be set to a remote path. The path has to be shared/accessible, or this feature will not work.

1. Export Settings

   - **Entity Export Directory**: Specify the generic GPON entity export path that is used throughout the EPM Solution.

   - **Entity Import Directory Type**: Specify whether the respective export path is local or remote. Note that for the remote file handling to work, the credentials for the system must be entered in the **System Credentials** section and directory must be set to a remote path. The path has to be shared/accessible, or this feature will not work.

1. System Credentials: This section is to be used if the element is configured to a remote file location.

   - **System Username**: The username that has access to the remote directory. If no domain is specified, the domain from the element's DMA location will be used.

   - **System Password**: The password of the user to access the remote directory.

Finally, it is necessary to register the **OLT elements** (DMA_ID/Element_ID) that will be taken into account for the solution. This must be done in the **GPON Collector Registration** table available in the Backend page.

## How to use

While this connector is mostly self-reliant once the initial setup is done, there are actions the user can perform.

- The **Provision button** will import all the provisioning files generated by the **Skyline EPM Platform** element and then notify the **OLT** elements to perform the import.

- The **Reset button** removes existing data from tables and performs provisioning logic to remove any erroneous data.

## Notes

### Inner workflow of the EPM Solution

The provisioning of the EPM Solution for GPON is sequential and involves the following components:

- **Skyline EPM Platform**: Responsible for the top-level data aggregation, displaying the topologies and ID assignment of all entities.
- **Skyline EPM Platform GPON**: In charge of the data aggregation from the OLTs.
- **OLT Platform**: In charge of polling data from the different OLTs (e.g. ZTE ZXA10 C600 GPON Platform) and exporting all available the entities.

The solution is based on the usage of CSV files and the DataMiner messaging system.

First, the **OLT** elements export the necessary files containing the resources (GPON topology and passives topology) that need to be assigned DataMiner IDs. These elements notify the **Skyline EPM Platform front-end** element, which in turn, initiates the ID assignment process. The ID request notifications will be handled in a FIFO (First-In-First-Out) fashion to ensure the sequential processing of requests. The **front-end** element will import the CSV files to perform the necessary steps of the provisioning.

Once the ID assignment is completed, the **front-end** element will export a series of CSV files for the **Skyline EPM Platform GPON back-end** and **OLT** elements to import. For this, the **front-end** element notifies the respective b**ack-end** element to process these files. The **back-end** element imports the resources with their assigned IDs and notifies the respective **OLT** elements of ID assignment completion (these elements will import the new files).
