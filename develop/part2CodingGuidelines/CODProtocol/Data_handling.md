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
        >
