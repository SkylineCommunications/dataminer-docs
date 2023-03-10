---
uid: KI_SRM_booking_events_issue
---

# Problem with booking automation and function DVE deactivation

## Affected versions

SRM setups using a DataMiner version prior to 10.3.0/10.3.2.

## Cause

From DataMiner 10.3.0/10.3.2 onwards ([RN 34856](xref:General_Feature_Release_10.3.2#breaking-change-capacity-property-will-no-longer-be-initialized-on-new-resources-id_34856)), the *Capacity* property is no longer initialized on new resources. However, if you use a 10.3.0/10.3.2 Cube version while the server uses an older DataMiner version, this can cause deactivating function DVEs to happen with large delays. This in turn can cause delays to booking automation in general (i.e. event scripts and starting/stopping of bookings).

## Fix

Upgrade to DataMiner 10.3.0/10.3.2 or higher.

## Workaround

The following workarounds are possible:

- Create new resources with a script that does not set the *Capacity* property to null. Adjust any resources with a null *Capacity* property by assigning the capacity in a script.
- Increase the ActiveFunctionResourceThreshold setting so the deactivation of function DVEs is not triggered. You can change this setting without a DMA restart. (See [Advanced SRM settings](xref:Advanced_SRM_settings).)
- Force DataMiner Cube to use the same version as the server. (See [Selecting your Cube update track](xref:Managing_the_start_window#selecting-your-cube-update-track).)

## Issue description

When a DataMiner Cube version of 10.3.0/10.3.2 or higher is used with an older server version, SRM event scripts and starting and stopping of bookings can take a long time. Also, function DVEs that should have been deactivated appear to remain active.
