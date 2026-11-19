---
uid: Protocol.QActions.QAction-row
description: "Use the row attribute in a DataMiner protocol to run a QAction when a table row changes and expose the updated row values to the script."
---

# row attribute

If set to *true*, the QAction will be executed when a row of a table has changed.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

A QAction with `row="true"` can be triggered by a write column parameter, a read column parameter, or an SNMP table parameter, or executed via [multithreaded timer](xref:AdvancedMultithreadedTimers) options (`qaction`, `qactionBefore`, or `qactionAfter`).

> [!IMPORTANT]
> A QAction with `row="true"` cannot be used with single parameters. Do not specify single parameters in the [triggers](xref:Protocol.QActions.QAction-triggers) attribute of a QAction that has `row="true"` enabled.

When a read column parameter is used as a trigger on a QAction with `row="true"`, make sure that if you for example fill in tables via QActions and you trigger on the read parameter, the QAction you then execute does not attempt to edit the same table. This will not work as it is locked, which will cause a deadlock.<!-- RN 14050, RN 15531 -->

> [!NOTE]
> When multiple values change (for example, via SetRow), multiple triggers can go off (per read column trigger defined) but each with the new values in the [protocol.NewRow()](xref:Skyline.DataMiner.Scripting.SLProtocol.NewRow) object.
>
> There are two exceptions when the [protocol.NewRow()](xref:Skyline.DataMiner.Scripting.SLProtocol.NewRow) object will not have the up-to-date data; this will be triggered in a separate run of the QAction:
>
> - Default values (for merge results)
> - Deleted rows on a state column
