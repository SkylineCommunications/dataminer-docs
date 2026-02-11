---
uid: Cube_Feature_Release_10.4.5
---

# DataMiner Cube Feature Release 10.4.5

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.5](xref:General_Feature_Release_10.4.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.5](xref:Web_apps_Feature_Release_10.4.5).

## New features

#### Visual Overview: New option to prevent placeholders from being resolved until a variable is set to a value [ID 38910]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

In Visual Overview, a variable placeholder will resolve to an empty value when the variable in question is not initialized.

From now on, you can add the "WaitForValue" option to a `[var]`, `[cardvar]`, or `[pagevar]` placeholder to prevent the placeholder (and the shape data field in which it is used) from being resolved until the variable is set to a value.

Example: `[var:testvar,WaitForValue]`

> [!NOTE]
> If the variable name contains commas, by default, the text before the first valid option will be considered the name of the variable. For example, in the placeholder `[var:my,var,WaitForValue,NotValidOption]`, "my,var" will be considered the name of the variable. This default behavior can be overruled by using a `[sep]` placeholder. For example, in the placeholder `[cardvar:[sep:,$]test,var$WaitForValue]`, "test,var" will be considered the name of the variable.

## Changes

### Enhancements

#### Visual Overview: Enhanced performance when processing property updates [ID 38458]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when processing property updates.

#### Visual Overview: Enhanced performance when loading embedded visual overviews [ID 38541]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when loading embedded visual overviews.

#### Alarm Console: Newly opened suggestion events tab will now include 'Service impact', 'Services' and 'RCA level' columns by default [ID 38732]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

From now on, a newly opened suggestion events tab will include *Service impact*, *Services* and *RCA level* columns by default.

Also, from now on, when you right-click a column header and select *Add/Remove column > Set default columns* in a suggestion events tab, the default columns will be restored correctly. Up to now, selecting the *Set default columns* menu option would incorrectly restore the default columns of an active alarms tab instead.

#### Alarm Console: Enhanced performance when loading a large number of active alarms [ID 38808]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when loading a large number of active alarms.

#### System Center - Agents: Tooltip of 'Upgrade only' button will now mention the prerequisites will be run [ID 38864]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When, in the *Upgrade* window, you hover over the *Upload only* button, the following tooltip will now appear:

`Uploading a package with prerequisites will run those prerequisites on each Agent of the cluster.`

The same message will also be shown on the confirmation box that will appear after you click the *Upload only* button.

#### Enhanced performance when loading properties in a view card [ID 38942]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Because of a number of enhancements, overall performance has increased when loading properties in a view card.

#### Sidebar: Users will now be logged in automatically when opening an app from the Apps pane [ID 39057]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Up to now, when you opened a web application by clicking an icon in the *Apps* pane of Cube's sidebar, you had to log in to that app when you had not yet logged in to another app that was open in the browser. From now on, you will be logged in automatically.

#### System Center - Agents: Warning when adding or removing Agents on systems that have the NATSForceManualConfig option enabled [ID 39070]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When you add or remove an Agent on a DataMiner System that has the *NATSForceManualConfig* option enabled, a warning message will now appear, saying that the NATS configuration will have to be updated.

#### Log entries added to SLClient.txt will now include the ConnectionID dimension [ID 39118]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

Each time a Cube client adds a log entry to the *SLClient.txt* log file of the DataMiner Agent in question, it will now include the *ConnectionID* dimension, which will allow the corresponding connection to be traced.

#### URL argument 'alarm=' now also supports values in DmaId/ElementId/RootAlarmId format [ID 39126]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When you open DataMiner Cube with the URL argument *alarm=* to immediately display a specific alarm card, it is now possible to specify the alarm in *DmaId/ElementId/RootAlarmId* format.

Example:

```txt
alarm=48/123/6713
```

#### Visual Overview: Passing session variables when navigating to elements using an application protocol [ID 39167]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

From now on, in Visual Overview, it will also be possible to pass session variables when navigating to an element using an application protocol (e.g. SRM Booking Manager).

#### Visual Overview - SPI logging: Log entries reporting page load timeouts will now show more accurate load times [ID 39222]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When a visual overview page does not load within two minutes, a log entry of type SPI will report a timeout indicating how long it took to load the page in question. From now on, the page load times indicated in SPI log entries will be more accurate, especially in case of large Visio files.

### Fixes

#### Resources app: Resource would incorrectly be marked as modified when capability values were set to NaN [ID 38699]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

In some cases, resource profiles generated within the Service & Resource Management solution would have their Min and Max capability values set to *NaN*. In the *Resources* app of Cube, a false positive result would then be returned when checking whether the capability of a resource had been changed.

From now on, when the *Resources* app of Cube detects that the Min and Max capability values of a resource profile are set to *NaN*, it will no longer mark the resource in question as modified.

#### Services app: Memory leak when closing the app [ID 38787]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When, in DataMiner Cube, you closed the Services app, in some cases, Cube could leak memory.

#### Memory leak when opening trend graphs [ID 39041]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When you opened a trend graph, in some cases, Cube could leak memory.

#### Visual Overview: Problem when executing automation scripts linked to a CPE card after clicking the 'Back' button [ID 39090]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When, in DataMiner Cube, you navigated to a CPE card by clicking the *Back* button, automation scripts linked to the page would not be executed correctly when they used CPE-specific placeholders like `FieldID` linked to variables. The Automation script popup would open, showing empty variables.

#### Visual Overview: Problem when closing a page [ID 39132]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

In Visual Overview, in some cases, a null reference exception could be thrown when you closed a page.

#### An error could occur while Cube was in alarm storm mode [ID 39252]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

While DataMiner Cube was in alarm storm mode, in some cases, an exception could be thrown.

#### Problem when the statistics of a view were updated while a ticket was updated [ID 39257]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When the statistics of a view were updated while, at the same time, one of the tickets associated with either the view or an element in that view was updated, in some rare cases, an error could occur, causing DataMiner Cube to stop working.

#### Alarm Console - Automatic incident tracking: Problem when double-clicking an alarm group header [ID 39266]

<!-- MR 10.3.0 [CU14]/10.4.0 [CU2] - FR 10.4.5 -->

When, in the Alarm Console, you double-clicked an alarm group header, in some cases, a null reference exception could be thrown.

#### Cube would not be able to connect to a DMA when both had 'Country or region' set to 'Saudi Arabia' [ID 39271]

<!-- MR 10.5.0 - FR 10.4.5 -->

When both the DataMiner Cube client and the DataMiner Agent had *Country or region* set to "Saudi Arabia" and *Regional format* set to "Arabic (Saudi Arabia)", up to now, DataMiner Cube would not be able to connect to the DataMiner Agent.
