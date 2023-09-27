---
uid: General_Feature_Release_10.1.11
---

# General Feature Release 10.1.11

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!TIP]
> For information on how to upgrade DataMiner, see [Upgrading a DataMiner Agent](xref:Upgrading_a_DataMiner_Agent).

## New features

### DMS core functionality

#### DataMiner Object Model: DomBehaviorDefinition object & status system [ID_30443]

The DataMiner Object Model can now also contain objects of type DomBehaviorDefinition.

A DomBehaviorDefinition is a standalone object that extends a normal DomDefinition and contains configuration settings for special behavior, including the configuration of the status system. In a ModuleSettings object, the ModuleBehaviorDefinition property will contain the ID of the DomBehaviorDefinition that includes all the configuration settings that must be used in that particular module.

##### DomBehaviorDefinition properties

A DomBehaviorDefinition object has the following properties.

| Property | Type | Filterable | Description |
|--|--|--|--|
| ID | DomBehaviorDefinitionId | Yes | The unique ID of the definition. |
| Name | string | Yes | The name of the definition. |
| ParentId | DomBehaviorDefinitionId | Yes | The ID of the parent DomBehavior-Definition (when using inheritance). |
| InitialStatusId | string | No | The ID of the status that should be used when new DomInstances are created. |
| Statuses | List\<DomStatus> | No | A list of all statuses. |
| StatusSectionDefinitionLinks | List\<DomStatusSectionDefinitionLink> | No | A list of links to SectionDefinitions that define which fields are required, allowed, etc. for a specific status. |
| StatusTransitions | List\<DomStatusTransition> | No | A list of all allowed status transitions. |

> [!NOTE]
> Properties of which the *Filterable* column contains “Yes” can be used for filtering using DomBehaviorDefinitionExposers.

##### DomBehaviorDefinition inheritance

One DomBehaviorDefinition can inherit from another.

Limitations:

- A DomBehaviorDefinition can only inherit from the DomBehaviorDefinition that is specified in the ModuleBehaviorDefinition property of the ModuleSettings object.
- A DomBehaviorDefinition that inherits from another DomBehaviorDefinition can only contain an ID, a parent ID and a list of additional DomStatusSectionDefinitionLinks to SectionDefinitions that are not defined in the module definition. Adding additional statuses or status transitions is not allowed.

##### Requirements

Create & update:

- The string IDs of the statuses and status transitions must not contain duplicates and should all be lowercase.
- When a ModuleDomBehaviorDefinition has been defined, the definition that is being created or updated must inherit from it. When no ModuleDomBehaviorDefinition has been defined, the ParentId property should be empty.
- The InitialStatusId property must contain the ID of an existing status.
- All status transitions must contain IDs of existing statuses.
- For each SectionDefinition/status pair, only one DomStatusSectionDefinitionLink is allowed.
- All DomStatusSectionDefinitionLinks must refer to existing status IDs.

Delete:

- A DomBehaviorDefinition can only be deleted when no DomDefinitions or other DomBehaviorDefinitions link to it.

##### Errors

The TraceData can contain one or more DomDefinitionErrors. For each error, the Id and Name properties will be filled in alongside any other property mentioned in the description. See below for a list of all possible ErrorReasons:

| Reason | Description |
|--|--|
| InvalidParentId | The DomBehaviorDefinition.ParentId property contains an unexpected ID. If a ModuleDomBehaviorDefinition is defined, it must contain the ID of that definition. If not, it should be empty. |
| InheritingDefinitionContainsInvalidData | The DomBehaviorDefinition inherits from another one, but it contains data that is not allowed. Only the DomBehaviorDefinition.StatusSectionDefinitionLinks can contain additional objects. |
| StatusTransitionsReferenceNonExistingStatuses | At least one DomStatusTransition refers to a status that does not exist. The ID(s) of the invalid transition(s) can be found in StatusTransitionsIds. |
| StatusSectionDefinitionLinksReferenceNonExistingStatuses | At least one DomStatusSectionDefinitionLink refers to a status that does not exist. The ID(s) of the invalid DomStatusSectionDefinitionLink(s) can be found in DomStatusSectionDefinitionLinkIds. |
| InvalidStatusIds | At least one status has an invalid ID (IDs should only contain lowercase characters). The ID(s) of the invalid status(es) can be found in StatusIds. |
| DuplicateStatusIds | Some statuses have duplicate status IDs. The ID(s) of the duplicate status(es) can be found in StatusIds. |
| InvalidTransitionIds | At least one transition has an invalid transition ID (IDs should only contain lowercase characters). The ID(s) of the invalid transition(s) can be found in StatusTransitionsIds. |
| DuplicateTransitionIds | Some transitions have duplicate transition IDs. The ID(s) of the duplicate transition(s) can be found in StatusTransitionsIds. |
| InUseByDomDefinitions | The DomBehaviorDefinition cannot be deleted because it is being used by at least one DomDefinition. The ID(s) of these DomDefinition(s) can be found in DomDefinitionIds. |
| InUseByDomBehaviorDefinitions | The DomBehaviorDefinition cannot be deleted because it is being used by at least one DomBehaviorDefinition. The ID(s) of these DomBehaviorDefinition(s) can be found in DomBehaviorDefinitionIds. |
| InvalidInitialStatusId | The DomBehaviorDefinition defines at least one status, but does not define a valid initial status. The ID of the invalid initial status (which can be empty) can be found in StatusIds. |
| DuplicateSectionDefinitionLinks | The DomBehaviorDefinition defines more than one DomStatusSectionDefinitionLink for the same SectionDefinition/status pair. The ID(s) of the duplicate DomStatusSectionDefinitionLinks can be found in DomStatusSectionDefinitionLinkIds. |

##### Security

Security checks are performed on CRUD actions when user permissions are configured on the DomManagerSecuritySettings (of the ModuleSettings).

- To read DomBehaviorDefinitions, users must be granted the DomManagerSecuritySettings.ViewPermission.
- To create, update or delete DomBehaviorDefinitions, users must be granted the DomManagerSecuritySettings.ConfigurePermission.

> [!NOTE]
> To create, update or delete the ModuleDomBehaviorDefinition, users must be granted the ModuleSettingsConfiguration permission.

##### Status system

In a DomManager, you can now configure a DomDefinition to use the status system.

When a DomDefinition is using the status system, each DomInstance linked to that DomDefinition has to adhere to the rules set by the status system. The status system can be configured by means of a DomBehaviorDefinition object linked to the DomDefinition. A DomBehaviorDefinition object contains properties in which you can store the statuses, the initial status, the status transitions and links to the SectionDefinitions.

Using the status system is an alternate way of defining which data should be present in a DomInstance. This means that, when a status system is used, the SectionDefinitionLinks on the DomDefinition will not be used.

> [!NOTE]
> A DomManager will detect that the status system is being used from the moment (a) a DomDefinition is linked to a DomBehaviorDefinition and (b) that DomBehaviorDefinition contains at least one status.

To set up a status system, do the following:

