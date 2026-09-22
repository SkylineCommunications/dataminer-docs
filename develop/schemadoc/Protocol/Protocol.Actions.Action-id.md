---
metadata_version: 1
uid: Protocol.Actions.Action-id
description: "Use the action ID to identify an action uniquely in a connector protocol and keep its references stable when the protocol changes."
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

Specifies the unique action ID.

## Content Type

[TypeObjectId](xref:Protocol-TypeObjectId)

## Parent

[Action](xref:Protocol.Actions.Action)

## Usage and constraints

Assign a unique object ID to every action in the protocol. The ID identifies the action in the `Actions` collection; it does not describe the action's execution type.

## Expected result

DataMiner can resolve the action declaration by its ID while processing the protocol's triggers, timers, or other action references.

## Failure and edge cases

Duplicate IDs make action references ambiguous. If you change an existing ID, update every protocol element that refers to the action and validate the connector before deployment.

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

## Authoritative references

- [Protocol XML schema](xref:SchemaProtocol)
- [Action element](xref:Protocol.Actions.Action)
