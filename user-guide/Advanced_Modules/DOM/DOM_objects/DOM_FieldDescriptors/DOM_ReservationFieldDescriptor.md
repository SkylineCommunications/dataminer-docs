---
uid: DOM_ReservationFieldDescriptor
---

# ReservationFieldDescriptor

- **FieldValue type**: `Guid`
- **Multiple values optional**: :heavy_check_mark:
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single `Reservation` | Guid | Guid |
| References one or more `Reservations` | List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `Guid` of an SRM `(Service)ReservationInstance`. The `ReservationFieldDescriptor` lists all ReservationInstances.

To enable multiple values, set the FieldType to `List<Guid>`.

```csharp
var descriptor = new ReservationFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ReservationFieldDescriptor",
    FieldType = typeof(Guid)
};
```

Assigning a `FieldValue` to the `FieldDescriptor` of a new `DomInstance`:

```csharp
var instance = new DomInstance 
{        
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

var reservationId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, reservationId);

var firstReservationId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondReservationId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");

// Example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(firstReservationId, secondReservationId));
```