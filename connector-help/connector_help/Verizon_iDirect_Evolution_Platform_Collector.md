---
uid: Connector_help_Verizon_iDirect_Evolution_Platform_Collector
---

# Verizon iDirect Evolution Platform Collector

The **Verizon iDirect Evolution Platform Collector** connector can be used to collect data from the iDirect Evolution Platform. This platform is an IP-based satellite communication system, with a product line consisting of a universal hub and network management system, comprising a series of line cards, operating software and a portfolio of both dedicated and dual-mode remotes.

## About

In elements using this connector, all information about an iDirect NMS is retrieved from MySQL databases and displayed accordingly. All iDirect installations consist of two databases (schemas): "nms" with all the configuration data, and "nrd_archive" with all the events and statistics. Depending on the size of the system, these databases can be placed on one or multiple MySQL servers, each one with a different IP address. **IP addresses and credentials for access to the databases** should be provided in the **Database Configuration table** on the Configuration page of the element. For more information, refer to the **"Configuration" section**.

The connector also uses data from the Verizon VSat Database, which contains proprietary information about the circuits deployed through the Verizon Satellite Network, with commissioning details and monitoring acceptance metrics. This database is queried and provisioned by elements running the **Verizon VSat Database Platform protocol** (1 per DMA), which will generate **provisioning files** with the necessary circuit information from the VSat database. Elements running the **iDirect Evolution Platform Collector** will retrieve the necessary information from the corresponding provisioning file and handle it accordingly. The connector also exports the configuration data of remotes in XML files to be used by the VSat elements. For more information, refer to the **"Collector Setup" section**.

The connector supports the triggering and clearing of tickets from the Verizon system by generating DataMiner information events. This mechanism follows Verizon's proprietary SLA (Service Level Agreement) settings, and such settings stay synchronized with other elements in the DMS through the use of information stored in the DataMiner **Profile Manager** app. In addition to being able to perform bulk updates from the Profile Manager app, the solution includes the possibility of adding/editing/removing entries of the different SLA protocol parameters.

The protocol contains a mechanism to obtain unique numeric IDs for entities used in the CPE aggregation solution. In order to do so, it exports CSV files for each type of entity that needs to have IDs assigned, and imports the corresponding CSV files with the responses from the back-end manager elements.

As this is a virtual connector, **no data traffic** will be shown in the Stream Viewer.

### Version Info

| **Range**     | **Description**                                                          | **DCF Integration** | **Cassandra Compliant** |
|----------------------|--------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Obsolete\] | Initial version.                                                         | No                  | Yes                     |
| 1.0.1.x \[Obsolete\] | Display keys in alarm tables updated to show a more user-friendly value. | No                  | Yes                     |
| 1.0.2.x              | Main KPIs updated.                                                       | No                  | Yes                     |
| 1.0.3.x              | Fault/alarm functionality removed.                                       | No                  | Yes                     |
| 1.0.4.x \[SLC Main\] | Fix of the way events are handled towards native fault handling.         | No                  | Yes                     |

## Installation and configuration

### Creation

This connector uses a **virtual** connection and does not require any input during element creation.

### Configuration

Additional settings need to be specified in the **Database Configuration** table on the **Configuration** page of the element. All iDirect databases containing the data that must be polled need to be added in this table:

- Rows can be added/deleted in the table via the right-click menu.
- For each iDirect hub, exactly one config database and one or more statistics databases must be specified. Even when the config and statistics database have the same IP address, two entries need to be added to the table.
- For each database, the **Server** IP address, **Username** and **Password** must be specified. In addition, you have to indicate whether the database contains configuration or statistics (archive) data. Database polling can be enabled or disabled for each entry, and the polling interval can be configured as well.
- The **DB Hub ID** column indicates which iDirect NMS the database belongs to. You can enter the Hub ID yourself, but keep in mind that each hub must have a unique ID, and all databases that belong to the same iDirect hub must have the same ID.
- The **NMS Name** has to be entered in order for the connector to do any subsequent logic related to the NMS (such as aggregation at that level).

In order to obtain unique numeric IDs for entities used in the CPE aggregation process, the following settings need to be specified:

- On the **Collector Setup** page, a **path** must be provided for the import/export of CSV files with ID requests, and **toggle buttons** for both processes must be enabled.
- On the **Notify Registration** subpage, in the **Frontend Registration** table, an entry must be added with the DMA ID/Element ID of the CPE manager (front-end) element handling the ID requests from collectors.

## Usage

### General

This page contains general information on the system, such as the number of **Active Remotes**, **Inactive Remotes**, **Active Networks**, **Hub Forward** and **Hub Return**.

### Remotes

This page contains the **Remotes Overview** table, with specific information and metrics for all the remote terminals present in the system.

The page includes the following page buttons:

- **Remotes Events**: Displays the **Remotes Events Overview**, with detailed information on each alarm in the system related to remotes.

### BUC & LNB

This page contains the following tables:

- **LNB Table**: Contains all the configuration data related to the low-noise block down-converter
- **BUC Table**: Contains the information for the block up-converter.

These tables include the parameters **Start** **Frequency**, **Stop Frequency**, **Gain** and **Frequency Translation**.

### Hub Networks

This page contains the **Hub Networks Overview** table, with configuration and statistical information for the networks present in the system (with a "network" being a virtual concept hosting the logical expansion of a circuit).

### Hub Forward

