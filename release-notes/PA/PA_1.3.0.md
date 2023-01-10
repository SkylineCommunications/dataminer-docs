---
uid: PA_1.3.0
---

# PA 1.3.0

> [!NOTE]
> This version requires that **SRM 1.2.28 [CU1]** is installed.

## New features

#### Function packages included in PA package [ID_30357]

Various functions packages will now be included in the Process Automation package, so that these no longer need to be deployed manually:

| Connector | Function |
|---|---|
| Skyline Generic Token | Token |
| Skyline Process Automation Gateway | Generic Gateway |
| Skyline Process Automation Gateway | Repeat Gateway |

When you run the *SRM_Setup* script, the packages will be imported.

The setup script will now also create a *Generic Gateway* element using the *Skyline Process Automation Gateway* connector, including specific resource pools for both Generic Gateway and Repeat Gateway functions.

> [!IMPORTANT]
> When you update an existing installation with a new package, run the *SRM_Setup* script to make sure you are using the most recent version of the function packages.

#### Integration of Skyline Process Automation and associated functions [ID_30496] [ID_30764]

The Process Automation Framework has been adjusted to support the following functions:

- PA None Start Event
- PA Timer Start Event
- PA End Event

These functions will be deployed when the setup script is executed. A *PA-Process Overview* element and resource pool/resource will be created for each of them.

The necessary LSO script adjustments have been implemented to search for these functions. In case a *PA Instant Start* node is found, a first token will be pushed to the queue connected to it.

> [!NOTE]
> In case these functions are used, the service definition must have a property *ServiceDefinitionType* with value "ProcessAutomation".

For the *PA Timer Start Event* function, the following parameters have been added:

- *PA Timer Start Recurring Pattern*: The pattern that determines when an event is repeated. This is a JSON string of class *PaTimerStartEventRecurringPattern*. For example, to start an event once every 5 days:

  ```json
  {
  "ActiveStartDate":"01/10/2021 10:00",
  "ActiveEndDate":"01/10/2022 00:00",
  "FrequencyInterval":5,
  "FrequencyType":"Daily",
  "SubdayType":"AtTheSpecifiedTime"
  }
  ```

- *PA Initial Process Instantiation*: Can be set to "Enabled" or "Disabled". Indicates if a token should be pushed into the process at the beginning of the activation window.
- *PA Business Key*: Should be set to a domain-specific identifier of a process instance.

For the *PA None Start Event*, the last two of these parameters are also available. When the *PA None Start Event* function is used, a token will only be automatically pushed into the process at the beginning of the activation window if *PA Initial Process Instantiation* is set to "Enabled" and the *PA Business Key* is specified.

#### New Skyline Process Automation Overview connector [ID_30497]

The *Skyline Process Automation Overview* connector will now provide an overview of all processes running in a cluster. It contains a table with the following information for each process:

- Process ID
- Process Name
- Process Instance Name
- Process Definition
- Process Instance ID
- Status
- Start Event Type
- Process Activity

It also contains a *Processes Check* parameter, which will update the table on a regular basis (by default every 5 minutes).

The necessary LSO script adjustments have been implemented to communicate with the element using this connector and update relevant fields when the activation window starts and ends.

#### Pushing tokens into a process [ID_30830]

The Process Automation Framework has been extended to allow pushing tokens into a process. When a process contains a *PA Start Instant Event* or a *PA Start Timer Event*, the Process Overview element will push tokens into the process.

In case of the *PA Start Instant Event*, one token is pushed at the beginning of the activation window if *PA Initial Process Instantiation* is set to "Enabled" and the *PA Business Key* has been specified.

For the *PA Start Timer Event*, tokens are generated based on the recurring pattern defined in the *PA Timer Start Recurring Pattern* parameter. For now, a simple repeat interval is supported with a granularity of 1 minute.

For example, to generate 3 tokens, one each minute:

```json
{
   "Occurrences": 3,
   "SubdayInterval": 1,
   "SubdayType": "Minutes"
}
```

Or to generate unlimited tokens, one each minute:

```json
{
   "SubdayInterval": 1,
   "SubdayType": "Minutes"
}
```

In addition, the following method is now available in the *ProcessOverview* class to make it possible to push a token into a process:

```csharp
public static void PushToken(string paProcessName, string businessKey);
```

> [!NOTE]
> If a process is not yet active when a token is pushed, the token will only actually be pushed when the activation window starts.

#### Skyline Process Automation Overview connector renamed to Skyline Process Automation [ID_31289]

