---
uid: Connector_help_British_Telecom_GNMS
---

# British Telecom GNMS

This connector is used to request alarms and populate an Alarms table, so that alarms are generated in the Alarm Console.

The connector requests the alarms and contacts from an Oracle database.

The first time the element starts up, all alarms will be requested, processed, and added in the **Alarms** table. This can take a while. The contacts are also requested, and the **Service Contacts** table is filled in.

New alarms are requested and processed every minute. The timers to request the new alarms and contacts are activated after the time specified in the **Time Before Starting Timers** parameter.

After a restart of the element, the active alarms are populated in the Alarms table so that it is the same as before the restart.

## About

### Version Info

| **Range** | **Description** | **DCF Integration** | **Cassandra Compliant** |
|-----------|-----------------|---------------------|-------------------------|
| 1.0.0.x   | Initial version | No                  | Yes                     |

## Configuration

### Connections

#### Virtual database connection

This connector uses a virtual connection and does not require any input during element creation.

### Configuration of the Database

For the connector to be able to connect to the Oracle database, on the **Database Configuration** page, specify the **Database Name, First Server IP, Second Server IP, User Name**, and **Password**.

## Usage

### Alarms

This page contains a table listing all the active alarms.

Via the page button **IM Ref Configurations**, you can configure the IM Ref Customers of Interest. Those are used to filter out matches with change IDs coming from the Remedy ORCA connector. When a match is found with the **CI Name**, **Service End Point A**, or **Service End Point B**, the change ID will be used in the **IM Ref** column. This value will also be available as an alarm property (*IM Ref*).

### Contacts

On this page, the **Service Contacts** table lists the contacts. Above the table, the **Load Contacts** button is available, which can be used to retrieve the contacts immediately.

### Database Configuration

This page contains the parameters that must be configured to connect to the Oracle database. In addition, The **Time Before Starting Timers** parameter determines the timespan after startup of the element before the new alarms and contacts are requested from the database and the corresponding tables are filled in.