This page contains the **Hub Forward Overview** table, with specific data for the Hub Forward entities. The table includes fault information and the **Event Suppression** column, which allows you to set the percent of circuits for each hub that, if they contain alarms of the same type, will generate the corresponding infrastructure alarm for the hub.

### Hub Return

This page contains the following tables:

- **Hub Return Carriers**: Contains configuration and statistical data related to each return carrier.
- **Hub Return Overview**: Contains the same type of information for the Hub Return entities (also referred to as *Inroute Groups*). The table also includes fault information and the **Event Suppression** column, which allows you to set the percent of circuits for each hub that, if they contain alarms of the same type, will generate the corresponding infrastructure alarm for the hub.

### Line cards

This page contains the **Line Cards Table**, with configuration and statistical information for each line card. These line cards are modular electronic circuits designed to fit on a separate printed circuit board (PCB) and interface with a telecommunications access network.

The table also contains fault information. The **Event Suppression** column allows you to set the percent of circuits for each line card that will generate an infrastructure alarm **information event** for the **chassis** if they contain alarms of the same type and such a type of alarm is also present in the line card. The corresponding information events for each circuit will be suppressed in that case.

Via the **Linecards Events** page button, you can access the **Linecards Events Overview**, with detailed information on each alarm event related to line cards.

### Protocol Processors

This page contains the **Protocol Processor Blades** table, with the network configuration for each server, including the **Tunnel Address**, **Tunnel Mask**, **Upstream Address** and **Upstream Mask**.

Via the **PP Events** page button, you can access the **PP Events Overview** table, with detailed information on each Protocol Processor Blade-related alarm event.

### Chassis

This section contains the **Chassis Table**, with configuration data for each chassis, specific faults information and the **Event Suppression** column, which allows you to set the percent of line cards for each chassis that will generate the corresponding infrastructure alarm **information event** for the chassis if they contain alarms of the same type and such a type of alarm is also present in the chassis. The corresponding information events for each line card will be suppressed in that case.

Via the **Chassis Events** page button, you can access the **Chassis Events Overview**, with detailed information about all the alarms related to the chassis.

### Circuits

This page displays the **Circuits Overview** table, which contains all the information related to the circuits (with a "circuit" being the network part of the system that resides at the customer site).

The table stores different kinds of data:

- Configuration information like **Management IP**, **PING Status**, **VSat Acceptance Status, TM Workgroup** and **Outage Contract** info.
- Statistics information like **SLA Latency**, **SLA Packets Delivery**, **Uptime**, as well as data related to the Hub Return and Hub Forward each circuit belongs to, such as **Traffic**, **Errors** and **C/N** (Signal-to-Noise ratio).
- Fault information for each specific fault type.

You can dynamically verify the **ping status** of a specific circuit by right-clicking the table and selecting **PING Circuit** in the context menu. Note that the connector also automatically implements this functionality for all the circuits every 12 hours.

### Configuration

This section contains the **Database Configuration** table, which stores the required settings for each **Verizon iDirect Evolution database** used by the system. More information about the usage of this table can be found in the **Configuration** section above.

The page also includes page buttons to the following subpages:

- **DB Polling Config**: This page allows you to **enable or disable** **polling** of each type of database in the system (configuration and statistics) by triggering the controls **Config Polling Status** and **Stats Polling Status**. It also allows you to define the polling interval for each database.
- **DB Polling Status**: This section displays different metrics such as **Status** and **Execution Time** to measure the quality of the polling of each database type. It also contains controls to force database polling (the buttons **Get Config** and **Get Stats**).
- **PING Config**: This page contains controls to configure ping settings for the circuits, such as **PING Status**, which allows you to enable/disable this functionality, and **VLAN**, which allows you to select the ID of the VLAN to be used for the ping, based on the data from the provisioning files related to the VSat database.
- **SLA and Fault Config**: This page contains controls to manage the polling of the SLA and fault parameters from the Profile Manager.

### Collector Setup

This page contains the settings to manage the provisioning files mechanism. The connector periodically exports configuration data for remotes, by updating an XML provisioning file on the DMA server, and retrieves information from the Verizon VSat Database contained in another provisioning file in JSON format. These mechanisms can be configured using the controls on this page.

The **File Handling** parameter can be used to enable or disable both provisioning mechanisms, whereas the **File Import** and **File Export** parameters can be used to enable or disable a specific mechanism.

For each process, **File Path** controls allow you to specify the directory where the provisioning files should be located and a **Processing Time** parameter allows you to configure the interval for automatic processing.

The page also contains buttons that can be used to manually trigger each of the provisioning mechanisms.

On the right-hand side of the page, you can find the controls for the ID Notify mechanism:

- The **ID Import Settings** section contains controls to enable/disable the process of importing IDs from CSV files, as well as the path where the files are located and the current status of this process.
- The **ID Export Settings** section is similar to the ID Import Settings section, except that its controls apply to the process of exporting CSV files with ID requests.

The page contains page buttons to the following subpages:

- **Notify Registration**: This page contains the **Frontend Registration** table, where you should add an entry with the DMA ID/Element ID of the front-end element in the CPE solution. This is the element in charge of handling the requests for ID assignment coming from all the collectors.
- **Notify Settings**: This page contains parameters that allow you to manage and monitor the ID Notify process. **Time Out Timer** allows you to set the maximum time the collector should wait for a response from the CPE manager before it sends another ID Notify request. The **Reset** button performs a full ID Notify request for all the entities in the collector.
