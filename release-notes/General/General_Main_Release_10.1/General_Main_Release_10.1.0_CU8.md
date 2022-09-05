---
uid: General_Main_Release_10.1.0_CU8
---

# General Main Release 10.1.0 CU8

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### SLLogCollector: Command line support \[ID_26293\]

The SLLogCollector tool now supports the following command line options:

| Option             | Function                                                                                       |
|--------------------|------------------------------------------------------------------------------------------------|
| -c, --console      | Use the SLLogCollector console.                                                                |
| -h, -?, --help     | List syntax and available options.                                                             |
| -f, --folder=VALUE | Specify the folder in which the zipped log files will be stored. Default: C:\\Skyline_Data\\   |
| -d, --dumps=VALUE  | Specify the comma-separated list of processes from which dumps should be taken (IDs or names). |
| -m, --memory=VALUE | Take an extra dump as soon as the process uses the specified amount of memory (in MB).         |

#### StandAloneBPAExecutor: New command line option to save test result to file \[ID_27776\]

The StandAloneBpaExecutor tool, which can be found in the C:\\Skyline DataMiner\\Tools folder of a DMA, can be used to execute BPA (Best Practice Analysis) tests.

When using this tool to run a test from a command line, it is now possible to have the test result stored in a JSON file.

| Option                                                      | Function                                                   |
|-------------------------------------------------------------|------------------------------------------------------------|
| -f “PATH/TO/FILE.json”<br> or<br> -file “PATH/TO/FILE.json” | Specify the file in which the test results will be stored. |

#### Cassandra: Alarm squashing setting will by default be set to false when it cannot be requested from SLNet \[ID_30309\]

From now on, when it is not possible to request the value of the alarm squashing setting from SLNet when retrieving alarms from a Cassandra database, by default the alarm squashing setting will be considered false.

#### Alarm templates: Baseline editor now allows you to configure baselines and smart baselines specified in protocols \[ID_30388\] \[ID_30461\]

Up to now, when a parameter had a (smart) baseline value specified in the protocol, it was not possible to update that (smart) baseline value in Cube’s alarm template baseline editor. From now on, that editor will allow you to configure (smart) baselines specified in protocols.

> [!NOTE]
>
> - The alarm template baseline editor will not allow you to change the monitoring type (Normal, Relative, Absolute or Rate).
> - When a baseline is specified in a protocol, the baseline value is stored in a separate parameter. Although you should specify a read parameter (e.g. \<Alarm type="absolute:READ_PARAM_ID,108">), make sure that read parameter has an associated write parameter. Otherwise, it will not be possible to update the baseline value stored in that parameter. Also, the parameter in which the baseline value is stored must be free of any restrictions (e.g. step size, number of decimals, high/low range, etc.)

#### Security enhancements \[ID_30494\]

A number of security enhancements have been made.

#### No longer possible to launch a system-wide upgrade procedure when one agent fails to upload the upgrade package \[ID_30511\]

Up to now, when an agent in a DataMiner System failed to upload a DataMiner upgrade package, it would still be possible to launch the system-wide upgrade procedure. From now on, as soon as one of the agents in a DataMiner System fails to upload an upgrade package, it will not be possible to launch a system-wide upgrade procedure.

#### SLElement: Enhanced service impact calculation \[ID_30648\]

A number of enhancements have been made to the way in which SLElement calculates the service impact of an alarm.

#### Enhanced performance when enabling virtual functions with monitored parent elements \[ID_30673\]

Due to a number of enhancements, overall performance has increased when enabling virtual functions with monitored parent elements.

#### Interactive Automation scripts: File selector component can now be configured to only allow a script to continue after a file has been uploaded \[ID_30728\]

In an interactive Automation script that is used in Dashboards, you can now configure a file selector component to only allow a script to continue after a file has been uploaded. To do so, set the property *IsRequired* to true.

For example:

```csharp
UIBlockDefinition uibDef = new UIBlockDefinition();
uibDef.Type = UIBlockType.FileSelector;
...
uibDef.IsRequired = true;
```

#### Enhanced performance when determining the virtual impact of an alarm \[ID_30766\]

Overall performance has increased when determining the virtual function impact of an alarm.

Also, a number of issues have been fixed with regard to displaying statuses of virtual function alarms, exporting alarms to DVE child elements, masking of external alarms and updating virtual function states when alarms are cleared.

#### DataMiner Cube - Alarm Console: Availability of 'Count alarms' button now depends on the alarm filter that was specified \[ID_30810\]

