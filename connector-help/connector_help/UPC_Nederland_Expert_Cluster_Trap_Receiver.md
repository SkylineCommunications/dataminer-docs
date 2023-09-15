---
uid: Connector_help_UPC_Nederland_Expert_Cluster_Trap_Receiver
---

# UPC Nederland Expert Cluster Trap Receiver

The **UPC Nederland Expert Cluster Trap Receiver** receives all alarm traps sent from other DMAs.

## About

This connector captures all alarm traps, in order to visualize what the active alarms on other clusters are.

## Installation and configuration

### Creation

#### SNMP main connection

This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:

SNMP CONNECTION:

- **IP address/host**: The polling IP of the device, e.g. *192.168.10.2*

SNMP Settings:

- **Port number**: The port of the connected device, by default *161*.
- **Get community string**: The community string used when reading values from the device. The default value is *public*.
- **Set community string**: The community string used when setting values on the device. The default value is *private*.

### Configuration

To configure the connector, you must do the following:

- On the **General** page, the parameter **Trap Source IP** needs to be filled in. The value you fill in can be a single IP address or a comma-separated list of IP addresses. These addresses can contain \* and ? wildcards.
- On the DMA that will send the alarm traps, all the Custom Trap Bindings need to be included as a filter. For this, the elements can be selected of which the alarms need to be forwarded. However, note that information events should not be included in the alarm filter.

## Usage

### General

This page contains the **Trap Source IP** parameter. For more info on this parameter, refer to the "Configuration" section above.

This page also contains the **Alarm Traps** table, which displays all alarms that came in through traps. When an alarm is cleared, it will automatically be removed from the table. However, it is possible that alarms are not cleared, for example when the element is stopped on the source DMA. To manually delete a row from the table, select it in Cube, right-click and select the option **Delete Selected Rows**.

The connector processes the following bindings from a trap:

