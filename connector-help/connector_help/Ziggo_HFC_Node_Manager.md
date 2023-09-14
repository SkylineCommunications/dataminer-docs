---
uid: Connector_help_Ziggo_HFC_Node_Manager
---

# Ziggo HFC Node Manager

This connector can be used to provision and maintain all node elements in a DataMiner System.

## About

This connector will make sure all node elements are present and have an up-to-date configuration in the DataMiner System.

All required information will be loaded from an import file. Currently only **Teleste AC9000** protocols are supported.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of Import File

On the **Configuration** page, the **Folder Path** and the **File Name** parameters need to be correctly configured to load the import file. By default, the **Folder Path** will be set to *C:\Skyline DataMiner\Documents\Ziggo HFC Node Manager\\*. The **File Name** needs to be the file name of the import file, including the file extension. Currently, the supported extensions are .csv, .json and .xml.

Clicking the **Load** button will read the file. When recently added files are shown in the **File Name** parameter drop-down box, you can force an update of the box by clicking the **Refresh Files** button.

## Usage

### General

This page contains the **Progress** parameter, the **Node Table**, the **Update Status** and the **Refresh** and **Update Nodes** buttons.

The **Node Table** represents all the nodes in the system.

When the **Update Nodes** button is pressed, it will create or update the node elements that were read from the import file. The progress can be tracked via the **Progress** parameter and the **Update Status** parameter.

The **Progress** parameter represents the percentage of the creation or update of the nodes that has been handled.

### Configuration

On this page, you can find the parameters for the configuration of the import file (refer to the "Configuration of Import File" section above for more detailed information).

The **Refresh Time** parameter is used to determine at which interval the automatic refresh of the **Internal Node Table**, **Node Table** and **creation of the elements** occurs. This is can be set to a value between 1 hour and 1 day.

When an element is not located in the import file, it can be automatically deleted whenever the update of the nodes happens. You can configure this behavior with the **Element Auto Deletion** parameter.

This page also contains the **Internal Node Table** and **DataMiner Agent Table** page buttons.

#### Internal Node Table subpage

This subpage contains a table representing the import file after it has been read out. In case templates are missing or views do not exist, warnings will be indicated in the **State** column.

#### DataMiner Agent Table subpage

This subpage contains a table listing all the DMAs in the system. The DMAs where elements can be created need to be enabled in the **Element Creation** column.

In addition, this subpage also contains the **Balancing Method** parameter, which determines on which DMA(s) elements will be created. The following three options are currently supported:

- **Fill**: Elements will be added on one Agent at a time, starting with the Agent with the lowest DataMiner ID.
- **Round Robin**: Elements will be distributed evenly across the available Agents.
- **Load**: The percentage of available element space will be checked, and elements will be added on the Agent with the most free space.

### Debug

This page contains the debug logging parameter. This is only to be used for debugging purposes.

## Notes

### Example import files

These examples translate into an element with "Test Element" as its name, "127.0.0.1" as the device IP, "Teleste AC9000" as the protocol, "Basic Alarms" as the alarm template, no trend template, to be added on DataMiner Agent 132456 and located in the "Test View" view.

#### CSV file

Node Name;IP Address;Protocol;Alarm Template;Trend Template;DataMiner Agent;View

Test Element;127.0.0.1;Teleste AC9000;Basic Alarms;;132456;Test View

#### JSON file

\[
{
"Node Name": "Test Element",
"IP Address": "127.0.0.1",
"Protocol": "Teleste AC9000",
"Alarm Template": "Basic Alarms",
"Trend Template": "",
"DataMiner Agent": 123465,
"View": "Test View"
}
\]

#### XML file

\<Elements\>
\<Element\>
\<AlarmTemplate\>Basic Alarms\</AlarmTemplate\>
\<DataMinerAgent\>123465\</DataMinerAgent\>
\<IpAddress\>127.0.0.1\</IpAddress\>
\<NodeName\>Test Element\</NodeName\>
\<Protocol\>Teleste AC9000\</Protocol\>
\<TrendTemplate /\>
\<View\>Test View\</View\>
\</Element\>
\</Elements\>
