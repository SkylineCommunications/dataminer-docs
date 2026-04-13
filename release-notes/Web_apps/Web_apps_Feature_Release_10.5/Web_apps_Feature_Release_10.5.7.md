---
uid: Web_apps_Feature_Release_10.5.7
---

# DataMiner web apps Feature Release 10.5.7

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU16] and 10.5.0 [CU4].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.7](xref:General_Feature_Release_10.5.7).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.7](xref:Cube_Feature_Release_10.5.7).

## Changes

### Enhancements

#### Low-Code Apps - Interactive automation scripts: Enhancements made to redesigned UI component 'StaticText' [ID 42662]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When the text in a redesigned `UIBlockType.StaticText` component does not fit the width of the component, it will automatically be ellipsed, and when you hover over the component, the full text will be displayed in a tooltip.

From now on, the text in a redesigned `UIBlockType.StaticText` will no longer be automatically ellipsed when it contains newline characters. In that case, similar to the legacy `UIBlockType.StaticText` component, the text will be split into multiple lines.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards app & Low-Code Apps - Timeline component: Enhanced updating of timeline items [ID 42670]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

A number of enhancements have been made to the way in which timeline items are updated.

#### Low-Code Apps - Interactive automation scripts: Enhancements made to redesigned UI component 'CheckBoxList' [ID 42826]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

A number of enhancements have been made to the redesigned `UIBlockType.CheckBoxList` component. Its behavior is now more in line with other redesigned components like the `UIBlockType.RadioButtonList` component.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new components, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Dashboards app & Low-Code Apps: Enhancements made to dropdown controls [ID 42840]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

A number of minor enhancements have been made to the dropdown controls.

#### Web Services API: ConvertQueryToProtoJson method now allows the JSON version to be specified [ID 42855]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

If you want the Data Aggregator DxM to be able to use a GQI query, you have to convert that query to a JSON string using the *ConvertQueryToProtoJson* web method.

From now on, the *ConvertQueryToProtoJson* web method will allow you to specify the contract to be used:

| Version | Description |
|---------|-------------|
| contract 0 | The JSON version needed when GQI queries are processed by SLHelper. |
| contract 1 (default version) | The JSON version needed when GQI queries are processed by the GQI DxM. |

Example:

`HTTP POST https://DmaIP/API/v1/Internal.asmx/ConvertQueryToProtoJson`

with payload:

```json
{
   "connection": "...",
   "options": { "Contract": 1 },
   "query": {...}
}
```

### Fixes

#### Dashboards app & Low-Code Apps: No error would be returned when a parameter or an element could not be fetched [ID 42584]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When a component tried to fetch parameters or elements, up to now, null would be returned for every parameter or element that could not be found.

From now on, for every parameter or element than cannot be found, a clear error message will be returned. Each of those error messages will then explain why a particular parameter or element could not be found.

#### Dashboards app & Low-Code Apps - Node edge graph component: Moving a node would incorrectly cause the actions of that node to be executed [ID 42798]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When, in a node edge graph, you dragged a node to another position, up to now, the actions configured in that node would incorrectly be executed.

#### Web Services API: WebSocket connections would incorrectly not get closed when a client disconnected [ID 42848]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

In the Web Services API, in some cases, WebSocket connections would incorrectly not get closed when a client disconnected. As a result, the API would believe it was still connected to the client and would keep a connection to SLNet.

From now on, WebSocket connections will automatically get closed after 5 minutes of inactivity.

Also, a number of enhancements have been made with regard to error handling, especially when a connection gets closed.

#### Web Services API: Problem with GetAlarms method [ID 42902]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When a *GetAlarms* call was sent in a JSON request, in some cases, the following issues could occur when *History* was set to true in the alarm filter.

- When the filter that did not contain a *Columns* or a *SortBy* item, an error would be thrown.

- When the filter contained a *Search* item but no *Columns* item, an error would be thrown (even when *History* as set to false).

- Filters in which *StartTime* and *EndTime* were set to 0 would be cached incorrectly, causing problems when the call was sent multiple times over different days since the 0 values would be replaced with "Now" en "End - 1 hour".

- In the result set, the alarms would not always be sorted by *TimeOfArrival* (i.e., the default setting).

#### Dashboards app: Problem after generating PDF reports [ID 42907]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

Up to now, in some cases, an exception could be thrown after a PDF report had been generated. As a result, channels and sockets would not be cleaned up correctly.

#### Low-Code Apps: Problem with 'Open monitoring card' action after deleting and recreating the referenced object [ID 42926]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

When you had created an "Open monitoring card" action that referenced an object (i.e., an element, service or view) by name, and then deleted and recreated that object, up to now, the action would no longer work because it would still reference the object that was deleted.

#### Dashboards app & Low-Code Apps - Timeline component: Scroll position would incorrectly reset on Mozilla Firefox [ID 42966]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 -->

On Mozilla Firefox, when you scrolled inside a *Timeline* component, in some cases, the scroll position would incorrectly reset.

#### Dashboards app & Low-Code Apps - Table component: Problem when filtering on numeric columns containing discrete values [ID 43061]

<!-- MR 10.4.0 [CU16] / 10.5.0 [CU4] - FR 10.5.7 [CU0] -->

When a *Table* component was filtered on a numeric column that contained discrete values, up to now, an error could occur when you selected one of the discrete values instead of entering a number manually.
