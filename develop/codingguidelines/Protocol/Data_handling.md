---
uid: Data_handling
---

# Data handling

- Depending on the type of data a table will hold, different scenarios are possible as to what should be done with the table data when the table is updated.

  In many cases, a table should only hold the entries that are currently available. If so, old rows that are no longer present will be removed. For example, SNMP and WMI tables will by default only need to display the entries that currently exist, and old rows will be removed.

  > [!NOTE]
  > For tables filled in by a QAction, code is necessary to remove the old data, e.g. via FillArray, RemoveRow.

## Previous data comparison

Sometimes users need to know about items that are no longer present compared to a previous polling of the table data (e.g. missing transport streams, services, processes, DVEs, etc.). In this case, the items that are no longer present must not be automatically removed. The table should indicate which entries are no longer available.

This should be implemented as follows:

- Add a PageButton "\[Table Name\] Config…" above the table that contains:

  - A read/write parameter "\[Table Name\] Auto Removal Delay" that has an appropriate range (low and high) and a *Remove Immediately* exception value. When the table is updated:
    - If the parameter is set to *Remove Immediately*, remove any missing entries.
    - Otherwise, for all missing entries, compare this configuration with the *Missing Since* date and remove the row(s) if needed. If the *Missing Since* column is empty, enter the current date and time, and update the *Status* column.

  - A button "Remove All \[Content Type\]" to remove all missing or old entries.

  - Table:
    - A column containing buttons to remove a missing entry.
    - A *Status* column that allows alarms for missing entries.
    - A *Missing Since* column (saved) to display the data and time when an entry is considered missing. This column is also used for the logic regarding the removal delay.

## Infinitely growing amount of data

Another possible scenario is that entries keep being added to a table (e.g. data pushed from an external third-party component to DataMiner, such as SNMP traps). In this case, the protocol must provide a means to automatically limit the size of the table. However, care must be taken to not remove entries that are still valid and of interest to the user (e.g. only remove cleared traps, old information events, etc.).

Implementation based on maximum number of rows and/or maximum time to keep:

- Add a PageButton "\[Table Name\] Config…" above the table that contains:

  - A toggle button "Max Table Size" (On/Off, default: On)

  - A parameter to define the maximum allowed number of rows. (Provide a well-chosen default value).

  - A parameter to define the maximum time to keep. (Provide a well-chosen default value.)

    > [!NOTE]
    > In this case, the table must contain a column that holds the time (in descending sort order).

## Dealing with very large tables

Your default strategy should always be to avoid too many calls to SLProtocol from within a QAction as much as possible. This usually means performing a single GetColumns to retrieve the whole table and using FillArray or SetColumns.

However, there are some cases where you may want a different approach:

- When dealing with too much data to hold in memory, it can become more important to look at memory usage instead of CPU cycles.
- When dealing with too much data to retrieve in a single call.

In those cases, you may want to consider using a loop and performing only a few GetRow calls instead of a single GetColumns call to retrieve the whole table.

> [!NOTE]
> In this case, you should always add a comment in your QAction code that explains why you are using a non-standard way of handling table data.

### Example

```txt
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
```

Metrics for a table with 5 columns (average results from looping 100 times with the setup displayed above):

| Number of Rows | GetRow in loop | GetColumns | NT_Notify (external get table in one call) |
|----------------|----------------|------------|--------------------------------------------|
| 20             | 44 ms          | 16 ms      | 100 ms                                     |
| 100            | 260 ms         | 40 ms      | 390 ms                                     |
| 10 000         | 25 000 ms      | 3000 ms    | 40 500 ms                                  |

As you can see, it might be a lot more efficient in a table with a lot of data to first do a GetColumn of one or two columns and then perform several GetRows in a loop.

### Guidelines

Based on experience, we recommend that you follow these basic guidelines:

- Performing a GetColumns:

  - Try to stay below 120 000 cells in 1 get, except if the content of a cell is a 20 MB string or something equally large, in which case you should split up more.
  - If you go above 100 000 rows (considering an average of 7 columns), issues will likely start to occur. Split up the data over several calls or filter only necessary data if you need more.
  - If you have 100 columns and a large number of rows, you should split these up into several GetColumns calls (e.g. one for rows 1-49 and one for 50-100). Always retrieve the Key column for every call so you can complete your table in memory in a stable way.

- Performing sets (FillArray):

  - Try to stay below 20 000 cells in 1 set, except if the content of a cell is a 20 MB string or something equally large, in which case you should split up more.
  - Avoid setting more than 1000 rows at a time. If your table is larger than 1000 rows, use multiple sets per 1000 to improve performance.
