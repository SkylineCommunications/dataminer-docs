---
uid: General_Main_Release_10.0.0_CU21
---

# General Main Release 10.0.0 CU21

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Enhanced polling of SNMP tables using MultipleGetBulk and MultipleGetNext \[ID_31715\]

In DataMiner versions prior to 10.1.11, when MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm could get stuck into an infinite loop. That problem was fixed in DataMiner version 10.1.11, but now, the MultipleGetBulk/MultipleGetNext polling mechanism has received a more thorough overhaul.

### Fixes

#### DataMiner Connectivity Framework: Virtual functions would incorrectly inherit interfaces from the main element \[ID_30715\]

By default, the interfaces of a virtual function are the interfaces defined in the functions.xml file. Up to now, in some cases, virtual functions would also incorrectly inherited the interfaces of the main element.

#### Protocols: Export rules would fail to parse values containing escaped XML characters \[ID_31362\]

When, in a protocol, values contained escaped XML characters (e.g. \<Description>Measurements \> 5\</Description>), the export rules would fail to parse those values and the generated DVE or Virtual Function protocol would only have some or none of the export rules applied.

#### Alarm limit updates for column parameters would contain invalid data \[ID_31415\]

When alarm monitoring of type “rate” was used to monitor a column parameter, alarm limit change events would contain invalid data.

From now on, alarm limit change events will only be sent for standalone parameters and column parameters that are exported as standalone parameters in a virtual function or DVE child element.

#### DataMiner Cube - Correlation: Incorrect background color when creating or opening an analyzer or a correlation rule \[ID_31482\]

When, in the Correlation app, you created or opened an analyzer in the Analyzers tab or you created or opened a legacy correlation rule in the Correlation rules tab, the tab would incorrectly have a gray background.

#### SLPort would leak a socket when executing an action of type 'open' via a socket that had already been opened \[ID_31512\]

When an action of type “open” was executed on a smart-serial interface via a socket that had already been opened, SLPort would leak a socket as well as a port in the ephemeral port range. This would eventually lead to a situation in which no more ports were available and no more sockets could be created. From now on, SLPort will close the socket when it receives an action of type “open” on a socket that is already open.

#### SLAnalytics: Problem during initialization \[ID_31521\]

In some cases, an exception could be thrown during the initialization of the SLAnalytics process.

#### DataMiner Cube - Alarm Console: Problem when clearing an alarm while alarms were grouped by service \[ID_31549\]

When, in one of the tab pages in the Alarm Console, alarms were grouped by service, in some cases, an exception could be thrown when an alarm listed in more than one group was cleared.

#### DataMiner Cube - Settings: Changes made in 'Alarm Console \> Card-specific' section would incorrectly not get applied \[ID_31566\]

In the *Alarm Console \> Card-specific* section of the *Settings* app, you can configure which alarm tabs should be shown on element, service and view cards. Up to now, when you made changes to the settings on that page, those changes would incorrectly not get applied.

#### Problem with SLDataMiner when deleting an alarm template or a trend template \[ID_31583\]

In some rare cases, an error could occur in SLDataMiner when an alarm template or a trend template was deleted.

#### DataMiner Cube - Alarm cards: Services were not sorted naturally \[ID_31607\]

When you opened an alarm card, in some cases, the services affected by the alarm would incorrectly not be sorted naturally.

#### Problem when SLWatchDog was copying log files to the Minidump folder \[ID_31652\]

When an error of type “thread problem” occurs, the contents of the C:\\Skyline DataMiner\\Logging folder is compressed into a zip file, which is then placed in the C:\\Skyline DataMiner\\Logging\\Minidump folder. During this action, in some cases, a lock inside the SLWatchdog process would accidentally delay the start-up of elements.

#### DataMiner Cube - Settings: Turning an alarm tab of type 'sliding window' into a normal alarm tab would cause this change to be reverted as soon as another change was made to it \[ID_31664\]

When, in the group settings, you added an alarm tab of type “sliding window” and enforced it, as soon as a user had turned this tab into a normal alarm tab, the slightest change made to the tab afterwards would cause the tab to be changed back into a tab of type “sliding window”.

#### DataMiner Cube - Alarm Console: Problem when alarm tabs were grouped by property \[ID_31673\]

When an alarm tab was grouped by property, in some cases, DataMiner Cube could become unresponsive, especially on systems with high alarm traffic.

#### DataMiner Cube - Scheduler: Creating a task could fail on client machines with culture set to 'Finnish' \[ID_31712\]

In DataMiner Cube, creating a task in the Scheduler app could fail when the culture of the client machine was set to “Finnish”.

#### Dashboards app: Problem when listing the parameters of a selected element \[ID_31737\]

When, in a dashboard, you selected an element, in some cases, an “Index was outside the bounds of the array” error could be thrown when a linked parameter component tried to list all parameters of the element you selected.
