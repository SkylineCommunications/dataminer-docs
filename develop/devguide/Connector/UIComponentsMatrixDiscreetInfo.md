---
metadata_version: 1
uid: UIComponentsMatrixDiscreetInfo
description: "Describe the DataMiner connector development topic Discreet info, including its purpose, behavior, implementation guidance, and relevant constraints."
area: develop
content_type: conceptual
authority: unknown
authority_source: unknown
lifecycle: active
applies_to:
  - DataMiner
version: unknown
owner: unknown
review_status: needs_update
review_date: 2026-09-17
compatibility:
  uid: stable
  url: stable
---

# Discreet info

The matrix UI allows a user to change the input/output labels, allowed inputs per output (and vice versa), and the pages on which inputs or outputs are grouped. An input or output can also be locked.

It is possible to capture these changes in a protocol by defining a parameter of type "discreet info". There can only be one parameter of this type in the protocol.

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
