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
  > In a read parameter, this type can be used to display ASCII characters when all octets fall within the ASCII range (0x00 - 0x7F). If any octet falls outside this range, all items will be displayed in hex format. For example, if the octets include the hex value "0x4D614D61", this will be displayed as "MaMa" because all octets are ASCII values. However, if the input is the hex value "0x4D61E7E3", this will be displayed as "4D.61.E7.E3" because two octet values fall outside the ASCII range.

- OctetStringHex

  > [!NOTE]
  > This type can be used when it is necessary to maintain the hex format. For example, a write operation with value "01.02.03.04.05.06" will be sent as "010203040506" instead of the converted ASCII value "303130323033303430353036". Similarly, during a read operation, if the received value is "010203040506", it will be displayed as "01.02.03.04.05.06" in hex format.

- OctetStringASCII

  > [!NOTE]
  > This type can be used to retrieve special characters like é, è, à, and more. In a read parameter, it displays the incoming octet values according to the latin-1 (ISO 8859-1) character set. For example, if the hex value "0x4D61E7E3" is received, it will be displayed as "Maçã". However, if the "Maçã" value was written in UTF-8 encoding, it would have the hex value "0x4D61C3A7C3A3". Reading this value as OctetStringASCII would result in the unexpected display of "MaÃ§Ã£". It is important to consistently use the same type for read and write operations, as the SNMP device interprets these values solely as octets without contextual understanding of the represented characters.

- OctetStringUTF8

  > [!NOTE]
  > This type can be used to retrieve Unicode characters. In a read parameter, it displays the incoming octet values according to the UTF-8 Unicode character set. For example, if the hex value "0x4D61C3A7C3A3" is received, it will be displayed as "Maçã".
  
- OctetStringDecimal
- OID
- Opaque

  > [!NOTE]
  > When used in a trap it is processed the same way as the type octetstring. *Feature introduced in DataMiner 8.0.8.4, RN 7249.*

- TimeTicks
- UInteger32
