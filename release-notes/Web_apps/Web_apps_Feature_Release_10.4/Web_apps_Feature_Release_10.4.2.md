---
uid: Web_apps_Feature_Release_10.4.2
---

# DataMiner web apps Feature Release 10.4.2

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
>
> - For release notes related to the general DataMiner release, see [General Feature Release 10.4.2](xref:General_Feature_Release_10.4.2).
> - For release notes related to DataMiner Cube, see [DataMiner Cube Feature Release 10.4.2](xref:Cube_Feature_Release_10.4.2).

## Highlights

- [Dashboards app & Low-Code Apps: All visualizations now have an Info button to access their help page [ID 38224]](#dashboards-app--low-code-apps-all-visualizations-now-have-an-info-button-to-access-their-help-page-id-38224)
- [Low-Code Apps: Separate 'Delete draft' and 'Delete app' buttons [ID 37878]](#low-code-apps-separate-delete-draft-and-delete-app-buttons-id-37878)
- [Dashboards app & Low-Code Apps - GQI: New 'Get profile instances' data source [ID 38138]](#dashboards-app--low-code-apps---gqi-new-get-profile-instances-data-source-id-38138)

## New features

#### Dashboards app & Low-Code Apps: All visualizations now have an Info button to access their help page [ID 38224]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In edit mode, all visualizations now have a new *Info* button. Clicking this button when configuring a visualization will open its help page on <https://docs.dataminer.services/>.

> [!NOTE]
> Currently, clicking the *Info* button of the *Grid* component or the *Timeline* component will open the [Unleashing a world of possibilities: Introducing the timeline and grid components](https://community.dataminer.services/unleashing-a-world-of-possibilities-introducing-the-timeline-and-grid-components/) blog post instead.

## Changes

### Enhancements

#### Low-Code Apps: Separate 'Delete draft' and 'Delete app' buttons [ID 37878]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, in the header bar of a low-code app, there was one button to either delete the current draft or the entire application.

From now on, a low-code app will have two separate delete buttons:

- a *Discard draft* button in the header bar, and
- a *Delete app* button in the user menu.

> [!NOTE]
> When you click one of these buttons, a confirmation box will appear. Only when you confirm will the draft or app be deleted.

#### Dashboards app & Low-Code Apps: Certain datasets will now be hidden when Elasticsearch/OpenSearch is not installed [ID 38009]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, the dashboard editor would display datasets that did not contain any data due to Elasticsearch/OpenSearch not being installed.

From now on, when the DataMiner System does not include an Elasticsearch/OpenSearch database, a number of datasets will be hidden. See the overview below.

| DMA version | Elasticsearch/OpenSearch installed | Hidden datasets |
|-------------|------------------------------------|-----------------|
| >= 10.4 | Yes | None |
| >= 10.4 | No  | Bookings<br>Object manager definitions<br>Object manager instances<br>Profile parameters<br>Resources<br>Service definitions |
| < 10.4  | Yes | None |
| < 10.4  | No  | Bookings<br>Object manager definitions<br>Object manager instances<br>Service definitions |

#### DataMiner Object Models: Web APIs will no longer retrieve all items when a DOM list value is empty [ID 38024]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When DOM instances are retrieved in the web APIs, an attempt is also made to generate a display value for each field value. If a field value is a DOM instance reference (DomInstanceFieldDescriptor), a call is made to retrieve the DOM instance in question. The same applies for the list variant, where a single call is made to retrieve all selected DOM instances.

Up to now, when an empty list was saved in a DOM instance, the default filter used by the web APIs would incorrectly retrieve all items from the database.

#### Dashboards app & Low-Code Apps: GQI components will now all behave in the same way when loading [ID 38067]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

All GQI components (*State*, *Pie chart*, *Bar chart*, *Line chart*, *Table*, *Grid*, *Scheduler*,*Node Edge* and *Maps*) will now behave in the same way when loading.

> [!NOTE]
> The *Maps* component is currently still in soft launch.

#### Dashboards app & Low-Code Apps - Query filter component: Number and date filters will no longer list discrete values unless they are meant to filter columns containing discrete values [ID 38114] [ID 38149]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you enabled the filter assistance in a query filter component, up to now, all number and date filters would list all possible values that existed in the data source. As some of these lists could contain a very large number of values, from now on, number and date filters will no longer list discrete values, unless they are meant to filter number or date columns containing discrete values.

> [!NOTE]
>
> - Filters for columns containing string values will continue to list discrete values, even when the columns do not contain discrete values.
> - From now on, a filter list only show checkboxes when it lists boolean values, string values or discrete values.

#### Dashboards app & Low-Code Apps - GQI: New 'Get profile instances' data source [ID 38138]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In the Generic Query Interface, a new "Get profile instances" data source is now available. It will return all profile instances in the DMS.

#### Dashboards app & Low-Code Apps - Grid component: Touch screen support [ID 38191]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

The grid component now has full touch screen support. It is now possible to pan by sliding a finger across a grid and to select grid items by tapping them.

### Fixes

#### Web apps accessed via a remote access URL would redirect to the shares overview page when they lost connection with the cloud-connected DMA [ID 33789]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When a DataMiner Agent is connected to dataminer.services, you can use the remote access URL to access the DataMiner web apps from anywhere.

Up to now, when a web app that was accessed via a remote access URL lost its connection with the cloud-connected DataMiner Agent, it would incorrectly redirect you to the shares overview page. From now on, it will instead display a message, asking you to reload the page.

#### Dashboards app & Low-Code Apps - Template editor: Clicking a template would incorrectly be considered identical to updating that template [ID 37960]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Clicking a template in the template editor would incorrectly be considered identical to updating that template. As a result, the *Save* button would be enabled and, after clicking *Cancel*, a window mentioning unsaved changes would appear.

#### Dashboards app & Low-Code Apps: Filter box would incorrectly be empty when re-opening a previously filtered dataset [ID 38006]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you re-opened a dataset you had filtered earlier, the filter box would be empty although the dataset would still be filtered.

From now on, when you re-open a dataset you had filtered earlier, the filter box will still contain the filter you entered.

#### Dashboards app: Problem when clicking the search bar [ID 38029]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you clicked the search bar in the header of the *Dashboards* app, in some cases, the following error message would appear:

`this._dmaDashboardsService.dashboards is not iterable`

#### Dashboards app & Low-Code Apps: Template editor could incorrectly be opened before the default template was created [ID 38031]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

While configuring a *Grid*, *Timeline* or *Maps* component, it would incorrectly already be possible to open the template editor before the default template was created.

From now on, as long as the default template has not been created yet, a loading indicator will be displayed and it will not be possible to open the template editor.

> [!NOTE]
> The *Maps* component is currently still in soft launch.

#### Dashboards app & Low-Code Apps: Color theme changes would not be applied immediately [ID 38082]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you changed the color theme of a component, the change would incorrectly only get applied after a reload. Now, the change will be applied instantly.

#### Dashboards app & Low-Code Apps: Data would incorrectly not be refetched after changing the visualization of a component [ID 38094]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you changed the visualization of a component showing data fetched by a GQI query, the data would incorrectly not be refetched.

#### Low-Code Apps - Node edge component: Script action dummies would not be filled in [ID 38106]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When an Automation script action using dummies was linked to a node of a node edge component, up to now, the dummies incorrectly would not get filled in automatically. From now on, they will be filled in automatically when the node matches the dummy type.

#### Low-Code Apps: Problem with input validation when using interactive automation scripts [ID 38111]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When an interactive Automation script was used in a low-code app, input validation would not work correctly. When a validation failed, the border of the input field would turn red, but the corresponding error text would not be displayed.

#### Dashboards app & Low-Code Apps: Timeline component would apply incorrect colors [ID 38130]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In some cases, a timeline component would apply incorrect colors.

#### Low-Code Apps: Feed value would never be cleared after being sent to be used in actions [ID 38133]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, a feed value would never be cleared after being sent to be used in actions.

For example, when a feed was used in a script action parameter, the last feed value would always be inserted, even when the feed was no longer present when the action was executed.

#### Low-Code Apps: Subheader would overlap the page [ID 38144]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In a low-code app, the subheader would overlap the contents of a page. From now on, it will be displayed above the page.

#### Low-Code Apps: Problem when creating a DOM instance containing soft-deleted field descriptors [ID 38164]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Creating a new DOM instance in a low-code app would fail when that DOM instance contained boolean field descriptors that had been marked as soft-deleted. Those field descriptors would incorrectly have their value set to false.

#### Dashboards app & Low-Code Apps: Line & area chart would not render aggregation parameters correctly [ID 38166]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

A Line & area chart with multiple aggregation parameters would not render those parameters correctly. Only one line would be shown, and the legend would not show any labels.

#### Dashboards app & Low-Code Apps - Table component: 'Restore initial view' button would get disabled when an error occurred due to a sort operation [ID 38249]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When an error occurred in the table component after a user had sorted the data on a column, the *Restore initial view* button would incorrectly get disabled. As a result, it would not be possible to make the error disappear and undo the sort operation.

#### Low-Code Apps - Visual Overview: Problem when opening a popup window from within another popup window [ID 38265]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When, in a visual overview inside a low-code app, you opened a popup window from within another popup window, it would not be opened correctly.

#### Dashboards app & Low-Code Apps: Chart components no longer showed any data after switching to another visualization and back [ID 38269]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you switched a *Column & bar chart* or *Pie & donut chart* component to another visualization, and then switched back, in some cases, it would no longer show any data.

#### Dashboards app & Low-Code Apps: Visualization picker of a component would contain deprecated visualizations [ID 38270]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In some cases, the visualization picker of a component would incorrectly contain visualizations that had been deprecated.

#### Popup window issues in web apps [ID 38272]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In all DataMiner web apps, a few minor popup window issues have been fixed.

#### Dashboards app: Problem when refreshing a dashboard that contained a Parameter table component [ID 38291]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you refreshed a dashboard that contained a *Parameter table* component, the following error would be thrown:

`TypeError: Cannot read properties of undefined (reading 'selectMany')`

#### Dashboards app & Low-Code Apps - Template editor: '<=' operators in conditional cases would incorrectly be changed to '=' operators [ID 38296]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you saved a template with conditional cases that contained "<=" operators, those operators would incorrectly be changed to "=" operators.

#### Dashboards app - 'Column & bar chart' and 'Pie & donut chart' components: Problem when deleting the query of which the data is being displayed [ID 38314]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you add multiple queries to a *Column & bar chart* or *Pie & donut chart* component, only the data retrieved by the first one added will be displayed. Up to now, when you deleted the query of which the data was displayed, the component would malfunction until the page was reloaded.

From now on, when you delete the query of which the data is being displayed, the component will automatically switch to the second query added and display the data retrieved by that one.

#### Dashboards app: Unnecessary component properties would be saved in a dashboard configuration [ID 38315]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In some cases, unnecessary component properties would be saved in a dashboard configuration.

#### Web apps: Problem with bottom tab control in mobile versions [ID 38422]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

In the mobile versions of the web apps, the bottom tab control would incorrectly not display the contents of the selected tab.

#### Low-Code Apps: Page content would not fit the screen [ID 38478]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 [CU0] -->

In some cases, page content would not fit the screen and no scrollbars would appear. As a result, components could be cut off at the bottom of the screen.

Also, the header bar of a page or panel in edit mode would not be aligned with the height of the side panel header.
