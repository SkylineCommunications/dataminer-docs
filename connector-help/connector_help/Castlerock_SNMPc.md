---
uid: Connector_help_Castlerock_SNMPc
---

# Castlerock SNMPc

The Castlerock SNMPc is a device that monitors and catches events from connected devices. Depending on how this independent network management device is configured, the information of the connected devices can be used in several ways:

- The events can be stored in an SQL database. The connector range **1.0.x.x** makes a connection with the database and allows you to manage what to do with it.

- The events can be gathered and sent as traps to the connector. The connector range **2.0.0.x** collects traps and processes these according to the settings on the connector's Configuration page.

## About

- Regarding **range 1.0.x.x**:

  This connector makes an SQL connection with the SNMPc database of the device. It reads the **Node Table** and **EventLog Table** in the SNMPc database, processes the information, and displays the processed information on three pages. The **Devices page** shows the available information concerning the connected devices, the **Events** **page** shows the events captured by the device, and the **Info Events page** shows the information events. With the settings on the **Configuration page**, you can clean the database to e.g. only keep records that are less than one year old.

- Regarding **range 2.0.0.x**:

  This connector makes a simple SNMP connection with the device, collects traps originating from trap OID 1.3.6.1.4.1.56.12.1.7.0.1.0.1, and displays these on the **Traps page**. In addition, information concerning the devices connected to the Castlerock SNMPc can be imported and displayed on the **Known IP Addresses page.** With the settings on the **Configuration page**, you can configure how traps should be processed and limited, and manage the creation of DVEs.

This connector can export different connectors based on the retrieved data. A list can be found in the section 'Exported Connectors'.

### Version Info

| **Range** | **Description**                                                                                           | **DCF Integration** | **Cassandra Compliant** |
|------------------|-----------------------------------------------------------------------------------------------------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version with connection to SQL Database.                                                          | No                  | No                      |
| 1.0.1.x          | New alarm clearing system implemented. Update tables reviewed.                                            | No                  | Yes                     |
| 2.0.0.x          | New connector range retrieving information from traps and from the import of rules and IP addresses via CSV. | No                  | No                      |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |
| 1.0.1.x          | Unknown                     |
| 2.0.0.x          | Unknown                     |

### Exported connectors

| **Exported Connector**                                                                  | **Description**                                                                                                                                      |
|----------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------|
| Castlerock SNMPc Node (in 1.0.0.x and 2.0.0.x) Castlerock SNMPc - Node (since 1.0.1.x) | A separate connector showing only the database or traps information for that specific node, connected to the Castlerock SNMPc. Supported in all ranges. |

## Installation and configuration

### Creation

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range 1.0.0.x/1.0.1.x</strong></td>
<td><h4 id="virtual-sql-database-connection">Virtual SQL Database connection</h4>
<p>This connector uses a virtual connection and does not require any input during element creation. The configuration of the connection is done on the Configuration page of the connector (see below).</p></td>
</tr>
<tr class="even">
<td><strong>Range 2.0.0.x</strong></td>
<td><h4 id="snmp-trap-input-connection">SNMP Trap Input connection</h4>
<p>This connector uses a Simple Network Management Protocol (SNMP) connection and requires the following input during element creation:</p>
<p>SNMP CONNECTION:</p>
<ul>
<li><strong>IP address/host</strong>: The polling IP of the device.</li>
<li><strong>Device address</strong>: Not required.</li>
</ul>
<p>SNMP Settings:</p>
<ul>
<li><strong>Port number</strong>: <em>161</em></li>
<li><strong>Get community string</strong>: <em>public</em></li>
<li><strong>Set community string</strong>: <em>private</em></li>
</ul></td>
</tr>
</tbody>
</table>

### Configuration

<table>
<colgroup>
<col style="width: 50%" />
<col style="width: 50%" />
</colgroup>
<tbody>
<tr class="odd">
<td><strong>Range 1.0.0.x/1.0.1.x</strong></td>
<td>Configuration of credentials to connect to the SNMPc-database
<p>The credentials to connect with the SQL database must be specified on the <strong>Configuration page</strong>:</p>
<ul>
<li><strong>Database Name:</strong> The name of the database, by default SNMPc.</li>
<li><strong>Server IP:</strong> The IP address of the database.</li>
<li><strong>User Name:</strong> The user name to connect.</li>
<li><strong>Password:</strong> The password that is required to login.</li>
</ul>
<p>The connector does a credential check on these parameters before trying to connect to the database. If the default alarm template is used, not filling in these parameters will result in a critical alarm.</p></td>
</tr>
<tr class="even">
<td><strong>Range 2.0.0.x</strong></td>
<td><h4 id="custom-element-properties">CUSTOM ELEMENT PROPERTIES</h4>
<p>The <strong>Custom Element Properties</strong> <em>Client ID and MHA Identifier</em> need to be created in the main element before you import the CSV file.</p></td>
</tr>
</tbody>
</table>

