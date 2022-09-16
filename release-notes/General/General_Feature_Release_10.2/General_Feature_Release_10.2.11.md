---
uid: General_Feature_Release_10.2.11
---

# General Feature Release 10.2.11 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
>
> - For release notes related to DataMiner Cube, see [DataMiner Cube 10.2.11](xref:Cube_Feature_Release_10.2.11).
> - For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Security enhancements [ID_34251]

A number of security enhancements have been made.

#### Ticketing app: Enhanced error handling [ID_33414]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements, overall error handling has improved.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Enhanced performance when querying large XML files [ID_34299]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### Web apps - Interactive Automation scripts: Enhanced performance [ID_34348]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Because of a number of enhancements to the buffering mechanism, overall performance has improved when executing interactive Automation scripts in web apps.

#### SLLogCollector will now also collect the prerequisite output files and all upgrade logs [ID_34352]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

The SLLogCollector tool will also collect all prerequisite output files as well as all upgrade logs.

#### Lingering connections towards a DataMiner Agent will now be forcefully killed [ID_34367]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, connections between DMAs can leak TCP connections, causing new connections towards port 8004 to fail due to port exhaustion.

Up to now, when a new connection towards port 8004 failed, the following entry was logged in the SLNet log file:

``` txt
Connection to {0} via external process succeeds while same connection via SLNet process fails since {1} ({2} times) => possible lingering TCP connections issue
```

From now on, the connection in question will also be forcefully killed.

### Fixes

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### Problem when deserializing an overridden parameter description [ID_34266]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When a JSON string containing an overridden parameter description was deserialized to an ElementInfo message, in some cases, an exception would be thrown.

#### Interactive Automation scripts: Problem when entering an invalid value in a numeric component [ID_34310]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you entered an invalid value in a numeric component, the *UIResults.GetString()* method would incorrectly not return that invalid value. Instead, it returned the last valid value that had been entered.

#### Dashboards app / Low-code apps: Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated [ID_34368]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated.

#### Dashboards app: Email reports would incorrectly not include CSV files when the 'Include CSV' option had been selected [ID_34370]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, email reports would incorrectly not include CSV files when the *Include CSV* option had been selected.

#### Low-code apps: Problem when creating a new component theme [ID_34372]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you created a new component theme while a built-in dashboard theme was active, in some cases, a Web Services API error could occur.

#### Problem with SLProtocol when reading incorrectly configured port settings [ID_34379]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, an error could occur in SLProtocol when reading incorrectly configured port settings.

#### Dashboards app: URL parameter data would not be parsed correctly [ID_34380]

<!-- Main Release Version 10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, parameter data in a dashboard URL would incorrectly only get parsed when followed by a forward slash ("/").

#### Problem with SLLog when closing a log file [ID_34385]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

In some cases, an error could occur in SLLog when closing a log file.

#### Dashboards app: Side panel context menu and selected dashboard would overlap each other [ID_34411]

<!-- Main Release Version 10.1.0 [CU20]/10.2.0 [CU8] - Feature Release Version 10.2.11 -->

When you opened the context menu of the side panel, in some cases, the context menu and the dashboard selected in the list would overlap each other.
