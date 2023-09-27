---
uid: General_Main_Release_10.1.0_CU7
---

# General Main Release 10.1.0 CU7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_30124\] \[ID_30479\] \[ID_30570\] \[ID_30581\] \[ID_30597\] \[ID_30600\] \[ID_30604\] \[ID_30786\]

A number of security enhancements have been made.

#### Service & Resource Management: Interface state calculation for virtual function interfaces disabled \[ID_30537\]

As the interfaces of virtual functions are generated from a table that cannot be monitored, the interface state calculation for these interfaces is now disabled. This may result in improved performance.

#### Service & Resource Management: Improved performance when processing virtual functions \[ID_30585\]

A number of enhancements have been implemented to improve performance when processing virtual functions.

#### Alarm templates - Smart baselines: Calculated baseline values outside the value range will automatically be set to the nearest value in the range \[ID_30704\]

When a calculated baseline value is outside the baseline value range, from now on, it will automatically be set to the nearest value in the range.

Examples:

- If the baseline value range is 10-50 and the calculated value is 7, it will be set to 10.

- If the baseline value range is 10-50 and the calculated value is 58, it will be set to 50.

#### Dashboards app - Table components: Selecting multiple rows on an Apple Mac computer \[ID_30734\]

When working inside a table component using an Apple Mac computer, up to now, it was not possible to select multiple rows. From now on, users of an Apple Mac computer will be able to select multiple table rows while holding down the *Command* key.

Also, on an Apple Mac computer, it will now be possible to sort a table on multiple columns by clicking column headers while holding down the *Command* key.

#### SLElement: Enhanced performance when looking up linked rows after a foreign key has changed \[ID_30747\]

Due to a number of enhancements, overall performance of SLElement has increased when looking up linked rows after a foreign key has changed.

#### Web Services API v1: SetParameter and SetParameterRow methods can now also be used to update parameters of enhanced services \[ID_30823\]

The SetParameter and SetParameterRow methods of the DataMiner Web Services API v1 can now also be used to update parameters of enhanced services.

### Fixes

#### Ticketing app: Problem with drop-down fields \[ID_29478\]

When you added or updated options in a field of type “drop-down list”, in some cases, the default values of those options were not filled in correctly.

Also, when you turned a field into a field of type “drop-down list”, in some cases, a null reference exception could be thrown.

#### Slow initial synchronization of services in DMS \[ID_30074\]

In some cases, it could occur that the initial synchronization of services in a DMS was slow because of unnecessary errors generated in the SLDMS process. Usually, an error similar to the following was logged:

```txt
2021/06/03 01:00:00.302|SLDMS.txt|SLDMS.exe 10.1.2118.668|13524|26072|CSystem::ResolveServicePaths|ERR|-1|Failed resolving hosting DMA info for 10.10.80.20 and service RT_ServiceCreationDelete_66_2021_06_03_00_58
```

#### Dashboards app - GQI: 'Start from' option would not be available when the Queries.json file was empty or missing \[ID_30157\]

When building a GQI query, in some cases, the “Start from” option would not be available when the *C:\\Skyline DataMiner\\Generic Interface\\Queries.json* file was empty or missing.

#### Improved performance when including/excluding elements in services based on alarm or element alarm state \[ID_30303\]

Performance has improved when elements are dynamically included or excluded in a service based on alarm state or element alarm state.

#### Dashboards app: Problem with query linked to table component \[ID_30372\]

When a query in a dashboard was linked to a table component, it could occur that the query could not be rebuilt. In some cases, an error was shown in the data pane, e.g. "Cannot ready property 'selectedBlock' of undefined".

#### Problem with conditional monitoring after alarm template update \[ID_30531\]

When an alarm template was refreshed in the SLElement process, e.g. because the alarm template was modified or the baseline changed, it could occur that conditional monitoring was ignored for standalone parameters. Because of this, if a parameter was not monitored because the condition for this was met, it was shown as monitored regardless.

#### Dashboards app: Table incorrectly identified by display name instead of ID \[ID_30591\] \[ID_30684\]

Previously, if a query in a dashboard used the data source "Get parameter table by ID", the table was identified by its display name. However, as this is not necessarily unique in a protocol, this could cause incorrect results. New queries will now us the table ID as the identifier, though they will display the name in the UI.

#### Automation: CheckboxList and RadiobuttonList not decoding backslash correctly \[ID_30605\]

