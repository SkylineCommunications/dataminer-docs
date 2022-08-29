---
uid: General_Main_Release_10.2.0_CU7
---

# General Main Release 10.2.0 CU7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

### Enhancements

#### DataMiner Taskbar Utility: Enhanced installation of app packages [ID_33969]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

Using the DataMiner Taskbar Utility, it is now possible to install all possible types of app packages. To install an app, you can either double-click the .dmapp file or right-click the Taskbar Utility icon, click *Update* and select the app from the list.

Also, the *SLAppPackageInstaller.txt* log file will now keep track of all actions performed and issues encountered during the installation of an app.

#### Enhanced performance when an SNMP element using multi-threaded timers is polling multiple sources simultaneously [ID_34143]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

Because of a number of enhancements, overall performance has increased when an SNMP element using multi-threaded timers is polling multiple sources simultaneously.

#### Edge WebView2 now preferred when SAML authentication is used [ID_34162]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When SAML authentication is used, Cube will now try to use the Edge WebView2 browser engine instead of CefSharp. It will only fall back to using CefSharp if WebView2 is not available.

This will prevent the following possible issues:

- The CefSharp browser engine version used by Cube is not updated frequently and therefore not always trusted by certain SAML identity provider websites, such as Microsoft Azure. This can cause a lengthy authentication procedure, even if the browser cache is enabled.
- The CefSharp browser engine needs to be downloaded from the DMA before a first authentication (on a new device). However, this is currently not supported for HTTPS-only setups.

#### Cassandra: Alarms indicating that the cluster is down will no longer be repeated as long as the status of the cluster remains the same [ID_34209]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When the Cassandra database was down, up to now, the alarms indicating that the cluster is not in a healthy state would be repeated every 40 seconds. From now on, those alarms will no longer be repeated as long as the status of the cluster remains the same.

#### Enhanced logging of issues occurring when parsing a compliance cache file entry [ID_34212]

<!-- Main Release Version 10.0.0 [CU22]/10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When an issue occurred when parsing a compliance cache file entry, up to now, a log entry of type "error" would be added to the SLDataMiner.txt log file.

From now on, when an issue occurs when parsing a compliance cache file entry, the following log entry of type "info" will be added to the SLDataMiner.txt log file instead:

```txt
Warning: <function> is unable to parse compliance cache file entry at line <line number>. <line content>
```

### Fixes

#### Problem with SLAnalytics [ID_33850]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

In some cases, a problem could occur with the SLAnalytics process, causing the process to restart. This happened when the alarm repository was retrieved while the connection was being dropped.

#### Jobs app: Corrected start time saved incorrectly [ID_34043]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When, after receiving a message that it was not possible to save a job because of an invalid start time, you corrected the start time and tried to save the job again, that start time would get saved incorrectly.

#### DataMiner web apps / Visual Overview: Trending not displayed or displayed with incorrect coloring [ID_34101]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.9 -->

If a visual overview was viewed in the web apps (e.g. the Monitoring or Dashboards app), it could occur that trend graphs in that visual overview were not displayed.
In addition, the coloring of the trend lines could be incorrect. Instead of the colors defined in the themes, the lines were shown in black.

#### Service & Resource Management: Files in C:\Skyline DataMiner\ResourceManager would not be locked properly when being read or updated during a midnight synchronization [ID_34104]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

Up to now, the files stored in the `C:\Skyline DataMiner\ResourceManager` folder would not be locked properly when being read or updated during a midnight synchronization. File locking has now been improved.

#### Visual Overview: SurveyorSearchText variable continued to show cleared search input [ID_34114]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When the text in the Cube advanced search box was selected with Ctrl+A and then deleted, it could occur that the advanced search input was not cleared correctly, so that it continued to be shown by the *SurveyorSearchText* variable in Visual Overview.

#### Web apps - DOM: Sections inheriting from a parent behavior definition would not be taken into account when displaying a form [ID_34125]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, a DOM definition containing a behavior definition with inheritance enabled was used in a web app form, any sections inheriting from that parent behavior definition would not be taken into account when displaying that form.

#### SLNet could throw an OutOfMemoryException due to a memory leak [ID_34126]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

In some cases, SLNet could throw an OutOfMemoryException due to a memory leak.

#### Visual Overview: Connection highlight based on connection property not updated automatically [ID_34139]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.9 -->

When a connection in Visual Overview was highlighted based on a connection property, and the connection property changed, it could occur that the highlight style was not automatically applied to the connection line, but only after the user triggered a redraw, for example by clicking the highlight.

#### Automation: Invalid script changes would incorrectly be saved [ID_34150]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, in the *Automation* app, you made an invalid change in a script, closed the app and clicked *Yes* to confirm the changes, up to now, the invalid changes you made would incorrectly be saved. If the invalid change was an invalid script name change, then the script would even be deleted. From now on, it will only be possible to save valid changes.

#### DataMiner Cube - Alarm Console: Alarms would incorrectly be grouped when the 'Automatically group according to arrangement' was not selected [ID_34153]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, in the hamburger button in the top-left corner of the Alarm Console, the *Automatically group according to arrangement* setting was not selected, upon reconnecting DataMiner Cube, the alarms would incorrectly be grouped anyway.

#### Scheduled alarm templates would incorrectly not be updated when the system time changed [ID_34154]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When the system time changed because of e.g. a clock resynchronization or a switch to or from daylight-saving time, up to now, the start time and end time of scheduled alarm templates would incorrectly not get updated.

#### GQI: 'Bookings' data source incorrectly contained two 'Last modified at' columns [ID_34170]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

The GQI data source "Bookings" did not contain a *Last modified by* column and contained two different *Last modified at* columns (one with timestamps adjusted to the timezone and another with unadjusted timestamps). The *Last modified at* column containing unadjusted timestamps has now been replaced by a *Last modified by* column.

Also, the *Created at* and *Last modified at* columns will no longer be selected by default.

#### Dashboards app: Problem when trying to access a shared dashboard created in a previous version [ID_34210]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When you tried to access a shared dashboard created in a previous version, the migration of the dashboard would get stuck because the Web API was unable to write the current Dashboards app version to the `C:\Skyline DataMiner\WebPages\dashboard\appversion.json` file.

#### DataMiner Cube - Services app: No services would be loaded the first time you opened the Services app [ID_34211]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When you opened the *Services* app for the first time after opening DataMiner Cube, in some cases, no services would be loaded. The services would only be loaded when you closed the *Services* app and opened it again.

#### Web apps: App would incorrectly log in again after the user had logged out [ID_34227]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

After a user had logged out of a web app, in some cases, that app would incorrectly continue to send out network requests and try to automatically log itself in again.