## Usage: Range 1.0.0.x/1.0.1.x

### Devices

On this page, the **Node Table** lists all the connected nodes. The connector updates this table every hour by querying the SNMPc database.

The toggle buttons in the **Create DVE** column of the table allow you to create a DVE for each node, or remove existing DVEs.

### Events Filter (in 1.0.1.x)

This page contains an overview of the event filters. The calculated key (more info below) can be adjusted so matching events are combined.

The **Apply Filters** button recalculates the key for all the events in the **Events Table**. Matching events will be deleted, leaving the most recent key. When **Also Delete Alarm Events in Database** is selected (on the Configuration page), these events will be deleted from the database as well.

The **Events Filter Table** contains the following columns:

- **Index**: Unique identifier for this filter

- **Filter Priority**: Priority of this filter. Filter rows are processed in ascending order. The lower this number, the higher the priority. If rows have the same priority, they will be processed in the order they were added.

- **Node Label**: Device name/label as defined in the node table. Use an asterisk wildcard ('\*') to match 0 or more characters, or a question mark wildcard ('?') to match one character.

- **Trap OID**: The trap OID of the event this filter row applies to. Use an asterisk wildcard ('\*') to match 0 or more characters, or a question mark wildcard ('?') to match one character. Use *Any* if the row should be applied to all traps. The trap OID will not be considered when filtering events.

- **Message Filter**: Regular expression to filter an ID from the message in the events table. Example:

  - Input: "OSPF - 1.2.3.4 5.6.7.8 0 5 ospfTraps"

  - Pattern: "OSPF - \S\* (?\<ID\>\S\*) (?\<ID\>\S\*) 5 ospfTraps"

  - Will filter the following IDs:

    1. 5.6.7.8
    2. 0

Via the **Add Row** button, you can open a pop-up page where you can specify a new filter to add to the Events Filter Table.

### Events

This page displays the **Events Table**, which contains the events from the EventLog table in the SNMPc database that do not have priority level 7. Events with priority level 7 are info events, and as such these are stored in the Info Events table (see Info Events section below).

Aside from the raw data from the database, this table also contains the columns **Device Label**, **Device Description** and **Delete Event**. The information in the Device Label and Device Description columns is extracted from the Node Table, based on the Map ID, to show more information about the device that generated the event. The Delete Event column can be used to remove separate events from the table.

> [!NOTE]
> An entry in the Events Table can be the result of the overwriting of several entries in the database. The decision to overwrite an existing event or to add a new event to the table depends on the calculated key of every event, which is in essence a hashing operation (see below). The overview in the Events Table should only contain the most recent events, so in case a device for example first generates a message with high severity and then a message with low severity, both of which are stored in the SNMPc database, only the most recent event will be relevant for the Events Table, so it will be overwritten. However, to see a historical overview of the alarm, you can enable alarm monitoring on the Priority parameter of this table.

If the Events table is fully up to date with the SNMPc Database, the **Processing Status** parameter will display *Done*. If it is not fully up to date, this is because the Maximum Processing Speed of Events (see Configuration section below) is making sure that not too many events of the EventLog Table are queried at once. Particularly when the element is created, it can occur that it takes some time before the table is fully up to date.

The **Date and Time of the Youngest Processed Event** indicates the datetime of the most recent event in the Events Table. If the table is fully up to date, this datetime will equal that of the most recent event in the EventLog Table in the SNMPc database.

The **Number of Stored Events** indicates the number of events stored in the Events Table. This number can be limited on the Configuration page (see below).

### Info Events

The **Info Events Table** contains the events from the EventLog table in the SNMPc database that have priority level 7. Similar to the Events Table, it also contains the extra columns **Device Label, Device Description** and **Delete Event**.

Note that in this table overwriting is not possible. All entries from priority 7 of the EventLog Table have a corresponding new entry in this table.

### Configuration

This page consists of three main sections (detailed below), as well as the **Maximum Processing Speed \[Events/Minute\]** parameter. The latter displays the maximum number of events of the EventLog Table that can be queried and processed in one minute. By default, this parameter is set to 5000.

