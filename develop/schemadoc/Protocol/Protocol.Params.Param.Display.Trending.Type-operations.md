---
metadata_version: 1
uid: Protocol.Params.Param.Display.Trending.Type-operations
description: "Reference the DataMiner connector protocol schema entry for operations attribute, including its documented structure, attributes, values, and constraints."
content_type: schema
applies_to:
  - DataMiner
---

# operations attribute

Option to choose a logarithmic scale for the vertical axis.<!-- RN 5843 -->

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.Display.Trending.Type)

## Remarks

Option to choose a logarithmic scale for the vertical axis. The parameter’s real value should always be larger than 0 for log10(value) to be possible.

## Examples

```xml
<Param>
	<Display>
		<Trending>
			<Type operations="log10"/>
		</Trending>
	</Display>
</Param>
```
