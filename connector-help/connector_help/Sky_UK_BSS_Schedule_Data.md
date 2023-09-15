---
uid: Connector_help_Sky_UK_BSS_Schedule_Data
---

# Sky UK BSS Schedule Data

**Sky UK BSS Schedule Data** protocol will show the Schedule Data found in the predifined table from the database.

## About

When the connection information is entered correctly, the TX_MONITOR_VIEW table will be loaded every hour (adjustable with **Timer base**) from the Oracle database. This connector uses a virtual connection to poll the data from the database and a HTTP connection to poll the system list from VICC API. It will generate child elements (DVEs) for each bus, according the system that is configure - that can be found in 'Exported Connectors' section. The table data is filtered by bus and showed in the correspondent DVE.

### Version Info

| **Range** | **Description**                                                                    | **DCF Integration** | **Cassandra Compliant** |
|------------------|------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version.                                                                   | No                  | Yes                     |
| 1.0.1.x          | Overview table, less information for SLElement and less data polled from database. | No                  | Yes                     |

### Exported connectors

| **Exported Connector**                                                                            | **Description**                                                             |
|--------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------|
| [Sky UK BSS Schedule Data - Bus](xref:Connector_help_Sky_UK_BSS_Schedule_Data_-_Bus) | It shows the current event data from TX_MONITOR_VIEW for that specific bus. |

## Installation and configuration

### Creation

Virtual connection

This connector uses a virtual connection and does not require any input during element creation

#### HTTP connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The pooling IP of the device e.g. *bcam.broadcast.bskyb.com*
- **IP port**: The IP Port of the device e.g. *80*
- **Bus address**: This should be composed by the **Automation System** to monitor and if proxy server needs to be bypassed, please specify *byPassProxy*. e.g. *byPassProxy;SYSTEM1*

### Installation

For the installation of this application, just create an element using this protocol.

## Usage

### General

This page shows the parameters related to the DVEs exportation:

**System** parameter shows which System is this element monitoring.

**Buses Table** shows a table with every different buses detected in TX_MONITOR_VIEW, its **Polling Mode** (can on ON or Off), its **System Name** and its **Custom Name**. The Buses with Polling Mode ON are also present on Enabled Buses table and its data will be exported to a DVE, which name will match Custom Name column.

**Enabled Buses** table shows all the buses that will be exported as DVEs, its System Name, its DVE ID, internal ID in DataMiner, its Custom Name, which will be the DVE Name and its Status. Status can be Off-Air - if the current event in Schedule has Type equal to "SUSP" - or Off-Air - if the current event in Schedule has Type different from "SUSP".

**Automatic Removal** toggle button allows the user to configure if the DVEs will be automatically deleted when Polling Mode is set to OFF or they just will be flagged as 'Removed' in the DVE Status (Enabled Buses) column and can be removed afterwards.

It is also possible to find in this page action buttons:

**Enable All System DVEs** will set **Polling Mode** to ON for all the buses where **System Name** matches the **System** configured on this element and generate the DVEs, except for buses which are included in more than one System.

**Remove All System DVEs** will set **Polling Mode** to Off for all the buses where **System Name** matches the **System** configured on this element and delete the DVEs, except for buses which are included in more than one System**.**

**Delete All Removed DVEs** will delete all the DVEs that have 'Removed' DVE Status.

Please note that buses which are included in more than one System need to be controled by its Polling Mode toggle button. Actions executed by Enable/Remove All System DVEs won't affect these buses.

### Database Settings

This page contains the configuration parameters Database Name, Server IP, Port, User Name and Password, these are needed to connect to the Oracle database.

For Database Name, there is a discrete value named Server=Dedicated, which will drop the SID from the connection string and add SERVER=DEDICATED to CONNECT_DATA.

There is also available parameters related to the polling mechanism and an action button:

**DataBase State**, which shows the state of the communication with the database (Disabled, Finished, Polling or General Error);

**DataBase Message** will show a message when DataBase State is General Error.

**Polling State** shows if the polling mechanism is Enabled or Disabled.

**Update** action button will poll the database when clicked.
