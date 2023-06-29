---
uid: Web_apps_Feature_Release_10.3.9
---

# DataMiner web apps Feature Release 10.3.9 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For release notes for this release that are not related to the web applications, see [General Feature Release 10.3.9](xref:General_Feature_Release_10.3.9).

## Highlights

*No highlights have been selected for this release yet*

## Other features

*No features have been added to this release yet.*

## Changes

### Enhancements

#### Dashboards app: Enhanced mechanism to update the list of dashboards in the navigation pane [ID_36604]

<!-- MR 10.4.0 - FR 10.3.9 -->

Up to now, the list of dashboards displayed in the navigation pane on the left would be updated every 5 seconds via a polling mechanism. From now on, whenever that list is changed, all connected clients will receive an event that will update the list.

### Fixes

#### Dashboards app: Black boxes on top of first or last field of selection boxes on small screens [ID_36738]

<!-- MR 10.2.0 [CU18] - FR 10.3.9 -->

When you reduced the screen size to the point at which the navigation pane got hidden, a black box would incorrectly appear on top of the first or last field of a selection box.
