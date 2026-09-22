---
metadata_version: 1
uid: LogicActionMake
description: "Describe the DataMiner connector development topic make, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
applies_to:
  - DataMiner
version: unknown
owner: unknown
---

# make

Can be executed on commands only.

Normally, all commands are made when the element is started (i.e., at protocol startup) or when a set is performed via an "execute" or a "force execute" action.

The "make" action allows you to explicitly re-assemble a command after having changed the contents of that command.

## Attributes

### On@id (optional)

Specifies the ID(s) of the command(s).

## Examples

```xml
<Action id="5">
  <Name>Make Command</Name>
  <On>command</On>
  <Type>make</Type>
</Action>
```
