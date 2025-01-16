---
uid: MaskAlarmV2
---

# MaskAlarmV2

Use this method to mask an alarm for a certain period of time.

Available from DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards.<!-- RN 40240 -->

## Input

| Item | Format | Description |
|--|--|--|
| connection    | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID         | Integer | The DMA ID of the element. |
| elementID     | Integer | The element ID. |
| rootAlarmID   | Integer | The root alarm ID. |
| clearInterval | Integer | The period of time (in seconds) during which the alarm will be masked.<br>Set to -1 if the alarm has to be masked until clearance. |
| comment       | String | Extra information. |

## Output

None.
