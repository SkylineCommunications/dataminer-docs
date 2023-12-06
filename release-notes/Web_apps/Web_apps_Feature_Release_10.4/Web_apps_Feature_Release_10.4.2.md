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

### Fixes

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
