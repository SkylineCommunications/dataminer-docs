---
uid: DOM_ReservationFieldDescriptor
---

# ReservationFieldDescriptor

- **FieldValue type**: `GUID` of an SRM `ReservationInstance`
- **Multiple values optional**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Reservation | Guid | Guid |
| Reservation with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `GUID` of an SRM `(Service)ReservationInstance`.

The `ReservationFieldDescriptor` lists all ReservationInstances, the selected `ReservationInstance` is saved as their `GUID`.

```csharp
var descriptor = new ReservationFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "ReservationFieldDescriptor",
    FieldType = typeof(Guid)
};
```

To enable multiple values, set the FieldType to `List<Guid>`.