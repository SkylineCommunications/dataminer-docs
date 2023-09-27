---
uid: DMAAlarmTemplate
---

# DMAAlarmTemplate

| Item | Format | Description |
|--|--|--|
| Name | String | The name of the alarm template. |
| ProtocolName | String | The name of the protocol to which the alarm template is applied. |
| ProtocolVersion | String | The version of the protocol to which the alarm template is applied. |
| Description | String | The description of the alarm template. |
| IsScheduleEnabled | Boolean | Whether an alarm template schedule is enabled. |
| Type | String | *Template* in case of a regular alarm template, *Group* in case of an alarm template group. |
| IsUsedInGroup | Boolean | Whether the alarm template is used in a group. |
| Conditions | Array of DMAAlarmTemplateCondition | See [DMAAlarmTemplateCondition](xref:DMAAlarmTemplateCondition). |
| Parameters | Array of DMAAlarmTemplateParameter | See [DMAAlarmTemplateParameter](xref:DMAAlarmTemplateParameter). |
| GroupEntries | Array of DMAAlarmTemplateGroupEntry | See [DMAAlarmTemplateGroupEntry](xref:DMAAlarmTemplateGroupEntry). |
| Schedule | Array of DMAAlarmTemplateScheduleEntry | See [DMAAlarmTemplateScheduleEntry](xref:DMAAlarmTemplateScheduleEntry). |