The *Skyline Process Automation Overview* connector has been renamed to *Skyline Process Automation*, and will now be available as an app.

#### New Active Tokens table for queue elements [ID_31340]

All queue elements now have a new *Active Tokens* table (on the *Active Tokens* data page), which lists the active tokens belonging to that queue.

#### Skyline Process Automation: Process Tokens table [ID_31341]

A new *Process Tokens* table has been added to the *Skyline Process Automation* connector. This table will allow you to monitor the tokens related to the currently running processes.

Entries will be removed from the table once the time limit indicated in the *Time to Keep Completed Tokens* parameter has been exceeded after they get the status "Completed". They are also removed if they have the status "Error" and the corresponding process is deleted.

#### New 'PA DOM Reference' profile parameter [ID_31945]

A new profile parameter named *PA DOM Reference* has been added to *PA Timer Start Event* and *PA None Start Event*. It can be used to store a serialized *DomInstanceId* object. This object can then be referenced in the token that is passed along each queue.

In addition, the *PushToken* call has been extended to feature a new *DomReferenceId* input parameter, so that users can push a token that already has a DOM reference ID.

> [!IMPORTANT]
> To make sure that the updated profile definitions are properly updated in your system, you need to run the *SRM_Setup* script.

#### Support for routing tokens based on DOM fields [ID_32149]

The Process Automation Framework has been adjusted to support routing tokens based on DOM fields. For this purpose, a new *DomField* field has been introduced in the *RoutingRule* class. This needs to be specified in JSON in the *PA GW RoutingRules* parameter. This parameter defines the routing table of gateways queues.

Example:

```json
{
 "Evaluation": "First Matching",
 "Rules": [
  {
   "Description": "Generate a token as soon as we have received an incoming token on each of the 2 incoming connected interfaces with the DOM Field 'Generic Text Field Descriptor 1' equal to 'OK'",
   "Conditions": [
     {
      "DomField": {
      "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
      "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
     },
     "IncomingGatewayKeyName": null,
     "IncomingInterfaceId": 1,
     "Operation": "Equal",
     "Value": "OK"
    },
    {
     "DomField": {
      "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
      "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
    },
     "IncomingGatewayKeyName": null,
     "IncomingInterfaceId": 2,
     "Operation": "Equal",
     "Value": "OK"
    }
   ],
   "DoTagTokens": false,
   "OutgoingInterfaceIds": [11],
   "SequenceId": 1
  }
 ]
}
```

#### Logging of events related to a token [ID_32269]

Events related to a token can now be logged.

To enable this logging, specify a location in the *Booking Logging Location* parameter (available under *Config* > *General* > *History and Logs*) of the Booking Manager for the process the token is related to.

Log entries will then be added to the log file based on the business key. The token ID will be available for each log entry.

The logging cleanup settings configured in the Booking Manager will be applied to these log files.

#### New 'Concurrent Tasks' parameter and 'PA Task Type' capability parameter [ID_32305]

A new *Concurrent Tasks* parameter has been added to the *Skyline Queue Manager* connector. It will allow you to define the number of concurrent tasks that can be handled at the same time.

In addition, a new capability parameter, *PA Task Type*, is now available in PA systems. Configuring a DataMiner resource with that capability will allow you to define the type of task that the queue will manage.

#### New PA Script Task and PA User Task functions [ID_32524]

To support generic script tasks, the Process Automation Framework has been extended with two new functions, *PA Script Task* and *PA User Task*.

- *PA Script Task* has a profile definition without profile parameters. For each different script task, a profile definition inheriting the based profile definition needs to be created.
- *PA User Task* has a profile definition with only one parameter, *PA User DOM Definition*. The same logic as for *PA Script Task* is applied, except that the *PA User DOM Definition* parameter needs to point to a ModuleID and a user DOM definition in the profile instance.

#### New script to create activation windows [ID_32674]

A new script, *PA_CreateActivationWindow*, is now available, which can be used in the *Create Booking Script* parameter of the Booking Manager to help create activation windows (i.e. Process Automation "bookings").

#### New PA_ProcessDefinitionConfiguration script [ID_32774]

A new *PA_ProcessDefinitionConfiguration* script is now available, which can be used as a wizard to configure all nodes of a process definition. The script has the input argument *Input Data*, which requires the process definition ID, e.g. `{"ServiceDefinitionId":"9fe4d5ea-eb02-4a93-9e31-f01e66f1c9e3"}`.

#### PaProfileLoadDomHelper now logs actions related to token [ID_32809]

