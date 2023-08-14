---
uid: Web_apps_Feature_Release_10.3.10
---

# DataMiner web apps Feature Release 10.3.10 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.10](xref:General_Feature_Release_10.3.10).

## Highlights

*No highlights have been added to this release yet.*

## Other features

*No other features have been added to this release yet.*

## Changes

### Enhancements

#### Legacy Monitoring & Control app no longer available [ID_36953]

<!-- MR 10.4.0 - FR 10.3.10 -->

The legacy Monitoring & Control app (obsolete since DataMiner 10.0.0/10.0.2) is no longer available. If you browse to `http(s)://[DMA]/m`, you will now be redirected to the regular Monitoring app.

#### Security enhancements [ID_37051] [ID_37086]

<!-- MR 10.3.0 [CU7]/10.4.0 - FR 10.3.10 -->

A number of security enhancements have been made.

### Fixes

#### Dashboards app/Low-Code Apps: Error when data source contained cells with NaN value [ID_36923]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, when a data source contained cells with the value "NaN", an error message was shown in the Dashboards app or Low-Code Apps.

This has been fixed. The display value will remain "NaN", but the raw value will now be null.

#### Dashboards app/Low-Code Apps: Changing query column while it was loading made it stop loading [ID_37006]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, if a column of a query was edited while the query was loading in a table component of a dashboard or low-code app, it would stop loading, and an empty table would temporarily be shown.

#### Dashboards app/Low-Code Apps: Visual glitch when closing component menu [ID_37058]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the menu of a component in a dashboard or low-code app was closed by moving the mouse pointer out of it at the bottom center, a visual glitch could occur where the menu appeared to rapidly open and close.

#### Dashboards app/Low-Code Apps: Query filter not applied on sorted table [ID_37070]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- Not added in 10.4.0: fixes a feature introduced in that version -->

In a dashboard or low-code app, if sorting was applied to one or more columns of a table, it could occur that a query filter could not be correctly applied on the table, so that the unfiltered result was shown instead.

#### Monitoring app: Filtered combo box control not shown correctly in Visual Overview [ID_37107]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In the Monitoring app, it could occur that Visual Overview parameter control shapes configured to show a filtered combo box control (i.e. with *SetVarOptions* set to *Control=FilterComboBox*) were not displayed correctly.

#### GQI: Missing column statistics for discrete options of numeric columns [ID_37111]

<!-- MR 10.4.0 - FR 10.3.10 -->

When the web API fetched information for columns of a GQI query, it could occur that not all statistics were included. In the Dashboards app/Low-Code Apps, this could lead to incorrect "(0)" counters next to the discrete options of numeric columns in the query filter when the filter assistance option was enabled.
