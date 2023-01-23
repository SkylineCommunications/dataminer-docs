---
uid: Cube_Feature_Release_10.3.2
---

# DataMiner Cube Feature Release 10.3.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.2](xref:General_Feature_Release_10.3.2).

## Features

#### Trending - Pattern matching: Colors will now be used to differentiate how matches were detected [ID_34898] [ID_34947]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, matches found for the same element/parameter as the one for which a tag was defined were shown in bright orange, while matches associated with tags created for another element/parameter were shown in lighter orange. From now on, those colors will be used to indicate how the matches were detected:

- Matches detected by means of the so-called *streaming method* will be shown in bright orange.

  These matches are detected while tracking for trend patterns whenever a trended parameter is updated. When such a match is detected, a suggestion event is generated.

- Matches detected by means of the so-called *non-streaming method* will be shown in lighter orange.

  These matches are detected only when trend data is fetched from the database after you opened a trend graph.

> [!NOTE]
> Only matches detected by means of the so-called *streaming method* will be stored in the database.

#### Resources app: 'Resources' tab and 'Occupancy' tab can now be filtered [ID_34973]

<!-- MR 10.3.0 - FR 10.3.2 -->

In the *Resources* app, resource pools will now have a filter box that allow you to filter both the *Resources* tab and the *Occupancy* tab on resource name.

- When you enter text in the filter box, a list with suggestions will appear.
- When you select another resource pool while text is present in the filter box, the *Resources* tab and the *Occupancy* tab of that newly selected resource pool will automatically be filtered.
- When an item in either the *Resources* tab or the *Occupancy* tab gets updated while a filter is applied, that item will only be shown if it matches the filter after the update.
- To clear the filter box, you can either delete the text in the filter box or click the *Clear* button.

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

## Changes

### Enhancements

#### DataMiner Cube - Visual Overview: Enhanced performance when loading sorted tree view controls [ID_34795]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Because of a number of enhancements, overall performance has increased when loading sorted tree view controls.

#### Trending - pattern matching: Enhanced feedback when creating a trend pattern tag failed [ID_34963]

<!-- MR 10.4.0 - FR 10.3.2 -->

Up to now, when the creation of a trend pattern tag failed, the general error message `Consider increasing or decreasing  the tag time range selection and try again.` was displayed. From now, one of the following, more detailed messages will be displayed instead:

```txt
Failed to save your tag. Consider reducing the tag time range selection and try again.

Failed to save your tag. The data covered by the tag time range selection contains too little detail. Consider increasing the tag time range selection and try again.

Failed to save your tag. A tag time range was selected for which not all trend data can be retrieved. Consider adjusting the tag time range selection and try again.

Failed to save your tag. The defined patterns cannot be linked into the multivariate pattern. Consider adjusting its configuration and try again.
```

#### DataMiner Cube - Trending: Trend points with value "0" will now also be exported to CSV [ID_35124]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

Up to now, when you exported real-time trend data to a CSV file, trend points with value "0" would not be included. From now on, those values will be exported as well.

### Fixes

#### Service & Resource Management: Problem when Cube tried to retrieve SRM-related data to which the user did not have access [ID_34397]

<!-- MR 10.3.0 - FR 10.3.2 -->

Up to now, an exception could be thrown when DataMiner Cube tried to retrieve SRM-related data to which the user did not have access.

From now on, when DataMiner Cube tries to retrieve SRM-related data to which the user does not have access, a message box will appear, asking the user to contact the system administrator. Also, each time this type of message box is displayed, an entry of type "warning" will be added to the Cube logging (`User X could not read object Y because the user does not have permission flag Z`).

Overview of the read permissions needed to retrieve SRM-related data:

| SRM-related data | Read permission                    |
|------------------|------------------------------------|
| Bookings         | Bookings > UI available            |
| Functions        | Functions> UI available            |
| Profiles         | Profiles > UI available            |
| Resources        | Resources> UI available            |
| Service profiles | Services > Profiles > UI available |
| Services         | Services > UI available            |