1. Create a new DomBehaviorDefinition.

   - Add all statuses.
   - Define the initial status.
   - Add all status transitions.
   - Configure all fields.

1. Link a DomDefinition to the DomBehaviorDefinition.

1. Create DomInstances using the appropriate statuses and fields.

Configuration:

- To configure the statuses, for each status add a DomStatus object to the Statuses list property of the DomBehaviorDefinition. A DomStatus has the following properties:

  | Property | Type   | Explanation |
  |--|--|--|
  | Id | string | The ID of the status, consisting of lowercase characters only. Example: “initial_status” |
  | DisplayName | string | The display name of the status. Example: “Initial” |

  > [!NOTE]
  >
  > - The Statuses collection should not contain any DomStatus objects with identical IDs.
  > - InitialStatusId must contain the ID of an existing status. When a DomInstance is created and no status is assigned to it, it will automatically be assigned the status specified in InitialStatusId.

- To configure the allowed status transitions, for each transition add a DomStatusTransition object to the Transitions list property of the DomBehaviorDefinition. A DomStatusTransition has the following properties:

  | Property | Type | Explanation |
  |--|--|--|
  | Id | string | The ID of the transition, consisting of lowercase characters only. Example: “initial_to_accepted_status” |
  | FromStatusId | string | The ID of the status from which the DomInstance will transition. |
  | ToStatusId | string | The ID of the status to which the DomInstance will transition. |
  | FlowLevel | int | The flow level of the transition compared to other transitions. The main transition will have FlowLevel 0 (the highest priority), while alternate transitions from the same status will have FlowLevel 1 or more. |

  > [!NOTE]
  > The Transitions collection should not contain any DomStatusTransition objects with identical IDs.

- For each status, you can configure the requirements of a specific field. To do so, create DomStatusSectionDefinitionLinks that each include DomStatusFieldDescriptorLinks. A DomStatusSectionDefinitionLink has the following properties:

  | Property | Type | Explanation |
  |--|--|--|
  | Id | DomStatusSectionDefinitionLinkId | The SectionDefinitionID and the status ID. |
  | FieldDescriptorLinks | List\<DomStatusFieldDescriptorLink> | The links to FieldDescriptors that are part of the SectionDefinition. |

  A DomStatusFieldDescriptorLink contains the following properties:

  | Property | Type | Explanation |
  |--|--|--|
  | FieldDescriptorId | FieldDescriptorID | The ID of the linked FieldDescriptor. |
  | Visible | bool | Whether this field should be visible in the UI for this status. |
  | RequiredForStatus | bool | Whether a value for this field must be present and valid in this status. |
  | ReadOnly | bool | Whether values of this field are read-only in this status. |

  > [!NOTE]
  >
  > - When there is no FieldDescriptorLink for an existing FieldDescriptor, then no values will be allowed for this FieldDescriptor in that specific status.
  > - The Visible property is only used to tell the UI whether the field should be visible or not.
  > - When a field is marked as required, then at least one value for this FieldDescriptor should be present in a DomInstance and all values for this FieldDescriptor should be valid according to the validators of that descriptor (if any were defined).
  > - When a field is marked as read-only for a specified status, the values cannot be changed. If none were present before transitioning to that status, none can be added anymore once the DomInstance is in that status.
  > - The existence of the SectionDefinitions and FieldDescriptors are not checked when a DomBehaviorDefinition is saved.

  Some examples of fields you can define:

  | Case | RequiredForStatus | ReadOnly | Note |
  |--|--|--|--|
  | Not allowed | N/A | N/A | When no values are allowed to be present, no FieldDescriptorLink should be added to the list. |
  | Optional & editable | false | false | A value can optionally be added or an existing value can be updated or deleted. |
  | Optional & not editable  | false | true | A value may be present but it is not required. None can be added, edited or deleted. |
  | Required & editable | true | false | A valid value must be present when transitioning to the status in question and it can be updated as long as there is at least one value and all values are valid. |
  | Required & not editable | true | true | A valid value must be present when transitioning and it can no longer be changed in this status. |

If a DomInstance is created without a status, the DomManager will automatically assign the initial status when it detects that the instance is linked to a DomDefinition that uses the status system.

Transitioning to another status can only be done by means of a specific transition request. Changing the status by performing a status update is not allowed. A transition request requires the ID of the DomInstance and the ID of the transition. These requests can be sent using the helper.

```csharp
domHelper.DomInstances.DoStatusTransition(domInstance.ID, "initial_to_acceptance");
```

When something goes wrong while performing a status transition, a DomStatusTransitionError will be returned in the TraceData of the request. This error can contain the following reasons:

| Reason | Description |
|--|--|
| StatusTransitionNotFound | The transition ID does not match any of the IDs defined on the associated DomBehaviorDefinition. This error can also occur when no valid DomBehaviorDefinition is linked. StatusTransitionId contains the ID of the transition that could not be found. |
| StatusTransitionIncompatibleWithCurrentStatus | The current status of the DomInstance does not match the “from” status defined by the transition. StatusTransitionId contains the ID of the transition that could not be completed. |
| DomInstanceContainsUnknownFieldsForNextStatus | At least one FieldValue was defined on the DomInstance for which in the DomBehaviorDefinition no link could be found to the next status. AssociatedFields contains the SectionDefinitionID/FieldDescriptorID pairs of the unknown fields. |
| DomInstanceHasInvalidFieldsForNextStatus | The DomInstance contains fields that are required but are not valid according to at least one validator. If there are multiple values for the same SectionDefinition and FieldDescriptor, only one entry will be included. AssociatedFields contains the SectionDefinitionID/FieldDescriptorID pairs of the invalid fields. |
| DomInstanceHasMissingRequiredFieldsForNextStatus | The DomInstance does not contain all fields that are required for the next status. AssociatedFields contains the SectionDefinitionID/FieldDescriptorID pairs of the missing fields. |
| CrudFailedExceptionOccurred | When saving the DomInstance, a CrudFailedException occurred. InnerTraceData will contain the TraceData included in the exception. |

It is possible to mark one DomBehaviorDefinition as the main “Module” definition. This will force all other DomBehaviorDefinitions to inherit from it, forcing them all to use the same status system. The inheriting definitions can only add extra DomStatusSectionDefinitionLinks.

#### New DataMiner process: SLSpiHost [ID_30869]

From now on, all processing with regard to system performance indicators (SPIs) will be performed by the new SLSpiHost process instead of the SLNet process.

#### DataMiner Object Model: Actions & buttons [ID_30923]

It is now possible to define actions on a DomBehaviorDefinition, which can be triggered via the DomHelper, and buttons that will execute one or more actions when clicked.

##### Defining an action

An action can be defined by adding an IDomActionDefinition to the ActionDefinitions list of a DomBehaviorDefinition. Each action definition has an ID of type string and a condition of type IDomCondition. The ID must be unique for the DomBehaviorDefinition in question and can only contain lower-case characters.

Currently, you can only define actions of type ExecuteScriptDomActionDefinition, i.e. actions that execute a specified script. This type of action has the following properties.

