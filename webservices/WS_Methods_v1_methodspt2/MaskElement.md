---
uid: MaskElement
---

# MaskElement

Use this method to mask an element for a certain period of time.

## Input

| Item          | Format  | Description                                                                                                                                                                                                                                                                                                                            |
|---------------|---------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Connection    | String  | The connection ID. See [ConnectApp](xref:ConnectApp) .                                                                                                                                                                                                                                                       |
| DmaID         | Integer | The DataMiner Agent ID.                                                                                                                                                                                                                                                                                                                |
| ElementID     | Integer | The element ID.                                                                                                                                                                                                                                                                                                                        |
| ClearInterval | Integer | The period of time (in seconds) during which the element will be masked.<br> -  Set to -1 if the alarm has to be masked until clearance.<br> -  Set to -2 if the alarm has to be masked until unmasking. |
| Comment       | String  | Extra information.                                                                                                                                                                                                                                                                                                                     |

## Output

None.

