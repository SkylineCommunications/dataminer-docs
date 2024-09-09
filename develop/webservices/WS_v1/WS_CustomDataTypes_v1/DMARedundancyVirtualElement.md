---
uid: DMARedundancyVirtualElement
---

# DMARedundancyVirtualElement

| Item | Format | Description |
|------|--------|-------------|
| DataMinerID      | Integer      | The ID of the DataMiner Agent. |
| DerivedID        | Integer      | The ID of the derived element. |
| DerivedName      | String       | The name of the derived element. |
| RedundancyStatus | String       | The status of the virtual element: “Primary is operational”, “Backup is operational”, “Unavailable”, “Error” or “Switching”. |
| LastChangeUTC    | Long integer | The time when the object was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
