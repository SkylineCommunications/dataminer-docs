---
uid: Cassandra_General_DB_Failure
---

# Element fails to start because of database failure

In some cases, it can occur that an element is unable to start up because there are too many tombstones in Cassandra. This only occurs in setups with self-hosted storage, using either a Cassandra cluster for the entire DMS or a Cassandra database per Agent.

When this problem occurs, the following error message is shown in the Cube Alarm Console:

```txt
Start Element Failed – Initializing the protocol for <elementname> failed. General database failure. (hr = 0x80040226)
```  

Usually this happens for one or more elements or a series of elements using the same connector.

> [!NOTE]
> When you encounter this issue, it is often tombstone-related, but not always.

## Investigating the issue

To investigate this issue, carry out the checks below in the order mentioned.

### Check the element log file

When this error occurs, the element log file should look similar to this:

```txt
...
InitializeParameters
Querying elementdata
Could not start reading the element data for <DMAID>/<ElementID>: 0x80131500:
Failed to query elementdata for <DMAID>/<ElementID>: General database failure.
InitializeParameters failed General database failure.. (hr = 0x80040226)
InitializeProtocol for Element <ElementName> failed with General database failure.. (hr = 0x80040226)
Start failed. General database failure. (hr = 0x80040226)
Setting state from 1 to 10 (RealState = 4)
...
```  

This means that the element data cannot be read out, causing the element to fail to start up.

### Check the Cassandra logging

To then verify whether the issue is indeed related to a high number of tombstones, check either the *debug.log* or the *system.log* file of the Cassandra database. Check the log that matches the datetime of when the element failed to start up.

Note that if you have a Cassandra database per DMA, these log files will automatically be included in an [SLLogCollector](xref:SLLogCollector) package unless the database is located on an external server. If the DMS uses a Cassandra cluster, the element data of the affected element will be located on one of the nodes, which means that you may need to search through the logs of each node.

You should be able to find ERROR lines like these in the log files:

```txt
Scanned over <amount> tombstones during query 'SELECT v, vu FROM sldmadb_elementdata.elementdata WHERE d, e = <DMAID>, <ElementID> LIMIT 1000'
```

If such ERROR log lines are not present, you may instead find timeouts or tombstones being written to the table, e.g., `Writing xxxx tombstones`.

Be aware that tombstones being written to the table is normal. The amount is incremented with each update or delete action, and they are cleared with each compaction. Tracking these increments could give you an idea of the updates/deletes for a given table and at a given time. For example, if the number of tombstones suddenly increases with 100K or 1M in a short period of time, this is abnormal. This would mean that 100K or 1M records were updated or deleted.

### Check the Cassandra settings

Look for the following tombstone threshold settings within the *Cassandra.yaml* file:

- **tombstone_warn_threshold**: By default set to 1000.
   - In a Linux environment, this **should be set to 1000000**.
   - In a Windows environment, this **should be set to 100000**.
- **tombstone_failure_threshold**: By default set to 100000. 
   - In a Linux environment, this **should be set to 2000000**.
   - In a Windows environment, this **should be set to 200000**.

The default values for these settings are too limiting for a DataMiner environment. If these have not been adjusted correctly during [Cassandra installation](xref:Installing_Cassandra), adjusting their values as mentioned above will likely be the solution for the element startup issue.

