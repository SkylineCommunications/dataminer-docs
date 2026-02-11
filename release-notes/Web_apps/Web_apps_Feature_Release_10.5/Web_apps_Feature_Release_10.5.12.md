---
uid: Web_apps_Feature_Release_10.5.12
---

# DataMiner web apps Feature Release 10.5.12

This Feature Release of the DataMiner web applications contains the same new features, enhancements, and fixes as DataMiner web apps Main Release 10.4.0 [CU21] and 10.5.0 [CU9].

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.5.12](xref:General_Feature_Release_10.5.12).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.5.12](xref:Cube_Feature_Release_10.5.12).

## Highlights

- [Dashboards/Low-Code Apps: GQI queries can now be exported as JSON files [ID 43800]](#dashboardslow-code-apps-gqi-queries-can-now-be-exported-as-json-files-id-43800)
- [New GQI data source: Get relational anomalies [ID 43820]](#new-gqi-data-source-get-relational-anomalies-id-43820)
- Breaking change: [Dashboards/Low-Code Apps: HTML code on read-only DOM forms will no longer be interpreted [ID 43864]](#dashboardslow-code-apps-html-code-on-read-only-dom-forms-will-no-longer-be-interpreted-id-43864)

## New features

#### Dashboards/Low-Code Apps: GQI queries can now be exported as JSON files [ID 43800]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When in edit mode, it is now possible to directly export a GQI query to a JSON file. To do so, click the ellipsis button ("...") next to the query in the *Data* pane and select *Export*.

Up to now, when you wanted to export a GQI query to a JSON file (e.g. to have it executed by the *Data Aggregator* module), you had to open the developer tools of your browser, copy the query from the request payload, and convert the query using the *ConvertQueryToProtoJson* web method.

#### Web apps: New 'User settings' window allows users to change their password [ID 43803]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In the user menu of each DataMiner web app, you can now find a new *User settings* item. Clicking that item will open a window that allows you to change your password.

For a user to be able to see and click this new menu item, the following conditions must be met:

- In *System Center > Users*, the user's *User cannot change password* setting must be disabled.
- The user must have *Modules > System configuration > Security > Specific > Limited administrator* permission.
- The user must not be logged in with external or delegated authentication.

#### New GQI data source: Get relational anomalies [ID 43820]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

In the Generic Query Interface, a new *Get relational anomalies* data source is now available. It will return all relational anomalies in the DMS.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.6.0/10.5.12 or newer.

#### Interactive automation scripts executed in a web app: UI version can now be set in the script [ID 43964]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when you wanted an interactive automation script executed in a web app to use the new UI version, you had to add `useNewIASInputComponents=true` to the URL of the app.

From now on, it is also possible to indicate the UI version in the script itself. To do so, set the `engine.WebUIVersion` property to one of the following values:

| Value | UI version |
|-------|------------|
| WebUIVersion.Default | Default UI version. At present, this is V1. |
| WebUIVersion.V1      | Current UI version (V1) |
| WebUIVersion.V2      | New UI version (V2)     |

Example:

```csharp
engine.WebUIVersion = WebUIVersion.V2
```

The URL parameter `useNewIASInputComponents` has priority over the UI version set in the script.

- If you use `useNewIASInputComponents=true`, the script will use the new UI version (i.e. V2), even when V1 was set in the script.
- If you use `useNewIASInputComponents=false`, the script will use the current UI version (i.e. V1), even when V2 was set in the script.

> [!IMPORTANT]
>
> - This feature is only supported for interactive automation scripts executed in web apps. It is not supported for interactive automation scripts executed in DataMiner Cube.
> - This feature will only work in conjunction with DataMiner server version 10.6.0/10.5.12 or newer.

## Changes

### Breaking changes

#### Dashboards/Low-Code Apps: HTML code on read-only DOM forms will no longer be interpreted [ID 43864]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when a *Form* component was displayed in read-only mode, all content written in HTML code would be interpreted as such. However, this had a number of unwanted side effects:

- All HTML code that had to be displayed as code had to be escaped to prevent it from being interpreted.
- Text between chevrons (e.g. `<a piece of text between chevrons>`) was not displayed as it could potentially contain unsafe content.
- etc.

From now on, when set to read-only, a *Form* component will display all HTML code as code. For example, a value like `<b>Text</b>` will now always be displayed as "\<b\>Text\</b\>" instead of "**Text**".

In situations where HTML code needs to be interpreted, you will need to use a *Grid* component with a GQI query.

### Enhancements

#### Dashboards/Low-Code Apps: Elements will now be lazy-loaded when configuring components [ID 43814]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In edit mode, up to now, when you made a configuration that involved element data, one operation would retrieve the first 10000 elements. The rest of the elements would not be displayed.

From now on, the first 100 elements will initially be retrieved. Afterwards, when you then scroll down, the next 100 elements will be retrieved each time you reach the bottom of the list.

#### Dashboards app: PDF reports can now be generated in landscape mode [ID 43826]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When you configure a PDF report, you can now select the *Landscape* setting to indicate that the report should be generated in landscape mode.

#### DataMiner Comparison tool: Redesigned header [ID 43837]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

The header of the DataMiner Comparison tool has been redesigned.

- When you click the DataMiner logo, you will be redirected to the DataMiner landing page (by default accessible via `https://<DMA IP or hostname>/root`).
- When you click the app title (i.e. "Comparison"), the app's URL will be cleared of any settings that were added to it.

#### Dashboards app: Email reports can now also be sent to recipients who are not contacts and who are only specified in the CC and/or BCC fields [ID 43848]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, an email report could only be sent if recipients were specified in the *To* field. Also, those recipients had to be people in your contact list.

From now on, recipients no longer have to be contacts, and it will also be possible to send email reports that only have recipients specified in the *CC* and/or *BCC* fields.

> [!IMPORTANT]
> This feature will only work in conjunction with DataMiner server version 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12 or newer.

#### Dashboards/Low-Code Apps - Grid component: 'Grid template' section replaced by 'Grid layout' section [ID 43889]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When editing a grid component, up to now, the *Advanced > Grid template* section of the *Layout* pane allowed you to configure the number of columns and rows displayed in the component and choose how items scale within the available space. Now, that *Grid template* section has been replaced by the *Layout > Grid layout* section, which contains the following settings:

- **Columns**

  | Setting | Description |
  |---|---|
  | Fixed column count   | Disable this setting to have all columns displayed, or enable this setting to have the fixed number of columns specified in *Columns* displayed. |
  | Columns              | If *Fixed column count* is enabled, then, in this box, specify the number of columns to be displayed. |
  | Stretch to fit       | Enable this setting to have the cells scaled dynamically to fit the grid. |
  | Stretch mode         | If *Stretch to fit* is enabled, then set *Stretch mode* to either "Fit" or "Limit":<br>- Fit: Try to fit as many items as possible.<br>- Limit: Enlarge or reduce the items according to the template dimensions. |
  | Horizontal scroll    | Enable this setting if you want a horizontal scrollbar to be displayed.<br>When this setting is disabled, text in the cells will either wrap or be clipped, depending on the other settings. When a fixed number of columns are displayed, text in the cells will not wrap. |

- **Rows**

  | Setting | Description |
  |---|---|
  | Fixed row count   | Disable this setting to have all rows displayed, or enable this setting to have the fixed number of rows specified in *Rows* displayed. |
  | Rows              | In this box, specify the number of rows to be displayed when *Fixed row count* is enabled. |
  | Stretch to fit    | Enable this setting to have the cells scaled dynamically to fit the grid. |
  | Stretch mode      | If *Stretch to fit* is enabled, then set *Stretch mode* to either "Fit" or "Limit":<br>- Fit: Try to fit as many items as possible.<br>- Limit: Enlarge or reduce the items according to the template dimensions. |
  | Vertical scroll   | Enable this setting if you want a vertical scrollbar to be displayed.<br>When this setting is disabled, text in the cells will either wrap or be clipped, depending on the other settings. When a fixed number of rows are displayed, text in the cells will not wrap. |

> [!NOTE]
> By default, newly created grids will have *Stretch to fit* enabled and *Stretch mode* set to "Limit" for columns, and *Vertical scroll* enabled for rows.

#### Automatic backups of web apps will no longer include all versions [ID 43906]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

From DataMiner 10.3.11/10.3.0 [CU8] onwards, whenever you upgrade a DMA or install a DataMiner web upgrade, an automatic backup of all existing dashboards and low-code apps on the system is generated and stored in `C:\Skyline DataMiner\System Cache\Web\Backups`.

Up to now, that backup would include all app versions. From now on, to enable faster backups, it will only include up to two versions per app: the last version that was published and the most recent draft. The version history will be left untouched.

> [!NOTE]
>
> - When the `App.info.json` file of an app is present and valid, but a version cannot be found, a warning will be displayed, and the app will be included in the backup.
> - When the `App.info.json` file of an app is not present or invalid, or if the published and draft versions are set to null in that file, a warning will be displayed, and the app will not be included in the backup.

#### DataMiner landing page: Settings icon and 'System home settings' menu have been removed from the header bar [ID 43966]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

On the DataMiner landing page (by default accessible via `https://<DMA IP or hostname>/root`), the settings icon and the *System home settings* menu have now been removed from the header bar.

- The *Show draft applications* option has been moved to the apps section, next to the search bar.
- The *Theme* option\* has been moved to the *User settings* window.

\**The Theme option is only visible when you added `showAdvancedSettings=true` to the URL of the landing page.*

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

#### Dashboards/Low-Code Apps: Problem when applying a time range when using the 'Get behavioral change events' or 'Get pattern occurrence events' data sources [ID 43821]

<!-- MR 10.5.0 [CU9] - FR 10.5.12 -->

When, in e.g. a Table component, a specific time range was applied when listing behavioral changes or pattern occurrences using the *Get behavioral change events* or *Get pattern occurrence events* data sources, in some cases, an error message could appear, saying that the time range was not in UTC format. Also, the time range would not be displayed correctly.

#### Dashboards/Low-Code Apps - Time range component: Problem when scheduling the PDF generation of dashboard reports using a relative timespan [ID 43828]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When the *Time range* component had been used to schedule the PDF generation of dashboard reports, the reports would not be generated at the correct time when a relative timespan (e.g. "Today so far") had been specified. Instead of the relative timespan, the system would incorrectly use a fixed timespan based on the moment at which the time range had been configured.

#### Low-Code Apps: Problem when importing and exporting low-code apps [ID 43833]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, when you imported a newer version of a low-code app, its version history would not be updated correctly.

Also, when you exported a low-code app, the version list in the export package would incorrectly include all versions of the app. From now on, the version list will only include the version you exported.

#### Low-Code Apps: Users without 'View dashboards' permission would not be allowed to view or edit a low-code app via a dashboard gateway [ID 43846]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, users without the *Modules > Reports & Dashboards > Dashboards > View dashboards* permission would incorrectly not be allowed to view or edit a low-code app via a dashboard gateway.

#### Low-Code Apps: Problems when using a dashboard gateway setup because of an incorrect user permissions check [ID 43879]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

On a dashboard gateway setup, certain calls would not work because of an incorrect user permissions check.

- The following calls would not work when users did not have the *Modules > Reports & Dashboards > Dashboards > Edit* permission. From now on, these calls will require users to have either the *Modules > Reports & Dashboards > Dashboards > Edit* permission or the *Modules > User-definable apps > Edit* permission.

  - AddDashboardTheme
  - UpdateComponent
  - UpdateDashboard
  - UpdateDashboardTheme
  - UploadImage

- The following calls would not work when users did not have the *Modules > Reports & Dashboards > Dashboards > View dashboards* permission. From now on, these calls will require users to have either the *Modules > Reports & Dashboards > Dashboards > View dashboards* permission or the *Modules > User-definable apps > View apps* permission.

  - GetDashboardThemes
  - GetImageByName
  - GetImages
  - ObserveDashboardChanges

Also, the ShareDashboard call did incorrectly not require users to have the *General > Live sharing > Share* permission.

#### Dashboards app: Multiple error messages would appear when you were editing a dashboard when another user was also editing it [ID 43928]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When, for example, you were editing a dashboard that another user was also editing at the same time, up to now, a series of error messages could start to appear. From now on, only one error message will appear.

As simultaneous dashboard editing is not supported, any errors that appear will not be added to the Cube logging.

#### Dashboards/Low-Code Apps - Table component: 'Is selected' template override would only be applied correctly for the first 50 rows [ID 43937]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

Up to now, in a *Table* component, the *Is selected* template override would only be applied correctly for the first 50 rows.

#### Dashboards/Low-Code Apps - Time range component: Problem with relative time span when linked to a Trigger component [ID 43968]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When, in a dashboard or a low-code app, a *Time range* component had a relative time span set (e.g. "Today so far") and was linked to a *Trigger* component, up to now, the *Time range* component would incorrectly no longer update its relative time span when the *Trigger* component ordered it to do so after a reload of the dashboard or a page switch in the low-code app.

#### Problem with embedded VLC player [ID 43973]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In client applications like DataMiner Cube, the embedded VLC player would no longer work.

#### DataMiner web apps authentication page: Header could keep on loading indefinitely [ID 43978]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

In some cases, the header of the DataMiner web apps authentication page would keep on loading indefinitely.

#### Web apps: Scrollbar would not always appear when you hovered the mouse pointer over a scrollable container [ID 43996]

<!-- MR 10.4.0 [CU21] / 10.5.0 [CU9] - FR 10.5.12 -->

When a DataMiner web app contains a scrollable container, a scrollbar should be shown when the user hovers the mouse pointer over that container. However, after a Chrome upgrade to version 139 or higher, this behavior was no longer consistent.

#### Web apps: Message that indicates that the WebSocket connection was dropped would incorrectly appear when no WebSocket connection had been made [ID 44047]

<!-- MR 10.4.0 [CU20] / 10.5.0 [CU8] - FR 10.5.11 -->

In some cases, a `Connection has been interrupted.` message would incorrectly appear when no WebSocket connection had been made.

From now on, this message will only appear when an attempt to re-establish a WebSocket connection has failed.
