---
uid: DeviceSimulator_SNMP_Schema_Simulation_Options_MaxResponseWeight
---

# MaxResponseWeight element

Default: Int32.MaxValue (2147483647).

This option sets the maximum weight of an SNMP response message. The weight of each value added to the response is combined, and when the next value to add would breach the maximum weight, it is dropped. This can be useful to simulate devices where large responses are resulting in partial responses, without having to actually use large values in the simulation.

For example, if MaxResponseWeight is 1024, and you request nextOid with 5 repetitions:

1. OID 1 with weight 1 is added (total: 1).
1. OID 2 with weight 1000 is added (total: 1001).
1. OID 3 with weight 1 is added (total: 1002).
1. OID 4 with weight 1000 is dropped (2002 exceeds 1024).
1. OID 5 is no longer considered.

The response is sent with OIDs 1 through 3 with a total weight of 1002.

## Parent

[Options](xref:DeviceSimulator_SNMP_Schema_Simulation_Options)