When, in the Alarm Console, you add a new history or sliding window tab page, you can add a filter by clicking *Apply filter*. After configuring that filter, you can click *Count alarms* to see how many alarms will be retrieved when that filter is applied. However, up to now, when the filter contained one of the following items, it would not be possible to count the number of alarms that matched the filter:

- ElementType
- InterfaceImpact
- ParameterDescription
- Protocol
- ServiceImpact
- ViewID
- ViewImpact
- ViewName
- VirtualFunctionID
- VirtualFunctionImpact
- VirtualFunctionName

From now on, when the alarm filter contains one of the above-mentioned items, the *Count alarms* button will not be available.

#### Automation scripts: SLAnalyticsTypes.dll added to the list of default DLL references \[ID_30821\]

All Automation scripts will now by default have a reference to the SLAnalyticsTypes.dll file.

#### BREAKING CHANGE: DataMiner installer will only enable ICMP and HTTP ports 80 & 8004 \[ID_30913\]

From now on, the DataMiner installer will by default only enable

- ICMP (ping) and
- HTTP ports 80 and 8004.

> [!NOTE]
> When you enable Telnet or the SNMP agent feature, from now on, you will have to manually create a firewall rule for the HTTP ports in question.

#### DataMiner Cube - Aggregation: Enhanced performance \[ID_30917\]

Due to a number of enhancements, overall performance of the Aggregation module has increased.

#### SLDataGateway: Enhanced startup routine \[ID_30934\]

A number of enhancements will now allow the SLDataGateway process to handle Cassandra exceptions and file offload initialization errors more efficiently, which may prevent startup issues.

#### Ticketing: FieldName of TicketFieldDescriptor can no longer contain certain characters [ID_30962]

From now on, the FieldName of a TicketFieldDescriptor has to meet the following requirements:

- It cannot start with an underscore character ("\_").
- It cannot contain any of the following characters:

  - . (period)
  - \# (number sign)
  - \* (asterisk)
  - , (comma)
  - " (double quote)
  - ' (single quote)

#### DataMiner Cube - System Center: Enhanced 'Limited administrator' tooltip \[ID_31042\]

When, in the *Users/Groups* section of *System Center*, you hover over the *Modules \> System configuration \> Security \> Specific \> Limited administrator* permission, a tooltip gives you more information about that permission. That tooltip now contains the following updated text:

```txt
* Read-only access on all groups 
* Read-only access to users in your groups 
* Create new DataMiner users 
* Editing your own user properties
```

### Fixes

#### Problem when starting Kibana after restoring an Elasticsearch backup \[ID_29943\]

After restoring an Elasticsearch backup that was taken with the StandaloneElasticBackup tool, in some cases, it would no longer be possible to start Kibana when Elasticsearch had security enabled.

#### Dashboards app - Node edge graphs: Parameter values in node tooltips would incorrectly show 'not initialized' \[ID_30694\]

When you hovered over a node, parameter values shown in the node tooltip would incorrectly be set to “not initialized”.

#### Elasticsearch installations would fail on systems on which Cassandra was installed remotely \[ID_30731\]

On systems on which Cassandra was installed remotely, in some cases, Elasticsearch installations would fail.

#### DataMiner Cube - Settings: User group settings not taken into account when applying regional settings \[ID_30813\]

When starting up, up to now, Cube would load the regional settings before loading the user group settings. As a result, it would only take into account the user settings when applying the regional settings. From now on, Cube will also take into account the user group settings when applying the regional settings.

#### SLSNMPManager: Problem when using MultipleGetBulk to poll a table containing only a single row \[ID_30815\]

When MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm would get stuck into an infinite loop.

#### DataMiner Cube - Visual Overview: Child shapes representing alarms would incorrectly appear on a white background \[ID_30820\]

When generating child shapes that represent alarms, up to now, those child shapes would always appear on a white background, even when the Cube theme was set to e.g. Skyline Black.

From now on, generated child shapes that represent alarms will appear on a transparent background instead.

#### Confusing 'Already authenticated error' would be thrown when an error occurred during an authentication process \[ID_30827\]

When an error occurred during an authentication process, in some cases, a confusing “Already authenticated” exception would be thrown instead of the actual error message. From now on, the actual error message will be thrown.

#### DataMiner Cube: Alarm counter in alarm storm warning did incorrectly not decrease when alarms were cleared \[ID_30836\]

When, during an alarm storm, you hover the mouse pointer over the alarm storm warning, a tooltip appears, showing you which alarms are causing the storm and the number of alarms per parameter. Up to now, when one of those alarms got cleared, the number of alarms shown in the tooltip would incorrectly not decrease.

