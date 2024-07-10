---
uid: Cassandra_expired_blocking_SSTables
---

# Expired SSTables blocking other tables from being dropped

In case the only data SSTables in Cassandra contain is tombstones, and the tables are therefore expired, they could block other tables that are also expired from being dropped.

To resolve this issue, you can enable the *unsafe_aggressive_sstable_expiration* option for the Cassandra database. This is something that should only be done to troubleshoot this issue, because it is considered a risky option otherwise. The data in the expired SSTables will be dropped without being checked, but as it consists entirely of tombstone data in this case, this is not a problem.

To enable this option, follow the steps below.

> [!NOTE]
> Ideally, this should be done on one node at a time to reduce the downtime for the Cassandra Cluster. However, whether your cluster can cope with one node being down at a time depends on its configuration and architecture. To check this, you can use the [ecyrd.com Cassandra calculator](https://www.ecyrd.com/cassandracalculator/).

1. Access the Cassandra node where you want to enable this option, for instance via SSH.

1. Navigate to `/etc/cassandra`.

1. Access the Environment Variable file, which is usually named *cassandra-env.sh*.

1. Make sure the following entry is added in the file:

   `JVM_OPTS="$JVM_OPTS -Dcassandra.allow_unsafe_aggressive_sstable_expiration=true"`

1. Restart the node.

1. Repeat the steps above for each of the nodes in the Cassandra Cluster.

1. Open a connection to the Cassandra nodes via DevCenter.

1. Send the following query for all TWCS keyspaces:

   ```txt
   ALTER TABLE PREFIXPLACEHOLDER_trend_data_medium.trend_data_medium
   with compaction = {
   'class' : 'TimeWindowCompactionStrategy',
   'unsafe_aggressive_sstable_expiration' : true
   };
   ```

   In most cases, you will need to run this query for the following tables:

   - PREFIXPLACEHOLDER_trend_data_long
   - PREFIXPLACEHOLDER_trend_data_medium
   - PREFIXPLACEHOLDER_trend_data_rt
   - PREFIXPLACEHOLDER_trend_data_short

   To find out what the PREFIXPLACEHOLDER is, navigate to cd /data/cassandra/data.