The *PaProfileLoadDomHelper* can now log the actions related to the token it was created for.

An example of how to add logging is available in the *PA_ProfileLoadDomTemplate* script:

```csharp
using Skyline.DataMiner.DataMinerSolutions.ProcessAutomation.Helpers.Logging;

try
{
    // ...

    helper.ReturnSuccess();
    helper.Log("Successfully approved to invoice", PaLogLevel.Information);
}
catch (Exception ex)
{
    helper.Log($"An issue occurred while approving the invoice: {ex}", PaLogLevel.Error);
    helper.SendErrorMessageToTokenHandler();
}
```

#### Timer Start Event now generates DOM instance copies [ID_32850]

The *Timer Start Event* now generates DOM instance copies for each new main token. This way, whenever a token instance is initiated, a DOM instance is also provided.

#### Script task activity configuration [ID_32968]

It is now possible to configure the profile instance for a script task activity via the *PA_ProcessDefinitionConfiguration* script. The script allows you to select an existing profile instance or configure a new one. When you create a new profile instance, you will be able to configure its name and parameters. All profile definition parameters will be listed, with the available field descriptors, so that you will be able to pick which field descriptor to configure on each parameter. You will also be able to set a hard-coded value for a profile parameter.

#### User tasks [ID_33043]

The Process Automation Framework now supports user tasks. When these tasks receive a token, they will wait for a user action to be completed, and then they will complete the token.

For this purpose, a DOM behavior definition *Pa User Task Behavior Definition* is available in the *pa_user_task* DOM module, which implements a status system with the statuses "open_status" and "closed_status".

When a token reaches a PA user task, a user DOM instance is created based on a user DOM definition defined in the activity profile instance. This DOM instance will by default contain a field descriptor *Process DOM Instance*, which indicates that the DOM instance is attached to the token.

When the user executes the action associated with the status "open_status" on the created user DOM instance, the token is completed and the DOM instance transitions to the status "closed_status".

In case you want to use the default user DOM definition *PA Default Definition*, a default profile instance *PA User Task Default Instance* is available, which can be used when creating the activation window.

In case you want to add more field descriptors to the user DOM instance that will be created:

- Create a section definition with the desired field descriptors. Note that these field descriptors need to have a default value (e.g. string.Empty).
- Create a DOM behavior definition inheriting from *PA User Task Behavior Definition*, adding two entries to *StatusSectionDefinitionLinks* (one for open_status and the other for closed_status) referencing the created SectionDefinition and the new field descriptors.
- Create a DOM definition making use of the created DOM behavior definition adding the created section definition and the *Process DOM Instance Section*.
- Create a profile instance referencing the created DOM definition in the *PA User DOM Definition* parameter.

The LSO script that runs when the activation window starts has also been extended to validate all user tasks. It will check if the DOM definition is correctly configured and will notify the user in case of an invalid or missing configuration.

#### User task process definition configuration [ID_33111]

It is now possible to configure user tasks in the process definition configuration UI of the Process Automation Framework. To do so, click the *Configure* button next to a user task activity in the process definition configuration script. You will then be able to configure the user task based on existing profile instances or create new profile instances based on the existing user task DOM definition.

#### Process configuration using the Process Automation app [ID_33174]

You can now configure a process using the Process Automation app. You can create, configure, and activate a process definition, and an overview is available of the active and future processes with their activation windows, as well as an overview of all active tokens.

#### Support for user DOM instance fields [ID_33614]

The Process Automation Framework now supports routing tokens based on user DOM instance fields. For this purpose, a new *UserDomInstance* field has been introduced, which defines the label of the service definition node that generated a user DOM instance. This field is optional. For example:

```json
{
 "Evaluation": "First Matching",
 "Rules": [
  {
   "Description": "Generate a token as soon as we have received an incoming token on each of the 2 incoming connected interfaces with the User DOM Instance field 'Action' equal to 'OK'",
   "Conditions": [
     {
      "DomField": {
      "UserDomInstance" : "Main",
      "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
      "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
     },
     "IncomingInterfaceId": 1,
     "Operation": "Equal",
     "Value": "OK"
    },
    {
     "DomField": {
      "UserDomInstance" : "Backup",
      "FieldDescriptorId": "9a15783b-ccc0-4d8f-9574-0870c55f4a73",
      "SectionDefinitionId": "5d6c39ed-f616-4ad2-b311-28e39d52505a"
    },
     "IncomingInterfaceId": 2,
     "Operation": "Equal",
     "Value": "OK"
    }
   ],
   "DoTagTokens": false,
   "OutgoingInterfaceIds": [11],
   "SequenceId": 1
  }
 ]
}
```

