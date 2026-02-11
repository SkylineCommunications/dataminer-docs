---
uid: InterAppCalls_GettingStarted_CreatingExecutor
keywords: Executor
---

# Creating an executor

When you have [created an API](xref:InterAppCalls_GettingStarted_CreatingApi) describing the different messages and their content, the next thing to do is to create an executor that will define how an incoming message should be handled.

The executor is never shared between connectors or automation scripts. You create it at the destination of a message and it is unique to that connector. It will hold all the methods that can access the content of the message and do something with it.

A few common examples:

- The methods in the executor could be used to translate the content of your InterApp message into a serial, SNMP, HTTP, etc. command to be sent to the device.
- The methods could be used to perform parameter gets and sets based on the message content.
- An executor could be created in an automation script to create an information message to indicate that a message was received.
- etc.

You create an executor by making a new class that inherits from `MessageExecutor<T>`, where T is a class from your messages defined in the API.

```csharp
public class MyMessageExecutor : MessageExecutor<MyMessage>
```

The Visual Studio IDE will then assist you in correctly implementing your executor.

![Executor implementation in Visual Studio](~/develop/images/InterApp_VS1.png)

The executor has several methods that will by default be called when a message is executed (in the specified order):

1. DataGets (always)
1. Parse (always)
1. Validate (always)
1. Modify (if validate was true)
1. DataSets (if validate was true)
1. CreateReturnMessage (always)

Default execute code (happens in background):

```csharp
executor.DataGets(dataSource);
executor.Parse();

bool result = executor.Validate();

if (result)
{
   executor.Modify();
   executor.DataSets(dataDestination);
}

optionalReturnMessage = executor.CreateReturnMessage();

return result;
```

You now have an executor that can do what you want. It can access your received message by calling the `Message` property.

```csharp
public override bool Validate ()
{
    if (String.IsNullOrWhiteSpace(Message.MyProperty))
    {
        return false;
    }
    
    return true;
}
```

Some methods, like *DataSets* and *DataGets*, have an object argument. This will mostly be `SLProtocol` or `IEngine`. These can also be used for a custom class with data, a database object, etc so you as a developer have more flexibility.

```csharp
public override void DataSets(object dataDestination)
{
    SLProtocol protocol = (SLProtocol)dataDestination;
    protocol.DeleteRow(Parameter.Mytable.tablePid, Message.MyProperty);
}
```

Lastly, you will also find one method that has a return type, i.e. *CreateReturnMessage*. This is optional. It can be used to create a message to return and have it bubble up to the calling methods. If you do not need this, you can just return null. You could consider it the "return" for the entire executor.

```csharp
public override Message CreateReturnMessage()
{
    return null;
}
```

In other cases, you want to immediately create a message that will eventually need to be returned to the sender.

```csharp
public override Message CreateReturnMessage()
{
    return new MyResponse { Guid = Message.Guid, Success = true };
}
```

The executor follows a design pattern called the **Template Method** pattern. This has the following benefits:

- Consistency: The overall process is consistent and follows the defined sequence.
- Flexibility: Specific steps can be overridden in subclasses if different behavior is needed for certain executors.
- Clarity: The sequence of steps is clearly defined in one place (the execute method of Executor).

This design pattern ensures that the core structure of the execution process remains intact while allowing for customization and extension where necessary.

> [!NOTE]
> A return message does not necessarily need to be something to send to an external destination. A message could also be part of an internal API used to move data between classes, methods or QActions within your own connector. This can also be returned.

> [!TIP]
> If your logic does not require the standard Method Template, consider using the [simple executor](xref:InterAppCalls_Customizations#creating-a-simple-executor). This approach is ideal for simpler situations and helps avoid code bloat.
