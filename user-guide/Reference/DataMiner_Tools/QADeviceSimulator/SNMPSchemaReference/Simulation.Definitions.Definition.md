---
uid: DeviceSimulator_SNMP_Schema_Simulation_Definitions_Definition
---

# Definition element

Each definition element represents a single, unique OID and corresponding value.

## Parent

[Definitions](xref:DeviceSimulator_SNMP_Schema_Simulation_Definitions)

## Attributes

|Name|Occurrences|Default Value|Description|
|--- |--- |--- |--- |
|OID |1 |Mandatory |The object identifier of the SNMP value. For example: `1.3.6.1.4.1.32473.1.0`. |
|Type |1 |Mandatory |The type of the SNMP value. See [Types](#types). |
|ReturnValue |1 |Mandatory |The SNMP value to return. |
|LogOutput |[0, 1] |Empty |The format for the log output. |
|Comment |[0, 1] |Empty |No longer used. |
|Delay |[0, 1] |*false* |No longer used. |
|Save |[0, 1] |*false* |No longer used. |
|SkipOID |[0, 1] |*false* |No longer used. |
|Weight |[0, 1] |*1* |The weight of the value when [MaxResponseWeight](xref:DeviceSimulator_SNMP_Schema_Simulation_Options_MaxResponseWeight) is used. |
|SameResponse |[0, 1] |*false* |Repeats this OID when the next OID is requested. Simulates an infinite loop. |

### Types

|Type (case insensitive) | Description  | Example ReturnValue |
|---|---|---|
|counter, counter32 |A 32-bit unsigned integer. When the maximum value is reached, it will roll over to 0. |12 |
|counter64 |A 64-bit unsigned integer. When the maximum value is reached, it will roll over to 0. |12 |
|endofmibview |The end of the MIB has been reached when performing GET-NEXT or GET-BULK operations. | |
|gauge, gauge32 |A non-negative 32-bit signed integer. |12 |
|integer, integer32 |A 32-bit signed integer. |-3 |
|ip, ipaddress |An IPv4 address or hostname that resolves to an IPv4 address. | 127.0.0.1 |
|nosuchinstance |The requested instance is not present in a table.  | |
|nosuchobject |The requested object does not exist in its MIB.  | |
|null |Null ASN.1 value type. | |
|objectid, object identifier |Unique identifier used to reference an object. |1.3.6.1.4.1.32473.1.0 |
|octetstring, octet string, octetstringasbytes, displaystring |UTF-8 encoded text. |John Doe |
|opaque |Used to support the transport of arbitrary data. The data itself is encoded as an octet string, but may be in any format defined by ASN.1 or another standard. |John Doe |
|timeticks |A non-negative 32-bit integer that counts time. The time is represented in hundredths (1/100th) of a second. | 100|

## See also

- [OIDs](xref:ConnectionsSnmpOids)
- [Protocol.Params.Param.SNMP.Type element](xref:Protocol.Params.Param.SNMP.Type)
