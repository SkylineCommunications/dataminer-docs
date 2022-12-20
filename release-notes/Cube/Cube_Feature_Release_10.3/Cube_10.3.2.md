---
uid: Cube_Feature_Release_10.3.2
---

# DataMiner Cube Feature Release 10.3.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.2](xref:General_Feature_Release_10.3.2).

## Highlights

*No highlights have been selected for this release yet*

## Other features

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
