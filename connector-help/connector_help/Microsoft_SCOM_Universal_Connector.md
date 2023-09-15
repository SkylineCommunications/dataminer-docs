---
uid: Connector_help_Microsoft_SCOM_Universal_Connector
---

# Microsoft SCOM Universal Connector

This connector is used to retrieve the alarms from the **Microsoft SCOM Universal Connector**.

## About

This connector communicates with the Microsoft SCOM Universal Connector to retrieve the alarms from the Microsoft SCOM system. The alarms are displayed in a table. Users can acknowledge and edit those alarms.

The SCOM 2007 Universal Interop Provider must be installed on the DMA for this connector to be operational.

## Installation and Configuration

### Creation

**Virtual Connection**

This connector uses a virtual connection and does not need any user input.

## Usage

This connector contains two pages.

### General

On this page, you can select the **Path to the UnvEvents Folder**, which is the folder were all the .xml files used to exchange alarms will be placed. The folder is called "*UnvEvents*" and must contain the folder "*FromOpsMgr*".

The default installation folder for the Interop Provider is: "*C:\Program Files (x86)\System Center Operations Manager 2007 Providers\Operations Manager 2007 Connector to Microsoft Universal Provider\UnvEvents\\*"

### Alerts

This page contains a table displaying all the alerts of the SCOM system. The table contains different columns: **Name**, **Time of Last Event**, **Severity**, etc.

Only two columns are editable: **Resolution State** (to close an alarm), and **EventId**.
