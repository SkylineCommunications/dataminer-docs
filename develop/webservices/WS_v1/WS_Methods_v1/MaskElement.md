---
uid: MaskElement
---

# MaskElement

Use this method to mask an element for a certain period of time.

## Input

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| clearInterval | Integer | The period of time (in seconds) during which the element will be masked.<br>Set to -1 if the alarm has to be masked until clearance.<br>Set to -2 if the alarm has to be masked until unmasking. |
| comment | String | Extra information. |

## Output

None.
