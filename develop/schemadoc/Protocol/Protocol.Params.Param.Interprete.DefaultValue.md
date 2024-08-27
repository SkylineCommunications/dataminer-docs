---
uid: Protocol.Params.Param.Interprete.DefaultValue
---

# DefaultValue element

Specifies the default value to be assigned to the parameter if it is empty after startup.

## Type

string

## Parent

[Interprete](xref:Protocol.Params.Param.Interprete)

## Remarks

*Feature introduced in DataMiner 8.5.3 (RN 8776).*

## Examples

```xml
<Interprete>
	<RawType>other</RawType>
	<LengthType>next param</LengthType>
	<Type>string</Type>
	<DefaultValue>This is the default value</DefaultValue>
</Interprete>
```

> [!NOTE]
> Default values can only be assigned to standalone parameters. They do not work for table columns.
