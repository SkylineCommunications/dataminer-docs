---
uid: Web_apps_Feature_Release_10.4.2
---

# DataMiner web apps Feature Release 10.4.2 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.4.2](xref:General_Feature_Release_10.4.2).

## Highlights

*No highlights have been selected yet.*

## New features

*No new features have been added yet.*

## Changes

### Enhancements

#### Low-Code Apps: Separate 'Delete draft' and 'Delete app' buttons [ID_37878]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, in the header bar of a low-code app, there was one button to either delete the current draft or the entire application.

From now on, a low-code app will have two separate delete buttons:

- a *Discard draft* button in the header bar, and
- a *Delete app* button in the user menu.

> [!NOTE]
> When you click one of these buttons, a confirmation box will appear. Only when you confirm will the draft or app be deleted.

#### Dashboards app & Low-Code Apps: Certain datasets will now be hidden when Elasticsearch/OpenSearch is not installed [ID_38009]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, the dashboard editor would display datasets that did not contain any data due to Elasticsearch/OpenSearch not being installed.

From now on, when the DataMiner System does not include an Elasticsearch/OpenSearch database, a number of datasets will be hidden. See the overview below.

| DMA version | Elasticsearch/OpenSearch installed | Hidden datasets |
|-------------|------------------------------------|-----------------|
| >= 10.4 | Yes | None |
| >= 10.4 | No  | Bookings<br>Object manager definitions<br>Object manager instances<br>Profile parameters<br>Resources<br>Service definitions |
| < 10.4  | Yes | None |
| < 10.4  | No  | Bookings<br>Object manager definitions<br>Object manager instances<br>Service definitions |

#### DataMiner Object Models: Web APIs will no longer retrieve all items when a DOM list value is empty [ID_38024]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When DOM instances are retrieved in the web APIs, an attempt is also made to generate a display value for each field value. If a field value is a DOM instance reference (DomInstanceFieldDescriptor), a call is made to retrieve the DOM instance in question. The same applies for the list variant, where a single call is made to retrieve all selected DOM instances.

Up to now, when an empty list was saved in a DOM instance, the default filter used by the web APIs would incorrectly retrieve all items from the database.

#### Dashboards app & Low-Code Apps: GQI components will now all behave in the same way when loading [ID_38067]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

All GQI components (*State*, *Pie chart*, *Bar chart*, *Line chart*, *Table*, *Grid*, *Scheduler*, *Maps* and *Node Edge*) will now behave in the same way when loading.

#### Dashboards app & Low-Code Apps - Query filter component: Number and date filters will no longer list discrete values unless they are meant to filter columns containing discrete values [ID_38114] [ID_38149]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you enabled the filter assistance in a query filter component, up to now, all number and date filters would list all possible values that existed in the data source. As some of these lists could contain a very large number of values, from now on, number and date filters will no longer list discrete values, unless they are meant to filter number or date columns containing discrete values.

> [!NOTE]
>
> - Filters for columns containing string values will continue to list discrete values, even when the columns do not contain discrete values.
> - From now on, a filter list only show checkboxes when it lists boolean values, string values or discrete values.

#### Dashboards app - GQI: New 'Get profile instances' data source [ID_38138]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In the Generic Query Interface, a new "Get profile instances" data source is now available. It will return all profile instances in the DMS.

#### Dashboards app & Low-Code Apps - Grid component: Touch screen support [ID_38191]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

The grid component now has full touch screen support. It is now possible to pan by sliding a finger across a grid and to select grid items by tapping them.

### Fixes

#### Web apps accessed via a remote access URL would redirect to the shares overview page when they lost connection with the cloud-connected DMA [ID_33789]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When a DataMiner Agent is connected to dataminer.services, you can use the remote access URL to access the DataMiner web apps from anywhere.

Up to now, when a web app that was accessed via a remote access URL lost its connection with the cloud-connected DataMiner Agent, it would incorrectly redirect you to the shares overview page. From now on, it will instead display a message, asking you to reload the page.

#### Dashboards app & Low-Code Apps - Template editor: Clicking a template would incorrectly be considered identical to updating that template [ID_37960]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Clicking a template in the template editor would incorrectly be considered identical to updating that template. As a result, the *Save* button would be enabled and, after clicking *Cancel*, a window mentioning unsaved changes would appear.

#### Dashboards app & Low-Code Apps: Filter box would incorrectly be empty when re-opening a previously filtered dataset [ID_38006]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you re-opened a dataset you had filtered earlier, the filter box would be empty although the dataset would still be filtered.

From now on, when you re-open a dataset you had filtered earlier, the filter box will still contain the filter you entered.

#### Dashboards app: Problem when clicking the search bar [ID_38029]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you clicked the search bar in the header of the *Dashboards* app, in some cases, the following error message would appear:

`this._dmaDashboardsService.dashboards is not iterable`

#### Dashboards app & Low-Code Apps: Template editor could incorrectly be opened before the default template was created [ID_38031]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

While configuring a *Grid*, *Timeline* or *Maps* component, it would incorrectly already be possible to open the template editor before the default template was created.

From now on, as long as the default template has not been created yet, a loading indicator will be displayed and it will not be possible to open the template editor.

#### Dashboards app & Low-Code Apps: Color theme changes would not be applied immediately [ID_38082]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you changed the color theme of a component, the change would incorrectly only get applied after a reload. Now, the change will be applied instantly.

#### Dashboards app & Low-Code Apps: Data would incorrectly not be refetched after changing the visualization of a component [ID_38094]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When you changed the visualization of a component showing data fetched by a GQI query, the data would incorrectly not be refetched.

#### Low-Code Apps - Node edge component: Script action dummies would not be filled in [ID_38106]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When an Automation script action using dummies was linked to a node of a node edge component, up to now, the dummies incorrectly would not get filled in automatically. From now on, they will be filled in automatically when the node matches the dummy type.

#### Low-Code Apps: Problem with input validation when using interactive Automation scripts [ID_38111]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

When an interactive Automation script was used in a low-code app, input validation would not work correctly. When a validation failed, the border of the input field would turn red, but the corresponding error text would not be displayed.

#### Dashboards app & Low-Code Apps: Timeline component would apply incorrect colors [ID_38130]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In some cases, a timeline component would apply incorrect colors.

#### Low-Code Apps: Feed value would never be cleared after being sent to be used in actions [ID_38133]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

Up to now, a feed value would never be cleared after being sent to be used in actions.

For example, when a feed was used in a script action parameter, the last feed value would always be inserted, even when the feed was no longer present when the action was executed.

#### Low-Code Apps: Subheader would overlap the page [ID_38144]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

In a low-code app, the subheader would overlap the contents of a page. From now on, it will be displayed above the page.

#### Dashboards app & Low-Code Apps: Line & area chart would not render aggregation parameters correctly [ID_38166]

<!-- MR 10.3.0 [CU11] - FR 10.4.2 -->

A Line & area chart with multiple aggregation parameters would not render those parameters correctly. Only one line would be shown, and the legend would not show any labels.
