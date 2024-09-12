---
uid: General_Main_Release_10.3.0_CU20
---

# General Main Release 10.3.0 CU20 – Preview

> [!IMPORTANT]
> We are still working on this release. Some release notes may still be modified or moved to a later release. Check back soon for updates!

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

### Enhancements

#### Failover: Virtual IP address check will now use both a ping and an arp command to check whether an IP address is free [ID 40516]

<!-- MR 10.3.0 [CU20]/10.4.0 [CU8] - FR 10.4.11 -->

Up to now, on systems that do not allow ping commands to be executed, in some cases, the virtual IP address check would incorrectly conclude that the IP address was free and decide to claim it, causing the network interface card to malfunction due to IP addresses not being unique.

From now on, when the virtual IP address check has concluded that the IP address is free after having executed the required number of ping commands, it will double-check by executing an arp command.

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
