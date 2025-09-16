---
uid: Cube_Feature_Release_10.5.11
---

# DataMiner Cube Feature Release 10.5.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.4.0 [CU20] and 10.5.0 [CU8].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.11](xref:General_Feature_Release_10.5.11).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.5.11](xref:Web_apps_Feature_Release_10.5.11).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Visual Overview: Load time metric will now include the time it took to load embedded visual overviews [ID 43467]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

From now on, the load time metric of a visual overview will include the time it took to load any embedded visual overviews.

#### Visual Overview: Load time metric will now include the time shapes with data fields of type 'Property' wait for data [ID 43469]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

From now on, the load time metric of a visual overview will include the time shapes with data fields of type 'Property' wait for data.

#### Clearer message will now appear when Cube experiences a CRL freeze [ID 43663]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When an internet connection is not available on the client machine, the DataMiner Cube application freezes for about 20 seconds during the session. From now on, when this happens, a more detailed message will appear, explaining what can be done to prevent this in the future.

This type of freezes happen because Windows and .NET try to verify the application's digital signatures by checking an online Certificate Revocation List (CRL). The system times out during this process, causing the delay and impacting user productivity.

#### Spectrum analysis: Trace color can now be modified when a measurement point is selected [ID 43669]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, it would not be possible to modify the trace color when a measurement point was selected. From now on, it will be possible to modify the trace color when either no measurement point or one single measurement point is selected.

Also, an issue has been fixed that caused the trace color to be incorrect in *View Buffer mode*, *View script mode*, or *Watch mode* when you had changed the color without closing the card.

### Fixes

#### Trending: Problems when opening a trend graph containing trending of string values combined with exception values [ID 43532]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you opened a trend graph containing trending of string values combined with exception values, up to now, the following issues could occur:

- Only the label of the exception value was displayed. None of the other values would have their label displayed.
- In some cases, the average value that was displayed would incorrectly be a value that had only occurred for a short period of time.
- The histogram would incorrectly not include any exceptions.

#### Problem when updating the log levels of an element that had been migrated or swarmed to another DMA [ID 43581]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

In some cases, DataMiner Cube would fail to update the log levels of an element log file, especially when the element in question had been migrated or swarmed from the DMA to which you were connected to another DMA in the DataMiner System.

Also, in some cases, it would incorrectly not be possible to clear multiple element log files in one go.

#### Trending: Alarm timeline would incorrectly be displayed on top of or beyond the Y axis when zooming in [ID 43593]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you zoomed in on a trend graph, the alarm timeline on the X axis would incorrectly be displayed either on top of or beyond the Y axis.

#### Trending: Percentage in legend of trend graph showing discreet values would be incorrect [ID 43614]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When, in a trend graph showing discreet values, you hover over the graph, the legend will show a percentage indicating how much of the time a value has occurred in the graph. However, since a server-side change in DataMiner version 10.1.10, this percentage has been incorrect.

#### Problem when a broadcast message expired [ID 43634]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When a broadcast message expired, up to now, an exception could be thrown.

#### Trending: Trend graphs containing trending of string values could incorrectly show gaps after new data had been received [ID 43636]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When an open trend graph containing trending of string values had received new data, up to now, the graph could incorrectly show gaps.

#### Trending: Changes made to the 'Display the alarm template in the trend graph' option would incorrectly not be applied when the bottom navigator chart was not enabled [ID 43638]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When, in a visual overview, a shape showing a trend component was configured to not show the bottom navigator chart (i.e. by means of the "NavigatorChart:false" option set in the *ParametersOptions* shape data field), up to now, changes made to the *Display the alarm template in the trend graph* option in the component's settings would incorrectly not be applied.

Also, when a shape showing a trend component was configured to not show the bottom navigator chart, up to now, changes made to the mouse actions in the component's settings would incorrectly not be applied until the card was re-opened.

#### Bookings module: Listed bookings would be sorted incorrectly [ID 43641]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When, in Cube's *Bookings* module (or the *Skyline Booking Manager* connector), the *List View* component was configured to show a custom culture-invariant DateTime property, up to now, the listed bookings would be sorted incorrectly.

#### Trending: Exception values not marked as such would be interpreted as valid trend points without Y axis label [ID 43696]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

In a trend graph showing trending of string values, in some cases, exception values would incorrectly not be marked as such, causing DataMiner to interpret those values as valid trend points without Y axis label.

#### Problem when sending a ParameterChangeEventMessage for a non-string parameter [ID 43701]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

When you retrieved the string value of a non-string parameter that was being updated, an exception would be thrown as the string value was null.

#### Cube UI could get stuck when an error occurred while an embedded web browser was initialized [ID 43732]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

Up to now, when an error occurred while an embedded web browser was initialized, in some cases, the entire Cube UI could get stuck.

Overall error handling has now been improved. When an embedded web browser throws an exception, that exception will now be caught, information about the error will be logged, and an appropriate error message will appear in the browser control.
