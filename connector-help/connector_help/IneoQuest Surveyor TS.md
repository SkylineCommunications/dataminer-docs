---
uid: Connector_help_IneoQuest_Surveyor_TS
---

# IneoQuest Surveyor TS

The **Surveyor TS** (Transport Stream) is a high capacity, scalable MPEG-2 Transport Stream monitor that provides comprehensive digital QoS monitoring providing more capacity in a smaller network footprint than prior generation solutions. It continuously monitors up to 20 Gbps of video traffic at line rate and in real time, measuring, trending and alarming on the TR 101-290 metrics for each program.

## About

A HTTP connection is used to retrieve information from and send information to the device. Data is received and sent in the JSON format. SNMP traps can be retrieved when this is enabled on the device.

### Ranges of the driver

| **Driver Range**     | **Description** | **DCF Integration** | **Cassandra Compliant** |
|----------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x \[SLC Main\] | Initial version | No                  | Yes                     |

### Supported firmware versions

| **Driver Range** | **Device Firmware Version**   |
|------------------|-------------------------------|
| 1.0.0.x          | SurveyorTS-1.03.00.313-121918 |

## Installation and configuration

### Creation

#### HTTP Connection

This driver uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *80 (http) or 443 (https)*
- **Bus address**: *bypassproxy.*

#### SNMP Connection

This driver uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: *8161*
- **Get community string**: *prbiqpub*
- **Set community string**: *prbiqpriv*

### Configuration of HTTP Connection (Data Extract)

In order to generate the token that will be used on the request sent to the device, the **User Name** and **Password** must be filled in on the **General** page.

## Usage

### General

On this page, you can enable or disable the polling of **Data Extract** and/or **Control API** data. In order to be able to poll Data Extract information, the **User Name** and **Password** must be filled in.

### Aliases

This page provides access to the **Flow Aliases** and **Program** **Aliases** available in the system.

The **Rediscover** button will delete and add again the alias automatically. It's also possible to **Rediscover All** the aliases by hitting the button under the table.

Modifications can be done through the following pagebuttons:

- Add Alias: Add a new alias to the **Flow Aliases** table. There are mandatory and optional fields.

- Modify Alias: Modify an alias. Please first select the alias to modify via the **Flow Alias Name**. It will load the current values. Note that some of the fields are mandatory.

- Deleted Aliases: New version introduces the possibility to keep an alias that is deleted from the **Flow Aliases** table. If the user wants to add it again, he can via the Re-Create button. It's also possible to delete it permanently.

- Comparison Flow Aliases:

- Tables can be cleared and content can be copied from the Aliases page.
  - You can also select just some rows from the **Flow Aliases** table and copy them to these tables
  - When a flow's **Availability** is *Missing* then it can be created back again by using the button **Create**. Only possible when a file is selected under the **Used Backup File Name**. If set to *None* then this won't work.

- Comparison Backup File Names:

- Two locations can be set:

  - - The **Local Archive Location** will be used to store the current backup file when changing from one **Used Backup File Name** to the other
    - The **Used Backup File Name Location** is used to store a backup from the current Used Backup File Name

  - To be able to select a **Used Backup File Name** you first need to generate the files by hitting the **Generate Files** button. It will store the contents of the **Comparison Flow Aliases** table and **Comparison Program Aliases** table in different files. The file name will be set by default with the *name of the element* followed by the *name of the table* and ending with the *port*. So if there are flows for both ports and each contain at least a program, 4 files will be created.

  - In order to have content on those files we first need to either press the **Import Current Aliases**, or add just the selected rows from the **Flow Aliases** table or we can also add them through the **Add Alias** page (change the **Flow Destination** to *Comparison Flow Aliases*).

  - If the files were generated correctly we need to add to the **Backup File Name** table and entry with the name of the element (the first part of the generated file's name). Each entry added to the **Backup File Name** table will be a new option on the **Used Backup File Name** parameter. Of course that after generating the default files they can be tweeked and the name can also be changed being aware that the name added to the **Backup File Name** will be the first part of those modified files.

### Templates

On this page, you can view all flow and program templates currently defined in the system.

### Flow Control

This page displays the **IGMP Flow Status** for the specified flow information.

### Port Details

This page displays the available **Ports** of the device.

### Census Data

On this page, the **Census Data** tableshows the list of flows and programs/assets that are currently being monitored in the system.

The page also displays information on **Current Alarms**, in a table that is filled in based on the incoming traps. Via the **Config** page button, you can determine whether rows will be removed or kept in this table when a Clear trap arrives. You can also configure the **List of Considered Events.** The **Event Name** of each of the traps will be validated against this list, and in case the event is part of it, the **Status** column for the relevant **Asset** in the **Census Data** table will change to *Failure* or *Ok*,depending on whether it is a Set or Clear trap.

New version introduces the **Override** page button which allows the user to see alarms being merged in the **Current Alarms** table. Each trap (Event Name and PIDs) that is received will be checked against the rules added in the **Alarm Override** table (**SNMP Event Name** and **Value** columns). If there's a match the alarm will get its Description (**Display Key \[IDX\]**) overriden as well as the **Severity** of the alarm. In case a trap is missed as soon as the **Alarm Log** is polled a verification is done to the **Current Alarms** table. Entries from the **Alarm Log** will be evaluted comparing the Event Name and PIDs to the **API Event Name** and **Column Value** columns.

Each match that is found is added to the **Matching Overrides** table. If the **Remove Cleared Alarms** is set to *Yes* under the **Config** page button, entries in the Matching Overrides table, will be also removed.

As there's a difference between the Event Name got from some traps and the ones got from the **Alarm Log**, for the sake of uniformization and to be able to make correct matchs, another table is available. That's the **Matching Event Names** table. In case there's a match then the **Event Name** taken to the **Current Alarms** table is the one from the **Trap Event Name** column.

Every change to the **Override Alarm Description/Severity** will trigger a clear of the **Current Alarms** and **Matching Overrides** tables. After the next poll of the **Alarm Log** missing items will be added again but only items generated since last poll.

The Event ID present in the **Current Alarms** table will be always the one from the last alarm received, event if there are 3 alarms matching a rule from the **Alarm Override** table.

### Quality Metrics

This page contains the **QoS Metrics** table, which contains metric information on bitrates, RTP Losses and Errors.

### Alarm Log

This page displays a list of past alarm events for a specified condition. The polling of this information can be *Enabled* by the **Poll Alarm Log** togglebutton. The amount of information in the table can be controlled via the **Clean Up Config** page button.

### Configurations

Under this page the user is able to Upload and Download an alias and template file.

### Web Interface

This page displays the web interface of the device. Note that the client machine has to be able to access the device, as otherwise it will not be possible to open the web interface.