> Note: This setting is intended as a safety measure in case the EventLog Table contains a large number of entries, as errors could occur if the number of queried entries is too high. Because this value will be higher than the number of events stored per minute in the EventLog table of the SNMPc database, this parameter is only relevant on startup, when the Events Table in the element first gets updated. For example, if you were to set the parameter to 10000, and only 10 events per minute are stored in the EventLog table on average, the element will be up to date fairly quickly. When the table is not yet up to date, the Date and Time of the Youngest Processed Event parameter can give an indication of the update progress.

#### Events Limitations

This section determines the limitations for events stored in the Events table:

- **Maximum Number of Events**: Indicates the maximum number of events that can be stored in the Events table before events are automatically removed.
- **Maximum Age of Events**: Indicates the maximum age events can have in the Events table before they are automatically removed.
- **Event Types That Can Be Cleared**: Indicates which types of events can automatically be removed from the table. If this is set to '*Only normals*' or '*Only normals and minors*', it could occur that the table contains more events than indicated in the Maximum Number of Events parameter. If this happens, a message will be logged in the logging for the element.
- **Remove Normal or Cleared Traps**: Determines whether cleared alarms are automatically deleted from the Events Table or if this should be done manually.
- **Also Delete Alarm Events in Database:** Can be used to synchronize the automatic cleaning of the Events Table with the EventLog Table of the device in the background. If this is enabled, queries of type DELETE are sent to the database. Note that this setting also takes into account if the connector is up to date with the device. This check is done to make sure that events that were not yet processed by the connector (more recent than the Datetime of the Youngest Processed Event) are not deleted from the SNMPc database before they are processed by the connector. When this setting is toggled to enabled, the synchronization is immediately executed in the background. While it remains enabled, the connector synchronizes once every minute.

The checks on the number of events and the age of the events in the table are done whenever the Maximum Number of Events or Maximum Age of Events parameters are updated, whenever the Events table is updated, and during startup. The limitations deliver a list of events that is cleaned up automatically, although only event types that can be cleared will be removed, as determined by the Event Types That Can Be Cleared parameter.

#### Info Events Limitations

This section determines the limitations for info events stored in the Info Events table:

- **Maximum Number of Info Events**: Determines the maximum numbers of info events that can be stored in the Info Events table before info events are automatically removed.
- **Maximum Age of Info Events**: Determines the maximum age info events can have in the Info Events table before they are automatically removed.
- **Also Delete Info Events in Database**: Can be used to synchronize the automatic cleaning of the Info Events Table with the EventLog Table of the device in the background. If this is enabled, queries of type DELETE are sent to the database, filtered on priority level 7.

The checks on the number of info events and the age of the info events in the table are done whenever the Maximum Number of Info Events or Maximum Age of Info Events parameters are updated, whenever the Info Events table is updated, and during startup. No further configuration or check on the priority is done, as all priorities are level 7 in this table.

#### SQL Credentials

As mentioned above, these credentials are needed to set up a connection with the SNMPc-database.

- **Database Name:** The name of the database of the device, by default '*SNMPc*'.
- **Server IP:** The IP address where the device can be found.
- **User Name** and **Password**: The credentials to log in to the database.
- **Credential** **Check:** Indicates if the credentials are filled in and is used as a flag to allow the connector to connect and send queries.

## Notes: Range 1.0.0.x/1.0.1.x

### Hashing operation

The decision to see if an event can overwrite an existing event in the Events Table is based on hashing. An event is overwritten by another event if the other processed event has the same hash key as the one already in the Events table. As such, the hash key helps the connector to decide if two events belong together and the new event is actually an update of the information of the old event. The hash key is stored in the Events Table, but not displayed to the user.

The normal hash key consists of four parts, delimited by semicolons:

1. **Map ID** This is equal to the raw data of that specific cell of an entry. Including this in the hash key ensures that only events coming from the same node can overwrite each other.

1. **From_address** This is equal to the raw data of that specific cell of an entry. Including this in the hash key ensures that only events with the same from_addres can overwrite each other.

1. **IP addresses in the Event Message** Through the use of a regular expression, the IP addresses (several types and occurrences in one message are possible, delimited by an '\*') are extracted from the raw message, which also correspond to a specific cell of the entry. This check is necessary as sometimes a node is connected to several devices, and the difference between these can be seen based on the IP addresses included in the message.

1. **Slot:port-combinations in the Event Message** Through the use of a regular expression, the Slot:Port combinations (several types and occurrences in one message are possible, delimited by an '\*') are extracted from the raw message, which also correspond to a specific cell of the entry. This check is necessary as sometimes a node is connected to several devices, and the difference between these can be seen based on the Slot:Port combinations in the message.

#### Examples of calculated hash keys

