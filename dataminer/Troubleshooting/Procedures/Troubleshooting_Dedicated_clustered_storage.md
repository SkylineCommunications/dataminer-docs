---
uid: Troubleshooting_Dedicated_clustered_storage
---

# Troubleshooting – Dedicated clustered storage health

When using **dedicated clustered storage** (not recommended), both the **Cassandra** and **OpenSearch** clusters must be healthy to ensure full system functionality. DataMiner includes built-in monitoring for these database types, which is used to determine when to offload data to disk to prevent data loss.

This overview explains how to interpret the health monitoring information and troubleshoot issues effectively.

Initially, issues will be reported through the error alarms. The log files can be consulted to find previous outages back.

## Error alarms

DataMiner will notify you of problems with your database clusters through error alarms.
Some examples for OpenSearch (the same format is used for Cassandra):

`Search cluster (OpenSearch Indexing) health is green. Search cluster is fully available.`

`Search cluster (OpenSearch Indexing) health is yellow. DataMiner is still fully functional. 1 out of 3 Search nodes are unavailable: http://172.16.0.101:9200/ - DOWN - IMPACTING.`

`Search cluster (OpenSearch Indexing) health is red. Search cluster is no longer available. 3 out of 3 Search nodes are unavailable: http://172.16.0.101:9200/ - DOWN - IMPACTING, http://172.16.0.102:9200/ - DOWN - IMPACTING, http://172.16.0.103:9200/ - DOWN - IMPACTING.`

## Logging

The same information, but formatted in a more compact fashion, can be found in the log files SLCassandraHealth.txt and SLSearchHealth.txt:

`Health of OpenSearch Indexing: GREEN - [UP(3): http://172.16.0.101:9200/ - UP - IMPACTING; http://172.16.0.102:9200/ - UP - NOT IMPACTING; http://172.16.0.103:9200/ - UP - IMPACTING] - [DOWN(0): ]`

`Health of OpenSearch Indexing: YELLOW - [UP(2): http://172.16.0.102:9200/ - UP - NOT IMPACTING; http://172.16.0.103:9200/ - UP - IMPACTING] - [DOWN(1): http://172.16.0.101:9200/ - DOWN - IMPACTING]`

`Health of OpenSearch Indexing: RED - [UP(0): ] - [DOWN(3): http://172.16.0.101:9200/ - DOWN - IMPACTING; http://172.16.0.102:9200/ - DOWN - IMPACTING; http://172.16.0.103:9200/ - DOWN - IMPACTING]`

## Impacting vs Not Impacting

**IMPACTING** and **NOT IMPACTING** nodes add a bit more complexity for OpenSearch health calculations:

- **IMPACTING** nodes store data and are critical for search functionality.
- **NOT IMPACTING** nodes typically serve as master/manager nodes and do not store data.

This distinction is important when evaluating cluster health, especially when determining whether the system can continue functioning without certain nodes.

## Health status determination

### General

- GREEN: All nodes are available.
- YELLOW / RED: One or more nodes are down. The threshold depends on the database type.

### Cassandra

The used threshold is the lowest *node failure tolerancy*. The *node failure tolerancy* is determined per datatype based on the consistency level and replication factor.

- YELLOW: More nodes are available than the lowest *node failure tolerancy*.
- RED: Fewer nodes are available than the lowest *node failure tolerancy*.

### Search

The used threshold is the lowest amount of primary shards (since every index can have a different amount of primary shards) in comparison to the amount of UP IMPACTING nodes.

- YELLOW: More impacting nodes are available than the lowest amount of primary shards.
- RED: Fewer impacting nodes are available than the lowest amount of primary shards.

## Additional notes

- RED status triggers file offload mode, indicated by a notice alarm:
"x storages are in file offload mode:..."

- A notice may be generated if not all OpenSearch cluster nodes are listed in db.xml. This does not necessarily indicate a problem but should be reviewed during troubleshooting.
