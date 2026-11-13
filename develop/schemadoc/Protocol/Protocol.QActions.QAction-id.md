---
uid: Protocol.QActions.QAction-id
description: "Learn how the id attribute uniquely identifies a QAction while remaining separate from parameter IDs in triggers and inputParameters."
---

# id attribute

Specifies the unique QAction ID.

A unique object ID must be assigned to every QAction in the protocol. The ID identifies the QAction declaration; it is separate from the parameter IDs listed in [triggers](xref:Protocol.QActions.QAction-triggers) and [inputParameters](xref:Protocol.QActions.QAction-inputParameters).

> [!IMPORTANT]
> Avoid duplicate QAction IDs. These would make the protocol ambiguous and could prevent the intended QAction from loading. When you copy a QAction, assign a new ID and verify its required `name` and trigger configuration.

## Content Type

[TypeObjectId](xref:Protocol-TypeObjectId)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Example

```xml
<QActions>
   <QAction id="1" name="Update status" encoding="csharp" triggers="100"><![CDATA[
      ...
   ]]></QAction>
</QActions>
```

## Related concepts

- [QActions](xref:LogicQActions)
- [QAction execution](xref:LogicQActionsExecution)
