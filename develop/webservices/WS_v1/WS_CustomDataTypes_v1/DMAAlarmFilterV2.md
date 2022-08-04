---
uid: DMAAlarmFilterV2
---

# DMAAlarmFilterV2

| Item | Format | Description |
|--|--|--|
| History | Boolean | Set to True to retrieve history alarms. By default set to False, so only active alarms are retrieved. |
| SlidingWindow | Boolean | Set to True to retrieve alarms in a sliding window. |
| FilterItem |  [DMAAlarmFilterItem](xref:DMAAlarmFilterItem) | See [DMAAlarmFilterItem](xref:DMAAlarmFilterItem). |
| StartTime | Long integer | Only alarms newer than this UTC timestamp are retrieved. |
| EndTime | Long integer | Only alarms older than this UTC timestamp are retrieved. |
| Masked | Boolean | Set to true to retrieve masked alarms. (Default: false.) |
| InfoEvents | Boolean | Set to true to retrieve information events. (Default: false.) |
| FullAlarmTree | Boolean | Set to true to include the full alarm tree. By default set to false, so only the top-level alarms are retrieved. |
| Columns | Array of string | Available from DataMiner 9.5.7 onwards. Can contain one or more of the following values, corresponding to Alarm Console columns: <br> -  status<br> -  comment<br> -  source<br> -  creation time<br> -  root creation time<br> -  category<br> -  description<br> -  corrective action<br> -  component info<br> -  key point<br> -  offline impact<br> -  interface impact<br> -  interfaces<br> -  view impact<br> -  views<br> -  function impact<br> -  functions<br> -  alarm.*propertyname* (propertyname being the name of the alarm property)<br> -  element.*propertyname* (propertyname being the name of the element property)<br> -  service.*propertyname* (propertyname being the name of the service property)<br> -  view.*propertyname* (propertyname being the name of the view property)<br> -  protocol.*propertyname* (propertyname being the name of the protocol property) |
| Limit | Integer | The maximum number of alarms to include. (By default: 100.) |
| SortBy | Array of string | The field(s) by which the alarms should be sorted. |
| SortAscending | Boolean | Determines whether alarms should be sorted in ascending or descending order. |
