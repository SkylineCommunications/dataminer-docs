---
uid: SLNetClientTest_tool_advanced_procedures
---

# SLNetClientTest tool advanced procedures

The procedures below can be applied to troubleshoot issues. However, be very careful when you apply them as they can strongly influence the functionality of your DataMiner System.

## Editing the connection string between two DataMiner Agents

In most cases, when you add a DataMiner Agent to a DataMiner System, all other DataMiner Agents in the DataMiner System connect to it using its primary IP address. However, in case e.g. NAT (Network Address Translation) is being used, you may need to configure the connection strings by hand.

To do so:

1. In the *Advanced* menu, select *Edit Connection Uris.*

1. In the *Connection String Configuration* dialog box, right-click in the list, and select *Add New Destination*.

1. In the *Edit Connection String* dialog box, configure the following settings.

   - *From*: The DataMiner Agent from which will be connected.
   - *To*: The primary IP address of the DataMiner Agent to which will be connected. From DataMiner 10.0.0 CU15/10.1.0 CU4/10.1.7 onwards, wildcards are supported in this field. If there is no exact match, the connection string will be set for all matching destinations.
   - *Update All Connections To This Agent*: Select this option if you want to update all connection strings to the DataMiner Agent specified in *To*.
   - *New Connection String*: The IP address to be used when connecting to the DataMiner Agent specified in *To*. Syntax example: `http://[IP address to connect]:8004/SLNetService`.

1. Click *OK* to save the configuration, and then click *Done*.

> [!NOTE]
> From DataMiner 10.0.0 CU15/10.1.0 CU4/10.1.7 onwards, if DataMiner fails to automatically detect the SLNet target port (via port 80 or 443), the connection attempt will continue on the default port 8004. To skip this auto-detection and immediately use the default port 8004, you can set the connection string to *auto://nodetect*. This can for instance be useful in case port 80 is blocked between the DMAs.

## Disabling replication buffering

As a diagnostic option to verify if certain issues are caused by replication buffering, or in case replication buffering causes issues, it is possible to disable replication buffering using the SLNetClientTest tool.

To do so:

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *DisableReplicationBuffering*.

   A list of the Agents in the cluster will be displayed, indicating for each of them whether replication buffering is disabled.

1. In the *Value* column, right-click the "false" value for the Agent for which you wish to disable replication buffering, and select *Edit value*.

1. Enter "true" and click *OK*.

> [!NOTE]
> This option is saved into the file *MaintenanceSettings.xml* under the *\<SLNet>* tag. It is not synchronized across Agents in the DMS.

## Making DataMiner Cube ignore view updates

With the SLNetClientTest tool, you can make DataMiner Cube clients stop handling view changes. Instead, as soon as a view change has been ignored, a *Reconnect* button will appear at the top of the Surveyor. You can click this button to reconnect and manually reload any view changes.

To do so:

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *ClientSkipViewUpdates*.

   A list of the Agents in the cluster will be displayed, indicating for each of them whether client view updates are ignored.

1. In the *Value* column, right-click the "false" value for the Agent for which you want client view updates to be ignored, and select *Edit value*.

1. Enter "true" and click *OK*.