eska-\[ER\];192.168.3.242;192.168.7.234; cn-go-wp1-cr90;192.168.255.61;192.168.255.61\*0.0.0.0\*192.168.255.65\*192.168.255.65; eska-\[ER\];192.168.3.242;192.168.6.82;2:12 dtv-nawij-is-dcm71;192.168.23.151;;

In version 1.0.1.x, the hash key consists of the following parts, delimited by semicolons, if an **Events Filter** is applied:

1. **Device Label**
1. **Trap OID**
1. ID groups found by applying the message filter regular expression of the applied **Events Filter**. Multiple IDs are separated by ampersands.

## Usage: Range 2.0.0.x

### Traps

This page contains the **Traps Table**, which lists the stored traps, ordered from new to old. The **Number of Traps** parameter above the table shows how many rows the table contains. The **Delete Trap** **button** on the right-hand side of every row in the table allows you to remove individual traps. To further manage this table or to configure the way traps are processed, go to the Configuration page (see below).

### Known IP Addresses

This page displays the **Devices Table**, which lists all the devices known to the connector. Note that every incoming trap has a source IP (see below) and that this source IP address is used to match the trap to a specific device. Only traps with a source IP address known by the connector will be processed, the others will be discarded.

In the one but last column of the table, **Create DVE**, you can enable or disable the creation of a single Dynamic Virtual Element. Note that enabling DVE creation will only be possible if there is a view with a name equal to the Site Name of the device. The created DVE will then use the exported connector Castlerock SNMPc Node. For more information on this connector, refer to its specific Help page.

To delete a single device from the Devices Table, use the **Delete Device** button in the relevant row. Note that the traps originating from that device will also immediately be deleted, as the connector only stores traps originating from known IP addresses.

The **Number of** **Known IP Addresses** parameter at the top of the page shows the total number of rows in the Device Table. The **Number of DVEs** parameter below it shows how many DVEs are currently enabled. To further manage devices, e.g. to delete multiple devices or to create or delete all DVEs at once, go to the Configuration page (see below).

### Configuration

This page consists of four main sections, as explained below.

#### Traps Limitation

At the top of this section, the total **Number of Traps** in the Traps Table is indicated.

You can limit the number of traps in two ways: based on the **Maximum Number of Traps** or based on the **Maximum Age of Traps**. It is not possible to disable both of these limitations at the same time, to avoid an unlimited increase of the content of the Traps Table.

For example, if the maximum number of traps limitation is enabled and set to 1000, and a new trap is received while the current number of traps is 1000, the oldest trap in the table will be removed. As another example, if the maximum age of traps limitation is enabled and set to 14 days, and a trap was received 14 days ago, it will be deleted tomorrow. This check is done daily and whenever the element starts up.

Finally, this section also contains buttons to manually **Delete All Traps** at once, or to **Delete Normal Traps**, which deletes all traps with severity Normal.

#### Traps Processing

In this section, you can configure how traps are processed, so that the received traps are not always simply added as a new trap in the Traps Table. Depending on this configuration, some traps will be considered invalid, others will update or clear old traps, etc.

The toggle button **Automatically Remove Cleared Traps** is used for traps that clear existing traps. For example, if a trap of severity Critical is received, mentioning that the CPU Load of a certain device is very high, and soon after another trap of severity Normal is received, mentioning the same parameter and device, an update rule can make sure that the second trap updates the first trap, so that the trap in the table will now have severity Normal. In such a case, **Automatically Remove Cleared Traps** determines whether this cleared alarm is automatically removed.

The toggle button **Store Not-Updating Normal Traps** is used to toggle whether traps with severity Normal that may not be relevant are stored. For example, if a connected device sends a trap every 5 minutes telling that the connection is OK, it might not be useful to store these traps. Note that this parameter is enabled by default, because disabling it could have undesirable effects. For example, if a trap of severity Major is received, followed by a trap of severity Normal indicating that the problem is solved, but the connector could not find a link to that first trap because of a mistake in the update rule (see below), the second trap would not be stored. However, if storing were enabled, you could simply correct and apply the update rule (via Apply Rules in History) to link the two traps.

The button **Delete All Rules** can be used to manually delete all old rules.

The **Import Rules** and **Show Rules** page buttons are used to manage update rules. (Refer to the Notes section for more information on how these rules work.)

