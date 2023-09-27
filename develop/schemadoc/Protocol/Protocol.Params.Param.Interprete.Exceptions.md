---
uid: Protocol.Params.Param.Interprete.Exceptions
---

# Exceptions element

Contains Exception elements, each representing a different exceptional state.

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Children

|Name&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|Occurrences|Description|
|--- |--- |--- |
|&nbsp;&nbsp;[Exception](xref:Protocol.Params.Param.Interprete.Exceptions.Exception)|[0, *]|Defines an exception for an exception value you want to intercept of which the Interprete.Type is identical to that of the parameter in question.|

## Constraints

|Type|Description|Selector|Fields|
|--- |--- |--- |--- |
|Unique |The ID of an exception must be unique. |Exception |@id |

## Remarks

> [!NOTE]
>
> - Exception tags are only useful for parameters of type “read”.
> - Only use the Exceptions tag to intercept values of the same Interprete.Type as that of your parameter. If you want to intercept values of another type, use the Protocol.Params.Param.Interprete.Others tag.

## Examples

```xml
<Exceptions>
	<Exception id="1" value="0">
		<Display state="disabled">Not Found</Display>
		<Value>0</Value>
	</Exception>
</Exceptions>
```
