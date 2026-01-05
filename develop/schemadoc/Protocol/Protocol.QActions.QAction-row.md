---
uid: Protocol.QActions.QAction-row
---

# row attribute

If set to *true*, the QAction will be executed when a row of a table has changed.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Remarks

A read column parameter can be used as a trigger on a QAction with row=true option. However, make sure that if you for example fill in tables via QActions and you trigger on the read parameter, the QAction you then execute does not attempt to edit the same table. This will not work as it is locked, which will cause a deadlock.<!-- RN 14050, RN 15531 -->

> [!NOTE]
> When multiple values change (for example, via SetRow), multiple triggers can go off (per read column trigger defined) but each with the new values in the protocol.NewRow() object.
>
> There are two exceptions when the protocol.NewRow() object will not have the up-to-date data; this will be triggered in a separate run of the QAction:
>
> - Default values (for merge results)
> - Deleted rows on a state column
