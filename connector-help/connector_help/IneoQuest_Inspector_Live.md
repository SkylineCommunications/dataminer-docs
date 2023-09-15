---
uid: Connector_help_IneoQuest_Inspector_Live
---

# IneoQuest Inspector Live

The **Inspector LIVE** is a versatile acquisition element that combines both quality of service (QoS) and quality of experience (QoE) measurements, offering the visibility necessary to understand the status of the network and to improve the delivery of video services for both linear TV and adaptive bitrate (ABR) streaming delivery networks. Modular by design, Inspector LIVE offers video providers the ability to customize the interface based on their unique requirements.

## About

One HTTPS and one HTTP connection are used to retrieve information from and send information to the device. Data is received and sent in the JSON format. SNMP traps can be retrieved when this is enabled on the device.

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**    |
|-----------|---------------------------|
| 1.0.0.x   | iDVA-5.00.01.205-03162018 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Connections

#### HTTP Connection (Data Extract)

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *80*
- **Bus address**: *bypassproxy.*

#### HTTPS Connection (Control API)

This connector uses an HTTPS connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *443*
- **Bus address**: *bypassproxy*

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: *8161*
- **Get community string**: *prbiqpub*
- **Set community string**: *prbiqpriv*

### Initialization

In order to generate the token that will be used in the request sent to the device, the **User Name** and **Password** must be filled in on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## How to Use

The element that is created with this connector consists of the data pages detailed below.

### General

On this page, you can enable or disable the polling of **Data Extract** and/or **Control API** data. In order to be able to poll Data Extract information, the **User Name** and **Password** must be filled in.

### Aliases

This page provides access to the **Flow Aliases** and **Program** **Aliases** available in the system.

The **Rediscover** button will automatically remove an alias and add it again. You can also **Rediscover All** the aliases by clicking the button under the table.

You can make modifications with the following page buttons:

- **Add Alias**: Add a new alias to the **Flow Aliases** table. There are mandatory and optional fields.

- **Modify Alias**: Modify an alias. First select the alias to modify via the **Flow Alias Name**. The current values will then be loaded. Note that some of the fields are mandatory.

- **Deleted Aliases**: Keeps aliases that were deleted from the **Flow Aliases** table. You can add a deleted alias again with the Re-Create button or delete it permanently.

- **Comparison Flow Aliases**:

  - Tables can be cleared and content can be copied from the Aliases page.
  - You can also select just some rows from the **Flow Aliases** table and copy them to these tables
  - When a flow's **Availability** is *Missing,* you can create it again using the button **Create**. This is only possible when a file is selected under the **Used Backup File Name**. If this is set to *None,* this will not work.

- **Comparison Backup File Names**:

  - Two locations can be set:

    - The **Local Archive Location** will be used to store the current backup file when changing from one **Used Backup File Name** to the other.
    - The **Used Backup File Name Location** is used to store a backup from the current Used Backup File Name.

  - To be able to select a **Used Backup File Name**, you first need to generate the files using the **Generate Files** button. This will store the contents of the **Comparison Flow Aliases** table and **Comparison Program Aliases** table in different files. The file name will by default be set with the *name of the element* followed by the *name of the table*. If there are programs, 2 files will be created.

  - In order to have content in those files, you first need to either click **Import Current Aliases**, or add just the selected rows from the **Flow Aliases** table. You can also add them via the **Add Alias** page (change the **Flow Destination** to *Comparison Flow Aliases*).

  - If the files were generated correctly, you need to add an entry to the **Backup File Name** table with the name of the element (the first part of the generated file's name). Each entry added to the **Backup File Name** table will be a new option for the **Used Backup File Name** parameter. After the default files are generated, you can tweak them and also change the name; however, keep in mind that the name added to the **Backup File Name** will be the first part of those modified files.

### Templates

On this page, you can view all flow and program templates currently defined in the system.

### Flow Control

This page displays the **IGMP Flow Status** for the specified flow information.

### Port Details

This page displays the available **Ports** of the device.

### Northbound

This page allows you to configure a **Northbound** entity. Note that some of the fields are mandatory.

### Census Data

On this page, the **Census Data** table shows the list of flows and programs/assets that are currently being monitored in the system.

The page also displays information on **Current Alarms**, in a table that is filled in based on the incoming traps. Via the **Config** page button, you can determine whether rows will be removed or kept in this table when a Clear trap arrives. You can also configure the **List of Considered Events**. The **Event Name** of each of the traps will be validated against this list, and in case the event is part of it, the **Status** column for the relevant **Asset** in the **Census Data** table will change to *Failure* or *Ok*, depending on whether it is a Set or Clear trap.

Depending on the connector version, an **Override** page button can be available, which displays the alarms that are merged in the **Current Alarms** table. Each trap (Event Name and PIDs) that is received is checked against the rules added in the **Alarm Override** table (**SNMP Event Name** and **Value** columns). If there is a match, the Description (**Display Key \[IDX\]**) and **Severity** of the alarm will be overridden. In case a trap is missed, when the **Alarm Log** is polled, the **Current Alarms** table is verified. Entries from the Alarm Log will be evaluated by comparing the Event Name and PIDs with the **API Event Name** and **Column Value** columns.

Each match that is found is added to the **Matching Overrides** table. If **Remove Cleared Alarms** is set to *Yes* (via the **Config** page button), entries in the Matching Overrides table will be also removed.

As there is a difference between the Event Name in some traps and in the Alarm Log, the **Matching Event Names** table is used to ensure that correct matches can be made. If there is a match, the **Event Name** used for the **Current Alarms** table is the one from the **Trap Event Name** column.

Every change to the **Override Alarm Description/Severity** will trigger a clear of the **Current Alarms** and **Matching Overrides** tables. After the next polling of the **Alarm Log**, missing items will be added again, but only the items generated since the last polling.

The Event ID in the **Current Alarms** table will always be the one from the last alarm received, even if there are several alarms matching a rule from the **Alarm Override** table.

### Status

This page contains different tables displaying the alarm and error information for each active program/asset. The values reflect the state at the time of the query. "\_15" values are cumulative over the four discrete 15-minute intervals that make up each hour. The 15-minute values are reset at the beginning of each interval.

### Quality Metrics

This page contains the **QoE Metrics** table, which contains metric information on audio-specific and video-specific content. It displays flow-level metric information related to the delivery of content. The metrics provide 1-minute minimum/maximum/average values for each measurement.

### Alarm Log

This page displays a list of past alarm events for a specified condition. The amount of information in the table can be controlled via the **Clean Up Config** page button.

### SCTE-35

This page displays the SCTE-35 events.

### Configurations

This page allows you to **Upload** and **Download** an alias and template file.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
