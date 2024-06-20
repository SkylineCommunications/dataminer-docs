---
uid: Troubleshooting_Cassandra
---

# Troubleshooting - Cassandra

## Context

DataMiner uses Cassandra in various ways. Each way has its specific behavior and place within a DataMiner System.

We have two types of Cassandra storage, i.e. two distinct types of Cassandra databases:

- Dedicated clustered storage: *Cassandra Cluster*
- Storage per DMA (with or without indexing): *Cassandra Single*

For more information on available storage options, see [About databases](xref:Databases_about).

First and foremost, it is imperative to determine whether the setup is using *Cassandra Cluster* or *Cassandra Single*. When investigating issues, you should keep in mind that there are some key differences between the two.

In DataMiner Cube, go to *System Center > Database > Type*:

- If the type is *database per cluster*, a *Cassandra Cluster* or a *dedicated clustered storage* is being used.
- If the type is *Cassandra*, a *Cassandra Single* or a *Storage Per DMA* is being used.

## Architecture

In case of a Failover system, a healthy *Cassandra Single* system has two clustered nodes with replication factor "2" and replication strategy "simple strategy".

If there are no failover agents, each agent is a single Cassandra node that is not clustered with the other Cassandra nodes linked to DataMiner.

When using a *Cassandra Cluster*, the number of nodes depends on the configuration.

## Symptoms of issues

- DataMiner fails to start up. Errors can be found in the *SLDBConnection.txt* log file.

- Elements fail to start and are in status "Error".

- In the Alarm Console, the following alarms appear:

  - Error alarm with value "General database failure, failed to initialize..."
  - Error alarm mentioning "DataMiner goes into offload mode"

    > [!NOTE]
    > This error may also be caused by other databases (e.g. Elasticsearch).

- The SLDataGateway process is leaking memory.

## Prerequisites and required tools

- *Microsoft Platform* elements

  - Trending must be enabled.
  - Can be used to detect memory leaks.

- DevCenter

  - Allows you to manually query the database.
  - Can be found in *C:\\Program Files\\Cassandra\\DevCenter\\Run DevCenter* (*Cassandra Single*) or can be downloaded from the Apache or DataStax websites.

- Notepad++ (optional)

  - Helps format and read the *Cassandra.yaml*, *debug.log*, and *system.log* files.

## Investigation

### Data collection during occurrence

- LogCollector package, including SLDataGateway memory dump

- Cassandra Single:

  - Logging (*debug.log* and *system.log*) of the affected database is included in the LogCollector package.

- Cassandra Cluster:

  - Manually collect *debug.log* and *system.log* from the machine hosting the database.
  - Check if the time at which the issue occurred can be found in the log files.

### Basic debugging

1. Check *SLCassandraHealth.txt* in *C:\\Skyline DataMiner\\Logging*

   - Green: All is well.
   - Red: The database is down and needs to be looked at.

1. Check *SLDBConnection.txt* log in *C:\\Skyline DataMiner\\Logging*.

   Look for a line saying `Failed to fetch max alarm ID`.

1. Verify whether all nodes are running fine by checking their status in *nodetool*.

   - UN (or up/normal): The node is running fine.
   - DN: The node is down. In some cases, this can mean data is being lost.

1. Check the Cassandra log files. The most important log files are *debug.log* and *system.log*. For an overview of all log files, see [Cassandra Logs](https://cassandra.apache.org/doc/latest/cassandra/troubleshooting/reading_logs.html).

   On a *Cassandra Cluster*, on a Linux node, these files can mostly be found in */var/log/cassandra*. On a *Cassandra Single*, these can be found in *C:\Program Files\Cassandra\logs*.

   Search for "tombstone" or "timeout" in *debug.log* and *system.log*. This is particularly relevant if elements are unable to start or if element data is missing.

   Tombstones are created upon adding/updating/deleting a null value toward the database. They correspond with a "delete" in Cassandra and drastically decrease read performance. They also take up space.

   Cassandra has a process called "compaction", which, among other things, removes these tombstones. If, for any reason, the amount of tombstones becomes too large, reads may eventually time out or fail altogether (see *tombstone_failure_threshold* in [Installing Cassandra on a Linux machine](xref:Installing_Cassandra)).

   If it has been determined that there is a tombstone problem or a timeout, the query that causes this will be logged. Make a note of this.

## Common configuration mistakes

- The machines hosting the databases do not meet the system requirements. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

  - Cassandra typically needs at least 32Gb of RAM on a production setup. On a staging setup, you may be able to get away with 16Gb of RAM.
  - Cassandra disks may not be on a NAS or similar technology. Attaching the storage to the network is forbidden.
  - Cassandra needs low latency and high bandwidth to work.
  - The Cassandra servers all need to have the exact same time. Time differences between servers in a Cassandra Cluster may lead to reads/writes not being executed. NTP may be used to synchronize the time settings.

- The system has not been customized to use the available resources.

  - The heap size has not been set.
  
    - The rule of thumb is to use half the available RAM as heap size.

      - If your Cassandra node has 32 Gb of RAM, the usual setup with DataMiner has a heap size of 16 Gb.
      - If your Cassandra node has 16 Gb of RAM, the usual setup with DataMiner has a heap size of 8 Gb.

    - There are different procedures for Windows and Linux:

      - For Windows, see step 2 of [After the migration](xref:Migrating_the_general_database_to_Cassandra#after-the-migration).
      - For Linux, change the XmX and Xms parameters in *jvm.options*. See *Setting the heap space* in [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster#setting-the-heap-space).

    - If you do not set the heat size, Cassandra will automatically set it to a quarter of the available RAM (capped to 8 Gb).
  
  - The maximum possible *tombstone_failure_threshold* has not been set.
  
    - On Windows: 100000
    - On Linux: 2000000

    See step 6 in [Installing Cassandra on a Linux machine](xref:Installing_Cassandra).

- The trend data TTL is being changed too often in Cassandra Cluster.

  - To set the trend data TLL, open DataMiner Cube, and go to *System Center > System settings > time to live > Trending*.
  - We recommend against changing this setting on a production cluster using *Cassandra Cluster*.
  - When you decrease the TTL:

    - Data will be kept until the previous, higher TTL has expired.
    - Manual actions will need to be executed. For example, enabling the *unsafe_aggressive_sstable_expiration* option for Cassandra (see [Time Window CompactionStrategy](https://cassandra.apache.org/doc/stable/cassandra/operating/compaction/twcs.html)) or manually removing the already expired sstables on disk.

      **To be documented: Request help with this from Skyline for the time being.**

  - When you increase the TTL, note that old data will still expire with the old, smaller TTL as only new data will be written with the higher TTL.