- **Import Rules**: This subpage contains the necessary parameters to import custom rules. The imported files must be CSV files with a specific format, as detailed in the Notes section below. Two kinds of rules are separated in the file with the keywords 'TRIM RULES' and 'UPDATE RULES'. It is also possible to specify if you want to delete the old rules on importing, or keep the old rules and just add the new rules, with the toggle button **Clear Old Rules on Importing**. At the right side of the page, you can also find a report of the import, mentioning which rows were imported and which were considered invalid (e.g. the severity was not recognized or the row did not contain the expected number of values).
- **Show Rules**: This page displays an overview of all trim rules and update rules that are currently imported in the connector, in the **Trim Rules Table** and **Update Rules Table**. The total **Number of Trim Rules** and the **Number of Update Rules** are also specified. Please also note that the order of the rules matters, as the rules are executed in that specific order (see Notes below).

Finally, the button **Apply Rules in History** can be used to apply all current rules on the full content of the Traps Table. This can for example be useful when you notice that an older trap was not updated by a new trap because the update rule was not correct. In that case, you can adjust the update rule and apply the rules in history. This mechanism will start from the oldest traps, and will check for every trap if the current rules require the update of an older trap. Note that this mechanism can take more time if the number of rules and the number of stored traps are high.

#### Known IP Addresses

In this section, you can manage the known IP addresses shown on the Known IP Addresses page. At the top of the section, the **Number of Known IP Addresses** is displayed.

With the **Delete All** button, you can manually delete all known IP addresses. Please note that this button will not only delete the known IP addresses in the table, but also the DVEs made for these addresses and the stored traps coming from the addresses. This means that, in essence, this button resets all stored information except for the rules.

The page button **Import IP Addresses** opens a subpage where you can import IP addresses into the connector, using a CSV file with a specific format (detailed on this subpage). With the toggle button **Create DVEs on Adding/Updating IP Addresses**, you can specify whether the connector should by default try to create DVEs when importing. A report of the import is displayed on the right-hand side of the subpage, mentioning which rows were imported and which were considered invalid (e.g. the IP address had already been imported before, the IP address was not a valid IP address, there was already a previous row mentioning that IP address, etc.). If you want to change the Device Name related to a certain IP address, it is also possible to do this via importing. However, unlike with the importing of rules, you cannot delete old addresses by importing, as this would delete all stored traps as well (similar to if the IP addresses were removed with the Delete All button).

#### Dynamic Virtual Elements

This section allows you to manage the creation or deletion of all DVEs all at once. Creating or deleting separate single DVEs is not possible on this page, but can be done on the Known IP Addresses page.

The section mentions the total **Number of DVEs**, and contains buttons to **Create All DVEs** and **Delete All DVEs**. Note that deleting all DVEs will not impact the stored traps in the Traps Table, as deleting the DVE will not delete the IP address that was related to that DVE. Also note that DVEs can only be created if there is a view in the Surveyor that matches the Site Name of the known IP address. The DVE will then immediately appear in the correct view. As a consequence, the DVEs will form a great overview of all the devices connected to the Castlerock SNMPc.

## Notes: Range 2.0.0.x

These notes provide information on the mechanisms implemented to make sure that incoming traps are processed as desired. Because the **format of the trap messages is not uniform** on all the devices that can be connected to the Castlerock SNMPc, it is impossible to fully hardcode how the traps should be processed. The possibility to **import** **trim and update rules** solves this issue and allows you to easily customize how every single trap should be processed.

### Incoming trap format

The traps collected by this connector need to have a particular format for the connector to be able to process them. In the trap structure illustrated below, items indicated in green are of particular importance for trap processing.

- Timestamp: Provided by the Castlerock SNMPc

- Source IP: The source IP will always be that of the Castlerock SNMPc, but in essence its origin is a device connected to the Castlerock SNMPc

- Trap OID: 1.3.6.1.4.1.56.12.1.7.0.1.0.1.

- Four bindings:

  - Binding 1: Trap message (from the connected device, not changed by the Castlerock SNMPc).

  - Binding 2: Trap severity (from the connected device, not changed by the Castlerock SNMPc)

    - This is a number that corresponds with a certain severity:

      1. Critical
      1. Severe
      1. Major
      1. Minor
      1. Warning
      1. Normal
      1. Info

  - Binding 3: IP address (real source IP of the trap, i.e. the IP address of the connected trap)

  - Binding 4: TrapOID (always equal to 1.3.6.1.4.1.56.12.1.7.0.1.0.1)

### General Hardcoded Rules

- Only incoming traps with an IP address that is known will be processed. It is therefore very important to import all the IP addresses of your connected devices.

- Only traps originating from the same IP address can overwrite each other.

- Normal traps stored in the Traps Table cannot be overwritten. This would make no sense. The timestamp of such a trap will remain unchanged, and eventually the trap will be deleted from the Traps Table, but not updated.

### Trim Rules

