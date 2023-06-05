---
uid: DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents
---

# DatabaseAgents element

Contains the database agents that should be available when the simulation file is spun up. However, the current Device Simulator only supports one agent to be defined.

## Parent

[Simulation](xref:DeviceSimulator_SNMP_Schema_Simulation)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|[DatabaseAgent](xref:DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents_DatabaseAgent)|1|Defines an agent.|

## Constraints

The simulator only supports one agent for the time being. To define different agents, the simulation will need to be copied and adjusted.