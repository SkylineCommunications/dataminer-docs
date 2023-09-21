---
uid: SRM_1.2.30_CU3
---

# SRM 1.2.30 CU3

> [!NOTE]
> This version requires that **DataMiner 10.3.2 or higher** is installed. It is not compatible with the DataMiner Main Release track.

## Enhancements

#### New BookingManager.ApplyServiceState overload methods that throw LSO script exception [ID_35929]

The following *BookingManager.ApplyServiceState* overload methods have been added, which will throw the exception thrown by the LSO script:

- public void ApplyServiceState(Engine engine, ServiceReservationInstance reservation, string state, bool isSynchronous, bool throwOnLsoFailure)
- public void ApplyServiceState(Engine engine, ServiceReservationInstance reservation, string[] states, bool isSynchronous, bool throwOnLsoFailure)

If *throwOnLsoFailure* is set to *true*, and the LSO script fails, the two methods above will throw an *SrmConfigurationException*, and *InnerException* will contain hold the exception that was thrown by the LSO script.

For this to work, the LSO script needs to run the method `AutomationScript.HandleException(engine, e);`; otherwise, a standard exception will be present in *InnerException*.

## Fixes

#### Auto Select Resource property not taken into account during silent booking creation [ID_35998]

When a booking was created silently, it could occur that the *Auto Select Resource* node property was not taken into account, so that resources were automatically selected even if this property was set to False.

Now this property will always be taken into account if no function object is passed to the silent booking for a node in the service definition. Otherwise, the value passed with *Function.ShouldAutoSelectResource* determines the behavior.
