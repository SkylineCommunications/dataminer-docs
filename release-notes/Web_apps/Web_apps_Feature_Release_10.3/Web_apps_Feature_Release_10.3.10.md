---
uid: Web_apps_Feature_Release_10.3.10
---

# DataMiner web apps Feature Release 10.3.10

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.3.10](xref:General_Feature_Release_10.3.10).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.3.10](xref:Cube_Feature_Release_10.3.10).

## Highlights

- [Dashboards app & Low-Code Apps: New Stepper component [ID 37200]](#dashboards-app--low-code-apps-new-stepper-component-id-37200)

## New features

#### Dashboards app & Low-Code Apps - GQI: Table visualizations now support real-time query updates [ID 36789]

<!-- MR 10.4.0 - FR 10.3.10 -->

Table visualizations now support real-time GQI query updates.

A table visualization will now immediately show the updated values if the *Update data* option is enabled in the table component settings.

> [!NOTE]
> Real-time updates only work when supported by the data source used in the query.

#### Dashboards app & Low-Code Apps - Time range component: Presets [ID 37050]

<!-- MR 10.4.0 - FR 10.3.10 -->

When configuring a *Time range* component, you can now find a new *Presets* section in the *Layout* tab. This section allows you to define the presets that will be available to users who open a *Time range* feed.

The list of presets will also include three new presets (each with a corresponding quick pick option):

- *Starting from now*
- *Near future*
- *Distant future*

In addition, other settings found on the *Layout* tab have been rearranged. The alignment and visibility settings have now been moved to a new *Layout* section, and the order of the quick pick options has been changed.

#### Dashboards app & Low-Code Apps: New Stepper component [ID 37200]

<!-- MR 10.4.0 - FR 10.3.10 -->

A new *Stepper* component is now available. This component is used to guide the user through a workflow by splitting it up into different numbered or labeled steps. It indicates the progress through the workflow by showing the past steps, current step, and future steps. The component uses a stateful DOM instance or DOM definition (i.e., a DOM instance or DOM definition that contains states) as data input.

For more information on how to configure this component, see [Stepper](xref:DashboardStepper).

## Changes

### Enhancements

#### Legacy Monitoring & Control app no longer available [ID 36953]

<!-- MR 10.4.0 - FR 10.3.10 -->

The legacy Monitoring & Control app (obsolete since DataMiner 10.0.0/10.0.2) is no longer available. If you browse to `http(s)://[DMA]/m`, you will now be redirected to the regular Monitoring app.

#### DataMiner web apps: Angular and other dependencies have been upgraded [ID 36977]

<!-- MR 10.4.0 - FR 10.3.10 -->

In all web apps (e.g., Low-Code Apps, Dashboards, Monitoring, Jobs, Ticketing, etc.), Angular and other dependencies have been upgraded.

#### Security enhancements [ID 37047] [ID 37051] [ID 37068] [ID 37086]

<!-- RN 37047/37051/37068: MR 10.4.0 - FR 10.3.10 -->
<!-- RN 37086: MR 10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

#### Dashboard sharing: Any API call that depends on a query feed will now be allowed if the data that is fed is considered valid [ID 37091]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when data from a GQI query was fed to another component on a dashboard, some API calls would not be allowed when that dashboard was shared. From now on, any API call that depends on a query feed will be allowed if the data that is fed is considered valid.

> [!NOTE]
> When you share a dashboard that feeds GQI results to another component, a warning will still appear. The API calls may still allow more than the creator of the dashboard intended.

#### Dashboards app/Low-Code Apps - Table component: Height of a column resizer has been reduced to that of the column header [ID 37226]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, a column resizer would span across the entire height of the column. From now on, the height of a column resizer will be equal to the height of the column header.

Note that, while you dragging a resizer, its height will be equal to that of the entire column you are resizing.

### Fixes

#### Dashboards app/Low-Code Apps: Error when data source contained cells with NaN value [ID 36923]

<!-- MR 10.2.0 [CU19]/MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a data source contained cells with the value "NaN", an error message was shown in the Dashboards app or Low-Code Apps.

This has been fixed. The display value will remain "NaN", but the raw value will now be null.

#### Low-Code Apps: Non-linked sections would incorrectly be displayed when creating a new DOM instance [ID 36994]

<!-- MR 10.4.0 - FR 10.3.10 -->

In a low-code app, the form to create a new DOM instance would incorrectly display the sections that were not linked to the initial state.

When a value was set for one of the fields in those sections, saving the new DOM instance would result in a error stating `Instance contains unknown fields for the current state`.

From now on, sections that are not linked to the initial state will no longer be displayed.

#### Dashboards app/Low-Code Apps: Changing query column while it was loading made it stop loading [ID 37006]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, if a column of a query was edited while the query was loading in a table component of a dashboard or low-code app, it would stop loading, and an empty table would temporarily be shown.

#### Low-Code Apps: DOM GenericEnumFieldDescriptors would not be sorted as specified in the DomDefinition [ID 37007]

<!-- MR 10.4.0 - FR 10.3.10 -->

Up to now, in *Form* components, DOM GenericEnumFieldDescriptors would be sorted alphabetically. The order that was specified in the DomDefinition would be disregarded.

From now on, DOM GenericEnumFieldDescriptors will always be sorted as specified in the DomDefinition.

#### DataMiner web apps: Date/time picker issues [ID 37041]

<!-- MR 10.4.0 - FR 10.3.10 -->

A number of date/time picker issues have been fixed.

#### Dashboards app: 'Loading...' indicator would appear when trying to save a folder of which the name consists of spaces [ID 37046]

<!-- 10.2.0 [CU20]/MR 10.3.0 [CU7] - FR 10.3.10 -->

When, in the *Create folder* or *Create dashboard* window, you clicked inside the *Location* box, clicked "+" to add a new folder, entered a series of spaces, and then clicked the checkmark button, a "Loading..." indicator would appear at the top of the window but nothing would happen.

Also, from now on, it is no longer allowed to save a folder with a name containing leading spaces.

#### Dashboards app/Low-Code Apps: Visual glitch when closing component menu [ID 37058]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When the menu of a component in a dashboard or low-code app was closed by moving the mouse pointer out of it at the bottom center, a visual glitch could occur where the menu appeared to rapidly open and close.

#### Dashboards app/Low-Code Apps - Line chart component: Viewport would change upon receiving data [ID 37065]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When a *Line chart* component received new data, it would incorrectly recalculate its viewport.

#### Dashboards app/Low-Code Apps: Query filter not applied on sorted table [ID 37070]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- Not added in 10.4.0: fixes a feature introduced in that version -->

In a dashboard or low-code app, if sorting was applied to one or more columns of a table, it could occur that a query filter could not be correctly applied on the table, so that the unfiltered result was shown instead.

#### Dashboards app: 'Copy embed URL' right-click option continued to be displayed [ID 37090]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the *Copy embed URL* right-click option of a dashboard component continued to be displayed when it should not have been. This specifically occurred when you moved or resized the component or when you closed and reopened edit mode while the option was displayed.

#### Monitoring app: Filtered combo box control not shown correctly in Visual Overview [ID 37107]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In the Monitoring app, it could occur that Visual Overview parameter control shapes configured to show a filtered combo box control (i.e., with *SetVarOptions* set to *Control=FilterComboBox*) were not displayed correctly.

#### GQI: Missing column statistics for discrete options of numeric columns [ID 37111]

<!-- MR 10.4.0 - FR 10.3.10 -->

When the web API fetched information for columns of a GQI query, it could occur that not all statistics were included. In the Dashboards app/Low-Code Apps, this could lead to incorrect "(0)" counters next to the discrete options of numeric columns in the query filter when the filter assistance option was enabled.

#### Low-Code Apps: Time range component overlay not fully displayed [ID 37118]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you click a time range component in a low-code app, an overlay is displayed where you can select a time range. In some cases, it could occur that part of this overlay could not be displayed.

#### Web apps: DOM GenericEnumEntry objects marked as hidden would incorrectly still be visible [ID 37121]

<!-- MR 10.4.0 - FR 10.3.10 -->
<!-- For new feature part of RN, see General/Features -->

In web apps, *GenericEnumEntry* objects marked as hidden would incorrectly still be visible in the UI.

#### Low-Code Apps: No longer possible to deny specific users access to low-code apps when using SAML authentication [ID 37125]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

When using external user authentication via SAML, it was no longer possible to deny specific users access to low-code apps.

#### Low-Code Apps: 'View published app' option still present in user menu after publishing an app [ID 37129]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

After you had published an app, the *View published app* option would still be present in the app's user menu. From now on, this option will no longer be present in the user menu of published apps.

#### Dashboards app/Low-Code Apps: Seconds of multiple clock components would not be in sync [ID 37193]

<!-- MR 10.2.0 [CU20]/10.3.0 [CU8] - FR 10.3.10 -->

When you enabled the *Show seconds* option of multiple clock components on the same dashboard or app panel, the seconds would incorrectly not all be in sync.

#### Low-Code Apps: Editing a published app with an existing draft would incorrectly create a new draft [ID 37194]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when you edited a published app that had a draft, a new draft would incorrectly be created. From now on, when you edit an app that has a draft, that existing draft will be opened.

#### Dashboards app/Low-Code Apps: Label of 'Icon' setting of 'Icon' component would incorrectly be in lowercase [ID 37199]

<!-- MR 10.4.0 - FR 10.3.10 -->

The label of the *Icon* setting of an *Icon* component would incorrectly be in lowercase. It is now in uppercase.

#### Low-Code Apps: Problem when two State components were fed the same query row data with a column filter applied [ID 37206]

<!-- MR 10.3.0 [CU8] - FR 10.3.10 -->

When two *State* components were fed the same query row data and had a column filter applied, the app would become unresponsive.

#### Dashboards app/Low-Code Apps: Problem when migrating a query containing only a 'start from' node linking to another query with only a 'start from' node [ID 37224]

<!-- MR 10.3.0 [CU8] - FR 10.3.10 -->

Up to now, it would not be possible to migrate a query with only a *start from* node linking to another query with only a *start from* node linking to another query.

#### Low-Code Apps - Form component: DOM button shadows would be cut off [ID 37348]

<!-- MR 10.4.0 - FR 10.3.10 [CU0] -->

In a Form component, the DOM button shadows would incorrectly be cut off.
