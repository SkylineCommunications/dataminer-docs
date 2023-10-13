---
uid: LogicActionRead
---

# read

Can be executed on parameters and responses.

## On parameter

This action will read the specified parameter.

> [!NOTE]
> This action has to be triggered from a Trigger that triggers on response.

## On response

This action will read the specified response.

Use this command if the response contains parameters of which the length is set to "next param".

### Attributes

#### On@id

Specifies the ID(s) of the responses to read.

## Examples

```xml
<Action id="608">
   <Name>Read Response 508</Name>
   <On id="508">response</On>
   <Type>read</Type>
</Action>
```
