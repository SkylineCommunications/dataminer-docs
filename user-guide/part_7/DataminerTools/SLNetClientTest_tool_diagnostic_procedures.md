## SLNetClientTest tool diagnostic procedures

This section contains the following procedures:

- [Consulting license information for a DMA](#consulting-license-information-for-a-dma)

- [Verifying Sync rules](#verifying-sync-rules)

- [Debugging callback timeout errors](#debugging-callback-timeout-errors)

- [Consulting replication information for other DMAs in a DMS](#consulting-replication-information-for-other-dmas-in-a-dms)

- [Inspecting the active replication buffers](#inspecting-the-active-replication-buffers)

- [Consulting Correlation information](#consulting-correlation-information)

- [Activating verbose Correlation logging](#activating-verbose-correlation-logging)

- [Tracking DMA communication](#tracking-dma-communication)

- [Consulting connection details](#consulting-connection-details)

- [Creating a dump file for a particular process](#creating-a-dump-file-for-a-particular-process)

- [Requesting information about pending incoming events](#requesting-information-about-pending-incoming-events)

- [Exporting data to a CSV file](#exporting-data-to-a-csv-file)

- [Retrieving DCF debug information](#retrieving-dcf-debug-information)

- [Checking a hyperlink filter](#checking-a-hyperlink-filter)

- [Requesting an estimate of the number of rows for a storage type in the database](#requesting-an-estimate-of-the-number-of-rows-for-a-storage-type-in-the-database)

- [Requesting a list of active merge actions for a protocol](#requesting-a-list-of-active-merge-actions-for-a-protocol)

- [Retrieving connection info for a particular element](#retrieving-connection-info-for-a-particular-element)

- [Retrieving information on open GQI sessions](#retrieving-information-on-open-gqi-sessions)

### Consulting license information for a DMA

> [!NOTE]
> To view license information regarding third-party software, go to *http(s)://**\[DMA name or IP\]**/Licenses* (available from DataMiner 9.5.14 onwards).

After you have connected to a DMA with the SLNetClientTest tool, do the following to get a list of all the applications the DMA is licensed for, the license verification method, and the license expiration date:

- In the *Info* menu, select *A -M* > *Licenses*.

    In the *Properties* tab of the main window, a new message will appear. You can double-click the message to read the details in a separate window, or select the message and read the details in the *Text* pane on the right.

To get an overview of the number of elements monitored with license counters, do the following

- In the *Info* menu, select *A -M* > *ActivatedLicenseCounters*.

    In the *Properties* tab of the main window, a new message will appear. You can double-click the message to read the details in a separate window, or select the message and read the details in the *Text* pane on the right.

    > [!NOTE]
    > To know the total number allowed by the license, in the list of applications a DMA is licensed for, look for keys with a number at the end, e.g. ELEMENTS500, SPECTRUMELEMENTS10, PROTOCOLMICROSOFTPLATFORM:5. The number indicates the total allowed license counters.

### Verifying Sync rules

The SlNetClientTest tool allows the user to check which Sync rules are in effect on a DMA. To do so:

1. In the *Diagnostics* menu, select *DMS* > *Config*.

2. Select the new message that appears in the *Properties* tab of the main window, and read the details in the *Text* pane on the right. The Sync rules are listed at the bottom of the pane.

    > [!NOTE]
    > - This info also lists the detected versions per DMA in the cluster. If version info for local IP addresses or Sync IP addresses is known, which is mainly for Failover Agents, there is also a section “Extra known versions.”
    > - Any DMAs running DataMiner versions prior to 8.5.5 will be considered to be running 8.0.0, as the version cannot be detected in that case.

> [!TIP]
> See also:
> [SyncRules.xml](../SkylineDataminerFolder/SyncRules_xml.md#syncrulesxml)

### Debugging callback timeout errors

When clients connect to a DataMiner Agent via eventing, the server can throw out the client when it takes longer than a particular number of seconds (default: 30) to send a packet of events to that client over the callback connection. In that case, a "callback timeout (waited 30 s)" type error is generated. This mechanism also applies to connections between DataMiner Agents. Possible reasons for such callback timeouts could be an unreachable destination (e.g. client was stopped, or firewall intervened), or also that the packet of data being forwarded is too large.

To debug such errors, you can do the following in the SLNetClientTest tool:

1. In the *Diagnostics* menu, select *Runtime Logging*.

2. Select *Hidden Messages*, and click *Apply*.

    The "callback timeout (30 s)" type error will now contain extra information, e.g. "callback timeout (waited 30 s; 251 messages; 570 KB)". A line of logging will also be generated in the SLNet log file.

3. In the *Advanced* menu, select *Options* > *SLNet Flags*.

4. In the *SLNet RunTime Flags* window, double-click *dumpCallbackTimeoutData*.

    Whenever a callback timeout is encountered, the packet of messages will now be dumped into an .slnetdump file in the following folder: *C:\\Skyline DataMiner\\logging\\CallbackTimeoutDumps*. You can open this file in the SLNetClientTest tool by going to *File* > *Dump* > *Open*.

> [!NOTE]
> These options are not remembered across SLNet restarts, and apply to one DataMiner Agent only.

### Consulting replication information for other DMAs in a DMS

It is possible to request information on the number of source elements and services on a DMA that are being replicated by other DMAs in the DataMiner System.

To do so:

- In the *Diagnostics* menu, select *Caches & Subscriptions \> ReplicationInfo.*

### Inspecting the active replication buffers

To solve issues with replication buffering, it is possible to inspect the active replication buffers with the SLNetClientTest tool, and also to drop a specific buffer.

To view a list of all active replication buffers:

- In the *Diagnostics* menu, select *Caches & Subscriptions* > *ReplicationBufferStats*.

    In the *Properties* tab of the main window, a new message will appear that lists the number of active buffers. For detailed information, double-click the message, or select the message and check the *Text* pane on the right.

To drop one specific replication buffer:

1. Go to the *Build Message* tab of the main window.

2. In the *Message Type* drop-down list, select *DiagnoseMessage*.

3. In the *ExtraInfo* field, specify "drop:\[bufferkey\]", where \[bufferkey\] is the key of the replication buffer you want to drop. Replication buffer keys are listed in the replication buffer stats (e.g. "hostname/ipaddress/dmaid/eid")

4. In the *Type* field at the bottom, select *ReplicationBufferStats*.

> [!NOTE]
> When a replication buffer saves files to disk, those files are located in C:\\Skyline DataMiner\\ System Cache\\SLNet and are named "ReplicationBuffer_clienthostname_ip_dmaid_eid_objectid.bin".

### Consulting Correlation information

The SLNetClientTest tool provides several functions to get more information about Correlation on a DMA.

To consult information about the Correlation engine, do the following:

1. In the *Diagnostics* menu, select *Correlation* > *CubeCorrelationStats.*

2. Double-click the new message that appears in the *Properties* tab of the main window, or select the message and check the *Text* pane on the right.

    The message will among others contain the stack size, a list of remote subscriptions from other Agents in the cluster, the last known remote Agent states (connected or disconnected), and some counters about the number of forwarded events between Agents.

To consult information about the Correlation rules of a DMA:

- In the *Advanced* menu, select *Correlation* > *Rule Status*.

    This opens the *Correlation Rule Status* window, which has several options:

    - To view disabled rules, clear the selection from *Hide Disabled*. Disabled rules will then be shown in gray.

    - To view remote rules, clear the selection from *Hide Remote*.

    - To view internal system rules, clear the selection from *Hide System*.

    - To automatically refresh the rule status, select *Auto Refresh* and specify a refresh interval (default: 5 seconds).

    The window lists the DMA handling each rule, buckets, sliding window status, etc. The context menu of the entries in the *Buckets* pane provides access to more detailed info.

### Activating verbose Correlation logging

To activate verbose Correlation logging:

1. In the *Advanced* menu, select *Options* > *SLNet options.*

2. In the list at the top of the *SLNet Options* window, select *CorrelationLogVerbose*.

    A list of the Agents in the cluster will be displayed, indicating for each of them whether verbose Correlation is activated.

3. In the *Value* column, right-click the “false” value for the Agent for which you wish to activate verbose Correlation logging, and select *Edit value*.

4. Enter “true” and click *OK*.

> [!NOTE]
> This option is saved into the file *MaintenanceSettings.xml* under the *\<SLNet>* tag. It is not synchronized across Agents in the DMS.

### Tracking DMA communication

Via the *Follow* menu, you can activate follow mode for several aspects of DMA communication. Messages will then appear in the *Properties* tab of the main menu as the DMA communication is tracked.

To activate follow mode:

1. Select which aspects of communication should be followed:

    - *Events* and *Requests/Responses* are selected by default, to track events that are sent to a client and requests and responses respectively.

    - Select *Include Polling* to track all polling.

    - Select *Wire* to track events after they have been pushed over an eventing callback or returned in a polling response. This can be useful to verify that events have been pushed onto the wire in diagnostic scenarios.

2. Optionally, if you want a transcript to be saved at the moment when follow mode is deactivated, select *Store Transcript*.

    > [!NOTE]
    > - To open a transcript later, go to *File* > *Dump* > *Open*.
    > - This option is no longer available from DataMiner 9.5.8 onwards. However, you can instead save a transcript via *File* > *Dump* > *Save*.

3. Select what should be followed. The following options are available:

    - *Hook into Active Session*: Allows you to select a particular item to follow from the current active session, e.g. SLBrain.exe

    - *Hook into Custom Active Session*: Allows you to specify a particular connection ID

    - *Hook into Next Session*: Allows you to select a particular client to follow for the next session.

    - *Hook into ALL Sessions*: Follows all sessions.

4. Optionally, from DataMiner 9.5.8 onwards, you can select the *Clone* option. This will follow a clone of the original event/request/response, to keep server-side changes to these objects from being included in the follow data. However, note that this option does increase the load on the server.

5. Click *OK*.

To stop follow mode, in the *Follow* menu, select *Stop Following*.

### Consulting connection details

To view connection details for a specific client or process, do the following:

- In the *Diagnostics* menu, select *Connection details*, and then select the client or process for which you want to see the connection details.

    The detailed information will open in a separate window. It mentions among others the time when the connection was made and the time of the last activity, the number of bytes of requests, responses and events, whether the connection was made via .NET Remoting or via Web Services, and much more. From DataMiner 9.6.4 onwards, this also mentions whether protocol buffer serialization ("ProtoBuf") is enabled.

To view the number of currently active calls between different DMAs in the DMS:

- In the *Diagnostics* menu, select *Connections* > *View DMA Connections*.

    The *Agent Connections* window will be displayed. This window lists among others the number of waiting and active calls towards the DMA (“*Calls to*”) and coming in from a remote DMA (“*Calls From*”), and the number of event packets that have been received from the remote DMA but not yet processed (“*Pending Event Packs*”).

### Creating a dump file for a particular process

With the SLNetClientTest tool, you can create a dump file for a process, i.e. a snapshot of that process at a particular time. To do so:

1. In the *Advanced* menu, select *Request dump*, and select the process for which you want to create a dump file. You can also select *(other)*, and enter the PID for which you want to create a dump file.

2. In the *Select Dump Level* window, indicate what information should be included in the dump file, and click *OK*.

    A file with the extension .dmp will be saved in the folder *C:\\Skyline Dataminer\\logging\\CrashDump*.

### Requesting information about pending incoming events

With the SLNetClientTest tool, there are two ways to request information on the number of events being passed from one DMA to another:

- To see a “Pending Incoming” count, go to *Diagnostics \> SLNet \> DataMinerConnections*.

- To see the list of incoming event packages waiting to be processed, go to *Diagnostics* > *Connections* > *OpenClientConnections*.

### Exporting data to a CSV file

For debugging purposes, you can export data from the SLNetClientTest tool to a CSV file that is updated whenever the data is refreshed. The data in that file can then, for example, be used to track the evolution of a certain value over time.

1. From SLNetClientTest, request info which can be displayed in a refreshable text window. E.g. *Diagnostics \> SLNet \> StackSizes*.

2. Double-click the relevant message in the main window to open the text window.

3. In the text window, select *Export* and either select an existing export file or select *\<Add New>* to add a new file.

    > [!NOTE]
    > Multiple exports can be added for the same window.

4. Configure the export file in the *Export Configuration* window and click *Save*.

    A line will be added to the CSV file whenever the data is refreshed (manually or automatically).     Closing the main window will stop the export.

To delete existing exports, follow the same procedure, and click delete in the *Export Configuration* window.

### Retrieving DCF debug information

To get debug information on DCF connections, from DataMiner 9.0.0 CU16/9.5.3 onwards, you can send SLNet requests for DCF path highlighting with a DEBUG flag.

Responses will then contain a DebugInfo string with additional information on why certain connections were added and others were not. This information also includes the service context match or mismatch, the direction that was used to resolve the connections, the element path found, the top 10 most frequent connections in case of a circular dependency, and protocol links that were not applied.

This can for example be of use when an exception is thrown because a possible circular dependency is detected, as you can then use the DEBUG flag to check which path was calculated.

To retrieve DCF debug information:

1. Go to the *Build Message* tab of the main window of the SLNetCLientTest tool.

2. In the *Message Type* drop-down list, select one of the following messages, depending on which information you want to retrieve:

    - *GetAlarmConnectivityMessage*

    - *GetElementConnectivityMessage*

    - *GetRCAConnectivityMessage*

    - *GetRedundancyConnectivityMessage*

    - *GetServiceConnectivityMessage*

3. Set the *Debug* field to *True*.

4. Click *Send Message*.

    In the *Properties* tab of the main window, a new message will appear with the debug information. Select the message to view the details in the *Text* pane on the right.

### Checking a hyperlink filter

From DataMiner 9.5.7 onwards, filters can be specified with a *filterElement* attribute in Hyperlink tags in *Hyperlinks.xml*. In the SLNetClientTest tool you can test such filters:

1. Go to *Offline Tools* > *FilterElementChecker*.

2. Specify the filter in the *Filter as string* section.

3. On the right, specify the object that has to match the filter.

4. Click *Check Filter* to check whether the filter is valid and matches the specified object.

> [!TIP]
> See also:
> [filterElement](../SkylineDataminerFolder/Hyperlinks_xml.md#filterelement)

### Requesting an estimate of the number of rows for a storage type in the database

From DataMiner 9.5.13 onwards, it is possible to request an estimate of the how many rows there are for a certain storage type in the database.

Retrieving this information via the SLNetClientTest tool instead of via a query has the advantage that you do not risk a timeout of the query. However, for large tables, it can take a while before the estimate is returned.

To request such an estimate:

1. Go to *Advanced* > *Database* > *Estimate Count.*

    The *Estimate Database Row Count* window will open.

2. Next to *Type*, select the data type for which you wish to get the estimate.

3. Optionally, next to *Filter*, specify a filter to limit the number of rows that are taken into account.

4. Click *Count*.

    The estimate will be displayed at the bottom of the window.

### Requesting a list of active merge actions for a protocol

From DataMiner 9.5.14 onwards, it is possible to request a list of currently active merge actions for protocols doing aggregation actions. This can be useful as debug information in case aggregated values do not update as intended.

To do so:

1. Go to *Diagnostics* > *DMA* > *Protocol Active Merge Actions*.

2. Enter either the DMA ID and element ID or the element name, and click *OK*.

    The result will be displayed in the *Output* tab of the tool.

### Retrieving connection info for a particular element

From DataMiner 9.6.13 onwards, it is possible to retrieve connection information for a particular element. This can for instance be useful to detect the reason for timeouts.

To do so:

1. Go to *Diagnostics* > DMA \> *Protocol Connection States*.

2. In the pop-up window, enter the name or the DMA ID/Element ID of the element and click *OK*.

    The connection information will be displayed in the *Output* tab of the tool.     If a timeout status is listed, this is the internal timeout status, without taking the configured element timeout time into account (which means that the element might not yet be considered to be in timeout in DataMiner).

### Retrieving information on open GQI sessions

From DataMiner 10.2.0/10.1.7 onwards, you can retrieve information on how many GQI (i.e. generic queries interface, the interface used for queries in the Dashboards app) sessions are currently open.

To view this information, go to *Advanced* > *GQI* > *Sessions*. This will open a window with the session ID, creation time and last update time of each of the current sessions.

You can refresh the displayed information with the *Refresh* button at the top of the window.