| Property | Type | Description |
|--|--|--|
| Id | string | The ID of the action. |
| Condition | IDomCondition | The condition that should be met before the action is allowed to be executed. Note: When you do not define a condition, it will always be allowed to execute the action. |
| Script | string | The name of the script to be executed. |
| Async | bool | Whether the script will be run asynchronously (true) or synchronously (false). When true, no errors or info data from the script will be returned. |
| ScriptOptions | List\<string> | A list of options (e.g. “PARAMETER:1:MyValue”) that will be passed to the SLAutomation process during execution. Note: Do not add the “DEFER” option. This option will be added automatically depending on the value of the Async property. |

The scripts that will be executed using this action require a custom entry point of type OnDomAction. This entry point method should have two arguments: the IEngine object and an ExecuteScriptDomActionContext object. See the following example.

```csharp
using Skyline.DataMiner.Automation;
using Skyline.DataMiner.Net.Apps.DataMinerObjectModel.Actions;
namespace DOM_Action_Example
{
   public class Script
   {
      public void Run(Engine engine)
      {
         engine.ExitFail("This script should be executed using the 'OnDomAction' entry point");
      }
      [AutomationEntryPoint(AutomationEntryPointType.Types.OnDomAction)]
      public void OnDomActionMethod(IEngine engine, ExecuteScriptDomActionContext context)
      {
         engine.GenerateInformation($"The DOM action with ID '{context.ActionId}' was executed.");
      }
   }
}
```

The ExecuteScriptDomActionContext object has the following properties:

| Property | Type | Description |
|--|--|--|
| ContextId | IDMAObjectRef | The ID of the object for which the action was executed. Note: Currently, only DomInstance IDs can be specified. |
| ActionId | string | The ID of the action that triggered the script. |

If the executed script added script output to the engine object, that output will be returned in a DomActionInfo InfoData via the TraceData. See the example below, which shows how data can be added to the script and how it can be retrieved in the other script/application.

Action script code snippet:

```csharp
[AutomationEntryPoint(AutomationEntryPointType.Types.OnDomAction)]
public void OnDomActionMethod(IEngine engine, ExecuteScriptDomActionContext context)
{
   var returnValue = DoSomething();
   // Add the return value as script output
   engine.AddScriptOutput("ReturnValue", returnValue);
}
```

Calling script code snippet:

```csharp
// Execute action
domHelper.DomInstances.ExecuteAction(domInstance.ID, "do_something_action");
// Check if the TraceData contains info
var traceData = domHelper.DomInstances.GetTraceDataLastCall();
var info = traceData.InfoData.OfType<DomActionInfo>().FirstOrDefault();
if (info != null && info.InfoType == DomActionInfo.Type.ScriptOutput)
{
   var returnValue = info.Data["ReturnValue"];
   engine.GenerateInformation($"DOM script returned '{returnValue}'.");
}
```

##### Executing an action

An action can be executed by calling the ExecuteAction method on the DomInstance CrudHelperComponent of the DomHelper. The following IDs must be passed along: the ID of the DomInstance for which the action will be executed and the ID of the action that has to be executed.

```csharp
domHelper.DomInstances.ExecuteAction(domInstance.ID, "some_action_id");
```

The execute call will return TraceData when the action failed or when the condition was not met. If a non-existing DomInstance was specified, this TraceData will contain a ManagerStoreError with reason ObjectDidNotExist. In case of another error, a DomActionError will be returned with one of the following reasons:

| Reason | Description |
|--|--|
| Unknown | An unknown error has occurred. Check the logging for more information. |
| UnexpectedExceptionOccurred | An unexpected exception has occurred when executing an action. ExceptionMessage will contain the message of the exception. |
| ScriptReturnedErrors | A script has returned errors. ErrorData will contain a list of all the errors that were returned. |
| ActionDefinitionNotFound | The action that had to be executed could not be found by means of the IDMAObjectRef context ID. |
| ConditionNotMet | The condition that was specified was not met. InnerTraceData may contain additional TraceData explaining why the condition was not met. |

##### Conditions

When you define an action, you can specify the following types of conditions:

- StatusCondition
- ValidForStatusTransitionCondition

A StatusCondition is a type of condition that is met when a DomInstance has one of the defined statuses. The list of required statuses can be specified via the constructor or by adding them to the Statuses list property. When this type of condition is not met, no extra TraceData will be returned.

```csharp
var condition = new StatusCondition(new List<string> { "first_status" });
```

A ValidForStatusTransitionCondition is a type of condition that is met when a DomInstance is valid for a given status transition. The required transition ID must be assigned to the TransitionId property. When this type of condition is not met, extra TraceData will be returned via the InnerTraceData property of the DomActionError. This TraceData should contain an error of type DomStatusTransitionError.

```csharp
var condition = new ValidForStatusTransitionCondition("first_to_second_transition");
```

##### Defining buttons

A DomBehaviorDefinition contains a list of IDomButtonDefinitions. These can be used to define buttons to be shown in the UI.

Currently, it is only possible to define buttons to be shown for a DomInstance by using a DomInstanceButtonDefinition. These buttons can be linked to one or more actions that will be executed when the buttons are clicked. A DomInstanceButtonDefinition also has a condition that determines whether a button is shown or not. When no condition is specified, a button will by default be shown. A DomInstanceButtonDefinition has the following properties:

| Property | Type | Description |
|--|--|--|
| Id | string | The ID of the button. This ID must be unique for the DomBehaviorDefinition in question and can only contain lower-case characters. |
| Layout | DomButtonDefinitionLayout | Additional properties that define how the button will be displayed. See below. |
| VisibilityCondition | IDomInstanceCondition | The condition that defines when the button will be shown. |
| ActionDefinitionIds | List\<string> | The IDs of the actions that should be executed. |

The DomButtonDefinitionLayout class has the following properties:

| Property | Type | Description |
|--|--|--|
| Text | string | The text that will be displayed on the button. |
| Icon | string | The (optional) icon that will be displayed on the button. |
| ToolTip | string | The (optional) tooltip with more information about the button. |
| Order | int | The number assigned to the button that determines its place within a series of buttons. |

#### Virtual functions can now be included in element connectivity chains [ID_30944]

When creating a connectivity chain between parameters in an element, it is now possible to also select virtual functions to be included in that chain.

> [!NOTE]
> Virtual function alarms reside on the main element. When multiple virtual functions are defined in different element connectivity chains, the most severe RCA will be shown in the element RCA of the alarm.

#### Video thumbnails: Support for HLS streams [ID_30953]

Video thumbnails now also support HTTP Live Streaming (HLS). No plugins need to be installed.

Syntax:

```txt
#https://dma/videothumbnails/video.htm?type=HTML5-HLS&source=https://videoserver/stream.m3u8
```

> [!NOTE]
>
> - For more information on HLS, see <https://github.com/video-dev/hls.js/>.
> - All HLS resources must be delivered with CORS headers that permit GET requests.
> - If you access a video thumbnail player that is using HTTPS, then the media must also be served over HTTPS.
> - When the video starts automatically, in order to comply with the browser's autoplay policy, it will be muted until the user turns on the sound.