#### Deleting a process [ID_33695]

The Process Automation element now allows you to delete a process. To do so, right-click the relevant entry and select *Delete selected item(s)*. However, note that this is only possible if there are no active or future activation windows for the process.

## Changes

### Enhancements

#### Tokens stored differently [ID_30377]

Queue elements now store tokens in a different manner to allow support for historical storage. Instead of dynamic tables, dedicated storage is used. Volatile profile instances are no longer stored as serialized objects in the tokens but instead created as copies of profile instances in the dedicated storage.

#### Support for connections between gateways [ID_30478]

It is now possible to pass tokens between two connected gateways.

#### Repeat gateway no longer clears gateway keys and process profile instances [ID_30490]

The repeat gateway will now repeat tokens while keeping gateway keys and process profile instances. Previously, the latter were cleared instead.

#### 'Busy' and 'Idle' indication of processes [ID_30961]

When a process is still processing one or more tokens in an activity and a token gets pushed to the process, the *Process Automation Overview* element will now indicate that the process activity is "Busy".

In addition, when the PA Framework indicates that a token has been fully handled and there are no more tokens that need to be processed by this same process, the *Process Automation Overview* element will now indicate that the process activity is "Idle".

#### Token created in database even when process has not started yet [ID_31856]

When a token is pushed into a process, it will now always be created in the database immediately, instead of only after the process starts.

#### New PaProfileLoadDomHelper class [ID_32130]

A new *PaProfileLoadDomHelper* class is now available to support the use of DOM in *Process Automation Profile Load Scripts*. A new script, *PA_ProfileLoadDomTemplate*, has also been added as an example.

#### Improved Queue Manager performance [ID_32526]

The way the *Skyline Queue Manager* connector processes tokens has been improved so that fewer SLNet calls need to be performed, and multiple tokens can be handled at the same time instead of one token per second.

#### PA functions extended to indicate their type + additional improvements [ID_33138]

The following functions in the PA Framework have been extended so that their type is indicated:

| Function name | Function type |
|---|---|
| PA None Start Event | NoneStartEvent |
| PA Timer Start Event | TimeStartEvent |
| PA End Event | EndEvent |
| PA Script Task | ScriptTask |
| PA User Task | UserTask |
| Generic Gateway | Gateway |
| Repeat Gateway | Gateway |

In addition, service definitions that use the *PA Timer Start Event* or *PA None Start Event* functions must now be of type "Process Automation" or "Custom Process Automation".

The Skyline Queue Manager connector has also been extended to add the new *ProcessAutomation* tag to indicate *Queue Depth* and *Queue Size* parameters.

