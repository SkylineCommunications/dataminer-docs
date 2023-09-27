---
uid: General_Main_Release_10.2.0_new_features_2
---

# General Main Release 10.2.0 - New features (part 2)

> [!NOTE]
> For known issues with this version, refer to [Known issues](xref:Known_issues).

> [!NOTE]
> A DataMiner Installer v10.2 is available on [DataMiner Dojo](https://community.dataminer.services/download/dataminer-installer-v10-2/).
>
> - For 64-bit systems only.
> - No longer contains the necessary files to install MySQL.
> - Unattended cluster installation is not supported.
> - On Windows Server 2022, an “Internal server error” is thrown after installation. Workaround:
>   - Go to <https://www.iis.net/downloads/microsoft/url-rewrite>.
>   - Download and install the URL rewrite module.
>   - Go to <http://localhost/root> and verify whether the root page is shown.

### DMS core functionality

#### SLSpectrum: Refactoring of code used to play back spectrum recordings \[ID_29785\]

In SLSpectrum, the code used to play back spectrum recordings has been refactored.

Also, the SpectrumManagerHelper now allows you to play, pause, slow-forward and fast-forward a recording. See the following table.

| Action       | Instruction                                                            |
|--------------|------------------------------------------------------------------------|
| Pause        | Helper.SetSpectrumRecordingSpeed(0.0)                                  |
| Play         | Helper.SetSpectrumRecordingSpeed(1.0)                                  |
| Slow-forward | Helper.SetSpectrumRecordingSpeed(0.5)<br> (any number between 0 and 1) |
| Fast-forward | Helper.SetSpectrumRecordingSpeed(2.0)<br> (any number greater than 1)  |

#### Improved SLLog stack cleaning behavior \[ID_29989\]

The way the SLLog process cleans the log file stack has been improved. SLLog now has a thread that iterates over the different log file buffers and that logs a number of lines from the buffers to the log files. The maximum number of lines depends on the *LinesPerIteration* setting in *LogSettings.xml* (default: 100).

In addition, SLLog now monitors its own memory usage, and whenever the memory usage exceeds a specific threshold, it will clean up the largest stack that has not yet been written to a file. This threshold is determined by the *SLLogMaxMemorysetting* in *LogSettings.xml* (default: 500 MB). For this setting, you can only specify integer numbers, which correspond with a number of megabytes.

*LogSettings.xml* can for instance be configured as follows:

```xml
<Log xmlns="http://www.skyline.be/config/log">
   <File name="">
      <Levels info="0" error="0" debug="0" />
   </File>
   <General>
      <LinesPerIteration>50</LinesPerIteration>
      <SLLogMaxMemory>100</SLLogMaxMemory>
   </General>
</Log>
```

#### DataMiner Object Model: DomInstanceNameDefinition \[ID_30226\]

A ModuleSettings object now has a DomInstanceNameDefinition property, which allows you to define how the name property of a DomInstance should be filled in automatically each time the instance is saved.

The DomInstanceNameDefinition class can contain a list of IDomInstanceConcatenationItems, which, placed in a specific order, will define the DomInstance name.

Currently, there are two types of concatenation items:

- **StaticValueConcatenationItem**

    Used to define a fixed string to be inserted into the DomInstance name.     The string value should be assigned to the ‘Value’ property.

- **FieldValueConcatenationItem**

    Used to define a FieldValue (defined on a DomInstance) to be inserted into the DomInstance name.     The FieldDescriptorID of the FieldValue should be assigned to the FieldDescriptorId property. When no FieldValue can be found with the given FieldDescriptorId, an empty string will be inserted instead.     A FieldValue can contain a variety of non-string data types. See below for more information on how these types will be converted to strings:

    | FieldValue type | Example of how this type will be converted to a string |
    |-------------------|--------------------------------------------------------|
    | Guid              | ‘bc77dcb5-b523-4722-aaaa-7d99a5c82304’                 |
    | double            | ‘124.65’                                               |
    | long/int          | ‘15254876’                                             |
    | DateTime          | ‘1997-04-10T14:40:14.0000000Z’ (ISO8601)               |
    | TimeSpan          | ‘13:28:18.9187335’                                     |
    | bool              | ‘True’                                                 |
    | GenericEnumEntry  | ‘SomeDisplayValue’ (the DisplayValue will be used)     |

##### Example

In the following example, we want to create DomInstances for switches in a network and created FieldDescriptors for the following data:

- Switch brand
- Switch model
- Management IP
- Year of installation

The names of the DomInstances, which will each represent a switch, have to contain all this information (example: “Cisco C9500-24Y4C - 10.11.5.87 (2021)”).

To achieve this, we could define the following in the ModuleSettings object, assuming that the FieldDescriptorIDs have already been defined elsewhere in the script/code:

```csharp
var settings = new ModuleSettings()
{
    ModuleId = "moduleid",
    DomManagerSettings = new DomManagerSettings()
    {
        DomInstanceNameDefinition = new DomInstanceNameDefinition()
        {
            ConcatenationItems = new List<IDomInstanceConcatenationItem>()
            {
                new FieldValueConcatenationItem(switchBrandDescriptorId),
                new StaticValueConcatenationItem(" "),
                new FieldValueConcatenationItem(switchModelDescriptorId),
                new StaticValueConcatenationItem(" - "),
                new FieldValueConcatenationItem(managementIpDescriptorId),
                new StaticValueConcatenationItem(" ("),
                new FieldValueConcatenationItem(yearDescriptorId),
                new StaticValueConcatenationItem(")")
            }
        }
    }
};
```

> [!NOTE]
>
> - When no concatenation is defined (i.e. when DomInstanceNameDefinition is empty or null), the ID of the DomInstance will be used as DomInstance name.
> - When multiple values are defined for the same FieldDescriptor (i.e. when there are multiple Sections for the same SectionDefinition), the first value will be used for the concatenation.
> - The DomInstanceNameDefinition can be overridden by a DomDefinition on the ModuleSettingsOverrides property.

#### DataMiner Object Model: DomBehaviorDefinition object & status system \[ID_30443\]

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

2. Link a DomDefinition to the DomBehaviorDefinition.

3. Create DomInstances using the appropriate statuses and fields.

Configuration:

- To configure the statuses, for each status add a DomStatus object to the Statuses list property of the DomBehaviorDefinition. A DomStatus has the following properties:

    | Property  | Type   | Explanation                                                                                  |
    |-------------|--------|----------------------------------------------------------------------------------------------|
    | Id          | string | The ID of the status, consisting of lowercase characters only. Example: “initial_status” |
    | DisplayName | string | The display name of the status. Example: “Initial”                                       |

    > [!NOTE]
    >
    > - The Statuses collection should not contain any DomStatus objects with identical IDs.
    > - InitialStatusId must contain the ID of an existing status. When a DomInstance is created and no status is assigned to it, it will automatically be assigned the status specified in InitialStatusId.

- To configure the allowed status transitions, for each transition add a DomStatusTransition object to the Transitions list property of the DomBehaviorDefinition. A DomStatusTransition has the following properties:

    | Property   | Type   | Explanation                                                                                                                                                                                                           |
    |--------------|--------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Id           | string | The ID of the transition, consisting of lowercase characters only. Example: “initial_to_accepted_status”                                                                                                          |
    | FromStatusId | string | The ID of the status from which the DomInstance will transition.                                                                                                                                                      |
    | ToStatusId   | string | The ID of the status to which the DomInstance will transition.                                                                                                                                                        |
    | FlowLevel    | int    | The flow level of the transition compared to other transitions. The main transition will have FlowLevel 0 (the highest priority), while alternate transitions from the same status will have FlowLevel 1 or more. |

    > [!NOTE]
    > The Transitions collection should not contain any DomStatusTransition objects with identical IDs.

- For each status, you can configure the requirements of a specific field. To do so, create DomStatusSectionDefinitionLinks that each include DomStatusFieldDescriptorLinks. A DomStatusSectionDefinitionLink has the following properties:

    | Property             | Type                                | Explanation                                                           |
    |----------------------|-------------------------------------|-----------------------------------------------------------------------|
    | Id                   | DomStatusSectionDefinitionLinkId    | The SectionDefinitionID and the status ID.                            |
    | FieldDescriptorLinks | List\<DomStatusFieldDescriptorLink> | The links to FieldDescriptors that are part of the SectionDefinition. |

    A DomStatusFieldDescriptorLink contains the following properties:

    | Property        | Type              | Explanation                                                              |
    |-------------------|-------------------|--------------------------------------------------------------------------|
    | FieldDescriptorId | FieldDescriptorID | The ID of the linked FieldDescriptor.                                    |
    | Visible           | bool              | Whether this field should be visible in the UI for this status.          |
    | RequiredForStatus | bool              | Whether a value for this field must be present and valid in this status. |
    | ReadOnly          | bool              | Whether values of this field are read-only in this status.               |

    > [!NOTE]
    >
    > - When there is no FieldDescriptorLink for an existing FieldDescriptor, then no values will be allowed for this FieldDescriptor in that specific status.
    > - The Visible property is only used to tell the UI whether the field should be visible or not.
    > - When a field is marked as required, then at least one value for this FieldDescriptor should be present in a DomInstance and all values for this FieldDescriptor should be valid according to the validators of that descriptor (if any were defined).
    > - When a field is marked as read-only for a specified status, the values cannot be changed. If none were present before transitioning to that status, none can be added anymore once the DomInstance is in that status.
    > - The existence of the SectionDefinitions and FieldDescriptors are not checked when a DomBehaviorDefinition is saved.

    Some examples of fields you can define:

    | Case                       | RequiredForStatus | ReadOnly | Note                                                                                                                                                              |
    |------------------------------|-------------------|----------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | Not allowed                  | N/A               | N/A      | When no values are allowed to be present, no FieldDescriptorLink should be added to the list.                                                                     |
    | Optional & editable      | false             | false    | A value can optionally be added or an existing value can be updated or deleted.                                                                                   |
    | Optional & not editable  | false             | true     | A value may be present but it is not required. None can be added, edited or deleted.                                                                              |
    | Required & editable      | true              | false    | A valid value must be present when transitioning to the status in question and it can be updated as long as there is at least one value and all values are valid. |
    | Required & not editable | true              | true     | A valid value must be present when transitioning and it can no longer be changed in this status.                                                                  |

If a DomInstance is created without a status, the DomManager will automatically assign the initial status when it detects that the instance is linked to a DomDefinition that uses the status system.

Transitioning to another status can only be done by means of a specific transition request. Changing the status by performing a status update is not allowed. A transition request requires the ID of the DomInstance and the ID of the transition. These requests can be sent using the helper.

```txt
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

#### Connecting a DataMiner System to the cloud \[ID_30513\]

It is now possible to connect a DataMiner System to the cloud. To do so:

1. Verify that each DMA that will be connected to the cloud is able to reach the following endpoints:

    - `https://connect.dataminer.services/`
    - `wss://tunnel.dataminer.services/`

2. Download the appropriate DataMiner Cloud Pack installer from [DataMiner Dojo](https://community.dataminer.services/downloads/) and install it on one or more DMAs in the cluster. As .NET 5 is required to connect the DataMiner Cloud, you can choose an installer that includes or downloads .NET 5. If .NET 5 is already installed in your system, choose the installer that does not include .NET 5.

3. In DataMiner Cube, go to System Center \> *Users / Groups* and make sure you have the following user permissions.

    - *System configuration* > *Cloud gateway* > *Connect to DCP*
    - *System configuration* > *Cloud gateway* > *Disconnect from DCP*

4. On the System Center \> *Cloud* page, click the *Connect* button. A pop-up browser window will open.

    > [!NOTE]
    > Internet Explorer is not supported for this. If your default browser is Internet Explorer, you may need to change this temporarily in order to continue with this procedure.

5. Specify the following information in the pop-up window:

    - *Organization*: Specify your organization, either by selecting it in the drop-down box if it already exists in the system, or by clicking *Create new* and specifying your name and DNS.
    - DMS name: Specify the name you want to use for your DMS.
    - DMS URL: Specify a URL-friendly version of the DMS name.

6. Select the checkbox to agree to the terms of service and click *Connect*.

7. On the System Center \> *Cloud* page, wait until the status under *Cloud info* changes to *Registered*. This can take up to half a minute.

If your DMS was already connected to the cloud using the earlier soft-launch version of this feature, install the DataMiner Cloud Pack installer on at least one DMA that was already hosting the cloud gateway, as described in step 2 above.

> [!NOTE]
> Make sure that all users that should be able to share data with the cloud have the necessary user permissions under *System configuration* > *Cloud sharing*. Refer to the DataMiner Help for more details.

#### New DataMiner process: SLSpiHost \[ID_30869\]

From now on, all processing with regard to system performance indicators (SPIs) will be performed by the new SLSpiHost process instead of the SLNet process.

#### DataMiner Object Model: Actions & buttons \[ID_30923\]

It is now possible to define actions on a DomBehaviorDefinition, which can be triggered via the DomHelper, and buttons that will execute one or more actions when clicked.

##### Defining an action

You can define an action by adding an IDomActionDefinition to the ActionDefinitions list of a DomBehaviorDefinition. Each action definition has an ID of type string and a condition of type IDomCondition. The ID must be unique for the DomBehaviorDefinition in question and can only contain lower-case characters.

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

| Property  | Type          | Description                                                                                                     |
|-----------|---------------|-----------------------------------------------------------------------------------------------------------------|
| ContextId | IDMAObjectRef | The ID of the object for which the action was executed. Note: Currently, only DomInstance IDs can be specified. |
| ActionId  | string        | The ID of the action that triggered the script.                                                                 |

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

| Reason                          | Description                                                                                                                                 |
|---------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------|
| Unknown                         | An unknown error has occurred. Check the logging for more information.                                                                      |
| UnexpectedExceptionOccurred | An unexpected exception has occurred when executing an action. ExceptionMessage will contain the message of the exception.              |
| ScriptReturnedErrors            | A script has returned errors. ErrorData will contain a list of all the errors that were returned.                                       |
| ActionDefinitionNotFound    | The action that had to be executed could not be found by means of the IDMAObjectRef context ID.                                             |
| ConditionNotMet                 | The condition that was specified was not met. InnerTraceData may contain additional TraceData explaining why the condition was not met. |

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

| Property            | Type                      | Description                                                                                                                        |
|---------------------|---------------------------|------------------------------------------------------------------------------------------------------------------------------------|
| Id                  | string                    | The ID of the button. This ID must be unique for the DomBehaviorDefinition in question and can only contain lower-case characters. |
| Layout              | DomButtonDefinitionLayout | Additional properties that define how the button will be displayed. See below.                                                     |
| VisibilityCondition | IDomInstanceCondition     | The condition that defines when the button will be shown.                                                                          |
| ActionDefinitionIds | List\<string>             | The IDs of the actions that should be executed.                                                                                    |

The DomButtonDefinitionLayout class has the following properties:

| Property | Type   | Description                                                                             |
|----------|--------|-----------------------------------------------------------------------------------------|
| Text     | string | The text that will be displayed on the button.                                          |
| Icon     | string | The (optional) icon that will be displayed on the button.                               |
| ToolTip  | string | The (optional) tooltip with more information about the button.                          |
| Order    | int    | The number assigned to the button that determines its place within a series of buttons. |

#### Virtual functions can now be included in element connectivity chains \[ID_30944\]

When creating a connectivity chain between parameters in an element, it is now possible to also select virtual functions to be included in that chain.

> [!NOTE]
> Virtual function alarms reside on the main element. When multiple virtual functions are defined in different element connectivity chains, the most severe RCA will be shown in the element RCA of the alarm.

#### Video thumbnails: Support for HLS streams \[ID_30953\]

Video thumbnails now also support HTTP Live Streaming (HLS). No plugins need to be installed.

Syntax:

```txt
#https://dma/videothumbnails/video.htm?type=HTML5-HLS&source=https://videoserver/stream.m3u8
```

> [!NOTE]
>
> - For more information on HLS, see <https://github.com/video-dev/hls.js/>
> - All HLS resources must be delivered with CORS headers that permit GET requests.
> - If you access a video thumbnail player that is using HTTPS, then the media must also be served over HTTPS.
> - When the video starts automatically, in order to comply with the browser's autoplay policy, it will be muted until the user turns on the sound.

#### Logging: SLCloudEndpointManager.txt renamed to SLUMSEndpointManager.txt \[ID_30974\]

The *SLCloudEndpointManager.txt* log file has been renamed to *SLUMSEndpointManager.txt*.

#### SLWatchdog will now by default send an email message when an anomaly was detected \[ID_30982\]

In the *MaintenanceSettings.xml* file of a newly installed DataMiner Agent, the Watchdog.Email@active setting will now by default be set to true. In other words, on a newly installed DataMiner Agent, the SLWatchdog process will now by default send an email to the configured destination(s) whenever it detects an anomaly.

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

#### Redundancy groups: Additional information in information events and Automation scripts \[ID_31358\]

When elements within a redundancy group are switched, from now on, additional information will be added both to the information events and to the Automation scripts that are executed.

##### Information events

The following information will be added to the information events.

- When a user changes the mode of a redundancy group, one of the following strings will now be added to the information event with parameter description “Edited”:

  - *RDG By Administrator: Set Mode to Automatic switching*
  - *RDG By Administrator: Set Mode to Manual switchback*
  - *RDG By Administrator: Set Mode to Manual switching*

- When a user sets an element to maintenance mode or takes an element out of maintenance mode, one of the following strings will now be added to the information event with parameter description “Edited”:

  - *RDG By Administrator: Switch to maintenance mode on \<element>*
  - *RDG By Administrator: Switch back from maintenance mode on element \<element>*

- When a switch is performed, an additional information event with parameter description “Redundancy switch” will now be generated to indicate the cause of the switch. In case of a manual switch, the information event will mention the user and in case of an automatic switch, it will mention the trigger ID.

- When DataMiner intervenes in the switching process, an information event with parameter description “Linked to” is generated. From now on, this event will also mention the element from which the switch occurred. It will now contain e.g. “RDG1, Unlinked from RDG3” instead of just “RDG1”.

##### Automation scripts

When an Automation script is triggered as part of an redundancy group action, that script will now have the following additional parameters. These can then be requested from within the Automation script using the GetScriptParam(\<id>) method on the engine object.

| ID | Name | Description |
|--|--|--|
| 65007 | \<Redundancy User> | In case of manual switching, this parameter will contain the name of the user who performed the switch. |
| 65008 | \<Redundancy Trigger> | In case of automatic switching, this parameter will contain the ID of the trigger that caused the switch to be performed. To look up the trigger, send a GetRedundancyGroup-ByID or GetRedundancyGroupByName message and check the Triggers array in the response. |
| 65009 | \<Redundancy Triggering Element> | In case of automatic switching, this parameter will contain the ID of the element that has caused the trigger to be fired. ID format: `<DataMinerID>/<ElementID>` |
| 65010 | \<Redundancy Primary> | This parameter will contain the ID of the primary element involved in the switch. ID format: `<DataMinerID>/<ElementID>` |
| 65011 | \<Redundancy Backup> | This parameter will contain the ID of the backup element involved in the switch. ID format: `<DataMinerID>/<ElementID>` |

#### Automatic Incident Tracking enabled by default on new systems \[ID_31617\]

From now on, Automatic Incident Tracking will be enabled by default

- on newly installed systems, and
- on systems that upgrade from a version on which Automatic Incident Tracking was not yet available (i.e. versions older than version 10.0.11).

> [!NOTE]
> In systems where Automatic Incident Tracking has explicitly been disabled, the feature will remain disabled.

#### Table filters of type 'fullfilter' now support filtering by means of regular expressions \[ID_31893\]

Inside a table filter of type “fullfilter”, it is now possible to filter by means of regular expressions.

In the following example, a regular expression will be applied to column 512:

```txt
fullfilter=(512 REGEX 'x\'y\\\\z' AND 510 == 1000)
```

> [!NOTE]
> In the example above, the regular expression contains a single quote and a backslash character that are part of the query. Since the “fullfilter” syntax requires these characters to be escaped, they have been escaped with an additional backslash character, and as a backslash character in a regular expression also needs to be escaped, four backslash characters were needed here.
