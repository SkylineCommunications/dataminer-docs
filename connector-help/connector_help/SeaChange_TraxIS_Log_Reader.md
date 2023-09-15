---
uid: Connector_help_SeaChange_TraxIS_Log_Reader
---

# SeaChange TraxIS Log Reader

The SeaChange VoD Platform is used by broadband and broadcast television operators in order to offer advanced multi-platform and personalized TV services to their subscribers. This platform includes, among others, the PRODIS-TRAXIS integrated video-on-demand back office solution for asset ingest, productizing, content propagation, catalogue generation and transaction handling.

## About

The SeaChange TraxIS Log Reader connector **processes log files** from the video-on-demand (VoD) platform in order to mitigate platform issues.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a virtual connection and does not require any input during element creation. The connector only supports shared folders.

## Usage

### General

This page consists of three sections:

- **Server**: To use a shared folder, fill in the necessary credentials in the parameters **Username**, **Password**, **Network Domain** and **Network Drive Path**.

- **Offload**: Allows you to define whether the connector should look for new files in the shared folder, using the **Offload Enabled** parameter. Also allows you to define the **Amount Of Files to Process At Once** as well as the **Offload Directory**.

- **Traxis Settings**:

  - **Keep Records For**: Determines for how many days locations are kept in the database.
  - **Traxis Backward Limit**: The log files before this parameter limit will not be displayed in the Monitoring Table.

### Traxis Monitoring

This page consists of a number of monitoring parameters, the Monitoring Table, and parameters related to the filter of this table.

The following monitoring parameters are available:

- **Last Copied Date**: The date of the last copied file.
- **Last Read Date**: The date of the last processed file.
- **Processing Task**: The current status of the connector, which can be *Looking For New Files*, *Processing Files* or *Decompressing Files*.
- **Files To Be Decompressed**: The total number of gzip files present in the default folder *C:\Skyline DataMiner\Documents\Traxis\Offload*.
- **Decompressed Files**: The total number of decompressed files.
- **Process GZip Files**: This button can be used to search for new files.

The **Monitoring table** displays usage statistics of VoD sessions started by users. The following metrics are available:

- **CRID_IMI**: In the TV-Anytime standard, the Content Reference Identifier (CRID) is a reference to particular content regardless of certain temporary features such as location info, cost, format or encoding details. Along with the Instance Metadata Identifier (IMI), this makes it possible to unambiguously identify a particular feature such as format, quality, audio encoding, etc.
- **Setup Counter**: Displays the number of times a customer has started playing back a VoD asset.
- **Play Scale Equal To One Counter**: Shows user trick mode usage frequency equal to one.
- **Play Scale Not Equal To One Counter**: Shows user trick mode usage frequency not equal to one.
- **Teardown Counter**: Displays the number of times the end of the stream was reached or the user exited (a bookmark call is made immediately afterwards to save the last position of the user). This should match the number of setup calls. If these are too different, this means a large number of streams are not getting set up properly.
- **Announces** **Counter**: Displays the number of end-of-stream announcements when a user rewinds all the way to the beginning.
- **DateTime**: The date and time of the file.
- **Notice**: Indicates any errors on the platform, which may be useful to debug any platform issues.

Finally, the **Filter Source** parameter allows you to define the DMA_ID/ELEMENT_ID/TABLE_ID/COLUMN_IDX in order to filter the CRIDs of the Monitoring table.
