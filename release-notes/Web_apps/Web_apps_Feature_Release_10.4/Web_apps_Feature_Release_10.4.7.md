---
uid: Web_apps_Feature_Release_10.4.7
---

# DataMiner web apps Feature Release 10.4.7

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.7](xref:General_Feature_Release_10.4.7).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.7](xref:Cube_Feature_Release_10.4.7).

## Highlights

- [Low-Code Apps - Interactive automation scripts: UI can now be hidden [ID 39451] [ID 39638]](#low-code-apps---interactive-automation-scripts-ui-can-now-be-hidden-id-39451-id-39638)

## Breaking changes

#### Dashboards app & Low-Code Apps: More consistent use of colors in graphs [ID 39739]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

The way in which colors are assigned to graphs has been enhanced. Across all components, charts displaying the same data will now use the same colors. This will greatly improve visual coherence and data interpretation.

Instead of each component independently taking the next color from its color palette, components will now check if another component has already requested a color for the same data. If so, the same color will be applied.

Data is considered identical if the display label used in the chart legend is identical. For example, if multiple charts display data labeled "SLNet:0", they will all use the same color for this label.

Note that, by default, colors will not be consistent across different sessions. Refreshing the application may result in different colors being used for the same data. If you want to maintain consistent colors across multiple sessions, you can now define conditional colors in a component theme's color palette by binding colors to specific regular expressions that match the display labels of the data.

> [!NOTE]
>
> - If a low-code app created prior to DataMiner 10.3.0 [CU16]/10.4.0 [CU4]/10.4.7 relies on the color order assigned in the theme's color palette, you will need to manually bind these colors to the data using conditional coloring to achieve the same result.
> - If you want to revert to the former color assignment behavior where a single color is used across all graphs, include only one color in the component theme's color palette.

## New features

#### Interactive automation scripts: UIBlockDefinition has new DebugTag property [ID 39365]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

The `UIBlockDefinition` class has a new `DebugTag` property, which allows you to assign an identifier to a UI element. That identifier can then be used in automated tests to explicitly refer to the UI element in question.

Example of a [Cypress](https://www.cypress.io/) test that gets the UI element of which the `DebugTag` property was set to "TextComponent":

```javascript
cy.get(`[data-cy="TextComponent"]`)
    .should('have.text', 'Some text');
```

> [!NOTE]
> The `DebugTag` can only be used in interactive automation scripts launched from web apps, not in interactive automation scripts launched from DataMiner Cube.

#### Low-Code Apps - Interactive automation scripts: UI can now be hidden [ID 39451] [ID 39638]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In a low-code app, it is now possible to hide the automation script window. This will allow users to continue working inside a low-code app while an automation script is running.

To hide the UI of an automation script, you can use the new `HideUI()` method in the `Engine` class.

Example:

```csharp
using System;
using Skyline.DataMiner.Automation;

public class Script
{
    public void Run(Engine engine)
    {
        // Build and display a form
        var formUi = BuildFormUi();
        var results = engine.ShowUI(formUi);

        // Process UI results

        // Hide the UI before starting a lengthy operation
        engine.HideUI();

        // Build and display issue information
        var issueUi = BuildIssueUi();
        var issueResults = engine.ShowUI(issueUi);
    }
}
```

> [!NOTE]
>
> - Although the use of `HideUI()` requires the automation script to be interactive, a script will not be recognized as interactive if the method is included in the script. It needs to be used in combination with `ShowUI()` or `FindInteractiveClient()`.
> - Although it is possible to request hiding the UI prior to showing it, it is recommended to not show any UI and only hide the UI after it was shown.

#### Dashboards app & Low-Code Apps: New 'Search input' component [ID 39555]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

A new *Search input* component is now available.

It is identical to the *Text input* component, but allows users to clear its contents by clicking the *X*.

#### Low-Code Apps: New 'On close' page event [ID 39604] [ID 39682]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In low-code apps, you can now configure actions for a new *On close* page event, which will be triggered right before a page is closed, either manually (by navigating using the sidebar) or via an action.

> [!NOTE]
>
> - Navigating to the next page will be blocked until all configured actions are executed. Therefore, it is good practice to only configure actions that do not take too long.
> - Actions linked to the *On close* page event will not be executed when you close the app.
> - The existing *On page load* event has now been renamed to *On open*.

#### Low-Code Apps: New 'Close all panels' action [ID 39625]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In low-code apps, you can now configure a *Close all panels* action. As its name suggests, this action will close all panels when executed.

#### Low-Code Apps: New 'On open' panel event [ID 39636]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In low-code apps, you can now configure actions for a new *On open* panel event, which will be triggered each time a panel is opened.

#### Low-Code Apps: Option to allow users to drag a panel to another location [ID 39649]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you configure a panel, it is now possible to allow users to drag it to another location.

> [!NOTE]
> Even if you indicated that a panel can be dragged to another location, it will only be possible to do so when that panel is opened as a pop-up window.

#### Low-Code Apps: New 'On close' panel event [ID 39668]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In low-code apps, you can now configure actions for a new *On close* panel event, which will be triggered when a panel is closed, either by you clicking an overlay or when a *Close panel* or *Close all panels* action is executed.

> [!NOTE]
> The panel will only be closed when all configured actions have been executed. Therefore, it is good practice to only configure actions that do not take too long.

## Changes

### Enhancements

#### Web apps - Visual Overview: Enhanced performance when updating a visual overview [ID 39038]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements, overall performance has increased when updating a visual overview in a web app.

#### Dashboards app & Low-Code Apps: 'New' label removed from Grid and Timeline components [ID 39490]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Both the *Grid* and the *Timeline* component no longer have a "New" label.

#### Low-Code Apps: Duplicate page name check will now be case insensitive [ID 39511]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, the duplicate page name check would be case sensitive. From now on, it will be case insensitive.

Also, a case-insensitive duplicate panel name check has now been added, and leading and trailing whitespace characters in page or panel names will now be trimmed.

#### Dashboards app & Low-Code Apps - Line & area chart component: Enhancements [ID 39586]

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

#### Low-Code Apps: All open panels will now stay open when you switch from one page to another [ID 39632]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, all open panels would by default be closed when you switched from one page to another. From now on, all open panels will by default stay open when you switch from one page to another.

> [!NOTE]
> When you migrate to this DataMiner version, in all your existing low-code apps, a *Close all panels* action will be added to the *On close* event of each page.

#### Web API: Enhanced performance [ID 39684]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Because of a number of enhancements with regard to subscription reuse and WebSocket communication, overall performance of the web API has increased.

### Fixes

#### Dashboards app & Low-Code Apps - Maps component: 'Map type not supported' error would not be displayed [ID 39506]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you tried to use a *Maps* component with an unsupported provider, in some cases, the `Map type not supported` error would incorrectly not be displayed. Instead, the component would stay empty.

#### Data Aggregator DxM would incorrectly not be able to run a GQI query that used Regexmatch column manipulation methods [ID 39540]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, due to a parsing issue, the Data Aggregator DxM would incorrectly not be able to run a GQI query that used *Regexmatch* column manipulation methods.

#### Dashboards app - Web component: 'auth' argument would incorrectly be added to the URL specified in a Web component [ID 39587]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In some cases, an *auth* argument would incorrectly be added to the URL specified in a Web component. This would cause the Web component to not being able to resolve the URL.

#### Data Aggregator DxM would incorrectly not be able to run a GQI query that used the 'Get object manager instances' data source [ID 39596]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, due to a parsing issue, the Data Aggregator DxM would incorrectly not be able to run a GQI query that used the 'Get object manager instances' data source.

#### Dashboards app: Access permissions for a private dashboard would be linked to an incorrect user name [ID 39610]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When you created a private dashboard, in some cases, the user permissions necessary to access that dashboard would incorrectly be linked to the domain controller user name instead of your DataMiner user name.

#### Dashboards app & Low-Code Apps - Template editor: Problem when configuring a conditional case using a numeric column with discrete values as a filter [ID 39656]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

When, in the template editor, you configured a conditional case using a numeric column with discrete values as a filter, the condition would not get applied when a discrete value was selected.

#### Dashboards app & Low-Code Apps: Line & area chart component would show null values [ID 39689]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

In some cases, a *Line and area chart* component would incorrectly show null values. From now on, these values will no longer be displayed.

#### Dashboards app & Low-Code Apps - Stepper component: Problem when a DOM instance in the initial state did not have any history [ID 39704]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

Up to now, when a DOM instance was in the initial state, did not have any history, and had a definition that contained a loop from "initial" back to "initial", the *Stepper* component would show an incorrect state.

From now on, the *Stepper* component will no longer try and guess the history of a DOM instance in the initial state when no history is available.

#### Dashboards app & Low-Code Apps - Table component: Problem with references to query columns specified in table templates after migrating a dashboard or app [ID 39730]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 -->

After a dashboard or a low-code app had been migrated from DataMiner server version 10.3.8 to DataMiner server version 10.3.9 or later, all references to query columns specified in table templates would no longer work.

> [!NOTE]
> This problem did not occur after a web-only upgrade.

#### Web API: No longer possible to configure ticketing domains [ID 39771]

<!-- MR 10.3.0 [CU16] / 10.4.0 [CU4] - FR 10.4.7 [CU0] -->

Due to an issue in the Web API, it was no longer possible to configure ticketing domains.
