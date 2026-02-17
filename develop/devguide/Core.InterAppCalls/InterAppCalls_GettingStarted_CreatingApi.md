---
uid: InterAppCalls_GettingStarted_CreatingApi
---

# Creating an API

To start using the InterApp framework, you first need to create an API with the classes that will represent your known messages. The namespace you make here needs to be present on both the source and the destination of your communication channel. You can achieve this by:

- Creating the API in a new solution and adding it as a NuGet package, or
- Creating the API in a precompile QAction and copying it to where you need it.

> [!IMPORTANT]
> Namespaces you use have to be the same in the source and destination. Because of issues with assembly resolving (see [Assembly Binding](xref:Assembly_Binding)), we strongly recommend copying the Message class definitions into the different scripts and connectors as you need them.

The InterApp framework allows a lot of freedom in the creation of the message classes. The default internal serializer is designed to be able to handle almost anything: custom classes, inheritance, abstraction, interfaces, private fields, public properties, objects, etc. There is no need to worry about any JSON properties or anything to do with how it serializes in the background. Just create the classes as you see fit. Any class that you want to define as a possible message you inherit from the *InterAppCalls.CallSingle.Message* class.

For example:

```csharp
public class MyMessage : Message
{
    public string MyProperty { get; set; }
}
```

A few key things to keep in mind:

- Classes in API should not contain any methods and logic. They should only contain the data you want to transfer. For information on how to parse the message, see [Creating an executor](xref:InterAppCalls_GettingStarted_CreatingExecutor).
- Do not pass along SLProtocol. The SLProtocol object should always be taken from the Run method of the QAction that your code is working in.
- Do not pass along the Engine instance from an automation script.
- You are free to choose how you organize your API, but we recommend adding a comment with versioning at the top of the API.

When you have created an API, the next thing to do is to [create an executor](xref:InterAppCalls_GettingStarted_CreatingExecutor).
