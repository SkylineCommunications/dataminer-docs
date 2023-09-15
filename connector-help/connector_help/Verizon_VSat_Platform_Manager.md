---
uid: Connector_help_Verizon_VSat_Platform_Manager
---

# Verizon VSat Platform Manager

The **Verizon VSat Platform Manager** allows the aggregation of KPIs from different collector elements deployed in the Verizon infrastructure (**Verizon iDirect Evolution Platform Collector**, **Verizon iDirect Pulse Platform Collector** and **Verizon VSat Platform Manager**).

## About

This is a **CPE** (Customer Premises Equipment) connector, and as such it is designed to poll large amounts of data from the deployed infrastructure, using **front-end** CPE Manager elements and **back-end** CPE Manager elements. Both of these types of elements use the same CPE Manager connector. The Verizon system contains one front-end and several back-end elements. The front-end element is responsible for the top-level data aggregation from different back-end elements. Each back-end element is responsible for the aggregation of a section of the data from the collectors.

Topologies describe the connections in the diagram shown in the visual interface. The current implementation integrates 5 different topologies: **Network**, **Service**, **NMS**, **Map** and **Quick**. Each topology represents a connected entity from top to bottom. Chains are mainly used to display topology views. In this case, the following chains are present:

- **Network**

- Network
  - Teleport
  - Hub Network
  - Hub Forward - Hub Return
  - Circuits

- **Service**

- Network
  - Customer
  - Circuits

- **NMS**

- Network
  - NMS
  - Hub Network
  - Hub Forward - Hub Return
  - Circuits

- **Map**

- Network
  - NMS - Customer
  - Circuits

- **Quick**

- Allows you to quickly access any platform topology level by selecting the desired filter (**Network**, **Teleport**, **NMS**, **Customer**, **Hub Network**, **Hub Forward**, **Hub Return**, **Circuit**).

- **Configuration**

- Allows you to place Visio layouts on a separate chain.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | N/A                         |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration

For each manager, the following data should be configured on the Configuration page:

For back-end managers:

- **Role** (back-end)
- **File Import Path**
- **List of registered collectors** (**Collector Registration** table Backend Information page)

For front-end managers:

- **Role** (front-end)
- **File Import Path**
- **List of registered back-end elements** (**Backend Registration** table on Frontend page)
- **List of all the collectors in the system** (**All Collectors Registration** table on Frontend page)

### Provisioning

The provisioning of the entire solution happens sequentially and involves platform collector elements as well as the front-end and back-end elements. The solution is based on the usage of .CSV files as well as inter-element sets.

After the collector has exported the necessary files containing the resources that need to be assigned DMS IDs, it will notify the assigned front-end element, which in turn initiates the ID assignment process. ID request notifications will be handled in a FIFO (First-In -First-Out) fashion to ensure the sequential processing of requests.

The front-end element will import a series of CSV files in order to perform the necessary steps of the provisioning. The ID assignment will be done through the DataMiner SRM module. For each resource within the files, the following will happen:

1. The SRM module will determine if the resource already exists and check if its "RESOURCE TYPE" property matches the requested resource type.
2. If no matching resource exists, the connector will notify the assigned SRM subscriber (Verizon Data Subscription Manager element) in order to create the required resources.

Once the ID assignment is completed, the front-end element will export a series of CSV files for the back-end(s) and collector(s) to import. It will then notify the respective back-end element(s) to process these files.

Back-end elements import info on the resources with their assigned IDs, and notify the respective collector elements of ID assignment completion

**Provisioning Workflow Overview:**

1. Collector elements export info on resources without IDs.
2. Collector elements interrogate the assigned front-end manager for ID assignment.
3. Front-end element imports info on resources without IDs.
4. Front-end element interrogates the DataMiner SRM module for resource IDs.
5. Front-end element exports info on resources with assigned IDs.
6. Front-end element notifies handling back-end element.
7. Handling back-end element imports info on resources with IDs.
8. Handling back-end element notifies the assigned collector elements that the ID request has been fulfilled.
9. Collector element imports info on resources with the assigned IDs.

## Usage

The CPE Manager's Data Display pages are not intended to be opened. Instead, the configuration should be performed through a Visio file.

