---
uid: UIComponentsMatrixDiscreetInfo
---

# Discreet info

The matrix UI allows a user to change the input/output labels, allowed inputs per output (and vice versa), and the pages on which inputs or outputs are grouped. An input or output can also be locked.

It is possible to capture these changes in a protocol by defining a parameter of type "discreet info".

```xml
<Param id="107">
   <Name>Discreet Info</Name>
   <Description>Discreet Info</Description>
   <Type>discreet info</Type>
   <Interprete>
      <RawType>other</RawType>
      <LengthType>next param</LengthType>
      <Type>string</Type>
   </Interprete>
   <Display>
      <RTDisplay>false</RTDisplay>
   </Display>
</Param>
```

A QAction triggering on this parameter can then be implemented to process the change. The parameter value will be updated on each change made on the matrix. For more information on how to process the parameter value, see [discreet info](xref:Protocol.Params.Param.Type#discreet-info).
