---
uid: ReservedIDsEnhancedService
---

# Enhanced service

| Range Start | Range End | Contents                                                                                         |
|-------------|-----------|--------------------------------------------------------------------------------------------------|
| 1           | 999       | Cannot be used by enhanced service protocols for any purpose other than what is mentioned below. |

- Param 1 is used to forward the service name to the enhanced service element.
- Param 2 is used to forward the service severity to the enhanced service element.
- Param 3 is used to forward the element severity to the enhanced service element.
- Param 4 is used to forward active alarms to the enhanced service element protocol.
- Param 11 is used to forward the enhanced service severity to the enhanced service element.
- Param 14 is used to forward history properties.
- Param 198-199 is "monitor_active_alarms".
- Param 200 is a table (columns 201-213) for the active alarms (RN 12978).

> [!TIP]
> For more information on the implementation of these parameters, see [Service](xref:ConnectionsService).
