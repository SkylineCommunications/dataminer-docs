---
uid: Cube_Feature_Release_10.6.5
---

# DataMiner Cube Feature Release 10.6.5 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner Cube client application contains the same new features, enhancements, and fixes as DataMiner Cube Main Release 10.6.0 [CU2].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.5](xref:General_Feature_Release_10.6.5).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.6.5](xref:Web_apps_Feature_Release_10.6.5).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### Enhancements made to the redesigned Cube UI and themes [ID 44977]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In version 10.6.4, the entire Cube UI and UI themes were redesigned. In this version, a number of additional enhancements have been made.

#### Trending: Enhanced performance when retrieving trend group data [ID 44982]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Because of a number of enhancements, overall performance has increased when retrieving trend group data, especially on systems with a large number of trend groups.

Also, an SPI log entry has been added that will record how long Cube had to wait for a server response after sending a query to retrieve trend group data.

#### Spectrum analysis: Trace thumbnails will now be updated more frequently [ID 44996]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In spectrum cards, up to now, a spectrum trace thumbnail that appeared after selecting a measurement point would be updated in real time up to 5 times per seconds. From now on, trace thumbnails will be updated up to 40 times per seconds (i.e., once every 25 milliseconds), depending on overall parameter update frequency.

### Fixes

#### Visual Overview: Child shapes of a Children shape would not be initialized correctly [ID 44816]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

In some cases, child shapes of a Children shape would not be initialized correctly, causing it to be drawn inaccurately.

#### Automation: Problem when discarding changes made to dummy, parameter, or memory files [ID 44853]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When you modified a dummy, parameter, or memory file in an automation script, and then discarded the changes you made, up to now, the original script configuration would not get restored correctly. DataMiner Cube would incorrectly continue to display the updated dummy, parameter, or memory file after you had discarded the changes, even in other modules like Scheduler.

For example, when you had discarded a change to a dummy, parameter, or memory file in an automation script, and then edited a scheduled task that used that same script, the configuration inputs would appear empty, even though the changes to the script had not been saved.

#### Visual Overview: Trend graphs would incorrectly not show any aggregation trending [ID 44955]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Since DataMiner version 1.0.1.0 CU22/10.2.0 CU10/10.3.1, trend graphs in a visual overview would incorrectly not show any aggregation trending.

#### UI sections containing embedded browser windows would remain empty when Microsoft Edge (WebView2) browser engine was not loaded [ID 44984]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

When, for whatever reason, the Microsoft Edge (WebView2) browser engine had not been loaded, up to now, parts of the Cube UI that contained embedded browser windows would incorrectly remain empty.

#### Spectrum analysis: Incorrect trace data would be shown when selecting multiple measurement points [ID 45059]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when you selected multiple measurement points, in some cases, incorrect trace data would be shown.

Also, the grid would not resize correctly when you selected the *Show external labels* option for the first time.

#### Spectrum analysis - Combined measurement point view: Not all traces would be shown when multiple measurement points were selected [ID 45070]

<!-- MR 10.5.0 [CU14] / 10.6.0 [CU2] - FR 10.6.5 -->

Up to now, when the *Combined measurement point view* option was enabled, in some cases, not all traces would be shown when multiple measurement points were selected.
