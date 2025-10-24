---
uid: KI_Scrollbars_not_shown_in_web_apps
---

# Scrollbars not shown in web apps

## Affected versions

DataMiner web apps on Chrome version 139 or higher.

## Cause

Chrome version 139 introduced an issue affecting scrollbar behavior across web apps.

## Fix

Install DataMiner web 10.4.0 [CU21]/10.5.0 [CU9]/10.5.12.<!-- RN 43996 --> This will cause scrollbars to always be shown for scrollable containers.

Note that a full DataMiner upgrade is not required for this fix; [installing a web upgrade](xref:Upgrading_Downgrading_Webapps) is sufficient.

## Description

When a DataMiner web app contains a scrollable container, a scrollbar should be shown when the user hovers the mouse pointer over that container. However, after a Chrome upgrade to version 139 or higher, this behavior is no longer consistent.
