---
uid: AssignAlarmTemplate
---

# AssignAlarmTemplate

Use this method to assign an alarm template to one or more elements.<!-- Available from DataMiner 10.1.9 onwards. -->

## Input

| Item            | Format                | Description                                                                               |
|-----------------|-----------------------|-------------------------------------------------------------------------------------------|
| connection      | String                | The connection ID. See [ConnectApp](xref:ConnectApp).                                     |
| elements        | Array of [DMAElementID](xref:DMAElementID) | The DMA ID and element ID of each element to which the alarm template should be assigned. |
| protocolName    | String                | The name of the protocol to which the alarm template is assigned.                         |
| protocolVersion | String                | The version of the protocol to which the alarm template is assigned.                      |
| templateName    | String                | The name of the alarm template.                                                           |

## Output

None.
