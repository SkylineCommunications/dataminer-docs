---
uid: Cube_Feature_Release_10.4.9
---

# DataMiner Cube Feature Release 10.4.9

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.9](xref:General_Feature_Release_10.4.9).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.9](xref:Web_apps_Feature_Release_10.4.9).

## Changes

### Enhancements

#### Security enhancements [ID 39585]

<!-- 39585: MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

A number of security enhancements have been made.

#### Visual Overview: Enhanced performance when loading AlarmSummary shapes [ID 39593]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Because of a number of enhancements, overall performance has increased when loading AlarmSummary shapes.

#### Visual Overview will now only subscribe on the specified properties when property placeholders are being used [ID 40008]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in a visual overview, a property placeholder was used, up to now, the visual overview would always subscribe on all properties associated with the linked object, regardless of the property specified in the property placeholder. From now on, the visual overview will only subscribe on the property name that is specified.

#### System Center - Agents: Some buttons will no longer be visible when Cube is connected to a DaaS system [ID 40013]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When Cube is connected to a DaaS system, the following buttons will no longer be visible in the *Agents* section of *System Center*:

- *Stop*
- *Shut down*
- *Reboot*
- *Failover...*

Also, the user permissions that control access to these buttons will no longer be visible:

- *Modules > System configuration > Agents > Stop*
- *Modules > System configuration > Agents > Shut down*
- *Modules > System configuration > Agents > Reboot*
- *Modules > System configuration > Agents > Configure Failover*

#### Trending: Light bulb in top-right corner of trend graphs is now better visible in the Skyline Black theme [ID 40059]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

The color of the light bulb in the top-right corner of trend graphs has been made brighter to make the light bulb better visible in the Skyline Black theme.

#### Alarm templates & trend templates: Analytics trending features can no longer be configured for general parameters [ID 40086]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Since the analytics trending features cannot be used for general parameters, from now on, the options to configure these features will no longer be available when you are configuring general parameters in an alarm template or a trend template.

Also, when a general parameter is being trended, it will no longer be possible to create a trend pattern for that parameter.

#### Visual Overview: WPF Path markup parsing will now be culture invariant [ID 40094]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, when you made a custom drawing by entering WPF Path markup in a shape data field of type *Path*, the decimal separator had to match the one that was set on the client computer.

From now on, the WPF Path markup parsing will be culture invariant, accepting both "." and "," as decimal separator.

#### System Center - Agents: BPA tests that have not been scheduled will now be displayed in a lighter font [ID 40113]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

In the *BPA* tab of the *Agents* section, BPA tests that have not been scheduled will now be displayed in a lighter font.

Also, next to each BPA test in the list, you can now find a button that, when clicked, will open a page showing more information about that test. When you click the information button in the *Name* header, the [Running BPA tests](xref:Running_BPA_tests) page will open.

#### SPI event log entry "Cube Connection" will now be sent to the DMA before the initial data is fetched [ID 40214]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, Cube would send an SPI event log entry "Cube Connection" to the DataMiner Agent after it had fetched and processed the initial data.

From now on, it will send this SPI event log entry, which indicated how long it took for Cube to connect to the DataMiner Agent, before it fetches the initial data.

#### Cube home page: 'Did you know?' list will now show the 5 latest Dojo blog posts