#### Logging: SLCloudEndpointManager.txt renamed to SLUMSEndpointManager.txt [ID_30974]

The SLCloudEndpointManager.txt log file has been renamed to SLUMSEndpointManager.txt.

#### SLWatchdog will now by default send an email message when an anomaly was detected [ID_30982]

In the MaintenanceSettings.xml file of a newly installed DataMiner Agent, the Watchdog.Email@active setting will now by default be set to true. In other words, on a newly installed DataMiner Agent, the SLWatchdog process will now by default send an email to the configured destination(s) whenever it detects an anomaly.

```xml
<MaintenanceSettings>
  ...
  <WatchDog>
    <EMail active="true">
      <Destination></Destination>
      <CCDestination></CCDestination>
      <BCCDestination></BCCDestination>
    </EMail>
  </WatchDog>
  ...
</MaintenanceSettings>
```

### DMS Security

#### BREAKING CHANGE: DataMiner installer will only enable ICMP and HTTP ports 80 & 8004 [ID_30913]

From now on, the DataMiner installer will by default only enable

- ICMP (ping) and
- HTTP ports 80 and 8004.

> [!NOTE]
> When you enable Telnet or the SNMP agent feature, from now on, you will have to manually create a firewall rule for the HTTP ports in question.

#### DataMiner Cube: Allow users to log in with a local user account even when external authentication via SAML is activated [ID_30981] [ID_31043]

By default, DataMiner Cube provides two methods to log in to a DataMiner Agent:

- Logging in “automatically” using your Windows domain credentials.
- Entering an explicit username/password combination.

When external authentication is activated on a DataMiner Agent, bypassing the external authentication provider by entering an explicit username/password combination is only allowed for the Administrator user. However, from now on, when using external authentication via SAML, bypassing the external authentication by entering a username/password combination will be allowed for any local DataMiner user account.

#### Azure AD application query support [ID_31059]

DataMiner now supports Azure AD application querying.

From now on, a DataMiner Agent will no longer need a user name and password to connect to Azure AD. An authentication secret will suffice.

For this feature to work, the following permissions must be set in Azure AD:

- Application permission for User.Read.All and GroupMember.Read.All
- Delegated permission for User.Read

### DMS Protocols

#### Enhanced view table filtering [ID_30809]

As from DataMiner feature release version 10.1.9, view tables containing a column with view options like “view=:x:y:z” or “view=a:b:c:z” allow that column to be filtered by means of a “VALUE=” filter (e.g. VALUE=5 == abc). From now on, these filters will also work when filtering on a column of a view table that refers to a column of another view table.

> [!NOTE]
> When a directview table links to a view table with remote columns (i.e. view=:x:y:z), it is not yet possible to filter on those columns.

### DMS Cube

#### Visual Overview: ListView component can now be used to list resources [ID_28723] [ID_30998]

The ListView component can now also be used to list resources. To do so, add a shape data field of type “Source” and set its value to “Resources”.

