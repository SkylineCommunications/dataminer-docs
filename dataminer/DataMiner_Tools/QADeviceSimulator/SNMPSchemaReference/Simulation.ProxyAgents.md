---
uid: DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents
description: "Configure the ProxyAgents element in an SNMP simulation file, define one proxy agent, and copy the simulation for different agents."
---

# ProxyAgents element

Contains the proxy agents that should be available when the simulation file is spun up. However, the current Device Simulator does not support defining more than one agent.

## Parent

[Simulation](xref:DeviceSimulator_SNMP_Schema_Simulation)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|[ProxyAgent](xref:DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents_ProxyAgent)|1|Defines an agent.|

## Constraints

The simulator only supports one agent for the time being. To define different agents, you will need to copy and adjust the simulation.