> [!TIP]
> Having an [Apache Cassandra Cluster Monitor](https://docs.dataminer.services/connector/doc/Apache_Cassandra_Cluster_Monitor.html) element in the DMS is an excellent way to know the KPIs (e.g., tombstone thresholds, gc_grace_seconds, etc.) of the Cassandra cluster without the need to log into these servers. Make sure to use the latest version of the connector to be able to view more KPIs. Unfortunately, to retrieve the configuration and log files, access to these Cassandra servers is still needed.

### Check the element configuration

If the Cassandra setup was already using the increased threshold values, then there is a chance something needs to change in the element or connector instead. The root cause is usually a table with saved columns. However, note that the primary key of a table is always saved, unless it is defined as volatile.

1. Investigate the connector itself.

   Keep an eye out for the following:

   - Tables with saved columns
   - A trap table
   - Fast timers

1. To be able to investigate the element more easily, start it up using the [workaround](#workaround) mentioned below.

1. To get an overview of the number of rows in the element, use the SLNetClientTest tool to [inspect the parameter table rows in SLProtocol](xref:SLNetClientTest_Inspecting_parameter_table_rows).

   To estimate the full dataset size, multiply the number of rows found by the number of columns in the table. Prioritize tables with a high row count, but keep in mind that a large dataset may be normal depending on the table's context.

   A rapidly changing dataset can also contribute to a growing number of tombstones. To assess this, click the *Turn On* button next to *Auto Refresh*, and set the interval to 1 sec. Ideally, the data should update in sync with the defined timers or, if applicable, the configured polling manager table.

1. [Increase the log level](xref:Elements_logging#changing-log-levels) of the Info, Debug and Error logging for the element to 5.

   If the log gets a multitude of entries for parameter changes for the same table, this is a good indicator of which table causes the problem. You can then verify this using the SLNetClientTest tool findings from the previous step.

   > [!IMPORTANT]
   > Remember to change the log level back to 0 once finished, as the higher log level puts an additional, unnecessary load on the system.

1. Verify that no [custom timer base](xref:Changing_the_polling_speed_of_an_element) is used, as this changes the speed of polling data.

1. If you have been able to pinpoint the issue to a specific table, address the issue as appropriate.

   The solution will depend on the root cause. For example: do all columns need to be saved, can you make this a volatile table, is the table being polled too fast, etc.

   If the root cause appears to be connector-related, then the connector will need to receive an update. In that case, [contact DataMiner Support](#contacting-dataminer-support-for-this-issue) to verify the findings and to forward them to the correct team.

### Other checks

1. Check if there is enough free disk space on the Cassandra server.

   If there is not enough disk space to perform a compaction, then tombstones cannot be removed. In this case, freeing up disk space may help you resolve this issue.

1. Check if Cassandra Reaper is configured correctly, as detailed under [Installing Cassandra Reaper](xref:Installing_Cassandra_Reaper).

   If the Reaper configuration is not correct, it can happen that the Cassandra maintenance is not done properly, causing the necessary cleanup not to be triggered.

1. If you have been unable to solve the issue through any of the steps above, [contact DataMiner Support](#contacting-dataminer-support-for-this-issue).

## Workaround

If the root cause of the large number of tombstone lies within the connector, follow the appropriate procedure below to start up the element again.

### Cassandra database per Agent

1. In DataMiner Cube, open the Query Executer by going to *System Center* > *Tools* > *Query Executer*.

1. In the *Execute query on* box, make sure the Agent hosting the element is selected.

1. Verify the current *gc_grace_seconds* using the following query:

   `SELECT gc_grace_seconds FROM system_schema.tables WHERE keyspace_name = 'SLDMADB' AND table_name = 'elementdata';`

1. Change the grace seconds to 10s, using the following query:

   `ALTER TABLE elementdata WITH gc_grace_seconds = 10;`

1. Verify whether the grace seconds were changed, using the previously mentioned query to verify the current *gc_grace_seconds*.

1. On the server hosting Cassandra, open a command prompt and go to the folder `C:\Program Files\Cassandra\bin`.

1. Use the following command to start a compaction to remove the tombstones:

   `Nodetool compact -s SLDMADB elementdata`

1. In Cube, restart the element.

   The element should now start up.

1. In the Query Executer, revert the *gc_grace_seconds* to the default of 1 day using the following query:

   `ALTER TABLE elementdata WITH gc_grace_seconds = 86400;`

1. Verify whether the grace seconds were changed, using the previously mentioned query to verify the current *gc_grace_seconds*.

### Cassandra cluster per DMS

1. Access one of the Cassandra nodes, e.g., via PuTTy.

1. Open CQLSH, by executing the following command:

   `Cqlsh -u <username> -p <password>`

   If **TLS** is used, append `--SSL` at the end.

1. Decrease the *gc_grace_seconds* of the table to 10s using the following command:

   `ALTER TABLE sldmadb_elementdata.elementdata WITH gc_grace_seconds = 10;`

1. Start a compaction to remove the tombstones:

   `Nodetool compact -s sldmadb_elementdata elementdata`

   This is a command **per node**. Execute this on every Cassandra node if the location of the specific element data is unknown.

1. In Cube, restart the element.

   The element should now start up.

1. In CQLSH, revert the *gc_grace_seconds* to the default of 1 day:

   `ALTER TABLE sldmadb_elementdata.elementdata WITH gc_grace_seconds = 86400;`

## Contacting DataMiner Support for this issue

If you are unable to resolve this yourself using the information above, contact <support@dataminer.services>.

Please provide all data useful for the investigation. This will include the following:

- The error message from the Alarm Console, including the datetime of the occurrence.
- A LogCollector package
- A .dmimport package containing an export of the affected element(s).
- If a Cassandra cluster is used for the entire DMS, the *system.log* files of all Cassandra nodes. The logs when the error occurred are sufficient.
- The *Cassandra.yaml* file.

If applicable, include any relevant investigation findings and notes derived from the document above.
