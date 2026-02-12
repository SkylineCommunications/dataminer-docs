---
uid: MaintenanceSettings.WatchDog.TimeoutTime
---

# TimeoutTime element

Specifies the timeout time in minutes. By default this value is 5. Threads will be tracked by WatchDog using 1.5 times this value (for example, if you use the default value of 5, threads using this default value will have a timeout of 7 minutes and 30 seconds).

The minimum value is 1, the maximum value is 959 (15 hours and 59 minutes).

This timeout time specifies the time it takes until a HALFOPEN RTE is reported. The value of (xref:MaintenanceSettings.WatchDog.Errors) then specifies how many additional times we wait on this timeout time until we escalate the HALFOPEN RTE to an OPEN RTE (for example, the default value is 2, meaning that if a HALFOPEN RTE is reported after 7 minutes and 30 seconds, an OPEN RTE is reported after 15 minutes).

## Content Type

nonNegativeInteger

## Parents

[WatchDog](xref:MaintenanceSettings.WatchDog)
