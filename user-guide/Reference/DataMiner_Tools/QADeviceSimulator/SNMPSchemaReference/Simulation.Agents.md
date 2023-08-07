---
uid: DeviceSimulator_SNMP_Schema_Simulation_Agents
---

# Agents element

Contains the agents that should be available when the simulation file is spun up. However, the current Device Simulator does not support defining more than one agent.

## Parent

[Simulation](xref:DeviceSimulator_SNMP_Schema_Simulation)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|[Agent](xref:DeviceSimulator_SNMP_Schema_Simulation_Agents_Agent)|1|Defines an agent.|

## Constraints

The simulator only supports one agent for the time being. To define different agents, you will need to copy and adjust the simulation.
