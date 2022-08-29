---
uid: AlarmEventMessage
---

# AlarmEventMessage

| Item | Format | Description |
|--|--|--|
| AlarmID | Integer | The alarm ID. |
| TimeOfArrival | DateTime | The time at which the alarm occurred. |
| TypeID | Integer | The type of the alarm: “New Alarm”, “Cleared”, “Mask”, “Unmask”, “Dropped from ...”, “Escalated from ...”, ... |
| Value | String | The raw alarm value as it is stored in the database. See *DisplayValue* below. |
| StatusID | Integer | The current status of the alarm: “Open” (12), “Cleared” (11), “Mask” (25), ... |
| SeverityID | Integer | The alarm severity: “Critical” (1), “Major”, “Minor”, “Warning”, “Normal” (5), “Timeout” (17), “Error” (24), “Notice” (28), ... |
| SeverityRangeID | Integer | The severity range: “Normal” (5), “High” (6), “Low” (7) |
| UserStatusID | Integer | The user Status: “Not Assigned” (18), ... |
| Comments | String | The comments associated with the alarm. |
| Owner | String | The user who owns the alarm. |
| SourceID | Integer | The ID of the module that generated the alarm. Example: 16 = SLDataMiner |
| PrevAlarmID | Integer | The ID of the previous alarm in the tree to which this alarm record belongs. If the alarm is the first alarm in a tree, PrevAlarmID is 0. |
| RootAlarmID | Integer | The ID of the first alarm in the tree to which this alarm record belongs. |
| ElementName | String | The name of the element on which the alarm occurred. |
| ElementType | String | The type of the element on which the alarm occurred. |
| ParameterName | String | The name of the parameter on which the alarm occurred. |
| DisplayValue | String | The textual representation of the alarm value. This representation includes units and has transformations (e.g. discreet mappings) applied. See *Value* above. |
| RootTime | DateTime | The timestamp of the first alarm in the tree to which this alarm record belongs. |
| Services | Array of string | The list of DmaId/ElementId pairs referring to the services in which the alarm is included. |
| ParentServices | Array of AlarmServiceInfo | Information about the services in which this alarm is included. Each AlarmServiceInfo object contains a service name a DmaId/ServiceId pair. |
| Interfaces | Array of string | The list of DmaId/InterfaceId pairs referring to the interfaces in which the alarm is included. |
| ParentInterfaces | Array of AlarmInterfaceInfo | Information about the interfaces in which the alarm is included. Each AlarmInterfaceInfo object contains a custom interface name and a DmaId/InterfaceID pair. |
| CorrelationReferences | Array of CorrelationReference | Array of references to Correlation alarms on the alarm. |
| BaseAlarms | Array of string | In case of a correlated alarm: The list of DmaId/AlarmId pairs referring to the raw alarms on which the correlated alarm is based. |
| IsNew | Boolean | Whether or not the alarm is new. |
| IsLastHistory | Boolean | Indicates whether an alarm is the most recent one in the history tree. |
| Links | Array of AlarmLinkItem | Hyperlinks to webpages or executable commands. |
| RCALevel | Integer | The root cause analysis level. |
| Properties | Array of PropertyInfo | The properties of the alarm. |
| CreationTime | DateTime | The time when the alarm was created in DataMiner. |
| RootCreationTime | DateTime | The time when the first alarm in the alarm tree was created in DataMiner. |
| ViewImpactInfo | Array of AlarmViewInfo | The views affected by the alarm. |
| ParameterRCALevel | Integer | The RCA level of the parameter. |
| ServiceRCALevel | Integer | The RCA level of the service. |
| Category | String | Custom category that can be assigned to a parameter using the information template. |
| Description | String | User-friendly description of the alarm, which can be customized with the information template. |
| CorrectiveAction | String | Description of corrective actions that should be taken, which can be customized with the information template. |
| InterpretTableIdx | Boolean | Indicates whether the table index needs to be interpreted by the client. Used for DVE elements. |
| KeyPoint | String | The exact location in the signal chain where the issue occurred. Used in DMS Business Intelligence. |
| OfflineImpact | Boolean | Indicates whether the alarm has an impact during the offline window of an SLA. Used in DMS Business Intelligence. |
| ComponentInfo | String | Contains more information about the nature of the alarm. Used in DMS Business Intelligence. |
| TableIdxPk | String | The primary key of the table index. |
