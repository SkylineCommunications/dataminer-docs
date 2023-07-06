---
uid: Cube_Feature_Release_10.3.9
---

# DataMiner Cube Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.3.9](xref:General_Feature_Release_10.3.9).

## Highlights

*No highlights have been selected yet.*

## Other new features

#### Visual Overview: New custom color 'bg.pressededitor' for parameter controls of type 'Lite' [ID_36779]

<!-- MR 10.4.0 - FR 10.3.9 -->

When you turn a shape into a parameter control of type "Lite", you can use the *CustomColors* option to customize the colors of that parameter control.

You can now define a new color called *bg.pressededitor*. This color will be used as background when the left mouse button is pressed within the editor part of the control.

For more information, see [CustomColors](xref:Adding_options_to_a_parameter_control#customcolors).

## Changes

### Enhancements

#### Errors or alarms will no longer be generated at startup when the DMS does not include an indexing engine [ID_36590]

<!-- MR 10.4.0 - FR 10.3.9 -->

From now on, when the DataMiner System does not include an indexing engine, no run-time errors or alarms of type "Notice" will be generated for ServiceManager, TicketingManager, ResourceManager and ProfilesManager at startup.

Also, when you open the *Profiles*, *Resources* or *Bookings* app in Cube, a message will now appear, saying that the DataMiner System does not include an indexing engine.

#### Trending - Relation learning: Clearer log information [ID_36760]

<!-- MR 10.4.0 - FR 10.3.9 -->

With the introduction of time-scoped parameter relations, two different light bulb icons can now appear in a trend graph: one in the top-right corner and another one whenever you select a section of the trend graph.

When the requirements of a light bulb are not met, an entry is added to the Cube logging. From now on, these log entries will make a clearer distinction between the "relation light bulb feature" (i.e. the icon appearing in the top-right corner) and the "time-scoped relation feature" (i.e. the icon appearing when you select a trend graph section).

### Fixes

#### DataMiner Cube: Report or dashboard would not be selected after 'Email', 'Upload to FTP' or 'Upload to shared folder' action was initialized [ID_36631]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

In *Automation*, *Correlation* and *Scheduler*, you can select a report of a dashboard in an *Email*, *Upload to FTP* or *Upload to shared folder* action. When such an action was initialized, in some rare cases, the report or dashboard would not be automatically selected.

#### DataMiner Cube - Trending: Panning across the graph would not work [ID_36769]

<!-- MR 10.2.0 [CU18]/10.3.0 [CU6] - FR 10.3.9 -->

When you opened a trend graph showing trend data of a parameter that only had average trending enabled, in some cases, it would not be possible to pan across the graph.
