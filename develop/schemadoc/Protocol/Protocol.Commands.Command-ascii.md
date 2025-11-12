---
uid: Protocol.Commands.Command-ascii
---

# ascii attribute

<!-- RN 7643 -->

Allows to specify that parameters should be sent as ASCII even if the protocol is in Unicode.

## Content Type

[TypeTrueOrSemicolonSeparatedNumbers](xref:Protocol-TypeTrueOrSemicolonSeparatedNumbers)

## Parent

[Command](xref:Protocol.Commands.Command)

## Remarks

This attribute allows you to specify that parameters should be sent as ASCII even if the protocol is in Unicode.

In the ascii attribute, you can specify that you want all parameters in the command to be sent as ASCII (e.g. ascii="true") or just some of the parameters, delimited with a semicolon (e.g. ascii="18;40").

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
>
> - Fixed parameters do not need conversion. If you have a fixed parameter (e.g. a 0x0D trailer), you should not convert that parameter unless you specify it as Unicode (0x000x0D).
> - From DataMiner 10.6.0/10.6.1 onwards (RN 43929), specifying `ascii="true"` will only apply conversion to string-type parameters in the command. Fixed parameters with [Interprete.Value](xref:Protocol.Params.Param.Interprete.Value) specified in 0x format are not converted. Parameters with [Interprete.RawType](xref:Protocol.Params.Param.Interprete.RawType) set to `numeric text` and [Interprete.Type](xref:Protocol.Params.Param.Interprete.Type) set to `double` are not encoded as Unicode UTF-16 and hence are not converted with `ascii="true"`. When a parameter ID is explicitly defined in the `ascii` attribute, the conversion will be executed regardless of the parameter type.
