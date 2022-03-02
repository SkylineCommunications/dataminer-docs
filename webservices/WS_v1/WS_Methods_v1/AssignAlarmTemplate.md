---
uid: AssignAlarmTemplate
---

# AssignAlarmTemplate

Use this method to assign an alarm template to one or more elements. Available from DataMiner 10.1.9 onwards.

## Input

| Item            | Format                | Description                                                                               |
|-----------------|-----------------------|-------------------------------------------------------------------------------------------|
| Connection      | String                | The connection ID. See [ConnectApp](xref:ConnectApp) .                                      |
| Elements        | Array of DMAElementID | The DMA ID and element ID of each element to which the alarm template should be assigned. |
| ProtocolName    | String                | The name of the protocol to which the alarm template is assigned.                         |
| ProtocolVersion | String                | The version of the protocol to which the alarm template is assigned.                      |
| TemplateName    | String                | The name of the alarm template.                                                           |

## Output

None.

