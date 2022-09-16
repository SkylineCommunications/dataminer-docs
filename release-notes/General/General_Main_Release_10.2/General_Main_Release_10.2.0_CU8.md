---
uid: General_Main_Release_10.2.0_CU8
---

# General Main Release 10.2.0 CU8 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_34251]

A number of security enhancements have been made.

#### Ticketing app: Enhanced error handling [ID_33414]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall error handling has improved.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Improved performance of SLDataGateway process [ID_34206]

<!-- MR 10.2.0 [CU8] - FR 10.2.10 -->

Because of improved internal logic, the performance of the SLDataGateway process has improved.

#### DataMiner Cube - Service & Resource Management: Function resource icons are now centered in service definition diagrams [ID_34249]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In service definition diagrams, function resource icons are now centered.

#### DataMiner Cube - Automation: Changes made to a script by other users will immediately be shown when selecting that script [ID_34277]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you select an Automation script in the Automation app, from now on, changes made to that script by other users (e.g. in another Cube session or in DataMiner Integration Studio) will immediately be shown.

#### Enhanced performance when querying large XML files [ID_34299]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### DataMiner Cube - Resources app: Removing resources from all pools [ID_34311]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you move one or more resources from a pool to the *(uncategorized)* pool, a confirmation box will now appear to warn you that, if you click *Yes*, the resources in question will be removed from all pools.

#### DataMiner Cube - Visual Overview: Service context of a linked shape will only be determined when the service context has been specified [ID_34340]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a shape was linked to an element that was not part of a service, up to now, an attempt would be made to determine the service context even when no service context had been specified. From now on, the service context will only be determined when the service context has been specified in the shape.

#### Web apps - Interactive Automation scripts: Enhanced performance [ID_34348]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements to the buffering mechanism, overall performance has improved when executing interactive Automation scripts in web apps.

#### DataMiner Cube - Visual Overview: Enhanced performance when sorting dynamically positioned shapes [ID_34351]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall performance has increased when sorting dynamically positioned shapes.

#### SLLogCollector will now also collect the prerequisite output files and all upgrade logs [ID_34352]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

The SLLogCollector tool will also collect all prerequisite output files as well as all upgrade logs.

#### DataMiner Cube - Visual Overview: Caching of user settings in order to enhanced performance [ID_34383]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In Visual Overview, the current value of the following user settings will now be cached in order to enhance performance:

- *Open element cards undocked* (*Settings* window)
- *AlarmSettings.Blinking* (*MaintenanceSettings.xml* file)

#### DataMiner Cube - Visual Overview: Enhanced performance when determining whether a shape is clickable [ID_34386]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

A number of enhancements have been made to the procedure called to determine whether a shape is clickable.

### Fixes

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### DataMiner Cube - Trending: Y axis would incorrectly show other values when the trend graph showed a constant exception value [ID_34242]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened a trend graph that only showed a constant exception value, the Y axis would incorrectly not only show the exception value but also a number of other values. In cases like this, from now on, the Y axis will only show the exception value.

#### Problem when deserializing an overridden parameter description [ID_34266]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a JSON string containing an overridden parameter description was deserialized to an ElementInfo message, in some cases, an exception would be thrown.

#### DataMiner Cube - Trending: Y-axis values did not take into account the number of decimals configured in the protocol.xml file [ID_34269]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened a trend graph, the Y-axis values would incorrectly not take into account the number of decimals configured in the *protocol.xml* file for the parameters in question.

#### Interactive Automation scripts: Problem when entering an invalid value in a numeric component [ID_34310]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you entered an invalid value in a numeric component, the *UIResults.GetString()* method would incorrectly not return that invalid value. Instead, it returned the last valid value that had been entered.

#### DataMiner Cube - Alarm Console: Negative counters in the footer bar [ID_34318]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

On systems with active correlation rules, in some rare cases, the counters in the footer bar of the Alarm Console could show negative numbers.

#### DataMiner Cube - EPM: Not possible to add a second parameter to a trend graph of an EPM object [ID_34323]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened a trend graph of an EPM object, it would not be possible to add a second parameter. After you had added a new parameter, the drop-down box would incorrectly only contain the current parameter.

#### Dashboards app / Low-code apps: Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated [ID_34368]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated.

#### Dashboards app: Email reports would incorrectly not include CSV files when the 'Include CSV' option had been selected [ID_34370]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, email reports would incorrectly not include CSV files when the *Include CSV* option had been selected.

#### Low-code apps: Problem when creating a new component theme [ID_34372]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you created a new component theme while a built-in dashboard theme was active, in some cases, a Web Services API error could occur.

#### Problem when processing a history set with a timestamp referring to a moment far in the past [ID_34378]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version TBD -->

When SLElement was processing a history set, an error could occur when the timestamp of that history set referred to a moment far in the past.

#### Problem with SLProtocol when reading incorrectly configured port settings [ID_34379]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, an error could occur in SLProtocol when reading incorrectly configured port settings.

#### Dashboards app: URL parameter data would not be parsed correctly [ID_34380]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, parameter data in a dashboard URL would incorrectly only get parsed when followed by a forward slash ("/").

#### DataMiner Cube - Visual Overview: Fix multiple script executions on page shape data change [ID_34412]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When, on page level, you had configured a data field of type *Execute* containing multiple *Set* actions with placeholders as well as a *Script* action, the script would incorrectly get executed multiple times when the page was opened.
