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

#### DataMiner web apps: Angular and other dependencies have been upgraded [ID_36977]

<!-- MR 10.4.0 - FR 10.3.10 -->

In all web apps (e.g. Low-Code Apps, Dashboards, Monitoring, Jobs, Ticketing, etc.), Angular and other dependencies have been upgraded.

#### Security enhancements [ID_37047] [ID_37051] [ID_37068] [ID_37086]

<!-- RN 37047/37051/37068: MR 10.4.0 - FR 10.3.10 -->
<!-- RN 37086: MR 10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

#### Dashboard sharing: Any API call that depends on a query feed will now be allowed if the data that is fed is considered valid [ID_37091]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when data from a GQI query was fed to another component on a dashboard, some API calls would not be allowed when that dashboard was shared. From now on, any API call that depends on a query feed will be allowed if the data that is fed is considered valid.

> [!NOTE]
> When you share a dashboard that feeds GQI results to another component, a warning will still appear. The API calls may still allow more than the creator of the dashboard intended.

### Fixes

#### Dashboards app/Low-Code Apps: Error when data source contained cells with NaN value [ID_36923]

<!-- MR 10.2.0 [CU19]/MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a data source contained cells with the value "NaN", an error message was shown in the Dashboards app or Low-Code Apps.

This has been fixed. The display value will remain "NaN", but the raw value will now be null.

#### Dashboards app/Low-Code Apps: Changing query column while it was loading made it stop loading [ID_37006]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, if a column of a query was edited while the query was loading in a table component of a dashboard or low-code app, it would stop loading, and an empty table would temporarily be shown.

#### Low-Code Apps: DOM GenericEnumFieldDescriptors would not be sorted as specified in the DomDefinition [ID_37007]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, in *Form* components, DOM GenericEnumFieldDescriptors would be sorted alphabetically. The order that was specified in the DomDefinition would be disregarded.

From now on, DOM GenericEnumFieldDescriptors will always be sorted as specified in the DomDefinition.

#### DataMiner web apps: Date/time picker issues [ID_37041]

<!-- MR 10.4.0 - FR 10.3.10 -->

A number of date/time picker issues have been fixed.

#### Dashboards app/Low-Code Apps: Visual glitch when closing component menu [ID_37058]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the menu of a component in a dashboard or low-code app was closed by moving the mouse pointer out of it at the bottom center, a visual glitch could occur where the menu appeared to rapidly open and close.

#### Dashboards app/Low-Code Apps - Line chart component: Viewport would change upon receiving data [ID_37065]

<!-- MR 10.4.0 - FR 10.3.10 -->

When a *Line chart* component received new data, it would incorrectly recalculate its viewport.

#### Dashboards app/Low-Code Apps: Query filter not applied on sorted table [ID_37070]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- Not added in 10.4.0: fixes a feature introduced in that version -->

In a dashboard or low-code app, if sorting was applied to one or more columns of a table, it could occur that a query filter could not be correctly applied on the table, so that the unfiltered result was shown instead.

#### Dashboards app: 'Copy embed URL' right-click option continued to be displayed [ID_37090]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the *Copy embed URL* right-click option of a dashboard component continued to be displayed when it should not have been. This specifically occurred when you moved or resized the component or when you closed and reopened edit mode while the option was displayed.

#### Monitoring app: Filtered combo box control not shown correctly in Visual Overview [ID_37107]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In the Monitoring app, it could occur that Visual Overview parameter control shapes configured to show a filtered combo box control (i.e. with *SetVarOptions* set to *Control=FilterComboBox*) were not displayed correctly.

#### GQI: Missing column statistics for discrete options of numeric columns [ID_37111]

<!-- MR 10.4.0 - FR 10.3.10 -->

When the web API fetched information for columns of a GQI query, it could occur that not all statistics were included. In the Dashboards app/Low-Code Apps, this could lead to incorrect "(0)" counters next to the discrete options of numeric columns in the query filter when the filter assistance option was enabled.

#### Low-Code Apps: Time range component overlay not fully displayed [ID_37118]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you click a time range component in a low-code app, an overlay is displayed where you can select a time range. In some cases, it could occur that part of this overlay could not be displayed.

#### Low-Code Apps: No longer possible to deny specific users access to low-code apps when using SAML authentication [ID_37125]

<!-- MR 10.4.0 - FR 10.3.10 -->

When using external user authentication via SAML, it was no longer possible to deny specific users access to low-code apps.

#### Low-Code Apps: 'View published app' option still present in user menu after publishing an app [ID_37129]

<!-- MR 10.4.0 - FR 10.3.10 -->

After you had published an app, the *View published app* option would still be present in the app's user menu. From now on, this option will no longer be present in the user menu of published apps.

#### Low-Code Apps: Editing a published app with an existing draft would incorrectly create a new draft [ID_37194]

<!-- MR 10.2.0 [CU19] - FR 10.3.10 -->

Up to now, when you edited a published app that had a draft, a new draft would incorrectly be created. From now on, when you edit an app that has a draft, that existing draft will be opened.

#### Dashboards app/Low-Code Apps: Label of 'Icon' setting of 'Icon' component would incorrectly be in lower case [ID_37199]

<!-- MR 10.4.0 - FR 10.3.10 -->

The label of the *Icon* setting of an *Icon* component would incorrectly be in lower case. It is now in upper case.

#### Low-Code Apps: Problem when two State components were fed the same query row data with a column filter applied [ID_37206]

<!-- MR 10.4.0 - FR 10.3.10 -->

When two *State* components were fed the same query row data and had a column filter applied, the app would become unresponsive.
