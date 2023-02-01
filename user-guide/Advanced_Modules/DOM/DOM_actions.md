---
uid: DOM_actions
---

# DOM actions

From DataMiner 10.1.11/10.2.0 onwards, it is possible to define actions on a [DomBehaviorDefinition](xref:DomBehaviorDefinition) that can be triggered via the `DomHelper`. These actions can only be executed when a condition is met.

You can also define buttons to be shown in the UI that will execute one of these actions when clicked. A button definition also has a condition to determine when the button is shown. This way you can hide buttons when they are not applicable.

An action is always executed in a specific context, i.e. for a context object. Currently only DOM instances are supported.

## Defining an action

You can define an action by adding an `IDomActionDefinition` to the `ActionDefinitions` list of a `DomBehaviorDefinition`. Each action definition has an ID (of type string) and a condition (of type `IDomCondition`). Note that the ID can only contain lower-case characters and must be unique across this `DomBehaviorDefinition` and its parent or child definitions. There is currently only one action type.

### ExecuteScriptDomActionDefinition

This action can be used to execute a specified script. This has the following properties:

| Name | Type | Description |
|--|--|--|
| Id | string | The ID of the action. |
| Condition | IDomCondition | The condition that should be met before the action is allowed to be executed. |
| Script | string | The name of the script that can be executed. |
| Async | bool | Determines whether the script will be run synchronously or asynchronously. When this is set to true, no errors or info data from the script will be returned. |
| ScriptOptions | List\<string> | Option strings that are passed to the SLAutomation process during execution. |
| IsInteractive | bool | Determines whether the script should be executed as an interactive script. See [Interactive script](#interactive-script). |

> [!NOTE]
>
> - The *ScriptOptions* property can contain the option strings you would put in the *Options* property of an [ExecuteScriptMessage](xref:Skyline.DataMiner.Net.Messages.ExecuteScriptMessage). This can be used to for example pass along a parameter (e.g. "PARAMETER:1:SomeValue"). Note that you should not add the "DEFER" option as this will be added automatically depending on the value of the *Async* property.
> - If no condition is defined (null), the action can always be executed.

The scripts that will be executed using this action require a custom entry point of type "OnDomAction". This entry point method should have the `IEngine` object as it first argument, and an `ExecuteScriptDomActionContext` object as its second object. A script with this entry point can look like this:

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
            engine.GenerateInformation($"The DOM action with ID '{context.ActionId}' was executed");
        }
    }
}
```

The `ExecuteScriptDomActionContext` object has the following properties:

| Name | Type | Description |
|--|--|--|
| ContextId | IDMAObjectRef | The ID of the object that the action was executed for. |
| ActionId | string | The ID of the action that triggered this script. |

> [!NOTE]
> The *ContextId* is of type `IDMAObjectRef`. That means it can contain many different types of IDs from DataMiner objects. Currently, only the `DomInstanceId` is supported, but this could possibly change. Make sure to cast it to the expected ID type and have a null check in place.

### Script output

It is possible for the script to return data to the instigator of the action. If the executed script added script output to the engine object, it will be returned in a `DomActionInfo` `InfoData` via the `TraceData`. The example below illustrates how data is added to the script and how it can be retrieved in another script/application.

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
    engine.GenerateInformation($"DOM script returned '{returnValue}'");
}
```

### Interactive script

From DataMiner 10.2.8/10.3.0 onwards, it is possible to execute an interactive Automation script (IAS) using the DOM actions. When a client triggers a DOM action, it can then interact with the script.

Flow:

1. A client executes a DOM action with an IAS. The `ExecuteAction` method on the helper will return almost immediately. The `TraceData` will contain a `DomActionInfo` object with type `DomActionInfo.Type.ScriptExecutionId`. This info object has the ID of the executed script available in the *ExecutionId* property.

1. The client can now send a `ScriptControlMessage` of type `Launch` using the aforementioned ID.

1. DataMiner will now send all `ScriptProgressEventMessages` of this script to this client, enabling it to interact with the script.

> [!NOTE]
>
> - Scripts marked as interactive will always be executed asynchronously. The value of the *Async* property on the `ExecuteScriptDomActionDefinition` will be ignored.
> - Since the script is executed asynchronously and the execution call therefore returns before the script is actually running, the `TraceData` will not contain the script output or errors that occur during the script.
> - Executing an IAS by using the DOM actions is supported in the Low-Code Apps from DataMiner 10.3.3/10.4.0 onwards. <!-- RN 35226 -->

