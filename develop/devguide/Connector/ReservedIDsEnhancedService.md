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
- Param 4 is used to forward active alarms to the enhanced service element protocol in systems that use a DataMiner version prior to 10.5.1/10.6.0 or where the [Swarming](xref:Swarming) feature is not enabled and no parameter 7 is available. Alarm references in the active alarms table or passed into this parameter 4 are of the legacy format `dmaid/rootalarmid` or `dma/alarmid`.
- Param 7 is used to forward active alarms to the enhanced service element protocol in systems using DataMiner 10.5.1/10.6.0 or higher.<!-- RN 41260 --> Alarm references in the active alarms table or passed into this parameter 7 are of the full format `dmaid/eid/rootalarmid` or `dma/eid/rootalarmid/alarmid`.
- Param 11 is used to forward the enhanced service severity to the enhanced service element.
- Param 14 is used to forward history properties.
- Param 198-199 is "monitor_active_alarms". When this is set to 1, DataMiner will fill out the active alarms table in parameter 200.
- Param 200 is a table (columns 201-213) for the active alarms (RN 12978).

> [!TIP]
> For more information on the implementation of these parameters, see [Service](xref:ConnectionsService).
