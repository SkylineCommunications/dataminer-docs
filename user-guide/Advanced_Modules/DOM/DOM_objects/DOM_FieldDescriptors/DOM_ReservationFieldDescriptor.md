---
uid: DOM_ReservationFieldDescriptor
---

# ReservationFieldDescriptor

- **FieldValue type**: Guid
- **FieldValue example**: 0d911285-0232-4610-8bd8-ebbebc9cdc29 (ID of an [SRM booking](xref:srm_instantiations#booking))
- **Multiple values supported**: :heavy_check_mark: (since DataMiner 10.2.3/10.3.0)
- **Available since**: DataMiner 10.1.2/10.2.0

| Type of Descriptor | FieldType | FieldValue type |
|--------------------|-----------|-----------------|
| References a single SRM booking | Guid | Guid |
| References one or more SRM bookings | List\<Guid\> | Guid (ListValueWrapper) |

Defines a DOM field that references an SRM booking (`ReservationInstance`) by storing the ID of that booking in the form of a `Guid`. The validity and existence of the booking is not checked server-side. However, when a value is displayed in the DOM low-code app form, it will be marked invalid when the booking does not exist in the DMS.

## Defining the FieldDescriptor

To enable multiple values, set the FieldType to `List<Guid>`.

```csharp
var descriptor = new ReservationFieldDescriptor
{
    ID = new FieldDescriptorID(Guid.NewGuid()),
    Name = "My reservation reference field",
    FieldType = typeof(Guid)
};
```

## Adding a value for the FieldDescriptor

```csharp
var instance = new DomInstance
{
    ID = new DomInstanceId(Guid.NewGuid()),
    DomDefinitionId = domDefinitionId
};

// Single value
var reservationId = Guid.Parse("8000971e-982a-2151-10a2-1803aa100359");
instance.AddOrUpdateFieldValue(sectionDefinitionId, fieldDescriptorId, reservationId);

// Multiple values
var firstReservationId = Guid.Parse("755a424e-783f-466d-981e-8359fd0ca426");
var secondReservationId = Guid.Parse("16da2b5d-6b43-4267-96ba-4abd5c16ee2b");
instance.AddOrUpdateListFieldValue(sectionDefinitionId, fieldDescriptorId, new List<Guid> { firstReservationId, secondReservationId });
```
