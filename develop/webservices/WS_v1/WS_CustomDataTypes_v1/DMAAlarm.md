---
uid: DMAAlarm
---

# DMAAlarm

| Item | Format | Description |
|------|--------|-------------|
| DataMinerID      | Integer         | The ID of the DataMiner Agent where the element was created. |
| HostingAgentID   | Integer         | The ID of the DataMiner Agent that is currently hosting the element. |
| ID               | Integer         | The ID of the alarm. |
| RootAlarmID      | Integer         | The ID of the root alarm (i.e. the first alarm in the alarm tree). |
| ElementID        | Integer         | The ID of the element. |
| ElementName      | String          | The name of the element. |
| IsElementMasked  | Boolean         | Whether or not the element is masked. |
| ParameterID      | Integer         | The ID of the parameter. |
| ParameterName    | String          | The name of the parameter. |
| TableIndex       | String          | The table index (in case the parameter is a table parameter). |
| DisplayValue     | String          | The display value (in case the parameter is a table parameter). |
| AlarmState       | String          | The current state of the alarm. |
| Type             | String          | The type of alarm (e.g. "New Alarm", "Escalated From Warning", "Dropped From Major", etc.). |
| IsAggregation    | Boolean         | Whether the alarm originates from an aggregation element. |
| IsMasked         | Boolean         | Whether or not the alarm is masked. |
| Services         | Array of string | The names of the services affected by the alarm. |
| TimeOfArrival    | String          | The time at which the alarm was created (local time of the DataMiner Agent).<br> Example: "2014-05-14 08:56:17" |
| TimeOfArrivalUTC | Long integer    | The time at which the alarm was created (milliseconds since midnight January 1, 1970 GMT).<br> Example: 1400050577000 |
| RootTime         | String          | The time at which the very first alarm in the alarm tree was created (local time of the DataMiner Agent).<br> Example: "2014-05-14 08:46:27" |
| RootTimeUTC      | Long integer    | The time at which the very first alarm in the alarm tree was created (milliseconds since midnight January 1, 1970 GMT).<br> Example: 1400049987000 |
| IsTrending       | Boolean         | Whether or not the parameter is being trended. |
| IsOwner          | Boolean         | Whether or not someone has taken ownership of the alarm. |
| OwnerName        | String          | The name of the person who currently owns the alarm. |
| LastChangeUTC    | Long integer    | The time when the alarm last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| IsCleared        | Boolean         | Whether the alarm is cleared.<!-- Added in DataMiner 9.5.5 --> |