When you open DataMiner Cube, from now on, the *Did you know?* list will show the 5 latest [DataMiner Dojo blog posts](https://community.dataminer.services/blog/).

Clicking the title of one of those posts, will open the post in a new browser window.

### Fixes

#### Visual Overview: 'Get Protocol' requests would be sent in an incorrect thread [ID 39543]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When *Children* shapes were being used, in some cases, *Get protocol* requests would be sent in an incorrect thread.

#### System Center - Agents: BPA tests would incorrectly show 'Execution failed' when connected to a DaaS system [ID 39929]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When DataMiner Cube was connected to a DaaS system, up to now, the test result of BPA tests than could not be run on a DaaS system would incorrectly be set to "Execution failed". From now on, BPA tests can have the status "Not applicable". If a BPA test cannot be run on a DaaS system, it will now correctly be flagged as "Not applicable".

For example, the *Minimum Requirements Check*, which cannot be run on a DaaS system, will now be set to "Not applicable" when Cube is connected to a DaaS system.

#### Trending: Trend graph windows could display duplicate graphs [ID 39930]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

When, in Data Display, you drilled down to a trend graph of a particular parameter, in some cases, a second, duplicate graph would incorrectly be displayed.

Also, in some cases, a nullreference exception could be thrown when a trend graph was being drawn.

#### Alarm templates and trend templates: Incorrectly possible to configure analytics features for parameters that did not support those features [ID 39952]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When configuring alarm templates and trend templates, up to now, it would incorrectly be possible to configure behavioral anomaly detection, proactive cap detection and trend icons for parameters that did not support those features.

#### Visual Overview: DCF connections would incorrectly be drawn from the center of the shapes when dynamic values were used [ID 39957]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When dynamic values were used in interface shapes that were child shapes on an element group, and those shapes did not have the *AllowCentralConnectivity* option enabled, in some cases, the DCF connections would incorrectly be drawn from the center of the shapes instead of their interfaces.

#### Visual Overview: Linked session variable would incorrectly not update when the selection changed in a multiple checkbox control [ID 40035]

<!-- MR 10.3.0 [CU18] / 10.4.0 [CU6] - FR 10.4.9 -->

Up to now, when you changed the selection in a multiple checkbox control, in some cases, the linked session variable would incorrectly not be updated, causing the control and the variable to get out of sync.

#### Visual Overview: Problem with 'EnableLoading=False' option [ID 40065]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

The page and shape option `EnableLoading=False` would no longer work when shapes had pending properties (e.g., properties of which the value contained unresolved placeholders).

> [!NOTE]
>
> - The `VisioLoadTimeMetric` SPI will now report on all shapes, regardless of whether they show their loading state or not.
> - From now on, the `EnableLoading` option is case insensitive.

#### Redundancy group editor would incorrectly allow saving a redundancy group containing script actions with empty dummies [ID 40068]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

Up to now, the redundancy group editor would incorrectly allow you to save a redundancy group containing script actions with empty dummies.

#### Router Control: Problem when connecting an already connected output to a new input [ID 40076]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, in the *Router Control* module, you connect an already connected output to a new input, the output first needs to be disconnected. Up to now, Cube would then send two messages: one to disconnect the output and another one to connect the output to the input. In some cases, those messages would be processed in the wrong order, causing the operation to fail.

From now on, disconnecting the output and connecting the output to the input will be performed in one single message.

#### Visual Overview: Router control shapes could flicker when session variables were updated [ID 40102]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, on the same visual overview, multiple router control shapes were linked to the same session variables, in some cases, a router control shape could flicker when a session variable update was triggered by e.g., a SetVar shape update.

#### Visual Overview: Problems with ClosePage and AutoClosePopup [ID 40131]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When a *SetVar* shape on a pop-up window was configured to close that pop-up window (by means of a *ClosePage* or *AutoClosePopup* option on the parent shape), the popup would incorrectly not close unless *Control=Shape* had been added to the *SetVarOptions* data field.

Also, when a popup was opened from a subshape of a *Children* shape, neither the *ClosePage* option nor the *AutoClosePopup* option would work.

#### View card would incorrectly be empty when opened [ID 40302]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you opened a view card, in some cases, the card would incorrectly be empty.

#### Alarm Console - Hyperlinks.xml: Hyperlink of type 'openservice' would not show all affected services [ID 40318]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When, in the *Hyperlinks.xml* file, you had configured a hyperlink that showed the services affected by an alarm in an Alarm Console column (see the example below), that column would incorrectly contain only one service affected by the alarm, even when multiple services were affected.

Example of a hyperlink that shows the services affected by an alarm in an Alarm Console column:

```xml
<HyperLink id="4" version="2" menu="root" name="Open Service" type="openservice" combineParameters="true" alarmColumn="True">[SID]</HyperLink>
```

#### Problem when clicking too close to a threshold line in a spectrum graph [ID 40365]

<!-- MR 10.3.0 [CU18]/10.4.0 [CU6] - FR 10.4.9 -->

When you wanted to zoom, pan or right-click a spectrum graph, but you clicked too close to a threshold line, the mouse events would incorrectly not work.
