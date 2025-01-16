---
uid: GetAlarmDetailsV2
---

# GetAlarmDetailsV2

Use this method to retrieve the alarm details for a specified alarm.

Available from DataMiner 10.3.0 [CU20]/10.4.0 [CU8]/10.4.11 onwards.<!-- RN 40240 -->

## Input

| Item       | Format  | Description                                           |
|------------|---------|-------------------------------------------------------|
| connection | String  | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID      | Integer | The DMA ID of the element.                            |
| elementID  | Integer | The element ID.                                       |
| alarmID    | Integer | The alarm ID.                                         |

## Output

| Item                    | Format    | Description                                    |
|-------------------------|-----------|------------------------------------------------|
| GetAlarmDetailsV2Result | [DMAAlarmDetails](xref:DMAAlarmDetails) | The alarm information for the specified alarm. |