> [!NOTE]
>
> - Function types are introduced in DataMiner 10.2.5/10.3.0 (see [ID_32851](xref:General_Feature_Release_10.2.5#functionsxml-file-assigning-a-function-type-to-a-function-id_32851)).
> - Service definition types are introduced in DataMiner 10.1.4/10.2.0 and further extended in DataMiner 10.2.4/10.3.0 (see [ID_28799](xref:General_Feature_Release_10.1.4#servicedefinitions-of-type-processautomation-id_28799) and [ID_32624](xref:General_Feature_Release_10.2.4#reservationinstances-now-have-a-reservationinstancetype-id_32624).
> - *ProcessAutomation* tags are introduced in DataMiner 10.2.5/10.3.0 (see [ID_32910](xref:General_Feature_Release_10.2.5#new-processautomation-element-to-pass-parameter-values-to-the-service-definition-component-of-the-dashboards-app-id_32910)).

#### Process Automation now uses dedicated module ID [ID_33347]

The *Skyline Process Automation* connector will now only process notifications from DOM instances using the *process_automation* module ID, and when it is used for user task activities, it will only generate tokens with DOM instances that use the *pa_user_task* module ID.

#### Limited set of functions when editing process definition [ID_33469]

When you edit a process definition in the Process Automation app, the list of available functions is now limited to functions of type UserTask, ScriptTask, ResourceTask, Gateway, NoneStartEvent, TimeStartEvent, and EndEvent.

#### SRM_Setup script now supports renamed tokens [ID_33581]

Up to now, the *SRM_Setup* script checked if a token resource existed by checking for a resource with the name "Token". If this could not be found, a new resource was created, unless the maximum amount was reached.

Now this check will instead look for a resource name containing the word "token" (case-insensitive). This means that it will now be possible to rename token resources to *Token PLM*, *Token IDP*, etc.

#### GetParameterValue, TryGetParameterValue and UpdateValue no longer limited to convertible value types [ID_33610]

Up to now, the methods *GetParameterValue* and *TryGetParameterValue* were limited to retrieving convertible value types. To support the retrieval of values from a DOM instance such as a GUID or GUID list, this constraint has now been removed.

The following constraints now apply:

- If a value comes from a DOM instance:

  - If the value is compatible with the requested type, it will be returned as is.

  - If it is not compatible and both value types are convertible, the value will be converted.

  - If neither of the above applies, the attempt to retrieve the value will fail.

- If a value comes from a profile instance:

  - If the expected type is convertible, the value will be converted.

  - If the expected type is not convertible, the value will be interpreted as JSON code representing the expected type.

  - If neither of the above applies, the attempt to retrieve the value will fail.

The convertible value constraint was also removed for the *UpdateValue* method.

#### PA_FunctionType no longer supported [ID_33617]

The node property *PA_FunctionType* is now no longer supported. Users can no longer use custom gateways and should use the Generic Gateway function definition that is included in the Process Automation package.

#### Improvements to simplify PA deployment [ID_33653]

To simplify the deployment of the Process Automation Framework, the following improvements have been implemented:

- When the *SRM_Setup* script is launched without the Booking Manager element attribute, a default Booking Manager instance and corresponding views will be created.
- All resource pools and queue elements generated by the *SRM_Setup* script will no longer have any knowledge of the virtual platform.
- The script responsible for creating an activation window, *PA_CreateActivationWindow*, will also no longer have any knowledge of the virtual platform when looking for resource pools.

> [!IMPORTANT]
> As resource pools used for Process Automation should not have any knowledge of the virtual platform, you will need to run the *PA_MigratePoolsAndQueues* script to migrate all existing queues and resource pools. This is a breaking change.

#### Icons for PA functions [ID_33667]

The standard function definitions delivered in the PA package (User Task, Script Task, None Start Event, End Event, Timer Start Event, and Generic Gateway) now each have a specific icon.

#### Support for transition of process DOM instance state in Profile-Load Script [ID_33697]

The DOM helper can now be used to trigger a transition of the state of a process DOM instance in a Profile-Load Script.

For example, the following lines cause a state transition from "Confirmed" to "Processed".

```csharp
var transitionId = "confirmed_to_processed";
helper.TransitionState(transitionId);
```

If fields have been updated before this method is called, those changes will be applied to the process DOM instance before the transition happens.

#### Reviewed PA function icons [ID_33816]

The icons linked to the standard function definitions included with Process Automation (User Task, Script Task, None Start Event, End Event, Timer Start Event) have been reviewed.

#### InterApp calls no longer used [ID_34087]

To prevent possible issues when InterApp calls are used, such as the exception `System.NotSupportedException: The called method is not supported in dynamic assembly`, the Process Automation Framework and Queue Manager connector now no longer use InterApp calls.

#### PA_ProcessDefinitionConfiguration script now supports Enum and DateTime formats [ID_34215]

In the *PA_ProcessDefinitionConfiguration* script, support has been added for Enum and DateTime formats.

DateTime values will be stored as the kind "Unspecified". In a Profile-Load Script, this can then be interpreted correctly based on the parameter the values were set for.

#### Default TTL for process and user DOM instances [ID_34354]

The TTL for process and user DOM instances is now set to 30 days by default. When you set up or update Process Automation by running the *SRM_Setup* script, and no TTL settings have been configured yet or the TTL is set to zero, this default TTL value will be set automatically. If a TTL has already been configured, it will not be changed.

#### Main token now set to error state to match child token state [ID_34482]

When a child token is set to an error state, now the main token will also be set to an error state.

### Fixes

#### Node profile instance updated in case profile parameter did not have link to DOM field [ID_32356]

In case a profile parameter did not have a link to a DOM field, an issue in the *UpdateField* method of the *PaProfileLoadDomHelper* class caused it to update the node profile instance. In such a case, the method will now instead throw an error to indicate that the profile parameter has no link to DOM.

#### Not possible to use UpdateValue in a PA Profile Load Script in case of missing optional field value [ID_33613]

In case an optional field value was not added to a DOM instance section, it could occur that using *UpdateValue* in a PA Profile-Load Script failed. Support has now been added to add the field value in such a case.

#### Tokens pushed in failed activation window [ID_33889]

In some cases, it could occur that tokens were pushed into the process while the activation window was not fully operational.
