---
uid: Protocol.Params.Param.CRC.Type-groupbytes
---

# groupbytes attribute

Specifies the number of bytes on which to perform the operation.

## Content Type

string

## Parent

[Type](xref:Protocol.Params.Param.CRC.Type)

## Remarks

By default, the grouped value is interpreted as a string of hexadecimal values.

If you set groupbytes to 2, 3130 will be interpreted as 10. See the following example:

```xml
<Param>
  <CRC>
     <Type groupbytes="2">
     ...
```

If, however, you want the grouped value to be interpreted as a binary value, add ”;binary” to the groupbytes value.

See the following example. If you set groupbytes to 2 and you add ”;binary”, 3130 will be interpreted as 0x3031:

```xml
<Param>
  <CRC>
     <Type groupbytes="2;binary">
     ...
```

Only valid if the CRC type is set to one of the following values:

- Exor
- LSB after sum
- LSB after subtract
- Subtract
- Sum
