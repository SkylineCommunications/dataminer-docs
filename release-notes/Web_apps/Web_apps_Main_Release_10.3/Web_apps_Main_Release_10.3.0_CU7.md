---
uid: Web_apps_Main_Release_10.3.0_CU7
---

# DataMiner web apps Main Release 10.3.0 CU7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Main Release 10.3.0 CU7](xref:General_Main_Release_10.3.0_CU7).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Main Release 10.3.0 CU7](xref:Cube_Main_Release_10.3.0_CU7).

### Enhancements

#### Security enhancements [ID 37086]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

A number of security enhancements have been made.

#### Dashboard sharing: Any API call that depends on a query feed will now be allowed if the data that is fed is considered valid [ID 37091]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when data from a GQI query was fed to another component on a dashboard, some API calls would not be allowed when that dashboard was shared. From now on, any API call that depends on a query feed will be allowed if the data that is fed is considered valid.

> [!NOTE]
> When you share a dashboard that feeds GQI results to another component, a warning will still appear. The API calls may still allow more than the creator of the dashboard intended.

### Fixes

#### Dashboards app/Low-Code Apps: Error when data source contained cells with NaN value [ID 36923]

<!-- MR 10.2.0 [CU19]/MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when a data source contained cells with the value "NaN", an error message was shown in the Dashboards app or Low-Code Apps.

This has been fixed. The display value will remain "NaN", but the raw value will now be null.

#### Dashboards app/Low-Code Apps: Changing query column while it was loading made it stop loading [ID 37006]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

Up to now, if a column of a query was edited while the query was loading in a table component of a dashboard or low-code app, it would stop loading, and an empty table would temporarily be shown.

#### Dashboards app: Height of 'Data used in Dashboard' section would not be reduced when you deleted multiple components at once [ID 37032]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.9 -->

When, while in edit mode, you deleted multiple components at once, the *Data used in Dashboard* section of the edit pane would not be updated correctly. The data would be removed, but the height of the section would incorrectly not be reduced.

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

#### Dashboards app: 'Copy embed URL' right-click option continued to be displayed [ID 37090]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

In some cases, it could occur that the *Copy embed URL* right-click option of a dashboard component continued to be displayed when it should not have been. This specifically occurred when you moved or resized the component or when you closed and reopened edit mode while the option was displayed.

#### Monitoring app: Filtered combo box control not shown correctly in Visual Overview [ID 37107]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

In the Monitoring app, it could occur that Visual Overview parameter control shapes configured to show a filtered combo box control (i.e., with *SetVarOptions* set to *Control=FilterComboBox*) were not displayed correctly.

#### Low-Code Apps: Time range component overlay not fully displayed [ID 37118]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

When you click a time range component in a low-code app, an overlay is displayed where you can select a time range. In some cases, it could occur that part of this overlay could not be displayed.

#### Low-Code Apps: No longer possible to deny specific users access to low-code apps when using SAML authentication [ID 37125]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

When using external user authentication via SAML, it was no longer possible to deny specific users access to low-code apps.

#### Low-Code Apps: 'View published app' option still present in user menu after publishing an app [ID 37129]

<!-- MR 10.3.0 [CU7] - FR 10.3.10 -->

After you had published an app, the *View published app* option would still be present in the app's user menu. From now on, this option will no longer be present in the user menu of published apps.

#### Low-Code Apps: Editing a published app with an existing draft would incorrectly create a new draft [ID 37194]

<!-- MR 10.2.0 [CU19]/10.3.0 [CU7] - FR 10.3.10 -->

Up to now, when you edited a published app that had a draft, a new draft would incorrectly be created. From now on, when you edit an app that has a draft, that existing draft will be opened.
