---
uid: Cassandra_General_DB_Failure
---

# Start Element Failed - General Database Failure

## Introduction
When using Cassandra (local or in cluster) as database of the DMS and the following error message is found in the alarm console of Cube:  
```txt
Start Element Failed – Initializing the protocol for <elementname> failed. General database failure. (hr = 0x80040226)
```  

Then there’s a chance this element can’t start up because of an overload of tombstones. Usually this is for 1 or a few elements or a series of elements using the same connector.  
> [!IMPORTANT]
> Although most of these cases are tombstone-related, be aware that not every case is related to tombstones.

## Investigate
### Element log
A good start is by checking the element log file, it should resemble something like:  
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
The elementdata can’t be read out, meaning the element can’t start up.

### Cassandra 
#### Logs
The best way to verify the issue is related to a high number of tombstones, is by checking either the debug.log or the system.log file. Check the log that matches the datetime of when the element failed to start up.

> **Local Cassandra vs Cassandra Cluster**  
> The logs of a local Cassandra node are automatically put into the LogCollector package. Unless the Cassandra node is found on an external server.
> If the DMS uses a Cassandra cluster, then the elementdata of the affected element will be found on 1 of these nodes. Meaning it may be necessary to search through the logs of each node. 

Ideally, ERROR lines like these will be found in the log files:
```txt
Scanned over <amount> tombstones during query ‘SELECT v, vu FROM sldmadb_elementdata.elementdata WHERE d, e = <DMAID>, <ElementID> LIMIT 1000’
```
However it’s possible such ERROR log line are not present, you might also find timeouts or in general see tombstones being written to the table, like `Writing xxxx tombstones`.  
  
Be aware that tombstones being written to the table is normal. The amount is incremented with each update or delete action and they are cleared with each compaction. Tracking these increments could gives an idea of the updates/deletes for a given table and at a given time.  
For example, if the amount of tombstones suddenly increases with 100K or 1M in a short period of time, then this is abnormal. This would mean that 100K or 1M records were updated or deleted.  

#### Settings
Look for the 2 tombstone threshold settings within the Cassandra.yaml file:
- Tombstone_warn_threshold
- Tombstone_failure_threshold  
These values are by default set to 1000 for the warning and 100K for the failure threshold.
In a Dataminer environment, this is too limiting, these need to be set to 1M for the warning and 2M for the failure threshold.  

In case these thresholds are still set to their low default values, then the solution will be to increase these to their recommended values. This configuration change is mentioned in step 6 in [Installing Cassandra on a Linux machine](xref:Installing_Cassandra).

