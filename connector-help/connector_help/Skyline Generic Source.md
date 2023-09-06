---
uid: Connector_help_Skyline_Generic_Source
---

# Skyline Generic Source

The Skyline Generic Source connector can be used to create and manage sources as well as to create resources and profiles related to IP, ASI, SDIoIP, and SDI sources compatible with the SRM framework.

This connector uses a virtual connection to provide a standardized way of managing the sources in a network. It provides an extensive set of data that can be configured in every domain of every type of source.

## About

### Version Info

| **Range**            | **Key Features**                                                                                          | **Based on** | **System Impact**                                                                    |
|----------------------|-----------------------------------------------------------------------------------------------------------|--------------|--------------------------------------------------------------------------------------|
| 1.0.0.x              | Initial version.                                                                                          | \-           | \-                                                                                   |
| 1.0.1.x              | ProfileManagerHelper calls used.                                                                          | \-           | \-                                                                                   |
| 1.1.0.x              | Implemented support for the new workflow and data structure of profile definitions and profile instances. | 1.0.1.3      | Names and descriptions have been changed to match the profile definition parameters. |
| 1.1.1.x              | Profile Manager is now obsolete. The connector now only uses the Profile Helper.                          | 1.1.0.21     | The minimum DMA version is now 10.0.8. Upgrade if necessary.                         |
| 1.1.2.x \[SLC Main\] | DCF added to the Sources Table.                                                                           | 1.1.1.7      | \-                                                                                   |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.0.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.0.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.1.x   | No                  | Yes                     | \-                    | \-                      |
| 1.1.2.x   | Yes                 | Yes                     | \-                    | \-                      |



## Configuration

### Connections

Virtual Connection

This connector uses a virtual connection and does not require any input during element creation, other than a proper element name.

### Files

We recommend that you have the latest Skyline Generic Source **Functions.xml** file installed on the DMA along with this connector.

### Initialization

Check if an updated profile definition exists in the system. To do so, navigate to the **Source Management** page and use the **Check Generic Source Profile** button. If the status after the action reads *Found and Compatible*, the connector is all set up. Otherwise, perform the **Create/Update Profile** action to create or update the profile definition.

## How to use

Once first-time setup is complete as detailed above, you can:

- Ingest/import profile instances and populate the Sources table on the Source Management page.
- Create a resource by right-clicking the source in the Sources table and selecting Commit.

For detailed information about the different pages, refer to the sections below.

### General

The **tree control** on this page provides an overview of all sources and their configuration regarding audio, video, and data streams, their transport stream configuration, and IP settings.

With the **Add Source** button, you can add a source to the **Sources table**. Its IP settings will be enabled by default. Toggle buttons are available that allow you to enable or disable the source as an IP, ASI, SDIoIP, or SDI source.

The **right-click menu of the Sources table** provides access to the following additional options: Commit, Add Source, Duplicate Source, Add Audio, Add Video, Add Data and Delete Source(s).

To **create a resource**, right-click the relevant source in the Sources table and select **Commit**. The resource will then be available under Surveyor \> Apps \> Resources.

The status information in the **Status column** indicates whether all data has been fully committed to the DataMiner Agent or not. For a source to be used by a booking, it must have the status *Committed*. Other possible statuses are *Not Committed*, *Failed to Commit*, and *Committing*.

### Source Management

On this page, you can initialize generic source profiles.

The **Check Generic Source Profile** button analyzes the Profile Manager setup in DataMiner to check whether all profile definitions have been created. The **Profile Definition Status Check** will be updated with the corresponding status.

The **Create/Update Profile** button creates all profile definitions.

The **Ingest Profile Instances** button ingests all profile instances linked to the Generic Source Profile Definition and creates the necessary entries.

### Audio / Data / Video

These pages contain a table representation of all audio, data, and video data for each source, respectively.

Right-clicking an audio, data, or video configuration allows you to add a table row with the same source feed, remove a row, or duplicate a row.

### IP / ASI / SDIoIP / SDI / SAT

These pages contain a table with the IP, ASI, SDIoIP, SDI, and SAT settings for each source for which the relevant column (IP, ASI, SDIoIP, SDI, and SAT, respectively) in the Sources table is set to *Enabled*.

Right-click a table row to add a new row for the same source, remove the selected video feed, or duplicate the table row.

## Notes

If you **switch to a more recent version** of this connector:

1.  Recommit all resources.
2.  Go to the Source Management page and use the **Create/Update Profile** and **Check Generic Source Profile** buttons.
