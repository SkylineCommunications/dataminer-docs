---
uid: General_Main_Release_10.0.0_CU4
---

# General Main Release 10.0.0 CU4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### DataMiner Cube - Automation: Dummies, parameters and memory files now sorted in the order in which they were added to the script \[ID_25897\]

Up to now, the dummies, parameters and memory files added to an Automation script were sorted naturally. From now on, they will be sorted in the order in which they were added to the script.

#### DataMiner Cube - Visual Overview: Colors linked to the Cube theme will now be changed immediately when you change the Cube theme \[ID_26045\]

When, in a Visio drawing, you linked some colors to the colors used in the DataMiner Cube theme, then those colors will now immediately be changed when you change the DataMiner Cube theme. You will no longer have to close and re-open the Visio drawing to have the changes take effect.

#### DataMiner Cube: Embedded Chromium web browser engine updated from v63 to v81 \[ID_26171\]

The embedded Chromium web browser engine has been updated from v63 to v81.

#### Automation: UnSetFlag method added to Intellisense \[ID_26176\]

In the Automation module, the *UnSetFlag* method has now been added to Intellisense.

#### Text will now be written to the log files using UTF-8 encoding \[ID_26194\]

From now on, text will be written to the log files using UTF-8 encoding.

#### Trending of column parameters with measurement type 'string' is now also supported \[ID_26230\]

From now on, trending of column parameters with measurement type set to “string” is also supported.

#### Enhanced performance when displaying and updating parameter values \[ID_26382\]

Due to a number of enhancements, overall performance has increased when displaying and updating parameter values, both in Data Display and Visual Overview.

### Fixes

#### Problem when taking Agents out of a Failover setup with a Cassandra database \[ID_24787\]

In some cases, it would no longer be possible to correctly take an Agent out of a Failover setup with a Cassandra database.

#### Problem with SLDMS due to memory issues \[ID_25890\]

In some cases, an error could occur in SLDMS due to memory issues.

#### DataMiner Cube: When, in the Generic DVE Linker Table, a link associated with a virtual function was changed while its element card was open, its parameters would not get updated \[ID_25913\]

When, in the Generic DVE Linker Table, a link related to a virtual function was added, updated or removed while its element card was open in DataMiner Cube, the parameters of that function would incorrectly not get updated.

#### Service & Resource Management: State of ReservationInstance would incorrectly be set to Interrupted when it was updated after a DMA restart \[ID_25938\]

When you restarted a DataMiner Agent with an ongoing ReservationInstance and then updated the end time of that ongoing ReservationInstance after the restart, in some rare cases, the state of the ReservationInstance would incorrectly be changed from “Ongoing” to “Interrupted”.

#### Duplicate table change notifications would be sent from SLElement to SLDataGateway when using history sets in combination with table updates \[ID_25987\]

When history sets were used in combination with table updates, in some cases, duplicate table change notifications would incorrect be sent from SLElement to SLDataGateway when the values remained stable.

#### Hotfixes not properly validated during installation \[ID_25991\]

In some cases, it could occur that hotfixes were not properly validated during installation, so that a hotfix could be installed on an incompatible version of DataMiner.

#### When adding or editing an element, some fields would not correctly be saved into the element.xml file \[ID_25994\]

When adding or editing an element, in some cases, the contents of a number of fields (e.g. GetCommunity, SetCommunity, etc.) would not correctly be saved into the element.xml file.

#### DataMiner Cube - Alarm Console: Alarm duration indicator was missing \[ID_26044\]

In the Alarm Console, in some cases, the alarm duration indicator would not be shown in the Time column of a certain alarm, even though the Show alarm duration indicator option was enabled in the hamburger menu of the Alarm Console.

The problem would occur in the following situations:

- When you expanded a correlation alarm, the alarm duration indicator of the source alarms would disappear.
- When, for a particular alarm, an update was received while its history was expanded, the alarm duration indicator of the alarms in the history list would disappear.

#### Automation scripts: Problem when a parameter specified in an email action contained a double quote character \[ID_26046\]

When, in an Automation script, you specified a parameter containing a double quote character in an email action configured to send a report, in some cases, it would not be possible to save the script.

#### DataMiner Cube - Trending: Zoom buttons in top-right corner of a trend graph window would incorrectly not be displayed \[ID_26068\]

When you opened a trend graph, e.g. by clicking the trend graph icon next to a parameter shown on an element card, in some cases, the zoom buttons (Last 24 hours, Week to date and Month to date) in the top-right corner would incorrectly not be displayed.

#### Deadlock between SLNet and SLDataGateway during a DataMiner startup or a Failover switch \[ID_26074\]

Due to a flushing issue in SLNet, in some cases, a deadlock could occur between SLNet and SLDataGateway during a DataMiner startup or a Failover switch.

#### DataMiner Cube - Visual Overview: Problem when initializing a Visio page with service shapes \[ID_26079\]

In some cases, an exception could be thrown while initializing a Visio page containing service shapes.

#### DataMiner Cube - Visual Overview: No tool tip shown when SetVar shape was configured using legacy syntax \[ID_26087\]

In some cases, no tool tip would be shown when you had used legacy syntax to configure a tool tip on a shape (e.g. SetVar set to "varA:X:Y" and SetVarOptions set to "Control=Shape").

#### DataMiner Cube - Element Connections: Problem when swapping connections \[ID_26098\]

When, in the Element Connections app, you swapped two connections, in some cases, the connection configuration would be incorrect or a connection would incorrectly be duplicated.