> [!NOTE]
> Often, users will need a combination of the above-mentioned read permission for Cube to be able to retrieve the necessary SRM-related data.

#### Profiles app: A profile instance would incorrectly list parameters that had been removed from the profile definition [ID_34679] [ID_34771]

<!-- MR 10.4.0 - FR 10.3.2 -->

When a parameter had been removed from a profile definition, in the *Profiles* app, the profile instances referring to the profile definition in question would incorrectly still list the parameter that had been removed.

#### DataMiner Cube: Latest script updates would not be shown when opening a script in the Automation app [ID_34738]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened the *Automation* app in DataMiner Cube and selected an unmodified script, the latest updates made to that script by another Cube client or another program (e.g. DataMiner Integration Studio) would not be shown. From now on, when you open a script in the Automation app that has not yet been changed in that same app, the latest version of that script will now automatically be retrieved from the server.

#### DataMiner Cube - Alarm Console: Alarm tab of type 'Active alarms linked to cards' would incorrectly not show any alarms when you opened a function card [ID_34799]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU11] - FR 10.3.2 -->

When the Alarm Console had an alarm tab of type *Active alarms linked to cards*, that tab would incorrectly not show any alarms when you opened a function card, even when that function had active alarms.

Also, when you added a new alarm tab, clicked *Apply filters*, and added an element filter, then you would incorrectly also be able to select virtual functions from the list of elements. From now on, only when you add a function filter will you be able to select virtual functions from the list of functions.

#### Alarm Console: Masking a correlated alarm would incorrectly cause the base alarms to disappear from the 'Active alarms' tab [ID_34815]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

Up to now, when you masked a correlated alarm, the alarm would not only be moved to the *Masked alarms* tab together with all its sources. The base alarms would also disappear from the *Active alarms* tab. From now on, when you mask a correlated alarm, its base alarms will remain visible in the *Active alarms* tab.

#### DataMiner Cube - Protocols & Templates: Function protocols would incorrectly be listed multiple times [ID_34885]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened the *Protocol & Templates* module, in some rare cases, function protocols would incorrectly be listed multiple times in the protocol list.

#### DataMiner Cube: Renaming your local DataMiner user would incorrectly cause that user to disappear [ID_34918]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you renamed your local DataMiner user with administrative access while being logged in as that user, the user would incorrectly get (partially) removed.

#### DataMiner Cube: Problem when opening scheduled tasks, Automation scripts or Correlation rules containing actions that include PDF reports [ID_34997]

<!-- MR 10.1.0 [CU22] / 10.2.0 [CU11] - FR 10.3.2 -->

When, in *Scheduler*, *Automation* or *Correlation*, you opened scheduled tasks, Automation scripts or Correlation rules containing actions that include PDF reports, in some rare cases, the data linked to those reports (i.e. the elements and services in view selection) could not be loaded. This data will now be loaded correctly. Also, a "Loading" indicator will now be displayed and the actions will remain disabled while the data is being loaded. When an error occurs while loading the protocols associated with said data, a clear warning entry will also be added to the Cube logging.

> [!NOTE]
> From now on, in the *Elements and services in view selection* list, it will also be possible to select parameters of enhanced services.

#### DataMiner Cube - Spectrum Analysis: Selected measurement point no longer selected after playing a spectrum recording [ID_35001]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you selected a measurement point of a spectrum trace, and then played a spectrum recording in which other measurement points were used, the measurement point you selected would incorrectly no longer be selected when the spectrum recording stopped playing.

#### DataMiner Cube - Alarm Console: Cube freezes when loading a large sliding window [ID_35032]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened an alarm tab of type "sliding window" with a large number of alarm trees, in some cases, the UI could become unresponsive.

#### DataMiner Cube: Y-axis values could be missing when opening a trend graph [ID_35060]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened the trend graph of a parameter that contained discrete values or exceptions, in some cases, Y-axis values could be missing.

