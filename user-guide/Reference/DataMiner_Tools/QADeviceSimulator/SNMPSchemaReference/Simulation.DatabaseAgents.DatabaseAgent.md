---
uid: DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents_DatabaseAgent
---

# DatabaseAgent element

Defines a simulation agent that uses data stored in a database to simulate a device.

For more information, follow the instructions on [realistic dynamic simulations](xref:Realistic_dynamic_simulations).

## Parent

[DatabaseAgents](xref:DeviceSimulator_SNMP_Schema_Simulation_DatabaseAgents)

## Attributes

### Inherited attributes

The same attributes as for a basic [agent](xref:DeviceSimulator_SNMP_Schema_Simulation_Agents_Agent#attributes) are available, but the database component adds some [additional attributes](#additional-attributes).

### Additional attributes

|Name|Occurrences|Default Value|Description|
|--- |--- |--- |--- |
|databaseType |1 |Mandatory |*MySQL* or *Cassandra*. |
|databaseServer |1 |Mandatory |The IP or hostname of the database endpoint. |
|databaseName |1 |Mandatory |The name of the database schema. |
|databaseTable |1 |Mandatory |The name of the database table. |
|user |1 |Mandatory |The username to authenticate with when querying the database. |
|password |1 |Mandatory |The password for the database user. |