| Binding | **OID** | **Comments** | **Mandatory** | **Column Name in table Alarm Traps** |
|--|--|--|--|--|
| System name | 1.3.6.1.2.1.1.5 | Possible values:<br>- Element name<br>- DataMiner name | Yes | Element Name |
| Parameter description | 1.3.6.1.4.1.8813.1.1.2.2.1 |  | Yes | Parameter Name |
| Value | 1.3.6.1.4.1.8813.1.1.2.2.2 | Possible values (depending on the type):<br>- Octet string<br>- Integer | Value |  |
| Severity | 1.3.6.1.4.1.8813.1.1.2.2.3 | Possible values:<br>- Critical Low/High<br>- Major Low/High<br>- Minor Low/High<br>- Warning Low/High<br>- Normal<br>- Information<br>- Timeout<br>- Error<br>- Notice| Severity |  |
| OID | 1.3.6.1.4.1.8813.1.1.2.2.4 | Default value: Device OID + Parameter OID | OID |  |
| Timestamp | 1.3.6.1.4.1.8813.1.1.2.2.5 | A fixed time format is used: | Time |  |
| 'yyyy-mm-dd HH:MM:SS'. |  |  |  |  |
| Alarm type | 1.3.6.1.4.1.8813.1.1.2.2.6 | Possible values:<br>- Escalated<br>- Dropped<br>- New alarm<br>- Cleared<br>- Acknowledged<br>- Resolved<br>- Unresolved<br>- Comment Added<br>- Masked<br>- Unmasked<br>- Dropped from critical<br>- Dropped from major<br>- Dropped from minor<br>- Dropped from warning<br>- Escalated from warning<br>- Escalated from minor<br>- <br>- Flipped<br>- Service impact changed<br>- Value changed<br>- Name changed<br>- RCA level changed | Alarm Type |  |
| Alarm status | 1.3.6.1.4.1.8813.1.1.2.2.7 | Possible values:<br>- Cleared<br>- Open<br>- Masked | Status |  |
| Name of owner | 1.3.6.1.4.1.8813.1.1.2.2.8 |  | Owner |  |
| User status | 1.3.6.1.4.1.8813.1.1.2.2.9 | Possible values:<br>- Not assigned<br>- Acknowledged<br>- Resolved<br>- Unresolved | User Status |  |
| Comment added by user | 1.3.6.1.4.1.8813.1.1.2.2.10 |  | Comment |  |
| Source | 1.3.6.1.4.1.8813.1.1.2.2.11 | Possible values:<br>- Automation Engine<br>- Correlation Engine<br>- DataMiner System<br>- External<br>- Mobile Gateway<br>- Service Monitor<br>- Unknown<br>- Watchdog | Source |  |
| Display value | 1.3.6.1.4.1.8813.1.1.2.2.12 | (formatted) | Yes | Display Value |
| Element description | 1.3.6.1.4.1.8813.1.1.2.2.13 |  | Element Description |  |
| Trap description | 1.3.6.1.4.1.8813.1.1.2.2.14 | (as defined in SNMP Manager) | Trap Description |  |
| Element RCA | 1.3.6.1.4.1.8813.1.1.2.2.15 | -1 = Not defined | Element RCA |  |
| Parameter RCA | 1.3.6.1.4.1.8813.1.1.2.2.16 | -1 = Not defined | Parameter RCA |  |
| Alarm ID | 1.3.6.1.4.1.8813.1.1.2.4.0.0 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.1 |  | Alarm ID |  |
| DataMiner ID | 1.3.6.1.4.1.8813.1.1.2.4.0.1 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.2 |  | Yes | DataMiner ID |
| Element ID | 1.3.6.1.4.1.8813.1.1.2.4.0.2 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.3 |  | Element ID |  |
| Parameter ID | 1.3.6.1.4.1.8813.1.1.2.4.0.3 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.4 |  | Parameter ID |  |
| Type ID | 1.3.6.1.4.1.8813.1.1.2.4.0.4 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.5 | Possible values:<br>- Escalated (8)<br>- Dropped (9)<br>- New alarm (10)<br>- Cleared (11)<br>- <br>- Resolved (20)<br>- Unresolved (21)<br>- Comment Added (22)<br>- Unmasked (27)<br>- Dropped from critical (31)<br>- Dropped from major (32)<br>- Dropped from minor (33)<br>- Dropped from warning (34)<br>- Escalated from warning (35)<br>- Escalated from minor (36)<br>-Escalated from major (37)<br>- Flipped (38)<br>- <br>- Value changed (41)<br>- Name changed (42)<br>- RCA level changed (43)<br>- Properties changed (50) | Type ID |  |
| State ID | 1.3.6.1.4.1.8813.1.1.2.4.0.7 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.6 | Possible values:<br>- Cleared (11)<br>- Open (12)<br>- Masked (25) | State ID |  |
| Severity ID | 1.3.6.1.4.1.8813.1.1.2.4.0.8 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.7 | Possible values:<br>- Critical (1)<br>- Major (2)<br>- Minor (3)<br>- Warning (4)<br>- Normal (5)<br>- Information (13)<br>- Timeout (17)<br>- Error (24)<br>- Notice (28) | Severity ID |  |
| Severity range | 1.3.6.1.4.1.8813.1.1.2.4.0.9 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.8 | Possible values:<br>- Normal (5)<br>- High (6)<br>-Low (7)  | Severity Range |  |
| Previous alarm ID | 1.3.6.1.4.1.8813.1.1.2.4.0.10 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.9 |  | Previous Alarm ID |  |
| User status ID | 1.3.6.1.4.1.8813.1.1.2.4.0.11 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.10 | Possible values:<br>- Not assigned (18)<br>- Acknowledged (19)<br>- Resolved (20)<br>- Unresolved (21) | User Status ID |  |
| Alarm root ID | 1.3.6.1.4.1.8813.1.1.2.4.0.14 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.11 |  | Yes | Alarm Root ID |
| Source ID | 1.3.6.1.4.1.8813.1.1.2.4.0.15 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.12 | Possible values:<br>- DataMiner (16)<br>- Correlation engine (23)<br>- Automation engine (26) | Source ID |  |
| Table display index | 1.3.6.1.4.1.8813.1.1.2.4.0.16 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.13 |  | Table Display Index |  |
| Full RCA level | 1.3.6.1.4.1.8813.1.1.2.4.0.17 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.14 | A 32-bit integer |  |  |
|                |                                                                | Service RCA: Byte 4 |  | Service RCA Level |
|                |                                                                | Parameter RCA: Byte 3 |  | Parameter RCA Level |
|                |                                                                | Element RCA: Bytes 2 and 1 |  | Element RCA Level |
| Element type | 1.3.6.1.4.1.8813.1.1.2.4.0.19 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.15 |  | Element Type |  |
| Root time | 1.3.6.1.4.1.8813.1.1.2.4.0.22 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.16 | A fixed time format is used: 'yyyy-mm-dd HH:MM:SS'. | Root Time |  |
| Table index (primary key) | 1.3.6.1.4.1.8813.1.1.2.4.0.23 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.17 |  | Table Index |  |
| Protocol name | 1.3.6.1.4.1.8813.1.1.2.4.0.24 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.18 |  | Protocolname |  |
| Alarm presence | 1.3.6.1.4.1.8813.1.1.2.4.0.25 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.1.19 |  | Alarm Presence |  |
| Service impact | 1.3.6.1.4.1.8813.1.1.2.4.1.0 <br>or <br>1.3.6.1.4.1.8813.1.1.2.5.1.1 |  | Service Impact |  |
| Platform Service | 1.3.6.1.4.1.8813.1.1.2.4.4.1.80.108.97.116.102.<br>111.114.109.32.83.101.114.118.105.99.101 | Element property Platform Service | Platform Service |  |
| Region | 1.3.6.1.4.1.8813.1.1.2.4.4.1. 82.101.103.105.111.110 <br>or <br>1.3.6.1.4.1.8813.1.1.2.4.4.3. 82.101.103.105.111.110 | Element or alarm property Region | Region |  |
| Customers Impacted | 1.3.6.1.4.1.8813.1.1.2.4.4.3.67.117.115.<br>116.111.109.101.114.115.32.73.109.<br>112.97.99.116.101.100 | Alarm property Customers Impacted | Customers Impacted |  |
| Event Tag | 1.3.6.1.4.1.8813.1.1.2.4.4.3.69.<br>118.101.110.116.32.84.97.103 | Alarm property Event Tag | Event Tag |  |
| Friendly Event Description | 1.3.6.1.4.1.8813.1.1.2.4.4.3.70.114.105.101.<br>110.100.108.121.32.69.118.101.110.116.32.<br>68.101.115.99.114.105.112.116.105.111.110 | Alarm property Friendly Event Description | Friendly Event Description |  |
| Impacted Services | 1.3.6.1.4.1.8813.1.1.2.4.4.3.73.109.112.97.99.<br>116.101.100.32.83.101.114.118.105.99.101.115 | Alarm property Impacted Services | Impacted Services |  |
| Parameters | 1.3.6.1.4.1.8813.1.1.2.4.4.3.80.97.114.97.109.<br>101.116.101.114.115 | Alarm property Parameters | Parameters |  |
| Source | 1.3.6.1.4.1.8813.1.1.2.4.4.3.<br>83.111.117.114.99.101 | Alarm property Source | Source Property |  |
| Trigger IVR | 1.3.6.1.4.1.8813.1.1.2.4.4.3.84.114.105.103.<br>103.101.114.32.73.86.82 | Alarm property Trigger IVR | Trigger IVR |  |
| Event Description | 1.3.6.1.4.1.8813.1.1.2.4.4.3.69.118.101.110.116.<br>32.68.101.115.99.114.105.112.116.105.111.110 | Alarm property Event Description | Event Description |  |

