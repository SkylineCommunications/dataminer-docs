---
uid: Cube_Feature_Release_10.2.12
---

# DataMiner Cube Feature Release 10.2.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.2.12](xref:General_Feature_Release_10.2.12).

## Highlights

*No highlights have been selected for this release yet*

## Other features

#### Trending: When trending a parameter, related parameters can now be added through light bulb icon [ID_34432]

<!-- MR 10.3.0 - FR 10.2.12 -->

When trending a parameter, you can now add related parameters by clicking the light bulb icon in the top-right corner of the trend. In doing so, you will get an overview of suggested parameters that are related to the currently displayed parameter trend.

#### Visual Overview - ListView component : 'Reservation.Start' and 'Reservation.End' columns can now be configured to convert date/time values to the current time zone [ID_34512]

<!-- MR 10.3.0 - FR 10.2.12 -->

Up to now, when you added the columns *Reservation.Start* and *Reservation.End* to a ListView component configured to list bookings, the date/time values in those columns would always be interpreted as UTC values. From now on, if you set the type of those columns to "Date InvariantCulture", the date/time values in those columns will be converted to the time zone specified in the Cube settings.

#### Server-side search: New option 'includeAllCustomProperties' [ID_34541]

<!-- MR 10.3.0 - FR 10.2.12 -->

In the *MaintenanceSettings.xml* file, you can configure the DataMiner Cube server-side search engine by specifying one or more search options in the *SLNet.SearchOptions* element.

If you specify the new *includeAllCustomProperties* option, the server-side search engine will now search the values of all custom properties. Up to now, the search engine would by default only search the values of the custom properties that were displayed in the Surveyor.

For more information on the available search options, see [Setting the indexing options for the server-side search](xref:Setting_the_indexing_options_for_the_server-side_search).

Also, from now on, DataMiner Cube will call the server-side search engine when you enter a numeric search string like "1234". Up to now, when you entered a numeric search string, DataMiner Cube would perform a client-side search that would only return views of which the ID matched the search string.

## Changes

### Enhancements

#### Visual Overview: New toggle buttons added to Buttons stencil [ID_34426]

<!-- MR 10.2.0 [CU9] - FR 10.2.12 [CU0] -->

The Buttons stencil now contains the following additional buttons:

- *tb-var-l* (button on left side, text on right side, logic based on session variable, configurable session variable scope)
- *tb-var-r* (button on right side, text on left side, logic based on session variable, configurable session variable scope)

Other changes made to the Buttons stencil:

- Buttons *abtn-automation* and *lbtn-automation* have been combined into one button *btn-automation*.
- Button *btn-popup* now has configurable window settings.

#### Trending - Behavioral anomaly detection: Enhanced detection of flatline changes [ID_34487]

<!-- MR 10.3.0 - FR 10.2.12 -->
<!-- Not added to 10.3.0 -->

Because of a number of enhancements, overall accuracy when detecting flatline changes has increased, especially in the following cases:

- When an element becomes inactive or is paused.
- When an element is deleted.
- When a table parameter is no longer active.

Any alarm or suggestion events created for flatline changes will now close sooner when one of the above-mentioned situations occurs.

#### Trending - Behavioral anomaly detection: Enhanced updating of anomaly alarms after alarm template changes [ID_34543]

<!-- MR 10.3.0 - FR 10.2.12 -->

Because of a number of enhancements, anomaly alarms will now be updated even more quickly after an alarm template change.

For example, if the monitoring of a certain type of anomaly (flatline, level shift, variance, trend) stops because of an alarm template change, every open alarm for that type of anomaly will now be cleared.

Changes that might result in anomaly alarms of a certain type being cleared:

- Assigning a new alarm template that does not monitor this type of anomaly.

- Removing an alarm template, causing this type of anomaly to no longer be monitored.

- Editing an alarm template in such a way that this type of anomaly is no longer monitored.

- Changing the template filter so that it is no longer applicable to the parameter in question.

