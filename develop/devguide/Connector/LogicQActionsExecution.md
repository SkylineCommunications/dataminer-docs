---
uid: LogicQActionsExecution
---

# QAction execution

A QAction is executed by a change event of a parameter referred to in the *triggers* attribute.

A change event is initiated when:

- the value of a parameter changes.
- a value is set to a parameter of type "write", even if the value is the same as the previous value.
- an action of type "run actions" is performed on a parameter.
- a parameter is set from a QAction using an instance of the SLProtocol(Ext) class, e.g. SetParameter.

   > [!NOTE]
   > This will also trigger the QAction even if the set value is the same as the current value.

A QAction is executed by the SLScripting process which is a 32 bit process.

## Executing a QAction on a row change

Often, when data of a row in a table changes, a QAction must be executed to process this change.

You can trigger on a row change by using the [row](xref:Protocol.QActions.QAction-row) attribute when defining a QAction, setting it to `true` and specifying a write column parameter:

```xml
<QAction id="..." encoding="..." triggers="1052" row="true">
```

In the example above, the triggers attribute is set to the parameter ID of the write parameter for a column in the table. This means the QAction will be triggered by any change made to this write parameter for every row.

> [!NOTE]
>
> - In recent DataMiner versions, you can use a read column parameter as a trigger on a QAction with row=true option. In legacy versions prior to DataMiner 9.5.1, triggering a QAction on a change of a particular read column is not possible.<!-- RN 15040 & 15531 -->
> - For SNMP tables, it is also possible to provide the ID of a table parameter. In this case, the QAction will trigger every time a row has been updated.

In a QAction, the following methods are available to retrieve information about the row that triggered the execution of the QAction:

|Method  |Description  |
|---------|---------|
|[RowIndex](xref:Skyline.DataMiner.Scripting.SLProtocol.RowIndex)     |Gets the 1-based row position of the row that triggered the execution of the QAction.         |
|[RowKey](xref:Skyline.DataMiner.Scripting.SLProtocol.RowKey)     |Gets the primary key of the row that triggered the execution of the QAction.         |
|[OldRow](xref:Skyline.DataMiner.Scripting.SLProtocol.OldRow)     |Gets information about the previous cell values before the row was updated.         |
|[NewRow](xref:Skyline.DataMiner.Scripting.SLProtocol.NewRow)     |Gets information about the updated cells in a row.         |

> [!NOTE]
> For more information about how to implement SNMP tables, see [Retrieving tables](xref:ConnectionsSnmpRetrievingTables).

## Queued QActions

A QAction can be defined with the option [queued](xref:Protocol.QActions.QAction-options#queued). Using the option `queued`, the QAction will be executed asynchronously: the QAction is triggered and set in the background. This means that it will not wait until it is finished before another QAction can run.

This option should only be used if really needed and care must be taken during implementation. For example, make sure to implement locking when needed.
