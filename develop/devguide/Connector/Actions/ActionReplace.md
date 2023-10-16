---
uid: LogicActionReplace
---

# replace

This action can be executed on commands and responses.

## On command

### Attributes

#### On@id

Specifies the ID(s) of the command(s) on which to perform this action.

#### Type@id

The ID of the parameter that contains the ID of the parameter that has to be put in the command.

#### Type@nr

The 0-based position of the parameter in the command/response.

> [!NOTE]
> This “replace” action must be followed by a “make” action.

## On response

### Attributes

#### On@id

Specifies the ID(s) of the response(s) on which to perform this action.

#### Type@id

The ID of the parameter that contains the ID of the parameter that has to be put in the response.

#### Type@nr

The 0-based position of the parameter in the command/response.

## Examples

In the following example, the fifth parameter (as Type@nr is 0-based) mentioned in the definition of response 324 will be replaced with the parameter of which the ID is set in parameter 10396. So, for example, if parameter 10396 contains 100, the fifth parameter in the response will be replaced with parameter 100:

```xml
<Action id="1999">
  <On id="324">response</On>
  <Type id="10396" nr="4">replace</Type>
</Action>
```
