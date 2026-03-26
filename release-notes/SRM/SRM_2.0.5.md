---
uid: SRM_2.0.5
---

# SRM 2.0.5

> [!NOTE]
> This version requires that **DataMiner 10.6.1.0-16647 or higher** is installed. The DataMiner Main Release track is not supported.

## Enhancements

#### Patch API now used to update booking properties [ID 44086]

Updating properties on a booking via the SRM solution will now use the patch API (introduced in [DataMiner 10.6.1](xref:General_Feature_Release_10.6.1#service--resource-management-new-patchreservationinstanceproperties-method-to-update-properties-of-a-reservation-instance-id-44084)) in the background. This improves performance of property updates, as the booking no longer needs to be fetched before and after the property update.

#### Logging added when custom event is discarded [ID 44115]

When a custom event cannot be added to a booking and is discarded, for example because the timing is in the past, this will now be mentioned in the logging.

## Fixes

#### Booking Wizard allowed booking names with forbidden characters [ID 44625]

In the Booking Wizard, booking names could be specified that contained characters forbidden according to the [naming rules for DataMiner Cube](xref:Forbidden_characters). The validation of booking names has now been updated to prevent this.

#### Element could not be linked to Profile-Load Script [ID 44902]

When a booking was created with a start date in the past, which should make it start immediately, but the DVE element was disabled and hosted by a different Agent than the booking triggering the Lifecycle Service Orchestration and Profile-Load Script (PLS), it could happen that when the PLS was called, SLAutomation was not yet aware of that element's existence, so that the element could not be linked to the script.

To handle this scenario, the PLS will now be retried several times, as the information about the element should eventually reach SLAutomation.
