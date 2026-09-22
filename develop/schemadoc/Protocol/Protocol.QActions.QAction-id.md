---
metadata_version: 1
uid: Protocol.QActions.QAction-id
description: "Use the QAction ID to identify a QAction uniquely in a connector protocol and keep the declaration aligned with its triggers."
area: develop
content_type: schema
authority: reference
authority_source: SchemaProtocol
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# id attribute

Specifies the unique QAction ID.

## Content Type

[TypeObjectId](xref:Protocol-TypeObjectId)

## Parent

[QAction](xref:Protocol.QActions.QAction)

## Usage and constraints

Assign a unique object ID to every QAction in the protocol. The ID identifies the QAction declaration; it is separate from the parameter IDs listed in `triggers` and `inputParameters`.

## Expected result

DataMiner can load the QAction declaration and associate its configured triggers with the code in that QAction.

## Failure and edge cases

Duplicate IDs make the protocol ambiguous and can prevent the intended QAction from loading. When you copy a QAction, assign a new ID and verify its required `name` and trigger configuration.

## Example

```xml
<QActions>
   <QAction id="1" name="Update status" encoding="csharp" triggers="100"><![CDATA[
      ...
   ]]></QAction>
</QActions>
```

## Related concepts

- [QAction element](xref:Protocol.QActions.QAction)
- [QActions](xref:LogicQActions)
- [QAction execution](xref:LogicQActionsExecution)

## Authoritative references

- [Protocol XML schema](xref:SchemaProtocol)
- [QAction element](xref:Protocol.QActions.QAction)
