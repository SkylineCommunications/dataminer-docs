---
uid: srm_resource_scheduling
---

# Resource Scheduling

*Assure your service delivery by avoiding resource conflicts at all times.*

With Resource Scheduling, which is available **out of the box**, you can **book resources ahead of an event**, so that you can **avoid resource conflicts** at all times, ensuring that a service will not be interrupted because of a resource shortage. Any resources can be added into such a booking, for maximum flexibility.

Resource Scheduling keeps track of all **resource availability** and **booking schedules**. When a booking starts, a DataMiner service is dynamically generated to aggregate the alarm state of all the resources that are part of the booking. This service also provides a single interface to access all resources in the booking.

**No automatic configuration of resources** will be executed at the start or end of the schedule. At any time, operators can go to their selected resources in DataMiner and configure them manually for the job at hand. They can do so either by navigating to the relevant resource from the service card or by triggering a Resource Automation action from that same service card.

Triggering the configuration is typically done during the pre-roll phase before the booking starts. During pre-roll, all resources are already reserved for the booking. Similarly, resetting all resources is typically done during the post-roll phase.

**Workflows that are rare or highly changeable** and workflows that require maximum flexibility benefit the most from Resource Scheduling. Some examples:

- Reserving ad hoc cameras and CCUs for events.
- IRD or IP gateway reservations in downlink and exchange networks to handle breaking news or late-notice OU sessions.
- Emergency broadcast transmissions that may not be interrupted at any time.
- Allocation of spare resources in case booked resources fail.
- Planning of resource utilization for resources that do not require any configuration, such as rooms, editing desks, IP addresses, or even staff.

> [!TIP]
> See also: [Schedule your resources and avoid resource conflicts](https://www.youtube.com/watch?v=BNK0RhlxwEc) ![Video](~/dataminer/images/video_Duo.png)
