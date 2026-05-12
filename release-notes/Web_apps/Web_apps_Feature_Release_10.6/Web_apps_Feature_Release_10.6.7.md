---
uid: Web_apps_Feature_Release_10.6.7
---

# DataMiner web apps Feature Release 10.6.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.6.0 [CU4].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.6.7](xref:General_Feature_Release_10.6.7).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.6.7](xref:Cube_Feature_Release_10.6.7).

## Highlights

*No highlights have been added yet.*

## New features

#### GQI DxM - Extensions: Retrieving the Culture and Timezone from the Session object [ID 45348]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Within a GQI extension, it will now be possible to retrieve the *Culture* and *Timezone* from the `Session` object. When the `IGQIOnInit` interface is implemented, the `Session` object is a property of `OnInitInputArgs`.

> [!NOTE]
> For this new feature to work, the extension needs to be created with the `Skyline.DataMiner.Core.GQI.Extensions` NuGet (version 1.1.0 or above). The feature is not supported when the extension is created using the `SLAnalyticsTypes` API.

## Changes

### Enhancements

#### Low-Code Apps: Enhanced performance when loading pages and panels [ID 45365]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Because of a number of enhancements, overall performance has increased when loading pages and panels of low-code apps.

#### DataMiner Web Services API v0 has now been removed [ID 45387]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

The DataMiner Web Services API v0 was declared End of Life in DataMiner version 10.1.5. It has now been removed from the code base.

> [!IMPORTANT]
> It will no longer be possible to enable the v0 interface by setting the `enableLegacyV0Interface` key to true in the `C:\Skyline DataMiner\Webpages\API\Web.config` file.

#### Dashboards/Low-Code Apps: Spectrum analyzer component will now behave more like its counterpart in DataMiner Cube [ID 45401]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

From now on, the *Spectrum analyzer* component will behave more like its counterpart in DataMiner Cube.

Up to now, when you selected a new measurement point, the `maxHold` value would incorrectly not be reset. From now on, selecting a new measurement point will reset the `maxHold`, `minHold`, and `avgTrace` values.

#### Dashboards/Low-Code Apps - Web component: 'Open in sandbox' setting renamed to 'Isolate' and now also available when 'Type' is set to 'Custom HTML' [ID 45422]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, when configuring a *Web* component, it would only be possible to enable or disable the *Open in sandbox* setting when *Type* was set to "Webpage".

From now on, it will also be possible to enable or disable this setting, which has now been renamed to *Isolate*, when *Type* is set to "Custom HTML".

#### Dashboards/Low-Code Apps: Spectrum sessions list can now be filtered by name [ID 45430]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When you have a *List* component listing spectrum sessions, you can now filter that list by name. To do so, link a data field of type string to the filter of the *List* component. This data field will then act as a filter box.

#### Dashboards/Low-Code Apps - Spectrum analyzer component: New 'Color source' option [ID 45437]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

The Spectrum analyzer component now has a *Color source* option, which can be set to either "Preset" or "Custom".

- When you set this option to "Preset":

  - Trace color and line visibility are inherited from the loaded preset (legacy behavior).

- When you set this option to "Custom":

  - Trace, threshold, minimum, maximum, and average colors are inherited from the theme settings, and can be customized if necessary.
  - Measurement point trace colors are resolved via theme color indexing based on the measurement point key/name.
  - Background, font, axis, and grid colors are all inherited from the component theme.

### Fixes

#### Dashboards/Low-Code Apps - Interactive automation scripts: Redesigned controls would incorrectly not allow you to use the arrow keys to move the cursor [ID 45313]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When, in a dashboard or a low-code app, an interactive automation script was launched in a popup window, the redesigned controls would incorrectly not allow you to use the arrow keys to move the cursor.

For example, when you pressed the *Up*/*Down* arrow in a multi-line textbox, the cursor would incorrectly not move to the previous/next line.

#### Dashboards/Low-Code Apps: Problem with 'Data used in ...' sections [ID 45373]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When you open a dashboard or a low-code app, the *Data used in dashboard/page/panel* section of the *Data* pane will list all data items used in the dashboard or low-code app page or panel, such as data sources, filters, and more, and when you select a particular component, the *Data used in component* section of the *Data* pane will list all data items used in the currently selected component.

However, up to now, because of a filtering issue, in some cases, these sections would not list the correct data items.

#### Dashboards/Low-Code Apps: Conditions with unknown columns would incorrectly not be shown in the template editor [ID 45379]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In some cases, conditions with unknown columns would not be shown in the template editor. As a result, they could not be edited or removed.

This would often happen when a template from another component had been applied using the *Browse templates* window.

From now on, whenever an unknown column is detected, it will be marked as such, and the condition will be shown correctly in the template editor.

#### Dashboards/Low-Code Apps - Query builder: Problem when a 'Get resources' query was linked to data [ID 45390]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When a *Get resources* query filtered by resource pool ID or booking ID was linked to data, up to now, an error would be thrown when the data item was empty.

From now on, no error will be thrown anymore. Instead, an empty result will be shown.

#### Dashboards/Low-Code Apps - Query builder: Resolving the join columns of a query would fail when the URL included the 'showAdvancedSettings=true' option [ID 45397]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When you edited an existing query containing a join, up to now, resolving the join columns would fail when the URL included the `showAdvancedSettings=true` option.

The query builder would incorrectly consider non-mandatory options (e.g., *Row by row* and *Prefetch*) without a value as unresolved, causing the join node to remain expanded and preventing all downstream nodes from loading.

#### Dashboards/Low-Code Apps: Spectrum analyzer component would either show no trace or an incorrect trace [ID 45410]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

When a *Spectrum analyzer* component in a dashboard or a low-code app loaded a spectrum preset when no measurement point had been selected, up to now, SLSpectrum would be unable to convert the display frequencies into device frequencies. As a result, the start/stop frequencies would appear out of range, no values would be sent to the connector, and either no trace or an incorrect trace would be displayed.

From now on, when no measurement point was selected, SLSpectrum will apply the measurement point stored in the preset before processing frequency values. This will ensure that the correct frequency offset context is available, and that display frequencies are properly converted into device frequencies.

#### Web apps opened via remote access would not be able to retrieve the manifest file [ID 45416]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, when a DataMiner web app was opened via remote access, it would fail to retrieve the manifest file. As a result, the app would not be considered a Progressive Web App (PWA) and would not be allowed to install locally.

#### Low-Code Apps: Changing the type of a variable without default value would incorrectly not be saved [ID 45417]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

Up to now, when you changed the type of a variable that did not have a default value, the update would incorrectly not be saved.

#### Monitoring app: List of available pages in an element card would incorrectly include a 'Dashboards' page when the LegacyReportsAndDashboards option was disabled [ID 45420]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In the *Monitoring* app, up to now, the list of available pages in an element card would incorrectly include a *Dashboards* page when the *LegacyReportsAndDashboards* soft-launch option was disabled.

#### Web apps: Inconsistencies and missing properties in manifest files [ID 45424]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

In the manifest files of the DataMiner web apps, a number of inconsistencies have been fixed and a number of missing properties have been added.

From now on, all web apps will use the same theme colors and the correct icons. Also, it will be possible to install all of them as Progressive Web Apps (PWAs).

#### Dashboards/Low-Code Apps - Query filter component: Problem when filtering numeric columns on discrete values [ID 45490]

<!-- MR 10.5.0 [CU16] / 10.6.0 [CU4] - FR 10.6.7 -->

On systems using the GQI DxM, in a *Query filter* component, it would no longer be possible to filter numeric columns on discrete values when filter assistance was enabled.
