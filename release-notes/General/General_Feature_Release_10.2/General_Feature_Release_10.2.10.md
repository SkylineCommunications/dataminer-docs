---
uid: General_Feature_Release_10.2.10
---

# General Feature Release 10.2.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.10](xref:Cube_Feature_Release_10.2.10).

## Highlights

#### Clearing an incident now clears any clearable base alarms it contains [ID_34112]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->

If an incident (also known as an alarm group) is cleared manually, any clearable base alarms of that incident will now also be cleared. This way, this behavior is consistent with the standard behavior for Correlation alarms.

## Other features

#### Dashboards / Low-Code Apps: Checkboxes to select discrete values in column filter Table component [ID_34234]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.9 -->

When you configure a column filter for a Table component in a dashboard or low-code app, you can now select checkboxes to filter on discrete values.

## Changes

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

#### Dashboards app / Low-Code apps: Conditional coloring layout configuration now uses numeric filter instead of numeric slider [ID_34174]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, the numeric slider control has been replaced with a numeric filter. This has the following advantages:

- Full control over the boundaries. You can indicate whether the start and end should be in- or excluded.
- Possibility to not have a start or end boundary.
- More consistent with the free text filter.
- Easier to define a precise filter.

#### Dashboards app / Low-Code apps: Conditional coloring layout filter configuration now shows discrete column values [ID_34182]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.10 -->
<!-- Part of this RN is still in soft launch and consequently has not been documented yet -->

In the conditional coloring layout setting for Table and Node edge components, discrete column values will now be displayed to make it easier to configure a filter.

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

#### Service & Resource Management: Files in C:\Skyline DataMiner\ResourceManager would not be locked properly when being read or updated during a midnight synchronization [ID_34104]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

Up to now, the files stored in the `C:\Skyline DataMiner\ResourceManager` folder would not be locked properly when being read or updated during a midnight synchronization. File locking has now been improved.

#### Web apps - DOM: Sections inheriting from a parent behavior definition would not be taken into account when displaying a form [ID_34125]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, a DOM definition containing a behavior definition with inheritance enabled was used in a web app form, any sections inheriting from that parent behavior definition would not be taken into account when displaying that form.

#### SLNet could throw an OutOfMemoryException due to a memory leak [ID_34126]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

In some cases, SLNet could throw an OutOfMemoryException due to a memory leak.

#### Automation: Invalid script changes would incorrectly be saved [ID_34150]

<!-- Main Release Version 10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When, in the *Automation* app, you made an invalid change in a script, closed the app and clicked *Yes* to confirm the changes, up to now, the invalid changes you made would incorrectly be saved. If the invalid change was an invalid script name change, then the script would even be deleted. From now on, it will only be possible to save valid changes.

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

#### Web apps: App would incorrectly log in again after the user had logged out [ID_34227]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

After a user had logged out of a web app, in some cases, that app would incorrectly continue to send out network requests and try to automatically log itself in again.
