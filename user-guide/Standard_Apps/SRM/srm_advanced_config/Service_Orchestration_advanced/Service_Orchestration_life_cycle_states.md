---
uid: Service_Orchestration_life_cycle_states
---

# Service Orchestration: booking life cycle states configuration

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

- **Failed Service Pre-Roll**: Orchestration at the beginning of the pre-roll phase has failed.

- **Failed Service Active**: Orchestration at the end of the pre-roll phase has failed.

- **Failed Service Post-Roll**: Orchestration at the beginning of the post-roll phase has failed.

- **Failed Completed**: Orchestration at the end of the post-roll phase has failed.

## Configuring a custom Created Booking Action

On a node in a service definition, you can configure that a script should run before the corresponding booking is set to the "Confirmed" state<!-- RN 19447 -->:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition and the node for which you want to run the script.

1. In the *properties* pane in the lower right corner, add the *Created Booking Action* property, and specify a value in the following format (similar to the format used to link a shape to an Automation script in Visio):

   ```json
   {
   "Script": "Script:<Script name>||<Parameter name 1>=<Parameter value 1>;
   <Parameter name 2>=<Parameter value 2>;..."
   }
   ```

   In this value, the placeholder `[RESERVATIONID]` can be used, which will be replaced by the booking ID of the created booking when the script is started.

> [!NOTE]
>
> - In case the script fails, the booking will be set to the *Partial* booking life cycle state. <!-- RN 28875 -->
> - To report a custom message to the main booking wizard and inform the user when the custom script fails, the script must exit with the following call (the exception containing the custom message): `AutomationScript.HandleException(Engine, Exception);` <!-- RN 26616 -->

> [!TIP]
> See also: [Created Booking Action](xref:SRM_properties_Booking_Manager#created-booking-action)

## Defining custom state colors

You can assign a custom color to each of the booking life cycle states.

1. In the Booking Manager app, go to *Config* > *Lifecycle colors*.

1. Next to the life cycle state for which you want to define a custom color, click the pencil icon, select the custom color, and click the green checkmark icon.

> [!TIP]
> See also: [Lifecycle colors subtab](xref:Booking_Manager_Config_tab#lifecycle-colors-subtab)
