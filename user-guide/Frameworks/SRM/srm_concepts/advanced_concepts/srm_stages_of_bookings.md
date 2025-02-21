---
uid: srm_stages_of_bookings
---

# Booking stages

A booking goes through several stages in the Resource Manager between its creation and the end of the booking. Having a clear understanding of these steps can help in troubleshooting bookings and understanding the impact of certain configuration settings. Note that a distinction must be made between the booking stages in the core software, and the [booking lifecycle](xref:Service_Orchestration_life_cycle_states) when using the SRM solution. The stages outlined below are the stages in the core software.

## 1. Booking creation

When a booking is created, a value is assigned to the `HostingAgentID` property, which indicates the agent responsible for orchestrating the booking. When using the SRM solution, the hosting agent is randomly selected from the list of agents configured in the corresponding settings. For more information on the configuration of agents, refer to the [default booking configurations settings](xref:Booking_Manager_Config_tab#default-booking-configurations-settings) page. The selected hosting agent must be online at the time of the booking creation.

In order to update the hosting agent of a booking after creation, the booking must be [swarmed](xref:SwarmingBookings) to a different agent. A booking can be swarmed while the currently configured hosting agent is offline, but any other update to a booking requires its hosting agent to be online.

> [!WARNING]
> If the hosting agent is offline when any orchestration must happen, such as the start actions, stop actions or the triggering of a booking event, the orchestration will not happen.
> The booking will be moved to the `Interrupted` state by the hosting agent when it comes back online, and any remaining events will not be run.

## 2. Registering events and actions

Once the booking is created, the hosting agent registers all the events and actions that need to occur for the booking. If the hosting agent is restarted after the booking is created, it will:

- Read all bookings it needs to orchestrate for the next 24 hours from the database.
- Bookings that have missed an event or action will be put in the interrupted state.
- Every 6 hours the next bookings for orchestration are registered.

## 3. Activating function resources

If the booking contains function resources, the Resource Manager on the hosting agent attempts to activate these resources a set period of time before the booking start time. The default time for this is 10 minutes, but this is configurable in the [function resource settings](xref:Function_resource_settings#function-resource-settings). The hosting agent by default waits for one minute for the activation of the resources, this timeout is also configurable in the function resource settings. If the function DVEs are not active within the timeout period, the start of the booking will still be attempted at the configured start time, but may fail if the DVEs are not active yet.

**Note:** the activation will be triggered immediately when the booking is created, if the time difference between the booking start time and the current time is shorter than the activation period.

## 4. Running booking pre-events

If there are any events configured with a start time before the booking start time, these events will run before the booking is started. When using the SRM solution, there are no such events, unless an event is configured in the [custom events tab](xref:Service_Orchestration_custom_events) that needs to run before the booking start.

**Note:** if the pre-event is configured at a time that is before the function resource activation, the pre-event will run before the function resources are active.

## 5. Starting the booking

After the functions have either been successfully activated or the activation has timed out, the hosting agent attempts to start the booking. If the function resources are not yet activated, the start of the booking will fail.

In such cases, the Resource Manager keeps the booking in the `Confirmed` status and triggers the script configured to run when the booking start fails (if any). See also [this page](xref:Service_Orchestration_service_states#configuring-a-custom-script-in-case-orchestration-fails) for details on how to configure this script if the SRM solution is used. When using the SRM solution, the booking lifecycle will also transition to the failed state.

The start of a booking can fail if:

- A required service already exists with the same name.
- The creation of the DCF links fails. The function manager creates DCF links between resources based on the DCF information in the parent element and the service definition associated with the booking. This behavior can be disabled in the [function resource settings](xref:Function_resource_settings#function-resource-settings).
- An unexpected exception occurs during the start. For example if saving the booking with the ongoing status fails because there is no connection to the database.

## 6. Running the booking events

Once the booking transitions to the `Ongoing` state, the hosting agent will trigger event scripts at the specified timings. If the timing of multiple events is in the past by the time the booking becomes ongoing, the event scripts will run in the order of their configured time. By default, these event scripts run asynchronously, meaning the hosting agent will trigger them without waiting for completion.
This asynchronous behavior means multiple scripts will run concurrently. After triggering the script, the `HasRun` property of the event in the `ReservationInstance` object is set to `true`, indicating the event has been triggered and will not be triggered again.

When using the SRM solution, some events are added by default to transition the booking lifecycle state. Any configured [custom events](xref:Service_Orchestration_custom_events) will also be event scripts on the booking.

## 7. Ending the booking

When the booking reaches its configured end time, the hosting agent will stop the booking. During this process:

- The DCF links are removed, if DCF link creation is enabled in the [function resource settings](xref:Function_resource_settings#function-resource-settings).
- Function DVEs may be disabled depending on the threshold set in the [function resource settings](xref:Function_resource_settings#function-resource-settings), if these DVEs are not in use by a different booking.
  
The hosting agent will then update the status of the `ReservationInstance` object to `Ended`.

## Updating already running bookings

If a booking is updated after the start actions have already been run, the booking may go back to the confirmed state and start again. Such a booking restart occurs if any of the following conditions are true:

- The timing of the booking is adjusted.
- There are new resources in the booking.
- There is an enhanced service protocol linked to the booking, and that protocol has changed.

If the booking restarts, any events that have already run will not be run again.