#### Compiled QAction DLL files would incorrectly not be deleted from the ProtocolScripts folder when a protocol was deleted \[ID_30841\]

When a protocol was deleted, up to now, the compiled QAction DLL files would incorrectly not get deleted from the C:\\Skyline DataMiner\\ProtocolScripts folder.

#### SLElement: ParameterThread error \[ID_30855\]

In some cases, a ParameterThread error could occur in SLElement.

#### Interactive Automation scripts: Value returned by the client would incorrectly be considered as an invalid file path selected in a file selector block \[ID_30879\]

When, in an interactive Automation script, a file selector block was defined after another type of input block (e.g. a checkbox), in some cases, the input block value returned by the client would incorrectly be considered as an invalid file path selected in the file selector. As a result, an “Invalid Data” error would be thrown.

#### DataMiner Cube - Alarm Console: Incorrect notices like '!! Unknown \<Type> R!AD for parameter xxx' \[ID_30884\]

In some rare cases, notices like “!! Unknown \<Type> RE!D for parameter 123” would incorrectly appear in the Alarm Console.

#### Protocols: Double values with leading zeros would not be displayed correctly when using scientific notation \[ID_30892\]

In some cases, double values with leading zeros would not be displayed correctly when using scientific notation.

#### Protocols: QActions and their compiled versions could get linked incorrectly \[ID_30896\]

In some rare cases, errors occurring in SLScripting or SLProtocol could cause QActions and their compiled versions to be linked incorrectly.

#### SLReset tool would incorrectly stop deleting files when it encountered a locked file \[ID_30906\]

In some cases, the SLReset tool would incorrectly stop deleting files when it encountered a locked file.

#### DataMiner Cube - View cards: Aggregation page would incorrectly be loaded as soon as a view card was opened \[ID_30907\]

In some cases, the Aggregation page of a view card would incorrectly be loaded as soon as you opened the card. From now on, the Aggregation page of a view will only be loaded when you select that page.

#### DataMiner Cube - Service definitions: Selection boxes would incorrectly contain raw values instead of display values \[ID_30916\]

When you configured a service definition, in some cases, selection boxes would incorrectly contain raw values instead of display values.

#### Problem when disabling a virtual function and then enabling it again \[ID_30918\]

When you disabled a virtual function and then enabled it again, in some rare cases, it would incorrectly disappear from the system.

#### Problem with SLDataMiner when deleting a service or a redundancy group \[ID_30925\]

In some cases, an error could occur in SLDataMiner when a service or a redundancy group was deleted.

#### Automation: Problem with ScriptEntry.GetHashCode method \[ID_30939\]

In some cases, calling the ScriptEntry.GetHashCode method could cause a NullReference-Exception to be thrown.

#### Problem with SLAutomation when a Timespan.MaxValue timeout had been defined \[ID_30946\]

In some cases, SLAutomation would throw an ArgumentOutOfRangeException when a Timespan.MaxValue timeout had been defined.

#### Legacy Reporter: Problem with SLASPConnection when requesting trend statistics \[ID_30966\]

In some cases, an error could occur in SLASPConnection when requesting trend statistics (Minimum/Maximum/Average).

#### Alarms in tables that were part of multiple relation paths for different DVEs would not get re-evaluated when a DVE was created \[ID_30979\]

In some cases, an alarm in a table that was part of multiple relation paths would not get re-evaluated when a DVE in one of those paths exported that alarm. As a result, the alarm would not get exported to the DVE child element, causing the element state to become incorrect.

#### DVE element information would no longer be written to the database \[ID_31004\]

In some cases, DVE element information would no longer be written to the database due to a NullReferenceException in SLDBConnection.

#### DataMiner Cube - Visual Overview: Problem with navigation buttons on visual pages after clicking a card’s Back button \[ID_31012\]

When you clicked a card’s Back button, in some cases, the navigation buttons on the card’s visual pages could start to behave incorrectly.

#### DataMiner Cube: Asset Manager app failed to initialize \[ID_31072\]

In some cases, the Asset Manager app would fail to initialize.

#### Run-time errors in ParameterThread when defining a column parameter in the functions.xml \[ID_31074\]

In some cases, run-time errors could occur in the ParameterThread when defining a column parameter in the functions.xml.

#### Table row exports for DVEs and virtual functions would trigger updates to be sent when no client applications were connected \[ID_31156\]

In some cases, table row exports for DVEs and virtual functions would trigger updates to be sent, even when no client applications were connected.