#### Incorrect message shown after a successful DataMiner upgrade operation \[ID_26114\]

After a DataMiner upgrade operation, in some cases, a “DataMiner is currently upgrading” error would be shown indefinitely, despite the fact that all agents had been upgraded successfully.

#### Database: Large offload files would not get written to the database \[ID_26130\]

In some cases, when a database was again up and running after being down for an extended period of time, the offload files would not get written to the database because their size was too large.

#### Sidebar docking position user setting not working in non-English Cube \[ID_26165\]

If Cube was set to a different language than English, it could occur that it was not possible to change the position of the Cube sidebar via the user settings.

#### DataMiner Cube would become unresponsive when no domain user pictures could be retrieved \[ID_26182\]

In some cases, DataMiner Cube could become unresponsive when no domain user pictures could be retrieved.

#### View synchronization could cause SLDataMiner to leak memory \[ID_26190\]

On large DataMiner systems, in some cases, a view synchronization could cause SLDataMiner to leak memory.

#### Dashboards: Clicking the icon of a parameter component would incorrectly not open the associated trend card in the Monitoring app \[ID_26213\]

When, in the Dashboards app, you click the icon of a parameter component, the trend card of the parameter in question should open in the Monitoring app. However, in some cases, this did not happen due to an incorrect key being passed from the Dashboards app to the Monitoring app.

#### Problem with user permissions caused certain parameters of an enhanced service not to be displayed \[ID_26222\]

In some cases, the user permissions configured for the hidden element of an enhanced service would differ from those configured for the enhanced service itself. This would cause certain parameters of the enhanced service not to be displayed.

#### Problem with protocol buffer serialization when server and client were running different DataMiner versions \[ID_26227\]

When protocol buffer serialization was being used, a “Failed to set up ProtoBuf” error could be thrown when a DMA and a client were running different DataMiner versions.

#### Problem when a table cell value was masked while being retrieved \[ID_26250\]

In some cases, an error could occur when a table cell value was masked while it was being retrieved.

#### Memory leak when adding or deleting rows in the DCF interface table \[ID_26256\]

When, in an element with DCF interfaces, rows were added or deleted in the DCF interface table, in some cases, a memory leak could occur.

#### Automation: Date and time not adapted to local time zone in calendar component \[ID_26258\]

If an interactive Automation script used a calendar component, it could occur that the date and time in the component were not adapted to the local time zone.

#### DataMiner Cube - Data Display: Time control values would incorrectly change when you edited them \[ID_26278\]

Due to a rounding issue, in some cases, values displayed in a time control would change when you edited them.

#### DataMiner Cube - Services: Exclude setting specified when creating a service would incorrectly change to an include setting when editing that service afterwards \[ID_26281\]

When you created a service with exclude conditions in combination with conditional alarm severity influence settings, in some cases, the exclude setting would incorrectly change to an include setting when editing that service afterwards.

#### Problem when multiple FillArray calls simultaneously tried to update the same table \[ID_26287\]

When multiple FillArray calls simultaneously tried to update the same table, in some cases, an error could occur due to a locking issue.

#### DataMiner Cube - Elements: Actions listed in the warning message that appears when changing the protocol version of an element would not be formatted correctly \[ID_26297\]

When you are about to change the protocol version of an element, a popup message will appear. Apart from warning you about the consequences, that message also lists the (manual) actions that are required afterwards. Up to now, in some cases, that list of actions would not be formatted correctly.

#### An SNMP table configured to retrieve data via a bulk operation would not get filled in when one of the responses contained an error \[ID_26333\]

When an SNMP table was configured to retrieve data via a bulk operation (e.g. multiple get), up to now, the table would only get filled in when all requests had received a correct response. One response containing an error would cause the entire table to not get filled in.

From now on, each time a correct response is received, the data in that response will be returned to SLProtocol for processing.

#### DataMiner Cube: Missing icons in standalone Cube installed by Cube Launcher \[ID_26340\]

When DataMiner Cube was used as a standalone application installed using the Cube Launcher introduced in DataMiner v10.0.9, in some cases, icons would be missing, especially when working with Automation and Trending.

#### Ticketing/Cassandra: Problem when retrieving a ticket that had just been added or updated \[ID_26348\]

On systems where the ticketing data is stored in a Cassandra database, in some cases, it would not be possible to retrieve a ticket immediately after it was created. Also, when a ticket was retrieved immediately after it had been updated, in some cases, the ticket data from before the update would incorrectly be retrieved.

#### DataMiner Cube - Alarm Console: Miscellaneous issues \[ID_26396\]

A number of minor issues have been fixes in the Alarm Console:

- When an alarm in the Active Alarms tab page was clicked, in other words, marked as read, in some cases, the alarm would incorrectly be set to unread again when you opened a tab page of type “sliding window” that contained the alarm in question.

- When you opened a tab page of type “sliding window” and kept it open while a number of active alarms were cleared, in some cases, when you opened a new tab page of type “sliding window” with an identical window size, the number of unread alarms in the first tab page would not be equal to the number of unread alarms in the second tab page.

- When the alarms in a particular tab page were grouped by Time, in some cases, the sorting would be reversed each time you changed the Automatically grouped according to arrangement setting.

- In some cases, similar alarms would have different parameter descriptions. One alarm would e.g. show “Temperature” while another alarm would show “Temperature A”.

#### DataMiner Cube: Module names in side bar not translated when UI language was set to a language other than English \[ID_26402\]

When, in DataMiner Cube, the UI language was set to a language other than English, in some cases, the names of the modules in the side bar would not be translated.
