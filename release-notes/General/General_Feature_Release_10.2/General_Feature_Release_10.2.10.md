---
uid: General_Feature_Release_10.2.10
---

# General Feature Release 10.2.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.10](xref:Cube_Feature_Release_10.2.10).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No new features have been added to this release yet*

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

#### SLNet could throw an OutOfMemoryException due to a memory leak [ID_34126]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

In some cases, SLNet could throw an OutOfMemoryException due to a memory leak.

#### Scheduled alarm templates would incorrectly not be updated when the system time changed [ID_34154]

<!-- Main Release Version 10.1.0 [CU19]/10.2.0 [CU7] - Feature Release Version 10.2.10 -->

When the system time changed because of e.g. a clock resynchronization or a switch to or from daylight-saving time, up to now, the start time and end time of scheduled alarm templates would incorrectly not get updated.
