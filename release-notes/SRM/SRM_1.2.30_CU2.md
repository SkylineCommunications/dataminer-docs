---
uid: SRM_1.2.30_CU2
---

# SRM 1.2.30 CU2

> [!NOTE]
> This version requires that **DataMiner 10.3.2 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## Fixes

#### Booking configured with milliseconds could not be finished [ID_35846]

If a booking was created with an SRM version prior to 1.2.30 and it contained a configuration in milliseconds, it could occur that the booking could not be finished.

#### Not possible to create booking with multiple transport nodes connecting element to itself [ID_35900]

If a booking had multiple transport nodes connecting the element to itself, it could occur that this booking could not be created because the path was considered to already be in use by another function.
