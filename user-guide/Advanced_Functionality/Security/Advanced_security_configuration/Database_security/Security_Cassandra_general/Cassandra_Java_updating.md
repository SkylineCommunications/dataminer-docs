---
uid: Cassandra_Java_updating
---

# Updating Java for Cassandra

By default, DataMiner installs Cassandra with its own Java installation. This is typically located in *C:\Program Files\Cassandra\Java\bin*. DataMiner deploys Cassandra with **Java 1.8.0_91**.

To update the Java version:

1. Download the latest Java binaries from the official website.

1. Stop your DataMiner Agent.

1. Stop the *Cassandra* service.

1. Update the binaries in *C:\Program Files\Cassandra\Java*.

1. Start the *Cassandra* service.

1. Start your DataMiner Agent.
