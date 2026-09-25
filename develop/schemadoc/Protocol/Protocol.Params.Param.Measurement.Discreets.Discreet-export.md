---
metadata_version: 1
uid: Protocol.Params.Param.Measurement.Discreets.Discreet-export
description: "Learn how the export attribute selects the exported protocol tables that receive a discreet parameter value in a DataMiner connector protocol."
---

# export attribute

Specifies the parameter values that have to be exported.

## Content Type

string

## Parent

[Discreet](xref:Protocol.Params.Param.Measurement.Discreets.Discreet)

## Examples

In the example below, the exported protocol will contain the following discreet values:

- table 1000: OK, Failure and Fine
- table 1200: GOOD and failure
- table 3000: Failure and fine

```xml
<Param>
	<Measurement>
		<Discreets>
			<Discreet export="1000">
				<Display>OK</Display>
				<Value>1</Value>
			</Discreet>
			<Discreet export="1200">
				<Display>GOOD</Display>
				<Value>2</Value>
			</Discreet>
			<Discreet>
				<Display>Failure</Display>
				<Value>3</Value>
			</Discreet>
			<Discreet export="1000;3000">
				<Display>Fine</Display>
				<Value>4</Value>
			</Discreet>
		</Discreets>
	</Measurement>
</Param>
```
