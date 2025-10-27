---
uid: srm_stages_of_bookings
---

# Booking stages

Once a booking has been created and is in the confirmed state, it goes through several stages in the Resource Manager until it is finished. Having a clear understanding of these steps can help in troubleshooting bookings and understanding the impact of certain configuration settings. Note that a distinction must be made between the booking stages in the core software and the [booking lifecycle](xref:Service_Orchestration_life_cycle_states) when the SRM framework has been deployed.

## Booking states

A booking has a state associated with it, which tracks its progress through the different stages of the booking process.

Once the booking is in the *Confirmed* state, the Resource Manager will execute the [booking stages](#stages-overview). Some of these will transition the booking to a different state.

You can find an overview of the possible states in the core software in the table below:

| State | Description |
|--|--|
| Pending | Bookings in this state will reserve the assigned resources, but will not execute any scripts or actions. |
| Confirmed | Bookings in this state will reserve their resources, and orchestration will be executed at the configured times. |
| Ongoing | The Resource Manager will move bookings from the *Confirmed* state to the *Ongoing* state after running the start actions. It is not possible to assign this state manually. |
| Ended | The Resource Manager will move bookings from the *Ongoing* state to the *Ended* state after running the end actions. Like the *Ongoing* state, this state cannot be assigned manually. |
| Interrupted | If a booking misses its start, stop, or any orchestration event because the hosting Agent is down, the Resource Manager will move the booking to this state. |
| Canceled | Resources assigned to a booking are freed up, and orchestration will not be executed. A booking must be manually updated to this state (it will not be automatically assigned). |

## Stages overview

In the core software, a booking goes through the following changes, in the indicated order:

- [Booking creation](#booking-creation)
- [Registration of events and actions](#registration-of-events-and-actions)
- [Activation of function resources](#activation-of-function-resources)
- [Running of booking pre-events](#running-of-booking-pre-events)
- [Booking start](#booking-start)
- [Running of booking events](#running-of-booking-events)
- [Booking end](#booking-end)

For what happens when a booking is updated after the start actions have run, see [Updating bookings that are already running](#updating-bookings-that-are-already-running).

### Booking creation

When a booking is created, a value is assigned to the `HostingAgentID` property, which indicates the Agent responsible for orchestrating the booking. If the SRM framework has been deployed, the hosting Agent is randomly selected from the list of Agents configured in the corresponding settings. The selected hosting Agent must be online at the time of the booking creation. For more information on the configuration of Agents, see [Default booking configurations settings](xref:Booking_Manager_Config_tab#default-booking-configurations-settings).

In order to update the hosting Agent of a booking after it has been created, the booking must be [swarmed](xref:SwarmingBookings) to a different Agent. A booking can be swarmed while the currently configured hosting Agent is offline, but any other update to a booking requires its hosting Agent to be online.

> [!IMPORTANT]
> If the hosting Agent is offline when any orchestration must happen, such as the start actions, stop actions, or the triggering of a booking event, the orchestration will not happen. The hosting Agent will move the booking to the *Interrupted* state when it comes back online, and any remaining events will not be run.

### Registration of events and actions

Once a booking has been created, the hosting Agent registers all the events and actions that need to occur for the booking. If the hosting Agent is restarted after the booking is created:

- The Agent will read all bookings it needs to orchestrate for the next 24 hours from the database.
- Bookings that have missed an event or action will be put in the interrupted state.
- Every 6 hours, the next bookings for orchestration are registered.

### Activation of function resources

If the booking contains function resources, the Resource Manager on the hosting Agent attempts to activate these resources a set period of time before the booking start time. The default time for this is 10 minutes, but this can be customized in the [function resource settings](xref:Function_resource_settings#function-resource-settings).

The hosting Agent by default waits for one minute for the activation of the resources. This timeout can be customized in the function resource settings. If the function DVEs are not active within the timeout period, DataMiner will still attempt to start the booking at the configured start time, but this may fail if the DVEs are not active yet.

> [!NOTE]
> If the time difference between the booking start time and the current time is shorter than the activation period, the activation will be triggered immediately when the booking is created.

### Running of booking pre-events

If there are any events configured with a start time before the booking start time, these events will run before the booking is started.

If the SRM framework has been deployed, there are no such events unless an event is configured in the [custom events tab](xref:Service_Orchestration_custom_events) that needs to run before the booking start.

> [!NOTE]
> If the pre-event is configured at a time before the function resource activation, the pre-event will run before the function resources are active.

### Booking start

After the functions have either been successfully activated or the activation has timed out, the hosting Agent attempts to start the booking.

If the function resources have not been activated yet, the start of the booking will fail. In such cases, the Resource Manager keeps the booking in the *Confirmed* state and triggers the script configured to run when the booking start fails (if any). For details on how to configure this script when you use the SRM framework, see [Configuring a custom script in case orchestration fails](xref:Service_Orchestration_service_states#configuring-a-custom-script-in-case-orchestration-fails). When the SRM framework is used, the booking lifecycle will also transition to the failed state.

The start of a booking can also fail if:

- A required service already exists with the same name.
- The creation of the DCF links fails. The function manager creates DCF links between resources based on the DCF information in the parent element and the service definition associated with the booking. This behavior can be disabled in the [function resource settings](xref:Function_resource_settings#function-resource-settings).
- An unexpected exception occurs during the start, for example if saving the booking with the ongoing status fails because there is no connection to the database.

### Running of booking events

Once the booking transitions to the *Ongoing* state, the hosting Agent will trigger event scripts at the specified timings. If the timing of multiple events is in the past by the time the booking becomes ongoing, the event scripts will run in the order of their configured time.

By default, these event scripts run asynchronously, which means that the hosting Agent will trigger them without waiting for completion.
This asynchronous behavior means multiple scripts will run concurrently. After a script is triggered, the `HasRun` property of the event in the `ReservationInstance` object is set to `true`, indicating that the event has been triggered and will not be triggered again.

When the SRM framework is used, some events are added by default to transition the booking lifecycle state. Any configured [custom events](xref:Service_Orchestration_custom_events) will also be event scripts on the booking.

### Booking end

When the booking reaches its configured end time, the hosting Agent will stop the booking. During this process:

- The DCF links are removed, if DCF link creation is enabled in the [function resource settings](xref:Function_resource_settings#function-resource-settings).
- Function DVEs may be disabled depending on the threshold set in the [function resource settings](xref:Function_resource_settings#function-resource-settings), and if these DVEs are not in use by a different booking.

The hosting Agent will then update the status of the `ReservationInstance` object to `Ended`.

## Updating bookings that are already running

If a booking is updated after the start actions have already been run, the booking may go back to the confirmed state and start again. Such a booking restart occurs if any of the following conditions is true:

- The timing of the booking is adjusted.
- There are new resources in the booking.
- There is an enhanced service protocol linked to the booking, and that protocol has changed.

If the booking restarts, any events that have already run will not be run again.
