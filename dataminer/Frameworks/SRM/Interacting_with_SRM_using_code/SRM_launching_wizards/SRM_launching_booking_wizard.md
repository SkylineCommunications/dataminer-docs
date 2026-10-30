---
uid: SRM_launching_booking_wizard
description: "Launch the standard Booking Wizard from a custom script with CreateNewBooking and set default service definition, timing, and resource values."
---

# Launching the standard Booking Wizard from a custom script

You can configure a custom frontend script to launch the standard Booking Wizard, and even provide default values for specific fields (service definition, timing, resources, etc.).<!-- RN 29937 -->

To do so, use the same code as is used to [silently create a booking](xref:SRM_creating_booking_silently), but use the overloaded *CreateNewBooking* method that accepts the *IsSilent* input argument:

```csharp
reservation = bookingManager.CreateNewBooking(engine, bookingData, functions, customEvents, properties, false);
```
