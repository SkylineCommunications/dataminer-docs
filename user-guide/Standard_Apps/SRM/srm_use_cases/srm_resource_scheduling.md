---
uid: srm_resource_scheduling
---

# Resource Scheduling

With Resource Scheduling, users can book resources ahead of an event, so that the service will not be interrupted by a resource shortage. This provides maximum flexibility, as any resources can be added into such a booking.

When a booking starts, a DataMiner service is dynamically generated to aggregate the alarm state of all the resources that are part of the booking. This service also provides a single interface to access all resources in the booking.

No automation happens when the service is generated. The users will need to manually trigger the configuration of the resources in booking. They can do so either by navigating to the relevant resource from the service card or by triggering a Resource Automation action from the same service card.

Triggering the configuration is typically done during the pre-roll phase before the booking starts. During pre-roll, all resources are already reserved for the booking. Similarly, resetting all resources is typically done during the post-roll phase.

Resource Scheduling can be used to support very exotic workflows where it is not worth investing into full service orchestration.

Examples:

- Booking staff
- Booking rooms
- Booking IP addresses