#### Apache Cassandra Cluster Monitor
Having an [Apache Cassandra Cluster Monitor](https://docs.dataminer.services/connector/doc/Apache_Cassandra_Cluster_Monitor.html) element on the DMS is an excellent way to know the KPIs (e.g. tombstone thresholds, gc_grace_seconds,...) of the Cassandra cluster, without the need to log into these servers. Unfortunately, to retrieve the configuration and log files, access to these Cassandra servers is still needed.  

> [!NOTE]
> In order to see the most KPIs, be sure to use the latest version of this connector

### Element
If the Cassandra setup was already using the increased threshold values, then there’s a chance something needs to change in the element or connector.  
The root cause is most often a table with saved columns.

> [!NOTE]
> The primary key of a table is always saved, unless it’s defined as volatile. 

To investigate the element, it should be able to start up first. Have a look at the mentioned workaround below to achieve this.

#### Connector
A deep dive in the connector gives an idea on the theoretical side, keep an eye out for the following:
-	Tables with saved columns
-	A trap table
-	Fast timers

#### Dataset
To get an overview of the amount of rows in the element, open the Client Test tool (see the note for guidance). 
Go to `Diagnostics > DMA > Parameter Table Rows(SLProtocol)` and provide the dmaId/elementID.  
  
To estimate the full dataset size, multiply the number of rows found by the number of columns in the table. Prioritize tables with a high row count, but consider that a large dataset may be normal depending on the table's context.  
  
A rapidly changing dataset can also contribute to a growing number of tombstones. To assess this, “Turn On” the Auto Refresh, using an interval of 1 sec. Ideally, the data should update in sync with the defined timers or, if applicable, the configured polling manager table.  

> [!NOTE]
> For those unfamiliar with the Client Test Tool, the following DM Docs pages will provide guidance on:
> - [Accessing it](xref:Opening_the_SLNetClientTest_tool)
> - [Connecting to it](xref:Connecting_to_a_DMA_with_the_SLNetClientTest_tool)
> - [Inspecting table rows](xref:SLNetClientTest_Inspecting_parameter_table_rows)

#### Log level
Increasing the log level of the element could reflect some fast-paced changed to the tables.  
[Increase the log level](xref:Elements_logging#changing-log-levels) of the Info, Debug and Error log to 5. Then see if the log gets spammed by parameter changes for the same table, this will be a good indicator.  
If possible, try to verify this using the Client Test tool of previous section.

> [!IMPORTANT]
> Be sure to change the log level back to 0 once finished, as this puts additional and unnecessary load onto the system.

#### Timer Base
Verify that no custom timer base is used, as this changes the speed of polling data.  
Where to find this parameter and what it does is fully explained in [Changing the polling speed of an element](xref:Changing_the_polling_speed_of_an_element).

### Other
#### Free disk space
If there isn’t enough disk space to perform a compaction, then tombstones can’t get removed. So be sure to check the free disk space as well.

#### Reaper
If reaper isn’t properly configured, then it can happen that the Cassandra maintenance isn’t done properly. Meaning the necessary clean-up can’t get triggered.

## Solution
### Threshold values
If the Cassandra setup was still using the default threshold values, then simply increase these values according to our DM Docs page [Installing Cassandra on a Linux machine](xref:Installing_Cassandra).

### Element
If the investigation points to a certain table, then the solution will depend on the root cause. For example, do all columns need to be saved? Can we make this a volatile table? Is the table being polled too fast?...  

If the root cause appears to be connector-related, then the driver will need to receive an update. Contact techsupport to verify the findings and to forward to the correct team.

## Workaround
If the root cause of the large amount of tombstone lies within the connector, then 1 of the below procedures should make it possible to to start up the element again.

### Local Cassandra node

1.	Access the Query Executer in Cube  
`Cube > System Center > Tools > Query Executer`
2.	Change the field “_Execute query on:_” points towards the agent hosting the element.
3.	Verify the current gc_grace_seconds with  
```SELECT gc_grace_seconds FROM system_schema.tables WHERE keyspace_name = 'SLDMADB' AND table_name = 'elementdata';```
4.	Change the grace seconds to 10s, using:  
```ALTER TABLE elementdata WITH gc_grace_seconds = 10;```
5.	Verify the grace seconds were changed, using the query in step 3.
6.	Access the server hosting Cassandra
7.	Open a CMD prompt and go to C:/Program Files/Cassandra/bin
8.	Start a compaction to remove the tombstones  
```Nodetool compact -s SLDMADB elementdata```
9.	In Cube, restart the element, it should start up.
10.	Back in the Query Executer, revert the gc_grace_seconds to the default of 1 day  
```ALTER TABLE elementdata WITH gc_grace_seconds = 86400;```
11.	Verify the grace seconds were changed, using the query in step 3.

### Cassandra cluster
1.	Access 1 of the Cassandra nodes, e.g. via PuTTy
2.	Open CQLSH, by executing the command  
```Cqlsh -u <username> -p <password>```   
Note, if TLS is used, append --SSL at the end.
3.	Decrease the gc_grace_seconds to 10s of the table using   
```ALTER TABLE sldmadb_elementdata.elementdata WITH gc_grace_seconds = 10;```
4.	Start a compaction to remove the tombstones  
```Nodetool compact -s sldmadb_elementdata elementdata```  
Note, this is a command per node. Execute this on every Cassandra node if the location of the specific elementdata is unknown.
5.	In Cube, restart the element, it should start up.
6.	Back in CQLSH, revert the gc_grace_seconds to the default of 1 day  
```ALTER TABLE sldmadb_elementdata.elementdata WITH gc_grace_seconds = 86400;```


## Techsupport
When stuck in the process, contact [techsupport@skyline.be](mailto:techsupport@skyline.be). Please provide all data useful for the investigation, this will include:
-	The error message from the alarm console, including the datetime of the occurrence
-	LogCollector package
-	DELT export of the affected element
-	In case of a Cassandra cluster, also include the system.log files from all Cassandra nodes  
The logs when the error occurred are sufficient.
-	Cassandra.yaml
  
If applicable, include any relevant investigation findings and notes derived from the document above.
