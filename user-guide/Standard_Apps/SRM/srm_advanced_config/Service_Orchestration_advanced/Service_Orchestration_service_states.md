---
uid: Service_Orchestration_service_states
---

# Service Orchestration: service states configuration

The DataMiner service associated with a booking can have different service states: Start, Stop, Standby, or Pause.

Whenever a booking enters a different booking life cycle state, the SRM framework will adjust the service state accordingly.

The booking life cycle state changes during the following events:

- Start of pre-roll
- End of pre-roll
- Start of post-roll
- End of post-roll

Each of these events will trigger a booking action, which will launch an LSO script that configures the resources used in the booking.

## Customizing which service state corresponds with which booking stage

When the booking life cycle state changes, the corresponding service gets a specific service state. You can customize which service state is applied for a specific event:

1. In the Booking Manager app, go to *Config* > *Services and SLA*.

1. Select the services state that should be triggered by the different booking events: *Initial Service State*, *Service State (preroll)*, *Service State (service active)*, *Service State (postroll)*, and *Service State (ended)*.

## Customizing the allowed transitions between service states

You can customize which transitions between specific service states are allowed:

1. In the Booking Manager app, go to *Config* > *Services and SLA*.

1. In the *Service State Transitions* table, customize the rows to indicate which transitions are allowed:

   - Click the pencil icon in a cell of an existing row to select a different value.

   - To remove an allowed transition, right-click the row and select *Delete State(s)*.

   - To add an allowed transition, right-click the table and select *Add State*, and then select the supported state and next allowed state.

   - To undo your customization, right-click the table and select *Reset to default state values*.

   For example, if you add a row with *PAUSE* in the *Supported State* column and *START* in the *Next Allowed State* column, this transition will be allowed.

> [!IMPORTANT]
> Any transition that is not mentioned in the table will not be allowed.

## Configuring the action linked to each service state

For each service state that a service definition must support, an action must be configured and linked to an LSO script defining the resources that must be configured for that service state:

1. In the Services module, go to the *definitions* tab.

1. Select the service definition for which you want to configure the actions.

1. Select the *actions* tab.

1. Add entries to the table as necessary. For detailed information, see [Actions tab](xref:SRM_Services_definitions#actions-tab).

> [!TIP]
> See also: [Creating LSO scripts](xref:Service_Orch_creating_LSO_scripts)

## Configuring a custom script in case orchestration fails

If the orchestration cannot be triggered for some reason, the booking life cycle state will become *Failed*.<!-- RN 28912 -->

Optionally, you can configure a custom script that will be triggered in such a case. This script can perform custom actions such as sending a report.<!-- RN 26018 -->

1. Create a custom script based on the example script included in the framework (*SRM_BookingStartFailureTemplate*).

1. In the Booking Manager app, go to *Config* > *General*.

1. Next to *Booking Start Failure Script*, select the custom script.
