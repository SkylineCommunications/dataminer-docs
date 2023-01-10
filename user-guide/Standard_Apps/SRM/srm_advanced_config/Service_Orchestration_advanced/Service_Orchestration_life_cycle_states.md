---
uid: Service_Orchestration_life_cycle_states
---

# Service Orchestration booking life cycle states configuration

A booking is always associated with a specific booking life cycle state. The following states are supported:

- **Partial**: This is the initial state when a booking is created. Resources that are part of the booking have been booked, but no orchestration will happen.

- **Confirmed**: The booking gets this state when it has all mandatory resources assigned and is scheduled to be orchestrated.

- **Pre-roll**: The booking gets this state during the pre-roll phase. When it transitions to this state, the orchestration layer will typically apply the configuration on the resources.

- **Service Active**: The booking gets this state during on-air time. When it transitions to this state, the orchestration layer will typically apply the last settings required to get the signal on air (e.g. enable the modulator).

- **Post-roll**: The booking gets this state during the post-roll phase. When it transitions to this state, the orchestration layer will typically start resetting resources to their default values.

- **Completed**: The booking gets this state as soon as post-roll is completed. No further transition is then possible.

- **Canceled**: If a booking is not running yet, it can be forced to transition to this state. In that case, it will never be executed, and its resources will be released. No further transition is possible.

- **Failed**: When DataMiner is unable to initiate the orchestration, a booking will get this state. No further transition is possible.

- **On-Hold**: If a booking is not running yet, it can be forced to transition to this state. In that case, it will not be executed, but its resources will continue to be reserved.

- **Quarantined**: When there is a resource conflict between multiple bookings, some of these bookings will get this state. This means the orchestration will not take place. Users can then edit the booking and adjust settings (e.g. select a different profile instance or resource) to make the booking leave this state.

  You can trigger quarantined state by:

  - Deleting a resource.
  - Extending another booking that makes use of the same resource as another booking and making it overlap with that other booking.
  - Adjusting required capabilities/capacities in the profile instance in such a way that the resource can no longer meet requirements.
  - Adjusting capabilities/capacities on the resource.

## Configuring a custom Created Booking Action

## Defining custom state colors
