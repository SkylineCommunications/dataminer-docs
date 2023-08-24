---
uid: DeviceSimulator_SNMP_Schema_Simulation
---

# Simulation element

The root element of the SNMP simulation file.

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|[Agents](xref:DeviceSimulator_SNMP_Schema_Simulation_Agents) |1 |Defines the simulation endpoints. |
|[Options](xref:DeviceSimulator_SNMP_Schema_Simulation_Options) |[0, 1] |A list of generic options regarding the simulation. |
|[DefaultDefinitionAttributes](xref:DeviceSimulator_SNMP_Schema_Simulation_DefaultDefinitionAttributes) |[0, 1] |Sets the default attributes for the [definition](xref:DeviceSimulator_SNMP_Schema_Simulation_Definitions_Definition) elements, |
|[Definitions](xref:DeviceSimulator_SNMP_Schema_Simulation_Definitions) |1 |The list of simulated OIDs and their corresponding values. |
