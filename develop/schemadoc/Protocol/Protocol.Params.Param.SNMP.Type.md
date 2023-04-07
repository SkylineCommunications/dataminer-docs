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
- OctetStringHex

  > [!NOTE]
  > This is used when you need to keep the Hex format. For example, a write with value 01.02.03.04.05.06 will be sent as 010203040506 instead of the converted ASCII value 303130323033303430353036.

- OctetStringASCII

  > [!NOTE]
  > This is used when special chars like é, è, à, etc. are retrieved.

- OctetStringUTF8
- OctetStringDecimal
- OID
- Opaque

  > [!NOTE]
  > When used in a trap it is processed the same way as the type octetstring. *Feature introduced in DataMiner 8.0.8.4, RN 7249.*

- TimeTicks
- UInteger32
