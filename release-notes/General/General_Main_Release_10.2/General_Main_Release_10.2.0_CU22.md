---
uid: General_Main_Release_10.2.0_CU22
---

# General Main Release 10.2.0 CU22 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_37641]

<!-- 37641: MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of security enhancements have been made.

#### DataMiner Cube - Visual Overview: Enhanced service chain behavior [ID_37645]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

A number of UI enhancements have been made with regard to service chain behavior in visual overviews.

Up to now, in some cases, service chains could get redrawn too often, or shapes would not get redrawn when a service chain was updated. Also, context menus of shapes would not always close when those shapes were updated and context menus would incorrectly show the *Display connectivity* command twice.

#### DataMiner Cube - Spectrum analysis: Zooming inside a spectrum window [ID_37668]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

It is now possible to zoom inside a spectrum window:

- To zoom horizontally, scroll up and down. This has the same effect as altering the frequency span.
- To zoom vertically, scroll up and down while pressing the CTRL key. This has the same effect as altering the amplitude scale.

When you stop scrolling, the new zoom dimensions will be set on the spectrum analyzer device and the screen will be updated with the new data.

> [!IMPORTANT]
>
> - It is only possible to zoom horizontally if the spectrum protocol includes the *Start frequency*, *Stop frequency* and *Frequency span* parameters.
> - It is only possible to zoom vertically if the spectrum protocol includes the *Amplitude scale* parameter.

#### DataMiner Cube - Spectrum Analysis: Buttons in 'Reference lines' panel, 'Thresholds' panel and 'Measurement Points' panel have been restyled [ID_37752]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In the *View* tab of a spectrum card, the buttons in the *Reference lines* panel and the *Thresholds* panel as well as the delete buttons in the *Measurement Points* panel have been restyled to match the buttons in the *Markers* panel.

#### DataMiner Cube - Alarm Console: New alarm tab showing current suggestion events now has the 'Automatically remove cleared alarms' option enabled by default [ID_37855]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When you add a new alarm tab showing the current suggestion events, that tab will now have the *Automatically remove cleared alarms* option enabled by default.

This means that suggestion events will automatically disappear from the tab approximately 2 hours after they have been detected.

#### DataMiner Cube - Desktop application: New command-line argument 'UseInitialArgumentsAfterDisconnect' [ID_37888]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

You can now start the DataMiner Cube desktop application with the new command-line argument *UseInitialArgumentsAfterDisconnect=true*.

This argument will make sure that all other arguments you specified when you started the application will again be applied when Cube has to reconnect for some reason.

### Fixes

#### DataMiner Cube - Protocols & Templates: Function definitions would not be listed when you activated a functions file [ID_37754]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When, in the *Protocols & Templates* app, you activated a functions file, the activated function definitions would incorrectly not be listed. For this list to be displayed, you had to close the *Protocols & Templates* app and re-opened it again.

#### DataMiner Cube - Visual Overview: Placeholder containing '[Elapsed Time]' would not be updated when the elapsed time had changed [ID_37756]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When the placeholder `[Elapsed Time]` was used inside another placeholder (e.g. `[Subtract:[Elapsed Time],[PreRoll]]`), the entire placeholder (e.g. `[Subtract:[Elapsed Time],[PreRoll]]`) would not be updated when the elapsed time had changed.

#### DataMiner Cube - Pattern matching: Memory leak [ID_37771]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

DataMiner Cube could start leaking memory when you opened trend graphs with pattern matching.

#### SLAnalytics: Problem when the alarm repository was not available at startup [ID_37782]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

In some cases, an error could occur in SLAnalytics when it was not able to connect to the alarm repository at startup.

#### DataMiner Cube - Data Display: Problem when hovering over lite parameter controls in Skyline Black theme [ID_37814]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When DataMiner Cube was using the *Skyline Black* theme, lite parameter controls would become unreadable when you hovered over them.

#### Entire SNMPv3 response would be discarded when one or more cells contained 'no such instance' [ID_37815]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU10] - FR 10.4.1 -->

When a table was polled via SNMPv3 and the response included a cell that contained *no such instance*, the table would not get populated with the values that were received. Instead, the entire result set would be discarded.
