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

### Fixes

#### Error could occur in SLHelper when generating visual overviews to be displayed in web apps [ID_32584]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, an error could occur in SLHelper when it was generating visual overviews to be displayed in web apps.

#### DataMiner Cube could become unresponsive after you had logged in [ID_38607]

<!-- MR 10.2.0 [CU22]/10.3.0 [CU13]/10.4.0 [CU1] - FR 10.4.4 -->

In some cases, after you had logged in, DataMiner Cube could become unresponsive when the "Show the news section" setting was enabled.

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
