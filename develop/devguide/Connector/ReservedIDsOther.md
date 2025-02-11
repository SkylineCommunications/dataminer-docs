---
uid: ReservedIDsOther
---

# Other reserved IDs

For protocol constructs such as triggers, commands, responses, pairs, groups, timers, actions, QActions, parameter groups, etc. the following IDs are reserved:

|Range|Owner|Minimum DMA version|Allowed|
|--- |--- |--- |--- |
|[1, 63 999]|Protocol|1.0.0|Yes|
|[64 000, 999 999]|DataMiner|1.0.0|No|
|[1 000 000, 9 999 999]|Protocol|9.0.4|Yes|
|10 000 000 or above|-|-|No|

For parameter groups, IDs larger than or equal to 10 000 should be avoided for existing connectors.

In legacy DataMiner versions prior to 9.0.4, the ID range 10 000+ was reserved for dynamic parameter groups. Previously assigned IDs remain reserved for existing elements.
