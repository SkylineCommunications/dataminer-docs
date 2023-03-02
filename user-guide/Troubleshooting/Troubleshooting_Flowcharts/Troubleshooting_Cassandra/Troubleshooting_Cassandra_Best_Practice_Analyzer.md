---
uid: Troubleshooting_Cassandra_Best_Practice_Analyzer
---

# Troubleshooting - Cassandra - best practice analyzer

## About the Cassandra BPA

The Cassandra BPA test is available on demand. You can run it in System Center on the Agents BPA tab, available from DataMiner 9.6.0 CU23, 10.0.0 CU13, 10.1.0 CU2 and 10.1.4 onwards. From DataMiner 10.1.4 onwards, this BPA test is available on each DMA by default.

For more information on how to run this test, see [running BPA tests](xref:Running_BPA_tests) and [Standalone BPA Executor](xref:Standalone_BPA_Executor).

## Cassandra BPA flowchart

<div class="mermaid">
flowchart TD
%% Define styles %%
linkStyle default stroke:#cccccc
classDef LightBlue fill:#9DDAF5,stroke:#000070,stroke-width:0px, color:#1E5179;
classDef Blue fill:#4BAEEA,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkBlue fill:#1E5179,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef DarkGray fill:#58595B,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef Gray fill:#999999,stroke:#000070,stroke-width:0px, color:#FFFFFF;
classDef LightGray fill:#DDDDDD,stroke:#000070,stroke-width:0px, color:#1E5179;
%% Define blocks %%
goback[Return to Troubleshooting Cassandra]:::Gray
A[Best Practice Analyzer Cassandra]:::DarkBlue
C{{Run the BPA test.}}:::Blue
G[Make sure DB.xml is configured<br> correctly and DataMiner is able to <br>create the keyspace as SLDMADB. ]:::DarkBlue
O[Free up space on the Cassandra drive <br>until requirements are met.]:::DarkBlue
X[ Remove the duplicates, making sure that <br>their ID does not match the currently used ID. ]:::DarkBlue
V(Review the SStable size using <br>the Cassandra Cleaner Tool.):::DarkBlue
E([Does free disk space meet requirements?]):::Blue
F([Is the result 'Could not find <br>the KeySpaceName keyspace'?]):::Blue
D([Is a large table identified?]):::Blue
B([Are duplicate tables identified?]):::Blue
%% Connect blocks %%
A ----- |The BPA can only check local database installations.<br> It is not available yet for remote Cassandra servers.|C
C ------ |Duplicate table or folder check|B
C ------ | SStable size check: size largest <br> SSTable smaller than 1/3 <br> of the total installed RAM. |D
C ------- |Compaction disk space check|E
C ---------- |Keyspace existence check|F
B --- |Yes|X
D --- |Yes|V
E --- |No|O
F --- |Yes|G
%% Define hyperlinks %%
click A "https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Systems/BPA_tests/BPA_Cassandra_DB_Size.html"
click C "https://docs.dataminer.services/user-guide/Advanced_Functionality/DataMiner_Systems/Running_BPA_tests.html"
click V "https://docs.dataminer.services/user-guide/Reference/DataMiner_Tools/Cassandra_Cleaner.html"
click E "https://community.dataminer.services/dataminer-compute-requirements/"
click O "https://docs.datastax.com/en/dseplanning/docs/capacityPlanning.html"
click goback "https://docs.dataminer.services/user-guide/Troubleshooting/Troubleshooting_Flowcharts/Troubleshooting_Cassandra/Troubleshooting_Cassandra.html"
click G "#making-sure-dbxml-is-configured-correctly"
click X "#removing-duplicate-tables-or-folders"
</div>

## Removing duplicate tables or folders

Duplicate tables or folders can be the result of previous installations of Cassandra that were not properly removed. The duplicates can be deleted manually.

However, when you delete a duplicate, make sure the ID (e.g. timetrace-511e8260b72f11e8862f6bd82952d1c9) does not match the current ID in use by the database table or folder.

To cross-check the IDs in use and remove a duplicate:

1. Open Cassandra DevCenter and use the following command: `select * from system_schema.tables, where keyspace_name = 'SLDMADB';`

1. Check which ID is displayed as a result of this query. This is the ID that is currently in use.

1. Delete the table or folder from the file system where the Cassandra database is located that does not have the ID displayed based on the query.

## Making sure DB.xml is configured correctly

To verify if *DB.xml* is configured correctly:

1. On the DMA, go to `C:\Skyline DataMiner` and open the file *DB.xml*.

1. Check if the following tags are configured correctly according to the type of Cassandra deployment:

   - The `Database` tag for the general database should have the attribute `type="Cassandra"` or `type="CassandraCluster"`.

   - The DB element within this Database element should be set to SLDMADB: `<DB>SLDMADB</DB>`.

For more information, see [DB.xml](xref:DB_xml).

Keep in mind that to make any changes to *DB.xml*, you need to first stop DataMiner, and then restart DataMiner when the changes have been saved. As making changes to raw configuration files like *DB.xml* can have far-reaching consequences for your system, always be very careful when you do this.
