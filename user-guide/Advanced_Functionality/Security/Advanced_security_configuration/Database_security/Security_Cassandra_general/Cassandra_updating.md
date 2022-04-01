---
uid: Cassandra_updating
---

# Updating Cassandra

We recommend that you periodically update your Cassandra database to ensure that all known vulnerabilities are fixed.

You can verify your version of Cassandra by executing the following query:

`SELECT cql_version FROM system.local;`

By default, DataMiner installs Cassandra 3.11. However, Cassandra 4.0 is also supported.

> [!NOTE]
> Cassandra 4.0 is no longer supported on Windows, which means that extra Linux servers will be required to host the Cassandra database.
