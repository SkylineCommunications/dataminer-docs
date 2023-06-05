---
uid: DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents
---

# ProxyAgents element

Contains the proxy agents that should be available when the simulation file is spun up. However, the current Device Simulator only supports one agent to be defined.

## Parent

[Simulation](xref:DeviceSimulator_SNMP_Schema_Simulation)

## Children

|Name|Occurrences|Description|
|--- |--- |--- |
|[ProxyAgent](xref:DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents_ProxyAgent)|1|Defines an agent.|

## Constraints

The simulator only supports one agent for the time being. To define different agents, the simulation will need to be copied and adjusted.