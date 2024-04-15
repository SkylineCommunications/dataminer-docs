---
uid: SRM_10.3.0.5
---

# SRM 10.3.0.5

> [!NOTE]
> This version requires that **DataMiner 10.3.0 [CU0] or higher** is installed. It is not compatible with the DataMiner Feature Release track.

## Enhancements

#### New ServiceManagement.CreateReservationService method [ID_39096]

A new method, *ServiceManagement.CreateReservationService*, is now available, which will create a service for an existing booking.

#### Support added for updated service creation behavior [ID_39162]

In DataMiner [10.4.5](xref:General_Feature_Release_10.4.5#not-possible-to-delete-a-service-created-via-an-srm-booking-when-it-had-been-assigned-a-name-that-was-already-being-used-id_38914) (as well as 10.3.0 [CU14] and 10.4.0 [CU2]), to prevent an issue when a service was created via an SRM booking and it had an error because the name was already in use by another object, new behavior was introduced when an SRM service is create with a name that already exists. Previously, when an existing name was passed with a different ID, the existing service name was returned, while now an error is thrown. The SRM Solution has now been adapted to support this new behavior, while also remaining compatible with the previous behavior.

#### Support for regular resources linked to elements in SRM_DiscoverResources script [ID_39187]

The *SRM_DiscoverResources* script now supports regular resources linked to elements. If a regular resource has a DMA ID and element ID linked to it, the *Element Name* column in the Excel file exported by the script will be filled in with the name of the linked element. Similarly, when you import an Excel file with the script, and the *Element Name* column is filled in with a valid element name, the *DmaID* and *ElementID* properties of the resource will be filled in with the element info.

#### Ability added to disable Booking Friendly Reference [ID_39199]

On the Configuration page of the Booking Manager, you can now deactivate the Booking Friendly Reference feature. Deactivating this feature will improve performance when new bookings are created, as this feature requires that a profile instance is read and updated for each booking that is created.

## Fixes

#### Problem with SRM_DiscoverResources script [ID_38769]

When a resource had at least one capacity and it had two properties of which the name was the same except for spaces (e.g. *Connected Input* and *ConnectedInput*), the *SRM_DiscoverResources* script could throw the following exception:

`System.Data.OleDb.OleDbException (0x80040E07): Data type mismatch in criteria expression.`

#### Exception when exporting SRM configuration including script with reference to DLL with long path [ID_38930]

When one of the scripts included in an SRM setup had a reference to a DLL with a very long path, a System.IO.PathTooLong exception could be thrown when an SRM configuration was exported.
