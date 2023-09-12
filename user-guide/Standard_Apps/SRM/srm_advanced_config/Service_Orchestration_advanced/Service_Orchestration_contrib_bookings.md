---
uid: Service_Orchestration_contrib_bookings
---

# Service Orchestration: contributing bookings configuration

Before you start [creating contributing bookings](#configuring-contributing-bookings), it is important that you understand which [types of contributing bookings](#types-of-contributing-bookings) there are and [how they behave](#contributing-booking-behavior).

> [!TIP]
> See also: [Contributing booking](xref:srm_instantiations#contributing-booking)

## Types of contributing bookings

### Locked or unlocked

A contributing booking can be locked or unlocked. When it is **locked**, the booking life cycle of the contributing booking is tied to the booking life cycle of the main booking. When it is **unlocked**, the main and contributing booking are more independent.

The timing for a contributing resource is fully managed by the SRM framework and is different depending on the type of contributing booking:

- **Unlocked**: The timing of the main and contributing booking must have an overlap of at least 1 second.

- **Locked**: The timing of the main booking needs to be fully included in the timing of the contributing booking

  > [!NOTE]
  > When a contributing resource is added to a main booking that is already running, the constraint on the time window is not applicable for the elapsed duration. <!-- RN 27107 -->

### Main or local

If a contributing booking has the orchestration trigger "**Local**", it can orchestrate itself. If it has the orchestration trigger "**Main**", it can be triggered by the main booking making use of it.

Regardless of whether the orchestration trigger is "Main" or "Local", the update of the booking life cycle state will always be determined by local events.<!-- RN 24856 -->

## Contributing booking behavior

By default, a service is created at booking time for a contributing booking, along with an enhanced element to expose the contributing resource. This is fully handled in the background by the SRM framework. The service created for a contributing booking will have the *SRM_ServiceType* property set to "Contributing" (for regular services created for bookings, this property has the value "Standard"). It will be located in a subview of the view containing the main service. The subview has the same name as that parent view, but with the *-Contributing* suffix.

Similar to regular bookings, contributing bookings can be **edited**. Relevant objects such as the contributing resource and service will be edited automatically in the background.<!-- RN 27502 -->

Like a main booking, a contributing booking can have different [life cycle states](xref:Service_Orchestration_life_cycle_states). These can be adjusted based on changes applied to the main booking, and likewise, changes applied to a contributing booking can cause a life cycle state adjustment of the main booking making use of it:

- When a booking is converted to a contributing booking (with the *Convert to Contributing* checkbox in the Booking Wizard), the SRM framework will set the booking to the **Partial** state. It is then up to the user or the front-end script to confirm the booking.<!-- RN 27573 -->

- When the **main booking is confirmed**:<!-- RN 25547 -->

  - Locked contributing bookings that have not yet started will also be confirmed.

  - Unlocked contributing bookings will remain unchanged.

- When the **main booking is set on hold**:<!-- RN 25547 -->

  - Locked contributing bookings that have not yet started will also be set on hold if no other bookings in confirmed, partial, or quarantined state are using them.

  - Unlocked contributing bookings will remain unchanged.

- When the **main booking is canceled**:<!-- RN 25547 -->

  - Locked contributing bookings that have not yet started will also be canceled if no other bookings in confirmed, partial, on-hold, or quarantined state are using them.

  - Unlocked contributing bookings will remain unchanged.

- When the **main booking is deleted**:<!-- RN 25547 -->

  - Locked contributing bookings will also be deleted if they are canceled and no other non-canceled bookings are still using them.

  - Unlocked contributing bookings will remain unchanged.

- When the **main booking is finished**:

  - The end time of the included locked contributing bookings will be adjusted in such a way that the smallest delta time between a contributing booking and all main bookings making use of it will be kept.<!-- RN 28815 -->

  - The end time of the included unlocked contributing bookings will not change. In case unlocked contributing bookings have a start time that is higher than the new end time of the main booking, the associated resources will be removed from the main booking.<!-- RN 25730 -->

- When the **timing of the main booking is updated**:

  - The included locked contributing bookings will be adjusted in the background in such a way that the smallest delta time between a contributing booking and all main bookings making use of it will be kept.<!-- RN 28772 --> In case the timing of a locked contributing booking needs to be adjusted in such a way that it causes a conflict with another booking, the SRM framework will not warn the user and will immediately move the relevant booking to the quarantine.<!-- RN 25599 -->

  - In case the timing of the unlocked contributing booking is no longer compatible with the main booking:<!-- RN 25599 -->

    - If the main booking is already running, the timing update will be blocked.

    - If the main booking has not started yet, the timing will be updated, the contributing resource will be removed from the main booking, and the main booking will be set to the “Partial” state.

- If the **main booking leaves the quarantined state**, the SRM framework will also try to make any included contributing bookings leave the quarantined state, regardless of whether they are locked or unlocked.<!-- RN 25547 -->

- When a **contributing booking is quarantined** because of a conflict with another booking, the main bookings making use of it will be quarantined.<!-- RN 29095 -->

- A **contributing booking can be confirmed** without restrictions, regardless of whether the contributing booking is locked or unlocked.<!-- RN 25547 -->

- Setting a **contributing booking on hold** is only implemented if the contributing booking is unlocked and no bookings making use of it have already started, or if it is locked but no bookings are making use of it.<!-- RN 25547 -->

- **Canceling a contributing booking** is only implemented if the contributing booking is locked and no bookings are making use of it, or if it is unlocked and no current bookings are making use of it. Note that if any future bookings make use of the unlocked contributing booking, the contributing booking will be removed from these future bookings and their state will be set to *Partial*.<!-- RN 25547 -->

  > [!NOTE]
  > Canceling a contributing booking will automatically delete the associated service and resources, even if the Booking Manager app is configured with the persistent service option and independently from the *Delete Unlocked Contributing Resource* option.

- **Deleting a contributing booking** is only implemented if the contributing booking is locked and no bookings are making use of it, or if it is unlocked.<!-- RN 25547 -->

  > [!NOTE]
  > When you try to delete a contributing booking, the SRM framework will first try to delete the contributing resource. Only if that step succeeds, will the contributing booking be deleted.<!-- RN 29284 -->

- The behavior when **finishing a contributing booking** also depends on whether it is locked or unlocked:

  - When a locked contributing booking is finished, and it is not used by any main booking, the contributing booking will immediately be finished (i.e. the end time will be set to now plus the rescheduling delay). If it is used by one or more main bookings, the end time of the contributing booking will be updated and aligned with the end time of the main booking with the latest end time, making sure that the new end time is not sooner than the current time plus the rescheduling delay.<!-- RN 28045 -->

  - Finishing an unlocked contributing booking will remove the associated resource from the main bookings that were supposed to make use of it.<!-- RN 28045 --> In case a main booking is already active, finishing its unlocked contributing booking is allowed if the timing remains compatible.<!-- RN 29809 -->

- **Updating the timing of a contributing booking** is allowed if the timing remains compatible with any main bookings making use of it. For an unlocked contributing booking, if the timing becomes incompatible, but the main booking has not started yet, the timing will be updated, but the contributing resource will be removed from the main booking, and the main booking will be set to the Partial state. If the main booking is already running, the timing update is blocked.<!-- RN 25599 -->

- When the **end time of the booking has passed**, a locked contributing booking will automatically be deleted. An unlocked contributing resource will only be deleted if the *Delete Unlocked Contributing Resource* parameter is set to *Yes* (see [Contributing Reservations settings](xref:Booking_Manager_Config_tab#contributing-reservations-settings)). In case it is part of a main booking that is still running, the contributing resource will only be deleted at the end time of the main booking.<!-- RN 25723 -->

## Configuring contributing bookings

> [!TIP]
> See also: [Enabling reuse of contributing bookings](xref:Service_Orchestration_service_definition_advanced#enabling-reuse-of-contributing-bookings)

### Basic configuration

1. Create a **system function** to define the signature of the contributing resource, i.e. the name, logo, interface, and (interface) profile definition(s). To do so, you will need to add a [Functions.xml](xref:Functions_XML_files) file in the folder `C:\Skyline DataMiner\ServiceManager\` on all DMAs in the system and then restart the DMAs. Here is an example of the content of such a functions file:

   ```xml
   <Function id="b91f59c8-58f2-4422-9a28-f0a6bf815ab0" name="RXSAT" maxInstances="0" profile="e21dd094-4815-4c62-8542-f70589767b18">
      <Parameters/>
      <EntryPoints/>
      <Interfaces>
         <Interface id="1" name="RF" type="in"/>
         <Interface id="2" name="ASI" type="out"/>
      </Interfaces>
   </Function>
   ```

1. Create the contributing service definition. This service definition will to define all functions that will be part of the contributing booking and how they will be interconnected. Extra configuration will also be required to indicate how bookings based on the service definition can generate a contributing resource.

   1. [Create a service definition](xref:Service_Orch_creating_service_definitions).

   1. Map the interfaces of functions to interfaces of the system function you made earlier, by adding the following properties to the relevant interfaces:

      - *NoConnectivityCheck*: True

      - *ExposedParentInterfaceId*: <ID of the interface of the system function>

   1. Add the *Contributing Configuration* property to the service definition, and set its value to a JSON string as detailed under [Contributing Configuration](xref:SRM_properties_Booking_Manager#contributing-configuration).

      For example:

      ```json
      { "Concurrency":10,"ConvertToContributing":true,"LifeCycle":"Locked","OrchestrationTrigger":"Local","ParentSystemFunction":"b91f59c8-58f2-4422-9a28-f0a6bf815ab0","PostRoll":0,"PreRoll":0,"ReservationAppendixName":"V46GQJ","ReservationType":"Standalone","ResourcePool":"SDMN.SAT.Resource Pool","Script":"Script:SRM_DummyScript||DummyParameterName=DummyValue","VisioFileName":null}
      ```

1. In the main service definition, where the contributing resource will be used, select the contributing node, add the *IsContributing* property, and set its value to *True*.

### Configuring local orchestration

If local orchestration is used, the contributing booking relies on its own events to configure its resources, instead of on the events of the main booking. As a consequence, a failure of the orchestration (e.g. configuring a function fails) will not be flagged on the main bookings making use of it.

However, any alarm generated by a function in the contributing booking will bubble up to the service associated with the main booking making use of it (if the Booking Manager app is configured to include the contributing service in the main service).

To configure this:

1. Create the system function. See [Basic configuration](#basic-configuration).

1. Create the contributing service definition. See [Basic configuration](#basic-configuration). Make sure to set the *OrchestrationTrigger* field of the *Contributing Configuration* property to *Local*.

1. [Create an LSO script](xref:Service_Orch_creating_LSO_scripts) to orchestrate the content of the contributing booking. Map the actions for the various service states (START, STOP, etc.) to the LSO script in the service definition you created earlier.

> [!NOTE]
> In the LSO script associated with the main booking, do not initiate the configuration of the contributing resource.

### Configuring main orchestration

If main orchestration is used, the main booking making use of the contributing booking will trigger the configuration on the contributing booking. 
If this type of orchestration is used, failure of the contributing orchestration will be flagged on the main booking making use of the contributing booking.

Here are the steps to configure this:

1. Create the system function. See [Basic configuration](#basic-configuration).

1. Create the contributing service definition. See [Basic configuration](#basic-configuration). Make sure to set the *OrchestrationTrigger* field of the *Contributing Configuration* property to *Main*.

1. [Create an LSO script](xref:Service_Orch_creating_LSO_scripts) to orchestrate the content of the contributing booking. Map the actions for the various service states (START, STOP, etc.) to the LSO script in the service definition you created earlier.

1. In the LSO script associated with the main booking, initiate the configuration of the contributing resource, using the *ApplyContributingState* method. See [Service Orchestration LSO script configuration](xref:Service_Orchestration_LSO_script).

### Customizing late conversion behavior

A contributing booking generates a DataMiner service, an enhanced element, and a function DVE at booking creation time. However, for bookings that are not scheduled to start in the near future, this is unnecessary overhead. By default, the SRM framework will therefore only create the above-mentioned components 48 hours prior to the booking start time.

You can adjust this 48-hour sliding window can be adjusted or even disable this "late conversion" feature in the Booking Manager app. To do so:

1. Open the Booking Manager app.

1. Click the hamburger button in the top-left corner and select *Show card side panel*.

1. In the side panel, go to the *General* data page.

1. In the *Contributing Reservations* section, modify the *Contributing Conversion Window* parameter. You can set the parameter to a different value, or use the *Disabled* checkbox to disable the feature.

   > [!NOTE]
   > At the bottom of this section, the *Late Conversion Status* parameter indicates if bookings are currently being converted. Every 10 minutes, the Booking Manager app will check if there are bookings in the conversion window and initiate the conversion when applicable.

### Enabling lite contributing bookings

For setups where many contributing bookings have to be created, you can reduce the load on the system by enabling the "lite" contributing feature. By default, for each contributing booking, an enhanced element is created. However, for lite contributing bookings, this does not happen.

To enable this feature, you can set the *Contributing Booking Type* parameter to *Lite* on the [Config tab](xref:Booking_Manager_Config_tab) of the Booking Manager app.<!-- RN 31488 -->

Alternatively, you can override the default behavior for specific service definitions:<!-- RN 31182 -->

1. In the Services module, go to the *definitions* tab.

1. Select the service definition.

1. Go to the *properties* tab at the top.

1. Add the *LiteContributingResource* attribute with value "true" in the value of the *Contributing Configuration* property.

   > [!TIP]
   > For detailed information on the configuration of this property, see [Contributing Configuration](xref:SRM_properties_Booking_Manager#contributing-configuration).
