---
uid: EPM_6.1.2_D-DOCSIS
---

# EPM 6.1.2 D-DOCSIS

## New features

#### Table cell navigation to EPM objects \[ID_33037\]

In the CM, Utilization and RPD Association tables, you can now click table cells to navigate to the visual pages of the linked EPM objects.

## Changes

### Enhancements

#### Access to collector data pages restricted to Administrator user \[ID_33018\]

To improve performance, now only the Administrator user can access the data pages for collector elements. All the data users need is exposed on the visual pages instead.

#### Enhancements to Skyline CCAP Platform WM connector \[ID_33020\]

To prevent redundant requests from collectors and reduce the load on the system, the Skyline CCAP Platform WM connector will now also export a file even when no data was found to satisfy a request. In addition, a startup check has been added so that, in case a problem occurred with the element, it will automatically start up to handle requests.

#### Improved filtering of CM tables \[ID_33038\]

The way column filters are applied to the CM tables has been improved, so that the pages are now updated and condensed after the filters have been applied. Previously, the client side filtering caused all the pages to be displayed, sometimes containing few or even no rows.

#### Trace Route pop-up window now resizable \[ID_33230\]

The Trace Route pop-up window can now be resized and minimized or maximized.

#### Cox Ceeview Platform: New Max RPDs Request Limit parameter \[ID_33250\]

A new parameter, *Max RPDs Request Limit*, has been added to the *Polling Config* page of the Cox Ceeview Platform connector, so that it is possible to limit the number of RPDs requested.

### Fixes

#### Incorrect RPD filtering in dashboard \[ID_33229\]

When RPD data were fed to a dashboard via the dashboard URL, it could occur that the EPM feed was not filtered correctly.
