---
uid: General_Main_Release_10.2.0_CU17
---

# General Main Release 10.2.0 CU17

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Cassandra: gc_grace_seconds will now be set to 1 day by default and to 4 hours for records with TTL set [ID_34763]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

In Cassandra databases, the table property `gc_grace_seconds` will now be set to 1 day by default.

For tables containing data with TTL set, this property will be set to 4 hours.

#### Dashboards app & Low-Code Apps: No visual replacement will be displayed anymore when a State component feeds empty query rows [ID_36460]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU4] - FR 10.3.7 -->

Up to now, when a *State* component fed empty query rows, a visual replacement would be displayed. From now on, this will no longer be the case.

#### DataMiner Agents joining a cluster will now synchronize their ProtocolScripts\DllImport folder [ID_36494]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When a DataMiner Agent joins a cluster, it will now synchronize its `ProtocolScripts\DllImport` folder.

Also, when processing a protocol, a DataMiner Agent will now synchronize

- the files in the `ProtocolScripts/DllImport` folder, and
- the files in the folders mentioned in the *QAction@dllImport* attribute.

#### Stream Viewer will now display parameter IDs in decimal format instead of octal format [ID_36525]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Stream Viewer will display an error message when an SNMP poll group contained either an invalid parameter or a parameter that did not have its SNMP setting enabled.

Up to now, that error message would contain the ID of the parameter in octal format. From now on, it will contain the ID of the parameter in decimal format instead.

#### Factory reset tool will no longer try to delete non-existing folders [ID_36550]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, the factory reset tool *SLReset.exe* would log an exception each time it had tried to delete a non-existing folder. From now on, when it has to delete a folder, it will first check whether that folder exists. If not, it will not try to delete it.

#### SNMP tables: Columns of type 'retrieved' can now be placed in between columns of type 'snmp' [ID_36559]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when an SNMP table had columns of type "retrieved" in between columns of type "snmp", problems could occur. All columns of type "retrieved" had to be grouped and placed at the right of the columns of type "snmp".

From now on, in an SNMP table, columns of type "retrieved" can be placed in between columns of type "snmp", providing the primary key column is a column of type "snmp" and not a column of type "retrieved".

#### Dashboards app & Low-Code Apps: Enhanced error handling while exporting trend data to a CSV file [ID_36627]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

A number of enhancements have been made with regard to error handling while exporting trend data to a CSV file.

#### DataMiner Cube - Alarm Console: Enhanced retrieval of history alarms [ID_36653]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when you requested the alarms of a certain time span, Cube would always send two requests to the server: one for the alarms and one for the information/suggestion events. However, in many cases, this was not necessary. From now on, Cube will only send the requests that are necessary.

### Fixes

#### NATS-related error: 'Failed to copy credentials from [IP address] - corrupt zip file' [ID_35935]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.6 -->

In some rare cases, the following NATS-related error would be thrown:

```txt
Failed to copy credentials from [IP address] - corrupt zip file
```

#### DataMiner Cube - Visual Overview: Problem with element or view scope of Children shapes [ID_36354]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

In some cases, when a placeholder was used in the *Element* or *View* shape data field of a *Children* shape, the scope would not be updated when changes were made to the placeholder.

From now on, the scope will be updated correctly whenever changes are made to the placeholder in the *Element* or *View* shape data field.

#### DataMiner Cube - Workspaces: Problem opening cards that showed a visual overview [ID_36438]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you opened a workspace in which one or more cards showed a page with a visual overview, in some cases, the visual overview would be empty.

#### DataMiner Cube - System Center: Problem with 'Show agent alarms' link [ID_36463]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you selected an agent in the *Agents* section of *System Center*, in some cases, the alarm numbers shown in the *Show agent alarms* link would not be correct.

Also, when you clicked that *Show agent alarms* link, the alarm tab listing the alarms of the selected agent would incorrectly be empty.

#### Low-Code Apps: Application would be updated each time you hit a key after changing a page name [ID_36479]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you changed the name of a low-code app page, the application would incorrectly be updated each time you hit a key. From now on, the application will be updated 250 ms after the last keystroke.

#### SLAnalytics: Incorrect trend predictions in case of incorrect data ranges set in the protocol [ID_36521]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

If, in the protocol, a data range is specified for a parameters for which trend data prediction is required, the trend prediction algorithm will cap the prediction values to the data range. For example, if a parameter has a rangeLow value equal to 0 and a rangeHigh value equal to 100, the prediction will not contain values lower than 0 or higher than 100.

From now on, if the trend data contains values outside of the specified data range, the trend prediction algorithm will no longer consider the data range values to be valid or reliable, and will not limit the prediction to this range.

#### Problem with protocol.SendToDisplay API call [ID_36528]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When the following protocol API call was used to update specific matrix crosspoints, in some cases, the API call could ignore the physical size of the matrix. Also, the API call could change the dimensions of future `ParameterChangeEventMessages`.

```csharp
protocol.SendToDisplay(matrixReadParameterId, changedInputs, changedOutputs);
```

#### Problem when requesting alarms on a system with Cassandra Cluster and Elasticsearch [ID_36549]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

On systems with a Cassandra Cluster and an Elasticsearch database, the following issues could occur:

- When alarms were requested via a query with a service filter, no alarms would be returned.

- When alarms were requested via a query with a view filter, no alarms would be returned when that view or any of its subviews contained services. Also, when a view was enhanced with an element, that element would not be queried.

#### SLAnalytics - Behavioral anomaly detection: False change point could be generated before a gap in a trend graph [ID_36605]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When there was a gap in a trend graph that showed a perfectly increasing line, in some cases, a false change point could be generated right before that gap.

#### Dashboards app & Low-Code Apps: Pie chart components would not update properly [ID_36612]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Pie chart components would not update properly while visualizing data from a query with variable input, especially when the number of rows returned by the query changed.

#### SLAnalytics - Automatic incident tracking: Attempt to clear an alarm group that had already been cleared [ID_36654]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

In some rare cases, the system would incorrectly try to clear an alarm group that had already been cleared.

#### DataMiner Cube - Settings: Suggestion tab added to a group setting would not show any suggestion alarms [ID_36666]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When, in the *Settings* window, you added a suggestion tab to a group setting for the Alarm Console, users who were a member of that group would see the suggestion tab, but it would not show any suggestion alarms.

#### DataMiner Cube: Problem when removing DCF connections [ID_36676]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you removed a connection between an active element and an element that was stopped/paused, the connection would be removed from the active element but not from the stopped/paused element. When you started that element again and tried to remove the connection, the action would fail.

#### Dashboards app & Low-Code Apps - Numeric input component: Input field would incorrectly be set to the minimum value after a refresh [ID_36677]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

Up to now, when a numeric input component had a non-zero minimum value set, the input field would automatically be set to that minimum value after a refresh. From now on, the input field will remain empty after a refresh, even when a minimum value is configured.

#### DataMiner Cube - Alarm Console: Problem with alarm tabs of type 'sliding window' [ID_36687]

<!-- MR 10.2.0 [CU17]/10.3.0 [CU5] - FR 10.3.8 -->

When you opened an alarm tab of type "sliding window", the history alarms matching the sliding window would be retrieved from the server but DataMiner Cube would incorrectly not show them.
