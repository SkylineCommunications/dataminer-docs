---
uid: Web_apps_Feature_Release_10.5.2
---

# DataMiner web apps Feature Release 10.5.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.2](xref:General_Feature_Release_10.5.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.2](xref:Cube_Feature_Release_10.5.2).

## Highlights

*No highlights have been selected yet.*

## New features

#### Dashboards/Low-Code Apps: New variable 'DMAIP' [ID 41561]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In dashboards and low-code apps, you can now use a new variable `DMAIP`, which contains the hostname and the IP port of the URL.

Examples:

| URL | DMAIP value |
|-----|-------------|
| `https://myaddress.skyline.local/dashboard/#/db/SLC/QA%20tables.dmadb` | myaddress.skyline.local |
| `https://localhost:4200/#/db/SLC/QA%20tables.dmadb` | localhost:4200 |

## Changes

### Enhancements

#### Web apps: Angular and other dependencies have been upgraded [ID 41488]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, etc.), Angular and other dependencies have been upgraded.

#### Low-Code Apps - Interactive Automation scripts: Redesigned UI component 'Button' [ID 41495]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

The UI component `UIBlockType.Button` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new *Button* component, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Video thumbnails will now have a default volume of 100% [ID 41597]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Video thumbnails will now have a default volume of 100%.

Up to now, when you clicked the sound icon of a video thumbnail, the video would unmute, but the volume would stay at 0%. From now on, when a video is unmuted, its volume will be at 100%.

#### Dashboards/Low-Code Apps: 'Link to data' dialog box has been redesigned [ID 41682]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

The *Link to data* dialog box has been redesigned. It will now offer a better overview, especially when a large number of entries are listed.

### Fixes

#### Dashboards/Low-Code Apps - Timeline component: Boundaries of the vertical timeline sections would not be correct [ID 41514]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, the boundaries of the vertical timeline sections would not be correct. For example, one-month sections would not start on the first day of the month.

#### Dashboards app: Dashboard lists would incorrectly not be shown on mobile devices [ID 41548]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you opened the Dashboards app on a mobile device, none of the following dashboard lists would be shown:

- Overview
- Recent
- Private
- Shared

#### Web API: Client applications would not receive any new events due to a WebSocket clean-up issue [ID 41560]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Due to a WebSocket clean-up issue, in some rare cases, client applications would incorrectly not receive any new events.

#### Dashboards/Low-Code Apps - Visual overview component: Loading indicator would not be shown [ID 41565]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, a *Visual overview* component would incorrectly not show any loading indicator when it was loading a visual overview.

#### Dashboards app: Users without access to the root folder would see a 'Loading' bar in the navigation pane [ID 41566]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you had not been granted access to the root folder, the navigation pane would keep on showing a "Loading" bar.

#### Low-Code Apps: State of newly created duplicate would be 'published' instead of 'draft' [ID 41623]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you duplicated a published app, and then previewed the newly created duplicate, in the version history, its state would incorrectly be set to "published" instead of "draft".

#### Dashboards/Low-Code Apps - Visual overview component: Problem when changing the page to be displayed to the first page of the Visio file [ID 41628]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When, in the settings of a *Visual overview* component, you changed the page to be displayed to the first page of the Visio file (i.e. page 0), up to now, the component would incorrectly continue to display the page that was selected before.

#### Low-Code Apps - Timeline component: Custom time zone would not be taken into account by the 'Set viewport' action [ID 41632]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When a custom time zone was configured in a *Timeline* component, up to now, that time zone would not be taken into account by the *Set viewport* action.

#### Dashboards/Low-Code Apps: Table and Grid components could incorrectly keep fetching query rows after the session had been closed [ID 41670]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, *Table* and *Grid* components could incorrectly keep fetching query rows after the session had been closed, eventually causing the web page to become unresponsive.

#### Web API: DOMHelper could stop working when a DOM instance was updated while a client connection was being closed [ID 41677]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When a DOM instance was updated while a client connection was being closed, in some cases, the DOMHelper could stop working.
