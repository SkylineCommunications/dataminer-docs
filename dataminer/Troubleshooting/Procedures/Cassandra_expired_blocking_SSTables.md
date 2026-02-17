---
uid: Cassandra_expired_blocking_SSTables
---

# Expired SSTables blocking other tables from being dropped

When **TWCS** is used in Cassandra, ideally only data is inserted with a new primary key, all with the same TTL. If updates happen in TWCS tables (e.g., insert with the same primary key), then it is possible that a **newer bucket contains an updated entry that was originally created in an older bucket**. The older bucket will then be **blocked** until the newer bucket is fully expired. If this keeps on happening, it could happen that you end up in a **situation where SSTables can never expire** as they are each time blocked by a newer SSTable. This could result in various issues, such as an increase in the disk usage of the Cassandra data partition, or a continuous increase of the size of the TWCS keyspaces on the disk (trend_data_medium, trend_data_short, and trend_data_long).

In case the only data SSTables in Cassandra contain is tombstones, and the tables are therefore expired, they could **block other tables that are also expired from being dropped**. This could result in various issues, such as an increase in the disk usage of the Cassandra data partition or a continuous increase of the size of the TWCS keyspaces on the disk (trend_data_medium, trend_data_short, and trend_data_long).

You can **check if you are indeed encountering this issue** using the Cassandra tools, for example with the following commands on **Linux**:

> [!CAUTION]
> These commands will temporarily stop the Cassandra service, which will likely have an impact on the functionality of the DataMiner System making use of the database.

- On a RHEL-based system:

  ```txt
  yum install cassandra-tools

  sudo systemctl stop cassandra

  sstableexpiredblockers zm1_cc_trend_data_short trend_data_short

  for f in *Data.db; do meta=$(sudo sstablemetadata $f); echo -e "Max:" $(date --date=@$(echo "$meta" | grep Maximum\ time | cut -d" " -f3| cut -c 1-10) '+%m/%d/%Y') "Min:" $(date --date=@$(echo "$meta" | grep Minimum\ time | cut -d" " -f3| cut -c 1-10) '+%m/%d/%Y') $(echo "$meta" | grep droppable) ' \t ' $(ls -lh $f | awk '{print $5" "$6" "$7" "$8" "$9}'); done | sort

  sudo systemctl start cassandra
  ```

- On a Debian-based system:

  ```txt
  sudo apt-get install cassandra-tools

  sudo systemctl stop cassandra

  sstableexpiredblockers zm1_cc_trend_data_short trend_data_short

  for f in *Data.db; do meta=$(sudo sstablemetadata $f); echo -e "Max:" $(date --date=@$(echo "$meta" | grep Maximum\ time | cut -d" " -f3| cut -c 1-10) '+%m/%d/%Y') "Min:" $(date --date=@$(echo "$meta" | grep Minimum\ time | cut -d" " -f3| cut -c 1-10) '+%m/%d/%Y') $(echo "$meta" | grep droppable) ' \t ' $(ls -lh $f | awk '{print $5" "$6" "$7" "$8" "$9}'); done | sort

  sudo systemctl start cassandra
  ```

With the output of the sstableexpiredblockers, you can see which tables are blocking others from being dropped. If the percentage of tombstones in the SSTable is higher than 1, you can assume that all data is tombstone data.

To **resolve this issue, we recommend enabling the *unsafe_aggressive_sstable_expiration* option** for the Cassandra database. Enabling this option on a table could lead to inconsistencies (data loss or re-appearing) when deletes/updates are done on the data in TWCS tables. However, in general, deletes and updates should be avoided on tables with TWCS, and you should always rely on TTL, as doing otherwise could result in the present blocking tables issue.

To enable this option, follow the steps below. These steps are intended for a **Linux** system, since this is the recommended operating system for a Cassandra cluster.

