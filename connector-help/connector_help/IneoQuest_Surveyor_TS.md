---
uid: Connector_help_IneoQuest_Surveyor_TS
---

# IneoQuest Surveyor TS

The **Surveyor TS** (Transport Stream) is a high-capacity, scalable MPEG-2 transport stream monitor that provides comprehensive digital QoS monitoring. It continuously monitors up to 20 Gbps of video traffic at line rate and in real time, measuring, trending, and alarming on the TR 101-290 metrics for each program.

An HTTP connection is used to retrieve information from and send information to the device. Data is received and sent in JSON format. SNMP traps can be retrieved when this is enabled on the device.

## About

### Version Info

| **Range**            | **Key Features** | **Based on** | **System Impact** |
|----------------------|------------------|--------------|-------------------|
| 1.0.0.x \[SLC Main\] | Initial version  | \-           | \-                |

### Product Info

| **Range** | **Supported Firmware**        |
|-----------|-------------------------------|
| 1.0.0.x   | SurveyorTS-1.03.00.313-121918 |

### System Info

| **Range** | **DCF Integration** | **Cassandra Compliant** | **Linked Components** | **Exported Components** |
|-----------|---------------------|-------------------------|-----------------------|-------------------------|
| 1.0.0.x   | No                  | Yes                     | \-                    | \-                      |

## Configuration

### Creation

#### HTTP Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP or URL of the destination.
- **IP port**: *80 (http) or 443 (https)*
- **Bus address**: *bypassproxy.*

#### SNMP Connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device.
- **Device address**: Not required.

SNMP Settings:

- **Port number**: *8161*
- **Get community string**: *prbiqpub*
- **Set community string**: *prbiqpriv*

### Configuration of HTTP Connection (Data Extract)

In order to generate the token that will be used in the request sent to the device, the **User Name** and **Password** must be filled in on the **General** page.

### Web Interface

The web interface is only accessible when the client machine has network access to the product.

## Usage

### General

On this page, you can enable or disable the polling of **Data Extract** and/or **Control API** data. In order to be able to poll Data Extract information, the **User Name** and **Password** must be filled in.

### Aliases

This page provides access to the **Flow Aliases** and **Program** **Aliases** available in the system.

The **Rediscover** button will delete the alias and automatically add it again. It is also possible to **Rediscover All** the aliases with the button under the table.

Modifications can be done through the following page buttons:

- **Add Alias**: Add a new alias to the **Flow Aliases** table. There are mandatory and optional fields.

- **Modify Alias**: To modify an alias, first select the alias to modify via the **Flow Alias Name**. The current values will be loaded. Note that some of the fields are mandatory.

- **Deleted Aliases**: It is possible to keep an alias that is deleted from the **Flow Aliases** table. If you want to add it again, you can do so using the **Re-Create** button. You can also delete the alias permanently.

- **Comparison Flow Aliases**:

- Tables can be cleared and content can be copied from the Aliases page.
  - You can also select some rows from the **Flow Aliases** table and copy them to these tables.
  - When a flow's **Availability** is *Missing*, you can create it again using the **Create** button. This is only possible if a file is selected under **Used Backup File Name**. If this is set to *None*, this will not work.

- **Comparison Backup File Names**:

- Two locations can be set:

  - - The **Local Archive Location** will be used to store the current backup file when changing from one **Used Backup File Name** to the other.
    - The **Used Backup File Name Location** is used to store a backup from the current Used Backup File Name.

  - To be able to select a **Used Backup File Name**, you first need to generate the files using the **Generate Files** button. The contents of the **Comparison Flow Aliases** table and **Comparison Program Aliases** table will be stored in different files. By default, the file name will be set to the name of the element, followed by the name of the table, and ending with the port. So if there are flows for both ports and each contain at least a program, four files will be created.

  - In order to have content in those files, you need to either first click **Import Current Aliases** or just add the selected rows from the **Flow Aliases** table, or you can also add them through the **Add Alias** page (change the **Flow Destination** to *Comparison Flow Aliases*).

  - When the files have been generated correctly, in the **Backup File Name** table, add an entry with the name of the element (the first part of the generated file's name). Each entry added to the **Backup File Name** table will be a new option for the **Used Backup File Name** parameter. After the default files are generated, they can be tweaked, and the name can also be changed. However, keep in mind that the name added to the **Backup File Name** must be the first part of those modified files.

### Templates

On this page, you can view all flow and program templates currently defined in the system.

### Flow Control

This page displays the **IGMP Flow Status** for the specified flow information.

### Port Details

This page displays the available **Ports** of the device.

### Census Data

On this page, the **Census Data** table shows the list of flows and programs/assets that are currently being monitored in the system.

The page also displays information on **Current Alarms**, in a table that is filled in based on the incoming traps. Via the **Config** page button, you can determine whether rows will be removed or kept in this table when a Clear trap arrives. You can also configure the **List of Considered Events.** The **Event Name** of each of the traps will be validated against this list, and in case the event is in the list, the **Status** column for the relevant **Asset** in the **Census Data** table will change to *Failure* or *Ok*, depending on whether it is a Set or Clear trap.

With the **Override** page button, you can see the alarms being merged in the **Current Alarms** table. Each trap (Event Name and PIDs) that is received will be checked against the rules added in the **Alarm Override** table (**SNMP Event Name** and **Value** columns). If there is a match, the description (Display Key \[IDX\]) and severity of the alarm will be overridden. In case a trap is missed, as soon as the **Alarm Log** is polled, the **Current Alarms** table is verified. Entries from the **Alarm Log** will be evaluated by comparing the Event Name and PIDs with the **API Event Name** and **Column Value** columns. Each match that is found is added to the **Matching Overrides** table. If **Remove Cleared Alarms** is set to *Yes (*via the **Config** page button), entries in the Matching Overrides table will be also removed.

As there is a difference between the Event Name retrieved from some traps and the one from the **Alarm Log**, for the sake of uniformity and to be able to make correct matches, another table is available, i.e. the **Matching Event Names** table. In case there is a match, the **Event Name** used for the **Current Alarms** table is the one from the **Trap Event Name** column.

Every change to the **Override Alarm Description/Severity** will trigger a clear of the **Current Alarms** and **Matching Overrides** tables. After the next polling of the **Alarm Log**, missing items will be added again, but only the items generated since the last polling.

The Event ID present in the **Current Alarms** table will always be the one from the last alarm received, even if there are 3 alarms matching a rule from the **Alarm Override** table.

### Quality Metrics

This page contains the **QoS Metrics** table, which contains metric information on bitrates, RTP Losses, and Errors.

### Alarm Log

This page displays a list of past alarm events for a specified condition. You can enable the polling of this information with the **Poll Alarm Log** toggle button. Via the **Clean Up Config** page button, you can control the amount of information in the table.

### Configurations

This page allows you to upload and download an alias and template file.
