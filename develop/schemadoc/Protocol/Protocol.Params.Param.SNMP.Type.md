---
uid: Protocol.Params.Param.SNMP.Type
---

# Type element

Specifies the SNMP type.

> [!IMPORTANT]
> We strongly recommend always specifying an SNMP type on a write parameter. Without the SNMP type, it will fall back to default behavior, which could not be as expected. Numbers will be set with the SNMP type *Integer32*. Text will be set with the SNMP type *OctetString*. A parameter with Protocol.Params.Param.Interprete.RawType defined as *numeric text* is considered to be text and will be set with the SNMP type *OctetString*.

## Type

[EnumSNMPType](xref:Protocol-EnumSNMPType)

## Parent

[SNMP](xref:Protocol.Params.Param.SNMP)

## Remarks

One of the following predefined values:

- Counter32
- Counter64
- Counter64string

  > [!NOTE]
  > This type can be used to receive the SNMP counter64 as a string, where the counter64 uses double and may therefore lose definition. *Feature introduced in DataMiner 8.5.4.2, RN 9284.*

- Gauge32
- Integer
- Integer32
- IpAddress
- NSAPAddress
- NULL
- ObjectID
- OctetString

  > [!NOTE]
  > In a read parameter, this will display ASCII characters when all octets fall within the ASCII range (0x00 - 0x7F). If one of the octets do not fall into this range then all items will be displayed in Hex format. For example, suppose that the Hex value 0x4D614D61 enters then this will be displayed as "MaMa" because all octets are ASCII values. However, when Hex value 0x4D61E7E3 enters then this will be displayed as "4D.61.E7.E3" because two octet values do not fall within the ASCII range.

- OctetStringHex

  > [!NOTE]
  > This is used when you need to keep the Hex format. For example, a write with value 01.02.03.04.05.06 will be sent as 010203040506 instead of the converted ASCII value 303130323033303430353036. For example in the other direction, a read that receives 010203040506 will display 01.02.03.04.05.06.

- OctetStringASCII

  > [!NOTE]
  > This is used when special chars like é, è, à, etc. are retrieved. In a read parameter, this will display the incoming octet values according to the latin-1 (ISO 8859-1) character set. For example, suppose that the Hex value 0x4D61E7E3 enters then this will be displayed as "Maçã". Suppose that the "Maçã" value was written as UTF-8 encoding then this would be Hex value 0x4D61C3A7C3A3, reading out such a value as OctetStringASCII would result into the unexpected "MaÃ§Ã£" being displayed. It is important to use the same type with read and write, because for the SNMP device these are just octet values that enter without context awareness of what character this is representing. 

- OctetStringUTF8

  > [!NOTE]
  > This is used when unicode chars are retrieved. In a read parameter, this will display the incoming octet values according to the UTF-8 unicode character set. For example, suppose that the Hex value 0x4D61C3A7C3A3 enters then this will be displayed as "Maçã".
  
- OctetStringDecimal
- OID
- Opaque

  > [!NOTE]
  > When used in a trap it is processed the same way as the type octetstring. *Feature introduced in DataMiner 8.0.8.4, RN 7249.*

- TimeTicks
- UInteger32