When the manager element card is open in Cube, the CPE interface will be displayed with different chains providing a different topology view.

When the filters (on the left side) are filled in, the topology diagram view is displayed.

When a KPI item is selected in this diagram view, a pop-up window with parameters opens.

### KPIs

The following Key Point Indicators (**KPIs**) are calculated on the different levels, in addition to other KPIs for specific levels.

| **KPI**                                               | **Description**                                                                              |
|-------------------------------------------------------|----------------------------------------------------------------------------------------------|
| OTA Traffic *(for both forward and return streams)*   | Sum of Over the Air Traffic values for included entities.                                    |
| Traffic *(for both forward and return streams)*       | Sum of data Traffic values for included entities.                                            |
| C/N *(for both forward and return streams)*           | Average of remote Signal-to-Noise Ratio for included entities.                               |
| Es/N0 *(for both forward and return streams)*         | Average of Noise Spectral Density for included entities.                                     |
| Errors *(for both forward and return streams)*        | Sum of existing Errors for included entities.                                                |
| Error Periods *(for both forward and return streams)* | Average of Error Periods values of included entities.                                        |
| C/N0 *(for return streams only)*                      | Average of Carrier-Power-to-Noise Density Ratio of included entities.                        |
| Power Headroom                                        | Average of Power Headroom values of included entities.                                       |
| SLA Site Active                                       | Sum of included circuits where Hub Return OTA Traffic or Hub Forward OTA Traffic \> 26kbps.  |
| SLA Site Inactive                                     | Sum of included circuits where Hub Return OTA Traffic or Hub Forward OTA Traffic \<= 26kbps. |
| SLA Latency                                           | Average of Latency values of included entities.                                              |
| SLA Packet Delivery                                   | Average of Packet Delivery values of included entities.                                      |
| Circuit Up/Down Faults                                | Number of circuits with Up/Down fault.                                                       |
| Circuit Performance Faults                            | Number of circuits with this performance fault.                                              |
| Connectivity Faults                                   | Number of circuits with Network Connectivity fault.                                          |
| Eth1 GigE Operation Status Up                         | Number of DSLAMs with "Up" Eth1 GigE Operation Status.                                       |
| Eth1 GigE Operation Status Down                       | Number of DSLAMs with "Down" Eth1 GigE Operation Status                                      |
| Eth1 GigE Operation Status Other                      | Number of DSLAMs with "Other" Eth1 GigE Operation Status.                                    |
| Eth1 GigE In Rate                                     | DSLAM Eth1 GigE in bitrate in Mbps.                                                          |
| Eth1 GigE Out Rate                                    | DSLAM Eth1 GigE out bitrate in Mbps.                                                         |
| Eth2 GigE Administration Status Up                    | Number of DSLAMs with "Up" Eth2 GigE Administration Status.                                  |
| Eth2 GigE Administration Status Down                  | Number of DSLAMs with "Down" Eth2 GigE Administration Status.                                |
| Eth2 GigE Administration Status Other                 | Number of DSLAMs with "Other" Eth2 GigE Administration Status.                               |
| Eth2 GigE Operation Status Up                         | Number of DSLAMs with "Up" Eth2 GigE Operation Status.                                       |
| Eth2 GigE Operation Status Down                       | Number of DSLAMs with "Down" Eth2 GigE Operation Status.                                     |
| Eth2 GigE Operation Status Other                      | Number of DSLAMs with "Other" Eth2 GigE Operation Status.                                    |
| Eth2 GigE In Rate                                     | DSLAM Eth2 GigE in bitrate in Mbps.                                                          |
| Eth2 GigE Out Rate                                    | DSLAM Eth2 GigE out bitrate in Mbps.                                                         |
| Polling Mask Enabled                                  | Number of polling masked DSLAMs.                                                             |
| Polling Mask Disabled                                 | Number of polling unmasked DSLAMs.                                                           |

## Revision History

DATE VERSION AUTHOR COMMENTS
04/12/2018 1.0.0.1 HPE Skyline Initial version

## Notes

As the data pages are not accessible, to provide an easier way to configure the settings, a custom Visio file can be used.
