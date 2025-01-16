---
uid: AddCommentToAlarmV2
---

# AddCommentToAlarmV2

Use this method to add a comment to an alarm.

Available from DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards.<!-- RN 40240 -->

## Input

| Item        | Format  | Description |
|-------------|---------|-------------|
| connection  | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID       | Integer | The DMA ID of the element. |
| elementID   | Integer | The element ID. |
| rootAlarmID | Integer | The root alarm ID. |
| comment     | String  | The comment to be added to the alarm. |

## Output

None.
