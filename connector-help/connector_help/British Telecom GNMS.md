---
uid: Connector_help_British_Telecom_GNMS
---

# British Telecom GNMS

This protocol is used to request alarms and populate an Alarms table so alarms are generated in the alarm console.

## About

This protocol requests the alarms and contacts from an Oracle database. It is important that the Database Configuration parameters are filled in on the correspondig page.
The first time the element starts up, all alarms will be requested, processed and populated in the **Alarms** table. This can take a while.
Also the contacts are requested and a **Service Contacts** table is populated.
New alarms are requested and processed every minute.
The timers to request the new alarms and contacts are activated after a time that is specified in the parameter **Time Before Starting Timers**.
After a restart of the element, the active alarms are populated in the Alarms table (like it was at the moment before restarting).

### Ranges of the driver

| **Driver Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### Virtual database connection

This driver uses a virtual connection and does not require any input during element creation.

### Configuration of the Database ...Database Name, First Server IP, Second Server IP, User Name and Password must be filled in to make the connection with the Oracle database.

## Usage

### Alarms

On this page there is an **Alarms** table that contains all the Active alarms.

With the popup button **IM Ref Configurations...** you can configure the IM Ref Customers of Interest. Those are used to filter out matches with Change IDs coming from the Remedy Orca driver. When a match is found with **CI Name**, **Service End Point A** or **Service End Point B**, the Change ID will be used in the **IM Ref** column. This value will also be available as an alarm property. (**IM Ref**)

### Contacts

On this page there is also a **Service Contacts** table that contains the contacts. Above the Service Contacts table, there is a **Load Contacts** button to retrieve the contacts immediately.

Database Configuration
On this page, there are the parameters that are needed to connect with the Oracle database.
The **Time Before Starting Timers** parameter is the timespan after startup of the element before the new alarms and contacts are requested from the database and the corresponding tables are populated.
