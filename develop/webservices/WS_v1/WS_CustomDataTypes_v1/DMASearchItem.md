---
uid: DMASearchItem
---

# DMASearchItem

| Item        | Format  | Description                                                                      |
|-------------|---------|----------------------------------------------------------------------------------|
| DataMinerID | Integer | The ID of the DataMiner Agent.                                                   |
| ElementID   | Integer | The ID of the element or the service (only if *Type* is “Element” or “Service”). |
| ID          | Integer | The ID of the view (only if *Type* is “View”).                                   |
| Name        | String  | The name of the element, service or view.                                        |
| Description | String  | “Element”, “Service” or “View”.                                                  |
| Type        | String  | The type of the item: “Element”, “Service” or “View”.                            |
| AlarmState  | String  | The current alarm severity of the element, service or view.                      |
| IsTimeout   | Boolean | Whether or not the element/service/view is in timeout.                           |
| Match       | String  | The text (name, protocol, ...) that matches the query.                           |
