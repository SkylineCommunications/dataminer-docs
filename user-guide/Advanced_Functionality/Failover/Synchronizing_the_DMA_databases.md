---
uid: Synchronizing_the_DMA_databases
---

# Synchronizing the DMA databases

In the *Failover* dialog box, you can access synchronization information about the two DMAs, and manually synchronize the databases.

> [!NOTE]
> In a system with Cassandra databases, the synchronization is handled by Cassandra instead of by DataMiner. As such, synchronization information and manual synchronization are not available in DataMiner for such a system.

> [!NOTE]
> We recommend switching to [Storage as a Service](xref:STaaS) instead, so that all the complexity of managing the DataMiner data storage is taken care of for you.

## Viewing DMA synchronization information

In the *Failover* dialog box, click the *Sync* button to open the *DataMiner Sync Status* window.

In the *Database* tab, the synchronization info is displayed in four columns:

- The first column contains all database tables. For some tables, there may be a triangle in front of the table name, allowing you to expand the list.

- The second column indicates if synchronization is OK for each table, or if data is missing on one of the DMAs.

- The third and fourth column indicate the number of rows per table for each of the DMAs. Below the columns, the date and time when the DMA information was last refreshed are indicated.

> [!NOTE]
> To refresh the data in this window, click the *Refresh* button. While the information is refreshing, the text *Refreshing* will be displayed both on the button itself and in the second column next to any table for which the refresh is not yet finished.

## Synchronizing the DMA databases in Cube

To synchronize the online and the offline agent:

1. In the *DataMiner Sync Status* window, select the tables you want to synchronize.

1. Click the *Sync* button in the lower left corner. The *Sync Options* window will open.

1. In the *Sync Options* window, the following options are possible:

   - Select *Sync from* and enter a date to limit the date range for the synchronization.

   - Select *SQL Limit* and enter a number to limit the amount of database rows that can be synchronized.

1. Click the *Sync* button at the bottom of the *Sync Options* window to start the synchronization.

   This will automatically open the *Sync* tab where you can follow the progress of the synchronization.

> [!NOTE]
> During a synchronization process, the main DMA will stay online the whole time and any new database Failover offloads will be put on hold until synchronization has finished.
>
