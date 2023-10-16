---
uid: SRM_1.2.33
---

# SRM 1.2.33

> [!NOTE]
> This version requires that **DataMiner 10.3.2.0 – 12627 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## New features

#### BookingManager.AddResource and BookingManager.RemoveResourceAndNode methods now support passing a service definition [ID_36792]

It is now possible to pass a service definition to the methods *BookingManager.AddResource* and *BookingManager.RemoveResourceAndNode*. The service definition must contain the correct functions; otherwise, the methods will have the previous behavior.

In addition, more logging has been added in the script *SRM_ResourceAction*.

#### New InputReference property in AssignResourceRequest class [ID_37080]

To support capacity reference in an *AssignResources* request, a new *InputReference* property has been added to the *AssignResourceRequest* class. If this property is set to null, no reference is taken into account.

## Changes

### Fixes

#### Problem when editing contributing booking without setting ConvertToContributing to true [ID_36716]

When a contributing booking was edited and *Booking.ConvertToContributing* was not passed as true, this could lead to corrupt data, as it is not possible to convert a contributing booking back to a normal booking. Now in such a case, an InvalidBookingDataException will be thrown.

#### Problem with disabled service state [ID_36736]

When the service state for an event was disabled, it could occur that the booking incorrectly got the service state -1, while actually the previous state had to be kept.

#### Profile instances with DOM references not imported with full configuration import [ID_36838]

When the full SRM configuration was imported, it could occur that profile instances with DOM references could not be imported.

#### Problem with SRM_CreateNewBooking if two services on different DMAs had the same ID [ID_36922]

When two services on different DMAs had the same ID, this could cause a problem in the *SRM_CreateNewBooking* script.

#### Skyline Profile Load Script Tester: Not possible to start or delete test case that was running when element/DataMiner restart occurred [ID_37253]

If the Skyline Profile Load Script Tester connector was running a test case and an element restart or DataMiner restart occurred, it was no longer possible to start or delete the test case entry in the corresponding table.

To resolve this issue, a new *Stop* button is now available. When you click this button, you will be able to start another test case or delete the current one. In the *Last Run Status* column, the entry corresponding to the test case will show *Aborted* to indicate what happened.
