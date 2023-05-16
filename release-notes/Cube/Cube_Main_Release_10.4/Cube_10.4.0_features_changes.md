---
uid: Cube_Main_Release_10.4.0_other_features_changes
---

# DataMiner Cube Main Release 10.4.0 – Other new features & changes - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Other new features

#### System Center - Analytics config: New Pattern Matching setting 'Maximum memory usage' [ID_34803]

<!-- MR 10.4.0 - FR 10.3.1 -->

In the *System settings > Analytics config* section of *System Center*, you can now find a new setting under *Pattern Matching*: *Maximum memory usage*.

This setting allows you to specify the maximum amount of memory that SLAnalytics will use to cache recurring patterns in trend data (in GB).

Default value: 2.00 GB

#### Visual Overview: Session variable YAxisResources now supports filters [ID_34857]

<!-- MR 10.4.0 - FR 10.3.1 -->

From now on, you can pass resource exposers as a filter to the *YAxisResources* session variable in order to show the corresponding resource bands.

Using a filter that results in less than 100 resources is recommended to avoid delay while loading the bands.

A converter has also been created in the client that will convert a profile parameter name to the ID of the found object. For this, the format [ProfileParameter:xxx,ID] should be used, replacing "xxx" with the name of the capacity/capability profile parameter.

> [!NOTE]
> For examples, refer to [YAxisResource session variable examples](xref:YAxisResource_Shape_Data_Examples) in the user guide.

