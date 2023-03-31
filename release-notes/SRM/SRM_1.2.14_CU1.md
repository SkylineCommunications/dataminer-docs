---
uid: SRM_1.2.14_CU1
---

# SRM 1.2.14 CU1

## Enhancements

#### Skyline Booking Monitoring updates now in the background \[ID_30171\]

Updates for the *Skyline Booking Monitoring* connector are now sent in the background so that they do not affect other SRM operations.

## Fixes

#### Problem assigning resources when capability/capacity value is not supported \[ID_30143\]

When a capability or capacity parameter was set to a value that was not supported for the current resource of a booking, it could occur that the script to assign a correct resource failed.

#### Fast booking creation failed if profile instances only had capacities/capabilities set \[ID_30153\]

If a booking used profile instances that only had capacities or capabilities set but no values, it could occur that fast creation of the booking failed.
