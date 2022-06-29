---
uid: Cassandra_firewall
---

# Firewall ports used with Cassandra

The following ports should be opened in the firewall, depending on your setup:

- **7000 or 7001**: Inter-node communication will go over port 7000 (or 7001 if TLS/SSL is enabled). This port should therefore be opened on the servers hosting Cassandra.

- **9042**: By default, Cassandra will communicate with clients over TCP port 9042. For DataMiner Systems with **single-node Cassandra systems, this port is not required** (unless DataMiner Failover is active).

> [!NOTE]
> In addition, port 7199 can also be used as the Cassandra JMX monitoring port, but this is not required. Opening this port can be useful for troubleshooting, in case you want to be able to run nodetool commands in case Cassandra is installed on a different server than DataMiner.
