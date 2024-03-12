---
uid: DOM_ReservationFieldDescriptor
---

# ReservationFieldDescriptor

- **FieldValue type**: `Guid` of an SRM `ReservationInstance`
- **Multiple values optional**: :heavy_check_mark:

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| Reservation | Guid | Guid |
| Reservation with multiple values enabled| List\<Guid\> | Guid (ListValueWrapper) |

Defines a field that has the `Guid` of an SRM `(Service)ReservationInstance`.

The `ReservationFieldDescriptor` lists all ReservationInstances, the `Guid` of the selected `ReservationInstance` is saved.

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

instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, GuidOfReservationInstance); // type should be Guid

// example with multiple values enabled 
instance.AddOrUpdateFieldValue(sectionDefinition, descriptor, new ListValueWrapper<Guid>(Guid1, Guid2));
```