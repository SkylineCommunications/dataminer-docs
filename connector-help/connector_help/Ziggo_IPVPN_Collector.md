---
uid: Connector_help_Ziggo_IPVPN_Collector
---

# Ziggo IPVPN Collector

The **Ziggo IPVPN Collector** connector collects data from different types of cable modems. The following modems are currently supported: **Ciena 3900 series**, **Cisco ME 3400**, **Cisco 1941**, **Cisco 887**, **Cisco ASR920**, **Cisco ISR1100 series**, **Huawei AR161**, **Huawei AR169**, **Telco Systems T-Marc 254** and **Juniper Networks SRX100/200**.

## About

This connector is part of a larger setup and works together with the **Ziggo IPVPN CPE Manager**, **Ziggo IPVPN Provisioning**, **Ziggo Modem Outage Check**, **Skyline IAM DB** and **Skyline IAM DB Provision** connectors. As part of this setup, an extra database (IAM DB) is required. This extra database contains tables and storage procedures that, together with the aforementioned connectors, form the complete Ziggo CPE solution.

An element will poll multiple modems at the same time through SNMP. Every modem gets polled once every 5 minutes to retrieve rapidly changing data and once every 24 hours to retrieve slowly changing data.

As the polling is multi-threaded and dynamic, no data traffic will be visible for this element in the Stream Viewer.

**Performance** and **enrichment** data are offloaded every 5 minutes and 60 minutes, respectively.

An outage check will be performed on a polled CPE if the following conditions are met:

- The **alarm description** after the aggregation contains "*CPE Down*".
- The CPE is of **access type** "*HFC*".
- The **CPE State** is equal to "*In Service*".

### Version Info

| **Range**       | **Description**                                                                        | **DCF Integration** | **Cassandra Compliant** |
|------------------------|----------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[Deprecated\] | Initial version.                                                                       | No                  | Yes                     |
| 1.0.1.x \[SLC Main\]   | Primary and Secondary BGP parameters are now called BGP Neighbor 1 and BGP Neighbor 2. | No                  | Yes                     |

### Supported modems

| **Range** | **Device**                                                                                                                                                            |
|------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 1.0.0.x          | Ciena 3900 series Cisco ME 3400 Cisco 1941 Cisco 887 Cisco ASR920 Cisco ISR1100 series Huawei AR161 Huawei AR169 Telco Systems T-Marc 254 Juniper Networks SRX100/200 |

## Installation and configuration

### Creation

#### SNMP Main connection

This connector uses a Simple Network Management Protocol (SNMP) connection.

The elements using this connector will automatically be created by the **Skyline IAM DB Provision** connector, so you will not need to specify anything during element creation. However, for the sake of completeness, the below fields are explained:

SNMP CONNECTION:

- **IP address/host**: 127.0.0.1. The IP will change dynamically at runtime, so the value in this field will not be used.

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*. All polled cable modems will use the same port and cannot be changed to one separate type.
- **Get community string**: The community string used when reading values from the device. This will be dynamically changed for every modem that is polled at runtime, so the value in this field will not be used.
- **Set community string**: The community string used when setting values on the device. As no sets are done on the cable modems, the value in this field will not be used.

### Configuration of settings

#### Alarming

To reduce the number of generated alarms, there can only be one alarm per modem.

This alarm can be configured through a CSV file, which must be placed in the documents folder for the Ziggo IPVPN Collector connector.

The fields in the CSV file are separated with a semicolon (";"). The order of a line indicates its priority. In case it is a field that represents a numeric value, either a range can be added, e.g. *\[10-14\],* or a comparison, e.g. *\>15*. In other cases, such as for a discreet value, the exact value must be specified. Fields that should not be validated for alarming should be left empty.

To upload an alarm configuration:

1. Go to the **Settings** page.
2. Click the **Refresh List** button to see the currently available files.
3. Select a file via the **Alarm Config File Name** parameter.
4. Click the **Import** button to load the file into the **Alarm Config** table.

   However, note that alarms will not necessarily immediately change when a new config is loaded. Alarm validation is only done when the modem is polled again.

The current alarm configuration can also be exported using the **Export** button. The exported file can then be found in the Ziggo IPVPN Collector documents folder. The file name consists of "*AlarmConfig\_*" followed by the current timestamp.

#### Offload

The settings of the offload mechanism can be accessed via the **Settings \> Offload** pop-up page.

On this subpage, you can enable the **collector's data offload** **mechanism**, using the **Offload State** toggle button (in the **General** section), and configure the folder where the **Performance** and **Enrichment** data files will be stored. If this folder does not exist, it will be created, if possible.

Two temporary CSV files are created in the folder (one for performance and one for enrichment data types). These files can be identified by their name, which ends with *"\_current"*, and should not be opened, edited or moved, in order to assure a successful offload.

The final offload files will have the following name format: "\[datetime\]\_\[dmaId\]\_\[elementId\].csv"

## Usage

### General

This page provides an overview of the current thread pool usage. This allows you to verify if communication is still running well or if there are threads that are taking a longer time to execute.

### Settings

Refer to the **Configuration of settings** section above.

### IAM

This page shows the current connection settings that are used to connect to the IAM database. These parameters are retrieved from the **Skyline IAM DB** element and cannot be modified. To execute provisioning again, click the **Provision** button. If, during the provisioning, the CPE State was changed for any CPE, an information event is generated.

### Offload Settings

On this page, in addition to the offload settings (see **Configuration of settings** **\> Offload** section above), you can find offload information regarding the latest **performance** **and** **enrichment** **data file**, such as:

- **Status**: If the generation of an offload file fails, this parameter will be set to *Fail*. Otherwise, it is set to *OK*.
- **Line Count**: Displays the number of lines of the last performance data offload file (header line not included).
- **Filename**: Displays the name of the last successfully offloaded data file.

### CPE

This page displays all CPE devices. However, it is not intended for operator use. Instead, the CPE user interface of the **Ziggo IPVPN Manager** element should be used.

### Interfaces

This page displays all CPE interfaces. However, it is not intended for operator use. Instead, the CPE user interface of the **Ziggo IPVPN Manager** element should be used.

### Offload

This page contains two tables where you can customize the offloaded KPIs related to **performance** data: **performance KPIs** and **QoS KPIs**.

#### Performance KPIs

This table contains a static list of all **performance KPIs** (a total of 44), and the following columns:

- **Offload Identifier**: The unique identifier of the performance KPI.
- **Description**: The name of the KPI.
- **State**: Whether the KPI is offloaded or not.

You can configure which KPIs will be offloaded to the performance data CSV file via the toggle button in the **State** column.

#### QoS KPIs

With this table, you can configure which interfaces will have their **QoS KPIs** offloaded. The interfaces are filtered by **Service Type**, **CPE Type** and **Interface Description** (all provisioned values). This filter is case-insensitive.

Via the context menu, it is possible to add a new row, delete one or more rows, enable or disable selected rows and clear the entire table.

Only users with **permission level 3** are able to access the context menu or edit existing rows.

The table itself contains 4 columns:

- **Service Type**: The service type associated with the interface(s).
- **CPE Type**: A drop-down list of model names for all supported modems.
- **Interface Description**: The interface name for which **QoS KPIs** are offloaded for the **CPE Type**. To offload all interfaces for the selected **Service Type** and **CPE Type**, set this parameter to *all*.
- **State**: Allows you to enable or disable the offload for the specified interface(s).

Additionally, for users with **permission level 3**, there are also two buttons to enable or disable all states, one for each table.
