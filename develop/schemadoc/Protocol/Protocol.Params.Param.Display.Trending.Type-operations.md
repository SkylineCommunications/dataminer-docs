---
metadata_version: 1
uid: Protocol.Params.Param.Display.Trending.Type-operations
description: "Learn how the operations attribute applies log10 scaling to the vertical axis of a trend graph for positive values in a DataMiner connector protocol."
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
