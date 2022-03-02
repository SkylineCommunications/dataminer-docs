---
uid: DMAView
---

# DMAView

| Item          | Format       | Description                                                                                               |
|---------------|--------------|-----------------------------------------------------------------------------------------------------------|
| ID            | Integer      | The ID of the view.                                                                                       |
| Name          | String       | The name of the view.                                                                                     |
| AlarmState    | String       | The current alarm state of the view.                                                                      |
| IsTimeout     | Boolean      | Indicates whether the view is in a timeout state.                                                         |
| ParentID      | Integer      | The ID of the parent view.                                                                                |
| HasVisio      | Boolean      | Indicates whether a Visio file is linked to the view.                                                     |
| HasChilds     | Boolean      | Indicates whether the view has child views.                                                               |
| HasElements   | Boolean      | Indicates whether the view has child elements                                                             |
| LastChangeUTC | Long integer | The time when the view was last changed, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| IsEnhanced    | Boolean      | Indicates whether the view is an enhanced view.                                                           |
