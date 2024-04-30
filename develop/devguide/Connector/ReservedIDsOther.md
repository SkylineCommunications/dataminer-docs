---
uid: ReservedIDsOther
---

# Other reserved IDs

For the other protocol constructs such as triggers, commands, responses, pairs, groups, timers, actions, QActions, parameter groups, etc. the following applies:

|Range|Owner|Minimum DMA version|Allowed|
|--- |--- |--- |--- |
|[1, 63 999]|Protocol|1.0.0|Yes|
|[64 000, 999 999]|DataMiner|1.0.0|No|
|[1 000 000, 9 999 999]|Protocol|9.0.4|Yes|
|10 000 000 or above|-|-|No|

For parameter groups, IDs larger than or equal to 10 000 should be avoided for existing drivers, as well as for drivers intended to be used with DataMiner versions before 9.0.4 (ID range 10 000+ was used for dynamic parameter groups prior to version 9.0.4. Previously assigned IDs remain reserved for existing elements).
