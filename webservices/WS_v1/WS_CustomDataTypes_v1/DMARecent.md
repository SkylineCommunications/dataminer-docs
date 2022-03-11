---
uid: DMARecent
---

# DMARecent

| Item | Format | Description |
|--|--|--|
| Type | String | “Element” or “Service” |
| DataMinerID | Integer | The ID of the DataMiner Agent. |
| ID | Integer | The ID of the element or the service. |
| Name | String | The name of the element or the service. |
| SubText | String | The name of the protocol (only if Type is “Element”). |
| AlarmState | String | The current alarm state of the element or the service. |
| IsTimeout | Boolean | Whether the element or service is in timeout. |
| ElementState | String | State of the element: “Active”, “Paused”, “Stopped”, “Error”, “Masked” or “Hidden”. |
| Position | Integer | Position of the element/service in the list of most recent or nearby items. The smaller the number, the higher the item is on the list. |
| IsPinned | Boolean | Whether the element/service is pinned in the Recent list. |
| Latitude | Double | Latitude of the element/service (if specified in the properties of the element/service). |
| Longitude | Double | Longitude of the element/service (if specified in the properties of the element/service). |