> [!NOTE]
> You can also configure this setting directly in the file *MaintenanceSettings.xml*. See [Making DataMiner Cube ignore view updates](xref:Configuration_of_DataMiner_processes#making-dataminer-cube-ignore-view-updates).

## Configuring how long alarm statistics are kept in memory

The SLNetClientTest tool allows you to determine the time range of the alarm statistics to keep in memory, as well as the amount of time that requested time ranges other than the most recent one will stay in memory.

To configure the time range that the most recent active alarms will be kept in memory:

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *ActiveAlarmStatsTimeToKeep*.

   A list of the Agents in the cluster will be displayed, indicating for each of them how long the alarm statistics are kept (in days). The default time is 2 days.

1. In the *Value* column, right-click the value you want to update, and select *Edit value*.

1. Enter the new number of days and click *OK*.

To configure how long time ranges other than the most recent one will be kept in memory after they have been requested:

1. In the *Advanced* menu, select *Options* > *SLNet options.*

1. In the list at the top of the *SLNet Options* window, select *ActiveAlarmStatsExpirationTime*.

   A list of the Agents in the cluster will be displayed, indicating for each of them how long the time ranges are kept (in minutes). The default time is 10 minutes.

1. In the *Value* column, right-click the value you want to update, and select *Edit value*.

1. Enter the new number of minutes and click *OK*.

## Aborting a running Automation script

To abort an Automation script while it is running:

1. In the *Advanced menu, select Automation*.

   The *Maintain Automation* window will open.

1. Go to the *Running Scripts* tab.

1. In the list of scripts, right-click the entry corresponding to the script you want to abort, and click *Abort Now*.

## Removing references to items that no longer exist

With the SLNetClientTest tool, you can check if the *Views.xml* contains references to elements, services or redundancy groups that no longer exist, and if so, remove them. To do so:

1. In the *Advanced* menu, go to *Clear From* > *Views.xml.*

1. In the *Clear From Views.xml* window, go to the *Clear by Removed Element* tab, and click *Find Removed Elements*.

   A dialog box will open with the IDs of all elements, services and redundancy groups that no longer exist but are still mentioned in *Views.xml*.

1. Click *Yes* to confirm the deletion.

## Comparing the views on two Agents in a DMS

In case there are suspected synchronization issues within a DataMiner System, the SLNetClientTest tool makes it possible to compare the in-memory views loaded by two different DataMiner Agents. This is also possible with a backup Agent in a Failover setup.

To do so:

1. In the *Advanced* menu, go to *Clear From* > *Views.xml.*

1. In the *Clear From Views.xml* window, go to the *Compare Agents* tab.

1. Next to *Agent A* and *Agent B*, select the two Agents.

1. Click *Compare.*

   If differences are detected between the Agents, these will be shown in the list at the bottom of the window.

## Having RCA chains updated by the DCF engine

You can make the DataMiner Connectivity Framework Engine update RCA chains automatically. To do so, generate the RCA chains by sending an SLNet message *GetRCAConnectivity* with the following arguments:

- *ActivePath*: true or false.

  - If "true", property-based path highlighting will be used.
  - If "false", only external connections will be taken into account.

- *AutoGenerate*: true.
- *ChainName*: The name of the DCF chain (which specifies the *Connectivity.xml* file to be used) or the automatically generated context GUID (type = service link).
- *ContextID*
- *DataMinerID*: The entry point.
- *ElementID*
- *RCAChainName*: The name of the RCA chain.

> [!NOTE]
> A DMS Correlation license is required to be able to configure RCA chains.

> [!TIP]
> See also: [Defining connectivity chains in XML files](xref:Defining_connectivity_chains_in_XML_files)

## Increasing the maximum upload size for upgrade packages in a DMS

The default maximum upload size of upgrade packages depends on the DataMiner version:

- Prior to 9.0.0, this is 200 MB.

- From DataMiner 9.0.0 up to DataMiner 10.0.2, this is 500 MB.

- From DataMiner 10.0.3 onwards, this is 4000 MB.

However, it is also possible to increase the maximum upload size via the SLNetClientTest tool:

1. In the *Advanced* menu, go to *Options* > *SLNet Options.*

1. In the drop-down list next to *Option values for*, select *MaxUploadSize*.

1. Right-click the indicated value for this setting, and select *Edit value*.

1. Enter a new value and click *OK*.

## Managing base subscriptions

The "base subscriptions" feature allows you to increase performance when retrieving element and parameter information by caching the data in SLNet.

When a client (e.g. DataMiner Cube) opens an element card, a subscription is made for that element. SLNet then retrieves the element data from the other processes (SLDataminer, SLElement, etc.), caches it, and makes arrangements so that changes get pushed to it immediately. When a client closes an element card, the subscription is removed, and the cached data is cleared.

However, if a base subscription has been defined for an element, the subscription for this element stays open permanently. As a consequence, when you open an element card for such an element, SLNet will send the data to the client instantly, as it does not have to do any initial setup. This is particularly useful for elements that are accessed very frequently.

The base subscriptions for a DMA can be found in *C:\\Skyline DataMiner\\BaseSubscriptions.xml*.

In order to ensure that the subscription for a particular element stays open:

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *BaseSubscriptionMessage*.

1. Select the *BaseSubscriptions* row and click the ... button on the right in order to open the *BaseSubscription Collection Editor*.

1. Click the *Add* button to add a new element subscription.

1. Fill in the following properties, and then click *OK*:

   - The *DmaID* and *ElementID* of the element.

   - The *MessageType*, usually "ParameterChangeEventMessage".

   - The *Name* of the subscription, e.g. "MyElementSubscription".

   - The *Type*, in this case "Element".

     > [!NOTE]
     > The *Type* determines how specific the subscription is. If, for instance, you select "Parameter" instead of "Element", you subscribe to all ParameterChangeEvents for a specific parameter only. In that case, the *ParameterID* field also needs to be filled in.

1. In the *Build Message* tab, make sure "Set" is selected as the *Type*, and click *Send Message* to save the subscription.

1. After you have received a positive response, in the *Build Message* tab, select "Subscribe" as the *Type*, and click *Send Message*.

> [!NOTE]
>
> - To remove the subscription, in the *Build Message* tab, select "Remove" as the *Type*, and click *Send Message*.
> - After you have set the subscription, you can test the functionality by going to *Diagnostics* > *Connection Details* > *BaseSubscriptionManager*. In the subscription set, you will then be able to see all the elements you are subscribed to.

## Configuring trend caching

Data for trend data queries is cached in the SLNet process after it has been received from SLDataGateway, and before it is processed further. This speeds up e.g. switching a trend graph's range from last day to last week, closing a trending card and opening it again shortly afterwards, opening the same trend graph on multiple clients, etc. In the SLNetClientTest tool, several options are available related to the trend cache.

Most of the trend cache options can be configured as follows:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down list at the top of the window, select an option and then configure it using the right-click menu in the pane below.

   The following options are available:

   - *TrendCacheEnable*: Can be set to "true" or "false" in order to enable or disable trend caching.
   - *TrendCacheExpirationTime*: A value in seconds (by default 120 seconds). Determines how long an entry remains in the cache.
   - *TrendCacheLogVerbose*: Can be set to "true" or "false" in order to enable or disable additional logging in the *SLNet.txt* log file, indicating whether a trend data request was resolved from the database or from the cache.
   - *TrendCacheMaxRecordsInCache*: The maximum number of trend records in the cache, by default 1000000. Older entries will be removed to make room for new entries.

   > [!NOTE]
   > These options are not synchronized among the Agents in a DMS.

In addition, if you go to *Diagnostics* > *Caches & Subscriptions* > *Trend Cache*, you can also:

- Select *Stats* or *List Contents* to view more information on the trend cache.

- Select *Clear Cache* to clear the trend cache.

## Modifying the engine ID of a DMA

The engine ID that is used by a DMA for northbound SNMP traffic is determined in the file *SNMP Managers.xml*. In SNMPv3 traps sent by the DMA, this engine ID is indicated.

With the SLNetClientTest tool, you can modify this engine ID:

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

1. In the *Message Type* drop-down list, select *SNMPManagersConfigurationRequestMessage*.

1. Click the field next to the *Agents* argument and then click the *...* button to open the *ObjectEditorForm* window.

1. In the *ObjectEditorForm* window, configure the following variables:

   - *DataMinerID*: The DataMinerID indicated in the file *SNMP managers.xml* for the DMA in question.

   - *EngineBoots*: The number of times the SNMP engine restarted. Usually, this is set to 0.

   - *Text*: The "text" for the EngineID. Depending on the *Type* variable, this text can be an IPv4 address, an IPv6 address, a MAC address, regular text or octets (bytes).

   - *Type*: Determines the type of info entered in the *Text* variable. The following types can be selected:

     - *IPv4*: IPv4 address, e.g. "10.11.12.13".

     - *IPv6*: IPv6 address, e.g. "fd7a:e0de:acc2::".

     - *MAC*: MAC address, e.g. "1234567890ABCDEF".

     - *Text*: regular text, e.g. "MyID".

     - *Octets*: bytes, e.g. "12:34:56:78:90:AB:CD:EF".

     - *LocalEngine*, *Reserved* or *EnterpriseSpecific*: these types function in the same manner as *Octets* and are included for the sake of completeness. However, these should not be used in normal circumstances.

   - All other variables in this window are for viewing purposes only and should not be modified.

1. Click *OK* to close the *ObjectEditorForm* window.

1. Enter the following values for the arguments in the *Build Message* window:

   - *DataMinerID* and *HostingDataMinerID*: The DMA to which the message should be sent, which should be the same as the DataMinerID in the *ObjectEditorForm* window.

   - *Get*: False.

   - *Set*: True.

1. Click *Send Message*.

> [!TIP]
> See also: [SNMP Managers.xml](xref:SNMP_Managers_xml#snmp-managersxml)

## Changing the service template child element and child service limitations

By default, when over 50 services are about to be created by a service template, or the template’s generated services contain over 20 elements, a warning appears that must be acknowledged within 5 minutes, as otherwise the service generation will be aborted.

However, it is possible to change this limit using the SLNetClientTest tool. To do so:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Next to *Option values for*:

   - To change the limit for the total number of services created by a service template, select *ServiceTemplateWarnCount*.

   - To change the limit for the total number of elements in generated services, select *ServiceTemplateWarnElementCount*.

    The value for the selected setting will then be displayed.

1. Right-click the displayed record and select *Edit value*.

1. Enter the new value and click *OK*, then click *OK* to close the *SLNet Options* window.

## Forcing file synchronization between DMAs

Usually, when two files have the exact same timestamp, these are not synchronized, even if the contents differ. From DataMiner 9.0.0 CU12 onwards, the SLNetClientTest tool allows you to carry out an advanced synchronization between Agents in a DMS, optionally also checking for differences between files that have the same timestamp.

1. In the *Advanced* menu, select *Force Sync*.

1. Go to the *DMA* tab. The tab consists of two buttons, and two options:

   - *Force Sync DMA* button: Starts synchronization of the connected DMA only.

   - *Force Sync DMS* button: Starts synchronization of all files in the DMS.

   - *Verify size/CRC for files that have the same time in the SyncInfo changes file*: If this option is selected, when you click the *Force Sync* button, the DMA or DMS will be checked for files that were changed at the same moment, but have a different content. Any inconsistencies will be mentioned in information events. Extra log information can also be found in *SLDMS.txt* and *SLErrors.txt*.

   - *Fix inconsistency problems*: If this option is selected, when you click the *Force Sync* button, any inconsistencies that are found will be resolved. This option can only be selected if the option above is selected as well.

1. Select the options you want to apply, and either click *Force Sync DMA* or *Force Sync DMS*, depending on whether you want to sync the currently connected DMA only, or all DMAs in the DMS.

## Setting the TTL for database records

From DataMiner 9.5.6 onwards, it is possible to update the "time to live" or TTL of database records via the SLNetClientTest tool.

> [!NOTE]
> From DataMiner 9.6.0/9.6.3 onwards, this can instead be done within the Cube UI. See [Specifying TTL overrides](xref:Specifying_TTL_overrides).

1. In the *Advanced* menu, select *TTL*.

1. Under *Sync Type*, select whether you want the TTL to be applied to the *DMA* only or to the entire *DMS*.

1. Select the tab corresponding to the type of record for which a TTL will be specified:

   - *DataType*: Allows you to specify a TTL for specific data types, e.g. *Alarm*, *TimeTrace*, etc.

   - *LoggerTable*: Allows you to specify a TTL for a logger table. The name of the table must be specified in the *Table* box.

   - *Trending*: Allows you to specify a different TTL for real-time ("*RT*"), 5-minute, 1-hour and 1-day trending records.

   - *Protocol*: Allows you to specify overrides for a protocol. The name of the protocol must be specified in the *Protocol* box.

1. Specify the TTL:

   - To customize the default TTL, add a value (in seconds) in the *DefaultTTL* box.

   - To override the TTL for records in the general or "local" database, add a value (in seconds) in the *LocalTTL* box.

   - To override the TTL for records in the indexing database, add a value (in seconds) in the *IndexingTTL* box.

   - If you do not want to edit a particular field, just leave it blank.

1. Click *Update*.

> [!NOTE]
> To find out what the currently used TTL values are, run the *GetTTLRequest* via the message builder.

> [!TIP]
> See also: [DBMaintenance.xml and DBMaintenanceDMS.xml](xref:DBMaintenance_xml_and_DBMaintenanceDMS_xml#dbmaintenancexml-and-dbmaintenancedmsxml)

## Enabling or disabling protocol buffer serialization

From DataMiner 9.5.10 onwards, it is possible to enable protocol buffer serialization, which can considerably increase overall DataMiner performance. This is enabled by default from DataMiner 9.5.14 onwards.

A number of messages related to this functionality can be sent via the *Build Message* tab in the SLNetClientTest tool:

- *DisableProtoBufSerializationMessage*: Disables protocol buffer serialization on all open connections that have it enabled and on all future connections.

- *EnableProtoBufSerializationMessage*: Enables server-side protocol buffer serialization. Any future connection will use protocol buffer serialization. Existing connections that are not using protocol buffer serialization will continue not using it.

- *GetProtoBufInfoMessage*: Checks whether a connection uses protocol buffer serialization.

In addition, when you connect to a DMA with the SLNetClientTest tool, you can select the attribute *NoProtoBufSerialization* in order to create a connection that does not use protocol buffer serialization.

## Managing scheduled tasks for maintenance of a Cassandra database

From DataMiner 9.5.10 onwards, a set of messages are available to manage scheduled tasks for the maintenance of Cassandra databases. The messages allow you to create, update, delete and execute tasks in the Windows Task Scheduler.

Via the *Build Message* tab in the SLNetClientTest tool, you can send the following messages:

- *GetMaintenanceTaskRequest*: Retrieves a list of the maintenance tasks for the specified DMA(s).

- *AddMaintenanceTaskRequest*: Creates a new maintenance task or updates an existing maintenance task (when an existing GUID is passed). The response will contain the new GUID that the task received when it was created or updated.

- *DeleteTaskRequest*: Deletes a task for the specified DMA(s). The response will indicate if the request was successful. If it was unsuccessful, the response will contain an exception detailing what went wrong.

- *ExecuteMaintenanceTaskRequest*: Starts the execution of a scheduled maintenance task on the specified DMA(s). The response will indicate if the request was successful. If it was unsuccessful, the response will contain an exception detailing what went wrong.

For each of the messages, you can pass a particular DMA ID to target a specific DMA in the DMS, or you can specify -1 to target all DMAs in a DMS, without having to connect to every single one of them.

A maintenance task has the following fields:

- *ID*: A GUID created by the software to keep track of the tasks across clusters

- *Name*: A string indicating the name of the task, which is used to identify the task in the Windows Task Scheduler.

- *Tool*: A string indicating the full path to the program that needs to be executed.

- *Arguments*: A string containing a list of optional arguments needed to run the task.

- *Triggers*: A list of triggers that will execute the task automatically. Each trigger consists of the following fields:

  - *Slot*: A custom object containing the day of the week and the time of the next execution.

  - *Frequency*: A time span indicating the frequency at which the task needs to be run.

  Leaving the list of triggers empty will still schedule the task, but it will then only run when executed manually.

## Creating an enhanced view

From DataMiner 10.0.0/9.6.1 onwards, it is possible to enhance a view with an element, so that the alarm level of the element will affect the alarm level of the view, even if the element is not part of the view, and so that the data pages of this element will be displayed on the card of the view.

To create such an enhanced view:

1. Go to the *Build Message* tab of the main window.

1. In the *Message Type* drop-down list, select *EnhanceViewWithElementRequestMessage*.

1. Specify the ID of the view you want to enhance and the ID of the element you want to use for this.

1. Click *Send Message*.

## Generating SMIv2 MIB files

From DataMiner 10.0.9 onwards, it is possible to generate SMIv2 MIB files for SNMP managers using custom bindings. This is only supported for SNMP managers of type SNMPv2 and SNMPv3. Exporting such a file can for instance be of use in case you want to integrate an SNMP manager with custom bindings into a third-party system.

> [!NOTE]
> From DataMiner 10.0.10 onwards, you can export the MIB file directly from the Cube user interface using the *Generate MIB file* button below the custom bindings in the SNMP manager configuration. This method of exporting the file is recommended over the use of the SLNETClientTest tool.

To generate such a MIB file:

1. Go to *Advanced* > *Tests* > *Generate MIB for SNMP Manager*.

1. In the pop-up window, select an SNMP manager and click *Generate*.

1. In the dialog box, browse to where you want to save the MIB file, optionally customize the file name, and click *Save*.

## Fine-tuning the CPECollectorHelper API timeout

When a call is performed via the CPECollectorHelper API, a timeout is calculated that is scaled based on how many items are requested. This way, the timeout time is dynamically adjusted to the number of requested items. This is calculated based on the following formula:

`Total Timeout = ((requested number of items / EPMBulkCount) + 1) * EPMASyncTimeout`

From DataMiner 10.0.9 onwards, you can fine-tune how the timeout is calculated using the SLNetClientTest tool:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Depending on what you want to configure, select one of the following options in the drop-down box at the top of the window:

   - *EPMAsyncTimeout*: The base value for a timeout when the CPE collector contacts another DataMiner Agent.

   - *EPMBulkCount*: The maximum number of items that can be requested in bulk before the timeout is increased.

1. Right-click the setting in the table and select *Edit Value*.

1. Specify the new value and click *OK*.

> [!CAUTION]
> Be careful when changing these values, as an incorrect configuration can lead to problems with EPM. If the EPMAsyncTimeout is too low, it can occur that not all data is displayed in the EPM elements, but it if it is too high, the system may become unresponsive. The inverse is the case for the EPMBulkCount.

## Changing the number of records in the protocol cache

From DataMiner 10.0.11 onwards, you can customize how many records can be contained in the protocol cache. This can be useful to tweak the performance of a DMA. However, **always check with Skyline** before you make any changes to this setting, as an **incorrect configuration can cause serious issues**.

To change this setting:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Select *protocolCacheMru* in the drop-down box at the top of the pop-up window.

1. Right-click the current value and select *Edit Value*.

1. Specify the new value in the pop-up window and click OK.

1. Click OK again to close the *SLNet Options* window.

## Checking or modifying the settings related to a Refused DMA state

When the state of a DMA is "Refused" on the *Agents* page in System Center (see [Viewing information on the DMAs in a DMS](xref:Viewing_information_on_the_DMAs_in_a_DMS)), this means that the DMA is actively refusing incoming connections. This is a state that should automatically disappear after some time, if the conditions that caused the refusal are resolved.

The exact cause of the refusal can be found in the SLNet logging. Overall, there can be two reasons:

- There have been too many connections with the DMA in the past hours, as defined in the *MaxAgentConnectsPerHour* setting.

- The threshold in the *QueuedStackOverflow* setting is exceeded and the DMA is consequently dropping events.

With the SLNetClientTest tool, you can check and modify the thresholds defined for these settings. To do so:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down list at the top of the window, select an option and then configure it using the right-click menu in the pane below.

   - *MaxAgentConnectsPerHour*: The maximum number of connections SLNet is allowed to set up with a DMA within one hour. If more connections have been made, further connections are refused for 30 minutes.
   - *QueuedStackOverflow*: The maximum number of messages that can be pending for an SLNet subscriber. If more messages are queued than this maximum, the connection is destroyed.

If the underlying issue is resolved, you can also clear the refusal state using SLNetClientTest tool:

1. Go to *Info* > *A - M* > *DataMinerInfo*.

1. Right-click the DMA with the "Refused" connection state and select *Clear Connection Refusal*.

1. Click *OK* to close the pop-up window.

## Managing trend patterns

From DataMiner 10.1.0/10.1.2 onwards, it is possible to view and delete trend patterns that can be detected by DataMiner Analytics using the SLNetClientTest tool.

To do so, go to *Advanced* > *Analytics* > *Pattern Matching*. This will open a window where all patterns are listed.

- To view detailed information on a pattern, make sure the *See preview* checkbox is selected, and select the pattern in the list.

- To remove a pattern, select it in the list and click the *Delete* button.

> [!TIP]
> See also: [Working with pattern matching](xref:Working_with_pattern_matching)

## Fine-tuning NATS settings

From DataMiner 10.1.0/10.1.1 onwards, DataMiner processes use the NATS open-source messaging system to communicate with each other. From DataMiner 10.1.0/10.1.3 onwards, you can check and fine-tune the settings for this in the SLNetClientTest tool.

To do so:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. Depending on what you want to check or configure, select one of the following options in the drop-down box at the top of the window:

   - *NATSDisasterCheck*: If this is set to true, automatic detection and triggering of NATS cluster self-healing is activated (default: false).

   - *NATSResetWindow*: A value in seconds representing the time window during which only one NATS reset can occur. This prevents situations where NATS disaster recovery is triggered too often. The minimum value is 60.

   - *NATSRestartTimeout*: The maximum time (in seconds) to wait for NATS to restart (default: 10). A NATS restart can for example be necessary when an Agent goes offline or is removed from the DMS.

1. To modify the setting, right-click it in the table and select *Edit Value*.

1. Specify the new value and click *OK*.

## Changing the grace period for the SLNetCom Notification thread

When the SLNetCom notification thread reaches a certain threshold, DataMiner assumes something is wrong and stops processing messages. A DMA restart is then required. However, to make sure this does not happen when it is not needed in setups where the threshold is only briefly reached, there is a grace period where the DMA does not start ignoring messages for a short time (by default 1 minute). This feature is available from DataMiner 9.6.0 \[CU23\]/10.0.0\[CU14\]/10.1.0 \[CU3\]/10.1.6 onwards.

If necessary, you can change the duration of this grace period using the SLNetClientTest tool.

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *SLNetCOMNotificationsStackExceedsThresholdGracePeriodInMin*.

1. Right- click the DMA for which you want to edit the grace period and select *Edit value*.

1. Specify the new value and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

## Specifying credentials for a shared backup path for Elasticsearch

From DataMiner 10.2.0/10.1.8 onwards, it is possible to configure specific credentials for the network location that is used for Elasticsearch backups.

To do so:

1. Go to the *Build Message* tab of the main window.

1. In the *Filter* box, specify *SetElasticBackupPath*. A message ending in *SetElasticBackupPath* should then be selected in the *Message Type* box.

1. Specify the backup path, password and username in the corresponding fields.

1. Click *Send Message*.

## Configuring the frequency of smart baseline calculations

From DataMiner 10.2.7/10.3.0 onwards, you can change the frequency of smart baseline calculations using the SLNetClientTest tool.

On systems that aggregate large amounts of data from parameters with smart baselines, it can be useful to increase this frequency. By default, it is set to 5 minutes.

To change this frequency:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *SmartBaselineThreadTime*.

1. Right-click the DMA for which you want to change the setting and select *Edit value*.

1. Specify the new value and click *OK*.

1. Click *OK* to close the *SLNet Options* window.

## Disabling automatic NATS configuration

From DataMiner 10.2.0 \[CU6]/10.2.8, you can enable the *NATSForceManualConfig* option so that NATS is not automatically configured in your DataMiner System. When you do so, you will need to either configure a NATS cluster manually instead, or manually call the *NatsCustodianResetNatsMessage* when changes are made to the DMS (see [Try a NATS reset](xref:Investigating_NATS_Issues#try-a-nats-reset)).

To disable automatic NATS configuration:

1. Go to *Advanced* > *Options* > *SLNet Options*.

1. In the drop-down box, select *NATSForceManualConfig*.

1. Right-click the DMA for which you want to change the setting and select *Edit value*.

1. Specify *true* and click *OK*.

1. Click *OK* to close the *SLNet Options* window.
