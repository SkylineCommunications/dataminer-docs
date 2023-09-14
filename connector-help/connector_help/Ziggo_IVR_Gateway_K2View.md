---
uid: Connector_help_Ziggo_IVR_Gateway_K2View
---

# Ziggo IVR Gateway K2View

The Ziggo IVR Gateway creates entries in the IVR (Interactive Voice Recording) via K2View.

## About

The Ziggo IVR Gateway will receive commands from elements or Automation scripts that need to be sent to IVR via the K2View MiddleWare (using REST calls). Currently this connector creates, updates and closes tickets and receives the **Row ID** when a call succeeded.

The **log file** will contain additional logging (e.g. required data is missing, wrong SOAP response format, etc.). There is an **offload mechanism** available to store the created tickets on the local system as a CSV file.

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

## Installation and configuration

### Creation

#### HTTP main connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host:** The polling IP or URL of the destination.
- **IP port:** The IP port of the destination.
- **Bus address:** If the proxy server has to be bypassed, specify *bypassproxy*.

## Usage

### Status Overview

This page displays the **Ticket Status Overview** table, which contains the requests that have been sent to the Oracle Middleware, with their **Status** (*Succeeded* or *Failed*) and the **Reason of Failure** when applicable. The **TSO Action** column also indicates whether the request was an activation or deactivation. The **TSO Method** column indicates whether the request was generated automatically or manually.

The parameter **Number of Incidents** displays the number of entries in the **Ticket Status Overview** table. Trending is possible on this parameter, so that you can track the number of incidents during a certain time period.

### External Requests

This page displays the **External Requests Overview** table, which contains the received external requests. These external requests are waiting for an execution or a retry in case the previous execution failed.

### Configuration

On this page, you can configure different settings regarding SOAP and offload.

#### SOAP CONFIG

- **Username** and **Password** for SOAP calls that will be sent to the Oracle MiddleWare. The **Password** is optional.
- **Number of Retries** in case a SOAP call fails.
- **IVR Clear Delay** on automatic deactivation requests.

#### OFFLOAD CONFIG

The parameters **Max Amount of Incidents** and **Amount of Incidents to Offload** affect the **Ticket Status Overview** table:

- **Max Amount of Incidents** determines how many entries the table can contain before an offload will occur.
- **Amount of Incidents to Offload** determines the number of entries that will be offloaded.
  The number of remaining entries in the table is based on the formula **Max Amount of Incidents - Amount of Incidents to Offload**. As such, even if the table already contains more entries than the allowed maximum, the remaining entries after an offload will always be the same based on the configuration.

The other parameters are used to configure when the offload check will be done, how the offload files will be stored and how long those files will be stored.

In the **Offload Path** folder, subfolders will be created on a daily basis with the name *yyyy_MM_dd*. These subfolders will contain offload CSV files with the structure *Offload\_\<Hour\>\_\<Timespan\>,* where *\<Hour\>* is the starting hour of the offload files and *\<Timespan\>* is the value from the parameter **Offload File Timespan**.

With the parameter **Offload File Local Storage Period**, you can configure how long the offloaded files will be stored in the local system. If you set this parameter to *Disabled*, there will be no cleanup of the local system.

*LOG CONFIG*

The **Log Config** section allows the user to configure some settings about the Logging:

- **Status**: Enable or disable the logging mechanism;
- **Full Path**: Full directory where the log file will be stored, (including file name and extension). Preferably .txt or .csv extensions;
- **Maximum Number of Entries**: This is a rolling log, i.e., when the maximum number of entries is reached, the older entries (from the top) are removed, and the newer ones are appended to the bottom of the file.

#### IVR RULES

Pressing the **IVR Rules** page button will open a window with a table where a set of rules are defined. These rules will be read by an Automation script. If they match the intended logic, the Automation script will cause the IVR Gateway to be triggered when the **IVR** column is set to **YES**.

To create a rule, right-click and select **Add row.** You will then be able to fill in a number of options: **Event Tag \[IDX\]**, **Severity**, **Min Limit Customer**, **Max Limit Customer**, **Level** and **Group.** Rules will be considered correct if they follow the following logic:

- **IF** Event Tag \[IDX\] **AND** Severity **AND** Min Limit Customer **AND** Max Limit Customer **AND** Level

The IVR Rules table has a column called **Priority**. This editable parameter allows you to select the priority for each rule entry. The table is sorted automatically from the highest priority (value 1) to the lowest (number of entries in table).

- *IT IS NOT RECOMMENDED* to set multiple priorities simultaneously, as this may result in incorrect sorting. When a new rule is created, it will automatically receive the lowest priority and be placed at the bottom of the table.


