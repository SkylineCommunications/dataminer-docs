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
|OID |1 |Mandatory |The object identifier of the SNMP value. |
|Type |1 |Mandatory |The type of the SNMP value. |
|ReturnValue |1 |Mandatory |The SNMP value to return. |
|LogOutput |[0, 1] |Empty |The format for the log output. |
|Comment |[0, 1] |Empty |No longer used. |
|Delay |[0, 1] |*false* |No longer used. |
|Save |[0, 1] |*false* |No longer used. |
|SkipOID |[0, 1] |*false* |No longer used. |
|Weight |[0, 1] |*1* |The weight of the value when [MaxResponseWeight](xref:DeviceSimulator_SNMP_Schema_Simulation_Options_MaxResponseWeight) is used. |
|SameResponse |[0, 1] |*false* |Repeats this OID when the next OID is requested. Simulates an infinite loop. |
