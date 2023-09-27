---
uid: Protocol.Commands.Command-ascii
---

# ascii attribute

Allows to specify that parameters should be sent as ASCII even if the protocol is in Unicode.

## Content Type

[TypeTrueOrSemicolonSeparatedNumbers](xref:Protocol-TypeTrueOrSemicolonSeparatedNumbers)

## Parent

[Command](xref:Protocol.Commands.Command)

## Remarks

This attribute allows you to specify that parameters should be sent as ASCII even if the protocol is in Unicode.

In the ascii attribute, you can specify that you want all parameters in the command to be sent as ASCII (e.g. ascii=”true”) or just some of the parameters, delimited with a semicolon (e.g. ascii=”18;40”).

In the following example, only parameter 40 will be sent as ASCII:

```xml
<Command id="8" ascii="40">
	<Name>Data Input</Name>
	<Content>
		<Param>2</Param>
		<Param>1</Param>
		<Param>18</Param>
		<Param>40</Param>
		<Param>4</Param>
	</Content>
</Command>
```

> [!NOTE]
> Fixed parameters do not need conversion. If you have a fixed parameter (e.g. a 0x0D trailer), you should not convert that parameter unless you specify it as Unicode (0x000x0D).

*Feature introduced in DataMiner 8.5.0 (RN 7643).*
