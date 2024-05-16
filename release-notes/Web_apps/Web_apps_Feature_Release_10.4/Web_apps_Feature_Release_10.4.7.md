---
uid: Web_apps_Feature_Release_10.4.7
---

# DataMiner web apps Feature Release 10.4.7 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.7](xref:General_Feature_Release_10.4.7).

## Highlights

*No highlights have been selected yet.*

## New features

#### Interactive Automation scripts: UIBlockDefinition has new DebugTag property [ID_39365]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

The `UIBlockDefinition` class has a new `DebugTag` property, which allows you to assign an identifier to a UI element. That identifier can then be used in automated tests to explicitly refer to the UI element in question.

Example of a [Cypress](https://www.cypress.io/) test that gets the UI element of which the `DebugTag` property was set to "TextComponent":

```javascript
cy.get(`[data-cy="TextComponent"]`)
    .should('have.text', 'Some text');
```

> [!NOTE]
> The `DebugTag` can only be used in interactive Automation scripts launched from web apps, not in interactive Automation scripts launched from DataMiner Cube.

#### Dashboards app & Low-Code Apps: New 'Search input' component [ID_39555]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

A new *Search input* component is now available.

It is identical to the *Text input* component, but allows users to clear its contents by clicking the *X*.

#### Low-Code Apps: New 'On close' event [ID_39604]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In low-code apps, you can now configure actions for a new *On close* event, which will be triggered right before a page is closed, either manually (by navigating using the sidebar) or via an action.

> [!NOTE]
>
> - Navigating to the next page will be blocked until all configured actions are executed. Therefore, it is good practice to only configure actions that do not take too long.
> - The existing *On page load* event has now been renamed to *On open*.

#### Low-Code Apps: New 'Close all panels' action [ID_39625]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In low-code apps, you can now configure a *Close all panels* action. As its name suggests, this action will close all panels when executed.

## Changes

### Enhancements

#### Web apps - Visual Overview: Enhanced performance when updating a visual overview [ID_39038]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when updating a visual overview in a web app.

#### Dashboards app & Low-Code Apps: 'New' label removed from Grid and Timeline components [ID_39490]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Both the *Grid* and the *Timeline* component no longer have a "New" label.

#### Low-Code Apps: Duplicate page name check will now be case insensitive [ID_39511]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, the duplicate page name check would be case sensitive. From now on, it will be case insensitive.

Also, a case-insensitive duplicate panel name check has now been added, and leading and trailing whitespace characters in page or panel names will now be trimmed.

#### Dashboards app & Low-Code Apps - Line & area chart component: Enhancements [ID_39586]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

A number of enhancements have been made to the *Line & area chart* component:

- Axis labels showing time data are now fully aligned with the *Timeline* component. The first label will now always include the day, the month and the year.

- The Y axis now has a dynamic range. Its minimum and maximum values will change according to the visible data.

- The component now has touchscreen support for panning and zooming:

  - To pan, drag left or right.
  - To zoom, pinch the chart.

- The chart dimensions will now be automatically adapted.

  - When a line chart has data, but does not have lines configured, the component will add one line on the default X and Y axes.
  - The columns will be chosen based on the column type and the column name. For example, a column with the name "X" will be chosen for the X value. 

### Fixes

#### Dashboards app & Low-Code Apps - Maps component: 'Map type not supported' error would not be displayed [ID_39506]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you tried to use a *Maps* component with an unsupported provider, in some cases, the `Map type not supported` error would incorrectly not be displayed. Instead, the component would stay empty.

#### Data Aggregator DxM would incorrectly not be able to run a GQI query that used Regexmatch column manipulation methods [ID_39540]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, due to a parsing issue, the Data Aggregator DxM would incorrectly not be able to run a GQI query that used *Regexmatch* column manipulation methods.

#### Data Aggregator DxM would incorrectly not be able to run a GQI query that used the 'Get object manager instances' data source [ID_39596]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, due to a parsing issue, the Data Aggregator DxM would incorrectly not be able to run a GQI query that used the 'Get object manager instances' data source.

#### Dashboards app: Access permissions for a private dashboard would be linked to an incorrect user name [ID_39610]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you created a private dashboard, in some cases, the user permissions necessary to access that dashboard would incorrectly be linked to the domain controller user name instead of your DataMiner user name.
