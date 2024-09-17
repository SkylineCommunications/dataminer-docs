---
uid: General_Main_Release_10.4.0_CU8
---

# General Main Release 10.4.0 CU8 - Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Failover: Virtual IP address check will now use both a ping and an arp command to check whether an IP address is free [ID 40516]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, on systems that do not allow ping commands to be executed, in some cases, the virtual IP address check would incorrectly conclude that the IP address was free and decide to claim it, causing the network interface card to malfunction due to IP addresses not being unique.

From now on, when the virtual IP address check has concluded that the IP address is free after having executed the required number of ping commands, it will double-check by executing an arp command.

#### Automation: Enhanced locking when calling 'SetParameter' and 'GetParameter' on an element [ID 40682]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

A number of enhancements have been made to the locking behavior in the SLAutomation process in order to prevent unnecessary holdups when interacting with the `Engine` and related `Element` objects in Automation scripts.

The following calls have been improved:

- `element.SetParameter` and associated methods:

  - `ConnectMatrixCrosspoint`
  - `DisconnectMatrixCrosspoint`
  - `SetParameterByPrimaryKey`

- `element.GetParameter` and associated methods:

  - `GetMatrixInputForOutput`
  - `GetParameterByPrimaryKey`
  - `GetParameterDisplay`
  - `GetParameterDisplayByPrimaryKey`
  - `IsMatrixCrosspointConnected`

#### SLAnalytics will now wait longer for a message from SLNet announcing that it has finished loading the configuration [ID 40729]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When starting up, up to now, SLAnalytics would wait up to 400 seconds for a message from SLNet announcing that it has finished loading the configuration. From now on, it will wait up to 20 minutes.

#### SLAnalytics: Maximum number of parameter changes that can be processed has increased from 5000 per second to 1 million per second [ID 40730]

<!-- MR 10.4.0 [CU8] - FR 10.4.11 -->

Because of a number of enhancements, the maximum number of parameter changes that can be processed by SLAnalytics has increased from 5000 per second to 1 million per second.

### Fixes

#### ReIndexElasticSearchIndexes tool would incorrectly overwrite the existing mapping by the default mappings [ID 40073]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When the *ReIndexElasticSearchIndexes* tool was run, the existing mappings (which define how types should be handled) would incorrectly be overwritten by the default mappings. From now on, the existing mappings will be correctly passed from source database to destination database.

#### Logger tables and slatable data would not be deleted from the Cassandra Cluster database when the associated element was deleted [ID 40523]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

If an element had logger tables that were stored in a database of type *CassandraCluster*, up to now, those logger tables would not be deleted from the database when the element was deleted.

Similarly, when an SLA element was deleted, the data in the slatable associated with that element would not be deleted.

#### SLAnalytics would get blocked for too long when it failed to perform a database operation [ID 40603]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When SLAnalytics fails to perform a database operation, it will retry the same operation several times before eventually giving up. While SLAnalytics is performing those retries, the cache will get blocked, causing all SLAnalytics functionality that relies on that cache to also get blocked.

In order to prevent SLAnalytics from getting blocked for too long and from taking up too much memory, from now on, SLAnalytics will perform less retries if the previous database operation it performed in the last hour also failed.

#### Service & Resource Management: Problem when retrieving resource pools with a property filter [ID 40642]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When resource pools were retrieved with a property filter, and one of the resource pools had "null" properties, a `NullReferenceException` would be thrown and no resource pools would be returned.

> [!NOTE]
> The above-mentioned exception would only be thrown when, instead of `FilterElements`, (deprecated) object filters were being used.

#### Maps: Filter would incorrectly be altered when the filter pane was collapsed [ID 40660]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

When you collapsed the filter pane, in that filter pane, the text box would be cleared and all alarm severity checkboxes would automatically be selected. From now on, when you expand or collapse the filter pane, the text box will no longer be cleared and the checkboxes will no longer be automatically selected.

Also, when you collapse the filter pane, the looking glass icon will now blink blue if a non-default filter is set.
