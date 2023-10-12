---
uid: BPA_Cassandra_DB_Size
---

# Cassandra DB Size

Cassandra has some operational limits regarding the size of its files, for example to keep enough disk space free for compaction. In addition, Skyline might impose some other limits based on previous issues observed in the field.

The *Cassandra DB Size* BPA test checks the size of the local Cassandra file system against a predefined set of rules. You can find information about this BPA test below.

This BPA test is available on demand. You can [run it in System Center](xref:Running_BPA_tests) (on the *Agents > BPA* tab, available from DataMiner 9.6.0 CU23, 10.0.0 CU13, 10.1.0 CU2 and 10.1.4 onwards). From DataMiner 10.1.4 onwards, it is available by default.

> [!NOTE]
> This BPA test does not work for remote Cassandra nodes or for systems with a Cassandra Cluster setup.

## Metadata

- Name: Cassandra DB Size
- Description: Compares the Cassandra file system against a set of rules
- Author: Skyline Communications
- Default schedule: Every hour

## Results

### Success

None of the files in the Cassandra file system violated any of the rules.

- Result message: No problems detected related to the Cassandra DB size.
- Detailed result: No problems detected related to the Cassandra DB size.
- Impact: None
- Corrective action: None

### Error

One or more of the critical rules have been violated (see [Critical rules](#critical-rules) below)

- Result message: Cassandra DB size errors detected.
- Impact: Cassandra operations (i.e. read/write/compaction/repair/…) will fail.

Each rule violation will be described in detail in the *Detailed Result* and *Corrective Action* field. The following list shows what kind of detailed result will be added for each rule.

- Free disk space < Total size of table

  - Detailed result: Not enough disk space free on disk [Driveletter].
  - Corrective action: Have at least [MinRequiredSpace] MB free on disk [DriveLetter].

- KeySpace not found

  - Detailed result: Could not find the [KeySpaceName] keyspace.
  - Corrective action: Make sure *DB.xml* is configured correctly and DataMiner was able to create the keyspace.

### Warning

One or more of the warning rules has been violated (see [Warning rules](#warning-rules) below)

- Result message: Cassandra DB size issues detected.
- Impact: DataMiner performance degradation is possible.

Each rule violation will be described in detail in the *Detailed Result* and *Corrective Action* field. The following list shows what kind of detailed result will be added for each rule.

- Largest SSTable file for a table > 1/3 of the total installed RAM

  - Detailed result: System might not have enough RAM to process [Tablename].
  - Corrective action: Have at least [MinRamRequired] GB of RAM installed or reduce the amount of data in [Tablename].

- Duplicate folders detected

  - Detailed result: Duplicate folders detected for [Tablename]
  - Corrective action: Remove unused folders

- Large partitions detected

  - Detailed result: Large partitions detected for table [Tablename] Partitions: [Tablename:Partition_key] - size: [Partition_size]
  - Corrective action: Reduce the amount of data in these tables/partitions

### Not Executed

These are the messages that can appear when the test fails to execute for unexpected reasons and cannot provide a conclusive report because of this:

`Could not execute test ([message])` (on unexpected exceptions).

In the message above, the exception message is included (e.g. "Access Denied"). The test result details contain the full exception text, if available.

`Unable to detect any Cassandra installation on the system`

When no Cassandra database is installed on the system or the installed Cassandra database is not the active database for the DMA, the test will halt execution and report this.

## List of rules being checked

### Critical rules

- Compaction DiskSpace Check

  - Amount of free disk space > total size used by a table on that disk.

- Keyspace exists

  - Checks if the defined keyspace exists in the folder structure.

### Warning rules

- SSTable size check

  - Largest SSTable for a table < 1/3 of the total installed RAM.

- Duplicate folder check

  - Checks if the folder structure does not contain multiple folders for the same name.

- Large partitions check

  - Checks Cassandra logs for lines `BigTableWriter.java:197 - Writing large partition <table:key> (<size>)`.
  - Checks the metric `Compacted partition maximum bytes` returned by the command `nodetool.bat tablestats` for every table.
  - Generates a warning if the reported value exceeds the setting `compaction_large_partition_warning_threshold_mb` in cassandra.yaml. The default value is 100 MB.

## Limitations

The BPA can only check local database installations. It will fail for remote Cassandra servers.
