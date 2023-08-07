---
uid: DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents_ProxyAgent
---

# ProxyAgent element

Defines a simulation agent that acts as a proxy for requests and responses with a device and client. The intercepted messages will be stored to build a simulation.

For more information, follow the instructions on [realistic dynamic simulations](xref:Realistic_dynamic_simulations).

## Parent

[ProxyAgents](xref:DeviceSimulator_SNMP_Schema_Simulation_ProxyAgents)

## Attributes

### Inherited attributes

The same attributes as for a basic [agent](xref:DeviceSimulator_SNMP_Schema_Simulation_Agents_Agent#attributes) are available, but the database component adds some [additional attributes](#additional-attributes).

### Additional attributes

|Name|Occurrences|Default Value|Description|
|--- |--- |--- |--- |
|deviceIP |1 |Mandatory |The IP of the device for which the simulator is acting as a proxy. |
|devicePort |[0, 1] |*161* |The network port of the device. |
|maxFileSize |[0, 1] |*1024* |The maximum size of the file in MB that the variable bindings are written to. In case the file becomes too big, a new file will be created. |
|maxDuration |[0, 1] |*1.0* |This maximum duration of the proxy simulation in hours. |