Trim Rules are useful in case you want to trim trap messages before storing them in the Traps Table. On every incoming trap, all trim rules are applied. It is possible to specify in which cases you want to apply a rule. Note that trim rules are applied all to an incoming trap one by one ordered via ID from low to high, regardless of whether a match found was in the previous trim rules.

The fields of an imported trim rule detail the following information:

- **IP Address**: You can specify to which source IPs the trim rule should be applied. If it should be applied to all IP addresses, use the wildcard value '\*'. Choosing a specific range like 192.168.10.x (with x between 0 and 255) is also allowed.

- **RegEX Incoming Trap**: You can specify to which words of the trap message the trim rule should be applied. This works via regular expressions. The rule will search if there is a match between the regular expression and the message in the trap. If so, the matching part is trimmed off the trap message.

- **Severity Incoming Trap**: You can specify to which severities the trim rule should be applied. If it should be applied to all severities, use the wildcard value '0'. Specify other severities by the corresponding number (1:Critical, 2:Severe, 3:Major, 4:Minor, 5:Warning, 6:Normal, 7:Info).

#### Example of Trim Rule Mechanism

Consider the following trim rules table:

| **ID** | **IP Address**      | **RegEx Incoming Trap**                                                                                                                                               | **Severity Incoming Trap** | **Applied** |
|--------|---------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------|-------------|
| 1      | \* (Wildcard Value) | \*;^(?:\b\[0-9\]{4})-(?:0\*\[1-9\]\|1\[0-2\])-(?:3\[0-1\]\|\[1-2\]\[0-9\]\|0\*\[1-9\]),(?:2\[0-3\]\|1\[0-9\]\|0\*\[1-9\]):(?:\[0-5\]\*\[0-9\]):(?:\[0-5\]\*\[0-9\])\b | 0 (Wildcard Value)         | Yes         |
| 2      | \* (Wildcard Value) | working                                                                                                                                                               | 6 (Normal)                 | Yes         |
| 3      | 10.x.10.x           | Failed                                                                                                                                                                | 2 (Severe)                 | Yes         |

Consider the following incoming trap, with the first three bindings equal to:

- Trap message: 2015-11-25,09:40:15 Connection not working. Failed

- Severity: 2 (Severe)

- Source IP: 10.10.10.10

The trim rules will then be applied one by one, from the first to the last ID:

1. Both the IP address and the severity are wildcards, so we can try to find a match for the regular expression. A match is found, and the matched part will be trimmed off the message. The intermediate result is a trimmed trap message: 'Connection not working. Failed'. The regular expression made sure that the datetime in front of the trap message was deleted.

1. The IP address is a wildcard, so this has no further effect. However, the severity check fails, as the trim rule can only be applied to traps of type normal and the incoming trap is of severity 'Severe'. As such, the word 'working' is not trimmed from the message.

1. The IP address of the incoming trap, 10.10.10.10, is part of the 10.x.10.x range and the severity check also matches, so we can try to find a match for the regular expression. A match is found, and the matched part will be trimmed off the message.

The result is the following trimmed trap message: 'Connection not working.' In the logging of the element, you will be able to find a message in the format "*TrapMessage \<trap message\> was trimmed to \<trimmed trap message\> by Trim Rule \<ID of the trim rule\>*".

### Update Rules

After the trim rules have been applied, the connector will check if the trimmed message can update an older trap in the Trap Table. This depends on the update rules. If it cannot update an older trap, the incoming trap will be added as a new trap. It is possible that a trap updates multiple older traps based on that one update rule. In the logging of the element, you will be able to find log messages specifying that a trap was updated, with a message in the format "*Due to Update Rule \<ID of the update rule\>, the trap from source IP \<IPAddress\> has overwritten \<#\> older trap(s), (with shortkey(s) : \<shortkeys of updated traps\>.* "

Update rules are useful to make sure that traps that are related to each other update each other. Having the same source IP is not enough for a trap to update another trap, as there should also be a match between the trap messages. Very often, trap messages are closely related to each other, but not exactly the same. As such, it is possible to trim parts of the messages of the traps before checking if a new and older trap are equal. Note that only one update rule can be applied on an incoming trap. When an incoming trap is processed, all update rules are evaluated one by one, but as soon as a match is found, the other update rules are no longer evaluated. Keep this in mind when specifying update rules.

The fields of an imported update rule detail the following information:

- **IP Address**: You can specify to which source IPs the update rule should be applied. If it should be applied to all IP addresses, use the wildcard value '\*'. Choosing a specific range like 192.168.10.x (with x between 0 and 255) is also allowed.

