---
uid: DMARedundancyGroup
---

# DMARedundancyGroup

| Item            | Format                                                                                                    | Description                                                                                                           |
|-----------------|-----------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------|
| DataMinerID     | Integer                                                                                                   | The ID of the DataMiner Agent.                                                                                        |
| ID              | Integer                                                                                                   | The ID of the redundancy group.                                                                                       |
| Name            | String                                                                                                    | The name of the redundancy group.                                                                                     |
| AlarmState      | String                                                                                                    | The current alarm state of the redundancy group.                                                                      |
| Status          | String                                                                                                    | The status of the redundancy group: “Undefined”, “Available”, “Operational”, “Unavailable”, “Error” or “Switching”.   |
| Mode            | String                                                                                                    | The redundancy mode: “Undefined”, “Automatic”, “ManualSwitchBack” or “Manual”.                                        |
| VirtualElements | Array of DMARedundan­cyVirtualElement (see [DMARedundancyVirtualElement](xref:DMARedundancyVirtualElement)) | The list of virtual elements in the redundancy group.                                                                 |
| Elements        | Array of DMARedundan­cyElement (see [DMARedundancyElement](xref:DMARedundancyElement))                      | The list of elements in the redundancy group.                                                                         |
| LastChangeUTC   | Long integer                                                                                              | The time when the redundancy group was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
