---
uid: DMAAlarmDetails
---

# DMAAlarmDetails

| Item | Format | Description |
|--|--|--|
| Category | String | Custom category that can be assigned to a parameter using the information template. |
| CorrectiveAction | String | Description of corrective actions that should be taken, which can be customized with the information template. |
| ComponentInfo | String | Information on the nature of the alarm. Used in DMS Business Intelligence. |
| Comments | String | Comments that have been added to the alarm, either by DataMiner users or by the system. |
| KeyPoint | String | The exact location in the signal chain where the error has occurred. Used in DMS Business Intelligence. |
| OfflineImpact | String | Indicates whether the alarm has an impact during the offline window of an SLA. Used in DMS Business Intelligence. |
| AffectedView | [DMAObject](xref:DMAObject) | The DataMiner ID, ID and name of the view affected by the alarm. |
| AffectedServices | Array of [DMAObject](xref:DMAObject) | The DataMiner ID, ID and name of the services affected by the alarm. |
| AffectedVirtualFunctions | Array of [DMAObject](xref:DMAObject) | The DataMiner ID, ID and name of the virtual functions affected by the alarm. |
| PropertiesAlarm | Array of [DMAProperty](xref:DMAProperty) | The properties of the alarm. |
| PropertiesElement | Array of [DMAProperty](xref:DMAProperty) | The properties of the affected element. |
| PropertiesService | Array of [DMAProperty](xref:DMAProperty) | The properties of the affected service(s). |
| PropertiesView | Array of [DMAProperty](xref:DMAProperty) | The properties of the affected view. |
| PropertiesProtocol | Array of [DMAProperty](xref:DMAProperty) | The properties of the affected protocol. |
