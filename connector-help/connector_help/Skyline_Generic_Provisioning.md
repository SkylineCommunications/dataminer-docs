---
uid: Connector_help_Skyline_Generic_Provisioning
---

# Skyline Generic Provisioning

Skyline Generic Provisioning is a **virtual manager connector** that can provision all **external** **DCF connections** in a DataMiner System.

## About

The connector is a **DCF provisioning manager** that allows the **import** and **export** of all external DCF connections of the whole system from/to a **CSV file**.

When the CSV file is imported, the connector creates the external DCF connections. While the connections are exported, the connector retrieves the external DCF connection data from the whole system and places this in the CSV file. Before the export, the connector validates the currently configured external connections and logs the ones that are not valid (because of a missing interface on one side of an external connection or because elements are paused or stopped).

When an import occurs, the connector gets the **DCF Type** and **DCF Grouping** based on the CSV file name in the following format: \[csvname\]-\[DCF Type\]-\[DCF Grouping\].csv (e.g.: Connections-Full-GroupingA.csv).

- **DCF Type** can either be *Full* or *Partial*:

- **Partial import**: Connections will be imported from the CSV file and added/updated in the system.
  - **Full import**: Connections will be imported from the CSV file. All the existing connections and their properties that are not in the CSV file will be removed from the system.

- **DCF Grouping** is used to "group" connections. It is not recommended to have the same connection(s) in different groupings. When this happens, there is a synchronizing mechanism that ensures that if the connection is removed, it will also be removed from the other groupings that were previously imported. It is the responsibility of the user to not import overlapping connections and keep the synchronization in mind.

### Version Info

| **Range**     | **Description**                                                                  | **DCF Integration** | **Cassandra Compliant** |
|----------------------|----------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version.                                                                 | No                  | Yes                     |
| 2.0.0.x \[Obsolete\] | This range is used by DataMiner Infrastructure Discovery and Provisioning (IDP). | No                  | Yes                     |
| 2.0.1.x \[Obsolete\] | Support for Unicode characters.                                                  | No                  | Yes                     |
| 2.0.2.x \[IDP ONLY\] | Increased minimum DataMiner version to 10.0.0.0 - 9517 CU6.                      | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation.

In range 2.0.0.x, DataMiner IDP takes care of the element creation.

## Usage

Below you can find a description of the usage for range 1.0.0.x. The usage from connector range 2.0.0.x onwards is explained in a separate section of the DataMiner Help.

### General

On this page, it is possible to enable or disable the **Debug** and the **DCF Debug Logging**.

The page also contains a page button with the **DCF Mapping Table**.

### Import

This page contains the **Import Folder** and **Import File** settings, which both need to be configured to make it possible to import a CSV file.

The page contains two buttons:

- **Refresh Files**: Refreshes the Import File parameter drop-down list with the files from the specified import folder.
- **Import:** Executes the import of the CSV file.

A **message information box** will show up after the CSV file import, mentioning how many connections were imported/read from that file.

The import requires that the CSV file contains the header definitions on the first line. The header may contain extra descriptions, and as such the connector will recognize the header as long as it contains the following:

- Connection Name
- Source Element Name
- Dest. Element Name
- Source Element Key
- Dest. Element Key
- Source Interface Name
- Source Custom Name
- Source Driver ParameterGroup ID
- Source Driver Table Key
- Dest. Interface Name
- Dest. Custom Name
- Dest. Driver ParameterGroup ID
- Dest. Driver Table Key
- Attribute Names
- Attribute Values
- Attribute Types

### Validation and Export

This page contains a parameter **Validation and Export**, which allows you to select one of the following options:

- **Only Validation**: Only validation will take place. This option will show in the **Status** box if the external connections are **valid or not**. This option does not export the connections to the CSV file.
- **Export**: The connector will validate and export the external connections **if** the **validation** of all connections was **successful**.
- **Force Export**: The connector will export the connections even **if invalid** **connections** were detected; however, **only valid connections** are included in the export. Invalid connections will be mentioned in the Status and will not be exported.

The **CSV File Export Folder**, **CSV File Name**, **DCF Grouping** and **DCF Type** are only used if the **Export** or **Force Export** options are selected. The **Export CSV File Name Preview** parameter will show a preview of the file name, taking into account the configured parameters.

In order to run the selected option, click the **Execute button**. The execution progress will be displayed with the **progress bar** and the Status will show **execution status messages**.