> [!NOTE]
> Ideally, this should be done on **one node at a time** to reduce the downtime for the Cassandra Cluster. However, whether your cluster can cope with one node being down at a time depends on its configuration and architecture. To check this, you can use the [ecyrd.com Cassandra calculator](https://www.ecyrd.com/cassandracalculator/).

1. Access the Cassandra node where you want to enable this option, for instance via SSH.

1. Navigate to `/etc/cassandra`.

1. Access the Environment Variable file, which is usually named *cassandra-env.sh*.

1. Make sure the following entry is added in the file:

   `JVM_OPTS="$JVM_OPTS -Dcassandra.allow_unsafe_aggressive_sstable_expiration=true"`

1. Restart the node.

1. Repeat the steps above for each of the nodes in the Cassandra Cluster.

1. Look up Cassandra's PREFIXPLACEHOLDER, as you will need to run queries on the following keyspaces:

   - PREFIXPLACEHOLDER_trend_data_long
   - PREFIXPLACEHOLDER_trend_data_medium
   - PREFIXPLACEHOLDER_trend_data_rt
   - PREFIXPLACEHOLDER_trend_data_short

   To find out what the PREFIXPLACEHOLDER is, navigate to the `/data/cassandra/data` folder and check the name used in that folder.

1. Open a connection to the Cassandra nodes using a query tool of your choice.

1. Execute the following queries one by one and save the contents of the "compaction" column:

   - select * from system_schema.tables where keyspace_name='PREFIXPLACEHOLDER_trend_data_long';
   - select * from system_schema.tables where keyspace_name='PREFIXPLACEHOLDER_trend_data_medium';
   - select * from system_schema.tables where keyspace_name='PREFIXPLACEHOLDER_trend_data_short';
   - select * from system_schema.tables where keyspace_name='PREFIXPLACEHOLDER_trend_data_rt';

   The output should look like the examples below, with a different `compaction_window_size` for each different trend type. Take note here of the values in `compaction_window_size` and `compaction_window_unit`.

   - Example: output for PREFIXPLACEHOLDER_trend_data_long

   ```txt
   {
     "class" : "org.apache.cassandra.db.compaction.TimeWindowCompactionStrategy",
     "compaction_window_size" : "30",
     "compaction_window_unit" : "DAYS",
     "max_threshold" : "32",
     "min_threshold" : "4"
   }
   ```

   -Example: output for PREFIXPLACEHOLDER_trend_data_short. Note the difference in `compaction_window_size`.

   ```txt
   {
     "class" : "org.apache.cassandra.db.compaction.TimeWindowCompactionStrategy",
     "compaction_window_size" : "4",
     "compaction_window_unit" : "DAYS",
     "max_threshold" : "32",
     "min_threshold" : "4"
   }
   ```

1. Execute the query below for all of the keyspaces, filling in the corresponding `compaction_window_size` and `compaction_window_unit` for each trend data table (as found in the queries mentioned above).

   For example, to match the example output shown above, fill in a `compaction_window_size` of "4" for trend_data_short, and "30" for trend_data_long.

   ```txt
   ALTER TABLE PREFIXPLACEHOLDER_trend_data_short.trend_data_short
   with compaction = {
   'class' : 'TimeWindowCompactionStrategy',
   'unsafe_aggressive_sstable_expiration' : true,
   'compaction_window_size' : '4',
   'compaction_window_unit' : 'DAYS',
   };
   ```

   Do the same for the other keyspaces, taking into account the `compaction_window_size` and `compaction_window_unit`.

   - PREFIXPLACEHOLDER_trend_data_long

     Example:

     ```txt
     ALTER TABLE PREFIXPLACEHOLDER_trend_data_long.trend_data_long
     with compaction = {
     'class' : 'TimeWindowCompactionStrategy',
     'unsafe_aggressive_sstable_expiration' : true,
     'compaction_window_size' : '30',
     'compaction_window_unit' : 'DAYS',
     };
     ```

   - PREFIXPLACEHOLDER_trend_data_medium

     Example:

     ```txt
     ALTER TABLE PREFIXPLACEHOLDER_trend_data_medium.trend_data_medium
     with compaction = {
     'class' : 'TimeWindowCompactionStrategy',
     'unsafe_aggressive_sstable_expiration' : true,
     'compaction_window_size' : '14',
     'compaction_window_unit' : 'DAYS',
     };

   - PREFIXPLACEHOLDER_trend_data_rt

     Example:

     ```txt
     ALTER TABLE PREFIXPLACEHOLDER_trend_data_rt.trend_data_rt
     with compaction = {
     'class' : 'TimeWindowCompactionStrategy',
     'unsafe_aggressive_sstable_expiration' : true,
     'compaction_window_size' : '3',
     'compaction_window_unit' : 'HOURS',
     };
