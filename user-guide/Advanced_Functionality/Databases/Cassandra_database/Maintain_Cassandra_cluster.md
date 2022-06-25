---
uid: Maintain_Cassandra_Cluster
---

# Maintaining Cassandra

- Monitoring your database

  To ensure your Cassandra database is running fine, we highly recommend to use the [Apache Cassandra Cluster Monitor](https://catalog.dataminer.services/result/driver/7500) connector.

- Keep your nodes repaired

  When nodes are down for longer periods of time or there has been a network problems, it may happen that data is no longer in sync between nodes holding copies (in case of replication). To ensure that data is being synced again repairs need to be scheduled. For larger scale clusters this might be very difficult to manage as you need to avoid that repairs are running on multiple nodes at the same time for specific data. That is why it is highly recomended to install [Cassandra Reaper](http://cassandra-reaper.io/). The easiest way to use reaper in a secure way is by installing it in side-car mode (installing the software on every node).

- Upgrade your software regurarly

  Keep your Cassandra software up to date. Rolling upgrades are possible, so that you can upgrade the Cassandra DB without any downtime (RF > 1 needed for this).