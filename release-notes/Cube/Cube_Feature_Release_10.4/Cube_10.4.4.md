---
uid: Cube_Feature_Release_10.4.4
---

# DataMiner Cube Feature Release 10.4.4 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to DataMiner Cube, see [General Feature Release 10.4.4](xref:General_Feature_Release_10.4.4).

## Highlights

*No highlights have been selected yet.*

## New features

*No features have been added yet.*

## Changes

### Enhancements

#### System Center: Enhanced 'Cloud' page [ID_38715]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

On the *Cloud* page of *System Center*, a link to <https://dataminer.services> has now been added. This will allow users to check the cloud connection status of their DataMiner System.

Also, the instructions and the general information on that page have been made clearer.

#### Visual Overview: Enhanced management of memory allocated to mobile visual overviews [ID_38727]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

Up to now, the memory used for all mobile visual overviews would remain allocated until the last user had been inactive for 5 minutes.From now on, the memory allocated to a specific mobile visual overview will be released as soon as the visual overview in question has been inactive for 5 minutes.

Also, the Cube session hosting these mobile visual overviews will now automatically terminate after 8 hours of inactivity.

#### CubeConnection entry added to SLClient.txt will now include the DMA server version [ID_38796]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

Each time a Cube client has fully connected to a DataMiner Agent, a *CubeConnection* entry is added to the *SLClient.txt* log file of the DataMiner Agent in question.

From now on, this *CubeConnection* entry will also include the DataMiner Agent server version.

### Fixes

#### Error could occur in SLHelper when generating visual overviews to be displayed in web apps [ID_32584]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, an error could occur in SLHelper when it was generating visual overviews to be displayed in web apps.

#### DataMiner Cube could become unresponsive after you had logged in [ID_38607]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, after you had logged in, DataMiner Cube could become unresponsive when the "Show the news section" setting was enabled.

#### Visual Overview: Problem when linking a shape to a Data Display page of an element [ID_38665]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When, in a visual overview of a service, a shape was linked to a Data Display page of an element within that service (using a *DataDisplayPage* data field), the alarm state color of the shape would not be updated correctly.

The alarm state color of the shape would be initialized correctly, but when the state of the element changed, the alarm state color of the shape would incorrectly reflect the alarm state color of the element instead of that of the element's Data Display page to which the shape was linked.

#### Problems with selection boxes in Automation and Data Display [ID_38714]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In Automation, up to now, when no element context was provided, parameter value selection boxes populated with values from another parameter (i.e. so-called dependency values) would incorrectly be empty. From now on, when no element context is provided, selection boxes populated with values from another parameter will now be populated with discrete values configured in the protocol. Moreover, if no values can be found for a particular selection box, it will become editable, allowing you to enter values manually.

Also, when you opened a parameter value selection box populated with values from another parameter in Data Display after having configured the same parameter by means of a set action in Automation, the parameter value selection box in Data Display could incorrectly be empty.

#### Visual Overview: An embedded browser component would incorrectly be created when generating mobile visual overviews [ID_38721]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When generating a mobile visual overview with *Link* shapes containing an inline link (i.e. a URL preceded by a # character), up to now, an embedded browser component would incorrectly be created. From now on, embedded browsers will no longer be created in this case.

#### Spectrum analyzer cards could leak memory [ID_38725]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, spectrum analyzer cards could leak memory.

#### Memory leak when opening a trend graph that had pattern matching activated [ID_38728]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, DataMiner Cube could leak memory when you opened a trend graph that had pattern matching activated.

#### Problem when closing a spectrum analyzer card while it was still loading [ID_38729]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you closed a spectrum analyzer card while it was still loading, in some cases, an unhandled exception could be thrown.

#### Trending: Proactive alarm tooltip would immediately disappear [ID_38749]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When the trend prediction shown in a trend graph exceeds a particular alarm threshold, this is indicated with a triangle-shaped marker.

Up to now, when you hovered the mouse pointer over that marker, the tooltip would immediately disappear. From now on, the tooltip will remain visible until you move the mouse pointer away from the marker.

#### Memory leak when closing apps [ID_38792]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you closed an app (e.g. Automation, Correlation, etc.), in some cases, Cube could leak memory.

#### Memory leak when opening trend graphs [ID_38799]

<!-- MR 10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

When you opened a trend graph, in some cases, Cube could leak memory.
