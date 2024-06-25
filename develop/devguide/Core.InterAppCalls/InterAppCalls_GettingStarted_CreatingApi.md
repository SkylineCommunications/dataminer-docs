---
uid: InterAppCalls_GettingStarted_CreatingApi
---

# Creating an API

The first step is to create your API, with the classes that will represent your known messages. The namespace you make here needs to be present on both the source and destination of your communication channel. You can achieve this by:

- Creating the API in a new solution and adding it as a NuGet package, or
- Creating the API in a precompile QAction and copying it to where you need it.

> [!NOTE]
> Namespaces you use have to be the same in the source and destination. We strongly recommend creating the API in a separate custom solution and using NuGet packages.

The InterApp framework allows a lot of freedom in the creation of the message classes. The default internal serializer was created to be able to handle almost anything: custom classes, inheritance, abstraction, interfaces, private fields, public properties, objects, etc. There is no need to worry about any JSON properties, or anything to do with how it serializes in the background. Just create the classes as you see fit. Any class that you want to define as a possible message you simply inherit from the InterAppCalls.CallSingle.Message class.

For example:

```csharp
public class MyMessage : Message
{
    public string MyProperty { get; set; }
}
```

A few key things to keep in mind:

- Classes in API should not contain any methods and logic. They should only contain the data you want to transfer. (For information on how to parse the message, see Creating an executor.)
- Do not pass along SLProtocol. The SLProtocol object should always be taken from the Run method of the QAction that your code is working in.
- Do not pass along the Engine instance from an Automation script.
- You are free to choose how you organize your API, but we recommend to add a comment with versioning at the top of the API.

## See also

- [Creating executors that define how to process a message.](xref:InterAppCalls_GettingStarted_CreatingExecutor)
- [Receiving a call.](xref:InterAppCalls_GettingStarted_ReceivingCall)
- [Sending a call.](xref:InterAppCalls_GettingStarted_SendingCall)
