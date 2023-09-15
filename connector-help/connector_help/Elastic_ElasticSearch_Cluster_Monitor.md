---
uid: Connector_help_Elastic_ElasticSearch_Cluster_Monitor
---

# Elastic ElasticSearch Cluster Monitor

This connector can be used to monitor the health of an Elasticsearch cluster. It performs specific HTTP queries directly to one of the Elasticsearch nodes in the cluster.

## About

The HTTP queries performed by this connector are intended to retrieve metrics that provide information on the current health status of the Elasticsearch cluster.

The scope of these health metrics includes general cluster and node metrics and statistical information related to node indexing and systems (operating system, file system, Java Virtual Machine, etc.).

### Version Info

| Range | Description | DCF Integration | Cassandra Compliant |
|------------------|-----------------|---------------------|-------------------------|
| 1.0.0.x          | Initial version | No                  | Yes                     |

### Product Info

| Range | Supported Firmware Version |
|------------------|-----------------------------|
| 1.0.0.x          | Unknown                     |

## Installation and configuration

### Creation

#### HTTP Main Connection

This connector uses an HTTP connection and requires the following input during element creation:

HTTP CONNECTION:

- **IP address/host**: The polling IP of the Elasticsearch cluster.
- **IP port**: The IP port of Elasticsearch, by default *9200*.

## Usage

### General

This page displays **general cluster health** information, including the cluster name and status, and the number of nodes and shards.

### Cluster Stats - Nodes

This page contains **general information** regarding the **cluster nodes**, such as node communication statistics and virtual machine memory usage.

The page contains a page button that displays additional general information related to the operating and file systems of the nodes.

### Cluster Stats - Indices

This page contains **general information** regarding the **cluster indices**, such as shard and document storage statistics.

The page contains page buttons to the following subpages:

- **Shards Health**: Contains health info on shard level, such as the state of each of the shards.
- **Indices Health**: Contains health info on index level, such as the status, the number of active shards and the primary shards related to a particular index.
- **Indices - Cache/Segments**: Provides additional general information related to the cache and segments of the indices.

### Index Shards Level Overview

This page contains a **tree view** that provides an overview of the **health status** of the cluster **indices and shards**. The tree view is based on the tables available via the Indices and Shards Health page buttons mentioned above.

### Index Overview

This page displays a table with an **overview** of the **cluster indices**, containing information such as the associated document count, the stored size and other status info.

### Node Stats - General

This page displays **general node information**, such as the name and IP addresses.

### Node Stats - Indices

This page and its page buttons display tables with statistics regarding each node **index operation** (search, merge, etc.), **cache memory** and **information storage** (field data, segments).

### Node Stats - OS / Processes

This page displays a table with information regarding each node's **operating system** and **process** **statistics**.

### Node Stats - JVM

This page contains tables that display memory, threads, garbage collector and buffer pools **statistics** regarding each node's **Java Virtual Machine**.

### Node Stats - Thread Pool (including pages II & III)

This page contains information related to the different **thread pools** contained within each node.

### Node Stats - File System

This page contains tables with information regarding each node's **file system** data and memory **statistics**.

### Node Stats - Communications

This page contains statistical information related to **HTTP** and **transport layer** communication.

### Node Stats - Circuit Breakers

This page contains tables with information related to the various types of **circuit breakers** for each node.

### Node Stats - Other

This page contains tables with information related to the nodes' **script**, **discovery** and **ingest** features.
