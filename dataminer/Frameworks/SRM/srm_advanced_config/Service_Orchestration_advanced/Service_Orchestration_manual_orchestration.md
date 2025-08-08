---
uid: Service_Orchestration_manual_orchestration
---

# Service Orchestration: Manual orchestration

<!-- RN 28764 and 29002 -->

In some situations, it may be necessary to force a service to transition to a particular state (STOP, START, etc.) and to apply relevant profiles for that service state. You can achieve this by implementing a custom script.

Two use cases can be defined:

- The target state is one of the states defined in the Booking Manager app (e.g. Start, Stop, Standby, etc.).

- The target state is not defined in the Booking Manager app (e.g. move to backup).

Here are the steps to support such a use case:

1. [Add relevant "Action" items to the service definition](xref:Service_Orchestration_service_states#configuring-the-action-linked-to-each-service-state) and associate them with an LSO script..

1. Create [state profile instances](xref:srm_instantiations#state-profile-instance) associated with the target service state.

1. In the LSO script, [capture the incoming target service state and trigger the execution of the relevant Profile-Load Scripts](xref:Service_Orchestration_LSO_script).

1. In a custom script, use the following method from the *BookingManager* class:

   ```csharp
   public void ApplyServiceState (Engine engine, ServiceReservationInstance reservation, string state);`
   ```

> [!NOTE]
>
> - In case the target state is defined in the Booking Manager app, the service state will be updated to the target state after successful completion of the LSO script. In the opposite scenario, the final state will be set to initial state.
> - For a contributing booking, forced transitioning to a target service state is supported regardless of the orchestration trigger (main or local).
