---
uid: Cassandra_Cleaner
---

# Cassandra Cleaner

## About this tool

This tool can be used to remove data from the Cassandra *timetrace* or *infotrace* table for a specific time range. This can be useful in case you urgently need to reclaim disk space on a DMA using a Cassandra local database, and you do not want to wait for the TTL of the timetrace or infotrace data (which is by default set to 1 year) to expire.

Do not use this tool unless you have no other option, as DataMiner functionality related to **alarm monitoring with time ranges will no longer work for the deleted time range**. For more information, refer to the FAQ section below. Note that you also need advanced knowledge of Cassandra in order to use this tool.

DataMiner does not need to be stopped to run this tool.

You can download this tool from [DataMiner Dojo](https://community.dataminer.services/download/cassandra-cleaner/).

## Configuring the tool

There are two configuration files present in the root directory of the tool:

- *db.yaml*: Similar to *DB.xml*. Contains information about the database. See [db.yaml](#dbyaml).

- *settings.yaml*: Contains application-specific settings.

If these files are not present, generate them by running the executable with the `generate -c` arguments. As soon as the files have been generated, the tool will stop running. This allows you to first configure the files and then run the tool with the proper configuration.

### db.yaml

The most important settings are the `table.name`, `delete.start.time`, and `delete.end.time` fields.

When the *db.yaml* file is generated, `table.name` is generated with the *timetrace* value. You can change this to the *infotrace* value.

> [!CAUTION]
> All timetrace or infotrace data between the `delete.start.time` and `delete.end.time` timestamps will be deleted, so be careful.

Log levels for both file and console output can be configured with the `logging.level.file` and `logging.level.console` fields. The possible log levels are TRACE, DEBUG, INFO, WARN, ERROR, and FATAL.

> [!NOTE]
> Enabling TRACE logging will log all executed queries and may affect performance.

We recommend throttling the number of concurrent deletes if the system is already under heavy load. Throttling can be achieved by reducing the `queue.max.concurrent.queries` setting. This setting should typically be kept between 10 and 100.

Make sure that the `queue.buffer.size` setting is always at least 5 times greater than the `queue.max.concurrent.queries` setting to guarantee efficient execution.

For example, if you want to keep the last 3 months of data, with a default TTL of 1 year, and the day you are running the program is January 1st, 2020, you should use the following settings:

- `delete.start.time`: 01/01/2019 00:00:00

- `delete.end.time`: 01/10/2019 00:00:00

The format of all timestamps is `dd/MM/yyyy hh:mm:ss`.

> [!NOTE]
> Do not leave the `delete.start.time` field set to 01/01/0001 00:00:00 or any other very old timestamp, as this will cause the program to needlessly scan for data that does not exist.

## Running the tool

Once the *db.yaml* and *settings.yaml* files have been correctly configured, as detailed in the previous section, you can start cleaning the *timetrace* or *infotrace* table.

Depending on the table specified in the *db.yaml* configuration, the following arguments are supported to clean the table:

- **Timetrace table**

  - `clean -l` or `clean --large-partition` to clean the "-1_-1_-1_-1" partition.

  - `clean -s` or `clean --small-partition` to clean all other partitions.

  To execute both steps sequentially in one run, specify both options: `clean -l -s`

- **Infotrace table**

  - `clean -l` or `clean --large-partition` to clean the "-1_-1_-1_-1" partition.

When the program has finished and the data has been deleted, you still need to run compaction to actually reclaim the disk space. However, note that you need to wait `gc_grace_seconds` after the program finishes before you start the compaction.

## FAQ

#### What should I do if I, after querying Cassandra, I notice there are still rows alive that should have been deleted when I ran the program?

It is possible that the deletion of some partitions or time ranges fails (because of timeouts). This will be logged with errors. If necessary, you can run the program again with the time ranges that were not properly deleted.

#### Will this tool also clear the alarm table?

The alarm table is left untouched. This means that after the cleaning, the alarm table will have alarms that are no longer in the timetrace table. If you encounter any problems that may be related to this, please contact [Skyline Techsupport](mailto:techsupport@skyline.be).

#### What should I do if my database is part of a Cassandra cluster (e.g. in case of DataMiner Failover)?

You only need to run the tool on one of the Cassandra nodes. After the program has finished, run a full Cassandra repair on one of the Cassandra nodes. After `gc_grace_seconds` have elapsed, run a full Cassandra compaction on all Cassandra nodes.

#### What DataMiner functionality is affected by running this tool?

In general, all functionality regarding alarm monitoring with time ranges will no longer work for the deleted time range.

Affected features for the *timetrace* table:

- The alarm history retrieval function in DataMiner Cube (e.g. all alarms of the last 24 hours).

- Dragging an element/service to the Alarm Console (same functionality as above).

- The history slider functionality in Cube.

- Migration of Cassandra alarms to Elasticsearch (timetrace is used for this, cleaned time ranges will not be available in Elasticsearch for future migrations).

Affected features for the *infotrace* table:

- Information events history retrieval function in Cube (e.g. all information events of the last 24 hours).
