---
uid: SRM_1.2.31_CU1
---

# SRM 1.2.31 CU1

> [!NOTE]
> This version requires that **DataMiner 10.3.2.0 – 12627 or higher** is installed. The DataMiner Main Release track is not supported.

## Enhancements

#### Support added for updated service creation behavior [ID_39162]

In DataMiner [10.4.5](xref:General_Feature_Release_10.4.5#not-possible-to-delete-a-service-created-via-an-srm-booking-when-it-had-been-assigned-a-name-that-was-already-being-used-id_38914) (as well as 10.3.0 [CU14] and 10.4.0 [CU2]), to prevent an issue when a service was created via an SRM booking and it had an error because the name was already in use by another object, new behavior was introduced when an SRM service is created with a name that already exists. Previously, when an existing name was passed with a different ID, the existing service name was returned, while now an error is thrown. The SRM framework has now been adapted to support this new behavior, while also remaining compatible with the previous behavior.

#### Service creation timeout in BookingBuilder.cs now depends on Retry Timeout setting [ID_39481]

In the *BookingBuilder.cs* from the SRM framework, the service creation timeout is now no longer fixed to a value of 30 seconds, but instead the *Retry Timeout* setting from the Booking Manager is applied.