## Executing an action

You can execute an action by calling the `ExecuteAction` method on the `DomInstance` `CrudHelperComponent` of the `DomHelper`. You need to pass along the ID of the `DomInstance` for which the action is executed and the ID of the action that has to be executed.

```csharp
domHelper.DomInstances.ExecuteAction(domInstance.ID, "some_action_id");
```

The execute call returns `TraceData` when the action failed or the condition was not met. This `TraceData` will contain a `ManagerStoreError` with reason *ObjectDidNotExist* if a non-existing `DomInstance` is given. In other common error cases, a `DomActionError` will be returned. This error type has the following reasons:

| Reason | Description |
|--|--|
| Unknown | An unknown error occurred. This should never happen. Check the logging to find more information. |
| UnexpectedExceptionOccurred | An unexpected exception occurred when executing an action. *ExceptionMessage* contains the message of the exception. |
| ScriptReturnedErrors | A script that was (being) executed returned errors. *ErrorData* contains a list of all the returned errors. |
| ActionDefinitionNotFound | The action that was requested to be executed could not be found using the `IDMAObjectRef` context ID. |
| ConditionNotMet | The condition that was set on the action was not met. *InnerTraceData* can contain extra `TraceData` on why the condition was not met. |

Additionally, the `TraceData` can also include information using one or more `DomActionInfo` objects. This info object has a *Type* property that describes the info it contains.

| Type | Description |
|--|--|
| ScriptOutput | Contains the script output in the *Data* property. |
| ScriptExecutionId | Contains the execution ID of the script that was executed for the action in the *ExecutionId* property. |

## Conditions

An `ActionDefinition` can only be executed when a pre-defined condition is met. It is currently possible to define the following conditions:

- **StatusCondition**

  Defines a condition that is fulfilled when a `DomInstance` has one of the defined statuses. The list of required statuses can be given via the constructor or added to the *Statuses* list property. This condition will not return extra `TraceData` when not met.

  ```csharp
  var condition = new StatusCondition(new List<string> { "first_status" });
  ```

- **ValidForStatusTransitionCondition**

  Defines a condition that is met when a `DomInstance` is valid for a given status transition. The required transition ID must be assigned to the *TransitionId* property. When this condition is not met, extra `TraceData` will be returned (via the *InnerTraceData* property of the `DomActionError`). This `TraceData` should contain an error of type `DomStatusTransitionError`. For more information about this error type, see [Creating and transitioning DOM instances](xref:DOM_status_system#creating-and-transitioning-dom-instances).

  ```csharp
  var condition = new ValidForStatusTransitionCondition("first_to_second_transition");
  ```

## Defining buttons

The `DomBehaviorDefinition` also contains a list of `IDomButtonDefinitions`. These can be used to have one or more buttons shown in the UI. Each button can be linked to one action that will be executed when they are clicked.

At present, you can only define buttons to be shown for a `DomInstance` by using the `DomInstanceButtonDefinition`.

A `DomInstanceButtonDefinition` also has a **condition** that determines whether the button is shown or not. The button should always be shown when there is no condition defined.

The `DomInstanceButtonDefinition` has the following properties:

| Name | Type | Description |
|--|--|--|
| Id | string | The ID of the button. This must be unique to this `DomBehaviorDefinition` and must be lower case. |
| Layout | DomButtonDefinitionLayout | Contains extra properties to define how the button will be displayed (see properties table below). |
| VisibilityCondition | IDomInstanceCondition | Condition that defines when the button will be shown. |
| ActionDefinitionIds | List\<string> | Contains the ID of the action that should be executed. Can contain multiple, but currently, only one is allowed. |

The `DomButtonDefinitionLayout` class has the following properties:

| Name | Type | Description |
|--|--|--|
| Text | string | Text that will be displayed on the button. |
| Icon | string | Optional icon for this button. |
| ToolTip | string | Optional tooltip that can contain more info about this button. |
| Order | int | Can be used to manage the order in which multiple buttons should be displayed. |

> [!NOTE]
> The `IDomInstanceCondition` on the buttons explains which type of condition applies to the visibility. Each subtype has properties that contain extra information to determine whether the condition is met (see [Conditions](#conditions)). A UI that displays these buttons needs to resolve these locally.
