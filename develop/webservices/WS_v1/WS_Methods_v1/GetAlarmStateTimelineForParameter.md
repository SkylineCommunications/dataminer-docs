---
uid: GetAlarmStateTimelineForParameter
---

# GetAlarmStateTimelineForParameter

Use this method to retrieve the alarm state timeline for a particular parameter.

## Input

> [!IMPORTANT]
> From DataMiner 10.5.0 [CU17]/10.6.0 [CU5]/10.6.8 onwards<!--RN 45600-->, before you request timeline data using this web method, first send the [`IsFeatureAvailable` web method](xref:IsFeatureAvailable) with `featureName` set to `DKForReport` to check whether the DataMiner Agent requires you to send the display key or the primary key (see: [Display keys](xref:UIComponentsTableDisplayKeys)).
>
> - If the method returns `true`, send the display key.
> - If the method returns `false`, send the primary key.

| Item | Format | Description |
|--|--|--|
| connection | String | The connection ID. See [ConnectApp](xref:ConnectApp). |
| dmaID | Integer | The DataMiner Agent ID. |
| elementID | Integer | The element ID. |
| parameterID | Integer | The parameter ID. |
| tableIndex | String | The table index. This field must be specified for table column parameters; otherwise it must be left empty. |
| utcStartTime | Long integer | The start time of the time span for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| utcEndTime | Long integer | The end time of the time span for which alarm state changes should be retrieved, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| maxPoints | Integer | The maximum number of alarm state changes that should be returned. |

## Output

| Item | Format | Description |
|--|--|--|
| GetAlarmStateTimelineForParameterResult | [DMATimeline](xref:DMATimeline) | An array of alarm state changes along with the start time and end time of the time span in which they occur. |
