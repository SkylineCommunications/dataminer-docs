---
uid: Protocol.Actions.Action-id
description: "Use the action ID to identify an action uniquely in a protocol and keep its references stable when the protocol changes."
---

# id attribute

Specifies the unique action ID of the action.

A unique object ID must be assigned to every action in a protocol. The ID identifies the action in the `Actions` collection; it does not describe the action's execution type.

DataMiner can resolve the action declaration by its ID while processing the protocol's triggers, timers, or other action references.

> [!TIP]
> If you change an existing ID, update every protocol element that refers to the action and validate the connector before deployment.

## Content Type

[TypeObjectId](xref:Protocol-TypeObjectId)

## Parent

[Action](xref:Protocol.Actions.Action)

## Example

```xml
<Actions>
   <Action id="1">
      <On id="1">timer</On>
      <Type>start</Type>
   </Action>
</Actions>
```

## Related concepts

- [Action element](xref:Protocol.Actions.Action)
- [Start action](xref:LogicActionStart)
- [Connector logic actions](xref:LogicActions)
