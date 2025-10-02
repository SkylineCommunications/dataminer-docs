---
uid: Web_apps_Feature_Release_10.5.12
---

# DataMiner web apps Feature Release 10.5.12 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU21] and 10.5.0 [CU9].

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.12](xref:General_Feature_Release_10.5.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.12](xref:Cube_Feature_Release_10.5.12).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

*No enhancements have been added yet.*

### Fixes

#### GQI DxM: Existing query sessions would incorrectly be allowed to use a restarted extension worker [ID 43770]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When an extension worker process had stopped unexpectedly, e.g. because someone had manually killed it, up to now, the process would automatically restart when a new query was executed, and existing query sessions would be allowed to use it as if nothing had happened.

However, when the extension worker restarted, the state of the existing query sessions would no longer be valid, causing the core GQI process to no longer be able to communicate correctly with the extension worker process.

From now on, when an extension worker process is stopped, all references to that process in the existing query sessions will be rendered invalid. If an existing query session then attempts to use the extension worker, the following error message will be thrown:

`Extension worker for '<ExtensionLibrary>' has exited.`

Other changes made with regard to extension worker behavior:

- While an extension worker is being shut down, from now on, another extension worker will be allowed to start up or shut down.
- Requesting the data source metrics of active extension workers will no longer reset their expiration time. In other words, if an extension worker is due to expire, requesting the data source metrics will no longer have any affect on that expiration.
- Extension worker references will no longer leak memory when a new extension worker is starting up while the previous one for the same extension library is being shut down.

#### Web apps: Old login page would incorrectly appear when navigating to '/login' directly [ID 43796]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When you navigated to the login page of a web app by using a URL like `https://<DMA IP or hostname>/monitoring/login`, up to now, the app's old login page would incorrectly appear. From now on, an "error 404" page will appear instead.

#### Dashboards/Low-Code Apps - Maps component: Clicking 'Save current view' would set the latitude to an invalid value [ID 43812]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When, in the *Layout* pane of a *Maps* component, you clicked *Save current view* after the map had been panned horizontally, in some cases, the longitude would be set to an invalid value outside the [-180,180] range.

#### Dashboards/Low-Code Apps - Line & area chart component: Problem with parameter filter would cause trended parameters to not show up in the component [ID 43813]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, the parameter filter that was used when checking whether or not a parameter was trended would incorrectly be based on the primary key instead of the display key. As a result, in some cases, trended parameters that matched the filter would incorrectly be considered as not trended, causing them to not show up in the component.

#### Dashboards/Low-Code Apps: Search input component would not pass an empty value when its default value was cleared [ID 43819]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When a *Search input* component had its *Emit value on* option set to "Value change", up to now, it would not pass an empty value when its value was cleared after the default selection had been (re)applied.

#### Dashboards/Low-Code Apps - Time range component: Problem when scheduling the PDF generation of dashboard reports using a relative timespan [ID 43828]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When the *Time range* component had been used to schedule the PDF generation of dashboard reports, the reports would not be generated at the correct time when a relative timespan (e.g. "Today so far") had been specified. Instead of the relative timespan, the system would incorrectly use a fixed timespan based on the moment at which the time range had been configured.
