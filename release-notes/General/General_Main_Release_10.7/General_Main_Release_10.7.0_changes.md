---
uid: General_Main_Release_10.7.0_changes
---

# General Main Release 10.7.0 – Changes (preview)

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

## Changes

### Enhancements

#### SLNet: Trend graphs in Cube will now also correctly display behavioral change points for table column parameters without advanced naming [ID 41751]

<!-- MR 10.7.0 - FR 10.6.1 -->

Because of a number of enhancements made in SLNet, trend graphs in DataMiner Cube will now also correctly display behavioral change points for table column parameters without advanced naming.

#### Automation: Engine class now has an OnDestroy handler that will allow resources to be cleaned up when a script ends [ID 43919]

<!-- MR 10.7.0 - FR 10.6.1 -->

An `OnDestroy` handler has now been added to the `Engine` class. This handler will allow resources to be cleaned up when a script ends.

Multiple handlers can be added. They will run synchronously, and if one handler throws an error, the others will keep on running.

#### SLNetClientTest tool: Enhanced management of DOM modules of which definition-level security is enabled [ID 44021]

<!-- MR 10.7.0 - FR 10.6.1 -->

The SLNetClientTest tool has been adapted to be able to better manage DOM modules of which definition-level security is enabled.

##### Filtering on DOM instance IDs in the Filter window

Up to now, it was only possible to select one or more DOM definitions in the list. From now on, it will be possible to enter up to 500 IDs of DOM instances you want to retrieve. If you enter more than 500 IDs, a message will appear, and only the first 500 IDs will be used to construct the filter.

When you enter a number of IDs and click *OK*, the IDs will be parsed. The valid IDs will be used and the invalid IDs will be disregarded.

Note that the IDs you enter will take precedence over the DOM definitions that you selected in the list. As soon as you enter a number of valid DOM instance IDs, the DOM definitions you selected in the list will be disregarded.

##### Context menu added to the list on the main 'DomInstances' tab

The list on the *DomInstances* tab now has a right-click menu with the following options:

| Option | Description |
|--------|-------------|
| View attachments | When this option is selected, all selected DOM instances will be added to list on the *Attachments* tab. This allows you to view, add, or delete attachments for these DOM instances. |
| View history     | When this option is selected, the selected DOM instances will be passed on to the *History* tab, where the list will be updated with the history of these DOM instances.<br>A note will be displayed at the top, clarifying that the current view only shows the history of a specific subset of instances.<br>Note: The list can only show the history of up to 500 instances. If more than 500 instances are selected, a message will be displayed, and no filtering will be applied. |

##### Changes to the Attachments tab

The *Attachments* tab has been updated as follows:

- The *Load* button will now be disabled when definition-level security is enabled.

- A message will now be displayed in the right-hand panel, explaining that you can add DOM instances to the list in the left-hand panel by using the context menu mentioned [above](#context-menu-added-to-the-list-on-the-main-dominstances-tab).

- A *Clear* button now allows you to clear the list of DOM instances.

##### Changes to the History tab

When definition-level security is enabled, from now on, the *History* tab will no longer try to read all recent history. In that case, a message will appear, referring to the context menu mentioned [above](#context-menu-added-to-the-list-on-the-main-dominstances-tab).

> [!NOTE]
> When, in said context menu, you selected *View history* to show the history of specific DOM instances, it is currently not possible to revert that decision and make the list show all latest history. To do so, close the DOM module window and re-open it.

##### When trying to delete a DOM module

When you try to delete a DOM module, but you do not have access to all DOM definitions in that module, a message box will now be displayed, explaining why you are not allowed to delete the module in question.

> [!CAUTION]
> Always be extremely careful when using the *SLNetClientTest* tool, as it can have far-reaching consequences on the functionality of your DataMiner System.

#### DataMiner upgrade: Web-only upgrades with version 10.6.x or above will now require the DMA to have version 10.5.x or above [ID 44103]

<!-- MR 10.7.0 - FR 10.6.1 -->

From now on, it will no longer be allowed to perform web-only upgrades with version 10.6.x or above on DataMiner Agents with a version below 10.5.x.

This means, that any DataMiner Agent on which you want to perform a web-only upgrade with version 10.6.x or above will first have to be upgraded to version 10.5.x or above.

### Fixes

#### SLAnalytics would not receive 'swarming complete' notifications for swarmed DVE child elements [ID 43984]

<!-- MR 10.7.0 - FR 10.6.1 -->

Up to now, SLAnalytics would incorrectly not receive any "swarming complete" notifications for swarmed DVE child elements. As a result, alarm focus calculations for DVE child elements would be restarted from scratch instead of being fetched from the database.