#### DataMiner Cube - Alarm Console: Incorrect error would appear when a DataMiner cluster had an IDP license but no Resource Manager license [ID_35123]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a DataMiner cluster had an IDP license but no Resource Manager license, an error would incorrectly appear in the Alarm Console when the agents were synchronized.

#### Trending: Light bulb icon would incorrectly not re-appear after removing a suggested parameter of type string from a graph [ID_35133]

<!-- MR 10.3.0 - FR 10.3.2 -->
<!-- Not added to 10.3.0 -->

When you removed a suggested parameter of type string from a trend graph, the light bulb icon would incorrectly not re-appear in the top-right corner of the graph.

#### DataMiner Cube - Trending: Trend graph would start to flicker when its data was updated [ID_35181]

<!-- Main Release Version 10.1.0 [CU22]/10.2.0 [CU11] - Feature Release Version 10.3.2 -->

When you opened a trend graph and left it open for a while, it would start to flicker when its data was updated.

#### DataMiner Cube - Data Display: Tables of which the table parameter had its 'Filter' option set to false would incorrectly have a filter box [ID_35196]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you opened an element card, tables of which the table parameter had its `Filter` option set to *false* in the element protocol would incorrectly have a filter box.

From now on, table filter boxes will be shown or hidden depending on the following rules:

| Protocol option    | Filter box |
|--------------------|------------|
| Filter:true        | Shown      |
| Filter:false       | Not shown  |
| Filter             | Shown      |
| *No Filter option* | Not shown  |

#### Surveyor: Problem when upgrading a view of which the name contains invalid characters [ID_35208]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a view of which the name contained one of the below-mentioned characters was upgraded to a service, up to now, the *Upgrade to service* action would fail because those characters are not allowed in service names. The view would disappear, but the service would incorrectly not be created.

```txt
\ / : * ? " < > | ° ;
```

From now on, when you try to upgrade a view of which the name contains one of these characters, a pop-up window will appear, saying that the view name contains invalid characters. When you then click *OK*, the pop-up window will close and the view will switch to edit mode, allowing you to change its name.

#### Visual Overview: Problem with conditional shape manipulation actions [ID_35211]

<!-- MR 10.4.0 - FR 10.3.2 -->

In some rare cases, conditional shape manipulation actions (e.g. Show, Hide, Rotate, Blink, etc.) would not be executed correctly.

#### DataMiner Cube - Visual Overview: Parameter value displayed on a shape in history mode would not be updated when linked to a session variable [ID_35219]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When a shape is linked to a parameter via a session variable, the parameter value shown on the shape will be updated when the session variable is updated, and when the shape goes into history mode, the history value of the linked parameter will be shown. However, up to now, when the session variable was updated while the shape was in history mode, the parameter value would incorrectly not be updated.

#### Element Connections app: Problems when creating or updating connections [ID_35228]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When, in the *Element Connections* app, you created a new connection or updated an existing connection, in some cases, duplicate connections would incorrectly be created or existing data would be modified incorrectly.

Also, the *Element Connections* app has now been made fully compatible with the *Skyline Black* theme.

#### Trending: 'Trending is currently not available ...' error would incorrectly be displayed while viewing the trend graph of an EPM object [ID_35234]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

In some cases, a `Trending is currently not available for this parameter` error would incorrectly be displayed when you were viewing the trend graph of an EPM object.

#### Visual Overview: Dynamically positioned shapes could no longer be re-arranged using drag-and-drop [ID_35241]

<!-- MR 10.4.0 - FR 10.3.2 -->

When, in a Visio drawing, shapes have been positioned dynamically based on properties, you can re-arrange those shapes manually by switching to *Arrange* mode and re-arranging the shapes using drag-and-drop. In some rare cases, it would no longer be possible to drag shapes to another location.

#### DataMiner Cube - Visual Overview: Inline preset of spectrum component would no longer be applied [ID_35244]

<!-- MR 10.2.0 [CU11] - FR 10.3.2 -->

When you had defined an inline preset while configuring an embedded spectrum component, that preset would no longer be applied. Instead, a `Please select at least one of the preset content items before clicking Load.` message would appear.
