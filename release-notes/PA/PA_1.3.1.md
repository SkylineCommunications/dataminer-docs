---
uid: PA_1.3.1
---

# PA 1.3.1

> [!NOTE]
> This version requires that **SRM 1.2.28 [CU1]** is installed.

## New features

#### Support for callback mechanism using DOM to transfer data between activities [ID_35671]

Process Automation now supports the use of DOM to execute an activity task asynchronously by means of a callback mechanism. The new *UpdateDomInstance* method can be used for this. It allows you to update a DOM instance with a Profile-Load Script before exiting the script.

For example:

```csharp
var helper = new PaProfileLoadDomHelper(engine);

var messageType = helper.InputData.ProcessInfo.MessageType;

try
{
    switch (messageType)
    {
        case MessageType.Request:
        {
        helper.UpdateField("PA DOM Field", "Initial token is Processing");
        helper.UpdateDomInstance();
        var scriptInfo = helper.CreateCallBackScriptInfo(MessageType.Response);
        var jsonCallbackInfo = JsonConvert.SerializeObject(scriptInfo);

        var element = engine.FindElement("External Element") ?? throw new ElementNotFoundException("Failed to find element 'External Element'");
        element.AddRow(engine, 100, new object[] { helper.TokenId.ToString(), 1, jsonCallbackInfo });

        }

        break;

    case MessageType.Response:
        {
        helper.UpdateField("PA DOM Field", "Initial token is completed");
        helper.ReturnSuccess();
        }
            break;
    case MessageType.Finish:
            {
        var element = engine.FindElement("External Element") ?? throw new ElementNotFoundException("Failed to find element 'External Element'");
        element.DeleteRow(engine, 100, helper.TokenId.ToString());
        helper.SendFinishMessageToTokenHandler();
        }            
            break;

    case MessageType.ForceFinish:
        {
        var element = engine.FindElement("External Element");
        element.DeleteRow(engine, 100, helper.TokenId.ToString());
        }
            break;
        default:
        break;
    }
}
catch (Exception ex)
{
    helper.Log($"An issue occurred: {ex}", PaLogLevel.Error);
    helper.SendErrorMessageToTokenHandler();
}
```

#### Support for configuring Max Time In Queue, Preemptive, and Priority settings for token that gets pushed into process [ID_35814]

A new overload method, *PushToken*, is now available, which allows you to define the settings Max Time In Queue, Preemptive, and Priority for a token when this token gets pushed into a process. These settings are defined using the class *PushPaTokenSettings*. In case Max Time In Queue or Priority are set to zero, the default values will be used.

In addition, the *PA None Start Event* and the *PA Timer Start Event* functions have been extended to add these parameters to the corresponding profile definition, so that these settings can be defined when an activation window is created.

The *PushToken* method without a DOM instance ID has also been removed, as this has never been supported, and the latest versions of Process Automation require a DOM instance to transfer data between activities.

## Changes

### Enhancements

#### Assigning tasks to a specific user or group [ID_35082]

While up to now Process Automation created user tasks without assigning them to specific users, now you can configure a process definition so that tasks are assigned or reassigned to a user or a group of users when they are created.

During the configuration of a process definition,you can select a Process DOM field for either the group or the user so that the group or user name can be retrieved when the user task gets created. With the *Fixed* option you can already pre-select the exact group and user. However, if a Process DOM field is selected for a group, you cannot pre-select a fixed user. The *Any* option allows you to postpone the selection of the group or user to the time when the task gets created.

> [!NOTE]
> This is the first step towards being able to assign user tasks to specific users or groups. For now, nothing is done with the user or user group info yet.

#### Improved handling of gateway queue tokens [ID_35403]

The way gateway queues are processed has been improved to avoid a possible bottleneck in the handling of gateway queue tokens.

A token for a gateway queue (except for a merge gateway) will now be handled immediately and passed to the next queue. For a merge gateway, the token will be created in the InQueue state with the waiting flag set to true if the merge is not complete.

#### Skyline Queue Manager no longer sends message to itself when forwarding tokens [ID_35577]

The *Skyline Queue Manager* connector has been adjusted so that it no longer sends a message to itself when forwarding tokens, and it adds the token directly to the database. This will improve the performance of the connector.

### Fixes

#### No tokens processed if more tokens were in queue than the Concurrent Tasks parameter value [ID_35437]

If a queue had more tokens with the *InQueue* status than the number indicated by the *Concurrent Tasks* parameter, it could occur that no more tokens were processed.

The logic of the *Skyline Queue Manager* connector has now been adjusted so that the queue will be able to process multiple tokens at once, instead of processing them one by one like before.
