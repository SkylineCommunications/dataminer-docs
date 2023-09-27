---
uid: srm_resource_orchestration
---
# Resource Orchestration

With Resource Orchestration, users can book resources ahead of an event and also define the settings that will be applied to the resources when the booking starts. This combines Resource Automation and Resource Scheduling.

When a booking starts, SRM will go over all resources and configure them one by one, without any predefined sequence. Depending on the workflow, it is possible that users may need to tweak some resources.

As with Resource Scheduling, a DataMiner service will be used to aggregate the alarm state of all resources and to provide a single interface to access them.

Resource orchestration can be combined with Resource Scheduling, in case extra resources, which were not initially part of the booking, need to be booked to deliver a service.

Resource Orchestration is typically used to support non-deterministic use cases. It can also be used to support rare use cases where the cost of full Service Orchestration cannot be justified because the use case does not occur often enough.

Examples:

- DataMiner Automation based on bookings defined in an external scheduling system.
- Initial configuration of devices associated with an event.
