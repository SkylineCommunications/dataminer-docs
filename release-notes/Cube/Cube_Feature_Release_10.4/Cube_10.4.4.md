---
uid: Cube_Feature_Release_10.4.4
---

# DataMiner Cube Feature Release 10.4.4

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.4](xref:General_Feature_Release_10.4.4).
> - For release notes related to the DataMiner web applications, see [DataMiner web apps Feature Release 10.4.4](xref:Web_apps_Feature_Release_10.4.4).

## Changes

### Enhancements

#### System Center: Enhanced 'Cloud' page [ID 38715]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

On the *Cloud* page of *System Center*, a link to <https://dataminer.services> has now been added. This will allow users to check the cloud connection status of their DataMiner System.

Also, the instructions and the general information on that page have been made clearer.

#### Visual Overview: Enhanced management of memory allocated to mobile visual overviews [ID 38727]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

Up to now, the memory used for all mobile visual overviews would remain allocated until the last user had been inactive for 5 minutes.From now on, the memory allocated to a specific mobile visual overview will be released as soon as the visual overview in question has been inactive for 5 minutes.

Also, the Cube session hosting these mobile visual overviews will now automatically terminate after 8 hours of inactivity.

#### CubeConnection entry added to SLClient.txt will now include the DMA server version [ID 38796]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

Each time a Cube client has fully connected to a DataMiner Agent, a *CubeConnection* entry is added to the *SLClient.txt* log file of the DataMiner Agent in question.

From now on, this *CubeConnection* entry will also include the DataMiner Agent server version.

### Fixes

#### Error could occur in SLHelper when generating visual overviews to be displayed in web apps [ID 32584]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, an error could occur in SLHelper when it was generating visual overviews to be displayed in web apps.

#### DataMiner Cube could become unresponsive after you had logged in [ID 38607]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, after you had logged in, DataMiner Cube could become unresponsive when the "Show the news section" setting was enabled.

#### Visual Overview: Problem when linking a shape to a Data Display page of an element [ID 38665]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When, in a visual overview of a service, a shape was linked to a Data Display page of an element within that service (using a *DataDisplayPage* data field), the alarm state color of the shape would not be updated correctly.

The alarm state color of the shape would be initialized correctly, but when the state of the element changed, the alarm state color of the shape would incorrectly reflect the alarm state color of the element instead of that of the element's Data Display page to which the shape was linked.

#### Problems with selection boxes in Automation and Data Display [ID 38714]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In Automation, up to now, when no element context was provided, parameter value selection boxes populated with values from another parameter (i.e. so-called dependency values) would incorrectly be empty. From now on, when no element context is provided, selection boxes populated with values from another parameter will now be populated with discrete values configured in the protocol. Moreover, if no values can be found for a particular selection box, it will become editable, allowing you to enter values manually.

Also, when you opened a parameter value selection box populated with values from another parameter in Data Display after having configured the same parameter by means of a set action in Automation, the parameter value selection box in Data Display could incorrectly be empty.

#### Visual Overview: An embedded browser component would incorrectly be created when generating mobile visual overviews [ID 38721]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When generating a mobile visual overview with *Link* shapes containing an inline link (i.e. a URL preceded by a # character), up to now, an embedded browser component would incorrectly be created. From now on, embedded browsers will no longer be created in this case.

#### Spectrum analyzer cards could leak memory [ID 38725]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, spectrum analyzer cards could leak memory.

#### Memory leak when opening a trend graph that had pattern matching activated [ID 38728]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, DataMiner Cube could leak memory when you opened a trend graph that had pattern matching activated.

#### Problem when closing a spectrum analyzer card while it was still loading [ID 38729]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you closed a spectrum analyzer card while it was still loading, in some cases, an unhandled exception could be thrown.

#### Visual Oveview: DCF connections would not show any properties when the MultipleLinesMode option was used [ID 38748]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When the *MultipleLinesMode* option was used, DCF connections would incorrectly not show any properties.

#### Trending: Proactive alarm tooltip would immediately disappear [ID 38749]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When the trend prediction shown in a trend graph exceeds a particular alarm threshold, this is indicated with a triangle-shaped marker.

Up to now, when you hovered the mouse pointer over that marker, the tooltip would immediately disappear. From now on, the tooltip will remain visible until you move the mouse pointer away from the marker.

#### Memory leak when closing apps [ID 38792]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you closed an app (e.g. Automation, Correlation, etc.), in some cases, Cube could leak memory.

#### Memory leak when opening trend graphs [ID 38799]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you opened a trend graph, in some cases, Cube could leak memory.

#### Memory leak when opening the Settings window [ID 38810]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you opened the Settings window, in some cases, Cube could leak memory.

#### Memory leak when opening advanced search in sidebar [ID 38901]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you opened the advanced search in the sidebar, in some cases, Cube could leak memory.

#### Broadcast message popup containing more than one message would not display the first message [ID 38903]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When Cube displayed a broadcast message popup containing more than one message, the first message would incorrectly not be shown.

#### Memory leak when opening an embedded browser component [ID 38919]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you opened an embedded browser component, in some cases, Cube could leak memory.

#### Memory leak when opening an EPM card using the topology selector [ID 38963]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you opened an EPM card using the topology selector, in some cases, Cube could leak memory.

#### Alarm Console: Name of history tab was incorrect on February 29 [ID 38968]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you added a history tab on February 29, the name of the tab would be incorrect.

For example, when on February 29 you added a history tab listing all alarms generated during the last year, the name of the tab would incorrectly be "Last 366 days" rather than "Year to date".

#### Visual Overview: Memory leak when shapes were configured to display pages of a Visio drawing [ID 39103]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 [CU0] -->

In some cases, DataMiner Cube could leak memory when viewing a visual overview in which shapes were configured to display pages of a Visio drawing.