- **RegEX Updated Trap**: You can specify to which words of the older trap message the update rule should be applied. This works via regular expressions. The rule will search if there is a match between the regular expression and the message in the older trap. If so, the matching part is trimmed off the older trap message before it is compared to the new trap. Note that this trimming is temporary and only done to compare if the trap messages are equal after applying both this regular expression and that for the new trap (see below).

- **Severity Updated Trap**: You can specify to which severities of the older trap the rule should be applied. If it should be applied to all severities, use the wildcard value '0'. Specify other severities by their corresponding number. A trap can only be updated via this update rule if the severity of the older trap matches this check.

- **RegEX Updating Trap**: You can specify to which words of the new trap message the update rule should be applied. This works via regular expressions. The rule will search if there is a match between the regular expression and the message in the new trap. If so, the matching part is trimmed off the new trap message before it is compared to the older trap. Note that this trimming is temporary and only done to compare if trap messages are equal after applying both this regular expression and that for the older trap (see above).

- **Severity Updating Trap**: You can specify to which severities of the new trap the rule should be applied. ft it should be applied to all severities, use the wildcard value '0'. Specify other severities by their corresponding number. A trap can only update other traps via this update rule if the severity of the new trap matches this check.

Additional remarks:

- To add multiple regular expressions in one rule, use '//-//' as a delimiter in your input CSV file.

- To use a semicolon (';') in the regular expression, use '//sc//' in your input CSV file. The result in your update rules table will be a normal semicolon. It is not possible to use a regular semicolon in the CSV file, as it would be mistaken for a new colum.

#### Example of Update Rule Mechanism

Consider the following update rules table:

| **ID** | **IP Address** | **RegEx Updated Trap** | **Severity Updated Trap** | **RegEx Updating Trap** | **Severity Updated Trap** | **Applied** |
|--------|----------------|------------------------|---------------------------|-------------------------|---------------------------|-------------|
| 1      | 11.11.11.11    | alcorSetTrap           | 1 (Critical)              | alcorClearTrap          | 6 (Normal)                | Yes         |
| 2      | 10.10.10.10    | Down                   | 1 (Critical)              | Up                      | 6 (Normal)                | Yes         |
| 3      | 12.12.12.12    | alarmSetTrap           | 1 (Critical)              | alarmClearTrap          | 6 (Normal)                | Yes         |

Consider the current content of the Traps Table. Some columns were hidden because they are not relevant to the update rules mechanism. The oldest trap is the one with the lowest ID. They are ordered by descending timestamp, so from new to old.

| **Shortkey** | **Timestamp**           | **IP Address** | **Message**    | **Severity** |
|--------------|-------------------------|----------------|----------------|--------------|
| 4            | 2010/01/01 14:17:00.000 | 10.10.10.10    | asxLinkDown Q8 | 1 (Critical) |
| 3            | 2010/01/01 14:10:00.000 | 10.15.15.12    | asxLinkDown Q8 | 1 (Critical) |
| 2            | 2010/01/01 14:03:00.000 | 10.10.10.10    | asxLinkDown A7 | 1 (Critical) |
| 1            | 2010/01/01 14:00:00.000 | 10.10.10.10    | asxLinkDown Q8 | 2 (Severe)   |

Consider the following incoming trap on 2010/01/01 15:00:00.000 (so more recent than the traps in the table), with the first three bindings equal to:

- Trapmessage: asxLinkUp Q8

- Severity: 6 (Normal)

- Source IP: 10.10.10.10

When the trap is received, the update rules will be evaluated one by one:

1. First rule: The incoming trap does not match the "RegEx Updating Trap" part of the update rule (the trap message does not contain 'alcorClearTrap'). Moreover, the source IP does not match, so this update rule cannot be applied and we move on to the next rule.

1. Second rule: The incoming trap does match the "RegEx Updating Trap" part of the update rule (the trap message contains 'Up'). Moreover, it has severity 6 (Normal) and the source IP matches, so the trap table is checked to see if any traps match the conditions for the "updated" trap:

   - Trap with shortkey 1: The IP address of the updated trap matches, but the severity of the updated trap does not match. The update rule was made for normal traps to clear Critical traps, not Severe traps.

   - Trap with shortkey 2: The IP address and severity of the updated trap match, but after temporary trimming the trap messages are not equal. ('asxLink A7' and 'asxLink Q8'). The new trap is therefore not related to the old trap, and is probably related to an different problem (of the A7 instead of the Q8).

   - Trap with shortkey 3: The severity of the updated trap matches, but the IP address does not match. The update rule was made for traps coming from 10.10.10.10.

   - Trap with shortkey 4: The IP address and severity of the updated trap match. After temporary trimming ('asxLink Q8'), the trap messages are equal. So this is a match.

