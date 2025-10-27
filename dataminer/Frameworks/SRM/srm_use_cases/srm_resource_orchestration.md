---
uid: srm_resource_orchestration
---
# Resource Orchestration

*Automate basic configuration actions as part of resource schedules.*

Resource Orchestration **combines the intelligence of Resource Scheduling with the power of Resource Automation**. This way, you can book resources ahead of an event and also define the settings that will be applied to the resources when the booking starts. This means that when resources are scheduled, an operator is no longer needed to configure them one by one. Similarly, DataMiner will put all resources in a well-known default state at the end of the schedule. This results in **reliable and predictable operations**, while at the same time offering the flexibility to allow operators to update configurations whenever needed.

When a booking starts, SRM will go over all resources and configure them one by one, without any predefined sequence. As with Resource Scheduling, a DataMiner service will be used to aggregate the alarm state of all resources and to provide a single interface to access them. Scheduling can be used in case extra resources that were not initially part of the booking need to be booked to deliver a service.

The term "DataMiner orchestration" is used when automation is combined with Resource Scheduling. While the DataMiner SRM stack is deployed on any DataMiner node by default at no additional cost, using Resource Orchestration requires [SRM licenses](xref:Pricing_Perpetual_Use_Licensing#special-purpose-licenses).

Resource Orchestration is typically used to support non-deterministic use cases. It can also be used to support rare use cases where the cost of full Service Orchestration cannot be justified because the use case does not occur often enough.

Some examples:

- Tuning antennas and IRDs for OU events.
- Setting up full production studio and playout environments for specific productions.
- DataMiner Automation based on bookings defined in an external scheduling system.
- Initial configuration of devices associated with an event.

> [!TIP]
> See also: [Learn to orchestrate an entire resource](https://www.youtube.com/watch?v=Lg75E8hrwxs) ![Video](~/dataminer/images/video_Duo.png)
