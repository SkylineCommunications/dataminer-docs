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

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements, overall error handling has improved.

#### Performance improvement to update service state more quickly [ID_34165]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a performance improvement, the calculated service alarm state will now be updated more quickly in the client.

#### Low-code apps: Data input via URL [ID_34261]

<!-- MR 10.3.0 - FR 10.2.11 -->

Low-code apps can now be provided with data (e.g. element data, parameter data, view data, etc.) via URL query parameters.

To do so, add a URL query parameter with key *data*. The value should be a URL-encoded JSON object with the following structure:

- *v*: version number (currently always 1)
- *components*: an array of component input objects

```json
{
   v: <version-number>;
   components: <component-data>;
}
```

The component input objects (component-data) have the following structure:

```json
{
   cid: <component-id>,
   select: <data>
}
```

In the following example, the URL selects one default element on the initial page:

- component ID = 1
- element ID = 1/6

```txt
https://<dma>/<app-id>?data=%7B%22v%22:1,%22components%22:%5B%7B%22cid%22:1,%22select%22:%7B%22elements%22:%5B%221%2F6%22%5D%7D%5D%7D%7D
```

#### Enhanced performance when querying large XML files [ID_34299]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements made to SLXML, overall performance has increased when querying large XML files.

#### Web apps - Interactive Automation scripts: Enhanced performance [ID_34348]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

Because of a number of enhancements to the buffering mechanism, overall performance has improved when executing interactive Automation scripts in web apps.

#### SLLogCollector will now also collect the prerequisite output files and all upgrade logs [ID_34352]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

The SLLogCollector tool will also collect all prerequisite output files as well as all upgrade logs.

#### Lingering connections towards a DataMiner Agent will now be forcefully killed [ID_34367]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, connections between DMAs can leak TCP connections, causing new connections towards port 8004 to fail due to port exhaustion.

Up to now, when a new connection towards port 8004 failed, the following entry was logged in the SLNet log file:

``` txt
Connection to {0} via external process succeeds while same connection via SLNet process fails since {1} ({2} times) => possible lingering TCP connections issue
```

From now on, the connection in question will also be forcefully killed.

### Fixes

#### Failover: Offline agent would fail to come online when the NATS cluster was down during a Failover switch [ID_33681]

<!-- MR 10.3.0 - FR 10.2.11 -->

When, during a Failover switch, the NATS cluster was down, the offline agent would fail to come online.

#### GQI - Elasticsearch: Aggregated data did not have the number of decimals specified in the parameter info [ID_33712]

<!-- MR 10.3.0 - FR 10.2.11 -->

Aggregated data retrieved from an Elasticsearch database did not have the number of decimals specified in the parameter info.

#### Dashboard Gateway (legacy): Dashboards would fail to show the Maps component when the DMA had HTTPS configured [ID_33777]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a legacy Dashboard Gateway was connected to a DataMiner Agent with HTTPS configured and port 80 blocked, dashboards would fail to show the Maps component.

#### Protocols - Multi-threaded timers: Empty poll groups would cause SLProtocol to send empty SNMP requests to SLSNMPManager [ID_33900]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When multi-threaded timers were used in an SNMP protocol, the timer would incorrectly always execute the poll group, even if it did not specify any OIDs to be polled.

From now on, an empty group will no longer cause SLProtocol to send an empty SNMP request to SLSNMPManager.

#### Problem when deserializing an overridden parameter description [ID_34266]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When a JSON string containing an overridden parameter description was deserialized to an ElementInfo message, in some cases, an exception would be thrown.

#### Interactive Automation scripts: Problem when entering an invalid value in a numeric component [ID_34310]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you entered an invalid value in a numeric component, the *UIResults.GetString()* method would incorrectly not return that invalid value. Instead, it returned the last valid value that had been entered.

#### Dashboards app - Service definition component: Function type 'TimeStartEvent' would not be visualized correctly [34316]

<!-- Main Release Version 10.3.0 - Feature Release Version 10.2.11 -->
<!-- Not added to 10.3.0 -->

When a Process Automation definition is added to the Service definition component, the added function shapes will reflect the function type (UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent or EndEvent). However, in some cases, the function type *TimeStartEvent* would not be visualized correctly. From now on, these will be assigned a BPMN reference time icon.

#### Dashboards app / Low-code apps: Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated [ID_34368]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

Creating a custom theme with a custom color palette would incorrectly cause the color palette of all built-in themes to be updated.

#### Dashboards app: Email reports would incorrectly not include CSV files when the 'Include CSV' option had been selected [ID_34370]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, email reports would incorrectly not include CSV files when the *Include CSV* option had been selected.

#### Low-code apps: Problem when creating a new component theme [ID_34372]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When you created a new component theme while a built-in dashboard theme was active, in some cases, a Web Services API error could occur.

#### Problem with SLProtocol when reading incorrectly configured port settings [ID_34379]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur in SLProtocol when reading incorrectly configured port settings.

#### Dashboards app: URL parameter data would not be parsed correctly [ID_34380]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, parameter data in a dashboard URL would incorrectly only get parsed when followed by a forward slash ("/").

#### Dashboards app: Renaming, duplicating or importing a dashboard would break the feeds inside the queries used in that dashboard [ID_34382]

<!-- MR 10.3.0 - FR 10.2.11 -->

When you renamed, duplicated or imported a dashboard, in some cases, the feeds inside the queries used in that dashboard would get broken.

#### Problem with SLLog when closing a log file [ID_34385]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur in SLLog when closing a log file.

#### Failover: Incorrect 'Cluster name of agents doesn't match' error when main agent was unable to make contact with the offline agent [ID_34393]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

When the online agent was unable to make contact with the backup agent, the failover status window could incorrectly show a "Cluster name of agents doesn't match" error.

#### Dashboards app: Sharing menu would incorrectly contain a 'Copy URL' command in HTTP setups [ID_34395]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In HTTP setups, up to now, the dashboard sharing menu would incorrectly contain a non-functioning *Copy URL* command.

From now on, in HTTP setups, the dashboard sharing menu will no longer contain this command.

#### Dashboards app: Problem with invalid URL parameters [ID_34405]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, an error could occur when invalid parameters were passed to a dashboard in the URL (e.g. invalid time spans).

#### Dashboards app: Not possible to access the query column selection box of a newly created query [ID_34410]

<!-- MR 10.2.0 [CU8] - FR 10.2.11 -->

In some cases, it would not be possible to access the query column selection box of a newly created query.

#### Dashboards app: Side panel context menu and selected dashboard would overlap each other [ID_34411]

<!-- MR 10.1.0 [CU20]/10.2.0 [CU8] - FR 10.2.11 -->

When you opened the context menu of the side panel, in some cases, the context menu and the dashboard selected in the list would overlap each other.
