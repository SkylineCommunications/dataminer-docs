---
uid: srm_service_orchestration
---

# Service Orchestration

Service Orchestration involves the complete scheduled orchestration of a service, including management of resources and advanced service orchestration rules.

For each type of service that needs to be on air, dedicated development is required to define the type of resources that will be part of the booking, to define how these will be interconnected, and to fully customize the configuration steps based on the target service state.

Service orchestration can be combined with Resource Scheduling in case extra resources, which were not initially part of the booking, need to be booked to accommodate last-minute changes.

Service Orchestration is the SRM flavor requiring the biggest implementation efforts. This is typically used to support very repetitive and deterministic use cases. Everything is prepared in advance to make the life of the user as easy as possible. However, this requires that each and every action that the user can potentially trigger on each type of service is defined and implemented (e.g. switching to a backup device, inserting a video processing unit, etc.).

Examples:

- Satellite reception.
- Transferring a stream over an IP network.
