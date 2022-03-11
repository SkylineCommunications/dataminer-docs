---
uid: DMABooking
---

# DMABooking

| Item                   | Format                          | Description                                                                |
|------------------------|---------------------------------|----------------------------------------------------------------------------|
| Description            | String                          | The description of the booking.                                            |
| CreatedAt              | Long integer                    | The time when the booking was created.                                     |
| CreatedBy              | String                          | The user who created the booking.                                          |
| LastModifiedAt         | Long integer                    | The time when the booking was last modified.                               |
| LastModifiedBy         | String                          | The user who last modified the booking.                                    |
| ResourceDefinitions    | Array of DMAResourceDefinition  | The service definition node IDs and the resources assigned to those nodes. |
| ServiceDefinition      | Array of string                 | The ID and name of the service definition.                                 |
| DataMinerID            | Integer                         | the DataMiner Agent ID.                                                    |
| ServiceID              | Integer                         | The service ID.                                                            |
| Properties             | Array of DMABookingProperty     | The key, value and type of each booking property.                          |
| ContributingResourceID | String                          | The ID of the contributing resource.                                       |
