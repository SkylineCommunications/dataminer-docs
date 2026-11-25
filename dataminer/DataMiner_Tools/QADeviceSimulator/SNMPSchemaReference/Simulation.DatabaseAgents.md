---
uid: DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents
description: "Configure the DatabaseAgents element in an SNMP simulation file, define one database agent, and copy the simulation for different agents."
---

# DatabaseAgents element

Contains the database agents that should be available when the simulation file is spun up. However, the current Device Simulator does not support defining more than one agent.

## Parent

[Simulation](xref:DeviceSimulator_SNMP_Schema_Simulation)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|[DatabaseAgent](xref:DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents_DatabaseAgent)|1|Defines an agent.|

## Constraints

The simulator only supports one agent for the time being. To define different agents, you will need to copy and adjust the simulation.
