---
uid: Connector_help_UPC_Nederland_VOD_Schedule_Importer
---

UPC Nederland VOD Schedule Importer

With this connector it is possible to import VOD (Video On Demand) schedules.

# About

The **UPC Nederland VOD Schedule Importer** will monitor multiple directories (that may or may not be local) for xml and csv files and will import the schedule information to the **VOD Workflow Application**.

The **XML** elements or **CSV** columns are mapped to fields of a schedule (such as: movie title, category, duration, etc...).

The mapping of the **XML** and **CSV** tags can be configured to be different for each directory.

After a file being processed it will be moved to a subfolder named "Succeeded" or "Rejected" depending if the file was correctly processed or not. A Information message will also be sent informing if the import was successful or nor for each file.

# Installation and configuration

## Creation

The **UPC Nederland VOD Schedule Importer** is a **Virtual** connector.

First the **XML** and **CSV** mapping have to be defined.

To configure a new **XML** mapping on the **Mappings page** set the parameter **XML Mapping Command** to

\#addAsset Title TagAsset Movie ID TagAsset Title ID TagProvider ID TagMovie File TagMovie Length TagFormat TagCategories TagStart Date TagEnd Date TagLicense Start TagLicense End TagAction Tag

To configure a new **CSV** mapping on the **Mappings page** set the parameter **CSV Mapping Command** to

\#addAsset Title TagAsset Movie ID TagAsset Title ID TagProvider ID TagMovie File TagMovie Length TagFormat TagCategories TagStart Date TagEnd Date TagLicense Start TagLicense End TagAction Tag

Currently the Asset Title ID and Movie File tags are not used in **CSV** files, those can be left empty but the separator must be present.

On the **Settings page** the following configurations have to be made:

- Set the **VOD Workflow Manager DMAI/EId** parameter with the **DMA_ID**/**Element_ID** for the **VOD Workflow Application**.
- Set the **Timer Frequency** to the desired value
- Set the **Username**, **Password** and **Domain** needed to access the directories to be read by the protocol.

To configure a new directory mapping on the **Directories page** set the parameter **Directory Command** to

\#addDirectory Full PathXML Mapping IDXCSV Mapping IDX

The files to be read should be on "Directory Full Path\Received" folder.

# Usage

## Directories Page

In this page it is shown a table with the directories to import from. The files to be imported should be on a folder called "Received" under the specified path. The table contains the columns:

- **Directory \[IDX\]** - The index of the row
- **Path** - The path to the folder with the "Received" folder containing the files to be imported
- **XML Mapping Id** - The row Id from the XML Mapping table to be used to map the **XML** elements to schedules
- **CSV Mapping Id** - The row Id from the CSV Mapping table to be used to map the **CSV** rows to schedules

It is also possible to edit the table by right clicking it to use the context menu to add a row, delete selected rows or clear the table.

## Mappings Page

In this page it is possible to see a table with the **XML Mapping** and the **CSV Mapping**. The tables contains the columns:

- **XML/CSV Mapping \[IDX\]** - The row Id of the **XML/CSV** mapping
- The remaining columns have the mapping as they appear on the **XML/CSV** files

It is also possible to edit the table by right clicking it to use the context menu to add a row, add a row with the default mappings, delete selected rows or clear the table.

## Failed Schedules Page

In this page it is possible to see the history of imports that failed with a time stamp and a reason:

## Settings Page

This page contains the credentials configuration to access the selected directories, which might not be local, and the time between each read of the directory in search oof new files to import. The time of the last import can be seen on the **Time Check** parameter.

## Commands Page

In this page it is possible to configure the **XML** and **CSV** mappings using the **XML Mapping Command** or the **CSV Mapping Command** parameter using the following commands:

- \#add*data...*
- \#editIDX*data...*
- \#deleteIDX

With *data...* being: Asset Title TagAsset Movie ID TagAsset Title ID TagProvider ID TagMovie File TagMovie Length TagFormat TagCategories TagStart Date TagEnd Date TagLicense Start TagLicense End TagAction Tag

In this page it is also possible to configure which directories will be read with the **Directory Command** parameter using the following commands:

- \#add*data...*
- \#editIDX*data...*
- \#deleteIDX

With *data...* being: Directory Full PathXML Mapping IDXCSV Mapping IDX.