| Shape data field | Value |
|--|--|
| Component | ListView |
| Source | Resources |
| ComponentOptions | List of options, separated by pipe characters. For an overview of all possible component options, see [Component options](xref:Creating_a_list_view#component-options). |
| Columns | The list of columns that have to be displayed. Preferably, this should be configured by specifying the name of a saved column configuration, e.g. MyColumnConfig.<br> Saving a column configuration is possible via the right-click menu of the list header in DataMiner Cube. This right-click menu also allows you to load a column configuration.<br> If you do not specify this shape data field or leave it empty, all columns will be displayed. |
| Filter | Examples:<br> - Resource.Name\[string\]== 'Encoder'<br> - Resource.Name contains 'res'<br> - Resource.Name notContains 'res'<br> - Resource.ID\[Guid\] == fad6a6dd-ca3a-4b6f-9ca7-b68fd2071786<br> - Resource.MainDVEDmaID == 113<br> - Resource.PoolGUIDs contains<br>0fb47f51-ad81-47f2-9e69-3d9477bdc961<br> - Resource.MaxConcurrency != 1<br> - Resource.PropertiesDict.Location\[string\] == '3'<br> - Resource.Name\[string\] notContains 'RS' AND Resource.Name\[string\] notContains 'RT' AND Resource.Name\[string\] notContains 'ExposeFlow' <br>For more information on list view filters, see [List view filters](xref:Creating_a_list_view#list-view-filters). |

> [!NOTE]
> The IDOfSelection session variable contains a list of the IDs or GUIDs of the selected items, separated by pipe characters.

#### Alarm templates: Conditions based on service impact [ID_30691] [ID_30763]

When editing an alarm template, it is now possible to configure alarm template conditions based on service impact.

#### Logging now contains more information regarding system performance [ID_30769]

The Cube log files will now contain more information regarding system performance.

> [!NOTE]
> A new checkbox at the top of System Center’s Logging page will allow you to show or hide these System Performance Indicator (SPI) log entries.

#### Logging: New log file 'Sharing Manager' [ID_30826]

The Logging module now also allows you to access the Sharing Manager log file.

#### DataMiner Cube - Router Control: 'Direct take' mode [ID_30865]

When configuring a matrix in the Router Control module, you can now set it to either “preset mode” (i.e. the default mode) or “direct take mode”.

- In preset mode, you need to click the *Connect* button to create or delete a crosspoint between an input and an output.
- In direct take mode, you don’t need to click the *Connect* button to create or delete a crosspoint between an input and an output. When you select an input and an output, they will automatically be connected or disconnected.

> [!NOTE]
> When you use direct take mode in combination with the “Use output-first workflow” option
>
> - selecting an output will not cause crosspoints to be created or deleted, and
> - input selections will only be cleared when you select another output.

#### Sidebar: 'Advanced search' improvements [ID_30885]

Up to now, the advanced search pane was only added to the sidebar after you entered a search string in the search box in the middle of the Cube header bar and then clicked the “Advanced search for” option at the bottom of the suggestions list. From now on, you can directly open the advanced search pane by clicking the ellipsis button (“...”) in the sidebar and selecting the *Search* button.

In addition, there is now a search box at the top of the advanced search pane, so you can search from directly in the pane.

#### DataMiner Agent will no longer be selected by default when creating a new element on an DataMiner System with multiple agents [ID_30889]

When you created an element on a DataMiner System with multiple agents, up to now, the DMA to which you were connected would by default be selected in the DMA selection box. To prevent users from all creating new elements on the same agent, from now on, whenever there are multiple agents in the DataMiner System, no agent will be selected by default.

> [!NOTE]
> When you duplicate an element, the DMA selection box will by default be set to the same DMA as the original element.

#### Visual Overview: Edge/WebView2 browser engine [ID_30940]

In DataMiner Cube, up to now, embedded webpages could be displayed using either Chromium or Microsoft Internet Explorer. From now on, it is also possible to use Microsoft Edge (WebView2).

Using this new Edge browser engine offers a number of advantages:

- The web content is rendered directly to the graphics card.
- The browser engine automatically receives updates via Windows Update, independent of DataMiner or Cube version.
- Proprietary codecs such as H.264 and AAC are supported.

To set this browser engine as the system default for all users, go to *System Center \> System Settings \> Plugins*, and set the *Web browser Engine* option to “Edge”.

If you want a shape to display a webpage using the Edge web browser regardless of Cube’s default browser engine setting, add a shape data field of type *Options* to the shape containing the web browser control, and set its value to “UseEdge”.

> [!NOTE]
>
> - Currently, the Edge web browser engine cannot be used in DataMiner web apps like Ticketing, Dashboards, etc.
> - The WebView2 Runtime will automatically be installed when using Office 365 Apps. It will also come pre-installed with Windows 11. It will not be included in DataMiner upgrade packages.

#### Sidebar: Pinning and unpinning sidebar items [ID_30963]

It is now possible to pin and unpin items in the sidebar.

- To pin an item, click the ellipsis button (“...”), and then click the item you want to pin to the sidebar.
- To unpin an item, right-click the item in the sidebar, and click *Unpin*.

> [!NOTE]
> One of the items you can pin after clicking the ellipsis button (“...”) is the “Overview” button. Clicking this button after it has been pinned will open a card showing the root view (Below this view \> All).

#### Visual Overview: Setting the background color of a static shape using a shape data field of type 'BackgroundColor' [ID_30964]

Using a shape data field of type *BackgroundColor* it is now possible to set the background color of a static shape, i.e. a shape that is not linked to an element, a service or a view.

| Shape data field | Value |
|--|--|
| BackgroundColor  | \<color> |

The \<color> value in the example above can be specified as follows:

- An HTML color code (e.g. #FF102030)
- An RGB color code (e.g. 40,50,60)
- A standard color name (e.g. magenta)
- A color placeholder referring to one of the configured DataMiner alarm colors (e.g. \[color:severity=minor\])
- A placeholder referring to a variable containing a color value (e.g. \[PageVar:MyColorSessionVar\])

> [!NOTE]
>
> - If you specified a valid color or if the placeholder resolves correctly, the color you specified will overrule the shape’s default background color. Note that if blinking was enabled, it will be disabled.
> - If you specify a custom BackgroundColor, shape transparency will work as before.

#### System Center - Analytics config: New setting 'Maximum group size' [ID_30993] [ID_31093]

In the *System settings \> Analytics config* section of *System Center*, a new setting has been added for automatic incident tracking. The *Maximum group size* setting will now allow you to limit the size of the alarm groups.

When an alarm group reaches the maximum size specified in this setting, a new group will be created with all remaining alarms that belong to the same incident.

Default value: 1000

> [!NOTE]
> In the *System settings \> Analytics config* section of *System Center*, the setting names have been adjusted to improve consistency. “Minimal” has been replaced with “Minimum” and “Maximal” has been replaced with “Maximum”.

### DMS Reports & Dashboards

#### Dashboards app - GQI: New filter node option 'Return no rows when feed is empty' [ID_29557]

When, in the Data tab, you add a filter node to a GQI query, a new option named “Return no rows when feed is empty” will allow you to specify what should be returned when the filter yields no rows.

- When you enable this option, an empty table will be returned when the filter yields no rows.
- When you disable this option, the entire table (i.e. all rows) will be returned when the filter yields no rows.

#### Dashboards app - State component: Enhanced scrolling behavior when Layout flow is set to 'Columns' [ID_30765]

When the *Layout flow* setting of a State component is set to “Columns” and there is either a single group or no grouping at all, from now on, the states will always be displayed at full width.

#### Dashboards app - Node edge graph component: New 'Bidirectional configuration' option [ID_30910]

When configuring a node edge graph component, you can now use the *Bidirectional configuration* option to specify how you want multiple edges between two nodes to be mapped.

#### Dashboards app - Node edge graph component: 'Filtering & highlighting' section [ID_31065]

In the *Layout* pane of a node-edge component, the *Column filters* section has been renamed to *Filtering & highlighting* and now contains the following options:

| Option | Description |
|--|--|
| Conditional coloring | Previously named *Column filters*, this option allows you to specify color filters for specific columns, so that these can be used for highlighting in case analytical coloring is used. |
| Highlight | When this option is enabled, the nodes that match the filter will be highlighted. Default: Enabled |
| Opacity | When the *Highlight* option is enabled, this option will allow you to set the level of transparency of the nodes and edges that do not match the filter. Note: When you disable the *Highlight* option, the nodes that do not match the filter will no longer be displayed and the remaining nodes will be reorganized. |
| Highlight/Show entire path | When this option is enabled, not only the nodes matching the filter will be highlighted, but also the entire tree structure of which they are a part (from root to leaves). |

> [!NOTE]
> The filtering options mentioned above require the *Query filter* component, which is currently still in [soft launch](xref:SoftLaunchOptions).

### DMS Service & Resource Management

#### Resource Manager: Permission checks [ID_30895]

The following messages now have server-side permission checks:

| Operation | Required flags | Helper calls |
|--|--|--|
| Read calls of Resources and ResourcePools | ResManResourceUI | GetResources<br> GetEligibleResources<br> GetResourceUsage<br> GetAvailableResources<br> GetResourcePools |
| Adding Resources or ResourcePools | ResManResourceAdd | AddOrUpdateResources<br> AddOrUpdateResourcePools |
| Updating the status of a Resource | ResManResourceEditStatus | AddOrUpdateResources |
| Updating a Resource (unless only the status is updated) or updating a ResourcePool | ResManResourceEditOther | AddOrUpdateResources<br> AddOrUpdateResourcePools |
| Removing a Resource or ResourcePool | ResManResourceDelete | RemoveResources<br> RemoveResourcePools |
| Read calls of ReservationInstances and ReservationDefinitions | ResManReservationUITimeline | GetReservationInstances<br> GetReservationDefinitions |
| Adding ReservationInstances or ReservationDefinitions | ResManReservationAdd | AddOrUpdateReservation<br>Instances<br> AddOrUpdateReservation<br>Definitions |
| Editing ReservationInstances or ReservationDefinitions | ResManReservationEdit | AddOrUpdateReservation<br>Instances<br> AddOrUpdateReservation<br>Definitions<br> (Safely)UpdateReservation<br>InstanceProperties<br> (Safely)UpdateReservation<br>DefinitionProperties |
| Removing ReservationInstances or ReservationDefinitions | ResManReservationDelete | RemoveReservationInstances<br> RemoveReservationDefinitions |

All operations will now return a ResourceManagerErrorData with reason NotAllowed if the user does not have the correct permissions.

#### RemoveResources: New ignoreCanceledReservations flag [ID_30936]

When deleting resources by means of a RemoveResources call, it is now possible to indicate whether errors should be generated when a resource is being used in canceled reservations.

If you set the ignoreCanceledReservations flag to true, no errors will be generated when deleting a resource that is being used in canceled reservations.

```csharp
Resource[] RemoveResources(Resource[] resources, bool ignorePassedReservations, bool ignoreCanceledReservations);
```

### DMS tools

#### SLLogCollector: Option 'Upload to Skyline' removed [ID_31032]

Up to now, when an internet connection was available on the DMA, the SLLogCollector tool provided an option to upload the collected information to Skyline via email. This “Upload to Skyline” option has now been removed.

## Changes

### Enhancements

#### SLLogCollector: Command line support [ID_26293]

The SLLogCollector tool now supports the following command line options:

| Option | Function |
|--|--|
| -c, --console | Use the SLLogCollector console. |
| -h, -?, --help | List syntax and available options. |
| -f, --folder=VALUE | Specify the folder in which the zipped log files will be stored. Default: C:\\Skyline_Data\\ |
| -d, --dumps=VALUE  | Specify the comma-separated list of processes from which dumps should be taken (IDs or names). |
| -m, --memory=VALUE | Take an extra dump as soon as the process uses the specified amount of memory (in MB). |

#### Security enhancements [ID_30674] [ID_31081]

A number of security enhancements have been made.

#### StandAloneBPAExecutor: New command line option to save test result to file [ID_27776]

The StandAloneBpaExecutor tool, which can be found in the C:\\Skyline DataMiner\\Tools folder of a DMA, can be used to execute BPA (Best Practice Analysis) tests.

When using this tool to run a test from a command line, it is now possible to have the test result stored in a JSON file.

| Option | Function |
|--|--|
| -f “PATH/TO/FILE.json”<br> or<br> -file “PATH/TO/FILE.json” | Specify the file in which the test results will be stored. |

#### DataMiner Cube - Visual Overview: Enhanced child shape loading indicator [ID_30151]

A number of enhancements have been made with regard to the loading indicator that is shown while automatically generated child shapes are being loaded.

#### Web apps: Enhanced visualization of warnings and errors [ID_30397]

A number of enhancements have been made with regard to the visualization of warnings and errors.

#### No longer possible to launch a system-wide upgrade procedure when one agent fails to upload the upgrade package [ID_30511]

Up to now, when an agent in a DataMiner System failed to upload a DataMiner upgrade package, it would still be possible to launch the system-wide upgrade procedure. From now on, as soon as one of the agents in a DataMiner System fails to upload an upgrade package, it will not be possible to launch a system-wide upgrade procedure.

#### Dashboards app - GQI: Columns will now be referred to by their unique ID instead of by their display name [ID_30568] [ID_30870] [ID_30970]

In GQI queries, up to now, columns would be identified by their display name. From now on, they will be identified by a unique ID instead.

Each time a user opens a dashboard, any existing GQI queries in table or node edge components on that dashboard referring to columns by display name will be adapted on the fly. When such a dashboard is opened by a user who is allowed to edit dashboards, the adaptation will be saved so that the dashboard will no longer have to be adapted the next time it is opened.

#### SLElement: Enhanced service impact calculation [ID_30648]

A number of enhancements have been made to the way in which SLElement calculates the service impact of an alarm.

#### DataMiner Cube - Alarm grouping: Enhanced performance when updating large alarm groups and when grouping alarms using correlation rules [ID_30670]

Due to a number of enhancements, overall performance has increased when updating large alarm groups and when grouping alarms using correlation rules.

#### Enhanced performance when enabling virtual functions with monitored parent elements [ID_30673]

Due to a number of enhancements, overall performance has increased when enabling virtual functions with monitored parent elements.

#### SAML authentication enhancements [ID_30749]

A number of enhancements have been made with regard to SAML authentication.

Also, DataMiner now supports SAML authentication via Okta.

#### Enhanced performance when determining the virtual impact of an alarm [ID_30766]

Overall performance has increased when determining the virtual function impact of an alarm.

Also, a number of issues have been fixed with regard to displaying statuses of virtual function alarms, exporting alarms to DVE child elements, masking of external alarms and updating virtual function states when alarms are cleared.

#### DataMiner Cube - Alarm Console: Availability of 'Count alarms' button now depends on the alarm filter that was specified [ID_30810]

When, in the Alarm Console, you add a new history or sliding window tab page, you can add a filter by clicking *Apply filter*. After configuring that filter, you can click *Count alarms* to see how many alarms will be retrieved when that filter is applied. However, up to now, when the filter contained one of the following items, it would not be possible to count the number of alarms that matched the filter:

- ElementType
- InterfaceImpact
- ParameterDescription
- Protocol
- ServiceImpact
- ViewID
- ViewImpact
- ViewName
- VirtualFunctionID
- VirtualFunctionImpact
- VirtualFunctionName

From now on, when the alarm filter contains one of the above-mentioned items, the *Count alarms* button will not be available.

#### Automation: Enhanced performance when retrieving large amounts of data via managed DataMiner modules [ID_30816]

Due to a number of enhancements, overall performance has increased when retrieving large amounts of data via managed DataMiner modules like SLManagedAutomation or SLManagedScripting.

#### Automation scripts: SLAnalyticsTypes.dll added to the list of default DLL references [ID_30821]

All Automation scripts will now by default have a reference to the SLAnalyticsTypes.dll file.

#### Improved performance when writing and deleting data on Cassandra clusters [ID_30860]

Performance has improved for all write and delete queries on Cassandra clusters. This applies to all data handled by the SLDataGateway process, including alarms, trending, element data, etc.

#### Deprecated web pages have been removed [ID_30877]

The following web pages have been removed as they are related to deprecated features:

```txt
http://<DMA>/Tools/CustomerLogoCheck.asp
http://<DMA>/Weather/VerifiyWeathericon.html
http://<DMA>/Weather/WeatherIcon.aspx
```

#### DataMiner Cube - Aggregation: Enhanced performance [ID_30917]

Due to a number of enhancements, overall performance of the Aggregation module has increased.

#### Response that caused an exception will now be added to the text of the exception [ID_30919]

When an exception is thrown, from now on, the response that caused the exception will be added to the text of the exception.

#### SLDataGateway: Enhanced startup routine [ID_30934]

A number of enhancements will now allow the SLDataGateway process to handle Cassandra exceptions and file offload initialization errors more efficiently, which may prevent startup issues.

#### DataMiner Cube - Router Control: Enhanced highlighting of IO buttons [ID_30949]

A number of enhancements have been made to the Router Control app with regard to IO button highlighting.

- When you connected an input to an output with multiple connections to other inputs and the “output first workflow” option was enabled, in some cases, those other connected inputs would no longer be highlighted. From now on, inputs connected to an output will no longer lose their highlighting when you connect a new input to that same output.
- When you selected an input of a matrix that did not have the “output first workflow” option enabled, up to now, the connected outputs would not be highlighted. From now on, these will be highlighted.

#### DataMiner backup: User-generated dashboards now included in 'Configuration Backup' & 'Configuration Backup without Database' [ID_30957]

From now on, user-generated dashboards will by default be included in the following types of backups:

- Configuration Backup
- Configuration Backup without Database

#### Ticketing: FieldName of TicketFieldDescriptor can no longer contain certain characters [ID_30962]

From now on, the FieldName of a TicketFieldDescriptor has to meet the following requirements:

- It cannot start with an underscore character ("\_").
- It cannot contain any of the following characters:

  - . (period)
  - \# (number sign)
  - \* (asterisk)
  - , (comma)
  - " (double quote)
  - ' (single quote)

#### DataMiner backup: Process Automation data now included in 'Full Backup' [ID_30999]

From now on, Process Automation data will be included in the following types of backups:

- Full backup
- Custom backup with “Create a backup of the database” and “Include Process Automation data in backup” options enabled
- Backup via the StandaloneElasticBackup tool

#### Security: Enhanced import of users and groups from Azure AD [ID_31038]

Up to now, a maximum of 100 users or groups could be imported from Azure AD. From now on, the number of users or groups that can be imported from Azure AD is no longer limited.

#### DataMiner Cube - System Center: Enhanced 'Limited administrator' tooltip [ID_31042]

When, in the *Users/Groups* section of *System Center*, you hover over the *Modules \> System configuration \> Security \> Specific \> Limited administrator* permission, a tooltip gives you more information about that permission. That tooltip now contains the following updated text:

```txt
* Read-only access on all groups
* Read-only access to users in your groups
* Create new DataMiner users
* Editing your own user properties
```

#### DataMiner upgrade packages will now include Microsoft .NET Framework 4.8 [ID_31120]

From now on, DataMiner upgrade packages will include Microsoft .NET Framework 4.8, which will be installed automatically on servers on which it has not yet been installed earlier.

> [!NOTE]
> If Microsoft .NET Framework 4.8 had to be installed during the DataMiner upgrade, the DataMiner Agent will automatically be rebooted.

### Fixes

#### Problem when starting Kibana after restoring an Elasticsearch backup [ID_29943]

After restoring an Elasticsearch backup that was taken with the StandaloneElasticBackup tool, in some cases, it would no longer be possible to start Kibana when Elasticsearch had security enabled.

#### Service & Resource Management: Property updates would incorrectly be overwritten by status updates [ID_30642]

When the properties of a ReservationInstance were updated in an asynchronous event script while the end actions were running, in some cases, the end actions could overwrite the updated properties, causing the event script’s property update to fail and throw a “PropertiesAlreadyModified” exception.

#### Dashboards app - Node edge graphs: Parameter values in node tooltips would incorrectly show 'not initialized' [ID_30694]

When you hovered over a node, parameter values shown in the node tooltip would incorrectly be set to “not initialized”.

#### Elasticsearch installations would fail on systems on which Cassandra was installed remotely [ID_30731]

On systems on which Cassandra was installed remotely, in some cases, Elasticsearch installations would fail.

#### Service & Resource Management: Protocols generated for contributing services could cause errors to occur in SLScripting [ID_30772]

In some cases, protocols generated for contributing services could cause errors to occur in SLScripting.

#### DataMiner Cube - Settings: User group settings not taken into account when applying regional settings [ID_30813]

When starting up, up to now, Cube would load the regional settings before loading the user group settings. As a result, it would only take into account the user settings when applying the regional settings. From now on, Cube will also take into account the user group settings when applying the regional settings.

#### SLSNMPManager: Problem when using MultipleGetBulk to poll a table containing only a single row [ID_30815]

When MultipleGetBulk was used to poll a table that contained only a single row and the response from the device was cut because it exceeded the maximum package size, in some cases, the algorithm would get stuck into an infinite loop.

#### DataMiner Cube - Visual Overview: Child shapes representing alarms would incorrectly appear on a white background [ID_30820]

When generating child shapes that represent alarms, up to now, those child shapes would always appear on a white background, even when the Cube theme was set to e.g. Skyline Black.

From now on, generated child shapes that represent alarms will appear on a transparent background instead.

#### Confusing 'Already authenticated error' would be thrown when an error occurred during an authentication process [ID_30827]

When an error occurred during an authentication process, in some cases, a confusing “Already authenticated” exception would be thrown instead of the actual error message. From now on, the actual error message will be thrown.

#### DataMiner Cube: Alarm counter in alarm storm warning did incorrectly not decrease when alarms were cleared [ID_30836]

When, during an alarm storm, you hover the mouse pointer over the alarm storm warning, a tooltip appears, showing you which alarms are causing the storm and the number of alarms per parameter. Up to now, when one of those alarms got cleared, the number of alarms shown in the tooltip would incorrectly not decrease.

#### Compiled QAction DLL files would incorrectly not be deleted from the ProtocolScripts folder when a protocol was deleted [ID_30841]

When a protocol was deleted, up to now, the compiled QAction DLL files would incorrectly not get deleted from the C:\\Skyline DataMiner\\ProtocolScripts folder.

#### Dashboards app - Node-edge graph component: Problem with color filtering [ID_30851]

In a node-edge graph component, in some cases, color filtering would not be applied correctly for profile parameters. The nodes and/or edges would not be colored even when the values matched the filter.

#### SLElement: ParameterThread error [ID_30855]

In some cases, a ParameterThread error could occur in SLElement.

#### Interactive Automation scripts: Value returned by the client would incorrectly be considered as an invalid file path selected in a file selector block [ID_30879]

When, in an interactive Automation script, a file selector block was defined after another type of input block (e.g. a checkbox), in some cases, the input block value returned by the client would incorrectly be considered as an invalid file path selected in the file selector. As a result, an “Invalid Data” error would be thrown.

#### DataMiner Cube - Alarm Console: Incorrect notices like '!! Unknown \<Type> R!AD for parameter xxx' [ID_30884]

In some rare cases, notices like “!! Unknown \<Type> RE!D for parameter 123” would incorrectly appear in the Alarm Console.

#### DataMiner Cube - Alarm Console: 'Automatic incident tracking' option would no longer be visible in the hamburger menu [ID_30890]

In some cases, the “Automatic incident tracking” option would no longer be visible in the hamburger menu of the Alarm Console.

#### Protocols: Double values with leading zeros would not be displayed correctly when using scientific notation [ID_30892]

In some cases, double values with leading zeros would not be displayed correctly when using scientific notation.

#### Protocols: QActions and their compiled versions could get linked incorrectly [ID_30896]

In some rare cases, errors occurring in SLScripting or SLProtocol could cause QActions and their compiled versions to be linked incorrectly.

#### SLReset tool would incorrectly stop deleting files when it encountered a locked file [ID_30906]

In some cases, the SLReset tool would incorrectly stop deleting files when it encountered a locked file.

#### DataMiner Cube - View cards: Aggregation page would incorrectly be loaded as soon as a view card was opened [ID_30907]

In some cases, the Aggregation page of a view card would incorrectly be loaded as soon as you opened the card. From now on, the Aggregation page of a view will only be loaded when you select that page.

#### DataMiner Cube - Service definitions: Selection boxes would incorrectly contain raw values instead of display values [ID_30916]

When you configured a service definition, in some cases, selection boxes would incorrectly contain raw values instead of display values.

#### Problem when disabling a virtual function and then enabling it again [ID_30918]

When you disabled a virtual function and then enabled it again, in some rare cases, it would incorrectly disappear from the system.

#### DataMiner Cube - Visual Overview: Problems when updating Children shapes [ID_30924]

A number of problems with Children shape updates have been fixed:

- When a Children shape was sorted on alarm severity, in some cases, updates to the alarm level of the shape would no longer be processed and the sorting would not be updated.
- When a shape no longer matched a filter, in some cases, it would not be removed from the list of generated shapes.
- In some cases, the (configurable) maximum amount of child shapes would no longer be applied when updates were received.

#### Problem with SLDataMiner when deleting a service or a redundancy group [ID_30925]

In some cases, an error could occur in SLDataMiner when a service or a redundancy group was deleted.

#### Automation: Problem with ScriptEntry.GetHashCode method [ID_30939]

In some cases, calling the ScriptEntry.GetHashCode method could cause a NullReference-Exception to be thrown.

#### Problem with SLAutomation when a Timespan.MaxValue timeout had been defined [ID_30946]

In some cases, SLAutomation would throw an ArgumentOutOfRangeException when a Timespan.MaxValue timeout had been defined.

#### Legacy Reporter: Problem with SLASPConnection when requesting trend statistics [ID_30966]

In some cases, an error could occur in SLASPConnection when requesting trend statistics (Minimum/Maximum/Average).

#### Element logging would no longer get properly stored after an element restart [ID_30967]

After an element restart, in some cases, logging would no longer be properly stored in the log file of that element. The log file of an element could get emptied when that element was restarted.

#### DataMinerCube.exe would not shut down when you closed a Cube desktop app [ID_30968] [ID_31036]

When you had opened a Cube desktop app without using the start window and had connected it to a DataMiner System with an Elasticsearch database, in some cases, the DataMinerCube.exe process would incorrectly not shut down when you closed the Cube app.

#### Dashboards app - Node-edge graph component: Custom node positions would not get applied when the user did not have edit permissions [ID_30976]

When, in a node-edge graph component, custom node positions had been defined, in some cases, those would not get applied when the user did not have edit permissions.

#### Alarms in tables that were part of multiple relation paths for different DVEs would not get re-evaluated when a DVE was created [ID_30979]

In some cases, an alarm in a table that was part of multiple relation paths would not get re-evaluated when a DVE in one of those paths exported that alarm. As a result, the alarm would not get exported to the DVE child element, causing the element state to become incorrect.

#### DataMiner Cube - Trending: Problem when exporting a trend graph to a CSV file [ID_30987]

In some cases, an exception could be thrown when you tried to export a trend graph to a CSV file.

#### DVE element information would no longer be written to the database [ID_31004]

In some cases, DVE element information would no longer be written to the database due to a NullReferenceException in SLDBConnection.

#### Failover: Resources.xml would constantly be updated during a Failover switch [ID_31006]

During a Failover switch, in some cases, the Resources.xml file would constantly be updated.

#### DataMiner Cube - Visual Overview: Problem with navigation buttons on visual pages after clicking a card’s Back button [ID_31012]

When you clicked a card’s Back button, in some cases, the navigation buttons on the card’s visual pages could start to behave incorrectly.

#### Memory usage of SLAnalytics would temporary increase due to alarm focus events not getting cleared from the cache [ID_31025]

In some rare cases, overall memory usage of the SLAnalytics process would temporarily increase due to alarm focus events not getting cleared from the cache.

#### Enabled soft-launch options would incorrectly be disabled [ID_31033]

When no SoftLaunchOptions.xml file was found in the C:\\Skyline DataMiner\\ root directory, soft-launch options that were enabled by default (e.g. the new average trending feature) would incorrectly be disabled.

#### Interactive Automation scripts: Problem with file upload components [ID_31064]

After multiple updates had occurred in an interactive Automation script, in some cases, a file upload component could end up in an invalid state and lose all information about the uploaded files.

#### DataMiner Cube: Asset Manager app failed to initialize [ID_31072]

In some cases, the Asset Manager app would fail to initialize.

#### Run-time errors in ParameterThread when defining a column parameter in the functions.xml [ID_31074]

In some cases, run-time errors could occur in the ParameterThread when defining a column parameter in the functions.xml.

#### Web Services API v1: Port details missing from result of GetElementConfiguration method [ID_31075]

In some cases, the result of a GetElementConfiguration method would be missing port details.

#### DataMiner Cube: Problem when adding/deleting DataMiner Agent to/from a DMS [ID_31078]

In the *Agents* section of *System Center*, up to now, users with *Agents > Add* permission but without *Agents > Add DMA to cluster* permission seemed to able to add a DMA to a DMS. However, after *System Center* had been refreshed, the added DMA would not be listed. Also, users with *Agents > Delete* permission but without *Agents > Delete DMA to cluster* permission seemed to able to delete a DMA to a DMS. However, after *System Center* had been refreshed, the deleted DMA would still be listed.

From now on, users with only *Agents > Add* permission or *Agents > Delete* permission will be able to correctly add or delete DMAs from a DMS.

#### Dashboards app - GQI: Problem when migrating queries that contain joins [ID_31080]

Each time the GQI version gets upgraded, all GQI queries are migrated to the new version. In some cases, the migration of a GQI query could fail when that query contained joins.

#### Cassandra cluster: No SLA table would be created on startup or on creation of an SLA [ID_31092]

On a Cassandra cluster, in some cases, no SLA table would be created on startup or on creation of an SLA.

#### Reporter: Problem when retrieving an alarm history on a system with a Cassandra cluster [ID_31096]

When, on a system with a Cassandra cluster, you used Reporter to retrieve the alarm history of an element, in some cases, the query would not return any results.

#### Failover: Resources.xml would incorrectly not be synchronized on offline agent [ID_31117]

When a new Failover configuration was created, in some cases, the Resources.xml file would incorrectly not be synchronized on the offline agent.

#### Dashboards app: GQI queries in PDF reports sent via an interactive Automation script would not be migrated correctly [ID_31127]

When a PDF report of a dashboard containing GQI queries was generated before being sent by email via an interactive Automation script, in some cases, the GQI queries would not be migrated correctly.

#### Table row exports for DVEs and virtual functions would trigger updates to be sent when no client applications were connected [ID_31156]

In some cases, table row exports for DVEs and virtual functions would trigger updates to be sent, even when no client applications were connected.

#### Failover: Full synchronization incorrectly not run at setup [ID_31296]

When a Failover system was set up, in some cases, a full synchronization would incorrectly not be run.

## Addendum CU1

### CU1 fixes

#### Problem when the \<NatsCredsFile> tag was removed from SLCloud.xml after running SLReset [ID_31379]

After running SLReset, in some cases, an error could occur when the \<NatsCredsFile> tag was incorrectly removed from the SLCloud.xml file.

#### Web apps: Problem with SAML authentication [ID_31434]

On DataMiner Agents that had SAML authentication configured, it would no longer be possible to log in and access any of the web apps (e.g. Monitoring, Dashboards, Ticketing, Jobs, etc.) or the web services API.
