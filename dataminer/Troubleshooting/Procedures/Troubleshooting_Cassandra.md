---
uid: Troubleshooting_Cassandra
---

# Troubleshooting – Cassandra

In case self-managed storage is used (not recommended), Cassandra or a Cassandra-compatible database service is needed, which DataMiner will use in various ways. Each way has its specific behavior and place within a DataMiner System.

Self-managed storage can use two distinct types of Cassandra databases:

- Dedicated clustered storage:, called *Cassandra Cluster* below.
- Storage per DMA (with or without indexing), called *Cassandra Single* below.

> [!TIP]
> For more information on available storage options, see [About storage](xref:About_storage).

## Determining the type of setup

When you start troubleshooting, you first need to determine whether the setup uses *Cassandra Cluster* or *Cassandra Single*. There are some key differences between the two that are important for your investigation.

To do so, in DataMiner Cube, go to *System Center* > *Database* > *Type*:

- If the type is *database per cluster*, *Cassandra Cluster* (i.e., *dedicated clustered storage*) is used.
- If the type is *Cassandra*, *Cassandra Single* (i.e., *Storage Per DMA*) is used.

## Architecture

- *Cassandra Single*:

  - In case of a Failover system, a healthy *Cassandra Single* system has two clustered nodes with replication factor "2" and replication strategy "simple strategy".

  - If there are no Failover Agents, each Agent is a single Cassandra node that is not clustered with the other Cassandra nodes linked to DataMiner.

- *Cassandra Cluster*: The number of nodes depends on the configuration.

## Issue symptoms

- DataMiner fails to start up. Errors can be found in the *SLDBConnection.txt* log file.

- Elements fail to start and are in status "Error".

- In the Alarm Console, the following alarms are shown:

  - Error alarm with value "General database failure, failed to initialize..."
  - Error alarm mentioning "DataMiner goes into offload mode"

    > [!NOTE]
    > This error may also be caused by other databases, such as OpenSearch or Elasticsearch (note that the latter is no longer recommended).

- The SLDataGateway process is leaking memory.

## Prerequisites and required tools for troubleshooting

- A *Microsoft Platform* element for each DMA server

  - Trending must be enabled.
  - Can be used to detect memory leaks.

- A query tool of your choice.

  In legacy systems, DevCenter is typically used, but this tool is no longer supported. [DbVisualizer](https://www.dbvis.com/) is a possible alternative.

- Notepad++ (optional)

  - Helps format and read the *Cassandra.yaml*, *debug.log*, and *system.log* files.

## Investigation

### Data collection during occurrence

- LogCollector package, including SLDataGateway memory dump

- *Cassandra Single*:

  - Logging (*debug.log* and *system.log*) of the affected database is included in the LogCollector package.

- *Cassandra Cluster*:

  - Manually collect *debug.log* and *system.log* from the machine hosting the database.
  - Check if the time when the issue occurred can be found in the log files.

### Basic debugging

1. Check *SLCassandraHealth.txt* in `C:\Skyline DataMiner\Logging`.

   - Green: All is well.
   - Red: The database is down and needs to be looked at.

1. Check the *SLDBConnection.txt* log in `C:\Skyline DataMiner\Logging`.

   Look for a line saying `Failed to fetch max alarm ID`.

1. Verify whether all nodes are running fine by checking their status in *nodetool*.

   - UN (or up/normal): The node is running fine.
   - DN: The node is down. In some cases, this can mean data loss is occurring.

1. Check the Cassandra log files.

   The most important log files are *debug.log* and *system.log*. For an overview of all log files, see [Cassandra Logs](https://cassandra.apache.org/doc/latest/cassandra/troubleshooting/reading_logs.html).

   In a *Cassandra Cluster* setup, on a Linux node, these files can mostly be found in `/var/log/cassandra`. In a *Cassandra Single* setup, these can be found in `C:\Program Files\Cassandra\logs`.

   Search for "tombstone" or "timeout" in *debug.log* and *system.log*. This is particularly relevant if elements are unable to start or if element data is missing (see [Element fails to start because of database failure](xref:Cassandra_General_DB_Failure)).

   Tombstones are created upon adding/updating/deleting a null value toward the database. They correspond with a "delete" in Cassandra and drastically decrease read performance. They also take up space.

   Cassandra has a process called "compaction", which, among other things, removes these tombstones. If, for any reason, the number of tombstones becomes too large, reads may eventually time out or fail altogether (see *tombstone_failure_threshold* in [Installing Cassandra on a Linux machine](xref:Installing_Cassandra)).

   If a tombstone problem or a timeout is detected, the query that causes this will be logged. Make a note of this.

## Common configuration issues

- The machines hosting the databases do not meet the **system requirements**. See [DataMiner Compute Requirements](xref:DataMiner_Compute_Requirements).

  - Cassandra typically needs at least 32 GB of RAM on a production setup. On a staging setup, you may be able to get away with 16 GB of RAM.
  - Cassandra disks may not be on a NAS or similar technology. Attaching the storage to the network is forbidden.
  - Cassandra needs low latency and high bandwidth to work.
  - The Cassandra servers all need to have the exact same time. Time differences between servers in a Cassandra cluster may lead to reads/writes not being executed. NTP can be used to synchronize the time settings.

- The system has **not been customized** to use the available resources.

  - The heap size has not been set.
  
    - The rule of thumb is to use half the available RAM as heap size.

      - If your Cassandra node has 32 GB of RAM, the usual setup with DataMiner has a heap size of 16 GB.
      - If your Cassandra node has 16 GB of RAM, the usual setup with DataMiner has a heap size of 8 GB.

    - There are different procedures for Windows and Linux:

      - For Windows, refer to the instructions for configuring the heap size under [After the migration](xref:Migrating_the_general_database_to_Cassandra#after-the-migration).
      - For Linux, change the XmX and Xms parameters in *jvm.options*. See *Setting the heap space* in [Maintaining a Cassandra cluster](xref:Maintain_Cassandra_Cluster#setting-the-heap-space).

    - If you do not set the heap size, Cassandra will automatically set it to a quarter of the available RAM (capped to 8 GB).
  
  - The maximum possible *tombstone_failure_threshold* has not been set.
  
    - On Windows: 100 000
    - On Linux: 2 000 000

    For more information, refer to the information on configuring the *cassandra.yaml* and the *cassandra-rackdc.properties* files under [Installing Cassandra on a Linux machine](xref:Installing_Cassandra).

- The trend data **TTL is changed too often** in a *Cassandra Cluster* setup.

  - To set the trend data TTL, open DataMiner Cube, and go to *System Center* > *System settings* > *time to live* > *Trending*.
  - We recommend against changing this setting on a production cluster using *Cassandra Cluster*.
  - When you **decrease** the TTL:

    - Data will be kept until the previous, higher TTL has expired.
    - Manual actions will need to be executed. For example, enabling the *unsafe_aggressive_sstable_expiration* option for Cassandra (see [Time Window CompactionStrategy](https://cassandra.apache.org/doc/stable/cassandra/operating/compaction/twcs.html)) or manually removing the already expired *sstables* on disk.

      > [!IMPORTANT]
      > If you do not feel confident executing these actions, contact your Skyline representative for assistance.

  - When you **increase** the TTL, note that old data will still expire with the old, smaller TTL, as only new data will be written with the higher TTL.

- Prior to DataMiner 10.4.0 [CU11]/10.5.2<!--RN 41551-->, changes to Cassandra compaction settings, such as the *unsafe_aggressive_sstable_expiration* option, may be incorrectly overwritten by the default settings during DataMiner startup. This issue applies only to manually configured Cassandra systems.
