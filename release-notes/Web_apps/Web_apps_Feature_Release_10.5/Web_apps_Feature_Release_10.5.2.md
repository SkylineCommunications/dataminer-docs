---
uid: Web_apps_Feature_Release_10.5.2
---

# DataMiner web apps Feature Release 10.5.2

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU11].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.2](xref:General_Feature_Release_10.5.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.2](xref:Cube_Feature_Release_10.5.2).

## Highlights

- [Dashboards/Low-Code Apps: New variable 'DMAIP' [ID 41561]](#dashboardslow-code-apps-new-variable-dmaip-id-41561)
- [Low-Code Apps: New 'Copy to clipboard' action [ID 41729]](#low-code-apps-new-copy-to-clipboard-action-id-41729)

## New features

#### DataMiner upgrade packages now include the new GQI DxM [ID 39145] [ID 41097] [ID 41811]

<!-- MR 10.5.0 - FR 10.5.2 -->

From now on, full DataMiner upgrade packages as well as web-only DataMiner upgrade packages will include the new GQI DxM.

Up to now, all GQI-related operations were executed by the SLHelper process, which only gets updated during a full DataMiner upgrade. From now on, you can opt to have all GQI-related operations executed by the GQI DxM instead. This has the following advantages:

- GQI can now be updated independently from the DataMiner core software.
- System load by GQI operations can now be balanced among the different DataMiner Agents in a DMS.

> [!IMPORTANT]
> This feature is available in preview and should only be used on staging setups for now. By default, the DataMiner web apps will continue to use the SLHelper process to execute GQI-related operations. If you want to test the new GQI DxM, update the `C:\Skyline DataMiner\Webpages\API\Web.config` file accordingly.

> [!TIP]
> For more information, see [GQI DxM](xref:GQI_DxM).

##### Specifying when idle child processes should be terminated

When the GQI DxM is used, in the `C:\Program Files\Skyline Communications\DataMiner GQI\appsettings.custom.json` file, you can specify when idle child processes should be terminated.

See the following example. Idle child processes will be terminated within the configured *WorkerExpiration* (in this case 1 day) + 30 seconds.

```json
{
  "GQIOptions": {
    "Extensions": {
      "WorkerExpiration": "1.00:00:00"
    },
  }
}
```

#### Dashboards/Low-Code Apps: New variable 'DMAIP' [ID 41561]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In dashboards and low-code apps, you can now use a new variable `DMAIP`, which contains the hostname and the IP port of the URL.

Examples:

| URL | DMAIP value |
|-----|-------------|
| `https://myaddress.skyline.local/dashboard/#/db/SLC/QA%20tables.dmadb` | myaddress.skyline.local |
| `https://localhost:4200/#/db/SLC/QA%20tables.dmadb` | localhost:4200 |

#### Low-Code Apps: New 'Copy to clipboard' action [ID 41729]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

It is now possible to configure *Copy to clipboard* actions.

This type of action will allow users to copy a value\* to their Windows clipboard.

*\*This can be a fixed value, but also a component data entry, a value from a flow or a variable.*

#### DataMiner upgrade: New upgrade action will update web.config settings [ID 41813]

<!-- MR 10.5.0 - FR 10.5.2 -->

As the *web.config* file of the web API can contain custom settings, neither a full DataMiner upgrade nor a web-only DataMiner upgrade will replace that file.

From now on, during either a full DataMiner upgrade or a web-only DataMiner upgrade, a new upgrade action will be executed to check the *web.config* file for outdated settings. If such settings are found, the file will be updated.

> [!NOTE]
> Up to now, in some cases, communication via WebSockets would not work when the *web.config* file contained outdated settings. As this new upgrade action will now make sure the *web.config* file is up to date, most WebSocket issues should now be prevented.

## Changes

### Enhancements

#### Dashboards/Low-Code Apps - Alarm table component: Enhanced performance when fetching history alarms [ID 41342]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Overall performance has increased when fetching history alarms. From now on, history alarms will be fetched whenever the alarm filter changes and will be kept in a cache.

#### Web apps: Angular and other dependencies have been upgraded [ID 41488]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, etc.), Angular and other dependencies have been upgraded.

#### Low-Code Apps - Interactive automation scripts: Redesigned UI component 'Button' [ID 41495]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

The UI component `UIBlockType.Button` has been redesigned.

Currently, by default, the existing components will still be used by default to keep the UI aligned. If you want to use the new *Button* component, then add the following argument to the URL of the low-code app:

`?useNewIASInputComponents=true`

#### Video thumbnails will now have a default volume of 100% [ID 41597]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Video thumbnails will now have a default volume of 100%.

Up to now, when you clicked the sound icon of a video thumbnail, the video would unmute, but the volume would stay at 0%. From now on, when a video is unmuted, its volume will be at 100%.

#### Enhanced network status indicator in Dashboards app & network status banner in Low-Code Apps [ID 41669]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

The network status indicator in the *Dashboards* app is no longer a separate icon. The current network status will now be incorporated into the user icon in the top-right corner. Also, from now on, when everything is fine, no network status will be shown.

In low-code apps, network status issues will now be shown in a colored banner. Possible notices include:

- "You are offline." (red)
- "Busy recovering connection..." (orange)
- "Connection recovered." (green)

#### Dashboards/Low-Code Apps: 'Link to data' dialog box has been redesigned [ID 41682]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

The *Link to data* dialog box has been redesigned. It will now offer a better overview, especially when a large number of entries are listed.

#### Low-Code Apps: Enhanced retrieval of version history [ID 41700]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Overall performance has increased when retrieving the version history of a low-code app.

Up to now, in order to retrieve the entire version history of a low-code app, the configuration file of each version had to be checked. From now on, all version information of a low-code app can be found in the *App.info.json* file.

#### Dashboards/Low-Code Apps: Column & bar chart and Line & area chart components will only render the first 1000 items [ID 41777]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

From now on, the *Column & bar chart* and *Line & area chart* components will only render the first 1000 items.

When 1000 items have been rendered, the following message will appear: `Only the first 1 000 items are shown.`

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

#### Web API: Client applications would not receive any new events due to a WebSocket cleanup issue [ID 41560]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Due to a WebSocket cleanup issue, in some rare cases, client applications would incorrectly not receive any new events.

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

#### Dashboards/Low-Code Apps - Table component: 'Refresh' button would not work when the GQI query session had expired [ID 41679]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

Up to now, when another page of partial table data was loaded into a *Table* component after the GQI query session had expired, the following could happen:

- If WebSockets were enabled, a `Session does not exist` error would appear.

- If WebSockets were disabled, a *Refresh* button would appear, but clicking it would not have any effect.

From now on, when another page of partial table data is loaded into a *Table* component after the GQI query session has expired, a *Refresh* button will appear, and clicking it will cause a new GQI query session to be started.

#### Low-Code Apps: Problem when adding an 'Execute a script' action to a low-code app that was hosted on a dashboard gateway [ID 41697]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When you tried to add an *Execute a script* action to a low-code app that was hosted on a dashboard gateway, an error could be thrown due to a serialization issue.

#### Low-Code Apps: Script running in an IAS component would not look identical to a script running in a pop-up window [ID 41759]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, an interactive Automation script running in an *Interactive Automation script* component would incorrectly not look identical to a script running in a pop-up window.

#### Low-Code Apps: Flows could get triggered too often [ID 41768]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, in low-code apps, flows could get triggered too often. As a result, queries that consumed those flows would refetch data more frequently then needed.

#### Low-Code Apps: Panel selection box would incorrectly be displayed when configuring a 'Close all panels' action [ID 41779]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

When, in the action editor, you were configuring a *Close all panels* action, a panel selection box would incorrectly be displayed.

#### Low-Code Apps: Additional page would incorrectly be added after a reload or after a new draft had been created [ID 41787]

<!-- MR 10.4.0 [CU11] - FR 10.5.2 -->

In some cases, an additional page would incorrectly be added to a low-code app after a reload or after a new draft had been created.