1. Third rule: This rule will not longer be evaluated, as a match was found for the second rule. However, even if it was evaluated, no match would be found.

The result of evaluating the update rules will be that the incoming trap will update the trap with shortkey 4 and will not be added as a new trap.

#### Example 1 of Choosing an Update Rule

Imagine the following two traps, arriving in this order:

| **IP Address**        | **Trap Message** | **Severity**                                                                                                        |              |
|-----------------------|------------------|---------------------------------------------------------------------------------------------------------------------|--------------|
| Stored in Traps Table | 10.237.150.41    | alarmSetTrap; No stream received : SES in DVBR; alarmDescr: Sess: \[WIN.D.U24M.INGL.CANO;IP2\]:No stream received   | 1 (Critical) |
| Incoming Trap         | 10.237.150.41    | alarmClearTrap; No stream received : SES in DVBR; alarmDescr: Sess: \[WIN.D.U24M.INGL.CANO;IP2\]:No stream received | 6 (Normal)   |

Importing the following .csv file for the rules would be enough to make sure that the incoming trap updates the correct old trap, because the regular expression trims the first word from the updated and updating trap:

*TRIM RULES*<br/>*UPDATE RULES*<br/>*10.237.150.41;^\s+\[^\s\]+;1;^\s+\[^\s\]+;6*

This more specific .csv file would also do the job:

*TRIM RULES*<br/>*UPDATE RULES*<br/>*10.237.150.41;alarmSetTrap//sc//;1;alarmClearTrap//sc//;6*

#### Example 2 of Choosing an Update Rule

Imagine the following two traps, arriving in this order:

| **IP Address**        | **Trap Message** | **Severity**                                                             |              |
|-----------------------|------------------|--------------------------------------------------------------------------|--------------|
| Stored in Traps Table | 10.11.12.13      | 4 Trib 1 uncommissioned traffic 1 Slot7 Slot7 system                     | 1 (Critical) |
| Incoming Trap         | 10.11.12.13      | 2015-11-22,13:37:03 6 Trib 1 uncommissioned traffic 0 Slot7 Slot7 system | 6 (Normal)   |

Importing the following .csv file for the rules would be enough to make sure that the incoming trap updates the correct old trap and is stored without the timestamp at the beginning:

*TRIM RULES*<br/>*\*;^(?:\b\[0-9\]{4})-(?:0\*\[1-9\]\|1\[0-2\])-(?:3\[0-1\]\|\[1-2\]\[0-9\]\|0\*\[1-9\]),(?:2\[0-3\]\|1\[0-9\]\|0\*\[1-9\]):(?:\[0-5\]\*\[0-9\]):(?:\[0-5\]\*\[0-9\])\b;0*<br/>*UPDATE RULES*<br/>*\*;\d\s+(?=Trib)//-//(?\<=uncommissioned\straffic)\s\*\d;1;\d\s+(?=Trib)//-//(?\<=uncommissioned\straffic)\s\*\d;6*

Note that the trim rule used a wildcard for the severity and IP address and will therefore be applied to ALL incoming traps starting with a datetime, regardless of their severity and IP address.

#### Example 3 of Choosing an Update Rule

You can even add the general case of traps updating older traps if the trap message is exactly the same as an update rule, because the regular expression can also have a wildcard value. In that case, there is no temporary trimming and the raw messages (after applying the trim rules) will be compared. Importing this file would add the required rule:

*TRIM RULES*<br/>*UPDATE RULES*<br/>*\*;\*;0;\*;0*

| **IP Address**        | **Trap Message** | **Severity**            |            |
|-----------------------|------------------|-------------------------|------------|
| Stored in Traps Table | 10.11.12.13      | No response from Device | 3 (Major)  |
| Incoming Trap         | 10.11.12.13      | No response from Device | 6 (Normal) |

#### Example 4 of Choosing an Update Rule

Imagine there is a certain range of devices that all have a source IP belonging to the address range 192.16.5.x. These devices send a trap every five minutes with a message about their current CPU Load, always with severity equal to Info. In this case, it makes sense to always overwrite the previous status of five minutes ago. So regardless of what is in the trap message, if the IP address is in that range and the severity is Info, we should update. This means we can use the regular expression .\* in the update rule to temporarily trim everything off the message, resulting in a match and an update. The hard-coded rule that traps with a different source IP cannot update each other still holds, so the traps will only update traps from the exact same device.

Importing this file would add the required rule:

*TRIM RULES*<br/>*UPDATE RULES*<br/>*192.16.5.x;.\*;7;.\*;7*