> [!NOTE]
> When an alarm template that had already been assigned to an element earlier is changed in such a way that monitoring of a certain type of anomaly is started, or when it is replaced by another alarm template that causes the monitoring of a certain type of anomaly to start, then every open suggestion event for that type of anomaly associated with the element in question will be promoted to an alarm event.

#### System Center: Link to online help now points to 'Connecting your DataMiner System to the cloud' on <https://docs.dataminer.services/> [ID_34683]

<!-- MR 10.3.0 - FR 10.2.12 -->

On the *Cloud* page of *System Center*, the *online help* hyperlink now points to the [Connecting your DataMiner System to the cloud](xref:Connecting_your_DataMiner_System_to_the_cloud) page on <https://docs.dataminer.services/>.

#### Alarm Console: When grouped, incident alarms will now appear in the group of the highest severity found among the base alarms [ID_34754]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you open an alarm tab that contains incident alarms, the icons in front of those incident alarms show the highest severity found among the base alarms and the severity column shows "suggestion".

Up to now, when you grouped/sorted the alarms in the alarm tab by severity, the incident alarms would all appear in the "suggestion" group. From now on, they will instead appear in the group of the highest severity found among the base alarms.

Also, in case of incident alarms, the alarm duration indicator will now show the highest severity found among the base alarms.

### Fixes

#### DataMiner Cube - Trending: Y axis of trend graph would incorrectly show duplicate values [ID_34492]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a trend graph showed a constant value, due to a rounding issue, the Y axis would incorrectly show duplicate values.

#### DataMiner Cube - Spectrum Analysis: Problem with measurement point option 'Invert spectrum' [ID_34552]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When you had selected the *Invert spectrum* option while configuring a measurement point, in some cases, that option would incorrectly not be applied.

#### DataMiner Cube - Data Display: Parameter controls displaying a write parameter of type DateTime would incorrectly not take into account the format of the current culture as defined in the regional settings of DataMiner Cube [ID_34575]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

A parameter control displaying a write parameter of type DateTime would incorrectly not take into account the format of the current culture as defined in the regional settings of DataMiner Cube. As a result, the read and write parameters would be formatted differently.

#### Trending: Problem when duplicating table parameters with different values [ID_34591]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When duplicating a table parameter in the legend of a trend graph, the graph would not be displayed if the duplicate parameter did not have the same index value as the original parameter.

#### Trending: Table would be cleared of all data after refreshing [ID_34592]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When triggering a refresh of a trend chart, the data and axes on the line chart would disappear for a short period of time without first verifying whether there was any new incoming data. If the incoming data equals null, the graph should not be redrawn and should remain visible.

#### Visual Overview: Dynamically generated shapes sorted by custom property value would not be displayed in the correct order [ID_34617]

<!-- MR 10.1.0 [CU21] / 10.2.0 [CU9] - FR 10.2.12 -->

When a large number of shapes generated based on child items in a view were sorted by a custom property value, in some rare cases, those shapes would not be displayed in the correct order.

#### Visual Overview: Problem when loading a DCF signal path [ID_34630]

<!-- MR 10.3.0 - FR 10.2.12 -->

When a visual overview was configured to display a DCF signal path, in some cases, that signal path would not load.

Also, in some cases, elements with an index in a service would incorrectly not show connection lines.

#### Trending - Pattern matching: Not all detected pattern occurrences would be indicated when you opened a trend graph [ID_34671]

<!-- MR 10.3.0 - FR 10.2.12 -->

When you opened a trend graph that contained patterns matching existing tags, in some cases, not all detected occurrences of those patterns would initially be indicated. Only after zooming out would all detected patterns be properly indicated.

#### Alarm Console - Incident tracking: Alarms without focus data would not be disposed of when their parent group was cleared [ID_34713]

<!-- MR 10.3.0 - FR 10.2.12 -->
<!-- Not added to 10.3.0 -->

Alarms without focus data would incorrectly not be disposed of when their parent group was cleared.
