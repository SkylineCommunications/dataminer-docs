---
uid: DMARedundancyElement
---

# DMARedundancyElement

| Item | Format | Description |
|------|--------|-------------|
| DataMinerID      | Integer      | The ID of the DataMiner Agent. |
| ID               | Integer      | The ID of the element. |
| Name             | String       | The name of the element. |
| AlarmState       | String       | The current alarm state of the element. |
| State            | String       | The current state of the element. |
| RedundancyType   | String       | The type of redundancy element: “Primary”, “Backup” or “State”. |
| RedundancyStatus | String       | The status of the element within the redundancy group: “Failed”, “Available”, “Unavailable”, “Error”, “Switching” or “Operational for primary element \[element name\]”, ... |
| IsInMaintenance  | Boolean      | Whether or not the element is in maintenance. |
| LastChangeUTC    | Long integer | The time when the object was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
