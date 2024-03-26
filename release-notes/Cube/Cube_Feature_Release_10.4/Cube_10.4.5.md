---
uid: Cube_Feature_Release_10.4.5
---

# DataMiner Cube Feature Release 10.4.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.5](xref:General_Feature_Release_10.4.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### Visual Overview: Enhanced performance when processing property updates [ID_38458]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when processing property updates.

#### Alarm Console: Newly opened suggestion events tab will now include 'Service impact', 'Services' and 'RCA level' columns by default [ID_38732]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

From now on, a newly opened suggestion events tab will include *Service impact*, *Services* and *RCA level* columns by default.

Also, from now on, when you right-click a column header and select *Add/Remove column > Set default columns* in a suggestion events tab, the default columns will be restored correctly. Up to now, selecting the *Set default columns* menu option would incorrectly restore the default columns of an active alarms tab instead.

#### Alarm Console: Enhanced performance when loading a large number of active alarms [ID_38808]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when loading a large number of active alarms.

#### System Center - Agents: Tooltip of 'Upgrade only' button will now mention the prerequisites will be run [ID_38864]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When, in the *Upgrade* window, you hover over the *Upload only* button, the following tooltip will now appear:

`Uploading a package with prerequisites will run those prerequisites on each Agent of the cluster.`

The same message will also be shown on the confirmation box that will appear after you click the *Upload only* button.

#### Visual Overview: Preventing placeholders from being resolved until the variable is set to a value [ID_38910]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

In Visual Overview, a variable placeholder will resolve to an empty value when the variable in question is not initialized.

From now on, you can add the "WaitForValue" option to a `[var]`, `[cardvar]` or `[pagevar]` placeholder. This will prevent the placeholder (and the shape data field in which it is used) from being resolved until the variable is set to a value.

Example: `[var:testvar,WaitForValue]`

> [!NOTE]
> If the variable name contains commas, by default, the text before the first valid option will be considered the name of the variable. For example, in the placeholder `[var:my,var,WaitForValue,NotValidOption]`, "my,var" will be considered the name of the variable.
> This default behavior can be overruled by using a `[sep]` placeholder. For example, in the placeholder `[cardvar:[sep:,$]test,var$WaitForValue]`, "test,var" will be considered the name of the variable.

#### Enhanced performance when loading properties in a view card [ID_38942]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when loading properties in a view card.

#### Sidebar: Users will now be logged in automatically when opening an app from the Apps pane [ID_39057]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when you opened a web application by clicking an icon in the *Apps* pane of Cube's sidebar, you had to log in to that app when you had not yet logged in to another app that was open in the browser. From now on, you will be logged in automatically.

#### System Center - Agents: Warning when adding or removing agents on systems that have the NATSForceManualConfig option enabled [ID_39070]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When you add or remove an agent on a DataMiner System that has the *NATSForceManualConfig* option enabled, a warning message will now appear, saying that the NATS configuration will have to be updated.

#### Log entries added to SLClient.txt will now include the ConnectionID dimension [ID_39118]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Each time a Cube client adds a log entry to the *SLClient.txt* log file of the DataMiner Agent in question, it will now include the *ConnectionID* dimension, which will allow the corresponding connection to be traced.

#### URL argument 'alarm=' now also supports values in DmaId/ElementId/RootAlarmId format [ID_39126]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When you open DataMiner Cube with the URL argument *alarm=* to immediately display a specific alarm card, it is now possible to specify the alarm in *DmaId/ElementId/RootAlarmId* format.

Example:

```txt
alarm=48/123/6713
```

### Fixes

#### Resources app: Resource would incorrectly be marked as modified when capability values were set to NaN [ID_38699]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

In some cases, resource profiles generated within the Service & Resource Management solution would have their Min and Max capability values set to *NaN*. In the *Resources* app of Cube, a false positive result would then be returned when checking whether the capability of a resource had been changed.

From now on, when the *Resources* app of Cube detects that the Min and Max capability values of a resource profile are set to *NaN*, it will no longer mark the resource in question as modified.

#### Services app: Memory leak when closing the app [ID_38787]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When, in DataMiner Cube, you closed the Services app, in some cases, Cube could leak memory.
