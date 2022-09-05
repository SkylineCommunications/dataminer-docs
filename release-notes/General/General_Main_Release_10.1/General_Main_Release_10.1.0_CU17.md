---
uid: General_Main_Release_10.1.0_CU17
---

# General Main Release 10.1.0 CU17

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements \[ID_33684\]

A number of security enhancements have been made.

#### Business Intelligence: Enhancements made to the automatic SLA data clean-up mechanism \[ID_33663\]

A number of enhancements have been made to the automatic SLA data clean-up mechanism.

### Fixes

#### Problem with SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped \[ID_33437\]

In some cases, an error could occur in SLPort when the last serial element using a specific IpAddress:IpPort connection was stopped.

#### Problems when migrating data from SQL to Cassandra \[ID_33524\]

In some cases, the following issues could occur when migrating data from SQL to Cassandra:

- Online migration would be executed, but would not get marked as completed in Cube.

- Offline migration would fail to launch.

Also, Cube will no longer throw “System.InvalidOperationException: Collection was modified” errors.

#### DataMiner Cube: Properties of exported elements would not be added to the CSV file in the correct order \[ID_33528\]

When you had exported elements to a CSV file, the element properties would not be added to the CSV file in the correct order.

#### DataMiner Cube - Data Display: Problems with button and date/time picker sizing \[ID_33601\]

In some cases, the width of a button would not automatically be adapted to the text displayed on the button.

Also, in date/time picker controls, the buttons to pick or clear a date/time would not be displayed correctly.

#### DataMiner Cube - Annotations: Images would get removed when saving an annotation \[ID_33623\]

When you saved an annotation, in some cases, any images added to the annotation would incorrectly get removed.

#### DataMiner Cube - Data Display: Buttons inside a table would incorrectly be grayed out when scrolling \[ID_33641\]

When scrolling through a table of which the rows contained buttons, in some cases, those buttons would incorrectly be grayed out.

#### Serializing/deserializing would not work when dictionary key contained spaces \[ID_33677\]

Up to now, serializing/deserializing would not work when creating a filter that contained spaces inside quotes (see the example below).

Example:

```csharp
AlarmEventMessageExposers.PropertiesDict.DictStringField($"Booking Manager Element ID").Matches(".+")
```

#### Service & Resource Management: Problem when adding, updating or deleting a resource \[ID_33678\]

When you tried to add, update or delete a resource, a NullReferenceException could be thrown when the Resources.xml file was locked by another process.

#### No alarm would be generated when an element that exported data failed to start \[ID_33744\]

When an error occurred during the startup of an element that exported data (e.g. a DVE or function element), in some cases, no alarm would be generated.

#### SLWatchdog: Problem when generating the database report \[ID_33769\]

In some cases, an error could occur in SLWatchdog when generating the database report.

#### SNMP: Former value of updated cell would incorrectly be returned the first time the table was polled after the update \[ID_33855\]

When a cell in a table with “pollingrate” enabled had been updated, the first time the table was polled after the update, the former value of that cell would incorrectly be returned.

#### Protocols: Additional connections with a 'Type' defined would incorrectly be ignored \[ID_33941\]

Additional connections that had a “\<Type>” defined would incorrectly no longer be taken into account.

In the following example, the second connection would incorrectly be ignored.

```xml
<Connections>
  <Connection id="0" name="HTTP Connection">
    <Type>http</Type>
    ...
  </Connection>
  <Connection id="1" name="WebSocket Interface">
    <Type>http</Type>
    ...
```

> [!NOTE]
> Specifying a type with \`\<Type>\` for one connection and specifying a type with e.g. \`\<Http>\` for another connection is not supported.
