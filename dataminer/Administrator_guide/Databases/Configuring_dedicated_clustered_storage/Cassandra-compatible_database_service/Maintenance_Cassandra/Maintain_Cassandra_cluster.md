---
uid: Maintain_Cassandra_Cluster
---

# Maintaining a Cassandra cluster

If you choose not to use the recommended [Storage as a Service (STaaS)](xref:STaaS) setup but instead choose self-managed storage, you are responsible for maintaining and monitoring the database used for DataMiner system storage. With a Cassandra cluster setup, this involves setting the heap space, monitoring the database, keeping the nodes repaired, and keeping the software up to date.

## Setting the heap space

To ensure that your Cassandra database does not run out of memory under load, in the *jvm-server.options* file, configure the parameters **Xmx** and **Xms** to set the Cassandra heap space.

If the default "CMS" garbage collector is used, the heap space should ideally be between 8 and 16 GB.

For more information on how to tune the resources of Cassandra's Java Virtual Machine, refer to [Tuning the Java heap](https://docs.datastax.com/en/cassandra-oss/3.0/cassandra/operations/opsTuneJVM.html#opsTuneJVM__tuning-the-java-heap).

> [!WARNING]
> Failing to adapt the heap space to the needs of your cluster will cause out of memory events which can affect availability of the DMS.

## Monitoring your database

To ensure that your Cassandra database is running fine, we highly recommend that you create an element using the [Apache Cassandra Cluster Monitor](https://catalog.dataminer.services/details/a1cd0877-d1b9-4905-8e96-53d913af315e) connector.

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
