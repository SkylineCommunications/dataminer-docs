---
uid: Connector_help_RTRN_NI
---

# RTRN NI

With the **RTRN NI** application, a set of DMS systems can get provisioned from an Oracle database configuration (or Excel sheet).

This protocol is a virtual DMS configuration setup application, which reads out a database and provisions the DMS. All the data intended for other DMS systems will be transferred to the other DMS systems using the **Message Overview table** from the **Skyline DMP Replication Element**.

## About

The RTRN NI connector will periodically poll the DB for changes. A button can also be used to manually trigger a full reprovisioning.

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | No                      |

## Installation and configuration

### Creation

This connector uses a **virtual connection** and does not need any user input during element creation.

## Usage

### General

On this page, there are two partial tables with all the element configurations that were read out from the database. The **Elements Count** parameter below the tables allows alarm monitoring and trending.

There are several parameters for the configuration of the Excel import selection, which are originally displayed on the **Settings** page.

Several buttons on the page allow you to execute certain actions, such as starting an import from DB (database) or from an Excel file. This import will read out the DB or Excel file and update the tables and the DMS (elements, views and services will be created, updated or deleted as required). **The Import Progress (%)** bar will show the progress status of the import procedure. The **Import Status** text parameter will display an overview of what has changed during the import.

All the changes for a remote DMS will be transferred in subpackages per DMS. This is done by setting a string that contains this configuration package on the **Message Overview table** of the **Skyline DMP Replication** element that is present in the system. The latter is a replicated element of which the real element is running on a separate DMS. When this information package is added in the message table, the data will be transferred to the correct DMS through DataMiner replication. On the "remote" DMS system, Correlation and Automation will set this message value on the local **RTRN NI** element. This local element will then process the incoming changes and update the DMS accordingly.

At the bottom of the page, there is a button that opens a pop-up page for the **Protocols**. On this subpage, all the protocols & versions for each **Trade Mark** and **Model Code** pair need to be configured (with or without exceptions/SDK5 subdevices).

### Settings

This page allows you to configure the connection towards the Oracle Database. Parameters such as **Server IP**, **Port**, **Service Name(SID)**, **UserName** & **Password** must be filled in to make the connection with the Oracle DB. Parameters **Table Name** and **Delete Table Name** are required to determine from which database table DataMiner needs to query the data for the element configurations and for the approved deleted elements list.

Alternatively, if you do not have access to the oracle DB, you can instead import an Excel file. In order to select the correct configuration file and delete file, you then need to configure the **File Path**. After that, you will be able to select all available files in that folder.

The last single item that you can configure is the **Service Template Name**. By default, this value is set to *RTRN Service Template*. This is the service template that will be used to generate the services from the configuration DB.

The small table at the bottom of the page is used to look up the **Branch Name** with the correct replicated **Branch Manager element**. This link is needed to be able to transfer the configuration package to the correct remote DMS.

## Notes

The **Protocols Table** and the **Branch Manager Lookup Table** only need to be configured in the HQ (Headquarters) DMS. When the packages are transferred to the other, remote DMS systems, the protocol information will already be included.
