---
uid: Protocol.Triggers.Trigger.Content.Id-else
description: "Use the else attribute of the Trigger Content Id element in a DataMiner protocol to run an action when the condition is not met."
---

# else attribute

When a condition has been added to the trigger, the action of which the ID is specified in this attribute will be executed when the condition is not met.

## Content Type

[EnumTrueFalse](xref:Protocol-EnumTrueFalse)

## Parent

[Id](xref:Protocol.Triggers.Trigger.Content.Id)

## Examples

```xml
<Id else="true">1</Id>
```
