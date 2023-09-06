---
uid: Connector_help_SingTel_Media_Asset_Manager
---

# SingTel Media Asset Manager

This connector orchestrates the Live-to-VOD and MAM workflows for SingTel using Process Automation.

## About

### Version Info

| **Range**            | **Key Features**                          | **Based on** | **System Impact** |
|----------------------|-------------------------------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Support for L2V workflow and MAM workflow | \-           | \-                |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### Virtual Connection - Main

This connector uses a virtual connection and does not require any input during element creation.

### Initialization

When you have created the element, you will still need to:

- Configure the workflow needed for the VOD and MAM.
- Configure the **Configuration subpages** of the **General** page to have all the credentials, workflows, and logic needed for the VOD and MAM to work.

### Redundancy

There is no redundancy defined.

## How to use

This connector watches several directories for new files. Once a new file shows up, and based on its location and type, the connector will perform specific actions:

| **Directory**               | **File Type**    | **Action**                                                                              |
|-----------------------------|------------------|-----------------------------------------------------------------------------------------|
| ForeTV                      | L2V              | Execute L2V workflow. Create/update asset DOM instance.                                 |
| ForeTV                      | MAM              | Create/update asset DOM instance. Link files with asset if applicable.                  |
| Content Provider (multiple) | Movie file (.ts) | Create/update file DOM instance.Link files with asset if applicable.Start MAM workflow. |

On the **General** page of this connector, you can:

- Start VOD workflows or process asset files using the **Received Fore TV Files** table.
- Monitor which workflow tasks are currently being processed using the **Running Activities** table.
- Access the **Configuration pages**. You can find more information about these pages below.

### Credentials

In the **Credentials** table on this page, you need to configure the credentials for the directories that will be used by the workflows. You can right-click the table and use the context menu to add or remove entries.

When looking for the credentials for a directory, the connector will search the table for the path that is the closest to the requested directory and use those credentials.

### Extraction Configuration

On this page, you can configure the **Actus Configuration** used for the extraction parts in the workflow.

### Transcoding Configuration

On this page, you can configure the Telestream data used for the transcoding parts of the VOD and MAM workflow.

The **Telestream Workflow Identifiers** table is used to configure which Telestream workflow will be used based on the input data.

The **Telestream Workflow Configuration**, **Telestream Workflow Medias**, and **Telestream Workflow Variables** are used to configure the Telestream workflow logic.

In the **Variables** and **Medias** table, placeholder names can be used in the **Value** column. If you specify "\<outputfilename\>", the connector will replace this placeholder with the VOD/MAM workflow's output file name.

### QC Configurations

This page allows you to configure the test plans to use QC parts of the workflow.

### MAM Configurations

This page allows you to configure the various directories used to detect new MAM files. It also allows you to configure the various file paths used by the workflow.