In an interactive Automation script, it could occur that the *CheckboxList* and *RadiobuttonList* components did not correctly decode a backslash ("\\") character.

#### Information about running elements missing in SLProtocol logging \[ID_30612\]

Since DataMiner 9.6.0/9.6.1, information about running elements could be missing in the SLProtocol logging.

#### DataMiner Cube - Spectrum Analysis: Problem when retrieved client session data contained duplicate keys \[ID_30644\]

When you open a spectrum analyzer element in Cube, it will retrieve all client sessions of that spectrum element. Up to now, when the retrieved client session data contained duplicate keys, an exception could be thrown. From now on, a log entry will be generated instead.

#### GetAlarmFilterResponse and GetTrendFilterResponse messages caused protocol buffer serialization errors \[ID_30650\]

In some cases, it could occur that the *GetAlarmFilterResponse* and *GetTrendFilterResponse* messages failed to be serialized even though these were marked as eligible for protocol buffer serialization. An error similar to the following could be displayed in the Cube logging:

```txt
Message : Index was outside the bounds of the array.
Exception : (Code: 0x80131508) Skyline.DataMiner.Net.Exceptions.DataMinerException: Index was outside the bounds of the array. ---> System.IndexOutOfRangeException: Index was outside the bounds of the array.
   at System.Collections.Generic.List\`1.Add(T item)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.Log(String method, String text)
   at Skyline.DataMiner.Net.Serialization.ProtoBufSerializationManager.ProtoBufPackMessage(DMSMessage rawMessage)
```

The scenarios where these messages cannot be serialized will now be handled better, so that they can no longer cause errors. In addition, to make it easier to troubleshoot errors with protocol buffer serialization, a new *SLProtobufSerialization.txt* log file is now available.

#### DataMiner Cube: Problem with table filters \[ID_30658\]

In Data Display and Visual Overview, in some cases, table filters could yield incorrect results when they contained numeric column filters with a “\<=”, “=”, or “=>” operator.

#### DataMiner Cube: No reports or alarm heatlines shown for view table parameters \[ID_30667\]

Up to now, for view table parameters, no reports were shown on the details page for the parameter in DataMiner Cube. In addition, no alarm heatline was shown for these parameters in trend graphs.

#### Spelling error in exception when minimum software version requirements for app package not met \[ID_30672\]

When an app package was installed on a DMA but the minimum software version requirements were not met, the exception message contained a spelling error.

```txt
Could not install the package because it requires DataMiner version {appInfo.MinDmaVersion}, but this agent us running version {dataMinerVersion}.
```

#### Dashboards app: Trace not displayed for spectrum buffer \[ID_30686\]

If a Spectrum analyzer component in the Dashboards app was used to visualize a spectrum buffer, it could occur that the buffer trace was not displayed.

#### CRC parameter with LengthType 'fixed' and RawType 'other', 'text' or 'numeric text' would incorrectly always be set to 0x20 or 0x30 \[ID_30730\]

When a CRC parameter with LengthType “fixed” and RawType “other”, “text” or “numeric text” was used in a command, it would incorrectly always be set to 0x20 characters for parameter of type “string” or 0x30 characters for parameters of type “double”.

#### Problem with SLDataMiner when using alarm templates with a monitoring schedule \[ID_30732\]

In some cases, an error could occur in SLDataMiner when alarm templates with a monitoring schedule were being used.

#### Problem with SLDataMiner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded \[ID_30743\]

In some cases, an error could occur in SLDataMIner when an element was restarted while a protocol exporting DVE or function protocols was being uploaded.

#### DataMiner Cube - Visual Overview: Cube could become unresponsive while retrieving service states \[ID_30762\]

When a visual overview with at least one service shape was open when you opened a Cube, and the initial service states had not yet been received, in some cases, Cube could become unresponsive while retrieving the service states.

#### DataMiner Cube: Problem when hovering the mouse pointer over an alarm storm warning \[ID_30799\]

When, during an alarm storm, you hovered the mouse pointer over the alarm storm warning, in some cases, an exception could be thrown.

#### DataMiner Cube - Alarm Console: Comments containing a new line would be displayed incorrectly \[ID_30801\]

When an alarm contains one or more comments, you can right-click it and select “View comments” to see all comments in the alarm tree in question. In that list, up to now, comments containing a new line would not be displayed correctly.
