---
uid: Maintain_Cassandra_Cluster
---

# Maintaining a Cassandra cluster

## Monitoring your database

To ensure that your Cassandra database is running fine, we highly recommend that you create an element using the [Apache Cassandra Cluster Monitor](https://catalog.dataminer.services/result/driver/7500) connector.

> [!NOTE]
> This is currently not supported for AWS Keyspaces or an Azure Managed Instance for Apache Cassandra.

## Keeping your nodes repaired

When nodes are down for longer periods of time or when there has been a network problem, it may happen that data is no longer in sync between nodes holding copies (in case of replication). To ensure that data is synced again, repairs need to be scheduled.

For large-scale clusters, this might be very difficult to manage as you need to avoid that repairs are running on multiple nodes at the same time for specific data. To deal with this, we recommend that you install [Cassandra Reaper](http://cassandra-reaper.io/) in sidecar mode (i.e. install the software on every node).

>[!IMPORTANT]
> It is absolutely essential that you perform repairs on your Cassandra nodes. Not repairing your tables might have severe consequences, as detailed in [Cassandra docs - Repair](https://cassandra.apache.org/doc/4.0/cassandra/operating/repair.html). We highly recommend automating your repairs with Cassandra Reaper as outlined above.

> [!NOTE]
> Tables using TimeWindowCompactionStrategy should be excluded from automated repairs. This applies to the following tables:
>
> - element_state_changes
> - spectrum_sharded
> - state_changes
> - trend_data_rt
> - trend_data_short
> - trend_data_medium
> - trend_data_long
>
> From Reaper v1.4.0 onwards, you can disable repairs on TimeWindowCompactionStrategy tables by setting the **blacklistTwcsTables tag to *true*** in the *cassandra-reaper.yaml* file.

## Keeping the software up to date

We recommend that you update your Cassandra software regularly.

With a replication factor greater than 1, rolling upgrades are possible, so that you can upgrade the Cassandra database without any downtime.

For more information, see [Updating Cassandra](xref:Cassandra_updating).
