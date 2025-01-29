---
uid: DMAElement1
---

# DMAElement

| Item | Format | Description |
|--|--|---|
| DmaID | Integer | The DataMiner Agent ID. |
| ID | Integer | The element ID (or service ID). |
| Name | String | The element name (or service name). |
| AlarmState | String | The current alarm state of the element. |
| Properties | Array of (Array of String) | Name and value of all properties of the element (or service). |
| Extra | Array of (Array of String) | Extra information:<br> For *GetElementbyPollingIP*, *GetElements*, *GetServiceElementListByID* and *GetServiceElementListByName*:<br> -  Protocol name<br> -  Protocol version<br> -  Current element state<br> For *GetServices*:<br> -  Service template name<br> -  Current service state |

> [!NOTE]
> For the "Extra" item, for the methods *GetServiceElementListByID* or *GetServiceElementListByName*, if the service child is a service, the three fields will contain "SERVICE", "", and "" respectively.
