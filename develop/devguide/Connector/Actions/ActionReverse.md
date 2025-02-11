---
uid: LogicActionReverse
---

# reverse

This action can be executed on parameters only.

This action will reverse the bytes of the specified parameter(s). This action will have the same effect as adding the tag `<Endian>big</Endian>` to the parameter, with the exception that the action (reversing the parameter) will be done at a specific time.

> [!NOTE]
> This action must be triggered from a trigger that triggers on response or command. Typically, this action is used before a command or after a response.

## Attributes

### On@id

The ID of the parameter(s) to be reversed.

### On@nr

(Optional.) In case a parameter is used multiple times in the definition of a command/response, this attribute can be used to indicate which occurrence(s) of this parameter in the command/response should be reversed. By default, the first occurrence is reversed. Separate multiple positions by semicolons (`;`). Occurrences are 0-based: to reverse the second occurrence, specify `nr="1"`.

## Examples

In the following example, parameter 1004 will be reversed when the trigger goes off:

```xml
<Trigger id="19">
   <On id="31">command</On>
   <Time>before</Time>
   <Type>action</Type>
   <Content>
      <Id>300</Id>
   </Content>
</Trigger>
```

```xml
<Action id="300">
  <Name>reverse device address</Name>
  <On id="1004">parameter</On>
  <Type>reverse</Type>
</Action>
```
