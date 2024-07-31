---
uid: DMABookingLite
---

# DMABookingLite

| Item           | Format       | Description     |
|----------------|--------------|-----------------|
| ID             | GUID         | The GUID of the booking. |
| Name           | String       | The name of the booking. |
| Description    | String       | The description of the booking. |
| CreatedAt      | Long Integer | The time when the booking was created. |
| CreatedBy      | String       | The user who created the booking. |
| LastModifiedAt | Long Integer | The time when the booking was last modified. |
| LastModifiedBy | String       | The user who last modified the booking. |
| StartTimeUTC   | Long Integer | The start time of the booking, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| EndTimeUTC     | Long Integer | The start time of the booking, in UTC format (milliseconds since midnight January 1, 1970 GMT). |
| State          | String       | The current state of the booking. |
| ContributingResourceID | String | The ID of the contributing resource. |
| ResourceDefinitions    | Array of DMAResourceDefinition | The service definition node IDs and the resources assigned to those nodes. |
| Properties             | Array of DMABookingProperty    | The key, value and type of each booking property. |
