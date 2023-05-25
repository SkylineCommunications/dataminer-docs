---
uid: Service_Orchestration_LSO_script
---

# Service Orchestration LSO script configuration

> [!TIP]
> An example LSO script is available as part of the framework: *SRM_LSOTemplate*.

LSO scripts are responsible for orchestrating the configuration of resources, i.e. launching Profile-Load Scripts to configure the resources included in bookings. See [Life cycle Service Orchestration (LSO) script](#srm_scripting#life-cycle-service-orchestration-lso-script).

When an event needs to be triggered (e.g. end of pre-roll) for a specific booking, the SRM framework will look up the [target service state](xref:Service_Orchestration_service_states) defined in the Booking Manager app (e.g. START). Based on this, it will then identify the LSO script to run by looking at the list of [actions defined in the service definition](xref:Service_Orchestration_service_states#configuring-the-action-linked-to-each-service-state).

## Main classes

LSO scripts can make use of the following classes to interact with bookings and their included resources:

- [LsoEnhancedAction](#lsoenhancedaction-class): Used to retrieve information about the event or the target service state triggering the LSO script.
- [SrmBookingConfiguration](#srmbookingconfiguration-class): Used to interact with the booking and related objects (e.g. get a list of resources).
- [SrmResourceConfiguration](#srmresourceconfiguration-class): Used to interact with the resource/function DVE (e.g. apply a profile).

> [!TIP]
> Load *SLSRMLibrary.dll* in a software development environment to get an exhaustive list of the available methods.

## LsoEnhancedAction class

With the *LsoEnhancedAction* class, an LSO script can implement different logic based on:

- The **target service state** (start, stop, standby, etc.).

  ```json
  var enhancedAction = new LsoEnhancedAction(engine.GetScriptParamValue<string>("Action"));
  switch (enhancedAction.ServiceState)
  {
     case "START":
  ...
  }
  ```

- The **event**<!-- RN 23536 -->

  ```json
  var enhancedAction = new LsoEnhancedAction(engine.GetScriptParamValue<string>("Action"));
  switch (enhancedAction.Event)
  {
     case SrmEvent.START_BOOKING_WITH_PREROLL:
  ...
  }
  ```

  You can configure the following events:

  - *START_BOOKING_WITH_PREROLL*: Event that will happen at the beginning of a booking.
  - *START*: Event that will happen when the pre-roll stage ends. If there is no pre-roll stage, the event will run right after the START_BOOKING_WITH_PREROLL event.
  - *STOP*: Event that will happen when the post-roll stage starts. If there is no post-roll stage, the event will run at the booking end time.
  - *STOP_BOOKING_WITH_POSTROLL*: Event that will happen at the end of the booking. If there is no post-roll stage, the event will run right after the STOP event.

### SrmBookingConfiguration class

In LSO scripts, you can use the *SrmBookingConfiguration* class to interact with the resources part of the booking. You can do so by:

- Using the label of the node in the service definition. For example, if the node has the "Decoder" label:

  `var decoderResource = SrmBookingConfiguration.GetResource("Decoder");`

  This will return an *SrmResourceConfiguration* object.

- Retrieving all resources and checking the node label:

  `var resources = SrmBookingConfiguration.GetResourcesToOrchestrate().ToArray();`

  This will return an array of *SrmResourceConfiguration* objects. The *Label* property on the *SrmResourcesConfiguration* object can then be used to access the node label.

### SrmResourceConfiguration class

The *SrmResourceConfiguration* object allows the use of the following methods to trigger the execution of Profile-Load Scripts:

- `SrmResourceConfiguration.ApplyProfile(string profileAction)`

  Used on a non-contributing resource. Executes the Profile-Load Script and applies the configuration selected at booking creation time.

- `SrmResourceConfiguration.ApplyServiceActionProfile(string serviceAction, string profileAction)`

  Used on a non-contributing resource. Executes the Profile-Load Script and applies the state profile instance associated with the profile instance selected at booking creation time.

- `SrmResourceConfiguration.ApplyContributingState(string serviceState)`

  Used in the LSO script associated with a main booking and on a contributing resource.

  Executes:

  - The Profile-Load Script defined on the contributing node of the main service definition (with the *ApplyProfileScript* property).

  - The LSO script associated with the service definition of the contributing booking, if defined.

- `SrmResourceConfiguration.ApplyContributingProfile()`<!--  RN 31301 -->

  Used in the LSO script associated with a main booking and on a contributing resource.

  Executes:

  - The Profile-Load Script defined on the contributing node of the main service definition (with the *ApplyProfileScript* property), providing the settings specified at booking creation time.

  - The LSO script associated with the service definition of the contributing booking, if defined.

By default, the methods above will launch a Profile-Load Script and validate each set. This means that by default, the *performCheckSets* flag is set to true. However, overloaded methods exist to launch the script without validating each set:<!--  RN 26236 -->

- `SrmResourceConfiguration.ApplyContributingState(string serviceState, bool performCheckSets)`
- `SrmResourceConfiguration.ApplyProfile(string profileAction, bool performCheckSets)`
- `SrmResourceConfiguration.ApplyServiceActionProfile(string serviceAction, string profileAction, bool performCheckSets)`

When data needs to be returned from the execution of a Profile-Load Script, you can use the following methods:<!--  RN 30862 -->

- `resourceConfig.ApplyContributingStateWithReturn`
- `resourceConfig.ApplyServiceActionProfileWithReturn`
- `resourceConfig.ApplyProfileWithReturn`

These three methods will return a <string,string> dictionary. However, for this to happen, the Profile-Load Script must build the dictionary (see [Returning data](xref:creating_profile_load_scripts#returning-data)).