> [!TIP]
> See also: [Service & Resource Management: Exposers for resource capacities and capabilities](xref:General_Main_Release_10.4.0_new_features#service--resource-management-exposers-for-resource-capacities-and-capabilities-id_34841)

#### Trending - Pattern matching: Colors will now be used to differentiate how matches were detected [ID_34898] [ID_34947]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, matches found for the same element/parameter as the one for which a tag was defined were shown in bright orange, while matches associated with tags created for another element/parameter were shown in lighter orange. From now on, those colors will be used to indicate how the matches were detected:

- Matches detected by means of the so-called *streaming method* will be shown in bright orange.

  These matches are detected while tracking for trend patterns whenever a trended parameter is updated. When such a match is detected, a suggestion event is generated.

- Matches detected by means of the so-called *non-streaming method* will be shown in lighter orange.

  These matches are detected only when trend data is fetched from the database after you opened a trend graph.

> [!NOTE]
> Only matches detected by means of the so-called *streaming method* will be stored in the database.

#### Visual Overview: New placeholders can now be added to a 'ShapeGrouping' shape [ID_34974]

<!-- MR 10.4.0 - FR 10.3.1 -->

Up to now, when you enabled grouping of dynamically positioned shapes, you were able to display the number of shapes that were grouped into a single group shape by adding an asterisk ("\*") in the *ShapeGrouping* shape.

From now on, you can also add the following placeholders in the *ShapeGrouping* shape:

- Add `[GroupValue]` to make the shape display the value that is specified in the *GroupBy* shape data field of the first child shape in the group.

  If this *GroupBy* value contains multiple column parameters and/or properties, they will be separated by commas.

- Add `[Count]` to make the shape display the number of child shapes in the group (similar to adding an asterisk).

The placeholders `[GroupValue]` and `[Count]` can be added simultaneously as well.

#### Visual Overview - ListView: Highlighting rows based on booking color [ID_35157]

<!-- MR 10.4.0 - FR 10.3.2 -->

If you add "ColorRows=True" to the *ComponentOptions* shape data field of a ListView component, the highlight color of the list view rows will be set to the booking color.

The booking color is a summary of the following reserved booking properties: *VisualForeground*, *VisualBackground*, *VisualSelectedForeground* and *VisualSelectedBackground*. Each of those properties can be set to a string value representing a hexadecimal value, an (A)RGB value or a predefined Windows color (the latter is not recommended).

Configuring gray-tinted foreground colors is not recommended as a ListView component uses a gray layer when you hover over its items. In the Skyline themes, that gray layer has the following color:

| Theme | Color of gray layer        |
|-------|----------------------------|
| Mixed | #E5E5E5 (RGB: 229,229,229) |
| Light | #E5E5E5 (RGB: 229,229,229) |
| Black | #333333 (RGB: 51,51,51)    |

> [!NOTE]
>
> - The *ColorRows* feature is disabled by default ("ColorRows=False").
> - At present, the *ColorRows* feature is only available on ListView components that have bookings as a source.

#### Visual Overview - ListView: Copying list data to the Windows clipboard [ID_35170]

<!-- MR 10.4.0 - FR 10.3.3 -->

The ListView component now allows you to copy data from the list to the Windows clipboard.

To copy the contents of one or more rows:

1. Select the row(s).
1. Choose *Copy selected row(s)*.

To copy the contents of a single cell:

1. Right-click in the cell.
1. Choose *Copy \<cell contents\>*.

The data copied to the Windows clipboard is split into a header section and a data section, separated by an empty line. The header section contains the column names, while the data section contains the actual row data.

> [!NOTE]
>
> - Only the columns that are visible to the user will be copied to the Windows clipboard. Also, the order of the columns will be identical to the order of the columns in the ListView component. Note that column visibility and column order can be configured using the component's column manager.
> - When you copy one or more rows, only cells that contain text will be included. For example, cells that only contain a colored rectangle will not be included. Also, when you try to copy the contents of a single cell, the *Copy \<cell contents\>* command will only be available if that cell contains text.

#### Visual Overview: Visualizing EPM object statistics in a shape [ID_35222]

<!-- MR 10.4.0 - FR 10.3.2 -->

It is now possible to display the statistics of an EPM object in a shape linked to that EPM object.

1. Link the shape to the EPM object via the *SystemName* and *SystemType* shape data fields.

1. Add an asterisk character ("\*") in the shape text.

1. Add a shape data field of type *Info* to the shape, and set its value to e.g. `EPM STATISTICS:###[#TotalAlarms]`.

The following information can be displayed:

```txt
#TotalAlarms
#CriticalAlarms
#MajorAlarms
#MinorAlarms
#WarningAlarms
#NormalAlarms
#TimeoutAlarms
#NoticeAlarms
#ErrorAlarms
```

#### Visual Overview - ListView component: New component option 'SingleSelectionMode' [ID_35320]

<!-- MR 10.4.0 - FR 10.3.4 -->

By default, you can select multiple rows in a list view (e.g. using the CTRL or SHIFT key). With the new component option *SingleSelectionMode*, you can now set the selection mode of a list view to single instead, so that only one row can be selected at a time.

#### Visual Overview: Re-arranging grouped shapes [ID_35323]

<!-- MR 10.4.0 - FR 10.3.4 -->

When, in a Visio drawing, shapes had been positioned dynamically based on properties, up to now, it was possible to re-arrange individual shapes manually. From now on, it will also be possible to re-arrange grouped shapes.

#### System Center: New DataMiner log file 'SLSmartBaselineManager.txt' [ID_35352]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the *Logging* section of *System Center*, you can now also consult the *SLSmartBaselineManager.txt* log file.

#### Embedded web apps can now interact with Cube when using the Microsoft Edge (WebView2) browser plugin [ID_35655]

<!-- MR 10.4.0 - FR 10.3.4 -->

From now on, when using the Microsoft Edge (WebView2) web browser plugin, embedded web apps can interact with Cube (e.g. open an element card).

#### Users no longer have to log in to embedded low-code apps [ID_35657]

<!-- MR 10.4.0 - FR 10.3.4 -->

When a low-code app was embedded in Cube (e.g. in a visual overview), up to now, users had to explicitly log in to that app. From now on, Cube will automatically pass the authentication ticket to the low-code app, allowing users to access the app without having to log in again.

#### Trending: Managing trend patterns in the 'Pattern Overview' window [ID_35694] [ID_36114]

<!-- 35694: MR 10.4.0 - FR 10.3.5 -->
<!-- 36114: MR 10.4.0 - FR 10.3.6 -->
<!-- Both released in MR 10.4.0 - FR 10.3.6 -->

When you right-click a trend graph and select *Trend patterns...*, the *Pattern Overview* window will now appear.

By default, this window will only list the existing patterns that apply to the trend graph you have opened. If you select the *Show all patterns* option, it will list all patterns found in the DataMiner System.

- To update the properties of an existing pattern, select it in the list on the left, update its properties, and click *OK* or *Apply*.

  Apart from changing its name and description, you can also indicate whether you want the pattern to be detected continuously in the background.

- To delete a pattern, click the recycle bin icon next to its name in the list on the left.

When you select a trend pattern from the list on the left, a thumbnail preview of the pattern will be displayed, together with the name of the element and parameter associated with the pattern.

> [!NOTE]
> Currently, this *Pattern Overview* window only supports single-variate patterns. Support for multi-variate patterns will be added in a later release.

#### Search box in Cube header can now be hidden [ID_35826]

<!-- MR 10.4.0 - FR 10.3.5 -->

It is now possible to either show or hide the search box in the middle of the Cube header bar.

1. Open the *Settings* app.
1. Go to *Cube* > *Cube header*.
1. Select or clear the *Display search box in header* option, and click *Apply*.

Alternatively, you can also open the quick menu in the Cube header, and toggle the *Show search box* option.

## Changes

### Enhancements

#### Alarm Console: Automatic incident tracking will now make use of the parameter relationship data that is stored in a model managed by the ModelHost DxM [ID_34684]

<!-- MR 10.4.0 - FR 10.3.1 -->

The *automatic incident tracking* feature groups active alarms that are related to the same incident, so that the Alarm Console provides a better overview of the current issues in the system. From now on, on cloud-connected DataMiner Agents that have the DataMiner Extension Module *ModelHost* installed and that have been configured to [offload alarm and change point events to the cloud](xref:Controlling_cloudfeed_data_offloads), this feature will also make use of the parameter relationship data that is stored in a model managed by the *ModelHost* DxM.

#### Trending - Parameter relationships: Enhancements [ID_34832] [ID_34846] [ID_34863] [ID_34938]

<!-- MR 10.4.0 - FR 10.3.1 -->

A number of enhancements have been made to the parameter relationship feature. When you hover over a light bulb icon in the top-right corner of a trend graph, a tooltip will now appear. This tooltip will suggest you add a number of related parameters. Also, when you open a histogram, no light bulb icon will be displayed anymore as parameter relationships are not really relevant when viewing histograms.

#### Trending - pattern matching: Enhanced feedback when creating a trend pattern tag failed [ID_34963]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, when the creation of a trend pattern tag failed, the general error message `Consider increasing or decreasing the tag time range selection and try again.` was displayed. From now, one of the following, more detailed messages will be displayed instead:

```txt
Failed to save your tag. Consider reducing the tag time range selection and try again.

Failed to save your tag. The data covered by the tag time range selection contains too little detail. Consider increasing the tag time range selection and try again.

Failed to save your tag. A tag time range was selected for which not all trend data can be retrieved. Consider adjusting the tag time range selection and try again.

Failed to save your tag. The defined patterns cannot be linked into the multivariate pattern. Consider adjusting its configuration and try again.
```

#### Trending - Pattern matching: A slightly larger number of missing values will now be allowed when you create a trend pattern tag [ID_35376]

<!-- MR 10.4.0 - FR 10.3.3 -->

When you try to create a trend pattern tag, an error message will appear when there are too many missing values in the selected pattern.

From now on, a slightly larger number of missing values will be allowed will you create a trend pattern tag.

#### Trending: Check marks will no longer appear in front of related parameters after adding them to the trend graph [ID_35518]

<!-- MR 10.4.0 - FR 10.3.3 -->

In the top-right corner of a trend graph, a light bulb icon appears when DataMiner finds parameters that are related to the parameters shown in the trend graph. Clicking this light bulb icon allows you to add one or more of those related parameters to the trend graph you are viewing.

Up to now, when you clicked one of those related parameters in order to add it to the trend graph, a check mark would appear in front of it. From now on, check marks will no longer appear in front of related parameters after selecting them.

#### Automation script editor: Intellisense added for timeUpDownConfig.ShowTimeUnits [ID_35672]

<!-- MR 10.4.0 - FR 10.3.4 -->

In the Automation script editor, Intellisense has been added for the new `timeUpDownConfig.ShowTimeUnits` property.

This property is only applied in interactive Automation scripts that are launched from a web app.

#### DataMiner Cube desktop app: Unused Cube versions will now automatically be removed [ID_35795]

<!-- MR 10.4.0 - FR 10.3.6 -->

From now on, Cube versions that meet the following conditions will be removed automatically:

- Not marked as the active version for a certain DataMiner Agent.
- Not downloaded recently.
- Not used recently.

#### Trending - Parameter relationships: Light bulb icon is now always displayed in top-right corner of trend graph and has one of three states [ID_35868] [ID_36157] [ID_36199]

<!-- MR 10.4.0 - FR 10.3.6 Also see Fixes-->

In the top-right corner of a trend graph, a light bulb icon was previously only displayed if DataMiner found relations for the parameters shown in the trend graph. From now on, this icon will always be visible, regardless of whether related parameters have been found and whether all necessary requirements for the parameter relationship feature are met. The light bulb icon can now have one of three states:

- Related parameters have been found.
- No related parameters have been found.
- The requirements have not been met.

When related parameters have been found, the light bulb icon will "light up" in an accent color to provide a visual indication of its state.

If any of the mandatory requirements for the parameter relationship feature have not been met, clicking the light bulb icon in the top-right corner of the trend graph will show a message that indicates the requirements are not met.

If any of the optional requirements for the parameter relationship feature have not been met, clicking the light bulb icon in the top-right corner of the trend graph will show a message that advises to unlock all capabilities of this feature.

Both messages are clickable and link to the relevant section of the DataMiner Documentation.

#### Visual Overview: Browser shapes will no longer be reloaded when their URL only had a fragment change [ID_36044] [ID_36104]

<!-- MR 10.4.0 - FR 10.3.6 -->

Up to now, a browser shape would always be reloaded whenever its URL was changed. From now on, this will no longer be the case when the URL only had a fragment change.

Examples:

- When `#https://company.be/#/app/Map` changes to `#https://company.be/#/app/Map#urlfragment`, the browser shape will not be reloaded because the URL only had its fragment changed.

- When `#https://company.be/#/app/Map` changes to `#https://company.be/#/app/Map?embed=true#urlfragment`, the browser shape will be reloaded because the URL not only had its fragment changed but also its query parameter.

#### System Center - Database: Warning when a DataMiner Agent in the cluster is offline [ID_36184]

<!-- MR 10.4.0 - FR 10.3.6 -->

In the *Database* section of *System Center*, a warning will now appear whenever a DataMiner Agent in the cluster is offline.

Also, when you click *Save* after changing any of the settings in this *Database* section, a popup message will now appear, saying that the Agents need to be restarted for the changes to take effect.

> [!IMPORTANT]
> No warning will appear to point out that the backup Agent in a Failover setup is offline.

### Fixes

#### Profiles app: A profile instance would incorrectly list parameters that had been removed from the profile definition [ID_34679] [ID_34771]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a parameter had been removed from a profile definition, in the *Profiles* app, the profile instances referring to the profile definition in question would incorrectly still list the parameter that had been removed.

#### Visual Overview: Problem with conditional shape manipulation actions [ID_35211]

<!-- MR 10.4.0 - FR 10.3.2 -->

In some rare cases, conditional shape manipulation actions (e.g. Show, Hide, Rotate, Blink, etc.) would not be executed correctly.

#### Visual Overview: Dynamically positioned shapes could no longer be re-arranged using drag-and-drop [ID_35241]

<!-- MR 10.4.0 - FR 10.3.2 -->

When, in a Visio drawing, shapes have been positioned dynamically based on properties, you can re-arrange those shapes manually by switching to *Arrange* mode and re-arranging the shapes using drag-and-drop. In some rare cases, it would no longer be possible to drag shapes to another location.

#### Alarm Console: When you clicked a suggestion alarm, the change points and patterns would incorrectly not be loaded [ID_35497]

<!-- MR 10.4.0 - FR 10.3.3 -->

When you clicked a suggestion alarm, in some cases, the trend graph would be loaded but the change points and the patterns incorrectly would not.

#### Trending - Parameter relationships: Light bulb icon would not appear if ModelHost DxM stopped working [ID_35868]

<!-- MR 10.4.0 - FR 10.3.6 Also see enhancements -->

The light bulb icon would not be displayed in the top-right corner of a trend graph if the ModelHost DxM stopped working after Cube had already been started.

#### No longer possible to configure a PDF report generated based on a dashboard [ID_35874]

<!-- MR 10.4.0 - FR 10.3.4 [CU0] -->

When, in the *Automation*, *Correlation* and *Scheduler* modules, you generated a PDF report based on a dashboard, it would incorrectly no longer be possible to click the *Configure* button to configure that report.

#### Alarm Console: Suggestion event would not be removed from the suggestion events tab after being promoted to alarm event [ID_35949]

<!-- MR 10.4.0 - FR 10.3.5 -->

When, in an alarm template, a suggestion event was promoted to an alarm event, it would correctly appear in the active alarms tab but it would incorrectly not be removed from the suggestion events tab.

#### Problem when connecting to a DataMiner Agent using gRPC [ID_35950]

<!-- MR 10.4.0 - FR 10.3.6 -->

In some cases, DataMiner Cube would fail to connect to a DataMiner Agent using gRPC, especially when a large number of clients were connecting to that same agent.