### General (version 1.0.0.7)

From version 1.0.0.7 onwards, a queue is introduced in order to prevent all the alarms from being added to the **Alarm Traps** table immediately. The parameter **Maximum Active Alarm Count** defines the maximum number of active alarms (i.e. alarms with another severity than Normal (=5), in the Severity ID column) that can be present in the **Alarm Traps** table, before a new active alarm will be queued.

If there are more active alarms, these will be queued until there is room in the Alarm Traps table again. If an alarm goes back to state Normal while it is queued, it will be removed from the queue, and it will therefore never enter the Alarm Traps table. Alarms in the queue are processed in a first-in-first-out (FIFO) manner. This means that the alarm that first entered the queue will be the first alarm that leaves the queue and enters the Alarm Traps table.

The connector also allows the user to remove rows from the Alarm Traps table by selecting **Delete Selected Rows** from the context menu. When this action is executed and there are still alarms left in the queue, these alarms will be transferred to the Alarm Traps table, until either this table holds the maximum allowed number of active alarms or the queue is empty.

**Note**: When the Maximum Active Alarm Count parameter is changed during operation, two options are possible:

- The maximum number of active alarms is **increased**: In this case, alarms from the queue will be transferred to the Alarm Traps table, until either this table holds the maximum allowed number of active alarms or the queue is empty.
- The maximum number of active alarms is **reduced**: In this case, it is possible that the Alarm Traps table contained more alarms than is now allowed. If this is the case, alarms are queued back to the queue in such a way that these alarm will be processed first when there is room in the Alarm Traps table again.

***\[**version 1.0.0.12\]***From version 1.0.0.12 onwards, this connector works along with the **Ziggo SAM Event Combiner** connector.A new parameter called **Trigger IVR Type** was added to specify which table of the **Combiner** element the alarms' information will be sent to (HFC or B2B).Two new columns were added to the **Alarm Traps** table that display the results of the correlation process returned by the **Combiner** element:

- **Correlated Trigger IVR -** The most technical path that will group the alarms and generate one correlated alarm.
- **Impact -** This column will only be set on "HFC" trap receivers and displays the number of B2B alarms under a correlated alarm.
