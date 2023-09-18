---
uid: Connector_help_UPC_Nederland_LVM_Service_Overview_Manager
---

# UPC Nederland LVM Service Overview Manager

The **UPC Nederland LVM Service Overview Manager** (SOM) is used to aggregate the service information from the different (supported) probes in the network and display this information in a central place.

## About

The SOM subscribes to the probes that are found in the system. The following probes are supported:

- **Tektronix Sentry**
- **Tektronix Sentry PVQ**
- **Tektronix Sentry Edge**
- **Hirschmann Multimedia Rover TAB7**

Every change in the **Service Overview Table** of the probes will be forwarded to the SOM and the different tables in the SOM will be updated. Which tables are updated is described further on in this document.

### Version Info

| **Range**     | **Description** |
|----------------------|-----------------|
| 1.0.0.x \[SLC Main\] | Initial version |

## Installation and configuration

### Creation

#### Virtual connection

This connector uses a **virtual connection** and does not require any input during element creation.

### Configuration of subscriptions

When a new element of the **SOM** is created, the subscriptions are by default disabled. To enable subscriptions, go to the **Configuration** page and set the **Subscriptions Enabled** parameter to *True*.

### Configuration of logical groups

To make sure that the SOM can correctly aggregate the received information, configure the **logical groups** and specify how these logical groups are connected. This can be done on the **Logical Groups** page.

You can populate both the **Logical Groups** and **Service Level Overview** table by right-clicking the table and adding an entry. However, the easiest method is to **import a CSV file** containing all rows for these tables.

The first row of the CSV file needs to contain the following headers:

- **Logical Group CSV:** "LG Name \[IDX\]","LG Impacted Services","LG Highest Possible Customer Impact","LG Highest Possible Customer Impact (Redundancy)"
- **Service Level Overview CSV:** "SLO Idx \[IDX\]","SLO Service","SLO Logical Group","SLO Level"

### Configuration of probes

The probes that are available on the DMS will be retrieved automatically by the SOM. After the logical groups have been configured, **link the probes** to the correct logical group. This is necessary to make sure that the SOM correctly aggregates the received data.

When a probe element is removed, it will **not automatically be removed from the Probes table**. This prevents loss of logical group configuration when an element cannot be found (e.g. because it is on another DMA in the cluster that is stopped). The only way to remove a probe from the Probes table is to manually remove it using the **Delete Probe** button.

### Configuration of priorities and channels

The priorities can be configured on the **Configuration** page. The **Priorities** table has 4 priorities by default (*P1, P2, P3 and P4*). You can add more by right-clicking the table. The Customers Impacted value that is linked to each priority indicates how many customers are affected when a channel with this priority is in alarm.

The **Channels** table on the Configuration page can then be used to link a channel with one of the priorities in the **Priorities** table. When an update for a channel is received from one of the probes, and the channel is not in the **Channels** table, it will **automatically** be added with the *P4* priority.

You can also add channels to the **Channels** table by importing a CSV file. This file needs to have the following headers: "Channel Name \[IDX\]","Channel Priority","Broadcast Start Time \[HH:mm\]","Broadcast Duration \[HH:mm\]". The **broadcast start** and **duration** are important, because these are used to monitor the channels in the **Channel Services** table.

## Usage

### Foundation

The **Foundation** table contains all the channels of the probes. Each row shows the current **Alert Groups** and the current **Severity**. When there is an alarm, you can find which one it is in the **Trap** **Types** column.

The **Channel Services** table contains one entry per channel. For each of these channels, if there is an alarm, the aggregated severity is calculated along with additional info. The additional information is also set in the alarm properties.

The following **alarm properties** are currently used:

- **Customers Impacted:** Number of affected customers (channel priority configurable in Channels table).
- **Region:** Regions affected by the issue.
- **Affected Blocks:** Logical groups affected by the channel's alarm.
- **Dashboard:** Indicates whether the alarm is local, regional or national (used to correctly update the overview Visio).
- **Friendly Event Description:** User-friendly description of the alarm (Format: "\[location\] - Issue with \[channel\] - \[root cause\]").
- **Trigger IVR:** Used to correlate the alarm (Format: "\[channel\];\[region\],\[region\],...").
- **Event Description:** Description of the alarm (Format: "\[location\] - \[channel\] - \[issue/multiple_issues\]").
- **Event Tag:** List of the traps that are affecting the alarm.
- **Impacted Services:** List of the services that are affected by the alarm.
- **Source:** List of the probes that are affecting the alarm.
- **Parameters:** List of probes with their respective traps that are affecting the alarm (Format: "Summary: \<\>\[probe A\]-\[trap A\],\[probe B\]-\[trap B\]\</\>").
- **TSID**: Value from the Tektronix Probes, present in the message that is received from the "Service Overview Table" - "Service DisplayKey". This has a content format like for example "*/Port 1/TS 2049/24Kitchen/20001*".
- **Service Name**: Value of the "Channel (Channel Services) \[IDX\]" column of the SOM.

### Probes

This page contains the **Probes** table (see "Configuration of probes" section above). This table contains all probe elements found in the DMS and indicates to which logical group they belong. This table is refreshed every day and after startup. You can also manually refresh the table by clicking the **Refresh** button at the top of the page.

Subscriptions are by default enabled for all probe elements that are **active** and **not in timeout**. If one of the probe elements is stopped or goes into timeout, the **Probe Subscriptions** will automatically change to *Disabled*. They can only be *enabled* again when the element is active. The **Enable Subscriptions** button can be used to try and enable all subscriptions for the probe elements that were disabled.

Under the Probes table, you can find the **Linking Probes Table**. This table allows you to link up multiple probes to aggregate their alarms on the services. These linked probes will then be displayed in the **Linked Probes Table**. When an alarm is generated on a specific service, this table will then aggregate those alarms and display whether they are Service Impact or Service Degradation alarms.

### Logical Groups

This page contains the **Service Level Overview** table and the **Logical Groups** table. These are both configuration tables (see "Configuration of logical groups" section). The **Import** page button can be used to import the data for these tables from a CSV file.

The **Service Level Overview** table is used for root cause analysis. The **SLO Level** indicates the level of the block. The root will have level 1, all logical groups (per service) that are directly under the root will have a level 2, etc.

### Configuration

This page contains the **Channels** and **Priorities** tables, which can be used to link a channel to a particular priority. This priority is used to indicate how many customers are affected when there is an issue with a particular alarm. The subscriptions also need to be enabled on this page.

For more information, refer to the "Configuration of priorities and channels" section above.

## Notes

It is important to note that when part of the **configuration** (e.g. the logical groups) is updated using a **CSV import**, the current configuration will be **overwritten**. The configuration is kept in memory to update the alarm table as quickly as possible. When you update the configuration, you should also **manually** **update the subscriptions**. This can be done by *enabling* and *disabling* the subscriptions again (**Configuration page \> Subscriptions Enabled**).

Note that the aggregated severity also takes into account the Highest Possible Customer Impact (and the Highest Possible Customer Impact in case of redundancy if applicable) of the logical group of a probe. **For example:** Imagine a certain probe P1 with logical group G1 sending a critical trap for channel C1, a probe P2 with logical group G2 sending a major trap for channel C1, and a probe P3 with logical group G2 sending a warning trap for channel C1. The logical group G2 also has a Redundancy Highest Possible Customer Impact set to *Warning*. The aggregated severity then also depends on the Highest Possible Customer Impact (in case of redundancy if applicable) of G1 and G2. The table below indicates that then the aggregated severity is the maximum of the last column, and therefore *Minor*.

