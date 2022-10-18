---
uid: Data_handling
---

# Data handling

- Depending on the type of data a table will hold, different scenarios are possible as to what should be done with the table data when the table is updated.

    In many cases, a table should only hold the entries that are currently available. If so, old rows that are no longer present will be removed. For example, SNMP and WMI tables will by default only need to display the entries that currently exist, and old rows will be removed.

    > [!NOTE]
    > For tables filled in by a QAction, code is necessary to remove the old data, e.g. via FillArray, RemoveRow.

### Previous data comparison

Sometimes users need to know about items that are no longer present compared to a previous polling of the table data (e.g. missing transport streams, services, processes, DVEs, etc.). In this case, the items that are no longer present must not be automatically removed. The table should indicate which entries are no longer available.

This should be implemented as follows:

- Add a PageButton "\[Table Name\] Config…" above the table that contains:

    - A toggle button "\[Table Name\] Auto Clear" (On/Off, default value Off). When the table is updated, check this status and remove the row(s) if needed.

    - A button "Remove All \[Content Type\]" to remove all missing or old entries.

    - Table:

        - A column containing buttons to remove a missing entry.

### Infinitely growing amount of data

Another possible scenario is that entries keep being added to a table (e.g. data pushed from an external third-party component to DataMiner, such as SNMP traps). In this case, the protocol must provide a means to automatically limit the size of the table. However, care must be taken to not remove entries that are still valid and of interest to the user (e.g. only remove cleared traps, old information events, etc.).

Implementation based on maximum number of rows and/or maximum time to keep:

- Add a PageButton "\[Table Name\] Config…" above the table that contains:

    - A toggle button "Max Table Size" (On/Off, default: On)

    - A parameter to define the maximum allowed number of rows. (Provide a well-chosen default value).

    - A parameter to define the maximum time to keep. (Provide a well-chosen default value.)

        > [!NOTE]
        > In this case, the table must contain a column that holds the time (in descending sort order).
        
        
### Dealing with very large tables

The default strategy is to always avoid too many calls to SLProtocol as possible from within a QAction. This usually means performing a single GetColumns to retrieve the whole table and using FillArray or SetColumns.

There are however some cases where you may want to reconsider this:

    - When dealing with too much data to hold in memory it can become more important to look at memory usage instead of CPU cycles.
    - When dealing with too much data to retrieve in a single call

In those cases you may want to consider using a loop and performing only a few GetRow calls instead of a single GetColumns call to retrieve the whole table.
        > [!NOTE]
        > In this case, you should always add a comment in your QAction code that explains why you're using a non-standard way of handeling table data.


System Information
------------------
      Time of this report: 11/14/2019, 12:29:49
             Machine name: 
               Machine Id: {7715B613-530C-4E8F-B12D-945A5A54BDC5}
         Operating System: Windows 10 Pro 64-bit (10.0, Build 17763) (17763.rs5_release.180914-1434)
                 Language: English (Regional Setting: English)
      System Manufacturer: Dell Inc.
             System Model: OptiPlex 3020
                     BIOS: BIOS Date: 02/15/17 05:19:18 Ver: A15.00  (type: BIOS)
                Processor: Intel(R) Core(TM) i5-4590 CPU @ 3.30GHz (4 CPUs), ~3.3GHz
                   Memory: 12288MB RAM
      Available OS Memory: 12206MB RAM
                Page File: 11848MB used, 7269MB available
              Windows Dir: C:\WINDOWS
          DirectX Version: DirectX 12
      DX Setup Parameters: Not found
         User DPI Setting: 96 DPI (100 percent)
       System DPI Setting: 96 DPI (100 percent)
          DWM DPI Scaling: Disabled
                 Miracast: Available, with HDCP
Microsoft Graphics Hybrid: Not Supported
           DxDiag Version: 10.00.17763.0001 64bit Unicode
 
 
 
Metrics, table with 5 columns: 
(average results out of looping 100 times)

Number of Rows	GetRow in loop 	GetColumns 	NT_Notify (external get table in one call)
10	                30 ms	        10 ms	    60 ms
20	                44 ms	        16 ms	    100 ms
100	                260 ms	        40 ms	    390 ms
10 000	            25 000 ms	    3000 ms	    40 500 ms


As you can see. You might be a lot more efficient in a table with a lot of data to first do a GetColumn of one or two columns and then perform several GetRows in a loop.

There are some basic guidelines to follow, these are based on experience:

Performing a GetColumns:
Try to stay below 120 000 cells in 1 get (except if the content of a cell is a 20mb string or something equally large, then split you'll want to split up more)

	• Usually starts breaking down if you go above 100 000 rows (Concidering an average of 7 columns)
	• Split it up or filter only necessary data if you need more.
	• If you've got 100 columns and >rows. Then it's better to split up and 2 getcolumns 1-49 and 50-100 for example. (Always retrieve the Key column for every call so you can complete your table in memory in a stable way)

Performing Sets (Fillarray):
Try to stay below 20 000 cells in 1 set. (same exception as above)
	• In general: avoid setting more than 1000 rows at a time.
If your table is larger then split up into multiple sets per 1000 as it will be more performant!
