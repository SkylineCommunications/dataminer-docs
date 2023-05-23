---
uid: Deleting_element_data_from_a_MySQL_database
---

# Deleting element data from a MySQL database

On a DMA using a MySQL general database, the current values of all element parameters marked “to be saved” in the element are saved in a local MySQL database table called “elementdata\_\[DMAID\]”. If, for some reason, you want all or some of those parameter values to be cleared, refer to the instructions below.

> [!NOTE]
> For more information on the save attribute of the Protocol.Params.Param tag, see [Param element](xref:Protocol.Params.Param).

> [!WARNING]
> Only people with the appropriate skills should be allowed to manipulate database contents directly. Incorrect changes made to the database can damage your entire DataMiner System.

## For one particular element on a DMA

Execute the following SQL delete statement:

```txt
DELETE FROM elementdata_[DMAID] WHERE iEID = [Element ID, NOT preceded by the DMA ID];
```

> [!NOTE]
> If, for a particular element, you only want to delete values of specific parameters, add a parameter restriction (e.g. “AND iPID = 102” or “AND iPID \>= 100”) to the WHERE clause.

## For all elements on a DMA

1. Rename the elementdata\_\[DMAID\] table to elementdata\_\[DMAID\]\_old by executing the following SQL statement:

    ```txt
    ALTER TABLE elementdata_[DMAID] RENAME TO elementdata_[DMAID]_old
    ```

    If you are using [MySQL Workbench](xref:MySQL_Workbench), you can also rename the table in the following way:

    1. Go to SQL Editor.

    1. In Object Browser, go to *sldmadb \> Tables \> elementdata*

    1. Right-click elementdata, and choose *Alter Table*.

    1. In the elementdata dialog box, enter another table name (e.g. elementdata_old) in the *Name* box and click *Apply*.

1. Restart the DataMiner Agent.

    During the restart operation, a new, blank elementdata table will be created.

1. If everything runs as expected, you can remove the old table by executing the following SQL statement:

    ```txt
    DROP TABLE elementdata_[DMAID]_old
    ```
