---
uid: Web_apps_Feature_Release_10.5.9
---

# DataMiner web apps Feature Release 10.5.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.9](xref:General_Feature_Release_10.5.9).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.9](xref:Cube_Feature_Release_10.5.9).

## Highlights

*No highlights have been selected yet.*

## New features

#### Low-Code Apps: Using script output in the post actions of a 'Launch a script' action [ID 43222]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The output of an Automation script can now be used in the post actions of a *Launch a script* action.

If a referenced key does not exist in the output, it will by default return an empty string.

Actions will now be numbered hierarchically to allow easier referencing when linking output data. See the example below.

- 1

  - 1.1

    - 1.1.1

  - 1.2

    - 1.2.1
    - 1.2.2

      - 1.2.2.1

- 2

## Changes

### Enhancements

#### DataMiner landing page: Redesigned app sections [ID 43115] [ID 43226]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

The app sections on the DataMiner landing page (e.g. `https://myDMA/root/`) have been redesigned.

- In the upper section, you will find the native DataMiner apps like Dashboards, Monitoring, and Cube.
- In the lower section, you will find the apps you downloaded from the DataMiner Catalog as well as the low-code apps you create yourself (in different tabs per category).

  Click *Browse catalog* to open the [DataMiner Catalog](https://catalog.dataminer.services/) or *Create app* to create a low-code app.

### Fixes

#### Dashboards app & Low-Code Apps - Timeline component: Group label tooltips missing [ID 43242]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When, in a *Timeline* component, you had grouped on multiple columns, only the labels of the bottom-level group would have a tooltip.

From now on, all group labels will have a tooltip.

#### Low-Code Apps: Actions on open panels would stop working when you switched from one page to another [ID 43256]

<!-- MR 10.4.0 [CU18] / 10.5.0 [CU6] - FR 10.5.9 -->

When you switched from one page to another, up to now, actions on open panels would stop working.
