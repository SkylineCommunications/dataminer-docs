---
uid: Web_apps_Feature_Release_10.5.8
---

# DataMiner web apps Feature Release 10.5.8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.8](xref:General_Feature_Release_10.5.8).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.8](xref:Cube_Feature_Release_10.5.8).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Dashboards app & Low-Code Apps: Automatically saved component settings will only get saved when in edit mode [ID 43029]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, certain component settings would automatically get saved in a dashboard or low-code app, even when you were not in edit mode.

From now on, these automatically saved component settings will only get saved in a dashboard or low-code code when you are in edit mode.

#### Web apps: Email address of Skyline support has been changed to <support@dataminer.services> [ID 43093]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In all DataMiner web apps, the email address of Skyline support has been changed from <techsupport@skyline.be> to <support@dataminer.services>.

### Fixes

#### Low-Code Apps: It would incorrectly be possible to publish a low-code app while it was still being saved [ID 42680]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

Up to now, it would incorrectly be possible to publish a low-code app while it was still being saved.

From now on, it will only be possible to publish a low-code app when the app has been saved.

#### Low-Code Apps - Interactive Automation scripts: initialValue of UI component 'Time' would not get updated in the UI when the value changed [ID 42878]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When the `UIBlockType.Time` component had a time range configured in the AutomationTimeUpDownOptions property, up to now, the initialValue that was displayed, would incorrectly not get updated when the value changed.

#### Dashboards app & Low-Code Apps - Line & area chart component: Y axis name change would incorrectly only be propagated to other Y axis settings after moving the mouse pointer [ID 42940]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in a *Line & area chart* component, you had changed the name of the Y axis, up to now, that name change would incorrectly only be propagated to other Y axis settings after you had moved the mouse pointer. From now on, the change will get propagated immediately.

#### Low-Code Apps: Components used in a low-code app could cause a user's web browser to leak memory [ID 42955]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

In some cases, components used in a low-code app could cause a user's web browser to leak memory.

#### Web Services API: SLHelper would incorrectly be used to process GQI queries when GQI DxM had been enabled in Web.config [ID 43046]

<!-- MR 10.4.0 [CU17] / 10.5.0 [CU5] - FR 10.5.8 -->

When, in the `C:\Skyline DataMiner\Webpages\API\Web.config` file, you had specified that all GQI-related operations had to be executed by the GQI DxM, in some cases, SLHelper would incorrectly still be used to process GQI queries.
